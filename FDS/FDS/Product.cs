using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FDS
{
    public class Product
    {
        #region Properties

        public int ProductId;
        public Hall Hall;
        public String Name;
        public int Inventory;
        public decimal Price;
        public bool IsActive;
        public bool IsWeeklyAccountable;

        #endregion Properties

        #region Private Methods

        /// <summary>
        /// Takes a reader and gets a Product from the columns. This should only be used if you
        /// already know there is a row. Does not call Read() ever
        /// </summary>
        /// <param name="reader">Reader to extract product from</param>
        /// <returns>Product as given by reader</returns>
        private static Product GetProductFromReader(SqlDataReader reader)
        {
            var product = new Product
            {
                ProductId = int.Parse(String.Format("{0}", reader["productID"])),
                Hall = Hall.GetHallById(int.Parse(String.Format("{0}", reader["hallID"]))),
                Name = String.Format("{0}", reader["name"]),
                Inventory = int.Parse(String.Format("{0}", reader["inventory"])),
                Price = decimal.Parse(String.Format("{0}", reader["price"])),
                IsActive = bool.Parse(String.Format("{0}", reader["isActive"])),
                IsWeeklyAccountable = bool.Parse(String.Format("{0}", reader["isWeeklyAccountable"]))
            };
            return product;
        }

        #endregion Private Methods

        #region Public Static Methods

        /// <summary>
        /// Adds a product to the given hall
        /// </summary>
        /// <param name="name">Name of product</param>
        /// <param name="hall">Hall of product</param>
        /// <param name="price">Price of product</param>
        /// <param name="active">Is product active?</param>
        /// <param name="weeklyAccountable">Is product weekly accountable?</param>
        /// <returns>Returns the newly created product.</returns>
        public static Product AddProduct(String name, Hall hall, decimal price, int inventory, bool active, bool weeklyAccountable)
        {
            // If product already exists, return null
            if (GetProductByNameAndHall(name, hall) != null) return null;

            // Set up insert command
            var command =
                new SqlCommand("INSERT INTO Products VALUES (@hallId, @name, @inventory, @price, @isActive, @isWeeklyAccountable)")
                {
                    CommandType = CommandType.Text,
                    Connection = Connections.FDSConnection()
                };
            command.Parameters.Add(new SqlParameter("hallId", hall.HallId));
            command.Parameters.Add(new SqlParameter("name", name));
            command.Parameters.Add(new SqlParameter("price", price));
            command.Parameters.Add(new SqlParameter("inventory", inventory));
            command.Parameters.Add(new SqlParameter("isActive", active ? 1 : 0));
            command.Parameters.Add(new SqlParameter("isWeeklyAccountable", weeklyAccountable ? 1 : 0));

            // Execute command
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();

            // Get the product just added
            return GetProductByNameAndHall(name, hall);
        }

        /// <summary>
        /// Deletes a product as determined by the given product ID
        /// </summary>
        /// <param name="productId">Product ID of product to find</param>
        /// <returns>Product with corresponding product ID</returns>
        public static Product DeleteProduct(int productId)
        {
            // Create the command
            var command =
                new SqlCommand("Delete FROM Products WHERE productID=@productId")
                {
                    CommandType = CommandType.Text,
                    Connection = Connections.FDSConnection()
                };
            command.Parameters.Add(new SqlParameter("productId", productId));

            // Execute the command
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();

            return null;
        }

        /// <summary>

        /// <summary>
        /// Gets a product as determined by the given product ID
        /// </summary>
        /// <param name="productId">Product ID of product to find</param>
        /// <returns>Product with corresponding product ID</returns>
        public static Product GetProductByProductId(int productId)
        {
            // Create the command
            var command =
                new SqlCommand("SELECT * FROM Products WHERE productID=@productId")
                {
                    CommandType = CommandType.Text,
                    Connection = Connections.FDSConnection()
                };
            command.Parameters.Add(new SqlParameter("productId", productId));

            // Execute the command
            command.Connection.Open();
            var reader = command.ExecuteReader();

            // If there is a row, return the top row as a Product
            if (reader.Read())
            {
                var product = GetProductFromReader(reader);
                reader.Close();
                command.Connection.Close();
                return product;
            }

            // No product found, return null
            reader.Close();
            command.Connection.Close();
            return null;
        }

        /// <summary>
        /// Gets a product with given name in the given hall
        /// </summary>
        /// <param name="name"></param>
        /// <param name="hall"></param>
        /// <returns></returns>
        public static Product GetProductByNameAndHall(String name, Hall hall)
        {
            // Create the command
            var command =
                new SqlCommand("SELECT * FROM Products WHERE name LIKE @name AND hallID=@hallId")
                {
                    CommandType = CommandType.Text,
                    Connection = Connections.FDSConnection()
                };
            command.Parameters.Add(new SqlParameter("hallId", hall.HallId));
            command.Parameters.Add(new SqlParameter("name", name));

            // Execute the command
            command.Connection.Open();
            var reader = command.ExecuteReader();

            // If there is a row, return the top row as a Product
            if (reader.Read())
            {
                var product = GetProductFromReader(reader);
                reader.Close();
                command.Connection.Close();
                return product;
            }

            // No product found, return null
            reader.Close();
            command.Connection.Close();
            return null;
        }

        /// <summary>
        /// Gets a list of all products
        /// </summary>
        /// <returns>List of all products</returns>
        public static List<Product> GetAllProducts()
        {
            // Create the command
            var command =
                new SqlCommand("SELECT * FROM Products")
                {
                    CommandType = CommandType.Text,
                    Connection = Connections.FDSConnection()
                };

            // Execute the command
            command.Connection.Open();
            var reader = command.ExecuteReader();

            // Set up a list to hold all the products
            var products = new List<Product>();

            // If there is a row, return the top row as a Product
            while (reader.Read())
            {
                products.Add(GetProductFromReader(reader));
            }

            reader.Close();
            command.Connection.Close();
            return products;
        }

        /// <summary>
        /// Gets a list of all products for a hall
        /// </summary>
        /// <param name="hall">Hall to get products for</param>
        /// <returns>List of hall's products</returns>
        public static List<Product> GetAllProductsForHall(Hall hall)
        {
            // Create the command
            var command =
                new SqlCommand("SELECT * FROM Products WHERE hallID=@hallId")
                {
                    CommandType = CommandType.Text,
                    Connection = Connections.FDSConnection()
                };
            command.Parameters.Add(new SqlParameter("hallId", hall.HallId));

            // Execute the command
            command.Connection.Open();
            var reader = command.ExecuteReader();

            // Set up a list to hold all the products
            var products = new List<Product>();

            // If there is a row, return the top row as a Product
            while (reader.Read())
            {
                products.Add(GetProductFromReader(reader));
            }

            reader.Close();
            command.Connection.Close();
            return products;
        }

        #endregion Public Static Methods

        #region Public Non-Static Methods

        /// <summary>
        /// Sets the price locally and in the database. If the local value does not change, the
        /// value in the database has not changed.
        /// </summary>
        /// <param name="price">New price for product</param>
        public void SetPrice(decimal price)
        {
            // Set up insert command
            var command =
                new SqlCommand("UPDATE Products SET price=@price WHERE productID=@productID")
                {
                    CommandType = CommandType.Text,
                    Connection = Connections.FDSConnection()
                };
            command.Parameters.Add(new SqlParameter("price", price));
            command.Parameters.Add(new SqlParameter("productID", ProductId));

            // Execute command
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();

            // Set the price to the price in the database
            Price = GetProductByProductId(ProductId).Price;
        }

        /// <summary>
        /// Sets the name locally and in the database. If the local value does not change, the value
        /// in the database has not changed.
        /// </summary>
        /// <param name="name">New name for product</param>
        public void SetName(String name)
        {
            // Set up insert command
            var command =
                new SqlCommand("UPDATE Products SET name=@name WHERE productID=@productID")
                {
                    CommandType = CommandType.Text,
                    Connection = Connections.FDSConnection()
                };
            command.Parameters.Add(new SqlParameter("name", name));
            command.Parameters.Add(new SqlParameter("productID", ProductId));

            // Execute command
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();

            // Set the name to the name in the database
            Name = GetProductByProductId(ProductId).Name;
        }

        /// <summary>
        /// Sets the inventory locally and in the database. If the local value does not change, the
        /// value in the database has not changed.
        /// </summary>
        /// <param name="inventory">New inventory for product</param>
        /// <param name="employee">Employee making the change</param>
        public void SetInventory(int inventory, Employee employee)
        {
            // Set up insert command
            var command =
                new SqlCommand("UPDATE Products SET inventory=@inventory WHERE productID=@productID;" +
                               "INSERT INTO InventoryChanges VALUES (@productID, @change, @changedBy, @changedOn)")
                {
                    CommandType = CommandType.Text,
                    Connection = Connections.FDSConnection()
                };
            command.Parameters.Add(new SqlParameter("inventory", inventory));
            command.Parameters.Add(new SqlParameter("productID", ProductId));
            command.Parameters.Add(new SqlParameter("change", inventory - Inventory));
            command.Parameters.Add(new SqlParameter("changedBy", employee.GetEmployeeId()));
            command.Parameters.Add(new SqlParameter("changedOn", DateTime.Now));

            // Execute command
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();

            // Set the inventory to the inventory in the database
            Inventory = GetProductByProductId(ProductId).Inventory;
        }

        /// <summary>
        /// Adds an amount of this product to the inventory
        /// </summary>
        /// <param name="amount">Amount of product to add to inventory</param>
        /// <param name="employee">Employee adding product</param>
        public void AddInventory(int amount, Employee employee)
        {
            SetInventory(Inventory + amount, employee);
        }

        /// <summary>
        /// Sells a certain amount of products
        /// </summary>
        /// <param name="amount">Amount of product to sell</param>
        /// <param name="isCredit">True if sell is credit (no money paid)</param>
        /// <param name="creditReason">If isCredit, the reason why</param>
        /// <param name="employee">Employee selling product</param>
        public void Sell(int amount, bool isCredit, String creditReason, Employee employee)
        {
            // Set up insert command
            var command =
                new SqlCommand("UPDATE Products SET inventory=@inventory WHERE productID=@productID;" +
                               "INSERT INTO Sales VALUES (@productID, @soldOn, @soldBy, @isCredit, @creditReason, @cost, @amount)")
                {
                    CommandType = CommandType.Text,
                    Connection = Connections.FDSConnection()
                };
            command.Parameters.Add(new SqlParameter("inventory", Inventory - amount));
            command.Parameters.Add(new SqlParameter("productID", ProductId));
            command.Parameters.Add(new SqlParameter("soldOn", DateTime.Now));
            command.Parameters.Add(new SqlParameter("soldBy", employee.GetEmployeeId()));
            command.Parameters.Add(new SqlParameter("isCredit", isCredit ? 1 : 0));
            // if not credit, null, else credit reason (if credit reason is null, then insert null)
            command.Parameters.Add(new SqlParameter("creditReason", !isCredit ? "NULL" : (creditReason ?? "NULL")));
            command.Parameters.Add(new SqlParameter("cost", isCredit ? 0 : Price));
            command.Parameters.Add(new SqlParameter("amount", amount));

            // Execute command
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();

            // Set the inventory to the inventory in the database
            Inventory = GetProductByProductId(ProductId).Inventory;
        }

        /// <summary>
        /// Sets IsActive to true locally and in the database. If the local value does not change,
        /// the value in the database has not changed.
        /// </summary>
        public void MakeActive()
        {
            // Set up insert command
            var command =
                new SqlCommand("UPDATE Products SET isActive=1 WHERE productID=@productID")
                {
                    CommandType = CommandType.Text,
                    Connection = Connections.FDSConnection()
                };
            command.Parameters.Add(new SqlParameter("productID", ProductId));

            // Execute command
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();

            // Set IsActive to the IsActive in the database
            IsActive = GetProductByProductId(ProductId).IsActive;
        }

        /// <summary>
        /// Sets IsActive to false locally and in the database. If the local value does not change,
        /// the value in the database has not changed.
        /// </summary>
        public void MakeInactive()
        {
            // Set up insert command
            var command =
                new SqlCommand("UPDATE Products SET isActive=0 WHERE productID=@productID")
                {
                    CommandType = CommandType.Text,
                    Connection = Connections.FDSConnection()
                };
            command.Parameters.Add(new SqlParameter("productID", ProductId));

            // Execute command
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();

            // Set IsActive to the IsActive in the database
            IsActive = GetProductByProductId(ProductId).IsActive;
        }

        /// <summary>
        /// Sets IsWeeklyAccountable to true locally and in the database. If the local value does
        /// not change, the value in the database has not changed.
        /// </summary>
        public void MakeWeeklyAccountable()
        {
            // Set up insert command
            var command =
                new SqlCommand("UPDATE Products SET isWeeklyAccountable=1 WHERE productID=@productID")
                {
                    CommandType = CommandType.Text,
                    Connection = Connections.FDSConnection()
                };
            command.Parameters.Add(new SqlParameter("productID", ProductId));

            // Execute command
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();

            // Set IsWeeklyAccountable to the IsWeeklyAccountable in the database
            IsWeeklyAccountable = GetProductByProductId(ProductId).IsWeeklyAccountable;
        }

        /// <summary>
        /// Sets IsWeeklyAccountable to false locally and in the database. If the local value does
        /// not change, the value in the database has not changed.
        /// </summary>
        public void MakeNotWeeklyAccountable()
        {
            // Set up insert command
            var command =
                new SqlCommand("UPDATE Products SET isWeeklyAccountable=0 WHERE productID=@productID")
                {
                    CommandType = CommandType.Text,
                    Connection = Connections.FDSConnection()
                };
            command.Parameters.Add(new SqlParameter("productID", ProductId));

            // Execute command
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();

            // Set IsWeeklyAccountable to the IsWeeklyAccountable in the database
            IsWeeklyAccountable = GetProductByProductId(ProductId).IsWeeklyAccountable;
        }

        /// <summary>
        /// Destroys this object. WARNING - PROBABLY SHOULD NOT BE USED EXCEPT IN TESTING Also
        /// destroys all InventoryChanges and Sales of this product
        /// </summary>
        public void Destroy()
        {
            // Set up delete command
            var command =
                new SqlCommand("DELETE FROM InventoryChanges WHERE productID=@productID; DELETE FROM Sales WHERE productID=@productID; DELETE FROM Products WHERE productID=@productID")
                {
                    CommandType = CommandType.Text,
                    Connection = Connections.FDSConnection()
                };
            command.Parameters.Add(new SqlParameter("productID", ProductId));

            // Execute command
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        /// <summary>
        /// Returns a list of sales of this product
        /// </summary>
        /// <returns>List of sales for this product</returns>
        public List<Sale> GetSales()
        {
            // Set up command
            var command = new SqlCommand(
                "SELECT * FROM Sales WHERE productID=@productID")
            {
                CommandType = CommandType.Text,
                Connection = Connections.FDSConnection()
            };
            command.Parameters.Add(new SqlParameter("productID", ProductId));

            // Execute command
            command.Connection.Open();
            var reader = command.ExecuteReader();

            // Make a list of sales
            var sales = new List<Sale>();

            // For each row add the sale to the list
            while (reader.Read())
            {
                var sale = new Sale
                {
                    Product = this,
                    SoldOn = DateTime.Parse(String.Format("{0}", reader["soldOn"])),
                    SoldBy = Employee.GetEmployeeByEmployeeId(int.Parse(String.Format("{0}", reader["soldBy"]))),
                    IsCredit = bool.Parse(String.Format("{0}", reader["isCredit"])),
                    CreditReason = String.Format("{0}", reader["creditReason"]),
                    Cost = decimal.Parse(String.Format("{0}", reader["cost"])),
                    Amount = int.Parse(String.Format("{0}", reader["amount"]))
                };
                sales.Add(sale);
            }

            // Return the list
            return sales;
        }

        /// <summary>
        /// Returns a list of all inventory changes for this product
        /// </summary>
        /// <returns>List of inventory changes</returns>
        public List<InventoryChange> GetInventoryChanges()
        {
            // Set up command
            var command = new SqlCommand(
                "SELECT * FROM InventoryChanges WHERE productID=@productID")
            {
                CommandType = CommandType.Text,
                Connection = Connections.FDSConnection()
            };
            command.Parameters.Add(new SqlParameter("productID", ProductId));

            // Execute command
            command.Connection.Open();
            var reader = command.ExecuteReader();

            // Make a list of inventory changes
            var inventoryChanges = new List<InventoryChange>();

            // For each row add the inventory change to the list
            while (reader.Read())
            {
                var inventoryChange = new InventoryChange
                {
                    Product = this,
                    Change = int.Parse(String.Format("{0}", reader["change"])),
                    ChangedBy = Employee.GetEmployeeByEmployeeId(int.Parse(String.Format("{0}", reader["changedBy"]))),
                    ChangedOn = DateTime.Parse(String.Format("{0}", reader["changedOn"]))
                };
                inventoryChanges.Add(inventoryChange);
            }

            // Return the list
            return inventoryChanges;
        }

        #endregion Public Non-Static Methods

        #region FDM3 methods

        public static int getProductInventory(int ProductID)
        {
            // Create the command
            var Query =
                new SqlCommand("SELECT Inventory FROM Products where ProductID=@ProductID")
                {
                    CommandType = CommandType.Text,
                    Connection = Connections.FDSConnection()
                };
            Query.Parameters.Add(new SqlParameter("ProductID", ProductID));

            // Execute the command
            Query.Connection.Open();
            var Inventory = (int)Query.ExecuteScalar();
            Query.Connection.Close();
            return Inventory;
        }


        /*
         * Method for FDM3 to add and sell pizzas
        */

        public static void ProductSell(int Inventory, int ProductID, int ShiftID, int EmployeeID, int isCredit, int Amount, decimal Cost)
        {
            // Create an insert command
            var updateInventory = new SqlCommand(
                "UPDATE products SET inventory=@Inventory where ProductID=@ProductID")
            {
                CommandType = CommandType.Text,
                Connection = Connections.FDSConnection()
            };
            updateInventory.Parameters.Add(new SqlParameter("productID", ProductID));
            updateInventory.Parameters.Add(new SqlParameter("Inventory", Inventory));

            // Execute command
            updateInventory.Connection.Open();
            updateInventory.ExecuteNonQuery();
            updateInventory.Connection.Close();

            // Create an insert command
            var updateSales = new SqlCommand(
                "INSERT INTO Sales VALUES(@productID, @shiftID, @employeeID, @soldOn, @isCredit, @Reason, @Cost, @Amount)")
            {
                CommandType = CommandType.Text,
                Connection = Connections.FDSConnection()
            };
            updateSales.Parameters.Add(new SqlParameter("productID", ProductID));
            updateSales.Parameters.Add(new SqlParameter("shiftID", ShiftID));
            updateSales.Parameters.Add(new SqlParameter("employeeID", EmployeeID));
            updateSales.Parameters.Add(new SqlParameter("isCredit", isCredit));
            updateSales.Parameters.Add(new SqlParameter("soldOn", DateTime.Now));
            updateSales.Parameters.Add(new SqlParameter("Cost", Cost));
            updateSales.Parameters.Add(new SqlParameter("Amount", Amount));
            updateSales.Parameters.Add(new SqlParameter("Reason", ""));

            // Execute command
            updateSales.Connection.Open();
            updateSales.ExecuteNonQuery();
            updateSales.Connection.Close();
        }

        /*
         * Method for FDM3 to add and sell pizzas
        */

        public static void ProductAdd(int Inventory, int ProductID, int change, int EmployeeID, String Reason, int ShiftID)
        {
            // Create an insert command
            var updateInventory = new SqlCommand(
                "UPDATE products SET inventory=@Inventory where ProductID=@ProductID")
            {
                CommandType = CommandType.Text,
                Connection = Connections.FDSConnection()
            };
            updateInventory.Parameters.Add(new SqlParameter("productID", ProductID));
            updateInventory.Parameters.Add(new SqlParameter("Inventory", Inventory));

            // Execute command
            updateInventory.Connection.Open();
            updateInventory.ExecuteNonQuery();
            updateInventory.Connection.Close();

            // Create an insert command
            var inventoryChange = new SqlCommand(
                "INSERT INTO InventoryChanges VALUES(@productID, @Change, @changedBy, @changedOn, @Reason, @shiftID)")
            {
                CommandType = CommandType.Text,
                Connection = Connections.FDSConnection()
            };
            inventoryChange.Parameters.Add(new SqlParameter("productID", ProductID));
            inventoryChange.Parameters.Add(new SqlParameter("Change", change));
            inventoryChange.Parameters.Add(new SqlParameter("changedBy", EmployeeID));
            inventoryChange.Parameters.Add(new SqlParameter("changedOn", DateTime.Now));
            inventoryChange.Parameters.Add(new SqlParameter("Reason", Reason));
            inventoryChange.Parameters.Add(new SqlParameter("shiftID", ShiftID));

            // Execute command
            inventoryChange.Connection.Open();
            inventoryChange.ExecuteNonQuery();
            inventoryChange.Connection.Close();
        }

        #endregion FDM3 methods

        #region ExtraMethods
    }

    public class Sale
    {
        public Product Product { get; set; }

        public DateTime SoldOn { get; set; }

        public Employee SoldBy { get; set; }

        public bool IsCredit { get; set; }

        public String CreditReason { get; set; }

        public decimal Cost { get; set; }

        public int Amount { get; set; }
    }

    public class InventoryChange
    {
        public Product Product { get; set; }

        public int Change { get; set; }

        public Employee ChangedBy { get; set; }

        public DateTime ChangedOn { get; set; }
    }

        #endregion ExtraMethods
}