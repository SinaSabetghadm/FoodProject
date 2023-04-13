using Buber.Application.Menus.Command;
using Buber.Contracts.Menu;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Controllers
{
    [Route("hosts/{hostId}/menus")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public MenusController(IMapper mapper,IMediator mediator)
        {
            _mapper = mapper;
             _mediator = mediator;  
        }

        [HttpPost]
        public IActionResult CreateMenu(CreateMenuRequest request,string hostid) 
        {
            var command = _mapper.Map<CreateMenuCommand>(request);
            var result=_mediator.Send(command);
            return Ok();
        }
    }
}
