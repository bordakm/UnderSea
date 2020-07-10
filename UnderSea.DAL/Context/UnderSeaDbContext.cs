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
    public class UnderSeaDbContext : DbContext
    {
        public DbSet<Game> Game { get; set; }
        public DbSet<User> Users { get; set; }
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

            modelBuilder.Entity<Game>().HasData(
                new Game()
                {
                    Attacks = new List<Attack>(),
                    CoralPictureUrl = "",
                    PearlPictureUrl = "",
                    Round = 0,
                    Users = new List<User>()
                    {
                        new User()
                        {
                            Country = new Country()
                            {
                                AttackingArmy = new List<Unit>()
                                {
                                    new Unit()
                                    {
                                        Count = 0,
                                        Type = new LaserShark()
                                    },
                                    new Unit()
                                    {
                                        Count = 0,
                                        Type = new StormSeal()
                                    },
                                    new Unit()
                                    {
                                        Count = 0,
                                        Type = new CombatSeaHorse()
                                    }
                                },
                                DefendingArmy = new List<Unit>()
                                {
                                    new Unit()
                                    {
                                        Count = 10,
                                        Type = new LaserShark()
                                    },
                                    new Unit()
                                    {
                                        Count = 20,
                                        Type = new StormSeal()
                                    },
                                    new Unit()
                                    {
                                        Count = 40,
                                        Type = new CombatSeaHorse()
                                    }
                                },
                                BuildingTimeLeft = 0,
                                Coral = 0,
                                CoralProduction = 500,
                                Name = "First Country",
                                Pearl = 0,
                                PearlProduction = 500,
                                Population = 200,
                                TaxRate = 50,
                                Score = 0,
                                UnitStorage = 100,
                                UpgradeTimeLeft = 0,
                                Upgrades = new List<Upgrade>()
                                {
                                    new Upgrade()
                                    {
                                        State = UpgradeState.Researched,
                                        Type = new Alchemy()
                                    },
                                    new Upgrade()
                                    {
                                        State = UpgradeState.Researched,
                                        Type = new CoralWall()
                                    },
                                    new Upgrade()
                                    {
                                        State = UpgradeState.Researched,
                                        Type = new MudHarvester()
                                    },
                                    new Upgrade()
                                    {
                                        State = UpgradeState.Researched,
                                        Type = new SonarCannon()
                                    },
                                    new Upgrade()
                                    {
                                        State = UpgradeState.Researched,
                                        Type = new UnderwaterMartialArts()
                                    }

                                },
                                BuildingGroup = new BuildingGroup()
                                {
                                    Buildings = new List<Building>()
                                    {
                                        new FlowManager(),
                                        new ReefCastle()
                                    }
                                }

                            },
                            Place = 0,
                            Score = 0,
                            UserName = "First User",
                            Id = 11111                            
                        },

                        new User()
                        {
                            Country = new Country()
                            {
                                AttackingArmy = new List<Unit>()
                                {
                                    new Unit()
                                    {
                                        Count = 0,
                                        Type = new LaserShark()
                                    },
                                    new Unit()
                                    {
                                        Count = 0,
                                        Type = new StormSeal()
                                    },
                                    new Unit()
                                    {
                                        Count = 0,
                                        Type = new CombatSeaHorse()
                                    }
                                },
                                DefendingArmy = new List<Unit>()
                                {
                                    new Unit()
                                    {
                                        Count = 0,
                                        Type = new LaserShark()
                                    },
                                    new Unit()
                                    {
                                        Count = 10,
                                        Type = new StormSeal()
                                    },
                                    new Unit()
                                    {
                                        Count = 0,
                                        Type = new CombatSeaHorse()
                                    }
                                },
                                BuildingTimeLeft = 0,
                                Coral = 0,
                                CoralProduction = 500,
                                Name = "Second Country",
                                Pearl = 0,
                                PearlProduction = 500,
                                Population = 200,
                                TaxRate = 50,
                                Score = 0,
                                UnitStorage = 100,
                                UpgradeTimeLeft = 0,
                                Upgrades = new List<Upgrade>()
                                {
                                    new Upgrade()
                                    {
                                        State = UpgradeState.Unresearched,
                                        Type = new Alchemy()
                                    },
                                    new Upgrade()
                                    {
                                        State = UpgradeState.Unresearched,
                                        Type = new CoralWall()
                                    },
                                    new Upgrade()
                                    {
                                        State = UpgradeState.Unresearched,
                                        Type = new MudHarvester()
                                    },
                                    new Upgrade()
                                    {
                                        State = UpgradeState.Unresearched,
                                        Type = new SonarCannon()
                                    },
                                    new Upgrade()
                                    {
                                        State = UpgradeState.Unresearched,
                                        Type = new UnderwaterMartialArts()
                                    }

                                },
                                BuildingGroup = new BuildingGroup()
                                {
                                    Buildings = new List<Building>()
                                    {
                                        
                                    }
                                }

                            },
                            Place = 0,
                            Score = 0,
                            UserName = "Second User",
                            Id = 22222
                        }
                    }
                }
            );
        }

        protected void SeedData()
        {

        }
    }
}
