using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using AutoMapper;
using Cepedi.Data;
using Cepedi.Data.Repositories;
using Cepedi.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cepedi.IoC
{
    [ExcludeFromCodeCoverage]
    public static class AppServiceCollectionExtension
    {
        public static void ConfigureAppDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            ConfigureDbContext(services, configuration);

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICursoRepository, CursoRepository>();
            services.AddScoped<IProfessorRepository, ProfessorRepository>();

            var mappingConfig = new MapperConfiguration(mc => mc.AddProfile(new AutoMapping()));
            services.AddSingleton(mappingConfig.CreateMapper());

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddHealthChecks()
                .AddDbContextCheck<ApplicationDbContext>();
        }

        private static void ConfigureDbContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<ApplicationDbContextInitialiser>();
        }
    }
}
