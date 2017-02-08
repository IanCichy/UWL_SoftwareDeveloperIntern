using FDS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FDMTest
{
    [TestClass]
    public class RentalTests
    {
        [TestMethod]
        public void TestRentalClass()
        {
            // Prepare for testing
            Hall testHall = Hall.GetHallByName("Test");
            Equipment equipment = Equipment.CreateEquipment(testHall, "test", "test");
            Employee testEmployee = Employee.AddNewEmployee("employee.test");
            Employee testEmployee2 = Employee.AddNewEmployee("employee.tes2");

            // Test GetLastRentalOfEquipment before it has ever been checked out
            Rental shouldNotExistRental = Rental.GetLastRentalOfEquipment(equipment);
            Assert.IsNull(shouldNotExistRental,
                "GetLastRentalOfEquipment did not return null for equipment that has never been checked out.");

            // Test Checkout
            const string expectedStatus = "checked out";
            Rental newRental = Rental.Checkout(equipment, "eagleid.test", testEmployee);
            Assert.IsNotNull(newRental, "Checkout does not create a new rental");
            Assert.AreEqual(newRental.Equipment.Status, expectedStatus,
                "Checkout does not change the status of the equipment");

            // Test GetRentalByID
            Rental getByIdRental = Rental.GetRentalById(newRental.RentalId);
            shouldNotExistRental = Rental.GetRentalById(-1);
            Assert.AreEqual(getByIdRental.RentalId, newRental.RentalId,
                "GetRentalById is not returning the correct rental");
            Assert.AreEqual(getByIdRental.Equipment.EquipmentId, newRental.Equipment.EquipmentId,
                "GetRentalById is not getting correct equipment");
            Assert.IsNull(shouldNotExistRental, "GetRentalById with an invalid ID is not returning null");

            // Test GetLastRentalOfEquipment
            Rental lastRental = Rental.GetLastRentalOfEquipment(equipment);
            Assert.AreEqual(lastRental.RentalId, newRental.RentalId, "GetRentalById is not returning the correct rental");
            Assert.AreEqual(lastRental.Equipment.EquipmentId, newRental.Equipment.EquipmentId,
                "GetRentalById is not getting correct equipment");

            // Test GetAllRentalsOfEquipment
            const int expectedCount = 1;
            List<Rental> rentals = Rental.GetAllRentalsOfEquipment(equipment);
            Assert.AreEqual(expectedCount, rentals.Count,
                "GetAllRentalsOfEquipment is not returning 1 after checking out equipment once");

            // Test CheckIn
            Rental checkedIn = Rental.CheckIn(equipment, testEmployee2, "good");
            Assert.IsNotNull(checkedIn, "CheckIn returned null");

            checkedIn = Rental.CheckIn(equipment, testEmployee2, "good");
            Assert.IsNull(checkedIn, "CheckIn did not return null for an already checked in equipment.");

            // Testing done, clean up (ORDER IS IMPORTANT)
            Rental.DestroyAllRentalsOfEquipment(equipment);
            equipment.Destroy();
            testEmployee.Destroy();
            testEmployee2.Destroy();
        }
    }
}