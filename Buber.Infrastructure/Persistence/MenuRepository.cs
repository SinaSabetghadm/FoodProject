using Buber.Domain.Menu;
using Buber.Domain.Persistence;
using Buber.Infrastructure.Persistence.BuberDataBaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buber.Infrastructure.Persistence
{
    public class MenuRepository : IMenuRepository
    {
        private readonly BuberDbContext _dbContext;
        public MenuRepository(BuberDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    
        public void Add(Menu menu)
        {
            _dbContext.Add(menu);
            _dbContext.SaveChanges();   
        }
    }
}
