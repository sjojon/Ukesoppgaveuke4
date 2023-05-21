using Ukesoppgaveuke4;

Console.WriteLine("Welcome to the car dealership!");
Console.WriteLine();

Dealership dealership = new("Autostrada", "Skiensveien 12", new List<Car>());
{
    dealership.AddCar(new Car("Mercedes", "ABC123", 2010, 100000));
    dealership.AddCar(new Car("Toyota", "DEF456", 2014, 85000));
    dealership.AddCar(new Car("Mazda", "GHI789", 2019, 43900));
}

Car car1 = new Car("Land Rover", "FWP385", 2005, 430000);
dealership.AddCar(car1);
Car car2 = new Car("BMW", "GCV856", 2018, 30000);
dealership.AddCar(car2);
Car car3 = new Car("Ford", "VTW294", 2012, 233000);
dealership.AddCar(car3);


Menu(dealership);


void Menu(Dealership dealer)
{
    bool flag = true;
    while (flag)
    {
        Console.WriteLine("Menu:\n" +
                          "1. Add car\n" +
                          "2. Display all cars\n" +
                          "3. Search cars by year\n" +
                          "4. Search cars by km\n" +
                          "5. Edit cars\n" +
                          "6. Clear screen\n" +
                          "7. Exit");
        string inputAnswer = Console.ReadLine();
        bool number = int.TryParse(inputAnswer, out int answer);

        if (number)
        {
            switch (answer)
            {
                case 1:
                    CarToAdd(dealer);
                    break;
                case 2:
                    Console.Clear();
                    dealer.DisplayAllCars();
                    break;
                case 3:
                    ShowOlderCarsByYear();
                    break;
                case 4:
                    ShowCarsByKm();
                    break;
                case 5:
                    Console.Clear();
                    Console.Clear();
                    dealer.DisplayAllCars();
                    EditMenu(dealership);
                    break;
                case 6:
                    Console.Clear();
                    break;
                case 7:
                    flag = false;
                    break;
                default:
                    Console.WriteLine("Please enter a number between 1 and 7!");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Please enter a number!");
        }
    }
}

void ShowCarsByKm()
{
    Console.WriteLine("Enter the number you want to show cars odometer lower than:");
    int kmToFind = int.Parse(Console.ReadLine());
    List<Car> carsByKm = dealership.GetCarsByKm(kmToFind);
    Console.Clear();
    if (carsByKm.Count == 0)
    {
        Console.WriteLine("No cars found!");
    }
    else
    {
        Console.WriteLine($"Cars with less or equal km to {kmToFind}:");
        Console.WriteLine();
        foreach (var car in carsByKm)
        {
            car.DisplayCarDetails();
        }
    }
}

void ShowOlderCarsByYear()
{
    Console.WriteLine("Enter the year you want to show cars included and older than:");
    int yearToFind = int.Parse(Console.ReadLine());
    List<Car> olderCars = dealership.GetOlderCars(yearToFind);
    Console.Clear();
    if (olderCars.Count == 0)
    {
        Console.WriteLine("No cars found!");
    }
    else
    {
        Console.WriteLine($"Cars older than {yearToFind}:");
        Console.WriteLine();
        foreach (var car in olderCars)
        {
            car.DisplayCarDetails();
        }
    }
}

void CarToAdd(Dealership dealer1)
{
    Console.WriteLine("Please enter a car to add:");
    Console.WriteLine("Make:");
    string make = Console.ReadLine();
    Console.WriteLine("RegistrationNumber:");
    string registrationNumber = Console.ReadLine();
    Console.WriteLine("Year:");
    int year = int.Parse(Console.ReadLine());
    Console.WriteLine("Odometer:");
    int odometer = int.Parse(Console.ReadLine());

    dealer1.AddCar(new Car(make, registrationNumber, year, odometer));
    Console.Clear();
    dealer1.DisplayAllCars();
}

void EditMenu(Dealership dealers)
{
    Console.WriteLine("Enter the registration number of the car you want to edit:");
    string getIndex = Console.ReadLine().ToLower();
    Console.Clear();
    int index = dealers.FindCarIndex(getIndex);

    if (index == -1) return;
    Car car = dealers.GetCar(index);
    car.DisplayCarDetails();
    Console.WriteLine(
        "What property do you want to edit?\n1. Make\n2. Registration number\n3. Year\n4. Odometer\n5. Sell car");
    string inputAnswer = Console.ReadLine();
    bool number = int.TryParse(inputAnswer, out int answer);
    if (number)
    {
        switch (answer)
        {
            case 1:
                Console.WriteLine("Edit Make:");
                string newMake = Console.ReadLine();
                car.UpdateMake(newMake);
                Console.Clear();
                car.DisplayCarDetails();
                Console.WriteLine("Make updated");
                Console.WriteLine();

                break;
            case 2:
                Console.WriteLine("Edit Registration number:");
                string newRegistrationNumber = Console.ReadLine();
                car.UpdateRegistrationNumber(newRegistrationNumber);
                Console.Clear();
                car.DisplayCarDetails();
                Console.WriteLine("Registration number updated");
                Console.WriteLine();

                break;
            case 3:
                Console.WriteLine("Edit Year:");
                int newYear = int.Parse(Console.ReadLine());
                car.UpdateYear(newYear);
                Console.Clear();
                car.DisplayCarDetails();
                Console.WriteLine("Genre updated");
                Console.WriteLine();

                break;
            case 4:
                Console.WriteLine("Edit Odometer");
                int newOdometer = int.Parse(Console.ReadLine());
                car.UpdateOdometer(newOdometer);
                Console.Clear();
                car.DisplayCarDetails();
                Console.WriteLine("Odometer updated");
                Console.WriteLine();

                break;
            case 5:
                dealership.SellCar(car);
                car.DisplayCarDetails();
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("CAR SOLD!");
                Console.WriteLine();

                break;
            default:
                Console.WriteLine("Invalid choice");
                break;
        }
    }

    else
    {
        Console.WriteLine("Please enter a number!");
    }
}