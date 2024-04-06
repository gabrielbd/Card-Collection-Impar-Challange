using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace ImparCar.Infra.Mappings
{
    public abstract class BaseMapping<T> : IEntityTypeConfiguration<T> where T : class
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey("Id");
            builder.Property("Id").IsRequired().HasColumnName("Id");
        }
    }
}
