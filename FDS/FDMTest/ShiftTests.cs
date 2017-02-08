using FDS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace FDMTest
{
    [TestClass]
    public class ShiftTests
    {
        [TestMethod]
        public void TestShiftClass()
        {
            // Set up for testing
            var hall = Hall.GetHallByName("Test");
            var employee = Employee.AddNewEmployee("employee.test");
            var pizza = Pizza.AddPizza("test pizza name", "test pizza brand", hall, (decimal)2.50, true);
            var startTime = DateTime.Now;
            pizza.SetInventory(10, employee);

            // Clear all shifts for Test hall
            foreach (var s in Shift.GetAllShiftsForHall(hall))
            {
                s.Destroy();
            }

            // Set up for testing continued
            var preAllShiftCount = Shift.GetAllShifts().Count;

            const decimal cashInAmount = (decimal)10.00;

            // Test StartShift
            var shift = Shift.StartShift(hall, employee);
            Assert.IsNotNull(shift, "Newly started shift should not be null.");

            // Test GetShiftImmediatelyPreceding returning null if there are no shifts before this
            Assert.IsNull(shift.GetShiftImmediatelyPreceding());

            // Test GetShiftById with invalid ID
            var shouldNotExistShift = Shift.GetShiftById(-1);
            Assert.IsNull(shouldNotExistShift, "GetShiftById should return null when given an invalid ID");

            // Test pre-cash in
            Assert.IsFalse(shift.HasCashedIn(), "HasCashedIn should be false before cashing in");
            Assert.IsFalse(shift.HasCashedOut(), "HasCashedOut should be false before cashing in");
            Assert.IsFalse(shift.HasCountedInPizza(), "HasCountedInPizza should be false before cashing in");
            Assert.IsFalse(shift.HasCountedOutPizza(), "HasCountedOutPizza should be false before cashing in");

            // Test CashIn
            shift.CashIn(cashInAmount);
            Assert.AreEqual(shift.CashInTotal, cashInAmount, "After CashIn, CashInTotal should be the same as the amount cashed in");

            shift.CashIn(cashInAmount);

            // Test CountInPizza
            var count = new Dictionary<Pizza, int> { { pizza, 10 } };
            shift.PizzaCountIn(count);
            Assert.AreEqual(shift.GetPizzaCountIn().Count, 1, "After PizzaCountIn with one pizza, GetPizzaCountIn should have one PizzaCount");

            // Test Sales
            pizza.Sell(1, false, null, employee);
            Assert.AreEqual(1, shift.GetSales().Count, "GetSales should have 1 Sale after selling one pizza");

            // Test InventoryChanges
            pizza.AddInventory(1, employee);
            Assert.AreEqual(1, shift.GetInventoryChanges().Count, "GetInventoryChanges should have 1 InventoryChange after adding 2 pizzas in one change");

            // Test CountOutPizza
            count[pizza] = 11;
            shift.PizzaCountOut(count);
            Assert.AreEqual(shift.GetPizzaCountOut().Count, 1, "After PizzaCountOut with one pizza, GetPizzaCountOut should have one PizzaCount");

            // Test CashOut
            shift.CashOut(cashInAmount + pizza.Price);
            Assert.AreEqual(cashInAmount + pizza.Price, shift.CashOutTotal, "After CashOut the CashOutTotal is not correctly set");

            // Test CashOut when already cashed out
            shift.CashOut(cashInAmount + pizza.Price);

            // Test GetAllShifts and GetAllShiftsForHall
            Assert.AreEqual(preAllShiftCount + 1, Shift.GetAllShifts().Count, "After adding one shift, GetAllShifts should have exactly one more shift");
            Assert.AreEqual(1, Shift.GetAllShiftsForHall(hall).Count, "After adding one shift, GetAllShiftsForHall should have exactly one shift");
            var endTime = DateTime.Now;

            // Start a new shift and test GetShiftImmediatelyPreceding
            var secondShift = Shift.StartShift(hall, employee);
            Assert.AreEqual(secondShift.GetShiftImmediatelyPreceding().ShiftId, shift.ShiftId, "Shift immediately preceding second test shift created should be the one created immediately before");

            // Test GetAllShiftsForHallBetween
            Assert.AreEqual(1, Shift.GetShiftsForHallBetween(hall, startTime, endTime).Count, "GetShiftsForHallBetween should return 1 shift when start time is immediately before it was created and end time is right after it was created.");

            // Clean up testing things
            secondShift.Destroy();
            shift.Destroy();
            pizza.Destroy();
            employee.Destroy();
        }
    }
}