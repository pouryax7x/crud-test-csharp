using Mc2.CrudTest.Application.Core.Dtos.Customer;
using Mc2.CrudTest.Application.Core.Interface.Repository.Customer;
using Mc2.CrudTest.Application.Core.Services.Customer;
using Mc2.CrudTest.Persistence.Context;
using Mc2.CrudTest.Persistence.Mapping;
using Mc2.CrudTest.Persistence.Repository.Customer;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;

namespace Mc2.CrudTest.Middleware.Middleware.IOC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services , IConfiguration configuration)
        {

            services.AddDbContext<SmartMedContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SmartMed"),
                    sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(
                            10,
                            TimeSpan.FromSeconds(3),
                            null);
                    }));

            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            
            services.AddScoped<ICustomerQueryRepository , CustomerQueryRepository>();
            services.AddScoped<ICustomerCommandRepository , CustomerCommandRepository>();
            services.AddAutoMapper(typeof(Mapping));



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MC2.CrudTest.Controllers", Version = "v1" });
            });


            return services;
        }


    }
}