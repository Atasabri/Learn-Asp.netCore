using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myApp.Controllers;
using myApp.Models.ViewModels;

namespace myApp.Models
{
    public class DB : IdentityDbContext
    {
        public DB(DbContextOptions<DB> options):base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }


        //For Seed Data On Model Create
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Employee>().HasData(
        //             new Employee { },
        //             new Employee { },
        //             new Employee { }
        //        );
        //}

    }
}
