using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        try
        {
        List<Ogrenci> ogrenciliste = new List<Ogrenci>();
        ogrenciliste.Add(new OrtaOkulOgrencisi("Zehra", "ACI", 354, 2009, 2019));
        ogrenciliste.Add(new IlkOkulOgrencisi("Esra", "ZEYBEK", 985, 2014, 2000));
        ogrenciliste.Add(new OrtaOkulOgrencisi("Ali", "AKIN", 654, 2010, 2020));
        ogrenciliste.Add(new IlkOkulOgrencisi("Ahmet", "EKER", 387, 2015, 2000));
        ogrenciliste.Add(new OrtaOkulOgrencisi("Ahmet", "ÇELİK", 658, 2011, 2022));
        ogrenciliste.Add(new IlkOkulOgrencisi("Arda", "AYDIN", 498, 2013, 2008));
        foreach (var ogrenciler in ogrenciliste)
        {
            ogrenciler.bilgileriEkranaYaz();
            if (ogrenciler is IlkOkulOgrencisi)
            {
                ((IlkOkulOgrencisi)ogrenciler).ortaokuldanMezunOlmaYılı();
            }
            else if(ogrenciler is OrtaOkulOgrencisi)
            {
                ((OrtaOkulOgrencisi)ogrenciler).GidebilecegiOkullar();
            }
        }
        Console.WriteLine("\n");
        Console.WriteLine("/////Silme İşleminden Sonra/////");    
        ogrenciliste.RemoveAt(3);
        foreach (var silindiktensonra in ogrenciliste)
        {
            silindiktensonra.bilgileriEkranaYaz();
            if (silindiktensonra is IlkOkulOgrencisi)
            {
                ((IlkOkulOgrencisi)silindiktensonra).ortaokuldanMezunOlmaYılı();
            }
            else if (silindiktensonra is OrtaOkulOgrencisi)
            {
                ((OrtaOkulOgrencisi)silindiktensonra).GidebilecegiOkullar();
            }
        }

        }
        catch (Exception Hata)
        {

            Console.WriteLine($"[Hata]:{Hata.Message}");
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
            if (value.Trim()=="")
            {
                throw new Exception("Ad Boş Geçilmez");
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
            if (value.Trim()=="")
            {
                throw new Exception("SoyAd Boş Geçilmez");
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
            if (value >=100 && value <=999)
            {
                ogrenciNo = value;
            }
            else
            {
                throw new Exception("3 Basamaklı Olmalı");
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
            if (value < DateTime.Now.Year && value > 1990)
            {
                dogumTarihi = value;
            }
            else
            {
                throw new Exception("Doğum Tarihi Hatalı");
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
            if (value < DateTime.Now.Year && value > 1990)
            {
                baslamaYili = value;
            }
            else
            {
                throw new Exception("Başlama Yılı Hatalı");
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
    public Ogrenci(string adP, string soyadP, int ogrenciNoP, int dogumTarihiP, int baslamaYiliP)
    {
        this.Ad = adP;
        this.Soyad = soyadP;
        this.OgrenciNo = ogrenciNoP;
        this.DogumTarihi = dogumTarihiP;
        this.BaslamaYili = baslamaYiliP;
    }
    public abstract string enOnemliOlay();
    public virtual void bilgileriEkranaYaz()
    {
        Console.WriteLine("/////////////////////");
        Console.WriteLine($"Ad Soyad:{Ad} {Soyad}");
        Console.WriteLine($"Öğrenci No:{OgrenciNo}");
        Console.WriteLine($"Doğum Tarihi:{DogumTarihi}/{Yas}");
        Console.WriteLine($"Başlama Yılı:{BaslamaYili}");        
    }    
}
interface IOgrenciİslem
{
    string MatematikDersİcerigi();
    int MezunOlacagiYas();
}
class IlkOkulOgrencisi : Ogrenci, IOgrenciİslem
{
    public IlkOkulOgrencisi(string adP, string soyadP, int ogrenciNoP, int dogumTarihiP, int baslamaYiliP) : base(adP, soyadP, ogrenciNoP, dogumTarihiP, baslamaYiliP)
    {
        Console.WriteLine("İlkOkul Öğrencisi Oluşturuldu");
    }

    public override string enOnemliOlay()
    {
        return "Yaz Kampı";
    }

    public string MatematikDersİcerigi()
    {
        return "İlk Matematik";
    }

    public int MezunOlacagiYas()
    {
        return Yas + 4;
    }
    public override void bilgileriEkranaYaz()
    {
        base.bilgileriEkranaYaz();
        Console.WriteLine($"En Önemli Olayı:{enOnemliOlay()}");
        Console.WriteLine($"Matematik Ders İçeriği:{MatematikDersİcerigi()}");
        Console.WriteLine($"Mezun Olacağı Yaş:{MezunOlacagiYas()}");
    }
    public override string ToString()
    {
        return $"{Ad} {Soyad}";
    }
    public void ortaokuldanMezunOlmaYılı()
    {
        Console.WriteLine($"OrtaOkuldan Mezun Olma Yılı:{BaslamaYili + 8}");
    }
}
class OrtaOkulOgrencisi : Ogrenci, IOgrenciİslem
{  
    public OrtaOkulOgrencisi(string adP, string soyadP, int ogrenciNoP, int dogumTarihiP, int baslamaYiliP) : base(adP, soyadP, ogrenciNoP, dogumTarihiP, baslamaYiliP)
    {
        Console.WriteLine("OrtaOkul Öğrenci Nesnesi Oluşturuldu");
    }
    public override string enOnemliOlay()
    {
        return "LGS Sınavı";
    }

    public string MatematikDersİcerigi()
    {
        return "Temel Matematik";
    }

    public int MezunOlacagiYas()
    {
        return Yas + 4;
    }
    public override void bilgileriEkranaYaz()
        {
            base.bilgileriEkranaYaz();
            Console.WriteLine($"En Önemli Olayı:{enOnemliOlay()}");
            Console.WriteLine($"Matematik Ders İçeriği:{MatematikDersİcerigi()}");
            Console.WriteLine($"Mezun Olacağı Yaş:{MezunOlacagiYas()}");
        }
    public void GidebilecegiOkullar()
        {
            Console.WriteLine("Gidebileceği Okullar: MTAL, Anadolu Lisesi, Fen Lisesi");
        }
}
