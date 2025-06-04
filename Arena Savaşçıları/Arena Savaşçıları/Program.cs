using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena_Savaşçıları
{
    using System;
    using System.Collections.Generic;

    namespace OyunSimulasyonu
    {
        // Canlı sınıfı
        public abstract class Canli
        {
            public string Ad { get; set; }
            public int Can { get; set; }
            public int Mana { get; set; }
            public int Guc { get; set; }

            public Canli(string ad, int can, int mana, int guc)
            {
                Ad = ad;
                Can = can;
                Mana = mana;
                Guc = guc;
            }

            public virtual void TurSonuEtkisi() { }
        }

        // Oyuncu sınıfı
        public class Oyuncu : Canli
        {
            public Oyuncu(string ad, int can, int mana, int guc) : base(ad, can, mana, guc) { }

            public virtual void OzelSaldiri(List<Dusman> dusmanlar) // Özel saldırılar alanda bulunan tüm düşmanlara hasar verir.
            {
                if (Mana >= 50)
                {
                    Mana -= 50;
                    Console.WriteLine($"{Ad} özel saldırı yapıyor! Gücü: {Guc * 2}");
                    foreach (var dusman in dusmanlar)
                    {
                        dusman.Can -= Guc * 2;
                        Console.WriteLine($"{dusman.Ad} hasar aldı! Kalan canı: {dusman.Can}");
                    }
                }
                else
                {
                    Console.WriteLine($"Yeterli mana yok! (Mevcut Mana: {Mana})");
                }
            }

            public void NormalSaldiri(Dusman hedef)
            {
                if (Mana >= 20)
                {
                    Mana -= 20;
                    Console.WriteLine($"{Ad} {hedef.Ad}'e saldırıyor! Gücü: 30");
                    hedef.Can -= 30;
                    Console.WriteLine($"{hedef.Ad} hasar aldı! Kalan canı: {hedef.Can}");
                }
                else
                {
                    Console.WriteLine($"Yeterli mana yok! (Mevcut Mana: {Mana})");
                }
            }

            public void ManaYenile()
            {
                Mana += 30;
                Console.WriteLine($"{Ad}'ın manası yenilendi. Yeni Mana: {Mana}");
            }

            public void CanYenile()
            {
                if (Mana >= 30)
                {
                    Mana -= 30;
                    Can += 50;
                    Console.WriteLine($"{Ad} 50 can yeniledi! Yeni Can: {Can}, Yeni Mana: {Mana}");
                }
                else
                {
                    Console.WriteLine($"Yeterli mana yok! Can yenileme başarısız. (Mevcut Mana: {Mana})");
                }
            }

            public void DurumYazdir()
            {
                Console.WriteLine($"{Ad} Durum: Can: {Can}, Mana: {Mana}");
            }
        }

        public class Sovalye : Oyuncu
        {
            public Sovalye(string ad, int can, int mana, int guc) : base(ad, can, mana, guc) { }

            public override void OzelSaldiri(List<Dusman> dusmanlar)
            {
                if (Mana >= 50)
                {
                    Mana -= 50;
                    Console.WriteLine($"{Ad} özel saldırı yapıyor! Gücü: {Guc * 3}");
                    foreach (var dusman in dusmanlar)
                    {
                        dusman.Can -= Guc * 3;
                        Console.WriteLine($"{dusman.Ad} hasar aldı! Kalan canı: {dusman.Can}");
                    }
                }
                else
                {
                    Console.WriteLine($"Yeterli mana yok! (Mevcut Mana: {Mana})");
                }
            }
        }

        public class Sifaci : Oyuncu
        {
            public Sifaci(string ad, int can, int mana, int guc) : base(ad, can, mana, guc) { }

            public override void TurSonuEtkisi()
            {
                Can += 20;
                Console.WriteLine($"{Ad} kendini iyileştiriyor! Yeni Can: {Can}");
            }
        }

        public class Buyucu : Oyuncu
        {
            public Buyucu(string ad, int can, int mana, int guc) : base(ad, can, mana, guc) { }

            public override void TurSonuEtkisi()
            {
                Mana += 30;
                Console.WriteLine($"{Ad} manasını artırıyor! Yeni Mana: {Mana}");
            }
        }

        // Düşman sınıfı
        public class Dusman : Canli
        {
            public Dusman(string ad, int can, int mana, int guc) : base(ad, can, mana, guc) { }

            public void Saldiri(Oyuncu hedef)
            {
                int hasar = 0;
                if (Ad == "Zombi") hasar = 20;
                else if (Ad == "İskelet") hasar = 35;
                else if (Ad == "Ejderha") hasar = 60;

                hedef.Can -= hasar;
                Console.WriteLine($"{Ad} {hedef.Ad}'e saldırıyor! Verilen Hasar: {hasar}, {hedef.Ad}'ın Kalan Canı: {hedef.Can}");
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Karakter seçin: 1. Şövalye 2. Şifacı 3. Büyücü");
                int karakterSecimi;
                Oyuncu oyuncu;

                while (!int.TryParse(Console.ReadLine(), out karakterSecimi) || (karakterSecimi < 1 || karakterSecimi > 3))
                {
                    Console.WriteLine("Geçerli bir seçim yapın.");
                }

                switch (karakterSecimi)
                {
                    case 1:
                        oyuncu = new Sovalye("Şövalye", 200, 100, 20);
                        break;
                    case 2:
                        oyuncu = new Sifaci("Şifacı", 200, 100, 20);
                        break;
                    case 3:
                        oyuncu = new Buyucu("Büyücü", 200, 100, 20);
                        break;
                    default:
                        throw new Exception("Geçersiz karakter seçimi!");
                }

                // Düşman türleri
                Dusman zombi = new Dusman("Zombi", 50, 0, 20);
                Dusman iskelet = new Dusman("İskelet", 80, 0, 35);
                Dusman ejderha = new Dusman("Ejderha", 250, 0, 60);

                // Dalgalar
                for (int dalga = 1; dalga <= 5; dalga++)
                {
                    Console.WriteLine($"\n--- {dalga}. Dalga Başladı! ---");

                    List<Dusman> dusmanlar = new List<Dusman>();
                    switch (dalga) //Dalgaları 1. ve 2. dalgada 2 zombi gelmesi 3. ve 4. dalgada 3 iskelet gelmesi için ayarladım
                    {
                        case 1:
                        case 2:
                            dusmanlar.Add(new Dusman(zombi.Ad, zombi.Can, zombi.Mana, zombi.Guc));
                            dusmanlar.Add(new Dusman(zombi.Ad, zombi.Can, zombi.Mana, zombi.Guc));
                            break;

                        case 3:
                        case 4:
                            dusmanlar.Add(new Dusman(iskelet.Ad, iskelet.Can, iskelet.Mana, iskelet.Guc));
                            dusmanlar.Add(new Dusman(iskelet.Ad, iskelet.Can, iskelet.Mana, iskelet.Guc));
                            dusmanlar.Add(new Dusman(iskelet.Ad, iskelet.Can, iskelet.Mana, iskelet.Guc));
                            break;

                        case 5: // 5. dalgada ise bir boss fight koydum 1 iskelet 1 zombi 1 ejderha olacak şekilde
                            dusmanlar.Add(new Dusman(zombi.Ad, zombi.Can, zombi.Mana, zombi.Guc));
                            dusmanlar.Add(new Dusman(iskelet.Ad, iskelet.Can, iskelet.Mana, iskelet.Guc));
                            dusmanlar.Add(new Dusman(ejderha.Ad, ejderha.Can, ejderha.Mana, ejderha.Guc));
                            break;
                    }

                    // Dalga içi savaşlar
                    while (dusmanlar.Count > 0)
                    {
                        Console.WriteLine("\nOyuncu turu. Seçenekler:");
                        Console.WriteLine("1. Normal Saldırı (Mana 20, Hasar 30)");
                        Console.WriteLine("2. Özel Saldırı (Mana 50, Hasar karaktere göre)");
                        Console.WriteLine("3. Can Yenile (Mana 30, Can +50)");

                        int secim;
                        while (!int.TryParse(Console.ReadLine(), out secim) || secim < 1 || secim > 3)
                        {
                            Console.WriteLine("Geçerli bir seçim yapın.");
                        }

                        if (secim == 1)
                        {
                            Console.WriteLine("Hedef seçin:");
                            for (int i = 0; i < dusmanlar.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {dusmanlar[i].Ad} (Can: {dusmanlar[i].Can})");
                            }

                            int hedefIndex;
                            while (!int.TryParse(Console.ReadLine(), out hedefIndex) || hedefIndex < 1 || hedefIndex > dusmanlar.Count)
                            {
                                Console.WriteLine("Geçerli bir hedef seçin.");
                            }

                            oyuncu.NormalSaldiri(dusmanlar[hedefIndex - 1]);

                            if (dusmanlar[hedefIndex - 1].Can <= 0)
                            {
                                Console.WriteLine($"{dusmanlar[hedefIndex - 1].Ad} öldü!");
                                dusmanlar.RemoveAt(hedefIndex - 1);
                            }
                        }
                        else if (secim == 2)
                        {
                            oyuncu.OzelSaldiri(dusmanlar);
                            dusmanlar.RemoveAll(d => d.Can <= 0);
                        }
                        else if (secim == 3)
                        {
                            oyuncu.CanYenile();
                        }

                        if (dusmanlar.Count == 0)
                        {
                            Console.WriteLine("Tüm düşmanlar öldü, bir sonraki dalgaya geçiliyor...");
                            break;
                        }

                        // Düşman saldırıları
                        foreach (var dusman in dusmanlar)
                        {
                            dusman.Saldiri(oyuncu);
                            if (oyuncu.Can <= 0)
                            {
                                Console.WriteLine("Oyuncu öldü! Oyun bitti.");
                                return;
                            }
                        }

                        oyuncu.ManaYenile();
                        oyuncu.TurSonuEtkisi();
                        oyuncu.DurumYazdir();
                    }
                }

                Console.WriteLine("\nTebrikler! Tüm dalgaları tamamladınız.");
            }
        }
    }

}

