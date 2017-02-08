﻿#region

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

#endregion

namespace FDS
{
    public class Shift
    {
        #region Properties

        public int ShiftId;
        public Hall Hall;
        public Employee Employee;
        public DateTime shiftStart;
        public DateTime? shiftEnd;
        public decimal? CashInTotal;
        public decimal? CashOutTotal;
        public String ReasonNotBalanced;

        #endregion Properties

        #region Private Methods

        /// <summary>
        /// Since this is performed half a million times in this code, take a reader (already
        /// .Read()) and return a Shift
        /// </summary>
        /// <param name="reader">Reader already .Read()</param>
        /// <returns>Null if no columns found, Shift otherwise</returns>

        private static Shift GetShiftFromReader(SqlDataReader reader)
        {
            var shift = new Shift
            {
                ShiftId = int.Parse(String.Format("{0}", reader["shiftID"])),
                Hall = Hall.GetHallById(int.Parse(String.Format("{0}", reader["hallID"]))),
                Employee = Employee.GetEmployeeByEmployeeId(int.Parse(String.Format("{0}", reader["employeeID"]))),
                shiftStart = DateTime.Parse(String.Format("{0}", reader["shiftStart"])),
                shiftEnd =
                    reader["shiftEnd"] == DBNull.Value
                        ? (DateTime?)null
                        : DateTime.Parse(String.Format("{0}", reader["shiftEnd"])),
                CashInTotal =
                    reader["cashIn"] == DBNull.Value
                        ? (decimal?)null
                        : decimal.Parse(String.Format("{0}", reader["cashIn"])),
                CashOutTotal =
                    reader["cashOut"] == DBNull.Value
                        ? (decimal?)null
                        : decimal.Parse(String.Format("{0}", reader["cashOut"])),
                ReasonNotBalanced =
                    reader["reasonNotBalanced"] == DBNull.Value ? "" : String.Format("{0}", reader["reasonNotBalanced"])
            };
            return shift;
        }

        /// <summary>
        /// Inserts a single pizza count
        /// </summary>
        /// <param name="pizza">Pizza to count</param>
        /// <param name="count">User count of pizza</param>
        /// <param name="In">Counting in if true, out if false</param>
        private void InsertPizzaCount(Pizza pizza, int count, bool In)
        {
            // Create a command
            var command = new SqlCommand(
                "INSERT INTO PizzaCount VALUES (@shiftID, @in, @pizzaID, @systemCount, @userCount)")
            {
                CommandType = CommandType.Text,
                Connection = Connections.FDSConnection()
            };
            command.Parameters.Add(new SqlParameter("shiftID", ShiftId));
            command.Parameters.Add(new SqlParameter("in", In));
            command.Parameters.Add(new SqlParameter("pizzaId", pizza.PizzaId));
            command.Parameters.Add(new SqlParameter("systemCount", pizza.Inventory));
            command.Parameters.Add(new SqlParameter("userCount", count));

            // Execute command
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        /// <summary>
        /// Inserts the pizza count into the database
        /// </summary>
        /// <param name="count"></param>
        /// <param name="In"></param>
        private void PizzaCount(Dictionary<Pizza, int> count, bool In)
        {
            foreach (var pair in count)
            {
                InsertPizzaCount(pair.Key, pair.Value, In);
            }
        }

        #endregion Private Methods

        #region FDM3 Methods

        /// <summary>
        /// Starts a shift for the given employee in the given hall
        /// </summary>
        /// <param name="hall">Hall shift is for</param>
        /// <param name="employee">Employee of shift</param>
        /// <returns>Newly created shift</returns>
        public static int StartShift(int hallid, int employee)
        {
            // Set up command
            var command = new SqlCommand(
                "INSERT INTO Shifts VALUES (@hallID, @employeeID, @shiftStart, NULL, 0, 0, NULL, 0, 0, 0)")
            {
                CommandType = CommandType.Text,
                Connection = Connections.FDSConnection()
            };
            command.Parameters.Add(new SqlParameter("hallID", hallid));
            command.Parameters.Add(new SqlParameter("employeeID", employee));
            command.Parameters.Add(new SqlParameter("shiftStart", DateTime.Now));

            // Execute command
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();

            // Return the newly created shift
            var getShiftID =
                new SqlCommand("SELECT shiftID FROM Shifts where HallID=@HallID AND employeeID=@EmployeeID AND shiftEnd IS NULL")
                {
                    CommandType = CommandType.Text,
                    Connection = Connections.FDSConnection()
                };
            getShiftID.Parameters.Add(new SqlParameter("hallId", hallid));
            getShiftID.Parameters.Add(new SqlParameter("EmployeeID", employee));

            // Execute the command
            getShiftID.Connection.Open();
            var ShiftID = (int)getShiftID.ExecuteScalar();
            getShiftID.Connection.Close();

            // Set up command
            var setEndTime = new SqlCommand(
                "UPDATE Shifts SET shiftEnd=@shiftEnd WHERE shiftID=@shiftID")
            {
                CommandType = CommandType.Text,
                Connection = Connections.FDSConnection()
            };
            setEndTime.Parameters.Add(new SqlParameter("shiftID", ShiftID));
            setEndTime.Parameters.Add(new SqlParameter("shiftEnd", DateTime.Now));

            // Execute command
            setEndTime.Connection.Open();
            setEndTime.ExecuteNonQuery();
            setEndTime.Connection.Close();

            return ShiftID;
        }

        public static void setCashIn(int ShiftID, decimal CashIn, String Msg)
        {
            // Set up command
            var setCashIn = new SqlCommand(
                "UPDATE Shifts SET cashIn=@cashIn, cashOut=0, reasonNotBalanced = CONCAT(reasonNotBalanced, @Message) WHERE shiftID=@shiftID")
            {
                CommandType = CommandType.Text,
                Connection = Connections.FDSConnection()
            };
            setCashIn.Parameters.Add(new SqlParameter("shiftID", ShiftID));
            setCashIn.Parameters.Add(new SqlParameter("cashIn", CashIn));
            setCashIn.Parameters.Add(new SqlParameter("Message", Msg));

            // Execute command
            setCashIn.Connection.Open();
            setCashIn.ExecuteNonQuery();
            setCashIn.Connection.Close();
        }

        public static void setCashOut(int ShiftID, decimal CashOut, String Msg)
        {
            // Set up command
            var setCashOut = new SqlCommand(
                "UPDATE Shifts SET cashOut=@cashOut, reasonNotBalanced = CONCAT(reasonNotBalanced, @Message) WHERE shiftID=@shiftID")
            {
                CommandType = CommandType.Text,
                Connection = Connections.FDSConnection()
            };
            setCashOut.Parameters.Add(new SqlParameter("shiftID", ShiftID));
            setCashOut.Parameters.Add(new SqlParameter("cashOut", CashOut));
            setCashOut.Parameters.Add(new SqlParameter("Message", Msg));

            // Execute command
            setCashOut.Connection.Open();
            setCashOut.ExecuteNonQuery();
            setCashOut.Connection.Close();
        }

        #region ErrorCheck

        public static void setCashErrorOut(int ShiftID)
        {
            // Set up command
            var setErrorOut = new SqlCommand(
                "UPDATE Shifts SET countErrorCashOut=1 WHERE shiftID=@shiftID")
            {
                CommandType = CommandType.Text,
                Connection = Connections.FDSConnection()
            };
            setErrorOut.Parameters.Add(new SqlParameter("shiftID", ShiftID));

            // Execute command
            setErrorOut.Connection.Open();
            setErrorOut.ExecuteNonQuery();
            setErrorOut.Connection.Close();
        }

        public static void setCashErrorIn(int ShiftID)
        {
            // Set up command
            var setErrorIn = new SqlCommand(
                "UPDATE Shifts SET countErrorCashIn=1 WHERE shiftID=@shiftID")
            {
                CommandType = CommandType.Text,
                Connection = Connections.FDSConnection()
            };
            setErrorIn.Parameters.Add(new SqlParameter("shiftID", ShiftID));

            // Execute command
            setErrorIn.Connection.Open();
            setErrorIn.ExecuteNonQuery();
            setErrorIn.Connection.Close();
        }

        public static decimal getLastCashOut(int ShiftID, int HallID)
        {
            // Set up command
            var getCash = new SqlCommand(
                "SELECT TOP 1 cashOut FROM Shifts WHERE hallID=@hallID AND shiftID<>@shiftID ORDER BY shiftID DESC")
            {
                CommandType = CommandType.Text,
                Connection = Connections.FDSConnection()
            };
            getCash.Parameters.Add(new SqlParameter("shiftID", ShiftID));
            getCash.Parameters.Add(new SqlParameter("hallID", HallID));

            // Execute command
            getCash.Connection.Open();
            var cash = (decimal)(getCash.ExecuteScalar());
            getCash.Connection.Close();

            return cash;
        }

        public static void setPizzaError(int ShiftID)
        {
            // Set up command
            var setPizzaError = new SqlCommand(
                "UPDATE Shifts SET countErrorPizza=1 WHERE shiftID=@shiftID")
            {
                CommandType = CommandType.Text,
                Connection = Connections.FDSConnection()
            };
            setPizzaError.Parameters.Add(new SqlParameter("shiftID", ShiftID));

            // Execute command
            setPizzaError.Connection.Open();
            setPizzaError.ExecuteNonQuery();
            setPizzaError.Connection.Close();
        }

        public static void Resolve(int ShiftID, int ReportID)
        {
            // Set up command
            var resolve = new SqlCommand(
                "UPDATE ShiftsForReport SET Resolved=1 WHERE shiftID=@shiftID AND ReportID=@ReportID")
            {
                CommandType = CommandType.Text,
                Connection = Connections.FDSConnection()
            };
            resolve.Parameters.Add(new SqlParameter("shiftID", ShiftID));
            resolve.Parameters.Add(new SqlParameter("ReportID", ReportID));

            // Execute command
            resolve.Connection.Open();
            resolve.ExecuteNonQuery();
            resolve.Connection.Close();
        }

        public static void UnResolve(int ShiftID, int ReportID)
        {
            // Set up command
            var unResolve = new SqlCommand(
                "UPDATE ShiftsForReport SET Resolved=0 WHERE shiftID=@shiftID AND ReportID=@ReportID")
            {
                CommandType = CommandType.Text,
                Connection = Connections.FDSConnection()
            };
            unResolve.Parameters.Add(new SqlParameter("shiftID", ShiftID));
            unResolve.Parameters.Add(new SqlParameter("ReportID", ReportID));

            // Execute command
            unResolve.Connection.Open();
            unResolve.ExecuteNonQuery();
            unResolve.Connection.Close();
        }

        #endregion ErrorCheck

        public static void EndShift(int ShiftID)
        {
            // Set up command
            var setEndTime = new SqlCommand(
                "UPDATE Shifts SET shiftEnd=@shiftEnd WHERE shiftID=@shiftID")
            {
                CommandType = CommandType.Text,
                Connection = Connections.FDSConnection()
            };
            setEndTime.Parameters.Add(new SqlParameter("shiftID", ShiftID));
            setEndTime.Parameters.Add(new SqlParameter("shiftEnd", DateTime.Now));

            // Execute command
            setEndTime.Connection.Open();
            setEndTime.ExecuteNonQuery();
            setEndTime.Connection.Close();
        }

        public static void countPizzaIn(int ShiftID, int PizzaID, int Inventory, int CountIn)
        {
            // Set up command
            var countPizzaIn = new SqlCommand(
                "INSERT INTO PizzaCount VALUES (@shiftID, @pizzaID, @systemCountIn, @userCountIn, null, null)")
            {
                CommandType = CommandType.Text,
                Connection = Connections.FDSConnection()
            };
            countPizzaIn.Parameters.Add(new SqlParameter("shiftID", ShiftID));
            countPizzaIn.Parameters.Add(new SqlParameter("pizzaID", PizzaID));
            countPizzaIn.Parameters.Add(new SqlParameter("systemCountIn", Inventory));
            countPizzaIn.Parameters.Add(new SqlParameter("userCountIn", CountIn));

            // Execute command
            countPizzaIn.Connection.Open();
            countPizzaIn.ExecuteNonQuery();
            countPizzaIn.Connection.Close();
        }

        public static void countPizzaOut(int ShiftID, int PizzaID, int Inventory, int CountOut)
        {
            // Set up command
            var countPizzaOut = new SqlCommand(
                "UPDATE PizzaCount SET systemCountOut=@SystemCountOut, userCountOut=@UserCountOut WHERE shiftID=@ShiftID AND pizzaID=@PizzaID")
            {
                CommandType = CommandType.Text,
                Connection = Connections.FDSConnection()
            };
            countPizzaOut.Parameters.Add(new SqlParameter("ShiftID", ShiftID));
            countPizzaOut.Parameters.Add(new SqlParameter("PizzaID", PizzaID));
            countPizzaOut.Parameters.Add(new SqlParameter("SystemCountOut", Inventory));
            countPizzaOut.Parameters.Add(new SqlParameter("UserCountOut", CountOut));
            // Execute command
            countPizzaOut.Connection.Open();
            countPizzaOut.ExecuteNonQuery();
            countPizzaOut.Connection.Close();
        }

        public static void CheckInStudent(int studentID)
        {
            // Set up command
            var CheckIn = new SqlCommand(
                "UPDATE CheckInStudents SET CheckedIn = 1, DateCheckedIn=@checkIn WHERE StudentID=@studentID")
            {
                CommandType = CommandType.Text,
                Connection = Connections.FDSConnection()
            };
            CheckIn.Parameters.Add(new SqlParameter("studentID", studentID));
            CheckIn.Parameters.Add(new SqlParameter("checkIn", DateTime.Now));

            // Execute command
            CheckIn.Connection.Open();
            CheckIn.ExecuteNonQuery();
            CheckIn.Connection.Close();
        }

        public static void CheckOutStudent(int studentID)
        {
            // Set up command
            var CheckOut = new SqlCommand(
                "UPDATE CheckOutStudents SET CheckedOut = 1, DateCheckedOut=@checkOut WHERE StudentID=@studentID")
            {
                CommandType = CommandType.Text,
                Connection = Connections.FDSConnection()
            };
            CheckOut.Parameters.Add(new SqlParameter("studentID", studentID));
            CheckOut.Parameters.Add(new SqlParameter("checkOut", DateTime.Now));

            // Execute command
            CheckOut.Connection.Open();
            CheckOut.ExecuteNonQuery();
            CheckOut.Connection.Close();
        }

        public static void CheckInPhone(int studentID, String Phone)
        {
            // Set up command
            var CheckIn = new SqlCommand(
                "UPDATE CheckInStudents SET PhoneNumber=@Phone WHERE StudentID=@studentID")
            {
                CommandType = CommandType.Text,
                Connection = Connections.FDSConnection()
            };
            CheckIn.Parameters.Add(new SqlParameter("studentID", studentID));
            CheckIn.Parameters.Add(new SqlParameter("Phone", Phone));

            // Execute command
            CheckIn.Connection.Open();
            CheckIn.ExecuteNonQuery();
            CheckIn.Connection.Close();
        }

        /*
         * 
         * 
         * 
         * 
         * 
         */

        public static void ReserveCheckOutDvd(String LocID, String SNetID, String DVDID, String WNetID)
        {
            int UserID = 0;
            try
            {
                var getUserID =
                    new SqlCommand("SELECT UserID FROM [DVDCheckout].[dbo].[User] where NetID=@NetID")
                    {
                        CommandType = CommandType.Text,
                        Connection = Connections.FDSConnection()
                    };
                getUserID.Parameters.Add(new SqlParameter("NetID", SNetID));

                // Execute the command
                getUserID.Connection.Open();
                UserID = (int)(getUserID.ExecuteScalar());
                getUserID.Connection.Close();
            }
            catch (Exception)
            {
                var AddNewUser = new SqlCommand("INSERT INTO [DVDCheckout].[dbo].[User] VALUES (@NetID,0)")
                {
                    CommandType = CommandType.Text,
                    Connection = Connections.FDSConnection()
                };
                AddNewUser.Parameters.Add(new SqlParameter("NetID", SNetID));

                // Execute command
                AddNewUser.Connection.Open();
                AddNewUser.ExecuteNonQuery();
                AddNewUser.Connection.Close();
            }


            if (UserID == 0)
            {
                var getUserID2 =
                     new SqlCommand("SELECT UserID FROM [DVDCheckout].[dbo].[User] where NetID=@NetID")
                     {
                         CommandType = CommandType.Text,
                         Connection = Connections.FDSConnection()
                     };
                getUserID2.Parameters.Add(new SqlParameter("NetID", SNetID));

                // Execute the command
                getUserID2.Connection.Open();
                UserID = (int)getUserID2.ExecuteScalar();
                getUserID2.Connection.Close();
            }


            var AddNewRes = new SqlCommand("INSERT INTO [DVDCheckout].[dbo].[Reservation] VALUES (@ID,@LocID,@UserID,@ReservationTime,@CheckOutTime,@CheckOutWorker,null,null,0,null)")
            {
                CommandType = CommandType.Text,
                Connection = Connections.FDSConnection()
            };
            AddNewRes.Parameters.Add(new SqlParameter("ID", DVDID));
            AddNewRes.Parameters.Add(new SqlParameter("UserID", UserID));
            AddNewRes.Parameters.Add(new SqlParameter("CheckOutWorker", WNetID));
            AddNewRes.Parameters.Add(new SqlParameter("LocID", LocID));
            AddNewRes.Parameters.Add(new SqlParameter("ReservationTime", DateTime.Now));
            AddNewRes.Parameters.Add(new SqlParameter("CheckOutTime", DateTime.Now));

            // Execute command
            AddNewRes.Connection.Open();
            AddNewRes.ExecuteNonQuery();
            AddNewRes.Connection.Close();


            // Update Location reservation status
            var LocOut = new SqlCommand(
                "UPDATE DVDCheckout.dbo.Location SET [In]=0, [Out]=1, Reserved=0 WHERE LocID=@LocID")
            {
                CommandType = CommandType.Text,
                Connection = Connections.FDSConnection()
            };
            LocOut.Parameters.Add(new SqlParameter("locID", LocID));

            // Execute command
            LocOut.Connection.Open();
            LocOut.ExecuteNonQuery();
            LocOut.Connection.Close();
        }


        public static void CheckOutDvd(String LocID, DateTime ResTime, String NetID)
        {
            // Set up command
            var CheckOut = new SqlCommand(
                "UPDATE [DVDCheckout].[dbo].[Reservation] SET CheckOutTime=@time, CheckOutWorker=@NetID, DaysOut=0 WHERE LocID=@locID AND ReservationTime=@ResTime")
            {
                CommandType = CommandType.Text,
                Connection = Connections.FDSConnection()
            };
            CheckOut.Parameters.Add(new SqlParameter("locID", LocID));
            CheckOut.Parameters.Add(new SqlParameter("ResTime", ResTime));
            CheckOut.Parameters.Add(new SqlParameter("NetID", NetID));
            CheckOut.Parameters.Add(new SqlParameter("time", DateTime.Now));

            // Execute command
            CheckOut.Connection.Open();
            CheckOut.ExecuteNonQuery();
            CheckOut.Connection.Close();

            // Update Location in/out status
            var LocOut = new SqlCommand(
                "UPDATE DVDCheckout.dbo.Location SET [In]=0, [Out]=1, Reserved=0 WHERE LocID=@LocID")
            {
                CommandType = CommandType.Text,
                Connection = Connections.FDSConnection()
            };
            LocOut.Parameters.Add(new SqlParameter("locID", LocID));

            // Execute command
            LocOut.Connection.Open();
            LocOut.ExecuteNonQuery();
            LocOut.Connection.Close();
        }

        public static void CheckInDvd(String LocID, DateTime OutTime, String Comment, String NetID)
        {
            // Set up command
            var CheckIn = new SqlCommand(
                "UPDATE DVDCheckout.dbo.Reservation SET CheckInTime=@time, CheckInWorker=@NetID, ReturnComments=@Comment WHERE LocID=@locID AND CheckOutTime=@OutTime")
            {
                CommandType = CommandType.Text,
                Connection = Connections.FDSConnection()
            };
            CheckIn.Parameters.Add(new SqlParameter("locID", LocID));
            CheckIn.Parameters.Add(new SqlParameter("OutTime", OutTime));
            CheckIn.Parameters.Add(new SqlParameter("Comment", Comment));
            CheckIn.Parameters.Add(new SqlParameter("NetID", NetID));
            CheckIn.Parameters.Add(new SqlParameter("time", DateTime.Now));

            // Execute command
            CheckIn.Connection.Open();
            CheckIn.ExecuteNonQuery();
            CheckIn.Connection.Close();

            // Update Location in/out status
            var LocIn = new SqlCommand(
                "UPDATE DVDCheckout.dbo.Location SET [In]=1, [Out]=0 WHERE LocID=@LocID")
            {
                CommandType = CommandType.Text,
                Connection = Connections.FDSConnection()
            };
            LocIn.Parameters.Add(new SqlParameter("locID", LocID));

            // Execute command
            LocIn.Connection.Open();
            LocIn.ExecuteNonQuery();
            LocIn.Connection.Close();
        }

        #endregion FDM3 Methods

        #region Public Static Methods

        /// <summary>
        /// Gets a shift by its shiftID, null if none exists
        /// </summary>
        /// <param name="shiftId">shiftID of shift to get</param>
        /// <returns>Shift if found, null otherwise</returns>
        public static Shift GetShiftById(int shiftId)
        {
            // Set up command
            var command = new SqlCommand(
                "SELECT * FROM Shifts WHERE shiftID=@shiftID")
            {
                CommandType = CommandType.Text,
                Connection = Connections.FDSConnection()
            };
            command.Parameters.Add(new SqlParameter("shiftID", shiftId));

            // Execute command
            command.Connection.Open();
            var reader = command.ExecuteReader();

            // If there is no result, return null
            if (!reader.Read()) return null;

            // If there is a result, load it, close up connections, and return it
            var shift = GetShiftFromReader(reader);
            reader.Close();
            command.Connection.Close();
            return shift;
        }

        /// <summary>
        /// Gets a list of all shifts
        /// </summary>
        /// <returns>List of all shifts</returns>
        public static List<Shift> GetAllShifts()
        {
            // Set up command
            var command = new SqlCommand(
                "SELECT * FROM Shifts")
            {
                CommandType = CommandType.Text,
                Connection = Connections.FDSConnection()
            };

            // Execute command
            command.Connection.Open();
            var reader = command.ExecuteReader();

            // Create a list of shifts
            var shifts = new List<Shift>();

            // For each row in the query, create a shift
            while (reader.Read())
            {
                shifts.Add(GetShiftFromReader(reader));
            }

            // Return the list
            return shifts;
        }

        /// <summary>
        /// Gets a list of all shifts for the given hall
        /// </summary>
        /// <param name="hall">Hall to get shifts for</param>
        /// <returns>List of all shifts for hall</returns>
        public static List<Shift> GetAllShiftsForHall(Hall hall)
        {
            // Set up command
            var command = new SqlCommand(
                "SELECT * FROM Shifts WHERE hallID=@hallID")
            {
                CommandType = CommandType.Text,
                Connection = Connections.FDSConnection()
            };
            command.Parameters.Add(new SqlParameter("hallID", hall.HallId));

            // Execute command
            command.Connection.Open();
            var reader = command.ExecuteReader();

            // Create a list of shifts
            var shifts = new List<Shift>();

            // For each row in the query, create a shift
            while (reader.Read())
            {
                shifts.Add(GetShiftFromReader(reader));
            }

            // Return the list
            return shifts;
        }

        /// <summary>
        /// Gets all shifts for the given hall that start on or after the startDateTime and end
        /// before or on the endDateTime
        /// </summary>
        /// <param name="hall">Hall to get shifts for</param>
        /// <param name="startDateTime">Earliest DateTime for shift to start</param>
        /// <param name="endDateTime">Latest DateTime for shift to end</param>
        /// <returns>List of shifts for hall between startDateTime and endDateTime</returns>
        public static List<Shift> GetShiftsForHallBetween(Hall hall, DateTime startDateTime, DateTime endDateTime)
        {
            // Set up command
            var command = new SqlCommand(
                "SELECT * FROM Shifts WHERE hallID=@hallID AND shiftStart>=@start AND shiftEnd<=@end")
            {
                CommandType = CommandType.Text,
                Connection = Connections.FDSConnection()
            };
            command.Parameters.Add(new SqlParameter("hallID", hall.HallId));
            command.Parameters.Add(new SqlParameter("start", startDateTime));
            command.Parameters.Add(new SqlParameter("end", endDateTime));

            // Execute command
            command.Connection.Open();
            var reader = command.ExecuteReader();

            // Create a list of shifts
            var shifts = new List<Shift>();

            // For each row in the query, create a shift
            while (reader.Read())
            {
                shifts.Add(GetShiftFromReader(reader));
            }

            // Return the list
            return shifts;
        }

        /// <summary>
        /// To be used by admins/DCs, always sets the cash in amount, if local amount hasn't changed
        /// then database amount hasn't changed
        /// </summary>
        /// <param name="amount">Amount to set cash in to</param>
        public static void UpdateCash(decimal cashIn, decimal cashOut, int ShiftId)
        {
            // Set up command
            var command = new SqlCommand(
                "UPDATE Shifts SET cashIn=@cashIn, cashOut=@cashOut WHERE shiftID=@shiftID")
            {
                CommandType = CommandType.Text,
                Connection = Connections.FDSConnection()
            };
            command.Parameters.Add(new SqlParameter("cashIn", cashIn));
            command.Parameters.Add(new SqlParameter("cashOut", cashOut));
            command.Parameters.Add(new SqlParameter("shiftID", ShiftId));

            // Execute command
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="ShiftID"></param>
        /// <param name="SoldOn"></param>
        public static void DeleteSale(int ShiftID, String SoldOn, int productID, int amount)
        {
            // Set up command
            var delSale = new SqlCommand(
                "DELETE FROM Sales WHERE ShiftID=@ShiftID AND soldOn=@SoldOn AND amount=@amount")
            {
                CommandType = CommandType.Text,
                Connection = Connections.FDSConnection()
            };
            delSale.Parameters.Add(new SqlParameter("ShiftID", ShiftID));
            delSale.Parameters.Add(new SqlParameter("SoldOn", SoldOn));
            delSale.Parameters.Add(new SqlParameter("amount", amount));

            // Execute command
            delSale.Connection.Open();
            delSale.ExecuteNonQuery();
            delSale.Connection.Close();

            // Set up command
            var fixInventory = new SqlCommand(
                "UPDATE products SET inventory=(inventory+@amount) WHERE productID=@productID")
            {
                CommandType = CommandType.Text,
                Connection = Connections.FDSConnection()
            };
            fixInventory.Parameters.Add(new SqlParameter("productID", productID));
            fixInventory.Parameters.Add(new SqlParameter("amount", amount));

            // Execute command
            fixInventory.Connection.Open();
            fixInventory.ExecuteNonQuery();
            fixInventory.Connection.Close();
        }

        public static void AddSale(int productID, int ShiftID, int employeeID, int amount, Decimal cost, int isCredit, String creditReason)
        {
            // Set up command
            var AddSale = new SqlCommand(
                "INSERT INTO Sales VALUES (@productID, @ShiftID, @employeeID, @SoldOn, @isCredit , @creditReason, @cost, @amount)")
            {
                CommandType = CommandType.Text,
                Connection = Connections.FDSConnection()
            };
            AddSale.Parameters.Add(new SqlParameter("ShiftID", ShiftID));
            AddSale.Parameters.Add(new SqlParameter("SoldOn", DateTime.Now));
            AddSale.Parameters.Add(new SqlParameter("amount", amount));
            AddSale.Parameters.Add(new SqlParameter("productID", productID));
            AddSale.Parameters.Add(new SqlParameter("employeeID", employeeID));
            AddSale.Parameters.Add(new SqlParameter("cost", cost));
            AddSale.Parameters.Add(new SqlParameter("isCredit", isCredit));
            AddSale.Parameters.Add(new SqlParameter("creditReason", creditReason));

            // Execute command
            AddSale.Connection.Open();
            AddSale.ExecuteNonQuery();
            AddSale.Connection.Close();

            // Set up command
            var fixInventory = new SqlCommand(
                "UPDATE products SET inventory=(inventory-@amount) WHERE productID=@productID")
            {
                CommandType = CommandType.Text,
                Connection = Connections.FDSConnection()
            };
            fixInventory.Parameters.Add(new SqlParameter("productID", productID));
            fixInventory.Parameters.Add(new SqlParameter("amount", amount));

            // Execute command
            fixInventory.Connection.Open();
            fixInventory.ExecuteNonQuery();
            fixInventory.Connection.Close();
        }

        #endregion Public Static Methods

        #region Public Non-Static Methods

        /// <summary>
        /// Returns true if cashed in, false otherwise
        /// </summary>
        /// <returns>Returns true if cashed in, false otherwise</returns>
        public bool HasCashedIn()
        {
            return CashInTotal != null;
        }

        /// <summary>
        /// Returns true if shift has cashed out, false otherwise
        /// </summary>
        /// <returns>Returns true if shift has cashed out, false otherwise</returns>
        public bool HasCashedOut()
        {
            return CashOutTotal != null;
        }

        /// <summary>
        /// Returns true if this shift has counted out pizza
        /// </summary>
        /// <returns>True if counted out pizza, false otherwise</returns>
        public bool HasCountedOutPizza()
        {
            return GetPizzaCountOut().Count > 0;
        }

        /// <summary>
        /// Returns true if this shift has counted in pizza
        /// </summary>
        /// <returns>True if counted in pizza, false otherwise</returns>
        public bool HasCountedInPizza()
        {
            return GetPizzaCountIn().Count > 0;
        }

        /// <summary>
        /// To be used when an employee cashes in, sets cash in to the supplied amount unless
        /// already cashed in
        /// </summary>
        /// <param name="amount">Cash in total</param>
        public void CashIn(decimal amount)
        {
            if (HasCashedIn()) return;
            SetCashIn(amount);
        }

        /// <summary>
        /// To be used when an employee cashes out, sets cash out to the supplied amount unless
        /// already cashed out
        /// </summary>
        /// <param name="amount">Cash out total</param>
        public void CashOut(decimal amount)
        {
            if (HasCashedOut()) return;
            SetCashOut(amount);
            if (HasCashedOut()) EndShift();
        }

        /// <summary>
        /// Ends the shift
        /// </summary>
        public void EndShift()
        {
            // Set up command
            var command = new SqlCommand(
                "UPDATE Shifts SET [end]=@end WHERE shiftID=@shiftID")
            {
                CommandType = CommandType.Text,
                Connection = Connections.FDSConnection()
            };
            command.Parameters.Add(new SqlParameter("end", DateTime.Now));
            command.Parameters.Add(new SqlParameter("shiftID", ShiftId));

            // Execute command
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();

            // Set the local value to the database value
            shiftEnd = GetShiftById(ShiftId).shiftEnd;
        }

        /// <summary>
        /// To be used by admins/DCs, always sets the cash in amount, if local amount hasn't changed
        /// then database amount hasn't changed
        /// </summary>
        /// <param name="amount">Amount to set cash in to</param>
        public void SetCashIn(decimal amount)
        {
            // Set up command
            var command = new SqlCommand(
                "UPDATE Shifts SET cashIn=@cashIn WHERE shiftID=@shiftID")
            {
                CommandType = CommandType.Text,
                Connection = Connections.FDSConnection()
            };
            command.Parameters.Add(new SqlParameter("cashIn", amount));
            command.Parameters.Add(new SqlParameter("shiftID", ShiftId));

            // Execute command
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();

            // Set the local value to the database value
            CashInTotal = GetShiftById(ShiftId).CashInTotal;
        }

        /// <summary>
        /// To be used by admins/DCs, always sets the cash out amount, if local amount hasn't
        /// changed then database amount hasn't changed
        /// </summary>
        /// <param name="amount">Amount to set cash out to</param>
        public void SetCashOut(decimal amount)
        {
            // Set up command
            var command = new SqlCommand(
                "UPDATE Shifts SET cashOut=@cashOut WHERE shiftID=@shiftID")
            {
                CommandType = CommandType.Text,
                Connection = Connections.FDSConnection()
            };
            command.Parameters.Add(new SqlParameter("cashOut", amount));
            command.Parameters.Add(new SqlParameter("shiftID", ShiftId));

            // Execute command
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();

            // Set the local value to the database value
            CashOutTotal = GetShiftById(ShiftId).CashOutTotal;
        }

        /// <summary>
        /// Gets the shift immediately preceding this shift (for this shift's hall)
        /// </summary>
        /// <returns>Shift immediately preceding this shift</returns>
        public Shift GetShiftImmediatelyPreceding()
        {
            // Set up command
            var command = new SqlCommand(
                "SELECT * FROM GetPrecedingShift (@shiftID)")
            {
                Connection = Connections.FDSConnection(),
                CommandType = CommandType.Text
            };
            command.Parameters.Add(new SqlParameter("shiftID", ShiftId));

            // Execute command
            command.Connection.Open();
            var reader = command.ExecuteReader();

            // If no previous shift, return null
            if (!reader.Read()) return null;

            // Load the shift
            var shift = GetShiftFromReader(reader);

            // Close everything
            reader.Close();
            command.Connection.Close();

            // Return the shift
            return shift;
        }

        /// <summary>
        /// Gets a list of all sales during this shift
        /// </summary>
        /// <returns></returns>
        public List<Sale> GetSales()
        {
            // Set up command
            var command = new SqlCommand(
                "SELECT * FROM GetSalesForShift (@shiftID)")
            {
                CommandType = CommandType.Text,
                Connection = Connections.FDSConnection()
            };
            command.Parameters.Add(new SqlParameter("shiftID", ShiftId));

            // Execute command
            command.Connection.Open();
            var reader = command.ExecuteReader();

            // Create a list to hold the sales
            var sales = new List<Sale>();

            while (reader.Read())
            {
                var sale = new Sale
                {
                    Product = Product.GetProductByProductId(int.Parse(String.Format("{0}", reader["productID"]))),
                    SoldOn = DateTime.Parse(String.Format("{0}", reader["soldOn"])),
                    SoldBy = Employee.GetEmployeeByEmployeeId(int.Parse(String.Format("{0}", reader["soldBy"]))),
                    IsCredit = bool.Parse(String.Format("{0}", reader["isCredit"])),
                    CreditReason = String.Format("{0}", reader["creditReason"]),
                    Cost = decimal.Parse(String.Format("{0}", reader["cost"])),
                    Amount = int.Parse(String.Format("{0}", reader["amount"]))
                };
                sales.Add(sale);
            }

            return sales;
        }

        /// <summary>
        /// Gets a list of all inventory changes during this shift
        /// </summary>
        /// <returns></returns>
        public List<InventoryChange> GetInventoryChanges()
        {
            // Set up command
            var command = new SqlCommand(
                "SELECT * FROM GetInventoryChangesForShift (@shiftID)")
            {
                CommandType = CommandType.Text,
                Connection = Connections.FDSConnection()
            };
            command.Parameters.Add(new SqlParameter("shiftID", ShiftId));

            // Execute command
            command.Connection.Open();
            var reader = command.ExecuteReader();

            // Create a list to hold the sales
            var inventoryChanges = new List<InventoryChange>();

            while (reader.Read())
            {
                var inventoryChange = new InventoryChange
                {
                    Product = Product.GetProductByProductId(int.Parse(String.Format("{0}", reader["productID"]))),
                    Change = int.Parse(String.Format("{0}", reader["change"])),
                    ChangedBy = Employee.GetEmployeeByEmployeeId(int.Parse(String.Format("{0}", reader["changedBy"]))),
                    ChangedOn = DateTime.Parse(String.Format("{0}", reader["changedOn"]))
                };
                inventoryChanges.Add(inventoryChange);
            }

            return inventoryChanges;
        }

        /// <summary>
        /// Inserts the pizza count into the database
        /// </summary>
        /// <param name="count">Dictionary of pizzas and their counts</param>
        public void PizzaCountIn(Dictionary<Pizza, int> count)
        {
            PizzaCount(count, true);
        }

        /// <summary>
        /// Inserts the pizza count into the database
        /// </summary>
        /// <param name="count">Dictionary of pizzas and their counts</param>
        public void PizzaCountOut(Dictionary<Pizza, int> count)
        {
            PizzaCount(count, false);
        }

        /// <summary>
        /// Returns a list of the in pizza count (empty if no pizza count in yet)
        /// </summary>
        /// <returns>List of PizzaCount</returns>
        public List<PizzaCount> GetPizzaCountIn()
        {
            // Create command
            var command = new SqlCommand(
                "SELECT * FROM PizzaCount WHERE shiftID=@shiftID AND [in]=1")
            {
                CommandType = CommandType.Text,
                Connection = Connections.FDSConnection()
            };
            command.Parameters.Add(new SqlParameter("shiftID", ShiftId));

            // Execute command
            command.Connection.Open();
            var reader = command.ExecuteReader();

            // Set up a list for counts
            var counts = new List<PizzaCount>();

            // For each row add a count to the list
            while (reader.Read())
            {
                var pizzaCount = new PizzaCount
                {
                    Pizza = Pizza.GetPizzaByPizzaId(int.Parse(String.Format("{0}", reader["pizzaID"]))),
                    SystemCount = int.Parse(String.Format("{0}", reader["systemCount"])),
                    UserCount = int.Parse(String.Format("{0}", reader["userCount"]))
                };
                counts.Add(pizzaCount);
            }

            // Return the list
            return counts;
        }

        /// <summary>
        /// Returns a list of the out pizza count (empty if no pizza count out yet)
        /// </summary>
        /// <returns></returns>
        public List<PizzaCount> GetPizzaCountOut()
        {
            // Create command
            var command = new SqlCommand(
                "SELECT * FROM PizzaCount WHERE shiftID=@shiftID AND [in]=0")
            {
                CommandType = CommandType.Text,
                Connection = Connections.FDSConnection()
            };
            command.Parameters.Add(new SqlParameter("shiftID", ShiftId));

            // Execute command
            command.Connection.Open();
            var reader = command.ExecuteReader();

            // Set up a list for counts
            var counts = new List<PizzaCount>();

            // For each row add a count to the list
            while (reader.Read())
            {
                var pizzaCount = new PizzaCount
                {
                    Pizza = Pizza.GetPizzaByPizzaId(int.Parse(String.Format("{0}", reader["pizzaID"]))),
                    SystemCount = int.Parse(String.Format("{0}", reader["systemCount"])),
                    UserCount = int.Parse(String.Format("{0}", reader["userCount"]))
                };
                counts.Add(pizzaCount);
            }

            // Return the list
            return counts;
        }

        /// <summary>
        /// Destroys the shift and any related pizza counts - WARNING: SHOULD PROBABLY ONLY BE USED
        /// FOR TESTING
        /// </summary>
        public void Destroy()
        {
            // Create command
            var command = new SqlCommand(
                "DELETE FROM PizzaCount WHERE shiftID=@shiftID; DELETE FROM Shifts WHERE shiftID=@shiftID")
            {
                CommandType = CommandType.Text,
                Connection = Connections.FDSConnection()
            };
            command.Parameters.Add(new SqlParameter("shiftID", ShiftId));

            // Execute command
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        #endregion Public Non-Static Methods
    }

    public class PizzaCount
    {
        public Pizza Pizza;
        public int SystemCount;
        public int UserCount;
    }
}