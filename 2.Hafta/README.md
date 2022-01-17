# E-Ticaret projeleri için örnek veritabanı şablonu

Ürün satışı yapmak için proje geliştirmek istiyorsanız bu yapıyı kullanarak veritbanı yapısını kolaylıkla oluşturabilirsiniz. Sistemde ürünlerinize ait bilgileri tutabilceğiniz **Products** tablosu, ürünlerin hangi kategoride olduğunu tutabilmek için **Categories** tablosu oluştmurulmuştur. Sisteme kayıt olacak kişilerin bilgilerini tutabilmek için **Users** tablosu, kayıt olan kullanıcılara rol ataması yapılabilmesi için rollerin tutulacağı **Rols** tablosu oluşturulmuş olup, bir kullanıcıya birden fazla rol ataması yapılmak istenirse kullanıcıya tanımlanmış rolerin bilgilerini tutabilmek için **UserRoles** tablosu oluşturulmuştur. Bunların yanında sepet işlemlerin kayıtlarının veritabanında tutulabimesi için **Carts**, Sipariş işlelreninin ve sipariş detaylar bilgilerinin tutulabilmesi için **OrderDetails**, ve ürünlere yapılan yorumları tutailmek içinde **Comments** tablosu oluşturulmuştur. Veritabanında tutulacak kayıtların tutarlı olabilmesi için ilgili tablolar arasında ilişki kurulmuştur. Veritbanı ve Tablo yapıları 
aşağıda ayrıntılı olarak açıklanmıştır. 


![alt text](https://omeryavas.com/content/img/ECommerceDB.gif)

## Categoies

 - **[Id]** ==> Sıra numarası tutmak için kullanılır.
 - **[CategoryName]** ==> Kategori adını tutmak için kullanılır.
 - **[CreateDate]** ==> Oluşturulduğu tarih bilgilerini tutmak için kullanılır.
 - **[LastUpDate]** ==> Güncellendiği tarih bilgilerini tutmak için kullanılır.
 - **[CreateUser]** ==> Oluşturan kullanıcı bilgilerini tutmak için kullanılır.
 - **[LastupUser]** ==> Güncelleyen kullanıcı bilgilerini tutmak için kullanılır.
 - **[IsActive]** ==> Aktif veya Pasif olma durumunu belirlemek için kullanılır.
 - **[IsDelete]** ==> Veritabanından tamamen silinmemesi gereken verilerin görünürde silinmiş gibi yapmak için kullanılır.
  
## Comments
  
 - **[Id]** ==> Sıra numarası tutmak için kullanılır.
 - **[Content]** ==> Yorum içeriğini tutmak için kullanılır.
 - **[EmailAdress]** ==> Yorum yapan kişinin email adresini tutmak için kullanılır.
 - **[Name]** ==> Yorum yapan kişinin adını tutmak için kullanılır.
 - **[ProductId]** ==> Yorum yapılan ürün bilgilerine ulaşmak için kullanılır.
 - **[CreateDate]** ==> Yorum yapıldığı tarih bilgilerini tutmak için kullanılır.
 - **[LastUpDate]** ==> Güncellendiği tarih bilgilerini tutmak için kullanılır.
 - **[CreateUser]** ==> Yorum yapan kullanıcı bilgilerini tutmak için kullanılır.
 - **[LastupUser]** ==> Güncelleyen kullanıcı bilgilerini tutmak için kullanılır.
 - **[IsActive]** ==> Aktif veya Pasif olma durumunu belirlemek için kullanılır.
 - **[IsDelete]** ==> Veritabanından tamamen silinmemesi gereken verilerin görünürde silinmiş gibi yapmak için kullanılır.

## Contacts
  
 - **[Id]** ==> Sıra numarası tutmak için kullanılır.
 - **[Name]** ==> Mail gönderen kişinin adını tutmak için kullanılır.
 - **[EmailAdress]** ==> Mail gönderen kişinin email adresini tutmak için kullanılır.
 - **[Subject]** ==> Mail başlığını tutmak için kullanılır.
 - **[Message]** ==> Mail içeriğini tutmak için kullanılır.
 - **[ReplyMessage]** ==> Maile verilen cevabı tutmak için kullanılır.
 - **[CreateDate]** ==> Oluşturulduğu tarih bilgilerini tutmak için kullanılır.
 - **[LastUpDate]** ==> Güncellendiği tarih bilgilerini tutmak için kullanılır.
 - **[CreateUser]** ==> Oluşturan kullanıcı bilgilerini tutmak için kullanılır.
 - **[LastupUser]** ==> Güncelleyen kullanıcı bilgilerini tutmak için kullanılır.
 - **[IsActive]** ==> Aktif veya Pasif olma durumunu belirlemek için kullanılır.
 - **[IsDelete]** ==> Veritabanından tamamen silinmemesi gereken verilerin görünürde silinmiş gibi yapmak için kullanılır.

## Genders
  
 - **[Id]** ==> Sıra numarası tutmak için kullanılır.
 - **[GenderName]** ==> Cinsiyet bilgilerini tutmak için kullanılır.

## OrderDetails
  
 - **[Id]** ==> Sıra numarası tutmak için kullanılır.
 - **[ProductName]** ==> Ürün adını tutmak için kullanılır.
 - **[ShowImageUrl]** ==> Ürüne ait bir resmi tutmak için kullanılır.
 - **[Price]** ==> Ürünün satın alındığındaki fiyatını tutmak için kullanılır.
 - **[Quantity]** ==> Satın alınan ürün miktarını tutmak için kullanılır.
 - **[ProductId]** ==> Satın alınan ürüne ait bilgilere ulaşmak için kullanılır.
 - **[OrderId]** ==> Detayların hangi siparişe ait olduğunu tespit etmek için kullanılır.

## Orders

 - **[Id]** ==> Sıra numarası tutmak için kullanılır.
 - **[Name]** ==> Siparişi veren kişinin adını tutmak için kullanılır.
 - **[Phone]** ==> Siparişi veren kişinin telefon bilgisini tutmak için kullanılır.
 - **[Email]** ==> Siparişi veren kişinin email adres bilgisini tutmak için kullanılır.
 - **[Address]** ==> Siparişi veren kişinin adres bilgisini tutmak için kullanılır.
 - **[City]** ==> Siparişi veren kişinin şehir bilgisini tutmak için kullanılır.
 - **[Note]** ==> Siparişi veren kişinin sipariş ile ilgili notlarını bilgisini tutmak için kullanılır.
 - **[Status]** ==> Siparişin durum bilgilerini tutmak için kullanılır. (Beklemede, Kargoda, Teslim edildi vs.)
 - **[PaymentTypeId]** ==> Siparişin ödeme türü bilgilerine ulaşmak için kullanılır. (Nakit, Kredi kartı vs.)
 - **[CargoMessage]** ==> Sipariş kargoya verildikten sonra kargo detaylarını ve kargoyla ilgili mesaj bilgilerini tutmak için kullanılır.
 - **[CargoName]** ==> Kargo firmasının bilgilerini tutmak için kullanılır.
 - **[CargoNo]** ==> Kargo numarasını tutmak için kullanılır.
 - **[CancelDescription]** ==> Sipariş iptal edilmesi halinde iptal nedenini tutmak için kullanılır.
 - **[CreateDate]** ==> Oluşturulduğu tarih bilgilerini tutmak için kullanılır.
 - **[LastUpDate]** ==> Güncellendiği tarih bilgilerini tutmak için kullanılır.
 - **[CreateUser]** ==> Oluşturan kullanıcı bilgilerini tutmak için kullanılır.
 - **[LastupUser]** ==> Güncelleyen kullanıcı bilgilerini tutmak için kullanılır.
 - **[IsActive]** ==> Aktif veya Pasif olma durumunu belirlemek için kullanılır.
 - **[IsDelete]** ==> Veritabanından tamamen silinmemesi gereken verilerin görünürde silinmiş gibi yapmak için kullanılır.


## ProductImages
 - **[Id]** ==> Sıra numarası tutmak için kullanılır.
 - **[PaymentName]** ==> Ödeme tür bilgilerini tutmak için kullanılır. (Nakit, Kredi kartı vs.)

## PaymentTypes
 - **[Id]** ==> Sıra numarası tutmak için kullanılır.
 - **[ImageURL]** ==> Resmin url bilgilerini tutmak için kullanılır.
 - **[ImageTitle]** ==> Resmin başlık bilgilerini tutmaki için kullanılır.
 - **[ProductId]** ==> Resmin hangi ürüne ait olduğunu bilgisini tutmak için kullanılır.

## Products
 - **[Id]** ==> Sıra numarası tutmak için kullanılır.
 - **[ProductName]** ==> Ürün adını tutmak için kullanılır.
 - **[Price]** ==> Ürün fiyatını tutmak için kullanılır.
 - **[Description]** ==> Ürün açıklamasını tutmak için kullanılır.
 - **[UnitInStok]** ==> Ürünün stok adet bilgisini tutmak için kullanılır.
 - **[ShowImageUrl]** ==> Ürünün ilk gösterilecek resim bilgilerini tutmak için kullanılır.
 - **[CategoryId]** ==> Ürünün hangi kategoriye ait olduğu bilgisini tutmak için kullanılır.

## Roles
 - **[Id]** ==> Sıra numarası tutmak için kullanılır.
 - **[RoleName]** ==> Kullanıcılara atanacak rol bilgilerini tutmak için kullanılır.

## UserRoles
 - **[UserId]** ==> Atanan rolün hangi kullanıcıya ait olduğunu tutmaki için kullanılır.
 - **[RoleId]** ==> Kullanıcıya atanan rolün hangi rol oduğu bilgisini bilgilerini tutmak için kullanılır.

## Users
 - **[Id]** ==> Sıra numarası tutmak için kullanılır.
 - **[FirstName]** ==> Kullanıcının adını tutmak için kullanılır.
 - **[LastName]** ==> Kullanıcının soyadını tutmak için kullanılır.
 - **[UserName]** ==> Kullanıcınının sistem kullanğıcı adını tutmak için kullanılır.
 - **[Password]** ==> Kullanıcının sisteme giriş yapmak için kullanacağı şifreyi tutmak için kullanılır.
 - **[ImageUrl]** ==> Kullanıcıya ait resim URL bilgilirini tutmak için kullanılır.
 - **[GenderId]** ==> Kullanıcının cinsiyet bilgisini tutmak için kullanılır.
 - **[Email]** ==> Kullanıcının emial adres bilgisini tutmak için kullanılır.
 - **[PhoneNumber]** ==> Kullanıcıya ait telefon numarasını tutmak için kullanılır.
 - **[Address]** ==> Kullanıcının adres bilgilerini tutmak için kullanılır.
 - **[AccountConfirmed]** ==> Kullanıcının hesabını onaylayıp onaylamadığını kontrol etmeki için kullanılır.
 - **[AccountConfirmedCode]** ==> Kullanıcının hesabını onaylabilmesi için oluşturulan uniq kod bilgilerini tutmak için kullanılır.

