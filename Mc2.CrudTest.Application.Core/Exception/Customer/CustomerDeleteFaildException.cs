using Mc2.CrudTest.Application.Core.Exception.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Core.Exception.Customer
{
    public  class CustomerDeleteFaildException : UnexpectedException
    {
        public override string Message => "There is an error while updating customer";
    }
}
