using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.infrastructure.Configuration
{
    public class PlaneConfiguration : IEntityTypeConfiguration<Plane>
    {
        public void Configure(EntityTypeBuilder<Plane> builder)
        {
            builder.HasKey(a => a.PlaneId); //equivalent a [Key]
            builder.ToTable("MyPlane");    // rename table
            builder.Property(capa => capa.Capacity).HasColumnName("PlaneCapacity");
        }
    }
}
