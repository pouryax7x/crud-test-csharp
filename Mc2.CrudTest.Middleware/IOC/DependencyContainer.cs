using Mc2.CrudTest.Application.Core.Dtos.Customer;
using Mc2.CrudTest.Application.Core.Interface.Repository.Customer;
using Mc2.CrudTest.Application.Core.Services.Customer;
using Mc2.CrudTest.Persistence.Repository.Customer;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Mc2.CrudTest.Middleware.Middleware.IOC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CustomerQueryService));
            services.AddScoped<ICustomerQueryRepository , CustomerQueryRepository>();


            return services;
        }
    }
}