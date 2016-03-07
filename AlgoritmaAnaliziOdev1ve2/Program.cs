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
            while (aranacakAralikMax >= aranacakAralikMin)
            {
                sayac++;
                ortaindex = (aranacakAralikMax + aranacakAralikMin) / 2;
                ortadakieleman = MyArray[ortaindex];

                if (ortadakieleman == Number)
                {
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

            return -1;

        }

        static void Main(string[] args)
        {



            int[] diziboyutları = { 100, 1000, 10000, 100000, 1000000 };

            int[] herdizininhamlesayilari = { 0, 0, 0, 0, 0 };

            int[][] dizi = new int[diziboyutları.Length][];

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
                string[] gecenzaman = new string[5]; // her bir n için arama katsayısı

                for (int i = 0; i < dizi[k].Length; i++)
                {
                    int aranacakeleman = aranacak.Next(diziboyutları[k]);
                    Console.WriteLine("aranan" + aranacakeleman);

                    watch.Start();
                    int donen = elemanarama(dizi[k], aranacakeleman);
                    watch.Stop();

                    TimeSpan ts = watch.Elapsed;
                    gecenzaman[k] = String.Format("{0:00}:{1:00}:{2:00}.{3:00}.{4:00}",
                 ts.Hours, ts.Minutes, ts.Seconds, ts.TotalMilliseconds,
                 ts.Milliseconds / 10);

                    Console.WriteLine("zaman" + k + "=" + gecenzaman[k]);

                    if (donen == -1)
                    {
                        Console.WriteLine("aranan eleman dizide yok ");
                    }

                    else
                    {
                        Console.WriteLine(i + ".donen hamle");
                        herdizininhamlesayilari[k] = herdizininhamlesayilari[k] + donen;
                    }
                }


            }



            Console.ReadLine();
        }
    }
}
