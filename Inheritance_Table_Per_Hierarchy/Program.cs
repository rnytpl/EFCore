//using Microsoft.EntityFrameworkCore;

//Console.WriteLine();

//ApplicationDbContext context = new();

//#region Table Per Hierarchy (TPH) Nedir?

//// Kalıtımsal ilişkiye sahip olan entitylerin olduğu senaryolarda her bir hierarşiye karşılık bir tablo oluşturan davranıştır

//#endregion
//#region Neden Table Per Hierarchy Yaklaşımında Bir Tabloya İhtiyacımız Olsun?

//// İçerisinde benzer alanlara sahip olan entityleri migrate ettiğimizde her entity'e karşılık bir tablo oluşturmaktansa bu entityleri tek bir tabloda modellemek isteyebilir ve bu tablodaki kayıtları discriminator kolonu üzerinden birbirlerinden ayırabiliriz. İşte bu tarz bir tablonun oluşturulması ve bu tarz bir tabloya göre sorgulama veri ekleme silme vs gibi operasyonların şekillendirilmesi için TPH davranışını kullanabiliriz

//#endregion
//#region TPH Nasıl Uygulanır?
//// EF Core'da entity arasında temel bir takılıtımsal ilişki söz konusuysa eğer default olarak kabul edilen bir davranıştır

//// O yüzden herhangi bir konfigürasyon gerektirmez
//// Entityler kendi aralarında kalıtımsal iliikiye sahip olmalı ve bu entitylerin hepsi DbContext nesnesine DbSEt olarak eklenmelidir
//#endregion
//#region Discriminator Kolonu Nedir?

//// Table Per Hierarchy yaklaşımı neticesinde kümülatif olarak inşa edilmiş tablonun hangi entitye karşılık veri tuttuğunu ayırt etmemizi sağlayan bir kolondur
//// EF Core tarafından otomatik olarak tabloya yerleştirilir

//// Default olarak içerisinde entity isimlerini tutar

//// Discriminator kolonunu komple özelleştirebiliriz

//#endregion
//#region Discriminator Kolon Adı Nasıl Değiştirilir?
////Employee employee = new()
////{
////    Name = "Gençay",
////    Surname = "Yıldız",

////};

////await context.Employees.AddAsync(employee);
////await context.SaveChangesAsync();
//#endregion
//#region Discriminator Değerleri Nasıl Değiştirilir?

//// Yine hierarşinin başındaki entity konfigürasyonlarına gelip HasDiscriminator Fonksiyınu ile özelleştirmede bulunarak ardından HasValue fonksiyonu ile hangi entitye karşılık hangi dweğerin girileceğini beliritlen türde ifade edebilirsiniz

//#endregion
//#region TPH'da Veri Ekleme

////Person p1 = new()
////{
////    Name = "Ronay",
////    Surname= "Topal"
////};

//Employee e1 = new()
//{
//    Name = "Gençay",
//    Surname = "Yıldız",
//    Department = "IT"
//};

//Employee e2 = new()
//{
//    Name = "Şuayip",
//    Surname = "Çakar",
//    Department = "Warehouse"
//};

//Customer c1 = new()
//{
//    CompanyName = "Turkish Airlines",
//    Name = "Pelin",
//    Surname = "Aksu",

//};

//Customer c2 = new()
//{
//    CompanyName = "Petkim",
//    Name = "Abidini",
//    Surname = "Suyusıcak",
//};

//Technician t1 = new()
//{
//    Surname = "Kıllıbacak",
//    Name = "Rıfkı",
//    Department = "Muhasebe",
//    Branch = "Şoför"
//};

//await context.Employees.AddRangeAsync(e1, e2);
//await context.Customers.AddRangeAsync(c1, c2);
//await context.Technicians.AddAsync(t1);
//await context.SaveChangesAsync();

//#endregion
//#region TPH'da Veri Silme
//// TablePerHierarchy silme operasyonu yine entity üzerinden gerçekleştirilir

////Employee employee = await context.Employees.FindAsync(3);

////context.Employees.Remove(employee);
////await context.SaveChangesAsync();

////var customers = await context.Customers.ToListAsync();
////context.Customers.RemoveRange(customers);
////await context.SaveChangesAsync();

//#endregion
//#region TPH'da Veri Güncelleme

//// TablePerHierarchy güncelleme operasyonu yine entity üzerinden gerçekleştirilir

//var guncellenecek = await context.Employees.FindAsync(8);
//guncellenecek.Name = "Hilmi";
//await context.SaveChangesAsync();
//#endregion
//#region TPH'da Veri Sorgulama

//// Veri sorgulama operasyonu bilinen DbSet propertysi üzerindne sorgulamadır.
//// Ancak bureada dikkat edilmesi gereken husus şudur ;

//var employees = await context.Employees.ToListAsync();

//// Kalıtımsal ilişkiye göre yapılan sorgulamalarda üst sınıf alt sınıftaki verileride kapsamaktadır. O yüzden üst sınıfların sorgulamalarında alt sınıfların verileride gelecektir. 
//// Sorgulama süreçlerinde EF Core generate edilen sorguya bir where şartı eklemektedir
//#endregion
//#region Farklı Entity'ler de Aynı İsimde Sütunların Olduğu Durumlar

//#endregion

//class Person
//{
//    public int Id { get; set; }
//    public string? Name { get; set; }
//    public string? Surname { get; set; }
//}
//class Employee : Person
//{
//    public string? Department { get; set; }
//}
//class Customer : Person
//{
//    public int A { get; set; }
//    public string? CompanyName { get; set; }
//}
//class Technician : Employee
//{
//    public int A { get; set; }
//    public string? Branch { get; set; }
//}

//class ApplicationDbContext : DbContext
//{
//    public DbSet<Person> Persons { get; set; }
//    public DbSet<Employee> Employees { get; set; }
//    public DbSet<Customer> Customers { get; set; }
//    public DbSet<Technician> Technicians { get; set; }
//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        //modelBuilder.Entity<Person>()
//        //    .HasDiscriminator<string>("ayirici")
//        //    .HasValue<Person>("A")
//        //    .HasValue<Employee>("B")
//        //    .HasValue<Customer>("C")
//        //    .HasValue<Technician>("D");

//        modelBuilder.Entity<Person>()
//            .HasDiscriminator<string>("Ayirici");
//    }
//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    {
//        optionsBuilder.UseSqlServer("Server=LAPTOP-EFPS8KL8;Database=InheritanceTablePerHierarchy;User ID=LAPTOP-EFPS8KL8\\huawei;Trusted_Connection=True");
//    }
//}