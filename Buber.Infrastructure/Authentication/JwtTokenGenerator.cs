using Buber.Application.Common.Interfaces.Authentication;
using Buber.Application.Common.Interfaces.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Buber.Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IDateTimeProvider _timeProvider;
        private readonly JwtSettings _jwtSettings;
        public JwtTokenGenerator(IDateTimeProvider timeProvider,IOptions<JwtSettings> jwtsettings)
        {
            _timeProvider = timeProvider;
            _jwtSettings = jwtsettings.Value;
        }
    
        public string GenerateToken(Guid Id, string FirstName, string LastName)
        {
            var siginingCredentials=new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),SecurityAlgorithms.HmacSha256);    
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,Id.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName,FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName,LastName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            };

        
            var securityToken = new JwtSecurityToken(audience:_jwtSettings.Audience,claims: claims,signingCredentials:siginingCredentials,issuer:_jwtSettings.Issuer,expires:_timeProvider.UtcNow.AddMinutes(60));

            return new JwtSecurityTokenHandler().WriteToken(securityToken);  
        }

    }
}
