using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.Customer
{
    public class Customer
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ulong PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }

    }
}
