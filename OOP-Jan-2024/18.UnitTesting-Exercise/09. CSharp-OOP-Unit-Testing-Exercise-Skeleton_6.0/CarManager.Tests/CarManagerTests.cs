namespace CarManager.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;

        [SetUp]
        public void SetUp()
        {
            car = new Car("Toyota", "Corolla", 6.5, 50.0);
        }

        [Test]
        public void CarCtor_WithArguments_ShouldInitializePropertiesCorrectly()
        {
            // Arrange
            string expectedMake = "Toyota";
            string expectedModel = "Corolla";
            double expectedFuelConsumption = 6.5;
            double expectedFuelCapacity = 50.0;

            //// Act
            //Car car = new Car(make, model, fuelConsumption, fuelCapacity); //moved to SetUp

            // Assert
            Assert.AreEqual(expectedMake, car.Make);
            Assert.AreEqual(expectedModel, car.Model);
            Assert.AreEqual(expectedFuelConsumption, car.FuelConsumption);
            Assert.AreEqual(expectedFuelCapacity, car.FuelCapacity);
            Assert.AreEqual(0, car.FuelAmount); // FuelAmount should be initialized to zero
        }

        [Test]
        public void CarCtor_WithNoArguments_ShouldInitializeFuelAmountToZero()
        {
            // Assert
            Assert.AreEqual(0, car.FuelAmount);
        }

        [TestCase("")]
        [TestCase(null)]
        public void Car_MakeProperty_SettingNullOrEmptyValue_ShouldThrowArgumentException(string make)
        {
  
            // Act & Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => new Car(make, "Corolla", 6.5, 50.0));
            Assert.AreEqual("Make cannot be null or empty!", exception.Message);
        }

        [TestCase("")]
        [TestCase(null)]
        public void Car_ModelProperty_SettingNullOrEmptyValue_ShouldThrowArgumentException(string model)
        {
            // Act & Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => new Car("Toyota", model, 6.5, 50.0));
            Assert.AreEqual("Model cannot be null or empty!", exception.Message);

        }

        [TestCase(0)]
        [TestCase(-1)]
        public void Car_FuelConsumptioProperty_SettingNegativeOrZero_ShouldThrowArgumentException(double consumption)
        {
            // Act & Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => new Car("Toyota", "Corolla", consumption, 50.0));
            Assert.AreEqual("Fuel consumption cannot be zero or negative!", exception.Message);
        }

        [TestCase(-1)]
        public void Car_FuelAmmountProperty_SettingNegative_ShouldThrowArgumentException(double fuelTank)
        {

            // Act & Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => new Car("Toyota", "Corolla", 6.5, fuelTank));
            Assert.AreEqual("Fuel capacity cannot be zero or negative!", exception.Message);

        }

        [TestCase(0)]
        [TestCase(-10)]
        public void CarRefuelMethod_ShouldThrowExceptionIfFuelIsNegativeOrZero(double fuelToRefuel)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => car.Refuel(fuelToRefuel));

            Assert.AreEqual("Fuel amount cannot be zero or negative!", exception.Message);
        }

        [Test]
        public void CarRefuelMethod_ShouldIncreaseFuelAmount()
        {
            int expectedResult = 10;

            car.Refuel(10);
            double actualResult = car.FuelAmount;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CarFuelMethod_Amount_ShouldNotBeMoreThanFuelCapacity()
        {
            int expectedResult = 50;

            car.Refuel(65);
            double actualResult = car.FuelAmount;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CarDriveMethod_ShouldDecreaseFuelAmount()
        {
            double expectedResult = 9.35;

            car.Refuel(10);
            car.Drive(10);
            double actualResult = car.FuelAmount;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CarDriveMethod_ShouldThrowExceptionIfFuelNeededIsMoreThanFuelAmount()
        {
            car.Refuel(2);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => car.Drive(40));

            Assert.AreEqual("You don't have enough fuel to drive!", exception.Message);
        }
    }
}