using FluentAssertions;
using Mc2.CrudTest.AcceptanceTestsXunit.Constants.Customer;
using Mc2.CrudTest.Application.Core.Dtos.Customer;
using Mc2.CrudTest.Application.Core.Dtos.Exception;
using Mc2.CrudTest.Application.Core.Exception;
using Mc2.CrudTest.Application.Core.Exception.Customer;
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
        [Fact]
        public async Task Update_OnSuccess_ReturnStatusCode200()
        {
            //arrange
            var mockMediaR = new Mock<IMediator>();
            mockMediaR
                .Setup(x => x.Send(It.IsAny<UpdateCustomersRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new UpdateCustomersResponse()
                {
                    Message = "Customer Update Successfully"
                });
            var controller = new CustomerController(mockMediaR.Object);
            //act
            var result = (OkObjectResult)await controller.UpdateCustomer((UpdateCustomersRequest)CustomerUpdateList.UpdateList.GetList.First().First());
            //assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task Update_OnSuccess_CallMediatR_once_atleast()
        {
            //arrange
            var mockMediaR = new Mock<IMediator>();
            mockMediaR
                .Setup(x => x.Send(It.IsAny<UpdateCustomersRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new UpdateCustomersResponse()
                {
                    Message = "Customer Create Successfully"
                });
            var controller = new CustomerController(mockMediaR.Object);
            //act
            var result = await controller.UpdateCustomer((UpdateCustomersRequest)CustomerUpdateList.UpdateList.GetList.First().First());
            //assert
            mockMediaR.Verify(x => x.Send(It.IsAny<UpdateCustomersRequest>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task Update_OnSuccess_ReturnUpdateCustomerResponse()
        {
            //arrange
            var mockMediaR = new Mock<IMediator>();
            mockMediaR
                .Setup(x => x.Send(It.IsAny<UpdateCustomersRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new UpdateCustomersResponse()
                {
                    Message = "Customer Inserted"
                });
            var controller = new CustomerController(mockMediaR.Object);
            //act
            var result = await controller.UpdateCustomer((UpdateCustomersRequest)CustomerUpdateList.UpdateList.GetList.First().First());
            //assert
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<UpdateCustomersResponse>();
        }

        [Fact]
        public async Task Update_OnFail_CustomerNotFoundException_404()
        {
            //arrange
            var mockMediaR = new Mock<IMediator>();
            mockMediaR
                .Setup(x => x.Send(It.IsAny<UpdateCustomersRequest>(), It.IsAny<CancellationToken>()))
                .Throws(new CustomerNotFoundException());
            var controller = new CustomerController(mockMediaR.Object);
            //act
            var result = await controller.UpdateCustomer((UpdateCustomersRequest)CustomerUpdateList.UpdateList.GetList.First().First());
            //assert
            result.Should().BeOfType<NotFoundObjectResult>();
            var objectResult = (NotFoundObjectResult)result;
            objectResult.Value.Should().BeOfType<ExceptionMessage>();
        }

        [Fact]
        public async Task Update_OnFail_CustomerAlreadyExsit_400()
        {
            //arrange
            var mockMediaR = new Mock<IMediator>();
            mockMediaR
                .Setup(x => x.Send(It.IsAny<UpdateCustomersRequest>(), It.IsAny<CancellationToken>()))
                .Throws(new CustomerAlreadyExistException());
            var controller = new CustomerController(mockMediaR.Object);
            //act
            var result = await controller.UpdateCustomer((UpdateCustomersRequest)CustomerUpdateList.UpdateList.GetList.First().First());
            //assert
            result.Should().BeOfType<BadRequestObjectResult>();
            var objectResult = (BadRequestObjectResult)result;
            objectResult.Value.Should().BeOfType<ExceptionMessage>();
        }

        #endregion
        #region Delete Customer
        [Fact]
        public async Task Delete_OnSuccess_ReturnStatusCode200()
        {
            //arrange
            var mockMediaR = new Mock<IMediator>();
            mockMediaR
                .Setup(x => x.Send(It.IsAny<DeleteCustomersRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new DeleteCustomersResponse()
                {
                    Message = "Customer Delete Successfully"
                });
            var controller = new CustomerController(mockMediaR.Object);
            //act
            var result = (OkObjectResult)await controller.DeleteCustomer(new DeleteCustomersRequest { Id = 10 });
            //assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task Delete_OnSuccess_CallMediatR_once_atleast()
        {
            //arrange
            var mockMediaR = new Mock<IMediator>();
            mockMediaR
                .Setup(x => x.Send(It.IsAny<DeleteCustomersRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new DeleteCustomersResponse()
                {
                    Message = "Customer Delete Successfully"
                });
            var controller = new CustomerController(mockMediaR.Object);
            //act
            var result = await controller.DeleteCustomer(new DeleteCustomersRequest { Id = 10 });
            //assert
            mockMediaR.Verify(x => x.Send(It.IsAny<DeleteCustomersRequest>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task Delete_OnSuccess_ReturnDeleteCustomerResponse()
        {
            //arrange
            var mockMediaR = new Mock<IMediator>();
            mockMediaR
                .Setup(x => x.Send(It.IsAny<DeleteCustomersRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new DeleteCustomersResponse()
                {
                    Message = "Customer Deleted"
                });
            var controller = new CustomerController(mockMediaR.Object);
            //act
            var result = await controller.DeleteCustomer(new DeleteCustomersRequest { Id = 10 });
            //assert
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<DeleteCustomersResponse>();
        }

        [Fact]
        public async Task Delete_OnFail_CustomerNotFoundException_404()
        {
            //arrange
            var mockMediaR = new Mock<IMediator>();
            mockMediaR
                .Setup(x => x.Send(It.IsAny<DeleteCustomersRequest>(), It.IsAny<CancellationToken>()))
                .Throws(new CustomerNotFoundException());
            var controller = new CustomerController(mockMediaR.Object);
            //act
            var result = await controller.DeleteCustomer(new DeleteCustomersRequest { Id = 10});
            //assert
            result.Should().BeOfType<NotFoundObjectResult>();
            var objectResult = (NotFoundObjectResult)result;
            objectResult.Value.Should().BeOfType<ExceptionMessage>();
        }
        #endregion
    }
}
