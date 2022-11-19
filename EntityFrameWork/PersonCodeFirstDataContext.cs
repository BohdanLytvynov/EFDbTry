using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWork
{
    internal class PersonCodeFirstDataContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public DbSet<Patient_Doctor> Patient_Physician { get; set; }

        public DbSet<Adress> Adresses { get; set; }

        public DbSet<AddInfo> AdInfo { get; set; }

        #region Ctor

        public PersonCodeFirstDataContext(DbContextOptions<PersonCodeFirstDataContext> options, bool Remove): base(options)
        {
            if (Remove)
            {
                Database.EnsureDeleted();
            }

            Database.EnsureCreated();                        
        }

        #endregion

        #region Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasKey(e => e.PrimKey);
            
            modelBuilder.Entity<Person>().HasOne(p => p.ActualAdress).
                WithOne(ad=> ad.Person)
                .HasForeignKey<Adress>(fk => fk.PersonId);

            modelBuilder.Entity<Person>().HasMany(p => p.AddInfoList)
                .WithOne(l => l.Person).HasForeignKey(fk => fk.PersonId);
                
            modelBuilder.Entity<Patient_Doctor>().HasOne(p=> p.Patient).WithMany(p=> p.Patient_Doctors)
                .HasForeignKey(fk => fk.PatientId);

            modelBuilder.Entity<Patient_Doctor>().HasOne(d => d.Doctor).WithMany(d => d.Patient_Doctors)
                .HasForeignKey(fk=> fk.DoctorId);

            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
