# BS Store App

## 📋 Proje Hakkında
BS Store App, modern ve güvenli bir e-ticaret çözümü sunan .NET Core tabanlı bir web uygulamasıdır. Bu proje, RESTful API prensiplerini takip ederek geliştirilmiş olup, ölçeklenebilir ve sürdürülebilir bir mimariye sahiptir.

## 🚀 Özellikler
- RESTful API mimarisi
- Entity Framework Core ile veritabanı entegrasyonu
- Repository pattern implementasyonu
- Modern ve güvenli kimlik doğrulama sistemi
- Swagger/OpenAPI desteği
- Dependency Injection kullanımı

## 🛠️ Teknolojiler
- .NET Core
- Entity Framework Core
- SQL Server
- Swagger/OpenAPI
- C#

## 📦 Kurulum

### Gereksinimler
- .NET Core SDK
- SQL Server
- Visual Studio 2022 veya Visual Studio Code

### Adımlar
1. Projeyi klonlayın:
```bash
git clone [proje-url]
```

2. Proje dizinine gidin:
```bash
cd bsStoreApp
```

3. Bağımlılıkları yükleyin:
```bash
dotnet restore
```

4. Veritabanını oluşturun:
```bash
dotnet ef database update
```

5. Uygulamayı çalıştırın:
```bash
dotnet run
```

## 📁 Proje Yapısı
```
bsStoreApp/
├── Controllers/     # API endpoint'leri
├── Models/         # Veri modelleri
├── Repositories/   # Veri erişim katmanı
├── Migrations/     # Veritabanı migration'ları
└── Program.cs      # Uygulama başlangıç noktası
```

## 🔧 Yapılandırma
Uygulama ayarları `appsettings.json` dosyasında bulunmaktadır. Veritabanı bağlantı dizesi ve diğer yapılandırma ayarlarını buradan düzenleyebilirsiniz.

## 📚 API Dokümantasyonu
API dokümantasyonuna Swagger UI üzerinden erişebilirsiniz:
```
https://localhost:[port]/swagger
```


