using System;
using System.Collections.Generic;
using System.IO;

namespace NFL
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Jatekos> jatekosok = new List<Jatekos>();
            foreach (var sor in File.ReadAllLines("NFL_iranyitok.txt"))
            {
                jatekosok.Add(new Jatekos(sor));
            }
            Console.WriteLine("5. feladat: A statisztikában {0} irányító szerepel", jatekosok.Count);

            Console.WriteLine("7. feladat: legjobb irányítók:");
            foreach (var j in jatekosok)
            {
                if (j.Mutató >= 100 && j.YardMeterben >= 4000)
                {
                    Console.WriteLine("\t {0} (irányító mutató: {1}. Passzok: {2}m",
                        j.FormazottNev(j.Név), j.Mutató, j.YardMeterben);
                }
            }

            Console.Write("8. feladat: Eladott labdák száma:");
            int eladott = int.Parse(Console.ReadLine());
            List<string> legtobbeteladott = new List<string>();
            foreach (var j in jatekosok)
            {
                if (j.Eladott > eladott)
                {
                    legtobbeteladott.Add(j.FormazottNev(j.Név));
                }
            }
            legtobbeteladott.Sort();
            File.WriteAllLines("legtobbeteladott.txt", legtobbeteladott);

            int legjobb = 0;
            for (int i = 1; i < jatekosok.Count; i++)
            {
                if (jatekosok[i].TDk >jatekosok[legjobb].TDk)
                {
                    legjobb = i;
                }
            }
            Console.WriteLine("9. feladat: A legtöbb TD-t szerző játékos:");
            Console.WriteLine("\t Neve: {0}", jatekosok[legjobb].Név);
            Console.WriteLine("\t TD-k száma: {0}", jatekosok[legjobb].TDk);
            Console.WriteLine("\t Eladott labdák száma: {0}", jatekosok[legjobb].Eladott);
        }
    }
}
