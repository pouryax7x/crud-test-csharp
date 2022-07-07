using MediatR;

namespace Mc2.CrudTest.Application.Core.Dtos.Customer
{
    public class DeleteCustomersRequest : IRequest<DeleteCustomersResponse>
    {
        public int Id { get; set; }
    }
}
