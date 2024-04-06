using ImparCar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImparCar.Infra.Mappings
{
    public class CarMapping : BaseMapping<Car>
    {
        public override void Configure(EntityTypeBuilder<Car> builder)
        {
            base.Configure(builder);

            builder.HasKey(g => g.Id);

            builder.ToTable("Car");

            builder.Property(g => g.Name)
                .IsRequired()
                .HasColumnName("Nome")
                .HasMaxLength(100);

            builder.Property(g => g.Status)
               .IsRequired()
               .HasColumnName("Status")
               .HasDefaultValue("1");

        }
    }
}
