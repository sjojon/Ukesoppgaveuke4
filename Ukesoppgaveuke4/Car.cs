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

    public void DisplayCarDetails() //Displays the details of the book (title, author, genre, quantity).
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
}