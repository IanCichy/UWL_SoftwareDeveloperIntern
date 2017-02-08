#region

using System;
using System.Data;
using System.Data.SqlClient;

#endregion

namespace FDS
{
    public class Options
    {
        #region Properties

        public Hall Hall;
        public String Message;
        public String EagleID;
        public DateTime Date;

        #endregion Properties

        #region Private Methods

        /// <summary>
        ///
        public static void UpdateMessage(Hall Hall, String Message, String EagleID, DateTime Date)
        {
            // Set up update command
            var command =
                new SqlCommand("INSERT INTO HallMessage VALUES ( @HallId, @message, @EagleID, @Date)")
                {
                    CommandType = CommandType.Text,
                    Connection = Connections.FDSConnection()
                };

            command.Parameters.Add(new SqlParameter("hallId", Hall.HallId));
            command.Parameters.Add(new SqlParameter("message", Message));
            command.Parameters.Add(new SqlParameter("EagleID", EagleID));
            command.Parameters.Add(new SqlParameter("Date", Date));

            // Execute command
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        public static String GetMessage(Hall Hall)
        {
            // Set up update command
            var command =
                new SqlCommand("SELECT TOP 1 message from HallMessage where HallId=@HallId ORDER BY Date DESC")
                {
                    CommandType = CommandType.Text,
                    Connection = Connections.FDSConnection()
                };

            command.Parameters.Add(new SqlParameter("hallId", Hall.HallId));

            // Execute command
            command.Connection.Open();
            String message = (String)command.ExecuteScalar();
            command.Connection.Close();

            return message;
        }

        public static String GetMessage(int Hall)
        {
            // Set up update command
            var command =
                new SqlCommand("SELECT TOP 1 message from HallMessage where HallId=@HallId ORDER BY Date DESC")
                {
                    CommandType = CommandType.Text,
                    Connection = Connections.FDSConnection()
                };

            command.Parameters.Add(new SqlParameter("hallId", Hall));

            // Execute command
            command.Connection.Open();
            String message = (String)command.ExecuteScalar();
            command.Connection.Close();

            return message;
        }

        public static String GetMessageDate(Hall Hall)
        {
            // Set up update command
            var command =
                new SqlCommand("SELECT Date from HallMessage where HallId=@HallId ORDER BY Date DESC")
                {
                    CommandType = CommandType.Text,
                    Connection = Connections.FDSConnection()
                };

            command.Parameters.Add(new SqlParameter("hallId", Hall.HallId));

            // Execute command
            command.Connection.Open();
            DateTime date = (DateTime)command.ExecuteScalar();
            command.Connection.Close();

            return date.ToString();
        }

        #endregion Private Methods
    }
}