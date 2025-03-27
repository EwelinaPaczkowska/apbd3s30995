namespace apbd3s30995;

public class Kontener
{
    protected static int licznik = 0;
    public string czlon = "KON";
    public double max;
    public double masa;
    public double waga;
    public double wysokosc;
    public double glebokosc;
    public string rodzaj;
    private int numer;

    public Kontener(double max, double waga, double wysokosc, double glebokosc)
    {
        this.max = max;
        this.waga = waga;
        this.wysokosc = wysokosc;
        this.glebokosc = glebokosc;
        this.masa = 0;
        numer = ++licznik;
    }

    public virtual void oproznienie()
    {
        masa = 0;
        Console.WriteLine("oprozniono "+ info());
    }

    public virtual void zaladowanie()
    {
        Console.WriteLine("wpisz mase: ");
        string input = Console.ReadLine();
        double masa_zaladuj = Int32.Parse(input);
        if(max<masa+masa_zaladuj)
            throw new OverfillException("masa nie moze przekraczac maksymalnej ladownosci");
        else
            masa += masa_zaladuj;
    }
    public String toString()
    {
        return "kontener: " + info() + " masa ladunku w kg: " + masa + " glebokosc: " + glebokosc + " wysokosc: " + wysokosc;
    }

    public String info()
    {
        return czlon + "-" + rodzaj + "-" + numer;
    }
}

public class OverfillException : Exception
{
    public OverfillException(string message) : base(message) { }
}