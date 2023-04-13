using Buber.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buber.Domain.Menu.ValueObjects
{
    public class MenuId : ValueObject
    {
        public Guid Value { get; }
        private MenuId( Guid value)
        {
            Value= value;
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
        public static MenuId Create(Guid value) { return new(Guid.NewGuid()); } 
    }
}
