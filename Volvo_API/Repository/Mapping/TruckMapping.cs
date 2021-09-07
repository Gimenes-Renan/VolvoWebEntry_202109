using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volvo_API.Models;

namespace Volvo_API.Repository.Mapping
{
    public class TruckMapping : IEntityTypeConfiguration<Truck>
    {
        public void Configure(EntityTypeBuilder<Truck> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.TruckModelId).IsRequired().HasColumnType("NUMBER(9)");
            builder.Property(p => p.ModelYear).IsRequired().HasColumnType("NUMBER(4)");
            builder.Property(p => p.FabricationYear).IsRequired().HasColumnType("NUMBER(4)");
            builder.Property(p => p.SerialNumber).IsRequired().HasColumnType("VARCHAR(50)");
            builder.ToTable("T_TRUCK");
        }
    }
}
