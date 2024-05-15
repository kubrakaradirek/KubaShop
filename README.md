Bu proje, ASP.NET Core mikroservis mimarisi kullanılarak geliştirilen bir e-ticaret websitesidir ve Murat Yücedağ'ın Udemy kursunu takip ederek oluşturulmaya devam edilmektedir.MVC ve API'ler kullanılmaktadır. Proje, farklı mikroservislerden oluşmaktadır ve şu anda MSSQL ve MongoDB veritabanlarını kullanmaktadır. Ayrıca projede Redis, Docker, MongoDB, Soğan Mimarisi (Onion Architecture), CQRS, Postman ve Identity Server gibi teknolojiler de kullanılmaktadır.

Proje geliştirilmeye devam etmektedir.

## Mikroservisler

- KubaShop.WebUI --> MVC kullanılmıştır.
      
- IdentityService

- Basket
  
- Cargo
  
- Catalog
  
- Comment
 
- Discount
  
- Order
  
# Kullanılan Teknolojiler

- ASP.NET Core 6.0

- MVC

- WEB API

- MSSQL

- MongoDB

- Redis

- Docker
  
- Onion Architecture
  
- CQRS

- Mediator
  
- Postman

- Identity Server

- JWT (JSON Web Token)

- Portainer: Docker konteynerlerinin yönetimi için kullanılan bir kullanıcı arabirimi.

- Entity Framework Core

Catalog Mikroservisi
  
Katalog mikroservisi, veritabanı olarak MongoDB kullanmaktadır. Bu mikroservis içerisinde Product, Category, ProductImage ve Detail varlıkları bulunmaktadır. Her bir varlık için DTO'lar tamamlanmıştır ve AutoMapper kullanılmıştır.API'ler yazılmış ve Postman'de test edilmiştir ve hepsi çalışmaktadır. Bu hizmetler, token ile koruma altına alınmıştır ve Web API kullanılmıştır.

Discount Mikroservisi

Discount API'si yazılarak Postman aracılığıyla test edilmiştir. Veritabanı olarak MSSQL kullanılmıştır. JWT yetkilendirme işlemleri gerçekleştirilmiş ve bu hizmet token ile koruma altına alınmıştır.

Order Mikroservisi

Bu serviste Onion Architecture&CQRS ve Mediator tasarım desenleri kullanılmıştır. Address ve result sınıfları tanımlanmıştır ve CRUD metotları yazılmıştır. API'ler oluşturulmuştur. Ordering sınıfı için Mediator tasarım deseni uygulanmıştır. JSON Web Token yetkilendirme işlemleri yapılmış ve bu servis token ile koruma altına alınmıştır.
Docker portainer arayüzü ile kurulmuştur. Portainer üzerinden MSSQL Linux ile container deploy işlemi gerçekleştirilmiştir. Port numarasını değiştirerek tüm veritabanları DBeaver ile bağlantı sağlanabilir. OrderDb’ye MSSQL üzerinden bağlanılmış ve Order mikroservislerinin API'leri yazılmıştır ve Postman aracılığıyla testleri yapılmıştır.

Identity Mikroservisi

Bu mikroservis üzerinde Identity Server kurulumu tamamlanmıştır. Identity Server migration işlemleri başarıyla tamamlanmıştır ve API test edilmiştir. Bu mikroservis token ile koruma altına alınmıştır.

Cargo Mikroservisi

Cargo mikroservisi için MSSQL veritabanı kullanılmıştır. Onion katmanlı mimari benimsenmiştir ve MVC kullanılmıştır. Generic Repository, Dal interfaceleri, entityler ve context sınıfı yazılmıştır. Business katmanı için manager sınıfları oluşturulmuştur. CargoCompany, CargoCustomer, CargoDetail, CargoOperationController ve RegistrationController gibi controllerlar yazılmıştır. API'nin Swagger ve Postman üzerinde testleri yapılmış ve token ile koruma altına alınmıştır.

Basket Mikroservisi

Web API projesi oluşturulmuş ve tek bir katmandan oluşmaktadır. Redis kullanılmıştır. Basket DTO'ları oluşturulmuş ve Redis Service ve Basket Service sınıfları yazılmıştır. Giriş yapan kullanıcının 'sub' değeri alınmıştır. Basket controller yazılmıştır. Kullanıcı adı ve şifre ile token alınmıştır. Redis sepeti için test işlemleri gerçekleştirilmiştir.

Comment Mikroservisi

Migration işlemleri ve API testleri tamamlandı.Admin panelinde yorum listesi ve yorum güncelleme sayfası yapıldı.Proje devam etmektedir. Tamamlandığında, video ve yazılar güncellenecektir."

Ürün ekleme sayfasında kategorilerin listelenmesi, ürün ekleme, silme ve güncelleme işlemleri yapıldı.Katalog mikroservisi ürünleri kategoriyle UI tarafta listelendi.

![Ekran görüntüsü 2024-05-16 010140](https://github.com/kubrakaradirek/KubaShop/assets/133059827/cc4a0df9-28c2-469f-adae-f2fbc9730c7a)
![Ekran görüntüsü 2024-05-16 010149](https://github.com/kubrakaradirek/KubaShop/assets/133059827/a5acc1ca-eb31-4792-9aab-b880f22ea371)
![Ekran görüntüsü 2024-05-16 010201](https://github.com/kubrakaradirek/KubaShop/assets/133059827/9ca4c5f4-759e-4367-bb49-dfe8363fdadb)
![Ekran görüntüsü 2024-05-16 010227](https://github.com/kubrakaradirek/KubaShop/assets/133059827/b9a48760-5e7c-4010-8cf0-8cebc6d6bb9f)
![Ekran görüntüsü 2024-05-16 010350](https://github.com/kubrakaradirek/KubaShop/assets/133059827/aa7ab870-3cc3-4110-970b-c3c53994ad45)
![Ekran görüntüsü 2024-05-16 010400](https://github.com/kubrakaradirek/KubaShop/assets/133059827/a0f950e8-3a21-4e6c-8a1b-ba2fe53c747c)
![Ekran görüntüsü 2024-05-16 010413](https://github.com/kubrakaradirek/KubaShop/assets/133059827/c81ec9dd-e082-4cf5-9b41-1bea9eb16030)
![Ekran görüntüsü 2024-05-16 010446](https://github.com/kubrakaradirek/KubaShop/assets/133059827/374922ad-a907-415d-82de-c6f5f891eb40)
![Ekran görüntüsü 2024-05-16 010502](https://github.com/kubrakaradirek/KubaShop/assets/133059827/537fab58-111c-47bc-bb64-1d9adc2252f6)
