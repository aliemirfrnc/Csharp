using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            List<Ogrenci> ogrenciliste = new List<Ogrenci>();
            ogrenciliste.Add(new OrtaOkulOgrencisi("Zehra", "ACI", 354, 1990, 2019));
            ogrenciliste.Add(new IlkOkulOgrencisi("Esra", "ZEYBEK", 985, 2014, 2000));
            ogrenciliste.Add(new OrtaOkulOgrencisi("Ali", "AKIN", 654, 2010, 2020));
            ogrenciliste.Add(new IlkOkulOgrencisi("Ahmet", "EKER", 387, 2015, 2000));
            ogrenciliste.Add(new OrtaOkulOgrencisi("Ahmet", "ÇELİK", 658, 2011, 2022));
            ogrenciliste.Add(new IlkOkulOgrencisi("Arda", "AYDIN", 498, 2013, 2008));
            foreach (var herbirogrenci in ogrenciliste)
            {
                herbirogrenci.BilgileriEkranaYaz();
                if (herbirogrenci is IlkOkulOgrencisi)
                {
                    ((IlkOkulOgrencisi)herbirogrenci).ortaokuldanMezunOlmaYili();
                }
                else if (herbirogrenci is OrtaOkulOgrencisi)
                {
                    ((OrtaOkulOgrencisi)herbirogrenci).gidebileceğiOkullar();
                }
            }
        }
        catch (Exception HATA)
        {
            Console.WriteLine($"[HATA]:{HATA.Message}");
        }


        
    }
}
abstract class Ogrenci
{
    string ad;
    string soyad;
    int ogrenciNo;
    int dogumTarihi;
    int baslamaYili;
    public string Ad
    {
        get
        {
            return ad;
        }
        set
        {
            if (value.Trim().Length == 0)
            {
                throw new Exception("Ad Değeri boş olamaz");
            }
            else
            {
                ad = value;
            }
        }
    }
    public string Soyad
    {
        get
        {
            return soyad;
        }
        set
        {
            if (value.Trim().Length == 0)
            {
                throw new Exception("Soyad Değeri boş olamaz");
            }
            else
            {
                soyad = value;
            }
        }
    }
    public int OgrenciNo
    {
        get
        {
            return ogrenciNo;
        }
        set
        {
            if (value >= 100 && value <= 999)
            {
                ogrenciNo = value;
            }
            else
            {
                throw new Exception("Ogrenci No 3 Basamaklı olmalı!!");
            }
        }
    }
    public int DogumTarihi
    {
        get
        {
            return dogumTarihi;
        }
        set
        {
            if (value >= 1990 && value <= DateTime.Now.Year)
            {
                dogumTarihi = value;
            }
            else
            {
                throw new Exception("Dogum Tarihi 1990'dan büyük olmalı");
            }
        }
    }
    public int BaslamaYili
    {
        get
        {
            return baslamaYili;
        }
        set
        {
            if (value >= 1990 && value <= DateTime.Now.Year)
            {
                baslamaYili = value;
            }
            else
            {
                throw new Exception("Başlama Yılı 1990'dan büyük olmalı");
            }
        }
    }
    public int Yas
    {
        get
        {
            return DateTime.Now.Year - DogumTarihi;
        }
    }
    public Ogrenci(string adP,string soyadP,int ogrenciNoP,int dogumTarihiP,int baslamaYiliP)
    {
        this.Ad = adP;
        this.Soyad = soyadP;
        this.OgrenciNo = ogrenciNoP;
        this.DogumTarihi = dogumTarihiP;
        this.BaslamaYili = baslamaYiliP;
    }
    public abstract string enOnemliOlay();
    public virtual void BilgileriEkranaYaz()
    {
        Console.WriteLine("-----");
        Console.WriteLine($"Ad:{Ad}");
        Console.WriteLine($"Soyad:{Soyad}");
        Console.WriteLine($"Öğrenci No:{OgrenciNo}");
        Console.WriteLine($"Doğum Tarihi/Yaş:{DogumTarihi}-{Yas}");
        Console.WriteLine($"Başlama Yılı:{BaslamaYili}");
        Console.WriteLine("-----");


    }
}
interface IOgrencİslem
{
    string matematikDersİcerigi();
    int mezunOlacagiYas();
}
class IlkOkulOgrencisi : Ogrenci, IOgrencİslem
{
    public IlkOkulOgrencisi(string adP, string soyadP, int ogrenciNoP, int dogumTarihiP, int baslamaYiliP) : base(adP, soyadP, ogrenciNoP, dogumTarihiP, baslamaYiliP)
    {
        Console.WriteLine("İlk Okul Öğrenci Nesnesi Oluşturuldu");
    }

    public override string enOnemliOlay()
    {
        return "Yaz Kampları";
    }

    public string matematikDersİcerigi()
    {
        return "İlk Matematik";
    }

    public int mezunOlacagiYas()
    {
        return Yas + 4;
    }
    public override string ToString()
    {
        return $"{Ad} {Soyad}";
    }
    public override void BilgileriEkranaYaz()
    {
        base.BilgileriEkranaYaz();
        Console.WriteLine($"En Önemli Olay:{enOnemliOlay()}");
        Console.WriteLine($"Matematik Ders İçeriği:{matematikDersİcerigi()}");
        Console.WriteLine($"Mezun Olacağı Yaş:{mezunOlacagiYas()}");
    }
    public void ortaokuldanMezunOlmaYili()
    {
        Console.WriteLine($"OrtaOkuldan Mezun Olacagi Yıl:{BaslamaYili+8}");
    }
}
class OrtaOkulOgrencisi : Ogrenci, IOgrencİslem
{
    public OrtaOkulOgrencisi(string adP, string soyadP, int ogrenciNoP, int dogumTarihiP, int baslamaYiliP) : base(adP, soyadP, ogrenciNoP, dogumTarihiP, baslamaYiliP)
    {
        Console.WriteLine("OrtaOkul Öğrenci Nesnesi Oluşturuldu");
    }

    public override string enOnemliOlay()
    {
        return "LGS Sınavı";
    }

    public string matematikDersİcerigi()
    {
        return "Temel Matematik";
    }

    public int mezunOlacagiYas()
    {
        return Yas + 8;
    }
    public override string ToString()
    {
        return $"{Ad} {Soyad} {OgrenciNo}";
    }
    public override void BilgileriEkranaYaz()
    {
        base.BilgileriEkranaYaz();
        Console.WriteLine($"En Önemli Olay:{enOnemliOlay()}");
        Console.WriteLine($"Matematik Ders İçeriği:{matematikDersİcerigi()}");
        Console.WriteLine($"Mezun Olacağı Yaş:{mezunOlacagiYas()}");
    }
    public void gidebileceğiOkullar()
    {
        Console.WriteLine("Gidebileceği Okullar: MTAL, Anadolu Lisesi, Fen Lisesi");
    }
}
