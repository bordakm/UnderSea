using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UnderSea.BLL.ViewModels;
using UnderSea.DAL.Context;
using UnderSea.DAL.Models.Buildings;

namespace UnderSea.BLL.Services
{
    class BuildingService : IBuildingService
    {
        private UnderSeaDbContext db;

        public BuildingService(UnderSeaDbContext db)
        {
            this.db = db;
        }

        public async Task<List<BuildingInfoViewModel>> GetBuildingInfos()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Building, BuildingInfoViewModel>());
            var mapper = new Mapper(config);
            var buildingInfos = new List<BuildingInfoViewModel>();
            await db.Buildings.ForEachAsync(building => buildingInfos.Add(mapper.Map<BuildingInfoViewModel>(building)));
            return buildingInfos;
        }

        public async Task PurchaseBuilding(int id)
        {
            // TODO authentication
            var user = await db.Users.FirstOrDefaultAsync();            
            var building = user.Country.BuildingGroup.Buildings.ToList()
                .Find(building => building.Id == id);
            var underConstructionCount = user.Country.BuildingGroup.Buildings.Sum(building => building.UnderConstructionCount);
            if (underConstructionCount > 0)
            {
                throw new Exception("A building is already under construction.");
            }
            if (building.Price > user.Country.Pearl)
            {
                throw new Exception("Not enough pearls.");
            }
            building.UnderConstructionCount++;
            user.Country.BuildingTimeLeft = 15;
            user.Country.Pearl -= building.Price;
            await db.SaveChangesAsync();
        }
    }
}
