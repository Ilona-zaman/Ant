using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Ant.Models
{
    public partial class AntDBContext : DbContext
    {
        public AntDBContext(DbContextOptions<AntDBContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("Cities");
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("nvarchar(MAX)");
            });
        }

        public virtual DbSet<City> Cities { get; set; }
    }
}