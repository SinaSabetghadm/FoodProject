using Buber.Application.Authentication.Commands;
using Buber.Application.Authentication.Commands.Queries;
using Buber.Application.Authentication.Commands.Register;

using Buber.Contracts.Authentication;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private IMediator _mediator;

        public AuthenticationController(Mediator mediator)
        {
           
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterRequest Data) 
        {
            var command = new RegisterCommand()
            {
                Email= Data.Email,
                FirstName= Data.FirstName,  
                LastName= Data.LastName,    
                Password = Data.Password    
            };
            var result =await  _mediator.Send(command); /*_authenticationcommandService.Register(Data);*/
               return Ok(result);
        }
        [HttpPost("login")]
        public ActionResult Login(LoginRequest Data)
        {
            var LoginCommand = new LoginQuery() {Email=Data.Email,Password=Data.Password };
            _mediator.Send(LoginCommand);
            return Ok(Data);
        }
    }
}
