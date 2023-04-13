using Buber.Application.Common.Errors;
using Buber.Application.Common.Interfaces.Authentication;
using Buber.Application.Persistence;
using Buber.Contracts.Authentication;
using Buber.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buber.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthenticationResponse>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;
        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<AuthenticationResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            // Check if user exiset 
            if (_userRepository.GetByEmail(request.Email) is not null)
            {
                throw new DuplicateEmailException("Email already exiset");
            }
            // Check User 
            var user = new User { Email = request.Email, LastName = request.LastName, Name = request.FirstName, Password = request.Password };
            _userRepository.Add(user);

            string token = _jwtTokenGenerator.GenerateToken(user.Id, request.FirstName, request.LastName);

            return new AuthenticationResponse()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Id = user.Id,
                Token = token


            };
        }
    }
}
