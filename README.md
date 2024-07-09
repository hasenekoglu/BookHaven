# BookHaven

  

# Çevrimiçi Kitaplık Yönetim Sistemi - Proje Dokümantasyonu 

  

## 1. Proje Tanımı 

Çevrimiçi Kitaplık Yönetim Sistemi, kullanıcıların kitap ödünç alma, geri getirme, yorum yapma ve kitapları derecelendirme gibi işlemleri gerçekleştirebileceği bir web uygulamasıdır. Kullanıcılar, kitaplar hakkında bilgi edinebilir, gelişmiş arama ve filtreleme özelliklerini kullanarak kitapları keşfedebilir ve sosyal özelliklerle diğer kullanıcılarla etkileşimde bulunabilir. 

  

## 2. Hedefler 

- Kullanıcıların kitap ödünç alma ve geri getirme işlemlerini kolayca gerçekleştirebileceği bir sistem oluşturmak. 

- Kitaplar hakkında yorum ve değerlendirme yapabilme imkanı sunmak. 

- Gelişmiş arama ve filtreleme özellikleri ile kullanıcı deneyimini iyileştirmek. 

- Bildirim ve e-posta servisleri ile kullanıcıları bilgilendirmek. 

- Güvenli bir kimlik doğrulama ve yetkilendirme mekanizması sağlamak. 

  

## 3. Teknoloji Yığını 

- **Backend**: .NET Core 

- **Veritabanı**: MSSQL 

- **Frontend**: (Projenin backend kısmı tamamlandıktan sonra belirlenecek) 

- **Mesajlaşma Sistemi**: RabbitMQ 

- **Diğer Teknolojiler**: AutoMapper, MediatR, CQRS, JWT, Swagger 

  

## 4. Mimari Yapı 

- **Katmanlı Mimari**: Presentation (API), Application, Domain, Infrastructure 

- **CQRS**: Command Query Responsibility Segregation 

- **MediatR**: MediatR kütüphanesi ile talep ve bildirimlerin yönetimi 

- **AutoMapper**: Veri transfer nesnelerinin (DTO) otomatik eşlenmesi 

  
  

## 5. Veritabanı Tasarımı 

### Tablolar 

- **Books** 

  - BookId (Primary Key) 

  - Title 

  - Author 

  - ISBN 

  - PublishedYear 

  - Genre 

  - Description 

  - Rating 

  

- **Users** 

  - UserId (Primary Key) 

  - Username 

  - PasswordHash 

  - Email 

  - Role (Enum: Admin, User) 

  

- **Loans** 

  - LoanId (Primary Key) 

  - BookId (Foreign Key) 

  - UserId (Foreign Key) 

  - LoanDate 

  - ReturnDate 

  

- **Roles** 

  - RoleId (Primary Key) 

  - RoleName 

  

### İlişkiler 

- **Books** ve **Loans** arasında 1:N ilişkisi. 

- **Users** ve **Loans** arasında 1:N ilişkisi. 

- **Users** ve **Roles** arasında 1:N ilişkisi. 

  

## 6. API Uç Noktaları 

### BooksController 

- `GET /api/books` - Tüm kitapları getirir. 

- `GET /api/books/{id}` - Belirli bir kitabı getirir. 

- `POST /api/books` - Yeni bir kitap ekler. 

- `PUT /api/books/{id}` - Belirli bir kitabı günceller. 

- `DELETE /api/books/{id}` - Belirli bir kitabı siler. 

  

### UsersController 

- `GET /api/users` - Tüm kullanıcıları getirir. 

- `GET /api/users/{id}` - Belirli bir kullanıcıyı getirir. 

- `POST /api/users` - Yeni bir kullanıcı ekler. 

- `PUT /api/users/{id}` - Belirli bir kullanıcıyı günceller. 

- `DELETE /api/users/{id}` - Belirli bir kullanıcıyı siler. 

  

### LoansController 

- `GET /api/loans` - Tüm ödünç işlemlerini getirir. 

- `GET /api/loans/{id}` - Belirli bir ödünç işlemini getirir. 

- `POST /api/loans` - Yeni bir ödünç işlemi ekler. 

- `PUT /api/loans/{id}` - Belirli bir ödünç işlemini günceller. 

- `DELETE /api/loans/{id}` - Belirli bir ödünç işlemini siler. 

  

### AuthController 

- `POST /api/auth/login` - Kullanıcı giriş işlemi. 

- `POST /api/auth/register` - Kullanıcı kayıt işlemi. 

  

## 7. Geliştirme Süreci 

### 1. Adım: Proje Kurulumu 

- .NET Core çözüm yapısını oluşturun. 

- Klasör yapısını ve katmanlı mimariyi oluşturun. 

- Gerekli paketleri (AutoMapper, MediatR, Swagger, JWT) ekleyin. 

  

### 2. Adım: Veritabanı Tasarımı ve Oluşturulması 

- MSSQL veritabanını oluşturun. 

- Entity Framework Core kullanarak veritabanı modellerini ve DBContext'i oluşturun. 

- Migration ve veritabanı güncellemelerini yapın. 

  

### 3. Adım: Domain Katmanı 

- Varlık sınıflarını ve arayüzlerini oluşturun. 

- Enum tiplerini tanımlayın. 

  

### 4. Adım: Infrastructure Katmanı 

- Repository sınıflarını oluşturun ve implement edin. 

- Veritabanı yapılandırmalarını yapın. 

- Yardımcı sınıfları oluşturun (JwtHelper, PasswordHasher). 

  

### 5. Adım: Application Katmanı 

- Servisleri ve arayüzlerini oluşturun. 

- İş mantığını servislerde tanımlayın. 

- Özel istisna sınıflarını oluşturun. 

- Nesne eşleme profillerini tanımlayın (AutoMapper). 

  

### 6. Adım: API Katmanı 

- Kontrolörleri oluşturun. 

- API uç noktalarını tanımlayın. 

- Swagger yapılandırmasını ekleyin. 

- Kimlik doğrulama ve yetkilendirme işlemlerini ekleyin. 

  

  

 
