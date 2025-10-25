# Çevrimdışı Konuşma Tanıma (Speech-to-Text) Uygulaması
Bu proje, C# ve Windows Forms kullanılarak geliştirilmiş basit bir sesten metne dönüştürme (speech-to-text) uygulamasıdır. Windows'un yerleşik System.Speech.Recognition kütüphanesini kullanarak, internet bağlantısı gerektirmeden (çevrimdışı) çalışır.

Özellikler
Çevrimdışı Çalışma: İnternet bağlantısı veya harici bir API anahtarı gerektirmez.

Basit Arayüz: Windows Forms ile oluşturulmuş, kullanımı kolay bir arayüz.

Başlat/Durdur: Mikrofondan ses dinlemeyi başlatmak ve durdurmak için butonlar.

Gerçek Zamanlı Çıktı: Konuşulan metin, algılandığı anda bir metin kutusuna yazdırılır.

Gereksinimler
Bu projenin çalışması için sisteminizde bazı yapılandırmaların olması ZORUNLUDUR:

İşletim Sistemi: Sadece Windows. (Bu kütüphane macOS veya Linux'ta çalışmaz).

.NET: Projenin oluşturulduğu .NET sürümü (örn: .NET 6, 7, 8 veya .NET Framework).

Windows Konuşma Paketi: Bu en önemli gereksinimdir. Uygulamanın sesi tanıyabilmesi için, Windows'unuzda hedef dilin (örn: İngilizce veya Türkçe) konuşma paketinin yüklü olması gerekir.

Konuşma Paketi Nasıl Yüklenir?
Windows'ta Ayarlar'ı açın.

Zaman ve Dil > Konuşma menüsüne gidin.

"Konuşma Dili" (Speech Language) başlığı altında, tanınmasını istediğiniz dili (örneğin, English (United States) veya Türkçe (Türkiye)) seçin.

Eğer paket yüklü değilse, Windows sizden bu paketi indirmenizi isteyecektir. Yüklemeyi tamamlayın.

Kullanım
Projeyi Visual Studio'da açın ve F5 tuşu ile başlatın. (Veya bin/Debug klasöründeki .exe dosyasını çalıştırın).

"Dinlemeye Başla" butonuna tıklayın.

Durum etiketi "Dinliyorum..." olarak değişecektir.

Mikrofona konuşun.

Konuşmanız algılandıkça, metin kutusuna eklenecektir.

Dinlemeyi sonlandırmak için "Durdur" butonuna tıklayın.
