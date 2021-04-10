using Microsoft.EntityFrameworkCore;
using System;

namespace Ehpad.ORM
{
    public class Context : DbContext
    {

        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonneType> PersonTypes { get; set; }
        public DbSet<Vaccin> Vaccines { get; set; }
        public DbSet<VaccinType> VaccineTypes { get; set; }
        public DbSet<Vacciner> Vaccinates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonneType>().HasData(new PersonneType { Id = 1, Label = "Personnel" }, new PersonneType { Id = 2, Label = "Résident" });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=" + Config.DB_FILE);
        }

    }
}
