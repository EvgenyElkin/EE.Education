using EE.Education.Site.EF;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EE.Education.Site.Infrastructure.Repositories
{
    public static class DataRepositoryHelper
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration config)
        {
            var conntectionString = config.GetConnectionString(EnvironmentName.Development);
            return services.AddDbContext<EducationContext>(options => options.UseNpgsql(conntectionString))
                .AddScoped<IDataRepository, DataRepository>();
        }
    }
}