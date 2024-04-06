using ImparCar.Domain.Entities;
using ImparCar.Infra.Mappings;
using Microsoft.EntityFrameworkCore;


namespace ImparCar.Infra.Contexts
{
    public class SqlContexts : DbContext
    {
        public SqlContexts(DbContextOptions<SqlContexts> dbContextOptions)
              : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarMapping());
            modelBuilder.ApplyConfiguration(new PhotoMapping());

        }
        public DbSet<Car>? Car { get; set; }
        public DbSet<Photo>? Photo { get; set; }
    }
}
