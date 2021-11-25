using Microsoft.EntityFrameworkCore;
using reppat.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reppat.DataAccess.Concrete.EntityFramework.Contexts
{
    public class ReppatContext : DbContext
    {
        public ReppatContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=REPPAT;User ID=sa;Password=Pw123456");
        }

        public DbSet<Personal> Personals { get; set; }
    }
}
