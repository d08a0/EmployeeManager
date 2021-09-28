using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EmployeeManager.Db
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using (var dbContext = scope.ServiceProvider.GetRequiredService<EmployeeManagerDbContext>())
                {
                    try
                    {
                        dbContext.Database.Migrate();
                    }
                    catch (Exception _)
                    {
                        //Log errors or do anything you think it's needed
                        throw;
                    }
                    var config = scope.ServiceProvider.GetRequiredService<IConfiguration>();

                    var okSeed = new MigrationConfig { Seed = false };
                    config.Bind(okSeed);
                    if (okSeed.Seed == true)
                    {
                        PositionSeed.Seed(dbContext);
                    }
                }
            }
            return host;
        }
    }
    public class MigrationConfig
    {
        public bool Seed { get; set; }
    }
}