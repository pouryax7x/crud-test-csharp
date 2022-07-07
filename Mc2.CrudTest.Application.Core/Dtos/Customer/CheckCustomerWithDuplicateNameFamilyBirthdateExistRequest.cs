using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Core.Dtos.Customer
{
    public class CheckCustomerWithDuplicateNameFamilyBirthdateExistRequest : IRequest<CheckCustomerWithDuplicateNameFamilyBirthdateExistResponse>
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }

        public CheckCustomerWithDuplicateNameFamilyBirthdateExistRequest(string name, string lastname, DateTime dateOfBirth)
        {
            Name = name;
            Lastname = lastname;
            DateOfBirth = dateOfBirth;
        }


    }
}
