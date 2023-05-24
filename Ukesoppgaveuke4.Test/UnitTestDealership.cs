namespace Ukesoppgaveuke4.Test
{
    public class UnitTestDealership
    {
        [Test]
        public void TestDisplayAllCars()
        {
            Dealership dealership = new("Auto", "Hollywood", new List<Car>());

            Car car1 = new("Mercedes", "ABC123", 2010, 100000);
            Car car2 = new("Toyota", "DEF456", 2014, 85000);
            Car car3 = new("Mazda", "GHI789", 2019, 43900);

            dealership.AddCar(car1);
            dealership.AddCar(car2);
            dealership.AddCar(car3);


            dealership.DisplayAllCars();

            Assert.That(dealership.Name, Is.EqualTo("Auto"));
            Assert.That(dealership.Address, Is.EqualTo("Hollywood"));
            Assert.That(dealership.Cars, Has.Count.EqualTo(3));
        }

        [Test]
        public void TestAddCar()
        {
            Dealership dealership = new("Auto", "Hollywood", new List<Car>());

            Car car1 = new("Land Rover", "FWP385", 2005, 430000);

            dealership.AddCar(car1);

            Assert.That(dealership.Cars, Has.Count.EqualTo(1));
        }

        [Test]
        public void TestSellCar()
        {
            Dealership dealership = new("Auto", "Hollywood", new List<Car>());

            Car car1 = new("Land Rover", "FWP385", 2005, 430000);

            dealership.SellCar(car1);

            Assert.That(dealership.Cars, Has.Count.EqualTo(0));
        }

        [Test]
        public void TestFindCarIndex()
        {
            Dealership dealership = new("Auto", "Hollywood", new List<Car>());
            Car car1 = new("Land Rover", "FWP385", 2005, 430000);
            dealership.AddCar(car1);

            string getIndex = "FWP385".ToLower();
            int index = dealership.FindCarIndex(getIndex);

            Assert.That(index, Is.EqualTo(0));
        }

        [Test]
        public void TestGetCar()
        {
        }
    }
}