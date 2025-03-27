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
            Console.WriteLine("dodano: " + kontener.info());
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
            Console.WriteLine("usunieto: " + kontener.info());
        }
        else
            Console.WriteLine("nie ma takiego kontenera na statku");
    }

    public void rozladuj()
    {
        k.Clear();
    }

    public void przenies(Kontenerowiec nowy, Kontener kontener)
    {
        if (k.Contains(kontener))
        {
            double suma = 0;
            foreach (var kont in nowy.k)
            {
                suma += kont.masa + kont.waga / 1000;
            }
        
            if (suma + (kontener.masa + kontener.waga) / 1000 <= nowy.maks_waga && nowy.k.Count < nowy.maks_liczba)
            {
                k.Remove(kontener);
                nowy.dodaj_kontener(kontener);
                Console.WriteLine("Kontener: "+ kontener.info() + " przeniesiony z " + numer + " na kontenerowiec: " + nowy.numer);
            }
            else
            {
                Console.WriteLine("Za duża waga kontenera lub przekroczono dopuszczalną liczbę kontenerów na nowym statku.");
            }
        }
        else
        {
            Console.WriteLine("Nie ma takiego kontenera na statku.");
        }
    }
    
    public void zastap(Kontenerowiec kontenerowiec, Kontener kontener, Kontener nowy)
    {
        if (kontenerowiec.k.Contains(kontener) && !kontenerowiec.k.Contains(nowy))
        {
            double suma1 = 0;
            foreach (var kont in kontenerowiec.k)
            {
                suma1 += kont.masa + kont.waga / 1000;
            }

            double suma2 = 0;
            foreach (var kont in k)
            {
                suma2 += kont.masa + kont.waga / 1000;
            }
            
            if (kontenerowiec.maks_waga >= suma1 - (kontener.masa + kontener.waga) / 1000 + (nowy.masa + nowy.waga) / 1000
                && kontenerowiec.k.Count-1 + 1 <= kontenerowiec.maks_liczba &&
                maks_waga >= suma2 + (kontener.masa + kontener.waga) / 1000 - (nowy.masa + nowy.waga) / 1000
                    && k.Count-1 + 1 <= maks_liczba)
            {
                kontenerowiec.usun(kontener);
                kontenerowiec.dodaj_kontener(nowy);
                k.Remove(nowy);
                k.Add(kontener);
                Console.WriteLine("Zamieniono kontener " + kontener.info() + " na kontener: " + nowy.info());
            }
            else
            {
                Console.WriteLine("Za duża waga kontenerów lub za dużo kontenerów na statku.");
            }
        }
        else
        {
            Console.WriteLine("Brak takiego kontenera na statku.");
        }
    }

    public String toString()
    {
        return "kontenerowiec: " + numer + " maks_ladownosc w tonach: " + maks_waga + " maks_liczba: " + maks_liczba
               + " maks_predkosc: " + maks_predkosc;
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