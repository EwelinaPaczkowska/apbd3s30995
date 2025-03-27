namespace apbd3s30995;

public class Kontenerowiec : IHazardNotifier
{
    protected static int licznik = 0;
    private List<Kontener> k;
    private double maks_predkosc;
    private int maks_liczba;
    private double maks_waga;
    private int numer;

    public Kontenerowiec(double maks_predkosc, int maks_liczba, double maks_waga)
    {
        this.maks_predkosc = maks_predkosc;
        this.maks_liczba = maks_liczba;
        this.maks_waga = maks_waga;
        k = new List<Kontener>();
        numer=++licznik;
    }
    public void Notify(string s)
    {
        Console.WriteLine(s);
    }

    public void dodaj_kontener(Kontener kontener)
    {
        if ((kontener.waga + kontener.masa) <= maks_waga && k.Count + 1 <= maks_liczba)
        {
            k.Add(kontener);
            Console.WriteLine("dodano: " + kontener.toString());
        }
        else
            Notify("za duza waga kontenera lub nie ma miejsca na statku");
    }

    public void dodaj_kilka_kontenerow(List<Kontener> kontenery)
    {
        double suma = 0;
        for (int i = 0; i < kontenery.Count; i++)
            suma += kontenery[i].masa + kontenery[i].waga;
        if (suma <= maks_waga && maks_liczba >= kontenery.Count + k.Count)
        {
            k.AddRange(kontenery);
            Console.WriteLine("zaladowano kontenery");
        }
        else
            Console.WriteLine("za duza waga kontenerow lub brak miejsca na tyle kontenerow na statku");
    }

    public void usun(Kontener kontener)
    {
        if (k.Contains(kontener))
        {
            k.Remove(kontener);
            Console.WriteLine("usnieto: " + kontener.info());
        }
        else
            Console.WriteLine("nie ma takiego kontenera na statku");
    }
    
    
    public void zastap(Kontenerowiec kontenerowiec, Kontener kontener, Kontener nowy)
    {
        if (k.Contains(kontener) && !k.Contains(nowy))
        {
            double nowy_masa = nowy.masa + nowy.waga;
            double kon_masa = kontener.masa + kontener.waga;
            if (nowy_masa <= maks_waga + nowy_masa
                && kon_masa <= kontenerowiec.maks_waga + kon_masa)
            {
                k.Remove(kontener);
                k.Add(nowy);
                kontenerowiec.dodaj_kontener(kontener);
                kontenerowiec.usun(nowy);
                Console.WriteLine("Dodano kontener: " + nowy.info() + " na kontenerowiec: " + numer);
            }
            else
                Console.WriteLine("za duza waga kontenera, zamiana niemozliwa");
        }
        else
            Console.WriteLine("Brak takiego konteneru na statku");
    }
    

    public void informacje()
    {
        if (k.Count == 0)
        {
            Console.WriteLine("statek o numerze: "+numer+" nie zawiera kontenerow");
        }
        else
        {
            Console.WriteLine("statek o numerze: "+numer+" zawiera");
            for (int i = 0; i < k.Count; i++)
            {
                Console.WriteLine(k[i].info());
            }
        }
    }
}