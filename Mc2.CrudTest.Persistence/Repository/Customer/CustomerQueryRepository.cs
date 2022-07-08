using AutoMapper;
using Mc2.CrudTest.Application.Core.Dtos.Customer;
using Mc2.CrudTest.Application.Core.Interface.Repository.Customer;
using Mc2.CrudTest.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Persistence.Repository.Customer
{
    public class CustomerQueryRepository : ICustomerQueryRepository
    {
        private readonly SmartMedContext context;
        private readonly IMapper mapper;

        public CustomerQueryRepository(SmartMedContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<bool> CheckCustomerExistById(int id)
        {
            var result = await context.Customers.FindAsync(id);
            if (result != null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> CheckEmailExsit(CheckEmailExistRequest request)
        {
            var result = await context.Customers.Where(x=>x.Email == request.Email).SingleOrDefaultAsync();
            if (result != null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> CheckUserExistWithNameFamilyBirthDate(CheckCustomerWithDuplicateNameFamilyBirthdateExistRequest request)
        {
            var result = await context.Customers.Where(x => x.Firstname == request.Name &&
                                                            x.DateOfBirth == request.DateOfBirth &&
                                                            x.Lastname == request.Lastname).SingleOrDefaultAsync();
            if (result != null)
            {
                return true;
            }
            return false;
        }

        public async Task<List<Domain.Customer.Customer>> GetAllCustomers()
        {
            var result = await context.Customers.ToListAsync();
            return mapper.Map<List<Domain.Customer.Customer>>(result);
        }
    }
}
