using Buber.Domain.Menu.Entities;
using Buber.Domain.Menu.ValueObjects;
using Buber.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Buber.Domain.Menu
{
    public sealed class Menu:AggregateRoot<MenuId>
    {
        private readonly List<MenuSection> _section=new();
        public string  Name { get; set; }
        public string Description { get; set; }
        public float AverageRating { get; set; }
        private IReadOnlyList<MenuSection> Items => _section.ToList();
        public Menu(MenuId menuId, string name, string description,float averagerating) : base(menuId)
        {
            Name = name;
            Description = description;
            AverageRating= averagerating;   
        }

    }
}
