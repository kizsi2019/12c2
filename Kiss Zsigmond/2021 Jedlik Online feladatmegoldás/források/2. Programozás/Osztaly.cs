class Jatekos
{
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
