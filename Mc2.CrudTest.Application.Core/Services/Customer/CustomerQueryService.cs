using Mc2.CrudTest.Application.Core.Dtos.Customer;
using Mc2.CrudTest.Application.Core.Exception.Customer;
using Mc2.CrudTest.Application.Core.Interface.Repository.Customer;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Core.Services.Customer
{
    public class CustomerQueryService
    {

        public class GetCustomersQuery : IRequestHandler<GetCustomersRequest, GetCustomersResponse>
        {
            private readonly ICustomerQueryRepository customerQuery;

            public GetCustomersQuery(ICustomerQueryRepository customerQuery)
            {
                this.customerQuery = customerQuery;
            }
            public async Task<GetCustomersResponse> Handle(GetCustomersRequest request, CancellationToken cancellationToken)
            {
                var result = await customerQuery.GetAllCustomers();
                if (!result.Any())
                {
                    throw new CustomerListIsEmptyException();
                }
                return new GetCustomersResponse(result);
            }
        }

        public class CheckEmailExist : IRequestHandler<CheckEmailExistRequest, CheckEmailExistResponse>
        {
            private readonly ICustomerQueryRepository customerQuery;

            public CheckEmailExist(ICustomerQueryRepository customerQuery)
            {
                this.customerQuery = customerQuery;
            }
            public async Task<CheckEmailExistResponse> Handle(CheckEmailExistRequest request, CancellationToken cancellationToken)
            {
                var result = await customerQuery.CheckEmailExsit(request);
                return new CheckEmailExistResponse(result);
            }
        }
        public class CheckUserExistWithNameFamilyBirthDate : IRequestHandler<CheckCustomerWithDuplicateNameFamilyBirthdateExistRequest, CheckCustomerWithDuplicateNameFamilyBirthdateExistResponse>
        {
            private readonly ICustomerQueryRepository customerQuery;

            public CheckUserExistWithNameFamilyBirthDate(ICustomerQueryRepository customerQuery)
            {
                this.customerQuery = customerQuery;
            }
            public async Task<CheckCustomerWithDuplicateNameFamilyBirthdateExistResponse> Handle(CheckCustomerWithDuplicateNameFamilyBirthdateExistRequest request, CancellationToken cancellationToken)
            {
                var result = await customerQuery.CheckUserExistWithNameFamilyBirthDate(request);
                return new CheckCustomerWithDuplicateNameFamilyBirthdateExistResponse(result);
            }
        }

        public class CheckCustomerExistById : IRequestHandler<CheckCustomerExistByIdRequest, CheckCustomerExistByIdResponse>
        {
            private readonly ICustomerQueryRepository customerQuery;

            public CheckCustomerExistById(ICustomerQueryRepository customerQuery)
            {
                this.customerQuery = customerQuery;
            }
            public async Task<CheckCustomerExistByIdResponse> Handle(CheckCustomerExistByIdRequest request, CancellationToken cancellationToken)
            {
                var result = await customerQuery.CheckCustomerExistById(request.Id);
                return new CheckCustomerExistByIdResponse(result);
            }
        }
    }
}
