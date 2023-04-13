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

namespace Buber.Application.Authentication.Commands.Queries
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthenticationResponse>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }
        public async Task<AuthenticationResponse> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            if (_userRepository.GetByEmail(request.Email) is not User user)
            {
                throw new Exception("User not exists.");

            }

            if (user.Password != request.Password)
            {
                throw new Exception("Invalid password.");
            }

            var Token = _jwtTokenGenerator.GenerateToken(user.Id, user.Name, user.LastName);

            return new AuthenticationResponse
            {
                Id = user.Id,
                LastName = user.LastName,
                Email = user.Email,
                FirstName = user.Name,
                Token = Token,
            };
        }
    }
}
