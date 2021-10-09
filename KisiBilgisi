using System;
class KisiBilgi
{
    string adSoyad;
    int dogumTarihi;
    string dogumYeri;
    int okulNo;
    KisiBilgi(string adSoyadP, int dogumTarihiP, string dogumYeriP, int okulNoP)
    {
        adSoyad = adSoyadP;
        dogumTarihi = dogumTarihiP;
        dogumYeri = dogumYeriP;
        okulNo = okulNoP;
    }
    void bilgileriEkranaYaz()
    {
        Console.WriteLine($"Adınız Soyadınız:{adSoyad}");
        Console.WriteLine($"Doğum Tarihiniz:{dogumTarihi}");
        Console.WriteLine($"Doğum Yeriniz:{dogumYeri}");
        Console.WriteLine($"Okul Numarınız:{okulNo}");
        YasHesapla();

    }
    void YasHesapla()
    {
        int yas;
        yas = 2021 - dogumTarihi;
        Console.WriteLine($"Yaşınız:{yas}");
    }

    static void Main(string[] paramatreler)
    {
        KisiBilgi kisi1 = new KisiBilgi("Merve", 2005, "Adana", 13);
        kisi1.bilgileriEkranaYaz();

        KisiBilgi kisi2 = new KisiBilgi("Ali", 2006, "Mersin", 7);
        kisi2.bilgileriEkranaYaz();

        KisiBilgi kisi3 = new KisiBilgi("Murat", 2004, "Hatay", 58);
        kisi3.bilgileriEkranaYaz();
        Console.ReadKey();
    }

}
