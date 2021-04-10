using Microsoft.EntityFrameworkCore;
using NLayerProject.Core.Models;
using NLayerProject.Data.Configuration;
using NLayerProject.Data.Seeds;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerProject.Data
{
   public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            //Seeder
            modelBuilder.ApplyConfiguration(new CategorySeed(new int[] { 1, 2 }));
            modelBuilder.ApplyConfiguration(new ProductSeed(new int[] { 1, 2 }));

            //
            modelBuilder.Entity<Person>().HasKey(x => x.Id);
            modelBuilder.Entity<Person>().Property(x => x.Id).UseIdentityColumn();
            modelBuilder.Entity<Person>().Property(x => x.Name).HasMaxLength(100);
            modelBuilder.Entity<Person>().Property(x => x.SurName).HasMaxLength(100);
        }
    }
}
