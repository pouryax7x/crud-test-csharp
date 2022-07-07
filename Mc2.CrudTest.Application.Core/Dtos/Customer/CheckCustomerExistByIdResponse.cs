namespace Mc2.CrudTest.Application.Core.Dtos.Customer
{
    public class CheckCustomerExistByIdResponse
    {
        public bool IsCustomerExist { get; set; }

        public CheckCustomerExistByIdResponse(bool isCustomerExist)
        {
            IsCustomerExist = isCustomerExist;
        }
    }
}