using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookstoreApi.Models
{
    public partial class BookstoreContext : DbContext
    {
        public BookstoreContext()
        {
        }

        public BookstoreContext(DbContextOptions<BookstoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BookDetails> BookDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-S8EIS201\\SQLEXPRESS;Database=Bookstore;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookDetails>(entity =>
            {
                entity.HasKey(e => e.BookId);

                entity.Property(e => e.AuthorFirstName).IsRequired();

                entity.Property(e => e.PageRange).HasColumnName("Page_range");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PublicationDate)
                    .HasColumnName("Publication_date")
                    .HasColumnType("date");

                entity.Property(e => e.Publisher).IsRequired();

                entity.Property(e => e.TitleOfContainer).HasColumnName("Title_of_container");

                entity.Property(e => e.TitleOfSource)
                    .IsRequired()
                    .HasColumnName("Title_of_source");

                entity.Property(e => e.Url).HasColumnName("URL");

                entity.Property(e => e.VolumeNo).HasColumnName("Volume_no");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
