namespace Mc2.CrudTest.Application.Core.Dtos.Customer
{
    public class CheckEmailExistResponse
    {
        public bool IsEmailExsit { get; set; }

        public CheckEmailExistResponse(bool isEmailExsit)
        {
            IsEmailExsit = isEmailExsit;
        }
    }
}