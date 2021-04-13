using System;
using System.Collections.Generic;
using System.IO;

namespace sudokuCLI
{
    class Program
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
        static void Main(string[] args)
        {
            List<Feladvany> feladvanyok = new List<Feladvany>();
            StreamReader sr = new StreamReader("feladvanyok.txt");
            while (!sr.EndOfStream)
            {
                feladvanyok.Add(new Feladvany(sr.ReadLine()));
            }
            sr.Close();
            Console.WriteLine("3. feladat: Beolvasva {0} feladvány", feladvanyok.Count);

            int meret;

            do
            {
                Console.Write("4. feladat: Kérem a feladvány méretét [4..9]: ");
                meret = int.Parse(Console.ReadLine());
            } while (meret < 4 || meret > 9);

            List<Feladvany> nElemuFeladvany = new List<Feladvany>();
            foreach (var f in feladvanyok)
            {
                if (f.Meret == meret)
                {
                    nElemuFeladvany.Add(f);
                }
            }

            Console.WriteLine("{0}x{0} méretű feladványból {1} darab van tárolva", meret, nElemuFeladvany.Count);

            Random rand = new Random();
            int index = rand.Next(nElemuFeladvany.Count);
            var kivalasztottFeladvany = nElemuFeladvany[index];

            Console.WriteLine("5. feladat: A kiválasztott feladvány:");
            Console.WriteLine(kivalasztottFeladvany.Kezdo);

            double db = 0;
            foreach (char szamjegy in kivalasztottFeladvany.Kezdo)
            {
                if (szamjegy != '0')
                {
                    db++;
                }
            }
            Console.WriteLine("6. feladat: A feladvány kitöltöttsége: {0:f0}%", 100 * db / kivalasztottFeladvany.Kezdo.Length);

            Console.WriteLine("7. feladat: A feladvány kirajzolva:");
            kivalasztottFeladvany.Kirajzol();

            string fajlNev = string.Format("sudoku{0}.txt", meret);
            StreamWriter sw = new StreamWriter(fajlNev);
            foreach (var f in nElemuFeladvany)
            {
                sw.WriteLine(f.Kezdo);
            }
            Console.WriteLine("8. feladat: {0} állomány {1} darab feladvánnyal létrehozva", fajlNev, nElemuFeladvany.Count);
            sw.Close();

        }
    }
}
