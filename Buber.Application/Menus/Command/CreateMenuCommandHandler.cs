using Buber.Domain.Menu;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buber.Application.Menus.Command
{
    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, Menu>
    {
        public async Task<Menu> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            return default;
        }
    }
}
