using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    public class ETicaretContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Parca> Parcalar { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-EFPS8KL8; Database=EFCoreBasics; User Id=LAPTOP-EFPS8KL8\\huawei; Trusted_Connection=True");
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

    }

    public class Product
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public float Price { get; set; }
        public ICollection<Parca> Parca { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

    }

    public class Parca
    {
        public int Id { get; set; }
        public string ParcaAdi { get; set; }
    }

    public class Author
    {
        public Author()
        {
            Console.WriteLine("New author has been created");
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }

    public class Book
    {
        public Book()
        {
            Console.WriteLine("New book has been created");
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Author> Authors { get; set; }
    }

}
