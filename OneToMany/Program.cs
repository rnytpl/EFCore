#region Default COnvention
// Default convention ymnteminde foreign key kolununa karşılık gelen property'i tanımladığımızda bu property ismi temel geleneksel entity tanımlama kurallarına uymuyorsa eğer Data Annotations ile müdahalede bulunabiliriz.
//public class Calisan
//{
//    public int Id { get; set; }

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

#region Fluent API

//public class Calisan
//{
//    public int Id { get; set; }
//    public int DepId { get; set; }
//    public string Adi { get; set; }
//    public Departman Departman { get; set; }
//}

//public class Departman
//{
//    public int Id { get; set; }
//    public ICollection<Calisan> Calisanlar { get; set; }
//}

//#endregion
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
//        modelBuilder.Entity<Calisan>().HasOne(c => c.Departman).WithMany(c => c.Calisanlar).HasForeignKey(c => c.DepId);
//    }

//}

#endregion