using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volvo_API.Models;

namespace Volvo_API.Repository.Context
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DatabaseContext() { }

        public virtual DbSet<Truck> Trucks { get; set; }
        public virtual DbSet<TruckModel> TruckModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Truck>().HasData(
                new Truck { Id = 1, TruckModelId = 1, FabricationYear = 2021, ModelYear = 2021 },
                new Truck { Id = 2, TruckModelId = 1, FabricationYear = 2021, ModelYear = 2022 },
                new Truck { Id = 3, TruckModelId = 2, FabricationYear = 2021, ModelYear = 2021 }
                );

            modelBuilder.Entity<TruckModel>().HasData(
                new TruckModel { Id = 1, Model = "FH" },
                new TruckModel { Id = 2, Model = "FM" }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
