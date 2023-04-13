using Buber.Domain.Menu;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buber.Infrastructure.Persistence.BuberDataBaseContext
{
    public class BuberDbContext:DbContext
    {
        public BuberDbContext(DbContextOptions<DbContext> options):base(options)
        {

        }
        public DbSet<Menu> Menus { get; set; }
    }
}
