using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AlgoritmaAnaliziOdev1ve2
{
    class Program
    {
        public static int elemanarama(int[] MyArray, int Number)
        {

            int aranacakAralikMin = 0;

            int aranacakAralikMax = MyArray.Length - 1;

            int ortadakieleman = 0;

            int ortaindex;
            int sayac = 0;
            int kontrol = 0;
            while (aranacakAralikMax >= aranacakAralikMin)
            {
                sayac++;
                ortaindex = (aranacakAralikMax + aranacakAralikMin) / 2;
                ortadakieleman = MyArray[ortaindex];

                if (ortadakieleman == Number)
                {
                    kontrol = 1;
                    Console.WriteLine("aranan sayi bulundu " + ortaindex + " ıncı eleman");
                    return sayac;
                }

                else if (ortadakieleman > Number)
                {
                    aranacakAralikMin = ((aranacakAralikMax + aranacakAralikMin) / 2) + 1;

                }
                else
                {
                    aranacakAralikMax = ((aranacakAralikMax + aranacakAralikMin) / 2) - 1;

                }

            }
            return sayac;
            if (kontrol == 0) { Console.WriteLine("sayi yok"); }

        }

        static void Main(string[] args)
        {



            int[] diziboyutları = { 10,100, 1000, 10000, 100000, 1000000 };

            int[] herdizininhamlesayilari = { 0, 0, 0, 0, 0 };

            int[][] dizi = new int[diziboyutları.Length][];

            Double[] gecenzaman = new Double[5]; // her bir n için arama katsayısı

            int dizisayac = 0;

            for (int k = 0; k < diziboyutları.Length; k++)
            {
                
                dizisayac++;

                dizi[k] = new int[diziboyutları[k]];

                Random yeni = new Random();

                for (int i = 0; i < diziboyutları[k]; i++)
                {
                    int sayi = yeni.Next(diziboyutları[k]);

                    //dizi[k][i] = i;
                    dizi[k][i] = sayi;
                }

                Array.Sort(dizi[k]);

                Console.WriteLine("dizi " + k + " elemanları");
                for (int i = 0; i < dizi[k].Length; i++)
                {
                    Console.WriteLine(i + ". eleman=" + dizi[k][i]);

                }
                Random aranacak = new Random();
                Stopwatch watch = new Stopwatch();
              

                for (int i = 0; i < dizi[k].Length; i++)
                {
                    int aranacakeleman = aranacak.Next(diziboyutları[k]);
                    Console.WriteLine("aranan" + aranacakeleman);

                    watch.Start();
                    int donen = elemanarama(dizi[k], aranacakeleman);
                    watch.Stop();

                    TimeSpan ts = watch.Elapsed;
                    gecenzaman[k] = gecenzaman[k]+ts.TotalMilliseconds;
                   

                    Console.WriteLine("zaman" + k + "=" + gecenzaman[k]);

                    Console.WriteLine(i + ".donen hamle"+donen);

                    herdizininhamlesayilari[k] = herdizininhamlesayilari[k] + donen;
                    
                }
                if (k == 5)
                {
                    Console.WriteLine(herdizininhamlesayilari[k] + "hamle");
                    break;
                   
                }
                
            }



         
            Console.ReadLine();
        }
    }
}
