using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameWork
{
    public class PersonsDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public PersonsDbContext(DbContextOptions<PersonsDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            base.OnModelCreating(modelBuilder);
        }
    }
}
