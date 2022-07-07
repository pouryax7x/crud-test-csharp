using Mc2.CrudTest.Application.Core.Exception.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Core.Exception.Customer
{
    public class CustomerNotExistException: NotFoundException
    {
        override public string Message => "Customer with this id is not exist.";
    }
}
