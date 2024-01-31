//using Microsoft.EntityFrameworkCore;

//Console.WriteLine("damn");

//ApplicationDbContext context = new();

#region One to One İlişkisel Senaryolarda Veri Güncelleme

#region 1. Durum Esas tablodaki veriye bağımlı veriyi değiştirme

//Person? person = await context.Persons.Include(p => p.Address).FirstOrDefaultAsync(p => p.Id == 1);

//context.Addresses.Remove(person.Address);
//person.Address = new Address() { PersonAddress = "Küçükyalı" };

//await context.SaveChangesAsync();

//Address adres = new Address()
//{
//    PersonAddress = "Eraykent Sitesi",
//    Person = new Person()
//    {
//        Name = "Hilmi"
//    }
//};

//Person person = new Person()
//{
//    Name = "Rny"
//};

//Person person1 = new Person()0
//{
//    Name = "Gençay"
//};

//await context.Persons.AddAsync(person);
//await context.Addresses.AddAsync(adres);
//await context.SaveChangesAsync();

#endregion

#region 2. Durum - Bağımlı verinin ilişkisel olduğu ana veriyi güncelleme

//Address adres = await context.Addresses.FindAsync(1);
//context.Addresses.Remove(adres);
//await context.SaveChangesAsync();

//Person? person = await context.Persons.FindAsync(1);
//adres.Person = person;
//await context.SaveChangesAsync();

//adres.Person = new()
//{
//    Name = "Cani"
//};

#endregion

#endregion

#region One To Many ilişkisel senaryolarda veri güncelleme

#region Saving

//Blog blog = new()
//{
//    Name = "rnytpl.com",
//    Posts = new HashSet<Post>()
//    {
//        new Post() { Title = "1. post"},
//        new Post() { Title = "2. post"},
//        new Post() { Title = "3. post"},

//    },
//};

//await context.Blogs.AddAsync(blog);
//await context.SaveChangesAsync();

//Post post = new()
//{
//    Title = "My Post",
//};

//blog.Posts.Add(post);



#endregion

#region 1. Durum Esas tablodaki veriye bağımlı veriyi değiştirme

//Blog? blog = await context.Blogs.Include(b => b.Posts).FirstOrDefaultAsync(b => b.Id == 10);

//Post? silinecekPost = blog.Posts.FirstOrDefault(p => p.Id == 3);

//blog.Posts.Remove(silinecekPost);
//blog.Posts.Add(new() { Title = "4. Post"});
//blog.Posts.Add(new() { Title = "5. Post" });

//await context.SaveChangesAsync();

//#endregion

//#region 2. Durum Bağımlı verinn ilişkisel olduğu ana veriyi güncelleme

//Post? post = await context.Posts.FindAsync(4);

//post.Blog = new()
//{
//    Name = "6. Blog",
//};

//await context.SaveChangesAsync();

#endregion

#endregion

#region Many To Many İlişkisel Senaryolarda Veri Güncelleme

#region Saving

//Book book1 = new Book() { BookName = "Book 1" };
//Book book2 = new Book() { BookName = "Book 2" };
//Book book3 = new Book() { BookName = "Book 3" };

//Author author1 = new Author() { AuthorName = "Author 1"};
//Author author2 = new Author() { AuthorName = "Author 2" };
//Author author3 = new Author() { AuthorName = "Author 3" };

//book1.Authors.Add(author1);
//book1.Authors.Add(author2);

//book2.Authors.Add(author1);
//book2.Authors.Add(author2);
//book2.Authors.Add(author3);

//book3.Authors.Add(author3);

//await context.AddAsync(book1);
//await context.AddAsync(book2);
//await context.AddAsync(book3);
//await context.SaveChangesAsync();

#endregion

#region 1. Örnek 

//Book? book = await context.Books.FindAsync(1);
//Author? author = await context.Authors.FindAsync(3);

//book.Authors.Add(author);

//await context.SaveChangesAsync();

#endregion

#region 2. Örnek

//Author? author = await context.Authors.Include(a => a.Books).FirstOrDefaultAsync(a => a.Id == 3);

//foreach (var book in author.Books)
//{
//    if (book.Id != 1) author.Books.Remove(book);
//}

//await context.SaveChangesAsync();

#endregion

#region 3. Örnek

//Book? book = await context.Books.Include(b => b.Authors).FirstOrDefaultAsync(b => b.Id == 2);

//Author silinecekyazar = book.Authors.FirstOrDefault(a => a.Id == 1);
//book.Authors.Remove(silinecekyazar);

//Author author = await context.Authors.FindAsync(3);
//book.Authors.Add(author);
//book.Authors.Add(new() { AuthorName = "4. Yazar" });

//await context.SaveChangesAsync();

#endregion

#endregion


// Dependent Entity
//class Person
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//    public Address Address { get; set; }
//}

//// Principal Entity
//class Address
//{
//    public int Id { get; set; }
//    public string PersonAddress { get; set; }
//    public Person Person { get; set; }

//}
//class Blog
//{
//    public Blog()
//    {
//        Posts = new HashSet<Post>();
//    }
//    public int Id { get; set; }
//    public string Name { get; set; }
//    public ICollection<Post> Posts { get; set; }


//}

//// Dependent
//class Post
//{
//    public int Id { get; set; }
//    //public int BlogId { get; set; }
//    public string Title { get; set; }
//    public Blog Blog { get; set; }

//}

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
//    public DbSet<Person> Persons { get; set; }
//    public DbSet<Address> Addresses { get; set; }
//    public DbSet<Blog> Blogs { get; set; }
//    public DbSet<Post> Posts { get; set; }
//    public DbSet<Book> Books { get; set; }
//    public DbSet<Author> Authors { get; set; }
//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    {
//        optionsBuilder.UseSqlServer("Server=LAPTOP-EFPS8KL8; Database=UpdatingRelatedData;User Id=LAPTOP-EFPS8KL8\\huawei;Trusted_Connection=True");
//    }
//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<Address>().HasOne(a => a.Person).WithOne(p => p.Address).HasForeignKey<Address>(a => a.Id);

//        modelBuilder.Entity<Blog>().HasMany(b => b.Posts).WithOne(p => p.Blog);
//    }
//}