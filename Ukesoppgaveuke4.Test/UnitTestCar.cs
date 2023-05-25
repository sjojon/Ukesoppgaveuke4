namespace Ukesoppgaveuke4.Test
{
    public class CarTest
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            car = new("Toyota", "ABC123", 2010, 100000);
        }

        [Test]
        public void TestCar()
        {
            // Arrange
            //Car car = new Car("Toyota", "ABC123", 2010, 100000);

            // Act
            car.DisplayCarDetails();
            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(car.Make, Is.EqualTo("Toyota"));
                Assert.That(car.RegistrationNumber, Is.EqualTo("ABC123"));
                Assert.That(car.Year, Is.EqualTo(2010));
                Assert.That(car.Odometer, Is.EqualTo(100000));
            });
        }

        [Test]
        public void TestUpdateMake()
        {
            //Car car = new Car("Toyota", "ABC123", 2010, 100000);
            string newMake = "Mercedes";

            car.UpdateMake(newMake);

            Assert.That(car.Make, Is.EqualTo(newMake));

            // Tungvint måte, men funker:

            //string newMake = "Mercedes";
            //string newRegistrationNumber = "CDE456";
            //int newYear = 2011;
            //int newOdometer = 150000;
            //var car = new Car(newMake, newRegistrationNumber, newYear, newOdometer);

            //car.UpdateMake(newMake);

            //Assert.That(car.Make, Is.EqualTo("Mercedes"));
            //Assert.That(car.RegistrationNumber, Is.EqualTo("CDE456"));
            //Assert.That(car.Year, Is.EqualTo(2011));
            //Assert.That(car.Odometer, Is.EqualTo(150000));
        }

        [Test]
        public void TestUpdateRegistrationNumber()
        {
            //Car car = new Car("Toyota", "ABC123", 2010, 100000);
            string newRegistrationNumber = "CDE456";

            car.UpdateRegistrationNumber(newRegistrationNumber);

            Assert.That(car.RegistrationNumber, Is.EqualTo(newRegistrationNumber));
        }

        [Test]
        public void TestUpdateYear()
        {
            //Car car = new Car("Toyota", "ABC123", 2010, 100000);
            int newYear = 2011;

            car.UpdateYear(newYear);

            Assert.That(car.Year, Is.EqualTo(newYear));
        }

        [Test]
        public void TestUpdateOdometer()
        {
            //Car car = new Car("Toyota", "ABC123", 2010, 100000);
            int newOdometer = 150000;

            car.UpdateOdometer(newOdometer);

            Assert.That(car.Odometer, Is.EqualTo(newOdometer));
        }
    }
}