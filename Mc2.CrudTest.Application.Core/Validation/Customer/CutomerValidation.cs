using FluentValidation;
using PhoneNumbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Core.Validation.Customer
{
    public class CutomerValidation : AbstractValidator<Domain.Customer.Customer>
    {
        PhoneNumberUtil phoneNumberUtil = PhoneNumberUtil.GetInstance();
        public CutomerValidation()
        {
            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Please enter valid Email address")
                .MaximumLength(150).WithMessage("Email length cannot be more than 150 character");

            RuleFor(x => x.PhoneNumber)
                .Must(CheckPhoneNumber);

            RuleFor(x => x.Firstname)
                .NotEmpty().WithMessage("Name cannot be empty")
                .NotNull().WithMessage("Name cannot be null")
                .MaximumLength(50).WithMessage("Name length cannot be more than 50 character");

            RuleFor(x => x.Lastname)
                .NotEmpty().WithMessage("Lastname cannot be empty")
                .NotNull().WithMessage("Lastname cannot be null")
                .MaximumLength(50).WithMessage("Lastname length cannot be more than 50 character");

            RuleFor(x => x.DateOfBirth)
                .Must(CheckDateOfBirth);

            RuleFor(x => x.BankAccountNumber)
                .Matches(@"^\W*\d{8,17}\b$");
        }

        private bool CheckDateOfBirth(DateTime arg)
        {
            if (arg >= DateTime.Today)
            {
                return false;
            }
            return true;
        }

        private bool CheckPhoneNumber(ulong arg)
        {
            return phoneNumberUtil.IsValidNumber(phoneNumberUtil.Parse("+" + arg.ToString() , "ZZ"));
        }
    }
}
