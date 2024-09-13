using Microsoft.EntityFrameworkCore;
using MVC_Project.DAL.Data.Configurations;
using MVC_Project.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Project.DAL.Data
{
    public class AppDbContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("server = . ; Database = FinalProject  ; Trusted_Connection = True ; MultipleActiveResultSets=True; Encrypt = False ");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent APIS
            //modelBuilder.ApplyConfiguration<Department>(new DepartmentConfigurations());
            modelBuilder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        public  DbSet<Department> Departments { get; set; }
    }
}
