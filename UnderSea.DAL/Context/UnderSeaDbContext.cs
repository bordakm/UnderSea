using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        public DbSet<BuildingType> BuildingTypes { get; set; }
        public DbSet<UpgradeType> UpgradeTypes { get; set; }
        public DbSet<Attack> Attacks { get; set; }
        public DbSet<UnitGroup> UnitGroups { get; set; }
        public DbSet<UnitLevel> UnitLevels { get; set; }
        public UnderSeaDbContext(DbContextOptions<UnderSeaDbContext> options) : base(options)
        {
            this.Database.SetCommandTimeout(TimeSpan.FromSeconds(100));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging(true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FlowManager>();
            modelBuilder.Entity<ReefCastle>();
            modelBuilder.Entity<Alchemy>();
            modelBuilder.Entity<StormSeal>();

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }

            var laserShark = new LaserShark
            {
                Id = 1
            };
            var sharkLv1 = new UnitLevel()
            {
                Id = 1,
                Level = 1,
                AttackScore = 5,
                DefenseScore = 5,
                UnitTypeId = 1,
                BattlesNeeded = 0
            };
            var sharkLv2 = new UnitLevel()
            {
                Id = 2,
                Level = 2,
                AttackScore = 7,
                DefenseScore = 7,
                UnitTypeId = 1,
                BattlesNeeded = 3
            };
            var sharkLv3 = new UnitLevel()
            {
                Id = 3,
                Level = 3,
                AttackScore = 10,
                DefenseScore = 10,
                UnitTypeId = 1,
                BattlesNeeded = 8
            };
            var stormSeal = new StormSeal
            {
                Id = 2,
            };
            var sealLv1 = new UnitLevel()
            {
                Id = 4,
                Level = 1,
                AttackScore = 6,
                DefenseScore = 2,
                UnitTypeId = 2,
                BattlesNeeded = 0
            };
            var sealLv2 = new UnitLevel()
            {
                Id = 5,
                Level = 2,
                AttackScore = 8,
                DefenseScore = 3,
                UnitTypeId = 2,
                BattlesNeeded = 3
            };
            var sealLv3 = new UnitLevel()
            {
                Id = 6,
                Level = 3,
                AttackScore = 10,
                DefenseScore = 5,
                UnitTypeId = 2,
                BattlesNeeded = 8
            };
            var combatSeaHorse = new CombatSeaHorse
            {
                Id = 3
            };
            var horseLv1 = new UnitLevel()
            {
                Id = 7,
                Level = 1,
                AttackScore = 2,
                DefenseScore = 6,
                UnitTypeId = 3,
                BattlesNeeded = 0
            };
            var horseLv2 = new UnitLevel()
            {
                Id = 8,
                Level = 2,
                AttackScore = 3,
                DefenseScore = 8,
                UnitTypeId = 3,
                BattlesNeeded = 3
            };
            var horseLv3 = new UnitLevel()
            {
                Id = 9,
                Level = 3,
                AttackScore = 5,
                DefenseScore = 10,
                UnitTypeId = 3,
                BattlesNeeded = 8
            };

            var reefCastle = new ReefCastle
            {
                Id = 1
            };
            var flowManager = new FlowManager
            {
                Id = 2
            };
            var stoneMine = new StoneMine
            {
                Id = 3
            };
            var alchemy = new Alchemy
            {
                Id = 1
            };
            var coralWall = new CoralWall
            {
                Id = 2
            };
            var mudHarvester = new MudHarvester
            {
                Id = 3
            };
            var mudTractor = new MudTractor
            {
                Id = 4
            };
            var sonarCannon = new SonarCannon
            {
                Id = 5
            };
            var underwaterMartialArts = new UnderwaterMartialArts
            {
                Id = 6
            };

            var upgrade1 = new Upgrade
            {
                Id = 1,
                CountryId = 1,
                State = UpgradeState.Unresearched,
                TypeId = 1
            };
            var upgrade2 = new Upgrade
            {
                Id = 2,
                CountryId = 1,
                State = UpgradeState.Unresearched,
                TypeId = 2
            };
            var upgrade3 = new Upgrade
            {
                Id = 3,
                CountryId = 1,
                State = UpgradeState.Researched,
                TypeId = 3
            };
            var upgrade4 = new Upgrade
            {
                Id = 4,
                CountryId = 1,
                State = UpgradeState.Unresearched,
                TypeId = 4
            };
            var upgrade5 = new Upgrade
            {
                Id = 5,
                CountryId = 1,
                State = UpgradeState.Unresearched,
                TypeId = 5
            };
            var upgrade6 = new Upgrade
            {
                Id = 6,
                CountryId = 1,
                State = UpgradeState.Researched,
                TypeId = 6
            };
            var upgrade7 = new Upgrade
            {
                Id = 7,
                CountryId = 2,
                State = UpgradeState.Unresearched,
                TypeId = 1
            };
            var upgrade8 = new Upgrade
            {
                Id = 8,
                CountryId = 2,
                State = UpgradeState.Unresearched,
                TypeId = 2
            };
            var upgrade9 = new Upgrade
            {
                Id = 9,
                CountryId = 2,
                State = UpgradeState.Unresearched,
                TypeId = 3
            };
            var upgrade10 = new Upgrade
            {
                Id = 10,
                CountryId = 2,
                State = UpgradeState.Unresearched,
                TypeId = 4
            };
            var upgrade11 = new Upgrade
            {
                Id = 11,
                CountryId = 2,
                State = UpgradeState.Unresearched,
                TypeId = 5
            };
            var upgrade12 = new Upgrade
            {
                Id = 12,
                CountryId = 2,
                State = UpgradeState.Unresearched,
                TypeId = 6
            };

            var buildingGroup1 = new BuildingGroup
            {
                Id = 1
            };
            var buildingGroup2 = new BuildingGroup
            {
                Id = 2
            };

            var building1 = new Building
            {
                Id = 1,
                BuildingGroupId = 1,
                Count = 4,
                TypeId = 1
            };
            var building2 = new Building
            {
                Id = 2,
                BuildingGroupId = 1,
                Count = 1,
                TypeId = 2
            };
            var building3 = new Building
            {
                Id = 3,
                BuildingGroupId = 2,
                Count = 1,
                TypeId = 1
            };
            var building4 = new Building
            {
                Id = 4,
                BuildingGroupId = 2,
                Count = 0,
                TypeId = 2
            };
            var building5 = new Building
            {
                Id = 5,
                BuildingGroupId = 1,
                Count = 0,
                TypeId = 3
            };
            var building6 = new Building
            {
                Id = 6,
                BuildingGroupId = 2,
                Count = 0,
                TypeId = 3
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
                Coral = 100000,
                Name = "First Country",
                Pearl = 100000,
                Stone = 5000,
                Score = 0,
                UpgradeTimeLeft = 0,
                UserId = 1,
                BuildingGroupId = 1,

            };
            var country2 = new Country
            {
                Id = 2,
                AttackingArmyId = 3,
                DefendingArmyId = 4,
                BuildingTimeLeft = 0,
                Coral = 100000,
                Name = "Another Country",
                Pearl = 100000,
                Stone = 5000,
                Score = 0,
                UpgradeTimeLeft = 0,
                UserId = 2,
                BuildingGroupId = 2

            };

            var game = new Game
            {
                Id = 1,
                Round = 1
            };

            var passwordHasher = new PasswordHasher<User>();
            var user1 = new User
            {
                Id = 1,
                GameId = 1,
                Place = 1,
                Score = 100,
                UserName = "first",
                NormalizedUserName = "FIRST",
                SecurityStamp = Guid.NewGuid().ToString()
            };
            user1.PasswordHash = passwordHasher.HashPassword(user1, "undersea");

            var user2 = new User
            {
                Id = 2,
                GameId = 1,
                Place = 2,
                Score = 50,
                UserName = "second",
                NormalizedUserName = "SECOND",
                SecurityStamp = Guid.NewGuid().ToString()
            };
            user2.PasswordHash = passwordHasher.HashPassword(user2, "undersea");

            modelBuilder.Entity<LaserShark>()
                .HasData(laserShark);
            modelBuilder.Entity<StormSeal>()
                .HasData(stormSeal);
            modelBuilder.Entity<CombatSeaHorse>()
                .HasData(combatSeaHorse);

            modelBuilder.Entity<ReefCastle>()
                .HasData(reefCastle);
            modelBuilder.Entity<FlowManager>()
                .HasData(flowManager);
            modelBuilder.Entity<StoneMine>()
                .HasData(stoneMine);

            modelBuilder.Entity<Alchemy>()
                .HasData(alchemy);
            modelBuilder.Entity<MudTractor>()
                .HasData(mudTractor);
            modelBuilder.Entity<MudHarvester>()
                .HasData(mudHarvester);
            modelBuilder.Entity<CoralWall>()
                .HasData(coralWall);
            modelBuilder.Entity<SonarCannon>()
                .HasData(sonarCannon);
            modelBuilder.Entity<UnderwaterMartialArts>()
                .HasData(underwaterMartialArts);

            modelBuilder.Entity<UnitGroup>()
                 .HasData(new UnitGroup[]
                 {
                    unitGroup1,
                    unitGroup2,
                    unitGroup3,
                    unitGroup4
                 });
            modelBuilder.Entity<Game>().HasData(game);
            modelBuilder.Entity<User>()
               .HasData(new User[]
               {
                    user1,
                    user2
               });
            modelBuilder.Entity<Country>()
                .HasData(new Country[]
                {
                    country1,
                    country2
                });
            modelBuilder.Entity<Upgrade>()
                .HasData(new Upgrade[]
                {
                    upgrade1,
                    upgrade2,
                    upgrade3,
                    upgrade4,
                    upgrade5,
                    upgrade6,
                    upgrade7,
                    upgrade8,
                    upgrade9,
                    upgrade10,
                    upgrade11,
                    upgrade12
                });
            modelBuilder.Entity<BuildingGroup>()
                .HasData(new BuildingGroup[]
                {
                    buildingGroup1,
                    buildingGroup2
                });
            modelBuilder.Entity<Building>()
                .HasData(new Building[]
                {
                    building1,
                    building2,
                    building3,
                    building4,
                    building5,
                    building6
                });

            modelBuilder.Entity<UnitLevel>()
                .HasData(new UnitLevel[]{
                    sharkLv1,
                    sharkLv2,
                    sharkLv3,
                    horseLv1,
                    horseLv2,
                    horseLv3,
                    sealLv1,
                    sealLv2,
                    sealLv3,
                });
        }
    }
}
