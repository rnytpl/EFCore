using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#region Default COnvention
// Default convention yönteminde foreign key kolununa karşılık gelen property'i tanımladığımızda bu property ismi temel geleneksel entity tanımlama kurallarına uymuyorsa eğer Data Annotations ile müdahalede bulunabiliriz.

//public class Calisan
//{
//    public int Id { get; set; }

// The reason why we retrieve the name of a variable as a string name is 
// in case property name is altered or removed, it makes sures that specified name actually exists and provides compile-time safety
//    [ForeignKey(nameof(Departman))]
//    public int DepId { get; set; }
//    public string Adi { get; set; }
//    public Departman Departman { get; set; }
//}

//public class Departman
//{
//    public int Id { get; set; }
//    public ICollection<Calisan> Calisanlar { get; set; }
//}

#endregion

#region Data Annotations

//Default convention yönteminde foreign key kolonuna karşılık gelen property'i tanımladığımızda bu property ismi temel geleneksel entity tanımlama kurallarına uymuyorsa eğer Data Annotations'lar ile müdahalede bulunabiliriz."

//class Calisan //Dependent Entity
//{
//    public int Id { get; set; }
//    [ForeignKey(nameof(Departman))]
//    public int DId { get; set; }

//    public string Adi { get; set; }

//    public Departman Departman { get; set; }
//}
//class Departman
//{
//    public int Id { get; set; }

//    public string DepartmanAdi { get; set; }

//    public ICollection<Calisan> Calisanlar { get; set; }

//}

#endregion

#region Fluent API

// Fluent API otomatik olarak foreign key'i oluşturur
// Eğer default convention yöntemiyle ilgili entity'e oluşturulan Id kolonuna custom bir isim vermek istiyorsak, ismi tanımlar sonra fluent api'da bunu belirtiriz.

//public class Calisan // Dependent Entity
//{
//    public int Id { get; set; }
//    //public int DepId { get; set; }
//    public string Adi { get; set; }
//    public Departman Departman { get; set; }
//}

//public class Departman
//{
//    public int Id { get; set; }
//    public ICollection<Calisan> Calisanlar { get; set; }
//}


//public class ETicaretContext : DbContext
//{
//    public DbSet<Calisan> Calisanlar { get; set; }
//    public DbSet<Departman> Departmanlar { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    {
//        optionsBuilder.UseSqlServer("Server=LAPTOP-EFPS8KL8; Database=OneToMany; User Id=LAPTOP-EFPS8KL8\\huawei; Trusted_Connection=True");
//        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
//    }

//    // Fluent API
//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<Calisan>().HasKey(c => c.Id);

//        modelBuilder.Entity<Calisan>().HasOne(c => c.Departman).WithMany(d => d.Calisanlar).HasForeignKey(c => c.Id); 
//    }

//}

#endregion