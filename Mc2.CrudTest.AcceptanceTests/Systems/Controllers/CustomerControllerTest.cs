using FluentAssertions;
using Mc2.CrudTest.Presentation.Server.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTests.Systems.Controllers
{
    public class CustomerControllerTest
    {

        [Fact]
        public async Task GetOnSuccessReturnStatusCode200()
        {
            //arrange
            var controller = new CustomerController();
            //act
            var result = (OkObjectResult) await  controller.GetCustomers();
            //assert
            result.StatusCode.Should().Be(200);
        }
    }
}
