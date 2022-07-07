using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Core.Exception.Common
{
    public class ValidationException : BaseException
    {
        private readonly string messages;

        public ValidationException(IList<ValidationFailure> errors)
        {
            foreach (var error in errors) messages += error.ErrorMessage + ".\n";
        }

        public override string Message => messages;
    }
}
