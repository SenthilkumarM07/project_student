using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApplication1.Models;

namespace WebApplication1
{
    public class Class1 : DbContext
    {
        public Class1() : base("Project")
        {
            Database.SetInitializer<Class1>(new CreateDatabaseIfNotExists<Class1>());
        }
        public DbSet<Student> students { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<DocumentModel> Documents { get; set; }
       // public DbSet<Timetable> Timetables { get; set; }

    }
}