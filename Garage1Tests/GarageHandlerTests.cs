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
        public void ParkStatus_ReturnSuccessfulParkMsg_ShouldPass()
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
        public void PickUpStatus_ReturnSuccessfulPickUpMsg_ShouldPass()
        {
            // Arrange
            TestData testData = new TestData();
            GarageHandler ReadyGarage = new GarageHandler();
            string registrationNumber = "RAC_987";
            string expected = $"Successfully Pick Up the Vehicle with Registration Number {registrationNumber} \n";
            ReadyGarage = testData.CreateGarageWithVehicles();
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