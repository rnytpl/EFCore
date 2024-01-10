using Example;
using Microsoft.EntityFrameworkCore;


ETicaretContext context = new();

#region Basic Query
#endregion

#region Method Syntax

//var urunler = await context.Products.ToListAsync();

#endregion

#region Query Syntax

//var urunler1 = await (from urun in context.Products 
//    select urun).ToListAsync();

#endregion

#region Foreach Query

//var urunId = new Guid();

//var urunler2 = from urun in context.Products
//               where urun.Id == urunId
//               select urun;

//foreach (var urun in urunler2)
//{
//    Console.WriteLine(urun.ProductName);
//}

#endregion

#region Deferred Execution


#endregion

#region IQueryable and IEnumerable



#endregion

#region IQueryable
// Sorguya karşılık gelir
// EF Core üzerinden yapılmış olajn sorgunun execute edilmemişl halini ifade eder
#endregion

#region IEnumerable
// Sorgunun çalıştırılıp/execute edilip verilerin in memory'e yüklenmiş halini ifade eder
#endregion

#region ToListAsync
// Üretilen sorguyu execute ettirmemizi sağlayan fonksiyondur

#endregion

#region Query Syntax


//var urunler = (from urun in context.Products
//               select urun).ToListAsync();

#endregion

#region Where
// Oluşturulan sorgulaya where şartı eklememizi sağlayan bir fonksiyontur

// QUery is made but not executed
//var productsQuery = context.Products.Where(u => u.ProductName == "Keyboard");

// Now query is executed
//var productsExecuteQuery = await productsQuery.ToListAsync();

// Method Syntax
// Query is made but not executed
//var productsQuery = (from urun in context.Products
//                     where urun.ProductName.StartsWith("Razor") || urun.ProductName == "Razor"
//                     select urun
//                     );

//List<Product> productsExecuteQuery = await productsQuery.ToListAsync();

#endregion

#region OrderBy

// Method Syntax
//var urunler = context.Products.Where(u => u.ProductName == "Razor" || u.ProductName.EndsWith("5")).OrderBy(u => u.ProductName).FirstOrDefault();

//var urunler2 = from urun in context.Products
//               where urun.ProductName == "Logitech" || urun.ProductName.StartsWith("Logitech")
//               orderby urun.ProductName descending
//               select urun
//               ;

//IEnumerable<Product> executeUrunlerQuery = await urunler2.ToListAsync();


#endregion

#region Thenby

// OrderBy üzerinde yapılan sıralama işlemini farklı kolonlarada uygulamamızı sağlayan bir fonksiyondur (Ascending)

//var urunlerMethod = context.Products.Where(u => u.ProductName == "Razor" || u.ProductName.EndsWith("A")).OrderBy(u => u.ProductName).ThenBy(u => u.Price);

//var urunlerQuery = from urun in context.Products
//                   where urun.ProductName == "Razor" || urun.ProductName.EndsWith("Logitech")
//                   orderby urun.ProductName ascending
//                   select urun;

#endregion

#region OrderByDescending

// Method Syntax

//var urunler = await context.Products.OrderByDescending(u => u.Price).ToListAsync();

//// Query Syntax

//var products = await (from urun in context.Products
//                      orderby urun.Price descending
//                      select urun).ToListAsync();

#endregion

#region ThenByDescending

//var urunler = await context.Products.OrderByDescending(u => u.Price).ThenByDescending(u => u.ProductName).ToListAsync();

#endregion

#region Tekil Veri Getiren Sorgulama Fonksiyonları

// Yapılan sorguda sadece ve sadece tek bir verinin gelmesi amaçlanıyorsa Single yada SingleOrDefault fonksiyonları kullanılabilir

#region Single Async

// Eğer ki sorgu neticesinde birden fazla veri geliyorsa yada hiç gelmiyorsa her iki durumda da exception fırlatır
#region Tek Kayıt Geldiğinde

//var tekUrun = await context.Products.SingleAsync(u => u.Id == Guid.Parse("a32cfff1-3a07-43ea-1aba-08dc0cebb7f8"));

#endregion

#region Hiç Kayıt Gelmediğinde

//// This returns null  and an exception error is thrown
//var noUrun = await context.Products.SingleAsync(u => u.Price <= 5);

#endregion

#region Çok kayıt geldiğinde

//var multipleUrun = await context.Products.SingleAsync(urun => urun.Price >= 5);

#endregion


#endregion

#region SingleOrDefaultAsync

// Eğer ki sorgu neticesinde birden fazla veri geliyorsa yada hiç gelmiyorsa her iki durumda da exception fırlatır
#region Tek Kayıt Geldiğinde

//var tekUrun = await context.Products.SingleOrDefaultAsync
//    (u => u.Id == Guid.Parse("a32cfff1-3a07-43ea-1aba-08dc0cebb7f8"));

#endregion

#region Hiç Kayıt Gelmediğinde

// This returns null and no exception error is thrown
//var noUrun = await context.Products.SingleOrDefaultAsync(u => u.Price <= 5);

#endregion

#region Çok kayıt geldiğinde
// This returns multiple entities and throws an exception error
//var multipleUrun = await context.Products.SingleOrDefaultAsync(urun => urun.Price >= 5);

#endregion

#endregion

#region FirstAsync

// Sorgul neticesinde elde edilen verilerden ilkini getirir. Eğer ki hiç veri gelmiyorsa hata fırlatır

//var urun1 = await context.Products.FirstAsync(u => u.ProductName.StartsWith("Asus"));

// If there are multiple results, first one is retrieved and returned as result
//var urun = await context.Products.FirstAsync(urun => urun.Price < 200);

//Console.WriteLine(urun.ProductName);

#endregion

#region FirstOrDefaultAsync
// Sorgu neticesinde elde edilen verilerden ilkini getirir, eğerki hiç veri gelmiyorsa null değerini dönrürür

//var urun = await context.Products.FirstOrDefaultAsync(u => u.Price >= 200);
//Console.WriteLine(urun.Price);

// If multiple entities are returned, first one is retrieved and returned as result
//var urun = await context.Products.FirstOrDefaultAsync(u => u.Price > 1);
//Console.WriteLine(urun.ProductName);

// If no matching results, null is returned and exception error is not thrown
//var urun = await context.Products.Where(u => u.ProductName == "Asus").FirstOrDefaultAsync();
//Console.WriteLine(urun.ProductName);

#endregion

#endregion

//////////////////////////////////////////////////////////


#region FindAsync
// Find fonksiyonu, primary key kolonuna özel hızlı ir şekilde sorgulama yapmamızı sağlayan bir fonksiyondur.
// Sonuç bulunmazsa 
//Product urun = await context.Products.FindAsync(Guid.Parse("e6ee4b0e-ab12-4917-81a1-08dc1185e21b"));

//


#endregion

#region LastAsync

// Sorgu neticesinde gelen verilerden en sonuncusunu getirir. OrderBy kullanılması mecburidir
// SOrgu neticesinde hiç veri gelmiyorsa hata fırlatır
//var urun = await context.Products.OrderByDescending(u => u.Price).LastAsync(u => u.Price > 1);
//Console.WriteLine(urun.Price);
#endregion

#region LastOrDefaultAsync
// Sorgu neticesinde gelen verilerden en sonuncusunu getirir. OrderBy kullanılması mecburidir
// Null döndürür
//var urun = await context.Products.OrderByDescending(u => u.Price).LastAsync(u => u.Price > 1);
//Console.WriteLine(urun.Price);

#endregion

#region CountAsync

// Oluşturulan sorgunun execute edilmesi neticesinde kaç adet satırın elde edileceğini sayısal olarak bizlere bildiren fonksiyondur

//var urunler = (await context.Products.ToListAsync()).Count();

//var urun1 = await context.Products.CountAsync();

//var urun2 = await context.Products.CountAsync(urun => urun.Price < 200);

#endregion

#region AnyAsync
// Sorgu neticesinde verinin gelip gelmediğini bool türünde dönen fonksiyondur
//var urunler = await context.Products.AnyAsync();

#endregion

#region AllAsync

// Bir sorgu neticesinde gelen verilerin verilen şarta uyup uymadığını kontrol etmektedir. Eğer ki tüm veriler şarta uyuyorsa true uymuyorsa false döndürecektir.

//var m = context.Products.AllAsync(u => u.Price > 500);

#endregion

#region SumAsync
// Vermiş olduğumuz sayısal property'nin toplamını alır
//var fiyatToplam = await context.Products.SumAsync(u => u.Price);
//Console.WriteLine(fiyatToplam);
#endregion 

#region AverageAsync
// Vermiş olduğumuz sayısal property'nin aritmetik ortalamasını alır
//var fiyatOrtalama = await context.Products.AverageAsync(u => u.Price);
//Console.WriteLine(fiyatOrtalama);
#endregion

#region ContainsAsync
// Linq sorgusu oluşturmamızı sağlar
//var urunler = await context.Products.Where(u => u.ProductName.Contains("7")).ToListAsync();
#endregion

#region StartsWith
// Like sorgusu oluşturmamızı sağlar
//var urunler = await context.Products.Where(u => u.ProductName.StartsWith("R")).ToListAsync();
#endregion

#region EndsWith

//var urunler = await context.Products.Where(u => u.ProductName.EndsWith("R")).ToListAsync();

#endregion

//////////////////////////////////////////////////////////

#region Sorgu Sonucu Dönüşüm Fonksiyonları
// Bu fonksiyonlar ile sorgu neticesinde elde edilen verileri isteğimiz doğrultusunda farklı türlerde projeksiyon edebiliyoruz.

#region ToDictionaryASync

// Sorgu neticesinde gelecek olan veriyi bir Dictionary olarak elde etmek/karşılamak istediğimizde kullanılır
// ToList gibi oluşturulan sorguyu execute edip neticesini alır
// ToList gelen sorgu sonucunu entity türünde bir koleksiyonda List<Entity> dönüştürürken, ToDictionary ise gelen sorgu sonucunu Dictionary türünden bir koleksiyona dönüştürür
//var urunler = await context.Products.ToDictionaryAsync(u => u.ProductName, u => u.Price);

#endregion


#region ToArrayAsync
// Oluşturulan sorguyu dizi olarak elde eder
// ToList ile aynı amaca hizmet eder, yani sorguyu execute eder, lakin gelen sonucu entity dizisi olarak elde eder

//var urunler = await context.Products.ToArrayAsync();

#endregion

#region Select
// Select fonksiyonunun işlevsel olarak birden fazla davranışı söz konusudur.
// Select fonksiyonu generate edilecek sorgunun çekilecek kolonlarını ayarlamamızı sağlamaktadır.
// Method 1 If the type of returned result is given to select, all but targeted fields will contain a null value which is extra space in memory
var urunler = await context.Products.Select(u => new Product { Id = u.Id, Price = u.Price }).ToListAsync();
//Method 2 Anonym Type, code is more optimized if we don't give a corresponding type to returned results
// This fields, other fields in that instance if any exists won't contain any value but only expected fields
var urunler1 = await context.Products.Select(u => new { Id = u.Id, Price = u.Price}).ToListAsync();
Console.WriteLine("Damn");
#endregion

#region SelectMany

#endregion

#endregion