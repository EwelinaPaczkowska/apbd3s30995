namespace apbd3s30995;

public class Gaz : Kontener, IHazardNotifier
{
    public Gaz(double wysokosc, double waga, double glebokosc, double max) : base(wysokosc, waga, glebokosc, max)
    { 
        rodzaj = "G";
    }
    public void Notify(string s)
    {
        Console.WriteLine(s);
    }
    public override void oproznienie()
    {
        Notify("Niebiezpieczne zdarzenie, zostawiamy 5% ladunku - kontener na gaz "+ info());
        masa *= 0.05;
    }
}