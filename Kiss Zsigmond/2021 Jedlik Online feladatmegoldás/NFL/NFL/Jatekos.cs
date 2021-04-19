using System;
using System.Collections.Generic;
using System.Text;

namespace NFL
{
    class Jatekos
    {
        public String Név { get; set; }
        public int Yardok { get; set; }
        public int Kísérletek{ get; set; }
        public int Passzok{ get; set; }
        public int TDk{ get; set; }
        public int Eladott  { get; set; }
        public double Mutató{ get; set; }
        public string Egyetem { get; set; }
        public int YardMeterben
        {
            get
            {
                return (int)Math.Round(Yardok * 0.9144);
            }
        }

        public Jatekos(string sor)
        {
            string[] adatok = sor.Split(';');
            Név = adatok[0];
            Yardok = int.Parse(adatok[1]);
            Kísérletek = int.Parse(adatok[2]);
            Passzok = int.Parse(adatok[3]);
            TDk = int.Parse(adatok[4]);
            Eladott = int.Parse(adatok[5]);
            Mutató = Konvertal(adatok[6]);
            Egyetem = adatok[7]; 
            

        }


        private double Konvertal(string iranyitoMutato)
        {
            var decimalSeparator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            iranyitoMutato = iranyitoMutato.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            if (double.TryParse(iranyitoMutato, out var ertek))
                return ertek;
            throw new FormatException("Hibás érték (irányítómutató)");
        }

        public string FormazottNev(string nev)
        {
            var n = nev.Split(' ');
            n[n.Length - 1] = n[n.Length - 1].ToUpper();
            return string.Join(" ", n);
        }
    }
}
