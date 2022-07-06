﻿using Mc2.CrudTest.Application.Core.Interface.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Core.Exception
{
    public class BaseException : System.Exception, IMessage
    {
        public new string Message { get ; set ; }
    }
}
