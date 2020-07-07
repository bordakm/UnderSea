using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UnderSea.DAL.Models;

namespace UnderSea.DAL.Context
{
    public class UnderSeaDbContext : DbContext
    {
        public UnderSeaDbContext(DbContextOptions<UnderSeaDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Game> Game { get; set; }

    }
}
