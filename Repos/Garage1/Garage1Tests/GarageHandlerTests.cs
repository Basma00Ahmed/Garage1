using Garage1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;


namespace Garage1Tests
{
    [TestClass()]
    public class GarageHandlerTests
    {
        [TestMethod()]
        public void GrarageCapacity_ReturnsExcpectedCapacity_ShouldPass()
        {
            // Arrange
            GarageHandler TestHandler = new GarageHandler();
            const string GarageName = "Test Garage";
            const int capacity = 30;
            const int expected = 30;
            //Act
            var Actual = TestHandler.CreateGrarageObject(capacity, GarageName);
            //Assert
            Assert.AreEqual(Actual.Garage_.Capacity, expected);
        }
        [TestMethod()]
        public void ParkVehicle_ReturnSuccessfulParkMsg_ShouldPass()
        {

            // Arrange
            GarageHandler TestGarage = new GarageHandler(30, "Test Garage");
            TestData testData = new TestData();
            const string vehicleType = "Airplane";
            string expected = $"Successfully Parked the {vehicleType} \n";

            //Act
            var actual = TestGarage.Park(testData.GetAirplaneObject(), vehicleType);
            //Assert
            Assert.AreEqual(actual, expected);
        }
        [TestMethod()]
        public void ParkVehicle_ReturnFullGarageCapacityMsg_ShouldPass()
        {

            // Arrange
            TestData testData = new TestData();
            GarageHandler ReadyGarage = new GarageHandler();
            ReadyGarage = testData.CreateGarageWithVehicles();// full Garge
            const string vehicleType = "Airplane";
            string expected = "There is no space in the garage \n";

            //Act
            var actual = ReadyGarage.Park(testData.GetAirplaneObject_NO2(), vehicleType);
            //Assert
            Assert.AreEqual(actual, expected);
        }
        [TestMethod()]
        public void ParkVehicle_ReturnConflictInRegstrationNo_ShouldPass()
        {

            // Arrange
            TestData testData = new TestData();
            GarageHandler ReadyGarage = new GarageHandler();
            ReadyGarage = testData.CreateGarageWithVehicles();
            const string vehicleType = "Airplane";
            string expected = $"There is another {vehicleType}  with same Registration Number\n";

            //Act
            var actual = ReadyGarage.Park(testData.GetAirplaneObject(), vehicleType);
            //Assert
            Assert.AreEqual(actual, expected);
        }
        [TestMethod()]
        public void PickUpVehicle_ReturnSuccessfulPickUpMsg_ShouldPass()
        {
            // Arrange
            TestData testData = new TestData();
            GarageHandler ReadyGarage = new GarageHandler();
            string registrationNumber = "RAC_987";
            ReadyGarage = testData.CreateGarageWithVehicles();
            string expected = $"Successfully Pick Up the Vehicle with Registration Number {registrationNumber} \n";
          
            //Act
            var actual = ReadyGarage.RemoveVehicleFromGarage(registrationNumber, false);
            //Assert
            Assert.AreEqual(actual, expected);
        }
        [TestMethod()]
        public void PickUpVehicle_ReturnNoVehicleMatchedWithRegstrationNoMsg_ShouldPass()
        {
            // Arrange
            TestData testData = new TestData();
            GarageHandler ReadyGarage = new GarageHandler();
            string registrationNumber = "ABC_987"; //Wrong registration Number
            ReadyGarage = testData.CreateGarageWithVehicles();
            string expected = $"There is no vehicle with this Registration Number \n";
            //Act
            var actual = ReadyGarage.RemoveVehicleFromGarage(registrationNumber, false);
            //Assert
            Assert.AreEqual(actual, expected);
        }
        [TestMethod()]
        public void PickUpVehicle_ReturnInvalidRegstrationNoMsg_ShouldPass()
        {
            // Arrange
            TestData testData = new TestData();
            GarageHandler ReadyGarage = new GarageHandler();
            string registrationNumber = ""; //Wrong registration Number
            ReadyGarage = testData.CreateGarageWithVehicles();
            string expected = $"Enter valid  Registration Number !!\n";
            //Act
            var actual = ReadyGarage.RemoveVehicleFromGarage(registrationNumber, false);
            //Assert
            Assert.AreEqual(actual, expected);
        }
        [TestMethod()]
        public void SearchByRegistrationNumber_ReturnsCountOfMatchedVehicles__ShouldPass()
        {
            // Arrange
            TestData testData = new TestData();
            GarageHandler ReadyGarage = new GarageHandler();
            ReadyGarage = testData.CreateGarageWithVehicles();
            string registrationNumber = "MOT654";
            const int expected = 1;

            //Act
            var actual = ReadyGarage.SearchByRegistrationNumber(registrationNumber, false);
            //Assert
            Assert.AreEqual(actual, expected);
        }
        [TestMethod()]
        public void Filter_Vehicles_ReturnsCountOfMatchedVehicles__ShouldPass()
        {
            // Arrange
            TestData testData = new TestData();
            GarageHandler ReadyGarage = new GarageHandler();
            ReadyGarage = testData.CreateGarageWithVehicles();
            Filter filterClass = testData.GetFilterClassObject();
            const int expected = 2;

            //Act
            var actual = ReadyGarage.FilterVehicles(filterClass, false);
            //Assert
            Assert.AreEqual(actual, expected);
        }
    }
}