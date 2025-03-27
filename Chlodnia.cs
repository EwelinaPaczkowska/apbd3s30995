namespace apbd3s30995;

public class Chlodnia : Kontener
{
    private List<Produkt> produkty;
    private double temp;
    private Produkt produkt;
    public Chlodnia(double wysokosc, double waga, double glebokosc, double max, double temp, Produkt produkt) : base(wysokosc, waga, glebokosc, max)
    {
        this.produkt = produkt;
        produkty = new List<Produkt>();
        this.temp = temp;
        rodzaj = "C";
    }

    public void dodanie(Produkt p)
    {
        if (produkty.Count == 0 && temp >= p.temperatura && produkt.nazwa == p.nazwa)
        {
            produkty.Add(p);
            Console.WriteLine("Dodano produkt: "+p.nazwa+" do kontenera: " + info());
        }
        else if (produkty.Exists(x => x.nazwa == p.nazwa))
        {
            produkty.Add(p);
            Console.WriteLine("Dodano produkt: "+p.nazwa+"do kontenera" + info());
        }
        else
        {
            Console.WriteLine("nie mozna dodac produktu");
        }
    }
}