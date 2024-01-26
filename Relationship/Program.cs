#region Principal Entity(asıl entity)
// Kendi başına var olabilen tabloyu modelleyen entity'e denir
// Örnek : Çalışan bir departmanda çalışabilir
// Departmanın çalışanları olabilir
// Departman kendi başına bağımsız olabilir
// Fakat çalışan bir departmana bağlı olmadan çalışamaz

#endregion

#region Dependent Entity

// Kendi başına var olamayan bir başka tabloya ilişkisel olarak bağlı tabloyu modelleyen entity'e denir

// Calisanlar tablosunu modelleyen Calisan entity'sidir

#endregion

#region Foreign Key

// Principal Entity ile Dependent Entity arasında ki ilişkiyi sağlayan key'dir

// Calisanlar ve Departmanlar tablolarında ki yada entity'lerinde ki DepartmanlarId foreign key'dir

// Dependent Entity'de tanımlanır

// Principal Entity'de ki Principal Key'i tutar

#endregion

#region Principal Key

//class Calsian
//{
//    public int Id { get; set; }
//    public string CalisanAdi { get; set; }
//    public int DepartmanId { get; set; }
//    public Departman Departman { get; set; }

//}

//class Departman
//{
//    public int Id { get; set; }
//    public string DepartmanAdi { get; set;}
//    public ICollection<Departman> Calisan { get; set; }

//}

#endregion

#region Navigation Property

// İlişkisel tablolar arasında ki fiziksel erişimi entity' classları üzerinden sağlayan propertylerdir

// Bir property'nin navigation property olabilmesi için kesinlikle entity türünden olması gerekiyor

// Navigation property'ler entitylerdeki tanimlarına göre n'e n yahut 1'e n şeklinde ilişki türlerini ifade etmektedir.

#endregion

#region İlişki türleri

#region One to One
// Çalışan ile adresi arasında ki ilişki

#endregion

#region One To Many

// Çalışan ile departman arasında ki ilişki
// Anne ve çocukları arasında ki ilişki

#endregion

#region Many to Many

#endregion

#endregion

#region Entity Framework Core'da ilişki yapılandırma yöntemleri

#region Default Convention

// Varsayılan entity kurallarını kullanarak yapılan ilişki yapılandırma yöntemleridir
// Navigation propertyleri kullanarak ilişki şablonlarını çıkarmaktadır

#endregion

#region Data Annotation

// Entitynin niteliklerine göre ince ayarlar yapmamızı sağlayan attributelardır [Key], [ForeignKey]

#endregion

#region Fluent API

// Entity modellerindeki ilişkileri yapılandırırken daha detaylı çalışmamızı sağlayan yöntemdir

// HasOne

// HasMany

// WithOne

// WithMany

#endregion 

#endregion