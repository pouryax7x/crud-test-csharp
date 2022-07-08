using System;
using System.Collections.Generic;

#nullable disable

namespace Mc2.CrudTest.Persistence.Entities
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }
    }
}
