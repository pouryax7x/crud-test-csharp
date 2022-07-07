using MediatR;

namespace Mc2.CrudTest.Application.Core.Dtos.Customer
{
    public class CheckEmailExistRequest : IRequest<CheckEmailExistResponse>
    {
        public string Email { get; set; }

        public CheckEmailExistRequest(string email)
        {
            Email = email;
        }
    }
}