using Mc2.CrudTest.Application.Core.Dtos.Customer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Core.Services.Customer
{
    public class CustomerCommandService
    {
        public class InsertCustomerCommand : IRequestHandler<InsertCustomersRequest, InsertCustomersResponse>
        {
            public Task<InsertCustomersResponse> Handle(InsertCustomersRequest request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }

        public class UpdateCustomerCommand : IRequestHandler<UpdateCustomersRequest, UpdateCustomersResponse>
        {
            public Task<UpdateCustomersResponse> Handle(UpdateCustomersRequest request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
