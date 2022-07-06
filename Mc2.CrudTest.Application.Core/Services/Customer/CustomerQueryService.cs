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
    public class CustomerQueryService
    {
        public class GetCustomersQuery : IRequestHandler<GetCustomersRequest, GetCustomersResponse>
        {
            public Task<GetCustomersResponse> Handle(GetCustomersRequest request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
