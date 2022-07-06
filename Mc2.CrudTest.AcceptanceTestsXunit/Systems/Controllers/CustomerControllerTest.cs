using FluentAssertions;
using Mc2.CrudTest.AcceptanceTestsXunit.Constants.Customer;
using Mc2.CrudTest.Application.Core.Dtos.Customer;
using Mc2.CrudTest.Presentation.Server.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions;

namespace Mc2.CrudTest.AcceptanceTests.Systems.Controllers
{
    public class CustomerControllerTest
    {
        #region Get section
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
            //assert
            result.StatusCode.Should().Be(200);
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
        #endregion
        #region Insert Customer

        [Fact]
        public async Task Insert_OnSuccess_ReturnStatusCode200()
        {
            //arrange
            var mockMediaR = new Mock<IMediator>();
            mockMediaR
                .Setup(x => x.Send(It.IsAny<InsertCustomersRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new InsertCustomersResponse()
                {
                    Message = "Customer Create Successfully"
                });
            var controller = new CustomerController(mockMediaR.Object);
            //act
            var result = (OkObjectResult)await controller.InsertCustomer((InsertCustomersRequest)CustomerInsertList.SafeList.GetList.First().First());
            //assert
            result.StatusCode.Should().Be(200);
        }

        public static IEnumerable<object[]> GetCustomerInsertList()
        {
            return CustomerInsertList.SafeList.GetList;
        }

        [Theory]
        [MemberData(nameof(GetCustomerInsertList))]
        public async Task Insert_OnSuccess_ReturnInsertCustomerResponse(InsertCustomersRequest request)
        {
            //arrange
            var mockMediaR = new Mock<IMediator>();
            mockMediaR
                .Setup(x => x.Send(It.IsAny<InsertCustomersRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new InsertCustomersResponse()
                {
                    Message = "Customer Inserted"
                });
            var controller = new CustomerController(mockMediaR.Object);
            //act
            var result = await controller.InsertCustomer(request);
            //assert
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<InsertCustomersResponse>();
        }

        [Fact]
        public async Task Insert_OnSuccess_CallMediatR_once_atleast()
        {
            //arrange
            var mockMediaR = new Mock<IMediator>();
            mockMediaR
                .Setup(x => x.Send(It.IsAny<InsertCustomersRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new InsertCustomersResponse()
                {
                    Message = "Customer Create Successfully"
                });
            var controller = new CustomerController(mockMediaR.Object);
            //act
            var result = await controller.InsertCustomer((InsertCustomersRequest)CustomerInsertList.SafeList.GetList.First().First());
            //assert
            mockMediaR.Verify(x => x.Send(It.IsAny<InsertCustomersRequest>(), It.IsAny<CancellationToken>()), Times.Once());
        }
        #endregion
        #region Update Customer

        #endregion
        #region Delete Customer

        #endregion
    }
}
