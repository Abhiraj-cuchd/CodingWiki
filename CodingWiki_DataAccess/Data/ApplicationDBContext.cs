using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_DataAccess.Data
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        //public DbSet<Category> Genres { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<SubCategory> SubCategories { get; set; }

        public DbSet<BookDetail> BookDetails { get; set; }

        public DbSet<Fluent_BookDetail> BookDetail_Fluent {  get; set; }

        public DbSet<Fluent_Book> Fluent_Book { get; set; }

        public DbSet<Fluent_Publisher> Fluent_Publisher { get; set; }

        public DbSet<Fluent_Author> Fluent_Author { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=GIDEON-07\\SQLEXPRESS;Database=CodingWiki;TrustServerCertificate=True;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fluent_BookDetail>().ToTable("Fluent_BookDetails");
            modelBuilder.Entity<Fluent_BookDetail>().Property(u => u.NumberOfChapters).HasColumnName("NoOfChapters");
            modelBuilder.Entity<Fluent_BookDetail>().Property(u => u.NumberOfChapters).IsRequired();
            modelBuilder.Entity<Fluent_BookDetail>().HasKey(u => u.BookDetail_Id);

           
            modelBuilder.Entity<Fluent_Book>().Property(u => u.ISBN).HasMaxLength(20);
            modelBuilder.Entity<Fluent_Book>().Property(u => u.ISBN).IsRequired();
            modelBuilder.Entity<Fluent_Book>().HasKey(u => u.IdBook);
            modelBuilder.Entity<Fluent_Book>().Ignore(u => u.PriceRange);

            modelBuilder.Entity<Fluent_Author>().HasKey(u => u.Author_Id);
            modelBuilder.Entity<Fluent_Author>().Property(u => u.FirstName).HasMaxLength(50);
            modelBuilder.Entity<Fluent_Author>().Property(u => u.FirstName).IsRequired();
            modelBuilder.Entity<Fluent_Author>().Property(u => u.LastName).IsRequired();
            modelBuilder.Entity<Fluent_Author>().Ignore(u => u.FullName);

            modelBuilder.Entity<Fluent_Publisher>().HasKey(u => u.Publisher_Id);
            modelBuilder.Entity<Fluent_Publisher>().Property(u => u.Name).IsRequired();


            modelBuilder.Entity<Book>().Property(u => u.Price).HasPrecision(10, 5);

            modelBuilder.Entity<BookAuthorMap>().HasKey(u => new { u.Author_Id, u.Book_Id });

            

            modelBuilder.Entity<Book>().HasData(
                   new Book { IdBook = 1, Title = "Spider without Duty", ISBN = "569741", Price = 2500, Publisher_Id = 1 },
                   new Book { IdBook = 2, Title = "Fortune of Time", ISBN = "54684", Price = 1100, Publisher_Id = 1 }
                   );

            var bookList = new Book[]
            {
                new Book { IdBook = 3, Title = "Call of Duty", ISBN = "412369", Price = 3500, Publisher_Id = 2 },
                new Book { IdBook = 4, Title = "2 States", ISBN = "44103", Price = 1300, Publisher_Id = 3 }
            };
            modelBuilder.Entity<Book>().HasData(bookList);

            modelBuilder.Entity<Publisher>().HasData(
                    new Publisher { Publisher_Id = 1, Name = "Oswald Publications", Location = "Bhopal" },
                    new Publisher { Publisher_Id = 2, Name = "RD Sharma Publications", Location = "New Delhi" },
                    new Publisher { Publisher_Id = 3, Name = "Reeva Publications", Location = "Chennai" }
                );
               
        }
    }
}
