using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EE.Education.DataLayer
{
    public class User
    {
        public int Id { get; set; }
    }

    public class EducationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }


    public class Startup
    {
        public Startup(IHostingEnvironment env, IHostingEnvironment appEnv)
        {
            var builder = new ConfigurationBuilder();
                //.SetBasePath(Path.Combine(Environment.CurrentDirectory, "../../config"))
                //.AddJsonFile("db-config.json");
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EducationContext>(options =>
                options.UseNpgsql("Server=localhost; Database=education_local; User Id=postgres; Password=1;"));
        }

        public static void Main(string[] args)
        {
            var host = WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
        }
    }
}
