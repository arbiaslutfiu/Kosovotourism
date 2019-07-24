using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Monument_Scann.Areas.Admin.Models;

namespace Monument_Scann.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Lajki>()
             .HasOne<Monument>(pt => pt.Monuments)
             .WithMany()
             .HasForeignKey(p=>new { p.MonumentsId });

            modelBuilder.Entity<LajkiTurS>()
           .HasOne<touristspot>(p => p.touristspots)
           .WithMany()           
           .HasForeignKey(c=>c.touristspotsId);
            

            modelBuilder.Entity<MonumentComments>()
                .HasOne(pt => pt.Monumenti)
                .WithMany()
                .HasForeignKey(pt => pt.MonumentId);

            modelBuilder.Entity<TouristSpotComents>()
               .HasOne(pt => pt.Touristspoti)
               .WithMany()
               .HasForeignKey(pt => pt.touristspotId);

        }
        public DbSet<Monument_Scann.Areas.Admin.Models.Monument> Monument { get; set; }
        public DbSet<Monument_Scann.Areas.Admin.Models.touristspot> touristspot { get; set; }
        public DbSet<MonumentComments> MonumentComments { get; set; }
        public DbSet<TouristSpotComents> TouristSpotComents { get; set; }
        public DbSet<Monument_Scann.Areas.Admin.Models.Lajki> Lajkis { get; set; }
        public DbSet<Monument_Scann.Areas.Admin.Models.LajkiTurS> LajkiTurSs { get; set; }
        public DbSet<Monument_Scann.Areas.Admin.Models.Reports> Reports { get; set; }
    }
}
