using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Ukesoppgaveuke4.Test
{
    public class UnitTestDealership
    {
        private Dealership dealership;
        private Car car1;


        [SetUp]
        public void Setup()
        {
            dealership = new Dealership("Auto", "Hollywood", new List<Car>
            {
                new("Mercedes", "ABC123", 2010, 100000),
                new("Toyota", "DEF456", 2014, 85000),
                new("Mazda", "GHI789", 2019, 43900),
                new("Ford", "JKL012", 2008, 75000),
                new("Chevrolet", "MNO345", 2012, 60000)
            });

            car1 = new Car("Land Rover", "FWP385", 2005, 430000);
        }

        [Test]
        public void TestDisplayAllCars()
        {
            //Dealership dealership = new("Auto", "Hollywood", new List<Car>());
            //Car car1 = new("Mercedes", "ABC123", 2010, 100000);
            //Car car2 = new("Toyota", "DEF456", 2014, 85000);
            //Car car3 = new("Mazda", "GHI789", 2019, 43900);
            //dealership.AddCar(car1);
            //dealership.AddCar(car2);
            //dealership.AddCar(car3);


            dealership.DisplayAllCars();

            Assert.That(dealership.Name, Is.EqualTo("Auto"));
            Assert.That(dealership.Address, Is.EqualTo("Hollywood"));
            Assert.That(dealership.Cars, Has.Count.EqualTo(5));
        }

        [Test]
        public void TestAddCar()
        {
            //Dealership dealership = new("Auto", "Hollywood", new List<Car>());
            //Car car1 = new("Land Rover", "FWP385", 2005, 430000);

            dealership.AddCar(car1);
            Assert.That(dealership.Cars, Has.Count.EqualTo(6));
        }

        [Test]
        public void TestSellCar()
        {
            //Dealership dealership = new("Auto", "Hollywood", new List<Car>());
            //Car car1 = new("Land Rover", "FWP385", 2005, 430000);

            dealership.SellCar(car1);
            Assert.That(dealership.Cars, Has.Count.EqualTo(5));
        }

        [Test]
        public void TestFindCarIndex()
        {
            //Dealership dealership = new("Auto", "Hollywood", new List<Car>());
            //Car car1 = new("Land Rover", "FWP385", 2005, 430000);
            //dealership.AddCar(car1);

            string getIndex = "GHI789".ToLower();
            int index = dealership.FindCarIndex(getIndex);
            Assert.That(index, Is.EqualTo(2));
        }

        [Test]
        public void TestGetCar()
        {
            int index = 2;
            Car result = dealership.GetCar(index);

            Assert.That(result, Is.EqualTo(dealership.Cars[index]));
        }

        [Test]
        public void TestGetOlderCars()
        {
            const int year = 2011;
            List<Car> olderCars = dealership.GetOlderCars(year);
            List<Car> expectedCars = new()
            {
                new Car("Mercedes", "ABC123", 2010, 100000),
                new Car("Ford", "JKL012", 2008, 75000),
            };

            // Todo: Måtte legge til Equals() og GetHashCode() i Car klassen for å få dette til å virke!

            Assert.That(olderCars.SequenceEqual(expectedCars), Is.True);

            //foreach (var car in olderCars)
            //{
            //    car.DisplayCarDetails();
            //}

            //Console.WriteLine("-----------------------------------------------------------");
            //foreach (var car in expectedCars)
            //{
            //    car.DisplayCarDetails();
            //}

            //for (int i = 0; i < olderCars.Count; i++)
            //{
            //    var olderCar = olderCars[i];
            //    var expectedCar = expectedCars[i];

            //    if (!olderCar.Equals(expectedCar))
            //    {
            //        Console.WriteLine($"Mismatch at index {i}:");
            //        Console.WriteLine("Actual car:");
            //        olderCar.DisplayCarDetails();
            //        Console.WriteLine("Expected car:");
            //        expectedCar.DisplayCarDetails();
            //    }
            //}

            //CollectionAssert.AreEqual(olderCars, expectedCars);
            //Assert.That(olderCars, Has.Count.EqualTo(expectedCars.Count));
            //for (var i = 0; i < expectedCars.Count; i++)
            //{
            //    Assert.AreEqual(expectedCars[i], olderCars[i]);
            //    //Assert.That(olderCars[i], Is.EqualTo(expectedCars[i]));
            //}
        }

        [Test]
        public void TestGetNewerCars()
        {
            const int km = 90000;
            List<Car> carsByKm = dealership.GetCarsByKm(km);
            List<Car> expectedCarsByKm = new()
            {
                new Car("Toyota", "DEF456", 2014, 85000),
                new Car("Mazda", "GHI789", 2019, 43900),
                new Car("Ford", "JKL012", 2008, 75000),
                new Car("Chevrolet", "MNO345", 2012, 60000)
            };

            Assert.That(carsByKm.SequenceEqual(expectedCarsByKm), Is.True);
        }
    }
}