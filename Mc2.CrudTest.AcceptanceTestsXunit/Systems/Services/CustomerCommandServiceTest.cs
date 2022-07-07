using FluentAssertions;
using Mc2.CrudTest.AcceptanceTestsXunit.Constants.Customer;
using Mc2.CrudTest.Application.Core.Dtos.Customer;
using Mc2.CrudTest.Application.Core.Exception.Common;
using Mc2.CrudTest.Application.Core.Exception.Customer;
using Mc2.CrudTest.Application.Core.Interface.Repository.Customer;
using Mc2.CrudTest.Application.Core.Services.Customer;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTestsXunit.Systems.Services
{
    public class CustomerCommandServiceTest
    {
        #region InsertCustomerTests
        [Fact]
        public async Task InsertCustomer_success()
        {
            //arrange
            var customerCommandRepository = new Mock<ICustomerCommandRepository>();
            customerCommandRepository
                .Setup(x => x.InsertCustomer((InsertCustomersRequest)CustomerInsertList.SafeList.GetList.First().First()))
                .ReturnsAsync(true);

            var mockMediaR = new Mock<IMediator>();
            mockMediaR
                .Setup(x => x.Send(It.IsAny<CheckEmailExistRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new CheckEmailExistResponse(false));

            mockMediaR.Setup(x => x.Send(It.IsAny<CheckCustomerWithDuplicateNameFamilyBirthdateExistRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new CheckCustomerWithDuplicateNameFamilyBirthdateExistResponse(false));

            var customerCommand = new CustomerCommandService.InsertCustomerCommand(customerCommandRepository.Object, mockMediaR.Object);
            //act
            var result = await customerCommand.Handle((InsertCustomersRequest)CustomerInsertList.SafeList.GetList.First().First(), It.IsAny<CancellationToken>());
            //assert
            result.Should().BeOfType<InsertCustomersResponse>();
            result.Message.Should().NotBeEmpty();
        }
        public static IEnumerable<object[]> GetCustomerInsertList_Unvalid()
        {
            return CustomerInsertList.UnSafeList.GetList;
        }

        [Theory]
        [MemberData(nameof(GetCustomerInsertList_Unvalid))]
        public async Task InsertCustomer_NotValid(InsertCustomersRequest request)
        {
            //arrange
            var customerCommandRepository = new Mock<ICustomerCommandRepository>();
            customerCommandRepository
                .Setup(x => x.InsertCustomer((InsertCustomersRequest)CustomerInsertList.SafeList.GetList.First().First()))
                .ReturnsAsync(true);

            var mockMediaR = new Mock<IMediator>();
            mockMediaR
                .Setup(x => x.Send(It.IsAny<CheckEmailExistRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new CheckEmailExistResponse(false));

            mockMediaR.Setup(x => x.Send(It.IsAny<CheckCustomerWithDuplicateNameFamilyBirthdateExistRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new CheckCustomerWithDuplicateNameFamilyBirthdateExistResponse(false));

            var customerCommand = new CustomerCommandService.InsertCustomerCommand(customerCommandRepository.Object, mockMediaR.Object);
            //act
            var result = () => customerCommand.Handle(request, It.IsAny<CancellationToken>());
            //assert
            await result.Should().ThrowAsync<ValidationException>();
        }

        [Fact]
        public async Task InsertCustomer_Faild_DuplicatedEmail()
        {
            //arrange
            var customerCommandRepository = new Mock<ICustomerCommandRepository>();
            customerCommandRepository
                .Setup(x => x.InsertCustomer((InsertCustomersRequest)CustomerInsertList.SafeList.GetList.First().First()))
                .ReturnsAsync(true);

            var mockMediaR = new Mock<IMediator>();
            mockMediaR
                .Setup(x => x.Send(It.IsAny<CheckEmailExistRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new CheckEmailExistResponse(true));

            mockMediaR.Setup(x => x.Send(It.IsAny<CheckCustomerWithDuplicateNameFamilyBirthdateExistRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new CheckCustomerWithDuplicateNameFamilyBirthdateExistResponse(false));

            var customerCommand = new CustomerCommandService.InsertCustomerCommand(customerCommandRepository.Object, mockMediaR.Object);
            //act
            var result = () => customerCommand.Handle((InsertCustomersRequest)CustomerInsertList.SafeList.GetList.First().First(), It.IsAny<CancellationToken>());
            //assert
            await result.Should().ThrowAsync<CustomerAlreadyExistException>();
        }

        [Fact]
        public async Task InsertCustomer_Faild_DuplicatedNameFamilyBrthDay()
        {
            //arrange
            var customerCommandRepository = new Mock<ICustomerCommandRepository>();
            customerCommandRepository
                .Setup(x => x.InsertCustomer((InsertCustomersRequest)CustomerInsertList.SafeList.GetList.First().First()))
                .ReturnsAsync(true);

            var mockMediaR = new Mock<IMediator>();
            mockMediaR
                .Setup(x => x.Send(It.IsAny<CheckEmailExistRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new CheckEmailExistResponse(false));

            mockMediaR.Setup(x => x.Send(It.IsAny<CheckCustomerWithDuplicateNameFamilyBirthdateExistRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new CheckCustomerWithDuplicateNameFamilyBirthdateExistResponse(true));

            var customerCommand = new CustomerCommandService.InsertCustomerCommand(customerCommandRepository.Object, mockMediaR.Object);
            //act
            var result = () => customerCommand.Handle((InsertCustomersRequest)CustomerInsertList.SafeList.GetList.First().First(), It.IsAny<CancellationToken>());
            //assert
            await result.Should().ThrowAsync<CustomerAlreadyExistException>();
        }
        [Fact]
        public async Task InsertCustomer_Faild_Unexpectly()
        {
            //arrange
            var customerCommandRepository = new Mock<ICustomerCommandRepository>();
            customerCommandRepository
                .Setup(x => x.InsertCustomer((InsertCustomersRequest)CustomerInsertList.SafeList.GetList.First().First()))
                .ReturnsAsync(false);

            var mockMediaR = new Mock<IMediator>();
            mockMediaR
                .Setup(x => x.Send(It.IsAny<CheckEmailExistRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new CheckEmailExistResponse(false));

            mockMediaR.Setup(x => x.Send(It.IsAny<CheckCustomerWithDuplicateNameFamilyBirthdateExistRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new CheckCustomerWithDuplicateNameFamilyBirthdateExistResponse(false));

            var customerCommand = new CustomerCommandService.InsertCustomerCommand(customerCommandRepository.Object, mockMediaR.Object);
            //act
            var result = () => customerCommand.Handle((InsertCustomersRequest)CustomerInsertList.SafeList.GetList.First().First(), It.IsAny<CancellationToken>());
            //assert
            await result.Should().ThrowAsync<CustomerInsertFaildException>();
        }
        #endregion

        #region Customer Update Tests
        [Fact]
        public async Task UpdateCustomer_success()
        {
            //arrange
            var customerCommandRepository = new Mock<ICustomerCommandRepository>();
            customerCommandRepository
                .Setup(x => x.UpdateCustomer((UpdateCustomersRequest)CustomerUpdateList.UpdateList.GetList.First().First()))
                .ReturnsAsync(true);

            var mockMediaR = new Mock<IMediator>();
            mockMediaR
                .Setup(x => x.Send(It.IsAny<CheckCustomerExistByIdRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new CheckCustomerExistByIdResponse(true));

            var customerCommand = new CustomerCommandService.UpdateCustomerCommand(customerCommandRepository.Object, mockMediaR.Object);
            //act
            var result = await customerCommand.Handle((UpdateCustomersRequest)CustomerUpdateList.UpdateList.GetList.First().First(), It.IsAny<CancellationToken>());
            //assert
            result.Should().BeOfType<UpdateCustomersResponse>();
            result.Message.Should().NotBeEmpty();
        }

        public static IEnumerable<object[]> GetCustomerUpdateList_Unvalid()
        {
            return CustomerUpdateList.UnSafeList.GetList;
        }
        [Theory]
        [MemberData(nameof(GetCustomerUpdateList_Unvalid))]
        public async Task UpdateCustomer_NotValid(UpdateCustomersRequest request)
        {
            //arrange
            var customerCommandRepository = new Mock<ICustomerCommandRepository>();
            customerCommandRepository
                .Setup(x => x.InsertCustomer((UpdateCustomersRequest)CustomerUpdateList.UpdateList.GetList.First().First()))
                .ReturnsAsync(true);

            var mockMediaR = new Mock<IMediator>();
            
            var customerCommand = new CustomerCommandService.UpdateCustomerCommand(customerCommandRepository.Object, mockMediaR.Object);
            //act
            var result = () => customerCommand.Handle(request, It.IsAny<CancellationToken>());
            //assert
            await result.Should().ThrowAsync<ValidationException>();
        }

        [Fact]
        public async Task UpdateCustomer_Faild_UserNotFound()
        {
            //arrange
            var customerCommandRepository = new Mock<ICustomerCommandRepository>();
            customerCommandRepository
                .Setup(x => x.UpdateCustomer((UpdateCustomersRequest)CustomerUpdateList.UpdateList.GetList.First().First()))
                .ReturnsAsync(true);

            var mockMediaR = new Mock<IMediator>();
            mockMediaR
                .Setup(x => x.Send(It.IsAny<CheckCustomerExistByIdRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new CheckCustomerExistByIdResponse(false));

            var customerCommand = new CustomerCommandService.UpdateCustomerCommand(customerCommandRepository.Object, mockMediaR.Object);
            //act
            var result = () => customerCommand.Handle((UpdateCustomersRequest)CustomerUpdateList.UpdateList.GetList.First().First(), It.IsAny<CancellationToken>());
            //assert
            await result.Should().ThrowAsync<CustomerNotExistException>();
        }

        [Fact]
        public async Task UpdateCustomer_Faild_Unexpected()
        {
            //arrange
            var customerCommandRepository = new Mock<ICustomerCommandRepository>();
            customerCommandRepository
                .Setup(x => x.UpdateCustomer((UpdateCustomersRequest)CustomerUpdateList.UpdateList.GetList.First().First()))
                .ReturnsAsync(false);

            var mockMediaR = new Mock<IMediator>();
            mockMediaR
                .Setup(x => x.Send(It.IsAny<CheckCustomerExistByIdRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new CheckCustomerExistByIdResponse(true));

            var customerCommand = new CustomerCommandService.UpdateCustomerCommand(customerCommandRepository.Object, mockMediaR.Object);
            //act
            var result = () => customerCommand.Handle((UpdateCustomersRequest)CustomerUpdateList.UpdateList.GetList.First().First(), It.IsAny<CancellationToken>());
            //assert
            await result.Should().ThrowAsync<CustomerUpdateFaildException>();
        }
        #endregion
    }
}
