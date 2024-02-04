using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
Console.WriteLine("");

ApplicationDbContext context = new();

#region Sequence Nedir?
//Veritabanında benzersiz ve ardışık sayısal değerler üreten veritabanı nesnesidir.
//Sequence herhangi bir tablonun özelliği değildir. Veritabanı nesnesidir. Birden fazla tablo tarafından kullanılabilir.
#endregion
#region Sequence Tanımlama

// Sequence'ler üzerinden değer oluştururken veritabanına özgü çalışma yapılması zaruridir. SQL Server'a özel yazılan SEquence tanımı örnek olarak Oracle veri tabanı için hata verebilir

await context.Employees.AddAsync(new() { Name = "Gençay", Surname = "Yıldız", Salary = 1000});
await context.Employees.AddAsync(new() { Name = "Mustafa", Surname = "Toplar", Salary = 1000 });
await context.Employees.AddAsync(new() { Name = "Okan", Surname = "Cacık", Salary = 1000 });
await context.Customers.AddAsync(new() { Name = "Reha" });

await context.SaveChangesAsync();

#region HasSequence

#endregion
#region HasDefaultValueSql

#endregion
#endregion

#region Sequence Yapılandırması

#region StartsAt



#endregion
#region IncrementsBy

#endregion
#endregion
#region Sequence İle Identity Farkı

// Sequence bir veritabanı nesnesiyken, Identity ise tabloların özellikleridir
// Yani Sequence herhangi bir tabloya bağımlıdır
// Identity bir sonraki değeri diskten alırken Sequence ise RAM'den alır. Bu yüzden önemli ölçüde Identity'e nazaran daha hızlı ve az maliyetlidir

#endregion

class Employee
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public int Salary { get; set; }
}
class Customer
{
    public int Id { get; set; }
    public string? Name { get; set; }
}
class ApplicationDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Customer> Customers { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasSequence("EC_Sequence")
            .StartsAt(100)
            .IncrementsBy(10);

        modelBuilder.Entity<Employee>().Property(e => e.Id).HasDefaultValueSql("NEXT VALUE FOR EC_Sequence");
        modelBuilder.Entity<Customer>().Property(c => c.Id).HasDefaultValueSql("NEXT VALUE FOR EC_Sequence");
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=LAPTOP-EFPS8KL8; Database=Sequences;User Id=LAPTOP-EFPS8KL8\\huawei;Trusted_Connection=True");
    }
}