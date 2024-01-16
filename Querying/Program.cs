using Example;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;


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

// Query is made but not executed
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

// Eğer ki sorgu neticesinde birden fazla veri geliyorsa exception fırlatır
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
//var urunler = await context.Products.Select(u => new Product { Id = u.Id, Price = u.Price }).ToListAsync();
//Method 2 Anonym Type, code is more optimized if we don't give a corresponding type to returned results
// This fields, other fields in that instance if any exists won't contain any value but only expected fields
//var urunler1 = await context.Products.Select(u => new { Id = u.Id, Price = u.Price}).ToListAsync();
Console.WriteLine("Damn");

#endregion

#region SelectMany
// Select ile aynı amaca hizmet eder, lakin ilişkisel tablolar neticesinde gelen koleksiyonel verileri de tekilleştirip projeksiyon etmemizi sağlar

//var urunler2 = await context.Products.Include(u => u.Parca).SelectMany(u => u.Parca, (u, p) => new
//{
//    u.Id,
//    u.Price,
//    p.ParcaAdi
//}).ToListAsync();
#endregion

#endregion

#region GroupBy Fonksiyonu

// Gruplama yapmamızı sağlayan fonksiyondur

// Method syntax

//var datas = await context.Products.GroupBy(u => u.Price).Select(group => new
//{
//    Count = group.Count(),
//    Fiyat = group.Key
//}).ToListAsync();
//Console.WriteLine();
// Query Syntax

//var data = (from urun in context.Products
//            group urun by urun.Price
//            into @group
//            select new
//            {
//                Count = @group.Count(),
//                Price = @group.Key
//            }
//            ).ToListAsync();

#endregion

#region ForEach fonksiypnu

//foreach (var item in datas)
//{

//}

//datas.ForEach(data =>
//{

//});

#endregion

#region ChangeTracker nedir

// Context nesnesi üzerinden gelen tüm nesneler/veriler otomatik olarak bir takip mekanizması tarafından izlenirler.
// İşte bu takip mekanızması CHangeTracker'dir.
// ChangeTracker ile nesneler üzerindeki değişiklikler/işlemler takip edilerek netice itibariyle bu işlemlerin fıtratına uygun sql sorgucukları generate edilir
// Bu işleme de ChangeTracking denir.

#endregion

#region ChangeTracker Property

// Takip edilen nesnelere erişebilmemizi sağlayan ve gerektiği takdirde işlemler gerçekleştirmemizi sağlayan bir property'dir.
// Context sınıfının base class'i olan DbContext sınıfının bir üyesidir

//var urunler = await context.Products.ToListAsync();

//var datas = context.ChangeTracker.Entries();

//Console.WriteLine();

#endregion

#region Detect Changes

// EF Core, context nesnesi tarafından izlenen tüm nesnelerdeki değişiklikleri change tracker sayesinde takip edebilmekte ve nesnelerde olan verisel değişiklikler yakalanarak bunların anlık görüntüleri(snapshot)ni oluşturabilir
// Yapılan değişiklerin veritabanına gönderilmeden önce algılandığından emin olmak gerekir. SaveChanges fonksiyonu çağrıldığı anda nesneler EF Core tarafından otomatik kontrol edilirler
// Ancak yapılan operasyonlarda güncel tracking verilerinden emin olabilmek için değişikliklerin algılanmasını opsiyonel olarak gerçekleştirmek isteyebiliriz.
// İşte bunun için detect changes fonksiyonu kullanılabilir ve her ne kadar ef core değişiklikleri otomatik olarak algılıyor olsada siz yine de kontrole zorlayabilirsiniz

//Product urun = await context.Products.FirstOrDefaultAsync(u => u.Id == new Guid()) ;
//urun.Price = 5;
//context.ChangeTracker.DetectChanges();
//await context.SaveChangesAsync();

#endregion

#region AutoDetectChangesEnabled Property

// İlgili metodlar (SaveChanges, Entries) tarafından DetectChanges metodunun otomatik olarak tetiklenmesinin konfigürasyonunu yapmamızı sağlayan property'dir
// SaveChanges fonksiyonu tetiklendiğinde DetectChanges metodunu içerisinde default olarak çağırmaktadır. Bu durumda DetechChanges fonksiyonunun kullanımını irademizle yönetmek ve maliyet/performans optimizasyonu yapmak istediğimiz drumlarda AutoDetectChagnesEnabled özelliğini kapatabiliriz.

#endregion

#region Entry Metod

// Context'teki Entry metodunun koleksiyonel versiyonudur

//Product urun = await context.Products.FirstOrDefaultAsync(u => u.Id == Guid.Parse("e6ee4b0e-ab12-4917-81a1-08dc1185e21b"));
//Console.Write(urun.Price);

//Console.WriteLine(context.Entry(urun).State);

//urun.Price = 549;

//Console.Write(urun.Price);

//Console.WriteLine(context.Entry(urun).State);

#endregion

#region Entries Metodu

// Context'te ki Entry metodun koleksiyonel versiyonudur
// ChangeTracker mekanizması tarafından izkenen her entity nesnesinin bilgisini EntittyEntry türünmden elde etmemizi sağlar ve belirli işlemler yapabilmemize olanak tanır
// Entries metodu DetectChanges metodunu tetikler
// Bu durum da tıpkı SaveChanges'da olduğu gibi bir maliyettir.
// Burada ki maliyetten kaçınmak için AutoDetectChangesEnabled özelliğine false değeri verilebilir

//var urunler = await context.Products.ToListAsync();
//urunler.FirstOrDefault(u => u.Id == Guid.Parse("e6ee4b0e-ab12-4917-81a1-08dc1185e21b")).Price = 123;
//context.Products.Remove(urunler.FirstOrDefault(u => u.Id == Guid.Parse("cca6d031-2791-48ef-81a0-08dc1185e21b")));

//context.ChangeTracker.Entries().ToList().ForEach(e =>
//{
//    if (e.State == EntityState.Unchanged)
//    {

//    } else if (e.State == EntityState.Deleted)
//    {

//    }
//}
//);

#endregion

#region AcceptAllChanges
// SaveChanges () veya SaveChanges(true) tetiklendiğinde EF Core herşeyin yolunda olduğunu varsayarak track ettiği verilerin takibini keser yani değişikliklerin takio edilmesini bekler. Byöyle bir durumda beklenmeyen bir durum olası bir hata söz konusu olursa eğer EF Core takipe ttiği nesneleri bırakacağı için bir düzeltme mevzu bahis olmayacaktır.
// haliyle bu durumda devreye SaveChagnes(false) ve AcceptAllChanges metotları girecektir.
// Bir hata sonucunda verilerin kayıt edilmesi başarısızlıkla sonuçlanırsa SaveChanges(false) kullanıldığı için CHangeTracker verilerin takibini bırakmaz.
// Hata olmaması ve değişikliklerin başarılı bir şekilde sonuçlanması halinde nesnelerin takibi hala devam edecektir ve takibin bırakılması gerekmektedir.
// Bu durumda takip mekanizmasını manuel olarak AccepAllChanges diyerek takipten çıkarız.


//Product urun = await context.Products.FirstOrDefaultAsync(u => u.Id == Guid.Parse("cca6d031-2791-48ef-81a0-08dc1185e21b"));

//urun.Price = 600;


//await context.SaveChangesAsync(false);
//context.ChangeTracker.AcceptAllChanges();

#endregion

#region HasChanges

// Takip edilen nesneler arasından depişiklik yapılanların olup olmadığının bilgisini verir.
// Arkaplanda DetectChanges metodunu tetikler

//var result = context.ChangeTracker.HasChanges();

#endregion

#region Entity States

// Entity nesnelerinin durumlarını ifade eder

// Detached - Nesnenin change tracker mekanizması trafından takip edilmediğini ifade eder

//Product urun = new();

//Console.WriteLine(context.Entry(urun).State);

// Added - Veritabanına eklenecek nesneyi temsil eder. Added henüz veritabanına işlenmeyen veiriy ifade eder. SaveChanges fonksiyonu çağrıldığında insert sorgusu oluşturalacağı anlamına gelir

//Product urun1 = new() { Price = 500, ProductName = "Honda HRV 2024"};

//Console.WriteLine(context.Entry(urun1).State);

//await context.Products.AddAsync(urun1);

//Console.WriteLine(context.Entry(urun1).State);

//await context.SaveChangesAsync();

// Unchanged -- Veritabanından sorgulandığından beri nesne üzerinde herhangi bir değişiklik yapılmadığını ifade eder. Sorgu neticesinde elde edilen tüm nesneler başlangıçta bu state'e sahiptir

//var urunler = await context.Products.ToListAsync();

// Modified -- Nesne üzerinden güncelleme yapıldığını ifade eder. SaveChanges fonksiyonu çaprıldığında update sorgusu oluşturulacağı anlamına gelir.

//Product findP = await context.Products.FirstOrDefaultAsync(u => u.Id == Guid.Parse("eb5372c8-68bf-4227-7234-08dc142211ff"));

//Console.WriteLine(context.Entry(findP).State);

//findP.ProductName = "Porsche Taycan S";

//Console.WriteLine(context.Entry(findP).State);

//await context.SaveChangesAsync();


// Deleted

//Guid newId = new Guid();

//Product newP = new()
//{
//    Id = newId,
//    Price = 1,
//    ProductName = "Doordash"
//};

//await context.Products.AddAsync(newP);
//await context.SaveChangesAsync();

//Console.WriteLine(context.Entry(newP).State);

//newP.ProductName = "Porsche Taycan S";

//context.Products.Remove(newP);


//Console.WriteLine(context.Entry(newP).State);

//await context.SaveChangesAsync();

#endregion





#region Context NEsnesi üzerinden CHangeTracker



#endregion

#region ChangeTracker'in Interceptor olarak kullanması



#endregion

#region AsNoTracking

// Context üzerindne gelen tüm datalar CHangeTracker mekanizması tarafından takip edilmektedir

// ChangeTracker takip ettiği nesnelerin sayısıyla doğru orantılı olacak şekilde bir maliyete sahiptir. O yüzden işlem yapılmayacak verilerin takipoe dilmesi bizlere lüzumsuz yere bir maliyet ortaya çıkaracaktır.

// AsNoTracking metodu, context üzerinden sorgu neticesinde gelecek olan verilerin ChangeTracker tarafından takip edilmesini engeller

// AsNoTracking metodu ile ChangeTracker'in ihtiyacı olmayan verilerdeki maliyetini törpülemiş oluruz

// AsNoTracking fonksiyonu ile yapılan sorgulamalarda verileri elde edebilir bu verileri istenilen noktalarda kullanabili lakın veriler üzerinden herhangi bir değişiklik/update işlemi yapamayız

//
var users = await context.Users.AsNoTracking().ToListAsync();

users.ForEach(user =>
    {
        Console.WriteLine(user.Name);
        user.Name = "Ronay";
        Console.WriteLine(user.Name);
    }
);

await context.SaveChangesAsync();

#endregion

#region AsNoTrackingWithIdentityResolution

// CT mekanizması yinelenen verileri tekil instance olarak getirir. Buradan ekstradan bir performans kazancı söz konusudur
// Bizler yaptığımız sorgularda takip mekanizmasının AsNotracking metodu ile maliyetiin kırmak isterken bazen maliyete sebebiyet verebiliriz.
// Özellikle ilişkisel tabloları sorgularken bu duruma dikkat etmemiz gerekiyor
// AsNotracking ile elde edilen veriler takip edilmeyeceğinden dolayı yinelenen verilerin ayrı instance'larda olmasına sebebiyet veriyoruz
// Çünkü CT takip ettiğini nesneden bellekte varsa eğer aynı nesneden bir daha oluşturma gereği duymaksızın o nesneye ayrı noktalarda ki ihtiyacı aynı instance üzerinden gidermektedir.
// Böyle bir durumda hem takip mekanizmasının maliyetini ortadan kadlırmak hemde yinelenen dataları tek bir instance üzerinde karşılamak için AsNoTrackingWithIdentityResolution

var books = await context.Books.Include(b => b.Authors).AsNoTrackingWithIdentityResolution().ToListAsync() ;

// AsNoTrackingWithIdentityResolution fonksiyonu AsNoTracking fonksiyonuna nazaran yavaştır/maliyetlidir lakin CT'a göre daha performanslıdır

#endregion

#region AsTracking

// Devre dışı bırakılan CT'ı iradeli bir şekilde ntity'ler üzerinde ki değişiklikleri takip eden CT mekanizmasını devreye almamızı sağlar
// Örneğin 

// Bir sonraki inceleyeceğimiz UseQueryTrackingBehavior metodunun davranışı gereği uygulama seviyesinde CT'nin default olarak devrede olup olmamasını ayarlıyor olacağız.
// Eğer ki default olarak pasif hale getirilirse böyle durumda takip mekanizmasının ihtiyaç olduğu sorgularda AsTracking fonksiyıonunu kullanabilir ve böylece takip mekanızmasını iradeli bir şekilde devreye sokmuş oluruz.
#endregion

#region

// Uygulama seviyesinde ilgili context'ten gelen verilerin üzerinde CT mekanizmasının davranışı temel seviye belirlememizi sağlayan fonksiyonudur. Yani konfigürasyon fonksiyonudur.

#endregion
