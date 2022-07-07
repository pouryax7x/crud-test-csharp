using Mc2.CrudTest.Application.Core.Dtos.Customer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.AcceptanceTestsXunit.Constants.Customer
{
    public static class CustomerInsertList
    {
        public class SafeList
        {
            private static List<object[]> _list = new List<object[]>()
                {
                    new object[]
                    {
                        new InsertCustomersRequest
                        {
                            BankAccountNumber = "12345678910",
                            DateOfBirth = DateTime.Today.AddDays(-1),
                            Email = "NoReplay@Google.com",
                            Firstname = "Pourya",
                            Lastname = "Tagharrob",
                            PhoneNumber = 989354930600 
                        }
                    },
                    new object[]
                    {
                        new InsertCustomersRequest
                        {
                            BankAccountNumber = "12345678910",
                            DateOfBirth = DateTime.Today.AddDays(-1),
                            Email = "NoReplay@Google.com",
                            Firstname = "Pourya1",
                            Lastname = "Tagharrob1",
                            PhoneNumber = 989354930601
                        },
                    },
                    new object[]
                    {
                        new InsertCustomersRequest
                        {
                            BankAccountNumber = "12345678910",
                            DateOfBirth = DateTime.Today.AddDays(-1),
                            Email = "NoReplay@Google.com",
                            Firstname = "Pourya3",
                            Lastname = "Tagharrob3",
                            PhoneNumber = 989354930602
                        },
                    }
                };
            public static IEnumerable<object[]> GetList
            {
                get { return _list; }
            }
        }

        public class UnSafeList
        {
            private static List<object[]> _list = new List<object[]>()
                {
                    new object[]
                    {
                        new InsertCustomersRequest
                        {
                            BankAccountNumber = "123",
                            DateOfBirth = DateTime.Today.AddDays(-1),
                            Email = "NoReplay@Google.com",
                            Firstname = "Pourya",
                            Lastname = "Tagharrob",
                            PhoneNumber = 989354930600
                        }
                    },
                    new object[]
                    {
                        new InsertCustomersRequest
                        {
                            BankAccountNumber = "12345678910",
                            DateOfBirth = DateTime.Today.AddDays(1),
                            Email = "NoReplay@Google.com",
                            Firstname = "Pourya1",
                            Lastname = "Tagharrob1",
                            PhoneNumber = 989354930601
                        },
                    },
                    new object[]
                    {
                        new InsertCustomersRequest
                        {
                            BankAccountNumber = "12345678910",
                            DateOfBirth = DateTime.Today.AddDays(-1),
                            Email = "NoReplayGoogle.com",
                            Firstname = "Pourya3",
                            Lastname = "Tagharrob3",
                            PhoneNumber = 989354930602
                        },
                    },
                    new object[]
                    {
                        new InsertCustomersRequest
                        {
                            BankAccountNumber = "12345678910",
                            DateOfBirth = DateTime.Today.AddDays(-1),
                            Email = "NoReplay@Google.com",
                            Firstname = " ",
                            Lastname = "Tagharrob3",
                            PhoneNumber = 989354930602
                        },
                    },
                    new object[]
                    {
                        new InsertCustomersRequest
                        {
                            BankAccountNumber = "12345678910",
                            DateOfBirth = DateTime.Today.AddDays(-1),
                            Email = "NoReplay@Google.com",
                            Firstname = "Pourya3",
                            Lastname = "",
                            PhoneNumber = 989354930602
                        },
                    },
                    new object[]
                    {
                        new InsertCustomersRequest
                        {
                            BankAccountNumber = "12345678910",
                            DateOfBirth = DateTime.Today.AddDays(-1),
                            Email = "NoReplay@Google.com",
                            Firstname = "Pourya3",
                            Lastname = "Tagharrob3",
                            PhoneNumber = 9890602
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
