namespace apbd3s30995;

public class Produkt
{
    public string nazwa;
    public double temperatura;

    public Produkt(string nazwa)
    {
        this.nazwa = nazwa;
        switch (nazwa.ToLower())
        {
            case "bananas":
                temperatura = 13.3;
                break;
            case "chocolate":
                temperatura = 18;
                break;
            case "fish":
                temperatura = 2;
                break;
            case "meat":
                temperatura = -15;
                break;
            case "ice cream":
                temperatura = -18;
                break;
            case "frozen pizza":
                temperatura = -30;
                break;
            case "cheese":
                temperatura = 7.2;
                break;
            case "sausages":
                temperatura = 5;
                break;
            case "butter":
                temperatura = 20.5;
                break;
            case "eggs":
                temperatura = 19;
                break;
            default:
                throw new ArgumentException("nieznany produkt");
        }
    }
}
