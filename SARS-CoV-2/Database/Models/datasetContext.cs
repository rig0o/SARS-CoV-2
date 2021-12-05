using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SARS_CoV_2.Database.Models
{
    class datasetContext : DbContext
    {
        public DbSet<Dataset> Datasets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString: "Filename=dataset.db",
                sqliteOptionsAction: op => {
                    op.MigrationsAssembly(
                        Assembly.GetExecutingAssembly().FullName
                        );
                });

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dataset>().ToTable("dataset");
            modelBuilder.Entity<Dataset>(entity =>
            {
                entity.HasKey(e => e.Fecha);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
