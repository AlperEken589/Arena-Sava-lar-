# Arena-Savascilari
Bu çalışmada, bir düşman dalgası tabanlı bir savaş oyunu simülasyonu geliştirmeye çalıştım.

Projenin Amacı: 
1. Nesne Yönelimli Programlama (OOP) prensiplerini uygulayarak basit bir savaş oyunu geliştirmek.
2. Oyuncu sınıf yapıları ve miras kullanımıyla karakter yeteneklerini modellemek.
3. Oyuncular ile düşmanlar arasında dinamik bir savaş simülasyonu oluşturmak.
4. Akış diyagramı ile yazılımın yapısını görselleştirmek.

Canlı Sınıfı: Oyuncular ve düşmanlar için temel sınıf.
Oyuncu Sınıfı: Canlı sınıfından oluşmuş bir sınıf.
Düşman Sınıfı: Canlı sınıfından oluşan ve oyuncuya saldırabilen bir sınıf.

Alt sınıflar: Şövalye, Şifacı, Büyücü (her birini özel hareketlerle oluşturdum).
1. Şövalye özellikleri: Özel saldırılar normal saldırıların 3 katı hasar vurur.
2. Şifacı özellikleri: Her turun sonunda kendine belirli bir miktarda can basar.
3. Büyücü özellikleri: Her turun sonunda kendine belirli miktarda mana basar.

Oyun sırasında oyuncunun verdiği kararlara göre üretilen ekran çıktıları oluşturdum.
1. Karakter Seçimi: Oyuncunun şövalye, şifacı veya büyücü karakterlerinden birini seçmesi.
2. Normal ve Özel Saldırılar: Oyuncunun düşmanlara zarar vermesi veya mana kullanımı.
3. Dalga İlerlemesi: 1. dalgadan 5. dalgaya kadar düşmanların sayısı ve gücünün artması.
4. Zafer veya Yenilgi: Tüm dalgaları geçme ya da oyuncunun ölmesi durumları.

Oyun yapısı açık ve genişletilebilir bir şekilde tasarlandı.
Görselleştirmeler ile yazılımın yapısı kolayca anlaşılır hale getirildi.

EK DOSYALAR:
1. Ekran çıktısı örneği
2. Akış şeması
