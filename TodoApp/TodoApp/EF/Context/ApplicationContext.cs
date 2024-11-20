using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic.ApplicationServices;
using TodoApp.Model;

namespace TodoApp.EF.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Model.Task> Tasks { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<PeriodTask> PeriodTasks { get; set; } = null!;
        public DbSet<Model.Timer> Timers { get; set; } = null!;

        public ApplicationContext()
        {
            // Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("C:\\AllMine\\course_project\\test\\TodoApp\\TodoApp\\appsettings.json")
                    .Build();
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("defaultConnection"));
            }
        }

        //public override int SaveChanges()
        //{
        //    var entities = ChangeTracker.Entries()
        //        .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified)
        //        .Select(e => e.Entity);

        //    foreach (var entity in entities)
        //    {
        //        var validationContext = new ValidationContext(entity);
        //        Validator.ValidateObject(entity, validationContext, validateAllProperties: true);
        //    }

        //    return base.SaveChanges();
        //}
    }
}
