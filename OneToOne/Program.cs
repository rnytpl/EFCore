using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//ETicaretContext context = new();


#region Default Convention

//Her iki entity'de Nav Property ile birbirlerini tekil olarak referans ederek fiziksel bir ilişkinin olacağı ifade edilir

// 1 to 1 ilişki türünde, dependent entity hangisi olduğunu default olarak belirleyebilmek pek kolay değildir. Bu durumda dependent entity'de fiziksel olarak bir foreign key'e karşılık property/kolon tanımlayarak çözebiliyoruz

// Foreign Key'e karşılık property tanımlamak lüzumsuz bir maliyettir

//public class Calisan
//{
//    public int Id { get; set; }
//    public string Adi { get; set; }
//    public CalisanAdresi CalisanAdresi { set; get; }

//}

//public class CalisanAdresi
//{
//    public int Id { get; set; }
//    public int CalisanId { get; set; }
//    public string Adres { get; set; }
//    public Calisan Calisan { set; get; }
//}

#endregion

#region Data Annotations

// Navigation Property'ler tanımlanmalıdır

// Foreign kolonunun ismi default convention'ın dışında bir kolon olacaksa eğer ForeignKey attribute ile bunu bildirebiliriz

// Foreign Key kolonu oluşturulmak zorunda değildir.

// Bire bir ilişkide ekstradan foreign key kolonuna ihtiyaç olmayacağından dolayı dependent entity'de ki id kolonunun hem foreign key hemde primary key olarak kullanmayı tercih ediyoruz ve bu duruma özen gösterilmelidir

//public class Calisan
//{
//    public int Id { get; set; }
//    public string Adi { get; set; }
//    public CalisanAdresi CalisanAdresi { set; get; }
//}

//public class CalisanAdresi
//{
//    public int Id { get; set; }

//    [Key, ForeignKey(nameof(Calisan))]
//    public int CalisanId { get; set; }
//    public string Adres { get; set; }
//    public Calisan Calisan { set; get; }
//}
#endregion

#region Fluent API

// Navigation propler tanımlanmalıdır

// Fluent API yönteminde entityler arasında ki ilşki contect sınıfı içerisinde OnModelCreating Fonksiyonu override edilerek metotlar aracılığıyla tasarlanması gerekmektedir. Yani tüm sorumluluk bu fonksiyon içerisindeki çalışmalardador

//public class Calisan
//{
//    public int Id { get; set; }
//    public string Adi { get; set; }
//    public Departman Departman { get; set; }

//}

//public class Departman
//{
//    public int Id { get; set; }
//    public string DepartmanAdi { get; set; }
//    public Calisan Calisan { get; set; }
//}


////#endregion

//public class ETicaretContext : DbContext
//{
//    public DbSet<Calisan> Calisanlar { get; set; }
//    public DbSet<Departman> Departmanlar { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    {
//        optionsBuilder.UseSqlServer("Server=LAPTOP-EFPS8KL8; Database=OneToOne; User Id=LAPTOP-EFPS8KL8\\huawei; Trusted_Connection=True");
//        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
//    }

//    // Modellerin veritabanında generate edilecek yapıları bu fonksiyon içerisinde konfigüre edilir

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<Calisan>().HasKey(c => c.Id);

//        modelBuilder.Entity<Calisan>().HasOne(c => c.Departman).WithOne(d => d.Calisan).HasForeignKey<Calisan>(c => c.Id);
//    }

//}

#endregion