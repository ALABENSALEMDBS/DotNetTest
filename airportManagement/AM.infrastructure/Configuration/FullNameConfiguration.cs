using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.domain;
using AM.ApplicationCore.service;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.infrastructure.Configuration
{
    public class FullNameConfiguration : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.OwnsOne(f => f.FullName, full =>
            {
                full.Property(a => a.FirstName).HasColumnName("PassFirstName").HasMaxLength(30);
                full.Property(b => b.LastName).HasColumnName("PassLastName").IsRequired();
            });
        }
    }
}
