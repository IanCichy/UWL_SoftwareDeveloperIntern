#region

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

#endregion

namespace FDS
{
    public class Hall
    {
        public readonly int HallId;
        public readonly String Name;

        public Hall()
        {
            HallId = 0;
            Name = "";
        }

        public Hall(int hallId, String hallName)
        {
            HallId = hallId;
            Name = hallName;
        }

        /// <summary>
        /// Finds a hall by its name. Returns null if no such hall.
        /// </summary>
        /// <param name="hallName">Name of hall to find</param>
        /// <returns>Hall if found, null if not.</returns>
        public static Hall GetHallByName(String hallName)
        {
            // Create a new command that gets a hall by name
            var command = new SqlCommand("SELECT * FROM Halls WHERE name LIKE @Name")
            {
                CommandType = CommandType.Text,
                Connection = Connections.FDSConnection()
            };
            command.Parameters.Add(new SqlParameter("Name", hallName));

            // Execute the command
            command.Connection.Open();
            var reader = command.ExecuteReader();

            // Read the results and return the first hall if there is one
            if (reader.Read())
            {
                var h = new Hall(int.Parse(String.Format("{0}", reader["hallID"])), String.Format("{0}", reader["name"]));
                reader.Close();
                command.Connection.Close();
                return h;
            }
            // if there is no result, return null
            reader.Close();
            command.Connection.Close();
            return null;
        }

        /// <summary>
        /// Returns a list of all halls.
        /// </summary>
        /// <returns>All halls.</returns>
        public static List<Hall> GetAllHalls()
        {
            // Create a list to hold the halls
            var halls = new List<Hall>();

            // Create a new command that gets the entire Halls table
            var command = new SqlCommand("SELECT * FROM Halls")
            {
                CommandType = CommandType.Text,
                Connection = Connections.FDSConnection()
            };

            // Execute the command
            command.Connection.Open();
            var reader = command.ExecuteReader();

            // Read the results and put them in the hall list
            while (reader.Read())
            {
                var h = new Hall(int.Parse(String.Format("{0}", reader["hallID"])), String.Format("{0}", reader["name"]));
                halls.Add(h);
            }

            reader.Close();
            command.Connection.Close();

            // Return the list of the halls
            return halls;
        }

        /// <summary>
        /// Finds a hall by its id. Returns null if no such hall.
        /// </summary>
        /// <param name="id">ID of hall to find</param>
        /// <returns>Hall if found, null if not.</returns>
        public static Hall GetHallById(int id)
        {
            // Create a new command that gets a hall by name
            var command = new SqlCommand("SELECT * FROM Halls WHERE hallID LIKE @ID")
            {
                CommandType = CommandType.Text,
                Connection = Connections.FDSConnection()
            };
            command.Parameters.Add(new SqlParameter("ID", id));

            // Execute the command
            command.Connection.Open();
            var reader = command.ExecuteReader();

            // Read the results and return the first hall if there is one
            if (reader.Read())
            {
                var h = new Hall(int.Parse(String.Format("{0}", reader["hallID"])), String.Format("{0}", reader["name"]));
                reader.Close();
                command.Connection.Close();
                return h;
            }
            // if there is no result, return null
            reader.Close();
            command.Connection.Close();
            return null;
        }
    }
}