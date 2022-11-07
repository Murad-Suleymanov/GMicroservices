using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace GMicroservices.Utility.Mappings
{
    public static class DependencyInjection
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            //Application
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IPersonControllerService, PersonControllerService>();


            //Other
            var sp = services.BuildServiceProvider();

            //DataAccess
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("TestDb"));
                options.EnableSensitiveDataLogging();
            }); 
            services.AddTransient<AppDbContext>();
            services.AddScoped<IPersonRepository, PersonRepository>();



            //CommonTech
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
