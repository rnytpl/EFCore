﻿using Microsoft.EntityFrameworkCore;

//Console.WriteLine("damn");

//ApplicationDbContext context = new();


#region One To One ilişkisel senaryolarda veri silme

//Person? person = await context.Persons
//    .Include(p => p.Address)
//    .FirstOrDefaultAsync(p => p.Id == 1);

//if (person != null) context.Addresses.Remove(person.Address);
//await context.SaveChangesAsync();

#endregion

#region One To Many ilişkisel senaryolarda veri silme

//Blog? blog = await context.Blogs.Include(b => b.Posts).FirstOrDefaultAsync(b => b.Id == 1);

//Post post = blog.Posts.FirstOrDefault(p => p.Id == 2);

//context.Posts.Remove(post);

//await context.SaveChangesAsync();

#endregion

#region Many to Many ilişkisel senaryolarda veri silme

//Book? book = await context.Books.Include(b => b.Authors).FirstOrDefaultAsync(b => b.Id == 1);

//Author? author = book?.Authors.FirstOrDefault(a => a.Id == 2);

// Bu yazarı silmeye kalkar
//context.Authors.Remove(author);

//book.Authors.Remove(author);
//await context.SaveChangesAsync();

#endregion

#region Cascade Delete
//Bu davranış modelleri Fluent API ile konfigüre edilebilmektedir.
#region Cascade
//Esas tablodan silinen veriyle karşı/bağımlı tabloda bulunan ilişkili verilerin silinmesini sağlar.
#endregion

#region SetNull
//Esas tablodan silinen veriyle karşı/bağımlı tabloda bulunan ilişkili verilere null değerin atanmasını sağlar.

//One to One senaryolarda eğer ki Foreign key ve Primary key kolonları aynı ise o zaman SetNull davranuışını KULLANAMAYIZ!
#endregion

#region Restrict
//Esas tablodan herhangi bir veri silinmeye çalışıldığında o veriye karşılık dependent table'da ilişkisel veri/ler varsa eğer bu sefer bu silme işlemini engellemesini sağlar.
#endregion

#endregion

#region Saving Data

//Person person = new()
//{
//    Name = "Gençay",
//    Address = new()
//    {
//        PersonAddress = "Yenimahalle/ANKARA"
//    }
//};

//Person person2 = new()
//{
//    Name = "Hilmi",
//    Address = new()
//    {
//        PersonAddress = "İdealtepe/İstanbul",
//    }
//};

//await context.AddAsync(person);
//await context.AddAsync(person2);

//Blog blog = new()
//{
//    Name = "Gencayyildiz.com Blog",
//    Posts = new List<Post>
//    {
//        new(){ Title = "1. Post" },
//        new(){ Title = "2. Post" },
//        new(){ Title = "3. Post" },
//    }
//};

//await context.Blogs.AddAsync(blog);

//Book book1 = new() { BookName = "1. Kitap" };
//Book book2 = new() { BookName = "2. Kitap" };
//Book book3 = new() { BookName = "3. Kitap" };

//Author author1 = new() { AuthorName = "1. Yazar" };
//Author author2 = new() { AuthorName = "2. Yazar" };
//Author author3 = new() { AuthorName = "3. Yazar" };

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

//class Blog
//{
//    // In case we try to access an instance property of this entity
//    // We've to initialize a collection of Hashset of Post type in entity's constructor
//    // So that we don't encounter a null reference exception error

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
//    public string Title { get; set; }
//    public Blog Blog { get; set; }
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

//class ApplicationDbContext : DbContext
//{

//    public DbSet<Person> Persons { get; set; }
//    public DbSet<Address> Addresses { get; set; }
//    public DbSet<Blog> Blogs { get; set; }
//    public DbSet<Post> Posts { get; set; }
//    public DbSet<Author> Authors { get; set; }
//    public DbSet<Book> Books { get; set; }


//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    {
//        optionsBuilder.UseSqlServer("Server=LAPTOP-EFPS8KL8; Database=DeletingRelatedData; User Id=LAPTOP-EFPS8KL8\\huawei;Trusted_Connection=True");
//    }
//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<Address>().HasKey(p => p.Id);

//        modelBuilder.Entity<Person>().HasOne(p => p.Address).WithOne(a => a.Person).HasForeignKey<Address>(p => p.Id).OnDelete(DeleteBehavior.Cascade);

//        modelBuilder.Entity<Blog>().HasMany(b => b.Posts).WithOne(p => p.Blog).OnDelete(DeleteBehavior.Cascade).IsRequired(false);

//        modelBuilder.Entity<Author>().HasMany(a => a.Books).WithMany(b => b.Authors);
//    }
//}