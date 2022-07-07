using FluentAssertions;
using Mc2.CrudTest.AcceptanceTestsXunit.Constants.Customer;
using Mc2.CrudTest.Application.Core.Dtos.Customer;
using Mc2.CrudTest.Application.Core.Exception.Customer;
using Mc2.CrudTest.Application.Core.Interface.Repository.Customer;
using Mc2.CrudTest.Application.Core.Services.Customer;
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
    public class CustomerQueryServiceTest
    {
        [Fact]
        public async Task GetCustomers_success()
        {
            //arrange
            var mockRepository = new Mock<ICustomerQueryRepository>();
            mockRepository
                .Setup(x => x.GetAllCustomers())
                .ReturnsAsync(CustomerList.GetCustomers());

            var customerQuery = new CustomerQueryService.GetCustomersQuery(mockRepository.Object);
            //act
            var result = await customerQuery.Handle(It.IsAny<GetCustomersRequest>(), It.IsAny<CancellationToken>());
            //assert
            result.Should().BeOfType<GetCustomersResponse>();
            result.CustomerList.Should().NotBeEmpty();
        }

        [Fact]
        public async Task GetCustomers_FaildOrNotFound()
        {
            //arrange
            var mockRepository = new Mock<ICustomerQueryRepository>();
            mockRepository
                .Setup(x => x.GetAllCustomers())
                .ReturnsAsync(new List<Domain.Customer.Customer>());

            var customerQuery = new CustomerQueryService.GetCustomersQuery(mockRepository.Object);
            //act
            var result = () => customerQuery.Handle(It.IsAny<GetCustomersRequest>(), It.IsAny<CancellationToken>());
            //assert
            await result.Should().ThrowAsync<CustomerListIsEmptyException>();
        }

        [Fact]
        public async Task CheckUserExistWithNameFamilyBirthDate()
        {
            //arrange
            var mockRepository = new Mock<ICustomerQueryRepository>();
            mockRepository
                .Setup(x => x.CheckUserExistWithNameFamilyBirthDate(It.IsAny<CheckCustomerWithDuplicateNameFamilyBirthdateExistRequest>()))
                .ReturnsAsync(true);

            var customerQuery = new CustomerQueryService.CheckUserExistWithNameFamilyBirthDate(mockRepository.Object);
            //act
            var result = await customerQuery.Handle(It.IsAny<CheckCustomerWithDuplicateNameFamilyBirthdateExistRequest>(), It.IsAny<CancellationToken>());
            //assert
            result.IsCustomerExist.Should().Be(true);
        }

        [Fact]
        public async Task CheckEmailExist()
        {
            //arrange
            var mockRepository = new Mock<ICustomerQueryRepository>();
            mockRepository
                .Setup(x => x.CheckEmailExsit(It.IsAny<CheckEmailExistRequest>()))
                .ReturnsAsync(true);

            var customerQuery = new CustomerQueryService.CheckEmailExist(mockRepository.Object);
            //act
            var result = await customerQuery.Handle(It.IsAny<CheckEmailExistRequest>(), It.IsAny<CancellationToken>());
            //assert
            result.IsEmailExsit.Should().Be(true);
        }
    }
}
