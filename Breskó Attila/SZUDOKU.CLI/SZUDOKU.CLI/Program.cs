using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZUDOKU.CLI
{
    class Feladvany
    {
        public string Kezdo { get; private set; }
        public int Meret { get; private set; }

        public Feladvany(string sor)
        {
            Kezdo = sor;
            Meret = Convert.ToInt32(Math.Sqrt(sor.Length));
        }

        public void Kirajzol()
        {
            for (int i = 0; i < Kezdo.Length; i++)
            {
                if (Kezdo[i] == '0')
                {
                    Console.Write(".");
                }
                else
                {
                    Console.Write(Kezdo[i]);
                }
                if (i % Meret == Meret - 1)
                {
                    Console.WriteLine();
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            StreamReader fb = new StreamReader("feladvanyok.txt");
            List<Feladvany> list = new List<Feladvany>();
            while(!fb.EndOfStream)
            {
                Feladvany temp = new Feladvany(fb.ReadLine());
                list.Add(temp);
            }
            fb.Close();
            Console.WriteLine($"3.Feladat: Beolvasva {list.Count} feladvány");
            int s = 0;
            do
            {
                Console.Write("4.Feladat: Kérem a feladvány méretét[4..9]: ");
                s = int.Parse(Console.ReadLine());
             } while (s < 4 || s > 9) ;

            int db = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Meret == s)
                {
                    db++;
                }
            }
            Console.WriteLine($"{s}x{s} méretű feladványból {db} darab van tárolva");
            string kiv = "";
            int idx = 0;
            do
            {
                Random r = new Random();
                idx = r.Next(0, list.Count);
                kiv = list[idx].Kezdo;
            } while (kiv.Length != s * s);
            Console.WriteLine("5. Feladat: A kiválasztott feladvány:");
            Console.WriteLine(kiv);

            db = 0;
            for (int i = 0; i < kiv.Length; i++)
            {
                if(kiv[i] != '0')
                {
                    db++;
                }
            }
            Console.WriteLine("6.Feladat: A feladvány kitöltöttsége: " + Math.Round((double)db / kiv.Length * 100, 0)+"%");

            Console.WriteLine("7.Feladat: A feladvány kirajzolva:");
            list[idx].Kirajzol();

            StreamWriter fk = new StreamWriter($"sudoku{s}.txt");
            List<Feladvany> kivalogat = new List<Feladvany>();
            for (int i =0; i < list.Count;i++)
            {
                if(list[i].Meret == s)
                {
                    kivalogat.Add(list[i]);
                    fk.WriteLine(list[i].Kezdo);
                }
            }
            Console.WriteLine($"8. Feladat: sudoku{s}.txt állomány {kivalogat.Count} feladvánnyal létrehozva");
            fk.Close();
            Console.ReadLine();
            
        }
    }
}
