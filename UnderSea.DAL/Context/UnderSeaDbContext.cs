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
        }

        protected void SeedData()
        {

        }
    }
}
