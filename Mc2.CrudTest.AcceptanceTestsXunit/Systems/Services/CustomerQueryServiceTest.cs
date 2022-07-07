using FluentAssertions;
using Mc2.CrudTest.AcceptanceTestsXunit.Constants.Customer;
using Mc2.CrudTest.Application.Core.Dtos.Customer;
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
    }
}
