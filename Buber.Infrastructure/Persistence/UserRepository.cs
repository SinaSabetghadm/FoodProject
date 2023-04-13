using Buber.Application.Persistence;
using Buber.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buber.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new List<User>();  
        public void Add(User user)
        {
           _users.Add(user);    
        }

        public User GetByEmail(string email)
        {
          return  _users.SingleOrDefault(u => u.Email == email);  
        }
    }
}
