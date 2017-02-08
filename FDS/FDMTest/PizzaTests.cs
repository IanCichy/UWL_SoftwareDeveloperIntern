using FDS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FDMTest
{
    [TestClass]
    public class PizzaTests
    {
        [TestMethod]
        public void TestPizzaClass()
        {
            // Set up for testing
            var testHall = Hall.GetHallByName("Test");
            var conflictingProduct = Product.AddProduct("test pizza brand-test pizza conflict", testHall, (decimal)10.0, true, true);
            const String pizzaName = "test pizza name";
            const String pizzaBrand = "test pizza brand";
            const String pizzaChangedBrand = "test pizza changed brand";
            const decimal pizzaPrice = (decimal)2.45;
            var preAllPizzasCount = Pizza.GetAllPizzas().Count;
            var preHallPizzasCount = Pizza.GetAllPizzasForHall(testHall).Count;

            // Test AddPizza
            var pizza = Pizza.AddPizza(pizzaName, pizzaBrand, testHall, pizzaPrice, true);
            Assert.IsNotNull(pizza, "Adding a non-existing pizza should not return null");

            var shouldNotExistPizza = Pizza.AddPizza(pizzaName, pizzaBrand, testHall, pizzaPrice, true);
            Assert.IsNull(shouldNotExistPizza, "Adding an existing pizza should return null");

            shouldNotExistPizza = Pizza.AddPizza("test pizza conflict", pizzaBrand, testHall, pizzaPrice, true);
            Assert.IsNull(shouldNotExistPizza, "Adding an existing pizza with a conflicting product should return null");

            // Test GetPizzaByPizzaId
            var samePizza = Pizza.GetPizzaByPizzaId(pizza.PizzaId);
            var areEqual = (pizza.PizzaId == samePizza.PizzaId && pizza.Brand.Equals(samePizza.Brand) &&
                            pizza.Name.Equals(samePizza.Name) && pizza.ProductId == samePizza.ProductId);
            Assert.IsTrue(areEqual, "GetPizzaByPizzaId does not get the correct pizza");

            shouldNotExistPizza = Pizza.GetPizzaByPizzaId(-1);
            Assert.IsNull(shouldNotExistPizza, "GetPizzaByPizzaId should return null when given an invalid pizza ID");

            // Test GetPizzaByBrandNameAndHall
            samePizza = Pizza.GetPizzaByBrandNameAndHall(pizza.Brand, pizza.GetPizzaName(), pizza.Hall);
            Assert.IsNotNull(samePizza, "GetPizzaByBrandNameAndHall does not find a pizza");
            areEqual = (pizza.PizzaId == samePizza.PizzaId && pizza.Brand.Equals(samePizza.Brand) &&
                pizza.GetPizzaName().Equals(samePizza.GetPizzaName()) && pizza.ProductId == samePizza.ProductId);
            Assert.IsTrue(areEqual, "GetPizzaByBrandNameAndHall does not get the correct pizza");

            shouldNotExistPizza = Pizza.GetPizzaByBrandNameAndHall("invalid_pizza_brand", "invalid_pizza_name", testHall);
            Assert.IsNull(shouldNotExistPizza, "GetPizzaByBrandNameAndHall should return null when given an invalid name or hall");

            // Test GetAllPizzas and GetAllPizzasForHall
            Assert.AreEqual(preAllPizzasCount + 1, Pizza.GetAllPizzas().Count,
                "GetAllPizzas should have one more pizza after adding a pizza");
            Assert.AreEqual(preHallPizzasCount + 1, Pizza.GetAllPizzasForHall(testHall).Count,
                "GetAllPizzasForHall should have one more pizza after adding a pizza");

            // Test SetBrand
            pizza.SetBrand(pizzaChangedBrand);
            Assert.AreEqual(pizza.Brand, pizzaChangedBrand, "SetBrand did not properly set the brand");

            // Clean up testing
            conflictingProduct.Destroy();
            pizza.Destroy();
        }
    }
}