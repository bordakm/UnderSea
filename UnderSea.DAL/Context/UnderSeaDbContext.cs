using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
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
            modelBuilder.Entity<Alchemy>();
            modelBuilder.Entity<StormSeal>();

          /*  modelBuilder.Entity<Site>().HasOne(e => e.Person)
                .WithMany(x => x.Sites).Metadata.DeleteBehavior = DeleteBehavior.Restrict;*/

            
           foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }
            

            /* modelBuilder.Entity<UnitType>();
             modelBuilder.Entity<LaserShark>();*/

            /*modelBuilder.Entity<FlowManager>();
            modelBuilder.Entity<ReefCastle>();
            
            modelBuilder.Entity<Alchemy>();
            modelBuilder.Entity<CoralWall>();
            modelBuilder.Entity<MudHarvester>();
            modelBuilder.Entity<MudTractor>();
            modelBuilder.Entity<SonarCannon>();
            modelBuilder.Entity<UnderwaterMartialArts>();*/

            LaserShark laserShark = new LaserShark
            {
                Id = 1
            };
            StormSeal stormSeal = new StormSeal
            {
                Id = 2
            };
            CombatSeaHorse combatSeaHorse = new CombatSeaHorse
            {
                Id = 3
            };
            var reefCastle = new ReefCastle
            {
                Id = 1
            };
            var flowManager = new FlowManager
            {
                Id = 2
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

            var unit1 = new Unit
            {
                Id = 1,
                AttackId = 1,
                UnitGroupId = 1,
                Count = 0,
                TypeId = 1
            };
            var unit2 = new Unit
            {
                Id = 2,
                AttackId = 1,
                UnitGroupId = 1,
                Count = 0,
                TypeId = 2
            };
            var unit3 = new Unit
            {
                Id = 3,
                AttackId = 1,
                UnitGroupId = 1,
                Count = 0,
                TypeId = 3
            };
            var unit4 = new Unit
            {
                Id = 4,
                UnitGroupId = 2,
                Count = 10,
                TypeId = 1
            };
            var unit5 = new Unit
            {
                Id = 5,
                UnitGroupId = 2,
                Count = 20,
                TypeId = 2
            };
            var unit6 = new Unit
            {
                Id = 6,
                UnitGroupId = 2,
                Count = 40,
                TypeId = 3
            };
            var unit7 = new Unit
            {
                Id = 7,
                UnitGroupId = 3,
                Count = 0,
                TypeId = 1
            };
            var unit8 = new Unit
            {
                Id = 8,
                UnitGroupId = 3,
                Count = 0,
                TypeId = 2
            };
            var unit9 = new Unit
            {
                Id = 9,
                UnitGroupId = 3,
                Count = 0,
                TypeId = 3
            };
            var unit10 = new Unit
            {
                Id = 10,
                UnitGroupId = 4,
                Count = 10,
                TypeId = 1
            };
            var unit11 = new Unit
            {
                Id = 11,
                UnitGroupId = 4,
                Count = 20,
                TypeId = 2
            };
            var unit12 = new Unit
            {
                Id = 12,
                UnitGroupId = 4,
                Count = 40,
                TypeId = 3
            };

            var upgrade1 = new Upgrade
            {
                Id = 1,
                CountryId = 1,
                State = UpgradeState.Researched,
                TypeId = 1
            };
            var upgrade2 = new Upgrade
            {
                Id = 2,
                CountryId = 1,
                State = UpgradeState.Researched,
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
                State = UpgradeState.Researched,
                TypeId = 4
            };
            var upgrade5 = new Upgrade
            {
                Id = 5,
                CountryId = 1,
                State = UpgradeState.Researched,
                TypeId = 5
            };
            var upgrade6 = new Upgrade
            {
                Id = 6,
                CountryId = 2,
                State = UpgradeState.Researched,
                TypeId = 1
            };
            var upgrade7 = new Upgrade
            {
                Id = 7,
                CountryId = 2,
                State = UpgradeState.Researched,
                TypeId = 2
            };
            var upgrade8 = new Upgrade
            {
                Id = 8,
                CountryId = 2,
                State = UpgradeState.Researched,
                TypeId = 3
            };
            var upgrade9 = new Upgrade
            {
                Id = 9,
                CountryId = 2,
                State = UpgradeState.Researched,
                TypeId = 4
            };
            var upgrade10 = new Upgrade
            {
                Id = 10,
                CountryId = 2,
                State = UpgradeState.Researched,
                TypeId = 5
            };

            var buildingGroup1 = new BuildingGroup
            {
                Id = 1,
                CountryId = 1
            };
            var buildingGroup2 = new BuildingGroup
            {
                Id = 2,
                CountryId = 2
            };

            var building1 = new Building
            {
                Id = 1,
                BuildingGroupId = 1,
                Count = 1,
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
                Count = 1,
                TypeId = 2
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
                UpgradeTimeLeft = 0,
                UserId = 1
            };
            var country2 = new Country
            {
                Id = 2,
                AttackingArmyId = 3,
                DefendingArmyId = 4,
                BuildingTimeLeft = 0,
                Coral = 0,
                Name = "Another Country",
                Pearl = 0,
                Score = 0,
                UpgradeTimeLeft = 0,
                UserId = 2
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


            //modelBuilder.Entity<UpgradeType>()
            //    .HasData(new UpgradeType[]
            //    {
            //        alchemy,
            //        mudTractor,
            //        mudHarvester,
            //        coralWall,
            //        sonarCannon,
            //        underwaterMartialArts
            //    });

            
           
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
            modelBuilder.Entity<Attack>().HasData(attack1);
            modelBuilder.Entity<Unit>()
                .HasData(new Unit[]
                {
                    unit1, unit2, unit3, unit4, unit5, unit6, unit7, unit8, unit9, unit10, unit11, unit12
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
                    upgrade10
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
                    building4
                });

            
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
