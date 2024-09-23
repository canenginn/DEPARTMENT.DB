using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Azure.Core;
using Azure;
using System.Text.RegularExpressions;
using DEPARTMENT.DB.Models;

namespace DEPARTMENT.DB
{
    public partial class DepartmentContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            AppConfiguration appConfiguration = new AppConfiguration();
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(appConfiguration.ConnectionString);
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetForeignKeys())
            .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            

        }

    }



}