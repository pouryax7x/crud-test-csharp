using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Mc2.CrudTest.Application.Core.Dtos.Customer
{
    public class GetCustomersResponse
    {
        public List<Domain.Customer.Customer> CustomerList { get; set; }

        public GetCustomersResponse(List<Domain.Customer.Customer> customerList)
        {
            CustomerList = customerList;
        }
        public GetCustomersResponse()
        {

        }
    }
}
