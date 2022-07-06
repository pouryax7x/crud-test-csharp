using Mc2.CrudTest.Application.Core.Dtos.Customer;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator mediator;

        public CustomerController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var result = await mediator.Send(new GetCustomersRequest());
            if (result.CustomerList == null || !result.CustomerList.Any())
            {
                return NotFound(result);
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> InsertCustomer(InsertCustomersRequest request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCustomers()
        {
            return null;
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCustomers()
        {
            return null;
        }
    }
}
