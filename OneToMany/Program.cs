using Microsoft.EntityFrameworkCore;

Console.WriteLine("App;");

#region Default Convention

public class Calisan
{
    public int Id { get; set; }
    public string Adi { get; set; }
    public Departman Departman { get; set; }
}

public class Departman
{
    public int Id { get; set; }
    public ICollection<Calisan> Calisanlar { get; set; }
}

#endregion
public class ETicaretContext : DbContext
{
    public DbSet<Calisan> Calisanlar { get; set; }
    public DbSet<Departman> Departmanlar { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=LAPTOP-EFPS8KL8; Database=OneToMany; User Id=LAPTOP-EFPS8KL8\\huawei; Trusted_Connection=True");
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }

}