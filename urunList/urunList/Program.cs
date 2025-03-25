using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    class Urun
    {
        public int Kod { get; set; }
        public string Ad { get; set; }
        public int Miktar { get; set; }
        public decimal BirimFiyat { get; set; }


    }
    static List<Urun> urunler = new List<Urun>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("1-Ürün Ekle");
            Console.WriteLine("2-Ürün Listele");
            Console.WriteLine("3-Ürün Güncelle");
            Console.WriteLine("4-Ürün Ara");
            Console.WriteLine("5-Ürün Sil");
            Console.WriteLine("6-Toplam Stok Değeri");
            Console.WriteLine("0-ÇIKIŞ");
            Console.WriteLine("Seçiminiz:");

            switch(Console.ReadLine())
            {
                case "1":
                    UrunEkle();
                    break;
                case "2":
                    UrunListele();
                    break;
                case "3":
                    Console.Write("Güncellenecek ürün kodunu giriniz : ");
                    int kodGuncelle = int.Parse(Console.ReadLine());
                    UrunGuncelle(kodGuncelle);
                    break;
                case "4":
                    Console.WriteLine("Aranacak ürün kodunu giriniz : ");
                    int kodAra = int.Parse(Console.ReadLine());
                    UrunAra(kodAra);
                    break;
                case "5":
                    Console.WriteLine("Silinecek ürün kodunu giriniz : ");
                    int kodSil = int.Parse(Console.ReadLine());
                    UrunSil(kodSil);
                    break;
                case "6":
                    ToplamStokDegeri();
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("GEÇERSİZ SEÇİM!!");
                    break;
            }
        }

    }

    private static void ToplamStokDegeri()
    {
       decimal toplam = urunler.Sum(urunler => urunler.Miktar * urunler.BirimFiyat);
        Console.WriteLine($"Toplam Stok Değeri : {toplam}");
    }

    private static void UrunSil(int kodSil)
    {
        var urun = urunler.FirstOrDefault(urunler => urunler.Kod == kodSil);
        if(urun != null)
        {
        urunler.Remove(urun);
            Console.WriteLine("Ürün Silindi.");
        }
        else
        {
            Console.WriteLine("Ürün Bulunamadı.");
        }
    }

    private static void UrunGuncelle(int kodGuncelle)
    {
       var urun = urunler.FirstOrDefault(urunler => urunler.Kod == kodGuncelle);
        if(urun != null)
        {
            Console.WriteLine("Yeni ürün adı : ");
            urun.Ad = Console.ReadLine();
            Console.WriteLine("Yeni ürün miktarı : ");
            urun.Miktar = int.Parse(Console.ReadLine());
            Console.WriteLine("Yeni ürün birim fiyatı : ");
            urun.BirimFiyat = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Ürün Güncellendi.");
        }
        else
        {
            Console.WriteLine("Ürün Bulunamadı.");
        }
    }

    private static void UrunAra(int kodAra)
    {
        var urun = urunler.FirstOrDefault(urunler => urunler.Kod == kodAra);
        if (urun != null)
        {
            Console.WriteLine($"Kod : {urun.Kod} Ad : {urun.Ad} Miktar : {urun.Miktar} Birim Fiyat : {urun.BirimFiyat}");
        }
        else
        {
            Console.WriteLine("Ürün Bulunamadı.");
        }
    }

    private static void UrunListele()
    {
        if(urunler.Count == 0)
        {
            Console.WriteLine("Ürün Bulunamadı.");
            return;
        }
        Console.WriteLine("-----------------------------");
        foreach (var urun in urunler)
        {
            Console.WriteLine($"Kod : {urun.Kod} Ad : {urun.Ad} Miktar : {urun.Miktar} Birim Fiyat : {urun.BirimFiyat}");
            Console.WriteLine("-----------------------------");
        }
    }

    private static void UrunEkle()
    {
        Urun urun = new Urun();
        Console.Write("Ürün Kodu : ");
        urun.Kod = int.Parse(Console.ReadLine());
        Console.Write("Ürün Adı : ");
        urun.Ad = Console.ReadLine();
        Console.Write("Ürün Miktarı : ");
        urun.Miktar = int.Parse(Console.ReadLine());
        Console.Write("Ürün Birim Fiyatı : ");
        urun.BirimFiyat = decimal.Parse(Console.ReadLine());
        urunler.Add(urun);
        Console.WriteLine("Ürün Eklendi.");
    }
}