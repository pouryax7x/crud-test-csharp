using Mc2.CrudTest.Application.Core.Interface.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Core.Dtos.Exception
{
    public class ExceptionMessage : IMessage
    {
        public string Message { get; set; }

        public ExceptionMessage(string message)
        {
            Message = message;
        }
    }
}
