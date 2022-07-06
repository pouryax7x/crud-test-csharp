using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Core.Dtos.Customer
{
    public class GetCustomersRequest : IRequest<GetCustomersResponse>
    {
    }
}
