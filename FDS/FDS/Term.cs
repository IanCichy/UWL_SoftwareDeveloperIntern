using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FDS
{
    public class Term
    {
        public String Name;
        public DateTime startDate;
        public DateTime endDate;

        public Term(String name, DateTime s, DateTime e)
        {
            Name = name;
            startDate = s;
            endDate = e;
        }

        /// <summary>
        /// Returns a list of all Terms.
        /// </summary>
        public static List<Term> GetAllTerms()
        {
            // Create a list to hold the halls
            var Terms = new List<Term>();

            // Create a new command that gets the entire Halls table
            var command = new SqlCommand("SELECT * FROM Terms WHERE isActive=1 ORDER BY Term DESC")
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
                var T = new Term(reader["Term"].ToString(),
                    DateTime.Parse(reader["startDate"].ToString()),
                    DateTime.Parse(reader["endDate"].ToString()));
                Terms.Add(T);
            }

            reader.Close();
            command.Connection.Close();

            // Return the list of the halls
            return Terms;
        }

        public static DateTime getTermStartDate(Term t)
        {
            return t.startDate;
        }

        public static DateTime getTermEndDate(Term t)
        {
            return t.endDate;
        }



    }
}