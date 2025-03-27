namespace apbd3s30995;

class Program
{
    static void Main(string[] args)
    {
        //kontener na plyn
        Kontener k1 = new Plyny(100, 10000,200, 20000, false);
        //zaladowanie ladunku
        //try{k1.zaladowanie();}
        //catch(Exception ex){Console.WriteLine(ex.Message);}
        
        //kontener na gaz
        Kontener k2 = new Gaz(100, 10000,200, 20000);
        //try{k2.zaladowanie();}
        //catch(Exception ex){Console.WriteLine(ex.Message);}
        Console.WriteLine(k2.toString());
        //oproznianie
        k2.oproznienie();
        
        //kontener na chlodnie
        Produkt p1 = new Produkt("bananas");
        Produkt p2 = new Produkt("chocolate");
        
        Chlodnia k3 = new Chlodnia(100, 10000,200, 20000, 15, p2);
        k3.dodanie(p1);
        k3.dodanie(p2);
        
        //tworzenie kontenerowca i dodanie kontenera na statek
        List<Kontener> k = new List<Kontener>();
        k.Add(k1);
        k.Add(k2);
        Kontenerowiec kontenerowiec = new Kontenerowiec(1000,12,120000);
        kontenerowiec.dodaj_kontener(k3);
        kontenerowiec.dodaj_kilka_kontenerow(k);
        Console.WriteLine(k1.toString());
        Console.WriteLine(k2.toString());
        Console.WriteLine(k3.toString()); 
    }
}
