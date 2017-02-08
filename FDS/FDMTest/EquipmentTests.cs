using FDS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace FDMTest
{
    [TestClass]
    public class EquipmentTests
    {
        [TestMethod]
        public void TestEquipmentClass()
        {
            Hall testHall = Hall.GetHallByName("Test");
            const string newCondition = "damaged";
            const string newStatus = "damaged";
            const string name = "test equipment";
            const string changeName = "test equipment name changed";
            const string category = "test category";
            const string changeCategory = "test category changed";

            // Test GetPossibleStatuses

            const int expectedStatusesCount = 5;
            Dictionary<String, int> statuses = Equipment.GetPossibleStatuses();
            Assert.AreEqual(statuses.Count, expectedStatusesCount, "Status count of GetPossibleStatuses is not corect");
            foreach (var pair in statuses)
            {
                Assert.IsTrue(pair.Value >= 0, "Status code is below 0 in GetPossibleStatuses");
                Assert.IsNotNull(pair.Key, "Status description is null in GetPossibleStatuses");
            }

            // Test GetPossibleConditions
            const int expectedConditionsCount = 3;
            Dictionary<String, int> conditions = Equipment.GetPossibleConditions();
            Assert.AreEqual(conditions.Count, expectedConditionsCount,
                "Condition count of GetPossibleConditions is not corect");
            foreach (var pair in conditions)
            {
                Assert.IsTrue(pair.Value >= 0, "Condition code is below 0 in GetPossibleConditions");
                Assert.IsNotNull(pair.Key, "Condition description is null in GetPossibleConditions");
            }

            int preAddHallCount = Equipment.GetEquipmentByHall(testHall).Count;

            // Test GetEquipmentByHallAndName finding no equipment
            Equipment equipment = Equipment.GetEquipmentByHallAndName(testHall, name);
            Assert.IsNull(equipment, "GetEquipmentByHallAndName found equipment where none should exist.");

            // Test CreateEquipment & GetEquipmentByHallAndName (inside CreateEquipment)
            equipment = Equipment.CreateEquipment(testHall, name, category);
            Assert.IsNotNull(equipment,
                "CreateEquipment either failed to create an equipment or GetEquipmentByHallAndName failed to get equipment");

            // Test CreateEquipment with equipment with name already in hall
            Equipment shouldNotExistEquipment = Equipment.CreateEquipment(testHall, name, category);
            Assert.IsNull(shouldNotExistEquipment,
                "CreateEquipment with equipment of the same name in the hall did not return null.");

            // Test GetEquipmentById
            equipment = Equipment.GetEquipmentById(equipment.EquipmentId);
            Assert.IsNotNull(equipment, "GetEquipmentById returned null");

            // Test GetEquipmentByHall
            Assert.AreEqual(preAddHallCount + 1, Equipment.GetEquipmentByHall(testHall).Count,
                "GetEquipmentByHall's count is not higher after adding an equipment to the hall.");

            // Test SetCondition
            equipment.SetCondition(newCondition);
            Assert.AreEqual(equipment.Condition, newCondition, "SetCondition failed");

            // Test SetStatus
            equipment.SetStatus(newStatus);
            Assert.AreEqual(equipment.Status, newStatus, "SetStatus failed");

            // Test SetName
            equipment.SetName(changeName);
            Assert.AreEqual(equipment.Status, newStatus, "SetName failed");

            // Test SetCategory
            equipment.SetCategory(changeCategory);
            Assert.AreEqual(equipment.Status, newStatus, "SetCategory failed");

            // Destroy the test equipment
            equipment.Destroy();
            equipment = Equipment.GetEquipmentById(equipment.EquipmentId);
            Assert.IsNull(equipment, "Destroy did not remove the test equipment");
        }
    }
}