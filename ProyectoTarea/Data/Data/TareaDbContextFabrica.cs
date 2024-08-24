using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Data.Data
{
    public class TareaDbContextFabrica : IDesignTimeDbContextFactory<TareaDbContext>
    {
        public TareaDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TareaDbContext>();

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(Directory.GetCurrentDirectory() + "\\appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("TareaDBConecction");

            optionsBuilder.UseSqlServer(connectionString);

            return new TareaDbContext(optionsBuilder.Options);
        }
    }
}
