
////using Microsoft.EntityFrameworkCore;

////Console.WriteLine("Hello, World!");

////Technician technician = new()
////{
////    Branch = "Plumb",
////    Department = "Construction",
////    Name = "Rny",
////    Surname = "Tpl",
////};


//#region Table Per Type (TPT) Nedir?
////Entitylerin aralarında kalıtımsal ilişkiye sahip olduğu durumlarda her bir türe/entitye/tip/referans karşılık bir tablo generate eden davranıştır.
////Her generate edilen bu tablolar hiyerarşik düzlemde kendi aralarında birebir ilişkiye sahiptir.
//#endregion
//#region TPT Nasıl Uygulanır?
////TPT'yi uygulayabilmek için öncelikle entitylerin kendi aralarında olması gereken mantıkta inşa edilmesi gerekmektedir.
////Entityler DbSet olarak bildirilmelidir.
////Hiyerarşik olarak aralarında kalıtımsal ilişki olan tüm entityler OnModelCreating fonksiyonunda ToTable metodu ile konfigüre edilmelidir. Böylece EF Core kalıtımsal ilişki olan bu tablolar arasında TPT davranışının olduğunu anlayacaktır.
//#endregion
//#region TPT'de Veri Ekleme
////Technician technician = new() { Name = "Şuayip", Surname = "Yıldız", Department = "Yazılım", Branch = "Kodlama" };
////await context.Technicians.AddAsync(technician);

////Customer customer = new() { Name = "Hilmi", Surname = "Celayir", CompanyName = "Çaykur" };
////await context.Customers.AddAsync(customer);
////await context.SaveChangesAsync();
//#endregion
//#region TPT'de Veri Silme
////Employee? silinecek = await context.Employees.FindAsync(3);
////context.Employees.Remove(silinecek);
////await context.SaveChangesAsync();

////Person? silinecekPerson = await context.Persons.FindAsync(1);
////context.Persons.Remove(silinecekPerson);
////await context.SaveChangesAsync();
//#endregion
//#region TPT'de Veri Güncelleme
////Technician technician = await context.Technicians.FindAsync(2);
////technician.Name = "Mehmet";
////await context.SaveChangesAsync();
//#endregion
//#region TPT'de Veri Sorgulama
////Employee employee = new() { Name = "Fatih", Surname = "Yavuz", Department = "ABC" };
////await context.Employees.AddAsync(employee);
////await context.SaveChangesAsync();

////var technicians = await context.Technicians.ToListAsync();
////var employees = await context.Employees.ToListAsync();

////Console.WriteLine();
//#endregion

//class Person
//{

//    public Person()
//    {
//        Console.WriteLine("Principal entity constructor is evoked");
//    }
//    public int Id { get; set; }
//    public string? Name { get; set; }
//    public string? Surname { get; set; }
//}
//class Employee : Person
//{
//    public Employee()
//    {
//        Console.WriteLine("Person Class");

//    }
//    public string? Department { get; set; }
//}
//class Customer : Person
//{
//    //public int A { get; set; }
//    public string? CompanyName { get; set; }
//}
//class Technician : Employee
//{
//    public Technician()
//    {
//        Console.WriteLine("Technicion Class");
//    }
//    //public int A { get; set; }
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
//        optionsBuilder.UseSqlServer("Server=LAPTOP-EFPS8KL8;Database=InheritanceTablePerType;User ID=LAPTOP-EFPS8KL8\\huawei;Trusted_Connection=True");
//    }
//}