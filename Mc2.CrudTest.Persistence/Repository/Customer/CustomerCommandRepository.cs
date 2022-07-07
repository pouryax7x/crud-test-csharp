using Mc2.CrudTest.Application.Core.Interface.Repository.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Persistence.Repository.Customer
{
    public class CustomerCommandRepository : ICustomerCommandRepository
    {
        public Task<bool> DeleteCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertCustomer(Domain.Customer.Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCustomer(Domain.Customer.Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
