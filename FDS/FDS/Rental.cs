#region

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

#endregion

namespace FDS
{
    public class Rental
    {
        #region Properties

        public Employee CheckedInBy;
        public DateTime? CheckedInOn;
        public Employee CheckedOutBy;
        public DateTime CheckedOutOn;
        public Equipment Equipment;
        public int RentalId;
        public String StudentEagleId;

        #endregion

        #region Public Static Methods

        /// <summary>
        ///     Checks out a given piece of equipment.
        /// </summary>
        /// <param name="equipment">The equipment to checkout</param>
        /// <param name="eagleId">The Eagle ID of the student checking out the equipment</param>
        /// <param name="employee">The employee checking out the equipment</param>
        /// <returns>Rental just created</returns>
        public static Rental Checkout(Equipment equipment, String eagleId, Employee employee)
        {
            // Create the command
            var command =
                new SqlCommand(
                    "INSERT INTO Rentals VALUES (@equipmentID, @eagleID, @checkedOutOn, @checkedOutBy, NULL, NULL)")
                {
                    CommandType = CommandType.Text,
                    Connection = Connections.FDSConnection()
                };
            command.Parameters.Add(new SqlParameter("equipmentID", equipment.EquipmentId));
            command.Parameters.Add(new SqlParameter("eagleID", eagleId));
            command.Parameters.Add(new SqlParameter("checkedOutOn", DateTime.Now));
            command.Parameters.Add(new SqlParameter("checkedOutBy", employee.GetEmployeeId()));

            // Execute the command
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();

            // Set the status of the equipment to checked out
            equipment.SetStatus("checked out");
            return GetLastRentalOfEquipment(equipment);
        }

        /// <summary>
        ///     Checks in the given equipment. Returns null if this equipment is not currently checked out
        /// </summary>
        /// <param name="equipment">Equipment to check in</param>
        /// <param name="employee">Employee checking equipment in</param>
        /// <param name="condition">Condition of returned equipment</param>
        /// <returns></returns>
        public static Rental CheckIn(Equipment equipment, Employee employee, String condition)
        {
            var rental = GetLastRentalOfEquipment(equipment);
            if (rental.CheckedInBy == null)
            {
                // Create the command
                var command =
                    new SqlCommand(
                        "UPDATE Rentals SET checkedInBy=@employeeID, checkedInOn=@checkedInOn WHERE rentalID=@rentalID")
                    {
                        CommandType = CommandType.Text,
                        Connection = Connections.FDSConnection()
                    };
                command.Parameters.Add(new SqlParameter("checkedInOn", DateTime.Now));
                command.Parameters.Add(new SqlParameter("employeeID", employee.GetEmployeeId()));
                command.Parameters.Add(new SqlParameter("rentalID", rental.RentalId));

                // Execute the command
                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();

                // Set the status and condition of the equipment
                equipment.SetStatus("available");
                equipment.SetCondition(condition);

                return GetLastRentalOfEquipment(equipment);
            }
            // Last rental has already been checked in
            return null;
        }

        /// <summary>
        ///     Returns the rental corresponding to the given Rental ID, null if none found
        /// </summary>
        /// <param name="rentalId">Rental ID of rental to find</param>
        /// <returns>Rental if found, null otherwise</returns>
        public static Rental GetRentalById(int rentalId)
        {
            // Create a new command
            var command = new SqlCommand("SELECT * FROM Rentals WHERE rentalID=@rentalID")
            {
                CommandType = CommandType.Text,
                Connection = Connections.FDSConnection()
            };
            command.Parameters.Add(new SqlParameter("rentalID", rentalId));

            // Execute the command
            command.Connection.Open();
            var reader = command.ExecuteReader();

            var rental = new Rental();

            // Read the results and return the first rental
            if (reader.Read())
            {
                rental.RentalId = int.Parse(String.Format("{0}", reader["rentalID"]));
                rental.Equipment = Equipment.GetEquipmentById(int.Parse(String.Format("{0}", reader["equipmentID"])));
                rental.StudentEagleId = String.Format("{0}", reader["student"]);
                rental.CheckedOutOn = DateTime.Parse(String.Format("{0}", reader["checkedOutOn"]));
                rental.CheckedOutBy =
                    Employee.GetEmployeeByEmployeeId(int.Parse(String.Format("{0}", reader["checkedOutBy"])));
                rental.CheckedInOn = reader["checkedInOn"] == DBNull.Value
                    ? (DateTime?)null
                    : DateTime.Parse(String.Format("{0}", reader["checkedInOn"]));
                rental.CheckedInBy =
                    Employee.GetEmployeeByEmployeeId(
                        int.Parse(String.Format("{0}",
                            reader["checkedInBy"] == DBNull.Value ? -1 : reader["CheckedInBy"])));
                reader.Close();
                command.Connection.Close();
                return rental;
            }
            // if there is no result, return null
            reader.Close();
            command.Connection.Close();
            return null;
        }

        /// <summary>
        ///     Gets the last rental of the given equipment
        /// </summary>
        /// <param name="equipment">Equipment to get last rental of</param>
        /// <returns>Last Rental of equipment, null if none is found</returns>
        public static Rental GetLastRentalOfEquipment(Equipment equipment)
        {
            // Create a new command
            var command =
                new SqlCommand("SELECT * FROM Rentals WHERE equipmentID=@equipmentID ORDER BY checkedOutOn DESC")
                {
                    CommandType = CommandType.Text,
                    Connection = Connections.FDSConnection()
                };
            command.Parameters.Add(new SqlParameter("equipmentID", equipment.EquipmentId));

            // Execute the command
            command.Connection.Open();
            var reader = command.ExecuteReader();

            // Read the results and add each to the equipment list
            if (reader.Read())
            {
                var rental = new Rental
                {
                    RentalId = int.Parse(String.Format("{0}", reader["rentalID"])),
                    Equipment = Equipment.GetEquipmentById(int.Parse(String.Format("{0}", reader["equipmentID"]))),
                    StudentEagleId = String.Format("{0}", reader["student"]),
                    CheckedOutOn = DateTime.Parse(String.Format("{0}", reader["checkedOutOn"])),
                    CheckedOutBy =
                        Employee.GetEmployeeByEmployeeId(int.Parse(String.Format("{0}", reader["checkedOutBy"]))),
                    CheckedInOn =
                        reader["checkedInOn"] == DBNull.Value
                            ? (DateTime?)null
                            : DateTime.Parse(String.Format("{0}", reader["checkedInOn"])),
                    CheckedInBy =
                        Employee.GetEmployeeByEmployeeId(
                            int.Parse(String.Format("{0}",
                                reader["checkedInBy"] == DBNull.Value ? -1 : reader["CheckedInBy"])))
                };
                reader.Close();
                command.Connection.Close();
                return rental;
            }

            // Shut down everything
            reader.Close();
            command.Connection.Close();
            return null;
        }

        /// <summary>
        ///     Gets all the rentals of the given equipment
        /// </summary>
        /// <param name="equipment">Equipment to get rentals of</param>
        /// <returns>List of all rentals of the given equipment</returns>
        public static List<Rental> GetAllRentalsOfEquipment(Equipment equipment)
        {
            // Create a new command
            var command = new SqlCommand("SELECT * FROM Rentals WHERE equipmentID=@equipmentID")
            {
                CommandType = CommandType.Text,
                Connection = Connections.FDSConnection()
            };
            command.Parameters.Add(new SqlParameter("equipmentID", equipment.EquipmentId));

            // Execute the command
            command.Connection.Open();
            var reader = command.ExecuteReader();

            // Create a list to store all the quipment
            var rentals = new List<Rental>();

            // Read the results and add each to the equipment list
            while (reader.Read())
            {
                var rental = new Rental
                {
                    RentalId = int.Parse(String.Format("{0}", reader["rentalID"])),
                    Equipment = Equipment.GetEquipmentById(int.Parse(String.Format("{0}", reader["equipmentID"]))),
                    StudentEagleId = String.Format("{0}", reader["student"]),
                    CheckedOutOn = DateTime.Parse(String.Format("{0}", reader["checkedOutOn"])),
                    CheckedOutBy =
                        Employee.GetEmployeeByEmployeeId(int.Parse(String.Format("{0}", reader["checkedOutBy"]))),
                    CheckedInOn =
                        reader["checkedInOn"] == DBNull.Value
                            ? (DateTime?)null
                            : DateTime.Parse(String.Format("{0}", reader["checkedInOn"])),
                    CheckedInBy =
                        Employee.GetEmployeeByEmployeeId(
                            int.Parse(String.Format("{0}",
                                reader["checkedInBy"] == DBNull.Value ? -1 : reader["CheckedInBy"])))
                };
                rentals.Add(rental);
            }

            reader.Close();
            command.Connection.Close();
            return rentals;
        }

        /// <summary>
        ///     Destroys all rentals of the given equipment in the database -- WARNING: PROBABLY SHOULD ONLY BE USED FOR TESTING
        /// </summary>
        /// <param name="equipment">Equipment to destroy rentals of</param>
        public static void DestroyAllRentalsOfEquipment(Equipment equipment)
        {
            var rentals = GetAllRentalsOfEquipment(equipment);
            foreach (var rental in rentals)
            {
                rental.Destroy();
            }
        }

        #endregion

        #region Public Non-Static Methods

        /// <summary>
        ///     Removes the current rental from the database
        /// </summary>
        public void Destroy()
        {
            var command = new SqlCommand("DELETE FROM Rentals WHERE rentalID=@rentalID")
            {
                CommandType = CommandType.Text,
                Connection = Connections.FDSConnection()
            };
            command.Parameters.Add(new SqlParameter("rentalID", RentalId));

            command.Connection.Open();
            command.ExecuteNonQuery();
        }

        #endregion
    }
}