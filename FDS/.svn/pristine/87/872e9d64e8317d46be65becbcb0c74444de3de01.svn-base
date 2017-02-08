using FDS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FDMTest
{
    [TestClass]
    public class HallTests
    {
        private const String TestHallName = "Test";
        private const int TestHallId = 11;

        [TestMethod]
        public void TestHallClass()
        {
            // Test new Hall()
            var emptyHall = new Hall();
            Assert.IsNotNull(emptyHall, "new Hall() creates a null hall somehow. This should be impossible.");

            // Test GetHalls

            // arrange & act
            var halls = Hall.GetAllHalls();

            // assert
            Assert.IsNotNull(halls);
            Assert.IsTrue(halls.Count == 11, "There should be 11 halls");

            foreach (var h in halls)
            {
                Assert.IsNotNull(h, "GetHalls returns a null hall");
                Assert.IsNotNull(h.Name, "GetHalls returns a hall with a null name");
                Assert.IsTrue(h.Name.Length > 0, "GetHalls returns an empty name");
                Assert.IsTrue(h.HallId > 0, "GetHalls returns a hall with an ID of 0 or less");
            }

            // Test GetHallByName

            // arrange
            const string validHallName = TestHallName;
            const string invalidHallName = "Invalid";
            const int expectedHallId = TestHallId;

            // act
            var validHall = Hall.GetHallByName(validHallName);
            var invalidHall = Hall.GetHallByName(invalidHallName);

            // assert
            Assert.IsNull(invalidHall, "GetHallByName returns a valid hall when given an invalid name");
            Assert.IsNotNull(validHall, "GetHallByName returns null when given a valid name");
            Assert.AreEqual(expectedHallId, validHall.HallId, "GetHallByName gets a hall with an incorrect hall id");

            // Test GetHallByID
            // arrange
            const string expectedValidHallName = TestHallName;
            const int invalidHallId = -1;
            const int validHallId = TestHallId;

            // act
            validHall = Hall.GetHallById(validHallId);
            invalidHall = Hall.GetHallById(invalidHallId);

            // assert
            Assert.IsNull(invalidHall, "GetHallById returns a valid hall when given an invalid id");
            Assert.IsNotNull(validHall, "GetHallById returns null when given a valid id");
            Assert.AreEqual(expectedValidHallName, validHall.Name,
                "GetHallById returns a hall with an incorrect hall name");
        }
    }
}