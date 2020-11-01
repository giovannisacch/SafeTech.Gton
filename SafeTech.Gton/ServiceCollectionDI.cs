using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SafeTech.Gton.Infra.Data;
using SafeTech.Gton.Infra.Data.Interfaces;
using SafeTech.Gton.Infra.Data.Repositories;
using SafeTech.Gton.Mappings;

namespace SafeTech.Gton
{
    public static class ServiceCollectionDI
    {
        public static IServiceCollection RegisterDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(AutoMapperConfig.RegisterMappings());
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IOrganRepository, OrganRepository>();

            services.AddDbContext<GtonContext>(ctx =>
                 ctx.UseMySql(configuration.GetConnectionString("Gton"),
                 option => option.EnableRetryOnFailure()
             )
          ) ;
            return services;
        }

    }
}
