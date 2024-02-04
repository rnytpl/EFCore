using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

//Console.WriteLine("Damn");

//ApplicationDbContext context = new();

#region One To One İlişkisel Senaryolarda Veri Ekleme
//Eğer ki principal entity üzerinden ekleme gerçekleştiriliyorsa dependent entity nesnesi verilmek zorunda değildir! Amma velakin, dependent entity üzerinden ekleme işlemi gerçekleştiriliyorsa eğer burada principal entitynin nesnesine ihtiyacımız zaruridir.
//#region 1st Method -> Principal Entity üzerinden dependent Entity Verisi Ekleme

//Person person = new();
//person.Name = "Gençay";
//person.Address = new()
//{
//    PersonAddress = "Yenimahalle/Ankara"
//};
//await context.AddAsync(person);
//await context.SaveChangesAsync();

//var findPerson = await context.Persons.Include(p => p.Address).FirstOrDefaultAsync(p => p.Id == 2);

//findPerson.Address.PersonAddress = "Gebze/İstanbul";

//await context.SaveChangesAsync();

#endregion

#region 2nd Method -> Dependent Entity üzerinden Principal Entity Verisi Ekleme

//Address adres = new Address
//{
//PersonAddress = "İdealtepe/İstanbul",
//Person = new()
//{
//Name = "Turgay",
//}
//};

//await context.AddAsync(adres);
//await context.SaveChangesAsync();

//adres.PersonAddress = "İdealtepe/İstanbul";



//class Person
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//    public Address Address { get; set; }
//}

//class Address
//{
//    public int Id { get; set; }
//    public string PersonAddress { get; set; }
//    public Person Person { get; set; }

//}

//class ApplicationDbContext : DbContext
//{
//    public DbSet<Person> Persons { get; set; }
//    public DbSet<Address> Address { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    {
//        optionsBuilder.UseSqlServer("Server=LAPTOP-EFPS8KL8; Database=SavingRelatedData;User Id=LAPTOP-EFPS8KL8\\huawei;Trusted_Connection=True");
//    }

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {

//        modelBuilder.Entity<Person>().HasOne(p => p.Address).WithOne(a => a.Person).HasForeignKey<Address>(a => a.Id);
//    }

//}

#endregion

#region One to Many İlişkisel Senaryolarda Veri Ekleme
#region 1. Yöntem -> Principal Entity üzerinden Dependent Entity Verisi Ekleme

#region Nesne referansı üzerinden ekleme

//Blog blog = new()
//{
//    Name = "gencayyildiz.com",
//};

//blog.Posts.Add(new Post() { Title = "Post 1" });
//blog.Posts.Add(new Post() { Title = "Post 2" });
//blog.Posts.Add(new Post() { Title = "Post 3" });

//await context.Posts.AddRangeAsync(
//    new Post() { Title = "Post 1" },
//    new Post() { Title = "Post 2" },
//    new Post() { Title = "Post 3" });

//await context.AddAsync(blog);

#endregion

#region Object Initializer üzerinden ekleme

//Blog blog1 = new()
//{
//    Name = "rnytpl.com",
//    Posts = new HashSet<Post>()
//    {
//        new Post() { Title = "Post 4"},
//        new Post() { Title = "Post 5"},
//        new Post() { Title = "Post 6"},
//    },
//};

#endregion

//await context.SaveChangesAsync();


#endregion

#region 2. Yöntem -> Dependent Entity üzeribden Principal Entity Verisi EKleme

//Post post1 = new()
//{
//    Title = "Post 6",
//    Blog = new Blog() { Name = "cmylmz", }
//};

//await context.AddAsync(post1);

#endregion

#region 3. Yöntem -> Foreign Key kolonu üzerinden veri ekleme

// 1. ve 2. yöntemler hiç olmayan verilerin ilişkisel olarak eklenmesini sağlarken, 3. yöntem önceden eklenmiş olan bir principal entity verisiyle dependent entitylerin eşleştirilmesini sağlamaktadır

//Post post3 = new()
//{
//    Title = "Post 7",
//    BlogId = 1,
//};

#endregion
//class Blog
//{
//    // We've to initialize a HashSet collection of Post type inside Blog entity's constructor
//    // Otherwise when an object member of Blog is null and accessed, you will encounter null reference exception error
//    public Blog()
//    {
//        Posts = new HashSet<Post>();
//    }
//    public int Id { get; set; }
//    public string Name { get; set; }
//    public ICollection<Post> Posts { get; set; }

//}

//class Post
//{
//    public int Id { get; set; }
//    public int BlogId { get; set; }
//    public string Title { get; set; }
//    public Blog Blog { get; set; }
//}

//class ApplicationDbContext : DbContext
//{
//    public DbSet<Blog> Blogs { get; set; }
//    public DbSet<Post> Posts { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    {
//        optionsBuilder.UseSqlServer("Server=LAPTOP-EFPS8KL8; Database=SavingRelatedDataManyToMany;User Id=LAPTOP-EFPS8KL8\\huawei;Trusted_Connection=True");
//    }

//    //protected override void OnModelCreating(ModelBuilder modelBuilder)
//    //{
//    //    modelBuilder.Entity<Blog>().HasMany(b => b.Posts).WithOne(p => p.Blog).HasForeignKey(p => p.BlogId);
//    //}

//}

#endregion

#region Many To Many İlişkisel Senaryolarda Veri Ekleme

#region 1. Yöntem

// n to n ilişkisi eğer ki default convention üzerinden tasarlanmışsa kullanılan bir yöntemdir

//Book book = new()
//{
//    BookName = "A Kitabı",
//    Authors = new HashSet<Author>() { new() { AuthorName = "Hilmi" } },
//};

//await context.Books.AddAsync(book);
//await context.SaveChangesAsync();

//class Book
//{
//    public Book()
//    {
//        Authors = new HashSet<Author>();
//    }
//    public int Id { get; set; }
//    public string BookName { get; set; }
//    public ICollection<Author> Authors { get; set; }
//}

//class Author
//{

//    public Author()
//    {
//        Books = new HashSet<Book>();
//    }
//    public int Id { get; set; }
//    public string AuthorName { get; set; }
//    public ICollection<Book> Books { get; set; }
//}

//class ApplicationDbContext : DbContext
//{
//    public DbSet<Book> Books { get; set; }
//    public DbSet<Author> Authors { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    {
//        optionsBuilder.UseSqlServer("Server=LAPTOP-EFPS8KL8; Database=SavingRelatedDataManyToMany;User Id=LAPTOP-EFPS8KL8\\huawei;Trusted_Connection=True");
//    }

//}


#endregion

#region 2. Yöntem

// n to n ilişkisi eğer ki fluent api ile tasarlanmışsa kullanılan bir yöntemdir

//Author author = new()
//{
//    AuthorName = "Author 2",
//    Books = new HashSet<BookAuthor>()
//    {
//        new () { Book = new() {BookName = "B Book"}}
//    },
//};

//await context.Authors.AddAsync(author);
//await context.SaveChangesAsync();

//class Book
//{
//    public int Id { get; set; }
//    public string BookName { get; set; }
//    public ICollection<BookAuthor> Authors { get; set; }
//}

//class BookAuthor
//{
//    public int BookId { get; set; }
//    public int AuthorId { get; set; }
//    public Book Book { get; set; }
//    public Author Author { get; set; }
//}

//class Author
//{
//    public int Id { get; set; }
//    public string AuthorName { get; set; }
//    public ICollection<BookAuthor> Books { get; set; }
//}

//class ApplicationDbContext : DbContext
//{
//    public DbSet<Book> Books { get; set; }
//    public DbSet<Author> Authors { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    {
//        optionsBuilder.UseSqlServer("Server=LAPTOP-EFPS8KL8; Database=SavingRelatedDataManyToMany;User Id=LAPTOP-EFPS8KL8\\huawei;Trusted_Connection=True");
//    }

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<BookAuthor>().HasKey(ba => new
//        {
//            ba.AuthorId,
//            ba.BookId
//        });

//        modelBuilder.Entity<BookAuthor>().HasOne(c => c.Book).WithMany(a => a.Authors).HasForeignKey(ba => ba.BookId);
//        modelBuilder.Entity<BookAuthor>().HasOne(a => a.Author).WithMany(a => a.Books).HasForeignKey(ba => ba.AuthorId);
//    }

//}

#endregion

#endregion


