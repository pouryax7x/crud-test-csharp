using FluentAssertions;
using Mc2.CrudTest.AcceptanceTestsXunit.Constants.Customer;
using Mc2.CrudTest.Application.Core.Dtos.Customer;
using Mc2.CrudTest.Presentation.Server.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTests.Systems.Controllers
{
    public class CustomerControllerTest
    {

        [Fact]
        public async Task Get_OnSuccess_ReturnStatusCode200()
        {
            //arrange
            var mockMediaR = new Mock<IMediator>();
            mockMediaR
                .Setup(x => x.Send(It.IsAny<GetCustomersRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new GetCustomersResponse()
                {
                    CustomerList = CustomerList.GetCustomers()
                });
            var controller = new CustomerController(mockMediaR.Object);
            //act
            var result = (OkObjectResult)await controller.GetCustomers();
            //assertsdfsd
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task Get_OnSuccess_ReturnGetCustomerResponse()
        {
            //arrange
            var mockMediaR = new Mock<IMediator>();
            mockMediaR
                .Setup(x => x.Send(It.IsAny<GetCustomersRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new GetCustomersResponse()
                {
                    CustomerList = CustomerList.GetCustomers()
                });
            var controller = new CustomerController(mockMediaR.Object);
            //act
            var result = await controller.GetCustomers();
            //assert
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<GetCustomersResponse>();
        }
        [Fact]
        public async Task Get_OnSuccess_CallMediatR_once_atleast()
        {
            //arrange
            var mockMediaR = new Mock<IMediator>();
            mockMediaR
                .Setup(x => x.Send(It.IsAny<GetCustomersRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new GetCustomersResponse());
            var controller = new CustomerController(mockMediaR.Object);
            //act
            var result = await controller.GetCustomers();
            //assert
            mockMediaR.Verify(x => x.Send(It.IsAny<GetCustomersRequest>(), It.IsAny<CancellationToken>()), Times.Once());
        }
        [Fact]
        public async Task Get_NoCustomerFound_Return404()
        {
            //arrange
            var mockMediaR = new Mock<IMediator>();
            mockMediaR
                .Setup(x => x.Send(It.IsAny<GetCustomersRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new GetCustomersResponse());
            var controller = new CustomerController(mockMediaR.Object);
            //act
            var result = await controller.GetCustomers();
            //assert
            result.Should().BeOfType<NotFoundObjectResult>();
        }
    }
}
