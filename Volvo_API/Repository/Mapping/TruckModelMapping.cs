using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volvo_API.Models;

namespace Volvo_API.Repository.Mapping
{
    public class TruckModelMapping
    {
        public void Configure(EntityTypeBuilder<TruckModel> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Model).IsRequired().HasColumnType("CHAR(2)");
            builder.ToTable("T_TRUCKMODEL");
        }
    }
}
