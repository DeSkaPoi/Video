using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Video.Domain;

namespace Video.Infrastructure
{
    public class VideoContext : DbContext
    {
        public DbSet<VideoManager> Videos { get; set; }
        public VideoContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VideoManager>(tmp =>
            {
                tmp.Property(prop => prop.Title).HasDefaultValue("not indicated");
                tmp.Property(prop => prop.Format).HasDefaultValue("not indicated");
                tmp.Property(prop => prop.Size).HasDefaultValue("not indicated");
                tmp.Property(prop => prop.Resolution).HasDefaultValue("not indicated");
                tmp.Property(prop => prop.Description).HasDefaultValue("not indicated");
                tmp.Property(prop => prop.LastUpdate).HasDefaultValue(null);
                tmp.Property(prop => prop.BelongDocument).HasDefaultValue(false);
            });
        }
    }
}
