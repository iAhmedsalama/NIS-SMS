﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NIS.Models
{
    public class DbEntities:IdentityDbContext
    {
        public DbEntities() { }
        public DbEntities(DbContextOptions<DbEntities> options) :base(options) { }

        public DbSet<Instructor> Instructor { get; set; } 
        public DbSet<Department> Department { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Student> Trainee { get; set; }
        public DbSet<CrsResult> CrsResult { get; set; }


        // server name - database name - Authentation
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ITI_DB;Integrated Security=True");
        }
       
        */

    }
}
