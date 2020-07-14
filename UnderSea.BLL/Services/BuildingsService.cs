using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnderSea.BLL.ViewModels;
using UnderSea.DAL.Context;
using UnderSea.DAL.Models.Buildings;

namespace UnderSea.BLL.Services
{
    public class BuildingsService : IBuildingsService
    {
        private readonly UnderSeaDbContext db;
        private readonly ILogger logger;

        public BuildingsService(UnderSeaDbContext db, ILogger<BuildingsService> logger)
        {
            this.db = db;
            this.logger = logger;
        }

        public async Task<List<BuildingInfoViewModel>> GetBuildingInfos(int userId)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Building, BuildingInfoViewModel>()
                                                        .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Type.Name))
                                                        .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Type.Price))
                                                        .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Type.Description))
                                                        .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Type.ImageUrl))
                                                        );
            var mapper = new Mapper(config);
            var buildingInfos = new List<BuildingInfoViewModel>();
            var user = await db.Users
                .Include(u => u.Country)
                .ThenInclude(c => c.BuildingGroup)
                .ThenInclude(bg => bg.Buildings)
                .ThenInclude(b => b.Type)
                .SingleAsync(u => u.Id == userId);
            var userbuildings = user.Country.BuildingGroup.Buildings;
            
            userbuildings.ForEach(building => buildingInfos.Add(mapper.Map<BuildingInfoViewModel>(building)));
            return buildingInfos;
        }

        public async Task PurchaseBuildingById(int userId, int buildingId)
        {
            // TODO authentication
            var user = await db.Users.Include(ent => ent.Country)
                .ThenInclude(ent => ent.BuildingGroup)
                .ThenInclude(ent => ent.Buildings)
                .ThenInclude(ent => ent.Type)
                .SingleAsync(user => user.Id == userId);
            var building = user.Country.BuildingGroup.Buildings.Single(building => building.Id == buildingId);
            var underConstructionCount = user.Country.BuildingGroup.Buildings.Sum(building => building.UnderConstructionCount);
            if (underConstructionCount > 0)
            {
                throw new Exception("Már épül egy épületed, nem kezdhetsz újat építeni.");
            }
            if (building.Type.Price > user.Country.Pearl)
            {
                throw new Exception("Nincs elég gyöngyöd az építéshez!");
            }
            building.UnderConstructionCount++;
            user.Country.BuildingTimeLeft = 5;
            user.Country.Pearl -= building.Type.Price;
            await db.SaveChangesAsync();
        }
    }
}
