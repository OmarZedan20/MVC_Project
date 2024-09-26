using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MVC_Project.DAL.Data.Configurations;
using MVC_Project.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Project.DAL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent Api
            // modelBuilder.ApplyConfiguration<Department>(new DepartmentConfigurations() ); //one Configuration
            modelBuilder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());  // All Configuration 
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Department> Departments { get; set; }  

        
    }
}
