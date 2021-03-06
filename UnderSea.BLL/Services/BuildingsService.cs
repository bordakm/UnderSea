﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnderSea.BLL.ViewModels;
using UnderSea.DAL.Context;
using UnderSea.DAL.Models.Buildings;

namespace UnderSea.BLL.Services
{
    public class BuildingsService : IBuildingsService
    {
        private readonly UnderSeaDbContext db;
        private readonly IMapper mapper;
        public BuildingsService(UnderSeaDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<BuildingInfoViewModel>> GetBuildingInfosAsync(int userId)
        {
            var user = await db.Users
                .Include(u => u.Country)
                .ThenInclude(c => c.BuildingGroup)
                .ThenInclude(bg => bg.Buildings)
                .ThenInclude(b => b.Type)
                .SingleAsync(u => u.Id == userId);
            var userBuildings = user.Country.BuildingGroup.Buildings;

            var buildingInfos = new List<BuildingInfoViewModel>();
            foreach (var building in userBuildings)
            {
                var dummy = mapper.Map<BuildingInfoViewModel>(building);
                dummy.RemainingRounds = user.Country.BuildingTimeLeft;
                buildingInfos.Add(dummy);
            }
            return buildingInfos;
        }

        public async Task<BuildingInfoViewModel> PurchaseBuildingByIdAsync(int userId, int buildingId)
        {
            var user = await db.Users.Include(ent => ent.Country)
                .ThenInclude(ent => ent.BuildingGroup)
                .ThenInclude(ent => ent.Buildings)
                .ThenInclude(ent => ent.Type)
                .SingleAsync(user => user.Id == userId);
            var building = user.Country.BuildingGroup.Buildings.Single(building => building.Type.Id == buildingId);
            var buildingTypes = db.BuildingTypes.ToList();
            var underConstructionCount = user.Country.BuildingGroup.Buildings.Sum(building => building.UnderConstructionCount);
            if (underConstructionCount > 0)
            {
                throw new HttpResponseException { Status = 400, Value = "Már épül egy épületed!"};
            }
            if (building.Type.Price > user.Country.Pearl)
            {
                throw new HttpResponseException { Status = 400, Value = "Nincs elég gyöngyöd az építéshez!" };
            }
            if(building.Type.StonePrice > user.Country.Stone)
            {
                throw new HttpResponseException { Status = 400, Value = "Nincs elég köved az építéshez!" };
            }
            building.UnderConstructionCount++;
            user.Country.BuildingTimeLeft = buildingTypes.Single(type => type.Id == buildingId).BuildingTime;

            user.Country.Pearl -= building.Type.Price;
            user.Country.Stone -= building.Type.StonePrice;
            await db.SaveChangesAsync();
            var buildingInfos = await GetBuildingInfosAsync(userId);
            return buildingInfos.Single(bi => bi.Id == buildingId);
        }
    }
}
