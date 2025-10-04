using Data.Context;
using Data.Initializer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ServiceRegistration
{
    public static class DataServiceRegistration
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            var dbPath = Path.Combine(AppContext.BaseDirectory, "appdata", "Employee.db");

            Directory.CreateDirectory(Path.GetDirectoryName(dbPath)!);

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite($"Data Source={dbPath}"));

            var serviceProvider = services.BuildServiceProvider();

            var dbContext = serviceProvider.GetRequiredService<AppDbContext>();

            dbContext.Database.Migrate();

            DbInitializer.Initialize(dbContext);

            return services;


        }
    }
}
