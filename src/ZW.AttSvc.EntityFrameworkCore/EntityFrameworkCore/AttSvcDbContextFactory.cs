using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZW.AttSvc.EntityFrameworkCore
{
    public class AttSvcDbContextFactory : IDesignTimeDbContextFactory<AttSvcDbContext>
    {
        public AttSvcDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AttSvcDbContext>()
                .UseNpgsql(GetConnectionStringFromConfiguration(), b =>
                {
                    b.MigrationsHistoryTable("__AttSvc_Migrations");
                });

            return new AttSvcDbContext(builder.Options);
        }

        private static string GetConnectionStringFromConfiguration()
        {
            return BuildConfiguration()
                .GetConnectionString(AttSvcDbProperties.ConnectionStringName);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(
                    Path.Combine(
                        Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName,
                        $"host{Path.DirectorySeparatorChar}ZW.AttSvc.HttpApi.Host"
                    )
                )
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
