using ImparCar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ImparCar.Infra.Mappings
{
    public class PhotoMapping : BaseMapping<Photo>
    {
        public override void Configure(EntityTypeBuilder<Photo> builder)
        {
            base.Configure(builder);

            builder.HasKey(g => g.Id);

            builder.ToTable("Photo");

            builder.Property(g => g.Base64)
                .IsRequired();

        }
    }
}
