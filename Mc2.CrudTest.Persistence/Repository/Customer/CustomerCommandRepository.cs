using AutoMapper;
using Mc2.CrudTest.Application.Core.Interface.Repository.Customer;
using Mc2.CrudTest.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Persistence.Repository.Customer
{
    public class CustomerCommandRepository : ICustomerCommandRepository
    {
        private readonly SmartMedContext context;
        private readonly IMapper mapper;

        public CustomerCommandRepository(SmartMedContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<bool> DeleteCustomer(int customerId)
        {
            var entity = await context.Customers.FindAsync(customerId);
            context.Customers.Remove(entity);
            var result = await context.SaveChangesAsync();
            if (result >= 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> InsertCustomer(Domain.Customer.Customer customer)
        {
            var entity = mapper.Map<Entities.Customer>(customer);
            entity.Id = 0;
            context.Add(entity);
            var result = await context.SaveChangesAsync();
            if (result >= 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateCustomer(Domain.Customer.Customer customer)
        {
            var entity = mapper.Map<Entities.Customer>(customer);
            context.Entry(await context.Customers.FindAsync(customer.Id)).CurrentValues.SetValues(entity);
            context.SaveChanges();

            var result = await context.SaveChangesAsync();
            if (result >= 0)
            {
                return true;
            }
            return false;
        }
    }
}
