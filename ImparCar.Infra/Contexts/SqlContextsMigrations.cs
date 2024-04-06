using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace ImparCar.Infra.Contexts
{
    public class SqlContextsMigrations : IDesignTimeDbContextFactory<SqlContexts>
    {
        public SqlContexts CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder();
            var path = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "appsettings.Infra.json");
            config.AddJsonFile(path, false);

            var root = config.Build();
            var connectionString = root.GetSection("ConnectionStrings").GetSection("ImparCar").Value;

            var builder = new DbContextOptionsBuilder<SqlContexts>();
            builder.UseSqlServer(connectionString);

            return new SqlContexts(builder.Options);
        }
    }
}
