using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

//Console.WriteLine("Damn");

#region Default Convention

// İki entity arasında ki ilişkiyi navigation propertyler üzerinden çoğul olarak kurmalıyız (ICOllection,List)
// Def convention'da cross table'i manuel oluşturmak zorunda değiliz. EF Core tasarıma uygun bir şekilde cross table'i kendisi otomatik generate edecektir
// Oluşturulan cross table'in içerisinde composite primary key'i otomatik oluşturmuş olacaktır
//public class Kitap
//{
//    public int Id { get; set; }
//    public string KitapAdi { get; set; }
//    public ICollection<Yazar> Yazarlar { get; set; }
//}

//public class Yazar
//{
//    public int Id { get; set; }
//    public string YazarAdi { get; set; }
//    public ICollection<Kitap> Kitaplar { get; set; }
//}



#endregion

#region Data Annotations
// Cross Table manuel olarak oluşturulmalıdır
// Entity'lerde oluşturduğumuz cross table entity'si ile bire çok bir ilişki kurulmalı
// Cross Table'da composite primary key'i data annotation attributelar ile manuel olarak kuramıyoruz
// Bunun için de FluentAPI'da çalışma yapmamız gerekiyor
// Cross Table'a karşılık bir entity modeli oluşturuyorsa eğer bunu context sınıfı içerisinde DbSEt prop'ı olarak bildirmek mecburiyetinde değiliz
//public class Kitap
//{
//    public int Id { get; set; }
//    public string KitapAdi { get; set; }
//    public ICollection<KitapYazar> Yazarlar { get; set; }

//}
//public class KitapYazar
//{

//    // If we want to describe foreign keys with a different name other than entity names

//    //[ForeignKey(nameof(Kitap))]
//    //public int KId { get; set; }

//    //[ForeignKey(nameof(Yazar))]
//    //public int YId { get; set; }
//    public int KitapId { get; set; }
//    public int YazarId { get; set; }
//    public Kitap Kitap { get; set; }
//    public Yazar Yazar { get; set; }
//}

//public class Yazar
//{
//    public int Id { get; set; }
//    public string YazarAdi { get; set; }
//    public ICollection<KitapYazar> Kitaplar { get; set; }
//}



//public class ETicaretContext : DbContext
//{
//    public DbSet<Kitap> Kitap { get; set; }
//    public DbSet<Yazar> Yazarlar { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    {
//        optionsBuilder.UseSqlServer("Server=LAPTOP-EFPS8KL8; Database=ManyToMany; User Id=LAPTOP-EFPS8KL8\\huawei; Trusted_Connection=True");
//        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
//    }

//}
#endregion

#region Fluent API

// Cross table manuel olarak oluşturulmalı
// DbSet olarak eklenmesine lüzum yoktur
// Composite PK haskey metodu ile kurulmalı

//public class Kitap
//{
//    public int Id { get; set; }
//    public string KitapAdi { get; set; }
//    public ICollection<KitapYazar> Yazarlar { get; set; }

//}
//// CrossTable
//public class KitapYazar
//{

//    public int KitapId { get; set; }
//    public int YazarId { get; set; }
//    public Kitap Kitap { get; set; }
//    public Yazar Yazar { get; set; }
//}

//public class Yazar
//{
//    public int Id { get; set; }
//    public string YazarAdi { get; set; }
//    public ICollection<KitapYazar> Kitaplar { get; set; }
//}
//public class ETicaretContext : DbContext
//{
//    public DbSet<Kitap> Kitap { get; set; }
//    public DbSet<Yazar> Yazarlar { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    {
//        optionsBuilder.UseSqlServer("Server=LAPTOP-EFPS8KL8; Database=ManyToMany; User Id=LAPTOP-EFPS8KL8\\huawei; Trusted_Connection=True");
//        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
//    }

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<KitapYazar>().HasKey(ky => new { ky.KitapId, ky.YazarId });

//        modelBuilder.Entity<KitapYazar>().HasOne(c => c.Kitap).WithMany(k => k.Yazarlar).HasForeignKey(ky => ky.KitapId);
//        modelBuilder.Entity<KitapYazar>().HasOne(c => c.Yazar).WithMany(y => y.Kitaplar).HasForeignKey(ky => ky.YazarId);
//    }

//}

#endregion