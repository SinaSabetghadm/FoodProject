using Buber.Domain.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buber.Domain.Persistence
{
    public interface IMenuRepository
    {
        void Add(Buber.Domain.Menu.Menu menu);
    }
}
