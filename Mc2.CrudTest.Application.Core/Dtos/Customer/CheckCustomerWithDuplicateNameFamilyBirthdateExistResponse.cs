namespace Mc2.CrudTest.Application.Core.Dtos.Customer
{
    public class CheckCustomerWithDuplicateNameFamilyBirthdateExistResponse
    {
        public bool IsCustomerExist { get; set; }

        public CheckCustomerWithDuplicateNameFamilyBirthdateExistResponse(bool isUserExist)
        {
            IsCustomerExist = isUserExist;
        }
    }
}