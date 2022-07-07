using Mc2.CrudTest.Application.Core.Interface.Common;

namespace Mc2.CrudTest.Application.Core.Dtos.Customer
{
    public class DeleteCustomersResponse : IMessage
    {
        public string Message { get; set; }
    }
}