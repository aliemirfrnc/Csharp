using System;

namespace _3SayıKucuktenBuyuge
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("1. Sayıyı Giriniz: ");
            int sayi1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("2. Sayıyı Giriniz: ");
            int sayi2 = Convert.ToInt16(Console.ReadLine());
            Console.Write("3. Sayıyı Giriniz: ");
            int sayi3 = Convert.ToInt16(Console.ReadLine());

            if (sayi1 > sayi2 && sayi1 > sayi3)
            {
                Console.WriteLine($"En Büyük Sayı:{sayi1}");
                if (sayi2 > sayi3)
                {
                    Console.WriteLine($"Ortanca Sayı:{sayi2}");
                    Console.WriteLine($"En Küçük Sayı:{sayi3} ");
                }
                else
                {
                    Console.WriteLine($"Ortanca Sayı:{sayi3}");
                    Console.WriteLine($"En Küçük Sayı:{sayi2}");
                }
            }
            else if (sayi2 > sayi1 && sayi2 > sayi3)
            {
                Console.WriteLine($"En Büyük Sayı:{sayi2}");
                if (sayi1 > sayi3)
                {
                    Console.WriteLine($"Ortanca Sayı:{sayi1}");
                    Console.WriteLine($"En küçük Sayı:{sayi3}");
                }
                else
                {
                    Console.WriteLine($"Ortanca Sayı:{sayi3}");
                    Console.WriteLine($"En Küçük Sayı:{sayi1}");
                }
            }
            else
            {
                Console.WriteLine($"En Büyük Sayı:{sayi3}");
                if (sayi2 > sayi1)
                {
                    Console.WriteLine($"Ortanca Sayı:{sayi2}");
                    Console.WriteLine($"En küçük Sayı:{sayi1}");
                }
                else
                {
                    Console.WriteLine($"Ortanca Sayı:{sayi1}");
                    Console.WriteLine($"En küçük Sayı:{sayi2}");
                }
            }
            Console.ReadKey();
        }
    }
}
