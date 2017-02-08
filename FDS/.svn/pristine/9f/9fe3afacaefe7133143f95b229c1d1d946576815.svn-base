#region

using System;
using System.Data;
using System.Data.SqlClient;

#endregion

namespace FDS
{
    public class Report
    {
        #region Properties

        public int ReportID;
        public Hall Hall;
        public String ReportName;
        public DateTime StartDate;
        public DateTime EndDate;

        #endregion Properties

        #region Private Methods

        private static Report GetReportFromReader(SqlDataReader reader)
        {
            var report = new Report
            {
                ReportID = int.Parse(String.Format("{0}", reader["ReportID"])),
                ReportName = String.Format("{0}", reader["ReportName"]),
                Hall = Hall.GetHallById(int.Parse(String.Format("{0}", reader["hallID"]))),
                StartDate = DateTime.Parse(String.Format("{0}", reader["StartDate"])),
                EndDate = DateTime.Parse(String.Format("{0}", reader["EndDate"]))
            };
            return report;
        }

        /// <summary>
        ///
        public static int AddReport(String name, Hall hall, DateTime StartDate, DateTime EndDate)
        {
            Report newRep = new Report();

            // Set up insert command
            var command =
                new SqlCommand("INSERT INTO Reports VALUES (@name, @hallId, @StartDate, @EndDate)")
                {
                    CommandType = CommandType.Text,
                    Connection = Connections.FDSConnection()
                };
            command.Parameters.Add(new SqlParameter("hallId", hall.HallId));
            command.Parameters.Add(new SqlParameter("name", name));
            command.Parameters.Add(new SqlParameter("StartDate", StartDate));
            command.Parameters.Add(new SqlParameter("EndDate", EndDate));

            // Execute command
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();

            return GetReportByNameAndHallAndDate(name, hall, StartDate, EndDate);
        }

        /// <summary>
        /// Deletes Equipment as determined by the given Equipment ID
        /// </summary>
        /// <param name="EquipmentId">Equipment ID of Equipment to find</param>
        public static Report DeleteReport(int ReportID)
        {
            // Create the command
            var command2 =
                new SqlCommand("Delete FROM ShiftsForReport WHERE ReportID=@ReportID")
                {
                    CommandType = CommandType.Text,
                    Connection = Connections.FDSConnection()
                };
            command2.Parameters.Add(new SqlParameter("ReportID", ReportID));

            // Execute the command
            command2.Connection.Open();
            command2.ExecuteNonQuery();
            command2.Connection.Close();

            // Create the command
            var command =
                new SqlCommand("Delete FROM Reports WHERE ReportID=@ReportID")
                {
                    CommandType = CommandType.Text,
                    Connection = Connections.FDSConnection()
                };
            command.Parameters.Add(new SqlParameter("ReportID", ReportID));

            // Execute the command
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();

            return null;
        }

        public static Report AddShiftToReport(int ReportID, int ShiftID)
        {
            // Set up insert command
            var command =
                new SqlCommand("INSERT INTO ShiftsForReport VALUES (@ReportID, @ShiftID, 0)")
                {
                    CommandType = CommandType.Text,
                    Connection = Connections.FDSConnection()
                };
            command.Parameters.Add(new SqlParameter("ReportID", ReportID));
            command.Parameters.Add(new SqlParameter("ShiftID", ShiftID));

            // Execute command
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();

            return null;
        }

        public static int GetReportByNameAndHallAndDate(String name, Hall hall, DateTime StartDate, DateTime EndDate)
        {
            // Create the command
            var command =
                new SqlCommand("SELECT ReportID FROM Reports where HallID=@HallID and ReportName=@ReportName ORDER BY ReportID DESC")
                {
                    CommandType = CommandType.Text,
                    Connection = Connections.FDSConnection()
                };
            command.Parameters.Add(new SqlParameter("hallId", hall.HallId));
            command.Parameters.Add(new SqlParameter("ReportName", name));
            //command.Parameters.Add(new SqlParameter("StartDate", StartDate));
            //command.Parameters.Add(new SqlParameter("EndDate", EndDate));

            // Execute the command
            command.Connection.Open();
            var ReportID = (int)command.ExecuteScalar();
            command.Connection.Close();
            return ReportID;
        }

        public static DateTime getStartDate(int ReportId)
        {
            // Create the command
            var command =
                new SqlCommand("SELECT StartDate FROM REPORTS WHERE ReportID=@ReportID")
                {
                    CommandType = CommandType.Text,
                    Connection = Connections.FDSConnection()
                };
            command.Parameters.Add(new SqlParameter("ReportID", ReportId));

            // Execute the command
            command.Connection.Open();
            var StartDate = (DateTime)command.ExecuteScalar();
            command.Connection.Close();
            return StartDate;
        }

        public static DateTime getEndDate(int ReportId)
        {
            // Create the command
            var command =
                new SqlCommand("SELECT EndDate FROM REPORTS WHERE ReportID=@ReportID")
                {
                    CommandType = CommandType.Text,
                    Connection = Connections.FDSConnection()
                };
            command.Parameters.Add(new SqlParameter("ReportID", ReportId));

            // Execute the command
            command.Connection.Open();
            var EndDate = (DateTime)command.ExecuteScalar();
            command.Connection.Close();
            return EndDate;
        }

        #endregion Private Methods
    }
}