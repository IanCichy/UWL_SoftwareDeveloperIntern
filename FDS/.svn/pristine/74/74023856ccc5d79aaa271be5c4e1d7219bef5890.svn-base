using FDS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FDMTest
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void TestProductClass()
        {
            // Set up for testing
            var testHall = Hall.GetHallByName("Test");
            var testEmployee = Employee.AddNewEmployee("employee.test");
            var preAddProductAllCount = Product.GetAllProducts().Count;
            var preAddProductHallCount = Product.GetAllProductsForHall(testHall).Count;
            const String productName = "test product";
            const String productChangedName = "test product name changed";
            const decimal productPrice = (decimal)10.00;
            const decimal productChangedPrice = (decimal)15.00;
            const int productChangedInventory = 10;
            const int productAddInventory = 15;
            const int productSellAmount = 2;
            const int productCreditAmount = 1;
            const String productCreditReason = "Burnt a pizza";
            const bool isWeeklyAccountable = true;
            const bool isActive = true;

            // Test AddProduct
            var product = Product.AddProduct(productName, testHall, productPrice, isActive, isWeeklyAccountable);
            Assert.IsNotNull(product, "AddProduct should not be null if product does not already exist");

            // Test AddProduct with product that already exists
            var shouldNotExistProduct = Product.AddProduct(productName, testHall, productPrice, isActive,
                isWeeklyAccountable);
            Assert.IsNull(shouldNotExistProduct, "Adding a product with the same name for the same hall should return null");

            // Test GetProductByProductId, working and failing
            var sameProduct = Product.GetProductByProductId(product.ProductId);
            Assert.IsNotNull(sameProduct, "GetProductByProductId with a valid ID should not return null");
            Assert.AreEqual(product.Name, sameProduct.Name, "GetProductByProductId should return the same product name");
            shouldNotExistProduct = Product.GetProductByProductId(-1);
            Assert.IsNull(shouldNotExistProduct, "GetProductByProductId should return null when given an invalid product ID");

            // Test GetProductByNameAndHall
            sameProduct = Product.GetProductByNameAndHall(productName, testHall);
            Assert.IsNotNull(sameProduct, "GetProductByNameAndHall with a valid name and hall should not return null");
            Assert.AreEqual(product.ProductId, sameProduct.ProductId, "GetProductByNameAndHall should return the same product id");
            shouldNotExistProduct = Product.GetProductByNameAndHall("invalid_name", testHall);
            Assert.IsNull(shouldNotExistProduct, "GetProductByNameAndHall should return null when given an invalid product name and/or hall");

            // Test GetAllProducts & GetAllProductsForHall
            var postAddProductAllCount = Product.GetAllProducts().Count;
            var postAddProductHallCount = Product.GetAllProductsForHall(testHall).Count;
            Assert.AreEqual(preAddProductAllCount + 1, postAddProductAllCount, "GetAllProducts does not contain exactly one more product after adding one for testing.");
            Assert.AreEqual(preAddProductHallCount + 1, postAddProductHallCount, "GetAllProductsForHall does not contain exactly one more product after adding one for testing.");

            // Test SetPrice, SetName, SetInventory, MakeActive, MakeInactive, MakeWeeklyAccountable, MakeNotWeeklyAccountable
            product.SetPrice(productChangedPrice);
            Assert.AreEqual(product.Price, productChangedPrice, "SetPrice did not properly set the price");

            product.SetName(productChangedName);
            Assert.AreEqual(product.Name, productChangedName, "SetName did not properly set the name");

            product.SetInventory(productChangedInventory, testEmployee);
            Assert.AreEqual(product.Inventory, productChangedInventory, "SetInventory did not properly set the inventory");

            product.MakeInactive();
            Assert.IsFalse(product.IsActive, "MakeInactive did not properly make the product not active");

            product.MakeActive();
            Assert.IsTrue(product.IsActive, "MakeActive did not properly make the product active");

            product.MakeNotWeeklyAccountable();
            Assert.IsFalse(product.IsWeeklyAccountable, "MakeNotWeeklyAccountable did not properly make the product not weekly accountable");

            product.MakeWeeklyAccountable();
            Assert.IsTrue(product.IsWeeklyAccountable, "MakeWeeklyAccountable did not properly make the product weekly accountable");

            // Test AddInventory
            product.AddInventory(productAddInventory, testEmployee);
            Assert.AreEqual(productAddInventory + productChangedInventory, product.Inventory, "AddInventory did not correctly add to the inventory.");

            // Test GetInventoryChanges
            Assert.AreEqual(2, product.GetInventoryChanges().Count, "GetInventoryChanges should have exactly two changes after creating a new object and only doing one change.");

            // Test Sell (no credit)
            product.Sell(productSellAmount, false, "", testEmployee);
            Assert.AreEqual(productAddInventory + productChangedInventory - productSellAmount, product.Inventory, "Sell did not correctly remove from the inventory.");

            // Test Sell (credit)
            product.Sell(productCreditAmount, true, productCreditReason, testEmployee);
            Assert.AreEqual(productAddInventory + productChangedInventory - productSellAmount - productCreditAmount, product.Inventory, "Sell did not correctly remove from the inventory.");

            // Test GetSales
            Assert.AreEqual(2, product.GetSales().Count, "GetSales should have exactly two sales after creating a new object and only doing two sales.");

            // End testing and destroy test objects
            product.Destroy();
            testEmployee.Destroy();
        }
    }
}