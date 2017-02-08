using FDS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace FDMTest
{
    [TestClass]
    public class EmployeeTests
    {
        private const String TestEagleId = "unit_test_employee";
        private static readonly Hall EmployedByHall = Hall.GetHallByName("Test");
        private static readonly Hall NotEmployedByHall = Hall.GetHallByName("Reuter");

        [TestMethod]
        public void TestEmployeeClass()
        {
            // Test GetEmployeeByEagleId (failure - employee does not exist)
            var shouldNotExist = Employee.GetEmployeeByEagleId("impossible string for an eagle id");
            Assert.IsNull(shouldNotExist,
                "GetEmployeeByEagleID should return null - finding employee where there is none.");

            // Test GetEmployeeByEmployeeId (failure - employee does not exist)
            shouldNotExist = Employee.GetEmployeeByEmployeeId(-1);
            Assert.IsNull(shouldNotExist,
                "GetEmployeeByEmployeeID should return null - finding employee where there is none.");

            // test adding employee
            Employee testEmployee = Employee.AddNewEmployee(TestEagleId);
            Assert.IsNotNull(testEmployee,
                "AddNewEmployee returned null - AddNewEmployee is not correctly adding or checking if employee already exists.");

            // test getting all employees
            List<Employee> allEmployees = Employee.GetAllEmployees();
            Assert.IsTrue(allEmployees.Count > 0, "GetAllEmployees is empty");

            // test getting employee by eagleid
            testEmployee = Employee.GetEmployeeByEagleId(TestEagleId);
            Assert.IsNotNull(testEmployee, "GetEmployeeByEagleID is not returning the newly added employee.");

            // test adding employee (already exists)
            testEmployee = Employee.AddNewEmployee(TestEagleId);
            Assert.IsNotNull(testEmployee,
                "AddNewEmployee returned null when adding an employee that already exists, should return employee that already exists.");

            // test getting an employee by employee id
            Employee secondEmployee = Employee.GetEmployeeByEmployeeId(testEmployee.GetEmployeeId());
            Assert.AreEqual(secondEmployee.GetEmployeeId(), testEmployee.GetEmployeeId(),
                "GetEmployeeByEmployeeID returned an employee with a different Employee ID.");
            Assert.AreEqual(secondEmployee.EagleId, testEmployee.EagleId,
                "GetEmployeeByEmployeeID returned an employee with a different Eagle ID.");

            // test add employee to hall & get employees of hall
            int preAddCount = Employee.GetEmployeesOfHall(EmployedByHall).Count;
            testEmployee.AddEmployeeToHall(EmployedByHall);
            Assert.IsTrue(Employee.GetEmployeesOfHall(EmployedByHall).Count == preAddCount + 1,
                "GetEmployeesOfHall does not have one more employee after AddEmployeeToHall.");

            // test add employee to hall alread in
            testEmployee.AddEmployeeToHall(EmployedByHall);
            Assert.IsTrue(Employee.GetEmployeesOfHall(EmployedByHall).Count == preAddCount + 1,
                "AddEmployeeToHall added the same employee to a hall twice.");

            // test is employed by hall
            Assert.IsTrue(testEmployee.IsEmployedByHall(EmployedByHall));

            // test make dc
            int preDCCount = Employee.GetDCsOfHall(EmployedByHall).Count;
            testEmployee.MakeDCOfHall(EmployedByHall);

            // test getdcofhalls
            Assert.AreEqual(1, testEmployee.GetDCOfHalls().Count, "After making employee DC of one hall, GetDCOfHalls should return one item");

            // test get dcs of hall
            Assert.IsTrue(Employee.GetDCsOfHall(EmployedByHall).Count == preDCCount + 1,
                "GetDCsOfHall is not one higher after adding a DC");

            // test is dc of hall
            Assert.IsTrue(testEmployee.IsDCOfHall(EmployedByHall),
                String.Format("IsDCOfHall returns false after adding {0} as DC of {1}.", TestEagleId,
                    EmployedByHall.Name));

            // test remove dc
            testEmployee.RemoveDCFromHall(EmployedByHall);

            // test remove dc from hall not employed by
            testEmployee.RemoveDCFromHall(NotEmployedByHall);

            // test is dc of hall
            Assert.IsFalse(testEmployee.IsDCOfHall(EmployedByHall),
                String.Format("IsDCOfHall returns true after removing {0} as DC of {1}.", TestEagleId,
                    EmployedByHall.Name));

            // test get dcs of hall
            Assert.IsTrue(Employee.GetDCsOfHall(EmployedByHall).Count == preDCCount,
                "GetDCsOfHall is not the same as original after adding a DC then removing DC");

            // test remove employee from hall
            testEmployee.RemoveEmployeeFromHall(EmployedByHall);

            Assert.IsFalse(testEmployee.IsEmployedByHall(EmployedByHall),
                "IsEmployedByHall returning true after employee was removed from hall.");

            // test IsAdmin
            Assert.IsFalse(testEmployee.IsAdmin(), "Newly created employee should not be admin");

            // test delete employee
            testEmployee.Destroy();

            Assert.IsNull(Employee.GetEmployeeByEagleId(TestEagleId),
                "After deleting employee, GetEmployeeByEagleId did not return null when trying to find them.");
        }

        [TestMethod]
        public void TestIsValidCredentials()
        {
            Assert.IsFalse(Employee.IsValidCredentials("username.fake", "password"));
        }
    }
}