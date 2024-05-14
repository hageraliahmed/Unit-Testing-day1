using CarFactoryLibrary;

namespace TestProject_Day1
{
    public class CarTests
    {
        [Fact]
        public void IsLicensed_Test_true()
        {
            // Arrange
            Toyota toyota = new Toyota();
            toyota.license = "hamada123";

            // Act
            bool actualResult = toyota.IsLicensed();

            // Boolean Assert
            Assert.True(actualResult);
        }
        [Fact]
        public void IsLicensed_Yesy_false()
        {
            //Arrange
            BMW bmw = new() { license = "" };

            //Act
            bool result = bmw.IsLicensed();

            //Boolean Assert
            Assert.False(result);
        }
        [Fact]
        public void Accelerate_velocity_Range30to35()
        {
            //Arrange
            BMW bmw = new() { velocity = 15 };
            Toyota toyota1 = new() { velocity = 15 };

            //Act
            bmw.Accelerate();
            toyota1.Accelerate();

            //Numeric Assert
            Assert.InRange(bmw.velocity, 30, 35);
            Assert.NotInRange(toyota1.velocity, 30, 35);
        }
        [Fact]
        public void GetDirection_Backward() {
            // Arrange
            Toyota toyota = new() { drivingMode = DrivingMode.Backward };

            // Act
            string result = toyota.GetDirection();

            // String Assert
            Assert.Equal("Backward", result);

            Assert.StartsWith("Ba", result);

            Assert.Contains("wa", result);

            Assert.Matches("B[a-z]{6}", result);
            Assert.DoesNotMatch("F[a-z]{8}", result);
        }
        [Fact]
        public void AskForRefrence_same() {
            //Arrange
            BMW bmw1 = new();
            BMW bmw2 = new();

            //Act
            Car car =  bmw1.GetMyCar();

            //Refrence Assert
            Assert.Same(car, bmw1);
            Assert.NotSame(car, bmw2);

        }
        [Fact]
        public void NewCar_TestForToyota() {
            //Arrange

            //Act
            Car? car = CarFactory.NewCar(CarTypes.Toyota);

            //Type Assert
            Assert.IsType<Toyota>(car);
            Assert.IsAssignableFrom<Car>(car);
        }
        [Fact]
        public void AddCars_BMW_CkeckListOfCars() {
            //Arrange
            CarStore carStore = new CarStore();
            BMW bmw = new() { velocity=15};
           //Act
            carStore.AddCar(bmw);
            //Collection Assert
            Assert.NotEmpty(carStore.cars);
            Assert.Contains(carStore.cars, c => c.velocity > 10);
        }
        [Fact]
        public void NewCar_TrySuzuki_Exception() {

            //Exception Assert
            Assert.ThrowsAny<Exception>(() =>
            {
                Car? car = CarFactory.NewCar(CarTypes.Suzuki);
            });
        }
    }
}