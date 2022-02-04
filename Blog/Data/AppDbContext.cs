using Blog.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Blog.Data
{
    public class AppDbContext : DbContext

    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {


        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            


            modelBuilder.Entity<TagWpis>()
                .HasKey(tw => new { tw.WpisId, tw.TagId });


            modelBuilder.Entity<TagWpis>()
             .HasOne(w => w.Wpis)
             .WithMany(tw => tw.TagiWpisy)
             .HasForeignKey(wi => wi.WpisId);

            modelBuilder.Entity<TagWpis>()
              .HasOne(t => t.Tag)
              .WithMany(tw => tw.TagiWpisy)
              .HasForeignKey(ti => ti.TagId);


            modelBuilder.Entity<Wpis>()             //entity  wpis
                .HasMany(k => k.Komentarze)           // has many comments
                .WithOne(w => w.Wpis)               // and each commant has one wpis
                .HasForeignKey(wi => wi.WpisId);      // foreigne key in komentarze table

            modelBuilder.Entity<Wpis>()             //Entity  Wpis
                .HasMany(o => o.Oceny)           // has many ratings
                .WithOne(w => w.Wpis)               // and each commant has one Wpis
                .HasForeignKey(wi => wi.WpisId);      // Foreigne key in Komentarze table

            base.OnModelCreating(modelBuilder);

        }



        public virtual DbSet<Tag> Tagi { get; set; }

        public virtual DbSet<Wpis> Wpisy { get; set; }

        public virtual DbSet<Komentarz> Komentarze { get; set; }

       

        public virtual DbSet<Ocena> Oceny { get; set; }


        public virtual DbSet<TagWpis> TagiWpisy { get; set; }




    }
}
