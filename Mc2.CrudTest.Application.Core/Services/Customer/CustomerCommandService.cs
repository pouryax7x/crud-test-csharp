using Mc2.CrudTest.Application.Core.Dtos.Customer;
using Mc2.CrudTest.Application.Core.Exception.Common;
using Mc2.CrudTest.Application.Core.Exception.Customer;
using Mc2.CrudTest.Application.Core.Interface.Repository.Customer;
using Mc2.CrudTest.Application.Core.Validation.Customer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Core.Services.Customer
{
    public class CustomerCommandService
    {
        public class InsertCustomerCommand : IRequestHandler<InsertCustomersRequest, InsertCustomersResponse>
        {
            private readonly ICustomerCommandRepository commandRepository;
            private readonly IMediator mediator;

            public InsertCustomerCommand(ICustomerCommandRepository commandRepository, IMediator mediator)
            {
                this.commandRepository = commandRepository;
                this.mediator = mediator;
            }

            public async Task<InsertCustomersResponse> Handle(InsertCustomersRequest request, CancellationToken cancellationToken)
            {
                //https://docs.fluentvalidation.net/en/latest/aspnet.html
                //Auto validation is not asynchronous
                //Auto validation is MVC-only
                //Auto validation is hard to debug
                //so i decide to validate manually
                //Validation
                var validateResult = await new CutomerValidation().ValidateAsync(request);
                if (!validateResult.IsValid) throw new ValidationException(validateResult.Errors);

                //there is two way to insert
                //first send data to repository and check for duplicate email and ... there and throw exception there which im not recommand but its more EZ way
                //secound to check data for duplicate in seperate methods which im going to use but its take more time to implement

                var checkEmailExist = await mediator.Send(new CheckEmailExistRequest(request.Email));
                if (checkEmailExist.IsEmailExsit)
                {
                    throw new CustomerAlreadyExistException();
                }

                var checkCustomerDuplicated = await mediator.Send(new CheckCustomerWithDuplicateNameFamilyBirthdateExistRequest(request.Firstname, request.Lastname, request.DateOfBirth));
                if (checkCustomerDuplicated.IsCustomerExist)
                {
                    throw new CustomerAlreadyExistException();
                }

                var insertResult = await commandRepository.InsertCustomer(request);
                if (insertResult)
                {
                    return new InsertCustomersResponse
                    {
                        Message = "Customer Inserted"
                    };
                }
                throw new CustomerInsertFaildException();
            }
        }

        public class UpdateCustomerCommand : IRequestHandler<UpdateCustomersRequest, UpdateCustomersResponse>
        {
            private readonly ICustomerCommandRepository commandRepository;

            public UpdateCustomerCommand(ICustomerCommandRepository commandRepository)
            {
                this.commandRepository = commandRepository;
            }
            public Task<UpdateCustomersResponse> Handle(UpdateCustomersRequest request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }

        public class DeleteCustomerCommand : IRequestHandler<DeleteCustomersRequest, DeleteCustomersResponse>
        {
            private readonly ICustomerCommandRepository commandRepository;

            public DeleteCustomerCommand(ICustomerCommandRepository commandRepository)
            {
                this.commandRepository = commandRepository;
            }
            public Task<DeleteCustomersResponse> Handle(DeleteCustomersRequest request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
