using Mc2.CrudTest.Application.Core.Dtos.Customer;
using Mc2.CrudTest.Application.Core.Interface.Repository.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Persistence.Repository.Customer
{
    public class CustomerQueryRepository : ICustomerQueryRepository
    {
        public Task<bool> CheckEmailExsit(CheckEmailExistRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckUserExistWithNameFamilyBirthDate(CheckCustomerWithDuplicateNameFamilyBirthdateExistRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<List<Domain.Customer.Customer>> GetAllCustomers()
        {
            throw new NotImplementedException();
        }
    }
}
