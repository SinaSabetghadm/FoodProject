using Buber.Domain.Menu;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buber.Application.Menus.Command
{
    public record CreateMenuCommand(
        string Name, string Description, List<MenuSectionCommand> Sections):IRequest<Menu>;

    public record MenuSectionCommand(string Name, string Description, List<MenuItemCommand> Items);

    public record MenuItemCommand(string Name, string Description);

}
