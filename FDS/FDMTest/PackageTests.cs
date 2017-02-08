using FDS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FDMTest
{
    [TestClass]
    public class PackageTests
    {
        [TestMethod]
        public void TestPackageClass()
        {
            // Set up for testing
            var testHall = Hall.GetHallByName("Test");
            var equipment = Equipment.CreateEquipment(testHall, "test", "test");
            var testEmployee = Employee.AddNewEmployee("employee.test");
            var testEmployee2 = Employee.AddNewEmployee("employee.tes2");
            var preAddCount = Package.GetPackagesForHall(testHall).Count;
            var preAddUndeliveredCount = Package.GetUndeliveredPackagesForhall(testHall).Count;

            // Test AddPackage
            Package package = Package.AddPackage(testHall, "student.id", "description of test package", "test carrier",
                (decimal)0.00, testEmployee);
            Assert.IsNotNull(package, "AddPackage did not correctly add a package");

            // Test GetPackagesForHall
            List<Package> packages = Package.GetPackagesForHall(testHall);
            Assert.AreEqual(preAddCount + 1, packages.Count,
                "GetPackagesForHall's count didn't increase by 1 after adding a package");
            List<Package> undeliveredPackages = Package.GetUndeliveredPackagesForhall(testHall);
            Assert.AreEqual(preAddUndeliveredCount + 1, undeliveredPackages.Count,
                "GetUndeliveredPackagesForHall's count didn't increase by 1 after adding a package");

            // Test Deliver
            package.Deliver(testEmployee2);
            Assert.IsNotNull(package.DeliveredBy, "Deliver did not set deliveredBy");
            Assert.IsNotNull(package.DeliveredOn, "Deliver did not set deliveredOn");

            // Test GetPackageById (correct then failure)
            package = Package.GetPackageById(package.PackageId);
            Assert.IsNotNull(package, "GetPackageByID returns null when it should find a package");

            Package shouldNotExistPackage = Package.GetPackageById(-1);
            Assert.IsNull(shouldNotExistPackage, "GetPackageByID returns a package when it should find none.");

            // Testing done, clean up (ORDER IS IMPORTANT)
            package.Destroy();
            Rental.DestroyAllRentalsOfEquipment(equipment);
            equipment.Destroy();
            testEmployee.Destroy();
            testEmployee2.Destroy();
        }
    }
}