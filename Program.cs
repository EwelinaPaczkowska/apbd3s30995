namespace apbd3s30995;

class Program
{
    static void Main(string[] args)
    {
        //kontener na plyn
        Kontener k1 = new Plyny(100, 10,200, 20000, false);
        //zaladowanie ladunku
        //try{k1.zaladowanie();}
        //catch(Exception ex){Console.WriteLine(ex.Message);}
        //Console.WriteLine(k1.toString());
        
        //kontener na gaz
        Kontener k2 = new Gaz(100, 10000,200, 20000);
        //try{k2.zaladowanie();}
        //catch(Exception ex){Console.WriteLine(ex.Message);}
        //Console.WriteLine(k2.toString());
        //oproznianie
        k2.oproznienie();
        Console.WriteLine(k2.toString());
        
        //kontener na chlodnie
        Produkt p1 = new Produkt("bananas");
        Produkt p2 = new Produkt("chocolate");
        
        Chlodnia k3 = new Chlodnia(100, 10000,200, 20000, 15, p1);
        k3.dodanie(p1);
        k3.dodanie(p2);
        
        //tworzenie kontenerowca i dodanie kontenera na statek
        List<Kontener> k = new List<Kontener>();
        k.Add(k1);
        k.Add(k2);
        Kontenerowiec kontenerowiec = new Kontenerowiec(1000,3,120000);
        kontenerowiec.dodaj_kontener(k3);
        kontenerowiec.dodaj_kilka_kontenerow(k);
        kontenerowiec.rozladuj();
        kontenerowiec.informacje();
        Kontenerowiec kontenerowiec2 = new Kontenerowiec(1000,2,120000);
        kontenerowiec2.dodaj_kilka_kontenerow(k);
        kontenerowiec.dodaj_kontener(k3);
        kontenerowiec2.przenies(kontenerowiec, k1);
        kontenerowiec.informacje();
        kontenerowiec2.informacje();
        Console.WriteLine("====================");
        Chlodnia k4 = new Chlodnia(100, 10000,200, 20000, 15, p2);
        kontenerowiec.zastap(kontenerowiec2,k2,k1);
        kontenerowiec.informacje();
        kontenerowiec2.informacje();
        kontenerowiec2.usun(k4);
    }
}
