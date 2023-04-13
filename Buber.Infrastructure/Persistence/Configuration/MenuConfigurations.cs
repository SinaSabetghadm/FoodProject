using Buber.Domain.Menu;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buber.Infrastructure.Persistence.Configuration
{
    public class MenuConfigurations : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            
        }
        private void ConfigMenusTable(EntityTypeBuilder<Menu> builder) { builder.ToTable("Menus"); }  
    }
}
