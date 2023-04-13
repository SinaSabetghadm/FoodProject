using Buber.Application.Authentication.Commands.Register;
using Buber.Contracts.Authentication;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buber.Application.Common.Behaviors
{
    public class ValidationBehavior : IPipelineBehavior<RegisterCommand, AuthenticationResponse>
    {
        private readonly IValidator<RegisterCommand> _validator;
        public ValidationBehavior(IValidator<RegisterCommand> validator)
        {
            _validator = validator;
        }
    
        public async Task<AuthenticationResponse> Handle(RegisterCommand request, RequestHandlerDelegate<AuthenticationResponse> next, CancellationToken cancellationToken)
        {
            var validationResult=await _validator.ValidateAsync(request);
            if (validationResult.IsValid) 
            {
                return await next();


            }
            var errors= validationResult.Errors.Select(x=>x.ErrorMessage);
            return (AuthenticationResponse)errors;

        }
    }
}
