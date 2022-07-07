using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Core.Exception.Customer
{
    public class CustomerAlreadyExistException : BaseException
    {
        override public string Message => "This customer is already exist.";
    }
}
