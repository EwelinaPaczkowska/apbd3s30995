namespace apbd3s30995;

public class Plyny : Kontener, IHazardNotifier
{
    public bool nb;
    public Plyny(double max, double waga, double wysokosc, double glebokosc, bool nb) :
        base(max, waga, wysokosc, glebokosc)
    {
        rodzaj = "L";
        this.nb = nb;
    }
    public void Notify(string s)
    {
        Console.WriteLine(s);
    }

    public override void zaladowanie()
    {
        Console.WriteLine("wpisz mase: ");
        string input = Console.ReadLine();
        double masa_zaladuj = Int32.Parse(input);
        if (nb)
        {
            if (masa_zaladuj + waga + masa > max * 0.5)
            {
                Notify("Niebezpieczny ladunek, mozna zaladowac tylko 50% pojemnosci do kontenera: " + info());
                throw new OverfillException("niebezpieczna sytuacja kontenera: " + info());
            }
            else
            {
                masa += masa_zaladuj;
                Console.WriteLine("Kontener: " + info() + " zaladowany, masa ladunku w kg: " + masa);
            }
        }
        else if (masa_zaladuj + masa + waga > max * 0.9)
        {
            throw new OverfillException("niebezpieczna sytuacja kontenera: " + info()
                                                                             + " masa nie moze przekraczac maksymalnej ladownosci");
        }
        else
        {
            masa += masa_zaladuj;
            Console.WriteLine("Kontener: " + info() + " zaladowany, masa ladunku w kg: " + masa);
        }
    }
}

