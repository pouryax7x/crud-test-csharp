﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.AcceptanceTestsXunit.Constants.Customer
{
    public static class CustomerList
    {
        public static List<Domain.Customer.Customer> GetCustomers() => new List<Domain.Customer.Customer>
        {
            new Domain.Customer.Customer
            {
                BankAccountNumber = "10",
                DateOfBirth = DateTime.Today,
                Email = "AAA@BBB.CCC",
                Firstname = "pourya",
                Lastname = "tagharrob",
                PhoneNumber = 989354930600
            },
            new Domain.Customer.Customer
            {
                BankAccountNumber = "11",
                DateOfBirth = DateTime.Today,
                Email = "Aabc@BBB.CCC",
                Firstname = "pourya1",
                Lastname = "tagharrob1",
                PhoneNumber = 989354930601
            },
            new Domain.Customer.Customer
            {
                BankAccountNumber = "12",
                DateOfBirth = DateTime.Today,
                Email = "Asss@BBB.CCC",
                Firstname = "pourya2",
                Lastname = "tagharrob2",
                PhoneNumber = 989354930602
            },
        };
    }
}
