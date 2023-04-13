using Buber.Application.Authentication.Commands.Queries;
using Buber.Application.Authentication.Commands.Register;
using Buber.Contracts.Authentication;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buber.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IMediator,Mediator>();
            services.AddScoped<IPipelineBehavior<RegisterCommand,AuthenticationResponse>>();
            services.AddScoped<IValidator<RegisterCommand>, RegisterCommandValidator>();
            return services;
        }
    }
}
