# Rehber Uygulaması

Bu uygulamada rehberinizi oluşturarak kişilerinizin ad, soyad, telefon ve adres bilgilerini tutabilirsiniz.

Yapılabilecek işlemler aşağıdaki tabloda gösterilmiştir.

|  İşlem    | HTTP yöntemi           | URL|
|:------------- |:-------------|:-----|
|Tüm kişi listesini almak için      | Get | api/Person |
|Id'ye göre kayıt almak için      | Get      |   api/Person/_ID_ |
|İsim veya soyisime göre arama yapmak için | Get     |    api/Person/search?name="_aranacakName_"&surname="_aranacakSurname_" |
|Yeni kişi eklemek için      | Post      |   api/Person/Person |
|Kişi bilgilerini güncelemek için      | Put      |   api/Person/_ID_ |
|Kişi silmek için     | Delete      |   api/Person/_ID_ |
