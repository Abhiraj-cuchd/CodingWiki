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

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=GIDEON-07\\SQLEXPRESS;Database=CodingWiki;TrustServerCertificate=True;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(u => u.Price).HasPrecision(10, 5);
            modelBuilder.Entity<Book>().HasData(
                   new Book { IdBook = 1, Title = "Spider without Duty", ISBN = "569741", Price = 2500 },
                   new Book { IdBook = 2, Title = "Fortune of Time", ISBN = "54684", Price = 1100 }
                   );

            var bookList = new Book[]
            {
                new Book { IdBook = 3, Title = "Call of Duty", ISBN = "412369", Price = 3500 },
                new Book { IdBook = 4, Title = "2 States", ISBN = "44103", Price = 1300 }
            };
            modelBuilder.Entity<Book>().HasData(bookList);
               
        }
    }
}
