# ntier-app-rabbitmq-postgresql
Phone Book App Backend Projesi
==============================

Kurumsal mimari yapısında (Business, DataAccess, Entities, Core) katmanlarını içerecek şekilde tasarlanmaya gayret edildi.
Bilgisayarınızda PostgreSQL, RabbitMQ ve Postman kurulu olmalıdır.
Migration işleminden sonra Contact ve ContactInfo tablolarına örnek (dummy) data eklenmektedir. Bu data ile servis kolayca test edilebilir.

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
     Kişi ve kişi detayı CRUD işlemleri

    Kişi ekleme:    
    POST http://localhost:54434/api/Contacts
    
    Kişileri listeleme:
    GET http://localhost:54434/api/Contacts
    
    Kişileri iletişim bilgileri ile birlikte detaylı listeleme:
    GET http://localhost:54434/api/Contacts/Details
    
    Kişiyi ve kişiye ait iletişim bilgileri detayını getirme:
    GET http://localhost:54434/api/Contacts/Details/{contactId}
    
    Kişi silme:
    DELETE http://localhost:54434/api/Contacts
    
    Kişiye ait iletişim bilgileri listeleme:
    GET http://localhost:54434/api/ContactInfoes
    
    Kişiye ait iletişim bilgisi ekleme:
    POST http://localhost:54434/api/ContactInfoes
    
    Kişiye ait iletişim bilgisi silme:
    DELETE http://localhost:54434/api/ContactInfoes

  II) ReportAPI: 
      Rapor oluşturma, listeleme ve detay getirme
  
    Eklenecek
