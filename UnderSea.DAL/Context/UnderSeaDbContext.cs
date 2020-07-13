using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using UnderSea.DAL.Models;
using UnderSea.DAL.Models.Buildings;
using UnderSea.DAL.Models.Units;
using UnderSea.DAL.Models.Upgrades;

namespace UnderSea.DAL.Context
{
    public class UnderSeaDbContext : IdentityDbContext<User, Role, int>
    {
        public DbSet<Game> Game { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<UnitType> UnitTypes { get; set; }
        public DbSet<Attack> Attacks { get; set; }
        public UnderSeaDbContext(DbContextOptions<UnderSeaDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<FlowManager>();
            modelBuilder.Entity<ReefCastle>();

            modelBuilder.Entity<StormSeal>();
            modelBuilder.Entity<LaserShark>();
            modelBuilder.Entity<CombatSeaHorse>();

            modelBuilder.Entity<Alchemy>();
            modelBuilder.Entity<CoralWall>();
            modelBuilder.Entity<MudHarvester>();
            modelBuilder.Entity<MudTractor>();
            modelBuilder.Entity<SonarCannon>();
            modelBuilder.Entity<UnderwaterMartialArts>();

            var laserShark = new LaserShark();
            var stormSeal = new StormSeal();
            var combatSeaHorse = new CombatSeaHorse();

            var unit1 = new Unit
            {
                Id = 1,
                AttackId = 1,
                UnitGroupId = 1,
                Count = 0,
                Type = laserShark
            };
            var unit2 = new Unit
            {
                Id = 2,
                AttackId = 1,
                UnitGroupId = 1,
                Count = 0,
                Type = stormSeal
            };
            var unit3 = new Unit
            {
                Id = 3,
                AttackId = 1,
                UnitGroupId = 1,
                Count = 0,
                Type = combatSeaHorse
            };
            var unit4 = new Unit
            {
                Id = 4,
                UnitGroupId = 2,
                Count = 10,
                Type = laserShark
            };
            var unit5 = new Unit
            {
                Id = 5,
                UnitGroupId = 2,
                Count = 20,
                Type = stormSeal
            };
            var unit6 = new Unit
            {
                Id = 6,
                UnitGroupId = 2,
                Count = 40,
                Type = combatSeaHorse
            };
            var unit7 = new Unit
            {
                Id = 7,
                UnitGroupId = 3,
                Count = 0,
                Type = laserShark
            };
            var unit8 = new Unit
            {
                Id = 8,
                UnitGroupId = 3,
                Count = 0,
                Type = stormSeal
            };
            var unit9 = new Unit
            {
                Id = 9,
                UnitGroupId = 3,
                Count = 0,
                Type = combatSeaHorse
            };
            var unit10 = new Unit
            {
                Id = 10,
                UnitGroupId = 4,
                Count = 10,
                Type = laserShark
            };
            var unit11 = new Unit
            {
                Id = 11,
                UnitGroupId = 4,
                Count = 20,
                Type = stormSeal
            };
            var unit12 = new Unit
            {
                Id = 12,
                UnitGroupId = 4,
                Count = 40,
                Type = combatSeaHorse
            };

            var upgrade1 = new Upgrade
            {
                Id = 1,
                CountryId = 1,
                State = UpgradeState.Researched,
                Type = new Alchemy()
            };
            var upgrade2 = new Upgrade
            {
                Id = 2,
                CountryId = 1,
                State = UpgradeState.Researched,
                Type = new CoralWall()
            };
            var upgrade3 = new Upgrade
            {
                Id = 3,
                CountryId = 1,
                State = UpgradeState.Researched,
                Type = new MudHarvester()
            };
            var upgrade4 = new Upgrade
            {
                Id = 4,
                CountryId = 1,
                State = UpgradeState.Researched,
                Type = new SonarCannon()
            };
            var upgrade5 = new Upgrade
            {
                Id = 5,
                CountryId = 1,
                State = UpgradeState.Researched,
                Type = new UnderwaterMartialArts()
            };

            var building1 = new Building
            {
                Id = 1,
                BuildingGroupId = 1,
                Count = 1,
                Type = new FlowManager()
            };
            var building2 = new Building
            {
                Id = 2,
                BuildingGroupId = 1,
                Count = 1,
                Type = new ReefCastle()
            };
            var buildingGroup1 = new BuildingGroup
            {
                Id = 1,
                CountryId = 1
            };

            var unitGroup1 = new UnitGroup
            {
                Id = 1
            };
            var unitGroup2 = new UnitGroup
            {
                Id = 2
            };
            var unitGroup3 = new UnitGroup
            {
                Id = 3
            };
            var unitGroup4 = new UnitGroup
            {
                Id = 4
            };

            var country1 = new Country
            {
                Id = 1,
                AttackingArmyId = 1,
                DefendingArmyId = 2,
                BuildingTimeLeft = 0,
                Coral = 0,
                Name = "First Country",
                Pearl = 0,
                Score = 0,
                UpgradeTimeLeft = 0
            };
            var country2 = new Country
            {
                Id = 2,
                AttackingArmyId = 3,
                DefendingArmyId = 4,
                BuildingTimeLeft = 0,
                Coral = 0,
                Name = "First Country",
                Pearl = 0,
                Score = 0,
                UpgradeTimeLeft = 0
            };

            var game = new Game
            {
                Id = 1,
                Round = 1,
                CoralPictureUrl = "",
                PearlPictureUrl = "",
            };

            var user1 = new User
            {
                Id = 1,
                GameId = 1,
                Place = 1,
                Score = 100,
                UserName = "First User"
            };

            var user2 = new User
            {
                Id = 2,
                GameId = 1,
                Place = 2,
                Score = 50,
                UserName = "Second User"
            };

            var attack1 = new Attack
            {
                Id = 1,
                AttackerUserId = 1,
                DefenderUserId = 2
            };

        }

        protected void SeedData(ModelBuilder builder)
        {
            /*var country = new Country
            {
                Name = "Atlantisz",
                BuildingGroup = ,
                AttackingArmy = ,
                DefendingArmy = ,
                Coral = 500,
                Pearl = 500,
                Upgrades = ,
            };
            builder.Entity<User>()
                .HasData(new User {
                    Country = "Atlantisz",

                });*/
            builder.Entity<User>()
                .HasData(new User { });
            builder.Entity<User>()
                .HasData(new User { });
        }
    }
}
