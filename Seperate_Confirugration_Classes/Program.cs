using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection;

#region OnModelCreating

// Entityler üzerinde konfigürasyonel çalışmalar yapmamızı sağlayan bir fonksiyondur

#endregion

#region IEntityTypeConfiguration<T> Arayüzü

// Entity bazlı yapılacak olan konfigürasyonları o entity' özel harici bir dosya üzerinde yapmamızı sağlayan bir arayüzdür

// Harici bir dosyada konfigürasyonların yürütülmesi merkezi bir yapılandırma noktası oluşturmamızı sağlamaktadır

// Harici bir dosyada konfigürasyonların yürütülmesi entity sayısınını fazla olduğu senaryolarda yönetilebilirliği arttıracak ve yapıalndırma ike ilgili geliştiricinin yükünü azaltacaktır

#endregion

#region ApplyConfiguration Metodu

// Bu method harici konfigürasyonel sınıflarmızıu EF Core'a bildirebilmek için kullandığımız bir metotdur.

#endregion

#region ApplyConfigurationsFromAssembly Metodu

// Uygulama bazında oluşturulan harici konfigürasyonel sınıfların her birini OnModelCreating metodunda ApplyConfiguration metodu ile tek tek bildirmek yerine bu sınıfların bulunduğu Assembl'i bildirerek IEntityTypeConfiguration arayüzünden türeyen tüm sınıflarrı ilgili entity'e kaşılık konfgürasyonel değer olarak baz almasını tek kalemde gerçekleştirmemizi sağlayan bir metotdur

#endregion

#region

#endregion

class Order
{
    public int OrderId { get; set; }
    public string Description { get; set; }
    public DateTime OrderDate { get; set; }

}

class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.OrderId);
        builder.Property(x => x.Description).HasMaxLength(13);
        //builder.Property(x => x.OrderDate).HasDefaultValue(DateTime.Now);
        builder.Property(x => x.OrderDate).HasDefaultValueSql("GETDATE()");


    }
}

class ApplicationDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}