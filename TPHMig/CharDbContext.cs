using EntityFrameWork.TPH;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPHMig
{
    public class CharDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public DbSet<Warrior> Warriors { get; set; }

        public DbSet<Hero> Heroes { get; set; }
       
        public CharDbContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDb;Initial Catalog=TPH;Integrated Security=True");

            base.OnConfiguring(optionsBuilder); 
        }
    }
}
