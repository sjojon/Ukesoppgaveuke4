namespace Ukesoppgaveuke4;

public class Dealership
{
    public string Name { get; set; }
    public string Address { get; set; }
    public List<Car> Cars { get; set; }

    public Dealership(string name, string address, List<Car> cars)
    {
        Name = name;
        Address = address;
        Cars = cars;
    }

    public void DisplayAllCars()
    {
        Console.WriteLine("Cars currently in the dealership:");
        Console.WriteLine();
        foreach (var car in Cars)
        {
            car.DisplayCarDetails();
        }
    }

    public void AddCar(Car car)
    {
        Cars.Add(car);
    }

    public void SellCar(Car car)
    {
        Cars.Remove(car);
    }

    public int FindCarIndex(string registrationNumber)
    {
        string lowerRegistrationNumber = registrationNumber.ToLower();
        for (int i = 0; i < Cars.Count; i++)
        {
            if (Cars[i].RegistrationNumber.ToLower() == lowerRegistrationNumber)
            {
                return i;
            }
        }

        return -1;
    }

    public Car GetCar(int index)
    {
        if (index >= 0 && index < Cars.Count)
        {
            return Cars[index];
        }
        else
        {
            throw new IndexOutOfRangeException("Invalid registration number!");
        }
    }

    public List<Car> GetOlderCars(int year)
    {
        List<Car> olderCars = new();
        foreach (Car car in Cars)
        {
            if (car.Year <= year)
            {
                olderCars.Add(car);
            }
        }

        return olderCars;
    }

    public List<Car> GetCarsByKm(int km)
    {
        return Cars.Where(car => car.Odometer <= km).ToList();
    }
}