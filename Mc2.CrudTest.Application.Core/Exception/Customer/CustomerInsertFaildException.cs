using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Core.Exception.Customer
{
    public  class CustomerInsertFaildException : System.Exception
    {
        override public string Message => "There is an error while inserting customer";
    }
}
