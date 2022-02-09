using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesHouse.Data.EF
{
    public class ShoesHouseDbContextFactory : IDesignTimeDbContextFactory<ShoesHouseDbContext>
    {
        public ShoesHouseDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();

            var connectionString = configuration.GetConnectionString("ShoesHouseDb");

            var optionsBuilder = new DbContextOptionsBuilder<ShoesHouseDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new ShoesHouseDbContext(optionsBuilder.Options);
        }
    }
}
