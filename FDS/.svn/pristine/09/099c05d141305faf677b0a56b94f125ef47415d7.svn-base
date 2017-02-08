using System;
using System.Data.SqlClient;

namespace FDS
{
    public static class Connections
    {
        // connection strings
        private const String FDSConnectionString =
            "Data Source=SDB-ResLifeC\\reslife;Initial Catalog=FrontDeskSuite;User Id=FrontDesk;Password=DG#eQ*=CT";

        public static SqlConnection FDSConnection()
        {
            return new SqlConnection(FDSConnectionString);
        }
    }
}