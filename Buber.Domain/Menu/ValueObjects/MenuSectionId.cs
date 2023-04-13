using Buber.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buber.Domain.Menu.ValueObjects
{
    public sealed class MenuSectionId:ValueObject
    {
        public Guid Value { get; }
        private MenuSectionId(Guid value)
        {
            Value = value;
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
        public static MenuSectionId Create() { return new(Guid.NewGuid()); }
    }
}
