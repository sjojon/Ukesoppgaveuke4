namespace Ukesoppgaveuke4;

public class Car
{
    public string Make { get; private set; }
    public string RegistrationNumber { get; private set; }
    public int Year { get; private set; }
    public int Odometer { get; private set; }

    public Car(string make, string registrationNumber, int year, int odometer)
    {
        Make = make;
        RegistrationNumber = registrationNumber;
        Year = year;
        Odometer = odometer;
    }

    public void DisplayCarDetails()
    {
        Console.WriteLine(
            $"Make: {Make}\nRegistrationNumber: {RegistrationNumber}\nYear: {Year}\nOdometer: {Odometer}\n");
    }

    public void UpdateMake(string newMake)
    {
        Make = newMake;
    }

    public void UpdateRegistrationNumber(string newRegistrationNumber)
    {
        RegistrationNumber = newRegistrationNumber;
    }

    public void UpdateYear(int newYear)
    {
        Year = newYear;
    }

    public void UpdateOdometer(int newOdometer)
    {
        Odometer = newOdometer;
    }

    // Todo: La til disse for å kunne kjøre TestOlderCars testen:
    // Måtte spørre chatGPT til slutt da jeg ikke hadde sjans til å finne det ut,
    // og broren min kunne ikke komme på noe han heller i farta.
    // Men sa nå etterpå at det er ca sånn man må gjøre i Java også.
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        Car otherCar = (Car)obj;
        return Make == otherCar.Make &&
               RegistrationNumber == otherCar.RegistrationNumber &&
               Year == otherCar.Year &&
               Odometer == otherCar.Odometer;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Make, RegistrationNumber, Year, Odometer);
    }

    /*
     *
     * Når du sammenligner to objekter i C# ved hjelp av metoden Equals,
     * brukes standardimplementeringen av Equals-metoden som er arvet fra System.Object.
     * Denne standardimplementeringen sammenligner objektreferansene og returnerer true bare hvis
     * objektene refererer til samme minneadresse. I testen din ønsket du imidlertid å sammenligne
     * egenskapene til Car-objektene, ikke objektreferansene.

     * Derfor måtte du tilpasse Equals-metoden i Car-klassen slik at den sammenligner egenskapene til bilene. 
     * Ved å implementere Equals-metoden på denne måten, kan du nå sammenligne to Car-objekter og få riktig
     * resultat basert på egenskapene de inneholder.

     * Hva med GetHashCode-metoden? I C# brukes GetHashCode-metoden sammen med Equals-metoden for å
     * sikre at to objekter som er like (ifølge Equals-metoden), har samme hashkode.
     * Hashkoden brukes ofte i hashtabeller og hashsamlinger for raskt å finne objekter med samme egenskaper.
     * Ved å implementere GetHashCode-metoden i Car-klassen på en konsistent måte,
     * sikrer du at to Car-objekter med de samme egenskapene vil ha samme hashkode.

     * Så ved å implementere Equals-metoden og GetHashCode-metoden riktig,
     * sørget du for at SequenceEqual-metoden kunne sammenligne egenskapene til bilene i stedet for objektreferansene.
     * Dette gjorde at testen din passerte når de to listene med biler hadde identiske egenskaper.
     */
}