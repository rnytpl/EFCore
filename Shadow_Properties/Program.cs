//using Microsoft.EntityFrameworkCore;
//using System.Reflection.Emit;

//ApplicationDbContext context = new();

//#region - Shadow Properties

//// Entity sınıflarında fiizksel olarak taınmlanmayan ancak EF Core tarafından ilgili entity için var olan var olduğu kabul edilen property'lerdir.

//// Genellikle tabloda gösterilmesini istemediğimiz entity instance'ı üzerinde işlem yapmayacağımız kolonlar için kullanılır

//// Shadow propertylerin değerleri ve stateleri ChangeTracker tarafından kontrol edilir

//#endregion
//#region Foreign Key - Shadow Properties

//// İlişkisel senaryolarda foreign key property'sini tanımlamadığımız halde EF Core tarafından dependent entity'e eklenmektedir. İşte bu shadow property'dir


////var blogs = await context.Blogs.Include(b => b.Posts).ToListAsync();

////Console.WriteLine("damn");

//#endregion

//#region Shadow Property Oluşturma

//// Bir entity üzerinde shadow property oluşturmak istiyorsanız eğer FLuent API'ı kullanmanız gerekmektedir

////modelBuilder.Entity<Blog>()
////            .Property<DateTime>("createdDate");

//#endregion

//#region  Shadow Property'e erişim sağlama


//#region ChangeTracker ile Erişim

//// Shadow property'e erişims ağlayabilmek için changetracker'dan istifade edilebilir

////var blog = await context.Blogs.FirstAsync();

////var createdDate = context.Entry(blog).Property("createdDate");

////Console.WriteLine(createdDate.CurrentValue);
////createdDate.CurrentValue = DateTime.Now;
////await context.SaveChangesAsync();
//#endregion

//#region EF Property ile erişim

//// Özellikle Linq sorgularında shadow property'lerine erişim için ef property statik yapılanmasını kıullanabiliriz

//var blogss = await context.Blogs.OrderBy(b => EF.Property<DateTime>(b, "createdDate")).ToListAsync();

//var blog1 = await context.Blogs.Where(b => EF.Property<DateTime>(b, "createdDate").Year > 2020).ToListAsync();

//blog1.ForEach(b => Console.WriteLine(b.Name));

//#endregion

//#endregion

//class Blog
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//    public ICollection<Post> Posts { get; set; }
//}

//class Post
//{
//    public int Id { get; set; }
//    public string Title { get; set; }
//    public bool lastUpdated { get; set; }
//    public Blog Blog { get; set; }
//}

//class ApplicationDbContext : DbContext
//{

//    public DbSet<Blog> Blogs { get; set; }
//    public DbSet<Post> Posts { get; set; }
//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    {
//        optionsBuilder.UseSqlServer("Server=LAPTOP-EFPS8KL8; Database=ShadowProperties;User Id=LAPTOP-EFPS8KL8\\huawei;Trusted_Connection=True");
//    }

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<Blog>()
//            .Property<DateTime>("createdDate");
//    }
//}