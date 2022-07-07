using Mc2.CrudTest.Application.Core.Dtos.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Core.Interface.Repository.Customer
{
    public interface ICustomerCommandRepository
    {
        public Task<bool> InsertCustomer(Domain.Customer.Customer customer);
        public Task<bool> UpdateCustomer(Domain.Customer.Customer customer);
        public Task<bool> DeleteCustomer(int customerId);
    }
}
