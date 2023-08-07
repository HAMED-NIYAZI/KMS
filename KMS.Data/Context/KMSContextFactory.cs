using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Data.Context
{

    public class KMSContextFactory : IDesignTimeDbContextFactory<KMSContext>
    {
        public KMSContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build();



            var builder = new DbContextOptionsBuilder<KMSContext>();
            var connectionString = configuration.GetConnectionString("KMSConnectionString");

            builder.UseSqlServer(connectionString);

            return new KMSContext(builder.Options);
        }

     
    }

}
