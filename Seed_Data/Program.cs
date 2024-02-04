//using Microsoft.EntityFrameworkCore;

//Console.WriteLine();

//// Seed datalar migrationların dışlında eklenmesi ve değiştirilmesi beklenmeyen durumlar için kullanılan bir özelliktir

//#region Data Seeding nedir?

//// EF Core ile inşa edilen veritabanı içerisinde veritabanı nesneleri olabileceği gibi verlerinde migrate sürecinde üretilmesini isteyebiliriz

//// Bu ihtiyaca istinaden Seed Data özelliği ile EF Core üzerinden migration'larda veriler oluşturabilir ve migrate ederken bu verileri hedef tablolarımıza basabiliriz


//// Seed Data'lar migrate süreçlerinde hazır verileri tablolara basabilmek için bunları yazılım kısmında tutmamızı gerektirmektedirler. Böylece bu veriler üzerinde veritabanı seviyesinde istenilen manipülasyonlar gerçekleştirebilmektedir.

//// Data Seeding özelliği şu noktalarda kullanılabilir
//// Test için geçici verilere ihtiyaç varsa
//// ASP.NEt Core'daki Identity yapılanmasındaki roller gibi static değerlerde tutulabilir
//// Yazılım için temel konfigürasyonel değerler


//#endregion

//#region Seed Data Ekleme


//// OnModelCreating metodu içerisinde Entity fonksiyonundna sonra çağrılan HasData fonksiyonu ilgili entity'e karşılık SeedData'ları eklememizi sağlayan bir fonksiyondur

//// PK değerlerinin manuel olarak bildirilmesi gerekmektedir. Nedeni, ilişkisel verileri de Seed Datalarla üretebilmek için 

//#endregion

//#region İlişkisel Tablolar için Seed Data Ekleme

//// İlişkiler senaryolarda dependent table'a veri eklerken foreign key kolonunun proeprtysi varsa eğer ona ilişkisi değerini vererek ekleme işlemini yapıyoruz

//#endregion

//#region Seed Data'nın Primary Key'ini değiştirme
//// Eğer ki migrat edilen herhangi bir seed datanın sonrasında PK'i değiştirilirse bu datayla varsa ilişkisel başka veriler onlara cascade davranışı sergilenecektir
//#endregion

//#region

//#endregion

//class Post
//{
//    public int Id { get; set; }

//    public int BlogId { get; set; }
//    public string Title { get; set; }
//    public string Content { get; set; }
//    public Blog Blog { get; set; }
//}

//class Blog
//{
//    public int Id { get; set; }
//    public string Url { get; set; }
//    public ICollection<Post> Posts { get; set; }
//}

//class ApplicationDbContext : DbContext
//{

//    public DbSet<Post> Posts { get; set; }
//    public DbSet<Blog> Blogs { get; set; }
//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    {
//        optionsBuilder.UseSqlServer("Server=LAPTOP-EFPS8KL8; Database=SeedData;User Id=LAPTOP-EFPS8KL8\\huawei;Trusted_Connection=True");
//    }

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {

//        // PK değerlerinin manuel olarak bildirilmesi gerekmektedir

//        modelBuilder.Entity<Blog>().HasData(
//            new Blog()
//            {
//                Id = 1,
//                Url = "www.gncyldz.com",
//            },
//            new Blog()
//            {
//                Id = 2,
//                Url = "www.rnytpl.com",
//            }
//            );

//        modelBuilder.Entity<Post>().HasData(
//            new Post()
//            {
//                Id = 1,
//                BlogId = 1,
//                Title = "A",
//                Content = "...."
//            },
//            new Post()
//            {
//                Id = 2,
//                BlogId = 2,
//                Title = "B",
//                Content = "...."
//            }
//            );
//    }
//}