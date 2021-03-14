# phone-book-app
Phone Book App Backend Projesi
==============================

Kurumsal mimari yapısında (Business, DataAccess, Entities, Core) katmanlarını içerecek şekilde tasarlanmaya gayret edildi.
Bilgisayarınızda PostgreSQL, RabbitMQ ve Postman kurulu olmalıdır.

  PostgreSQL için link:
  https://www.enterprisedb.com/downloads/postgres-postgresql-downloads

  RabbitMQ (Windows için):  
  https://github.com/rabbitmq/rabbitmq-server/releases/download/v3.8.14/rabbitmq-server-3.8.14.exe
  
  Postman (Windows 64 bit için):
  https://dl.pstmn.io/download/latest/win64

1) Veritabanının Oluşturulması (Migration) için;
------------------------------------------------

Paket yönetici konsolunda; DataAccess katmanı seçili iken

Şayet DataAccess içinde "Migration" klasörü yoksa:
Add-Migration InitialEntities

Eğer varsa sadece;
Update-Database

ile PostgreSQL üzerinde PhoneBookDB veritabanı oluşturulmaktadır.

2) Proje içerisindeki API lar:
------------------------------

İki adet API tasarlandı WebAPI ve ReportAPI.

Rest servisler için Postman aracıyla istekler oluşturulmaktadır.

  I) WebAPI:

    Kişi ekleme:    
    POST http://localhost:54434/api/Contacts
    
    Kişileri listeleme:
    GET http://localhost:54434/api/Contacts
    
    Kişilere ait iletişim bilgilerini detaylı getirme:
    GET http://localhost:54434/api/Contacts/Details
    
    ![image](https://user-images.githubusercontent.com/46825409/111084618-4b164680-8524-11eb-9721-ce32edf2e261.png)

  II) ReportAPI:
  
    
