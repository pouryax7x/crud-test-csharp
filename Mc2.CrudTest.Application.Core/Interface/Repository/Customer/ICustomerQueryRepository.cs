using Mc2.CrudTest.Application.Core.Dtos.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Core.Interface.Repository.Customer
{
    public interface ICustomerQueryRepository
    {
        public Task<List<Domain.Customer.Customer>> GetAllCustomers();
        public Task<bool> CheckEmailExsit(CheckEmailExistRequest request);
        Task<bool> CheckUserExistWithNameFamilyBirthDate(CheckCustomerWithDuplicateNameFamilyBirthdateExistRequest request);
    }
}
