using Buber.Domain.Menu.ValueObjects;
using Buber.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buber.Domain.Menu.Entities
{
    public sealed class MenuSection:Entity<MenuSectionId>
    {
        private readonly List<MenuItem> _items = new();

        public string Name { get; set; }
        public string Description { get; set; } 

        private IReadOnlyList<MenuItem> Items => _items.ToList();
        public MenuSection(MenuSectionId menuSectionId,string name,string description) :base(menuSectionId)
        {
            Name= name;
            Description= description;   
        }
        public static MenuSection Create(string Name,string Description)
        {
            return new MenuSection(MenuSectionId.Create(),Name,Description);   
        }
    }
}
