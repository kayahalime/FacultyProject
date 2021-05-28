# FacultyProject Backend

•	Visual Studio’da FacultyProject adında Boş Solution oluşturuldu.

•	Solution içinde class liibrary’ler eklendi.

•	Class Library: Birbirleriyle ilgili katmanlar anlamına gelir.

Katmanlar:

Entities: Bu katmanda varlıklarımızı tutacağız.

DataAccess: Verilerimize erişimi bu katman ile sağlayacağız.

Business: İş kodlarımızı yazacağımız katman.

ConsoleUI: Burada arayüzü eklemeden önce testlerimizi yapacağız.

FormsApp: Sunum katmanımız olacak. Kullanıcının işlemlerini yapacağı katman.

Core: Evrensel kodlarımızın olacağı katman bu katmanı diğer projelerimizde de kullanabiliriz. (Burada operasyonları generic hale getiririz.)

![Image](https://github.com/kayahalime/FacultyProject/blob/master/img/1.png)

•	Neden katmanlı mimari kullanırız?:  Katmanlı mimarinin en büyük yararı, kodlarımızı daha küçük yapılara bölerek kolay kontrol edilebilirlik ve güncellenebilirlik sağlar. Ayrıca verilerimizin güvenliğini de en yüksek seviyede korur.

•	Entities,DataAccess ve Business katmanlarına Abstract ve Concrete klasörleri eklendi.

•	Entities Concrete klasörü içerisinde her bir varlık için classlar eklendi ve diğer katmanlardan erişim için public hale getirildi.

![Image](https://github.com/kayahalime/FacultyProject/blob/master/img/2.png)

•	İsterlere göre varlıklar oluşturuldu burada öğrenci notları için ayrı bir tablo oluşturmam gerekti çünkü bir öğrenciye ait birden fazla ders ortalaması olabilir ayrıca DepartmentInformation adında oluşturduğum classta da öğrenci no gibi bilgileri tuttum bunun sebebide bir öğrenci çift anadal yapıyorsa iki farklı öğrenci no olabilir bu yüzden varlıklarımı bu senaryoya uygun oluşturdum.

•	Entities katmanında Abstract klasöründe IEntity adında bir interface oluşturuldu, bunun sebebi varlıları oluşturduğumuz classlarda implemente ederek onları IEntity olarak tanımlamak ve diğer classlardan ayırmak böylece herhangi bir filtreleme durumunda diğer classlardan farkı olabilir.

![Image](https://github.com/kayahalime/FacultyProject/blob/master/img/3.png)
Örnek bir IEntity classı

•	MSSQL’de Faculty adında bir veritabanı oluşturuldu. Tüm varlıklar için tablolar oluşturuldu.(FacultyDb dosyasında veritabanı kodları mevcuttur.)

•	Her bir tablodaki id özelliğini Primary key identity yaptım böylece her tabloca bir id sadece bir kez kullanılabilir,kullanıcı tarafından değer verilemez sistem tarafından otomatik artar.

•	Tabloları foreign key ile ilişkilendirdim.

![Image](https://github.com/kayahalime/FacultyProject/blob/master/img/4.png)

•	DataAccess ve Business katmanlarını oluşturmadan önce Core katmanını oluşturmak istedim çünkü diğer katmanlardaki operasyonlarım core katmanında generic halde bulunuyor.

•	Core katmanı bir kere oluşturulup buradaki yapılar diğer projemizde kullanılabilir bu yüzden daha önceden oluşturmuş olduğum Core katmanını bu projeme dahil ediyorum.

![Image](https://github.com/kayahalime/FacultyProject/blob/master/img/5.png)

•	Aspects: Uygulama süresince sistemin birçok bölümünde kullanılan, fonksiyonel olmayan kodun yani kesişen ilgilerin ufak ufak parçalara ayırarak uygulama genelinde kullanılacak olan yapıları sistemden soyutlamış olup enkapsüle ederek birçok yerde kullanılmasını sağlar.

•	CrossCuttingConcers: Log, cache, transaction, validation gibi bütün katmanlardaki ortak operasyonlar.

•	DataAccess: DataAccess katmanındaki operasyonların generic hali

•	Entities: Tüm projelerde olması muhtemel olan User ve ona bağlı OperationClaim gibi varlıklarımızın olduğu klasör

•	Extensions: Extension metodlar static bir class içerisinde static olarak tanımlanmalıdır. Extend edilecek class ilgili extension metoda metodun ilk parametresi olarak verilip önünde this keyword'ü ile tanımlanmalıdır. Extension metod da tanımlı parametrelerden sadece 1 tanesi this keyword'ü ile tanımlanır

•	Interceptors: Interceptor'lar belirli noktalarda metot çağrımları sırasında araya girerek bizlerin çakışan ilgilerimizi işletmemizi ve yönetmemizi sağlamakta. Böylece metotların çalışmasından önce veya sonra bir takım işlemleri gerçekleştirebilmekteyiz.

•	Utilities: Business klasöründe ki BusinessRules’i şu şekilde kullanırız örenğin Business katmanında manager içindeki bir metoda birsürü operasyonlar yazarsak karışır bizde private metotlar oluşturur bu operasyonları ilgili metotdan BusinessRule ile çağırırız böylelikle bir operasyon dahil etmek istediğimizde ya da çıkarmak istediğimizde sadece BusinessRule içinden çağırdığımız metodu siler başka bir yere dokunmayız. FileHelper klasöründe dosya işlemlerimiz bulunuyor. Ioc oluşturulacak olan nesnenin yaşam döngüsünün yönetilmesidir. Metotlarımızı Result yapılarıyla oluştururuz bu yapılar sayesinde operasyonlarımızı yönetiriz.Security klasöründe ise encryption hashing gibi şifreleme ve  json web token gibi yetkilendirme ile ilgili kodlarımız bulunur.

•	Core katmanını dahil ederek projemizde kod tekrarını önlemiş oluyoruz.

•	DataAccess katmanında EntityFramework adında bir klasör açıldı. Entity Framework Microsoft tarafından geliştirilen ve yazılım geliştiricilerin katı sql sorguları yazmalarını ortadan kaldırarak bir ORM imkanı sağlayan framework’tür.

•	Entity Framewor klasöründe FacultyContext adında class açıldı ve burada veritabanı ve kodlarımız arasındaki bağlantı kurulacak. 

•	DbContext:  Veritabanı ile uygulama arasında sorgulama, güncelleme, silme gibi işlemleri yapmamıza olanak sağlar.

![Image](https://github.com/kayahalime/FacultyProject/blob/master/img/6.png)

•	Görselde 1 numaralı işaretlediğim yerde veritabanı ile konfigürasyon sağlandı veritabanının adresi yazıldı.

•	2 numaralı işaretlediğim yerde veritanındaki tablolar ile varlıklarımız arasındaki bağlantıyı kurduk yani hangi tablonun hangi varlığa eşit olduğunu belirttik.

•	DataAccess Abstract klasöründe bütün varlıklarımız için servisler oluşturuldu. Burada IEntityRepository’i implemente ettik gerekli operasyonlar bizim için gelecek.

•	EntityFramework klasöründe de bütün varlıkların managerleri oluşturuldu. Burada da EfEntityRepositoryBase’i implemente ettik bizim için gerekli operasyonları getirecek.

•	Core katmanındaki entities içerisinde bulunan user varlığı veritabanında oluşturuldu ve claim operasyonları içinde gerekli tablolar oluşturuldu. Claimler : Rolleri dışında kullanıcı hakkında bilgi tutmamızı ve bu bilgilere göre yetkilendirme yapmamızı sağlayan yapılardır.

•	Business katmanında abstract sınıfları oluşturuldu. Burada operasyonlar IResult ve IDataResult yapıları ile oluşturdum bu yapılar sayesinde operasyonlarımızı yönetebileceğiz.

•	Business katmanında entities ve core katmanları referans eklendi.

•	Sonrasında Business Consrete klasöründe manager sınıfları oluşturmaya başladık. Manager sınıflarda servisleri implemente ettik ve burada operasyonlar için gerekli değerleri döndüreceğiz.

•	Öncelikle boş bir consctructor(class içinde ilk çalışan yapı) oluşturduk ve  Dependency Injection (bağımlılıkların dışarıdan enjekte edilmesi işlemi) ile ilgili varlığın DataAccess katmanındaki Dal servisinin örneği oluşturuldu. Ve bu şekilde metotlar içerisinden gerekli operasyonları çağırdık.

•	Business katanında DependencyResolvers adında bir klasör oluşturuldu onun içerisinde Autofac adında bir klasör oluşturuldu.

•	Autofac :.Net framework için geliştirilmiş bir Ioc Container’dır(nesnelerin yaşam döngüsünün yönetilmesi). 

![Image](https://github.com/kayahalime/FacultyProject/blob/master/img/7.png)

•	Burada örneğin Department varlığı için yapmaya çalıştığımız şudur: DepartmentManager demek bizim için aynı zamanda IDepartmentService demek yani herbir request için singleton şekilde ilgili nesne örneğinin bizim adımıza üretilmesidir.

•	Programın çalışması için gerekli tüm yapıları oluşturduk. Şimdi gerekli olan tablolarımızı birleştireceğiz. Bunun için Entities katmanında DTOs adlı bir kalsör açıldı.

•	DTO: veri dönüştürme nesnesi

•	StudentDetailDto adlı bir class açtım burada farklı tablolardai öğrenciye ait bilgileri öğrenci detayları adında olacak aynı şekilde dersler içinde bu işlem yapıldı.

•	Daha sonra GetStudentDetail operasyonu DataAccess ve Business katmanlarına dahil edildi.

•	Son olarak bizden istenen bazı kurallar vardı bunların bir kısmını Business katmanında fluent validation ile yaptık. 

•	Fluent Validation: Amacı datanın doğru olduğunu jquery validation gibi client-side da kontrol etmek yerine istenirse hem server-side hemde client-side de kontrol edilmesini sağlar.

•	Herbir nesne için validator oluşturuldu. 

![Image](https://github.com/kayahalime/FacultyProject/blob/master/img/8.png)

•	Örneğin burada ilk kural NoEmpty yani DepartmentName boş bırakılamaz ikincisinde ise DepartmentName’in B harfi ile başlaması gerektiği kuralını dahil ettik bunu StartsWith metotuyla sağladık.

![Image](https://github.com/kayahalime/FacultyProject/blob/master/img/9.png)

•	Karakterlerin uzunluğunu belirledğimiz kurallar koyduk.

•	Ancak Her bir öğretim üyesi için sicil no (4 haneli olacak, rakamlardan oluşacak ve B1 bölümündeki öğretim üyeleri için 1 ile B2 dekiler için 2 ile başlayacak!) bu kuralı validatorlerde oluşturamadım çünkü bunu yapmak için LecturerValidator’den department içindeki kod özelliğine ulaşmamız gerekiyor ancak denedğim yollar solid kurallarına aykırı olduğu için ve programın akışını etkileyeceği için şöyle bir senaryo yazdım.

•	Bölüm varlığına value adında bir özellik daha oluşturdum yani bölüm kodu eklendiğinde başındaki B harfi silinerek value’ye atılacak örneğin id:1 bölümkodu:B4 ve value:4 şeklinde ve bunu da DeparmentManager içinde sağladım.

![Image](https://github.com/kayahalime/FacultyProject/blob/master/img/10.png)

•	Bu yapıyı görseldeki gibi kurdum bunu add metotundan çağırarak aktif hale getirdim.

![Image](https://github.com/kayahalime/FacultyProject/blob/master/img/11.png)

•	Burada 1 numaralı gösterdiğim yerde validatorleri dahil ediyoruz hangi operasyon ile çalışmasını istiyorsak o operasyondan önce çağırıyoruz.

•	2 numarlı yerde ise önceki görseldeki B harfini silme metotları gibi yazdığımız bir takım metotları businessrules ile çağırırız ki operasyonlarla bir metotun içini doldurmayalım. Bir operasyon daha eklemek istediğimizde virgül koyup çağırıyoruz başka değişiklik yapmamıza gerek kalmıyor.

•	Şimdi ise bu values değerini LecturerManagerden çağırarak sicil no’yu kontrol edeceğiz.

•	Öncelikle LecturerManagerde DepartmentService’in bir örneğini oluşturmamız gerekiyor çünkü bir managerde başka bir varlığın Dal’ı çağırılmaz.

![Image](https://github.com/kayahalime/FacultyProject/blob/master/img/12.png)

Aynı işlemleri öğrenci no ve ders kodu içinde gerçekleştirdim.
