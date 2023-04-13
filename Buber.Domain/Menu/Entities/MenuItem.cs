using Buber.Domain.Menu.ValueObjects;
using Buber.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buber.Domain.Menu.Entities
{
    public sealed class MenuItem : Entity<MenuItemId>
    {

        public string Name { get; set; }
        public string Description { get; set; }

        public MenuItem(MenuItemId menuItemId,string name,string description):base(menuItemId)
        {
            Name= name;
            Description= description;
        }
        public static MenuItem Create(string name,string description)
        {
            return new(MenuItemId.Create(), name, description);
        }
    }
}
