using Mc2.CrudTest.Application.Core.Dtos.Customer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.AcceptanceTestsXunit.Constants.Customer
{
    public static class CustomerUpdateList
    {
        public class UpdateList
        {
            private static List<object[]> _list = new List<object[]>()
                {
                    new object[]
                    {
                        new UpdateCustomersRequest
                        {
                            BankAccountNumber = "123",
                            DateOfBirth = DateTime.Today,
                            Email = "A1@B1.com",
                            Firstname = "Pourya",
                            Lastname = "Tagharrob",
                            PhoneNumber = 98354930600 
                        }
                    },
                    new object[]
                    {
                        new UpdateCustomersRequest
                        {
                            BankAccountNumber = "124",
                            DateOfBirth = DateTime.Today,
                            Email = "A2@B2.com",
                            Firstname = "Pourya1",
                            Lastname = "Tagharrob1",
                            PhoneNumber = 98354930601
                        },
                    },
                    new object[]
                    {
                        new UpdateCustomersRequest
                        {
                            BankAccountNumber = "125",
                            DateOfBirth = DateTime.Today,
                            Email = "A3@B3.com",
                            Firstname = "Pourya3",
                            Lastname = "Tagharrob3",
                            PhoneNumber = 98354930603
                        },
                    }
                };
            public static IEnumerable<object[]> GetList
            {
                get { return _list; }
            }
        }
    }
}
