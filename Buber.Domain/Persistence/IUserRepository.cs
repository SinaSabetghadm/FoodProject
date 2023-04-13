using Buber.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buber.Application.Persistence
{
    public interface IUserRepository
    {
        User GetByEmail(string  email);
        void Add(User user);
    }
}
