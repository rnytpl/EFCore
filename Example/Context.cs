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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-EFPS8KL8; Database=EFCoreBasics; User Id=LAPTOP-EFPS8KL8/huawei; Trusted_Connection=True");
        }
    }

    public class Product
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public float Price { get; set; }

        public ICollection<Parca> Parca { get; set; }
    }

    public class Parca
    {
        public int Id { get; set; }

        public string ParcaAdi { get; set; }
    }
}
