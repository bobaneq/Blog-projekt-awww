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
                 .HasKey(tw => new
                 {
                     tw.TagId,
                     tw.WpisId
                 });

            modelBuilder.Entity<TagWpis>()
                .HasOne(t => t.Tag)
                .WithMany(tw => tw.TagiWpisy)
                .HasForeignKey(ti => ti.TagId);

            modelBuilder.Entity<TagWpis>()
            .HasOne(w => w.Wpis)
            .WithMany(tw => tw.TagiWpisy)
            .HasForeignKey(wi => wi.WpisId);



            base.OnModelCreating(modelBuilder);
        }

     

        public DbSet<Wpis> Wpisy { get; set; }

        public DbSet<Komentarz> Komentarze { get; set; }

        public DbSet<Tag> Tagi { get; set; }

        public DbSet<Ocena> Oceny { get; set; }


        public DbSet<TagWpis> TagiWpisy { get; set; }




    }
}
