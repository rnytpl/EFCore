using Example;
using Microsoft.EntityFrameworkCore;

#region
ETicaretContext context = new();

//Console.WriteLine("hello");

//Product product = new Product()
//{
//    ProductName = "Razor Keyboard",
//    Price = 10,
//};

//Product product1 = new Product()
//{
//    ProductName = "Logitech Prodigy 3300",
//    Price = 200,
//};

//Product product3 = new Product()
//{
//    ProductName = "Asus ROG 16.6 4090RTX",
//    Price = 200,
//};

//User user1 = new User()
//{
//    Name = "User 1",
//    LastName = "TPL",
//    Email = "user1@gmail.com"
//};

//User user2 = new User()
//{
//    Name = "User 1",
//    LastName = "TPL",
//    Email = "user2@gmail.com"
//};
//User user3 = new User()
//{
//    Name = "User 3",
//    LastName = "TPL1",
//    Email = "user3@gmail.com"
//};
//User user4 = new User()
//{
//    Name = "User 4",
//    LastName = "TPL 4",
//    Email = "user4@gmail.com"
//};

 //Author author1 = new Author()
 //{
 //    Name = "A",
 //};

//await context.Users.AddRangeAsync(user1,user2,user3,user4);

//#region context.AddAsync

//await context.AddRangeAsync(product, product1);
//await context.SaveChangesAsync();

#endregion

#region context.DbSet.AddAsync

//await context.Products.AddAsync(product);

#endregion

#region context.SaveChangesAsync()

// SaveChanges is a function to make Insert, update, delete queries and send to database along with a transaction and execute it. If any of the queries should fail, it rolls back all the transactions.

//await context.SaveChangesAsync();

#endregion

////////////////// Update

#region How to update an entity

//Product urun = context.Products.FirstOrDefault(u => u.Id == Guid.Parse("a32cfff1-3a07-43ea-1aba-08dc0cebb7f8"));

//urun.ProductName = "Razor Threadder";
//urun.Price = 59;

//await context.SaveChangesAsync();

//Guid newId = Guid.NewGuid();

//Product urun1 = new Product()
//{
//    Id = Guid.Parse("a32cfff1-3a07-43ea-1aba-08dc0cebb7f8"),
//    ProductName = "Logitect Prodigy 3300 Gaming Keyboard",
//    Price = 5
//};

//context.Products.Update(urun1);
//context.SaveChanges();


#endregion

#region Change Tracker

// Change tracker context üzerinden gelen verilerin takibindne sorumlu bir mekanızmadır. 
// Bu takip mekanizması sayesinde context üzerinde verilerle ilgil işlemler neticesinde update yahut delete sorgularının oluşturulacağı anlaşılır.

#endregion

#region Entity State

// Bir entity örneğinin durumunu ifade eden bir referanstır

//Product u = new();

//Console.WriteLine(context.Entry(u).State);

#endregion

#region Remove, RemoveRange

//Product urun1 = new Product()
//{
//    ProductName = "Casio Men Watch",
//    Price = 29,
//};

//Product urun2 = new Product()
//{
//    ProductName = "Timberland Winter Shoes",
//    Price = 329,
//};

//await context.Products.AddRangeAsync(urun1, urun2);
//await context.SaveChangesAsync();

//context.Products.RemoveRange(urun1, urun2);

//List<Product> products = await context.Products.Where(u => u.Id >= Guid.Parse("lşksdflşsdlşfksdlkfklsdfklsdklfş") && u.Id <= Guid.Parse("a32cfff1-3a07-43ea-1aba-08dc0cebb7f8").ToListAsync();






#endregion

#region EF Core Açısından bir Verinin Güncellenmesi Gerektiği nasıl anlaşılıyor

//Product findProduct = await context.Products.FirstOrDefaultAsync(u => u.Id == Guid.Parse("a32cfff1-3a07-43ea-1aba-08dc0cebb7f8"));

//Console.WriteLine(context.Entry(findProduct).State);

//findProduct.Price = 200;

//Console.WriteLine(context.Entry(findProduct).State);

//await context.SaveChangesAsync();

//Console.WriteLine(context.Entry(findProduct).State);


#endregion
