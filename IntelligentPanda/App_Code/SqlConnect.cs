using System.Data.SqlClient;

/// <summary>
/// Summary description for SqlConnect
/// </summary>
public class SqlConnect
{
    private SqlConnection conn;

    public SqlConnect(string connString)
    {
        Initialize(connString);
    }

    /// <summary>
    /// Initializes a connection with the specified connection string.
    /// </summary>
    /// <param name="connString">The connection string being used.</param>
    public void Initialize(string connString)
    {
        conn = new SqlConnection(connString);
    }

    /// <summary>
    /// Opens a connection to the database.
    /// </summary>
    /// <returns>Returns true if the connection is successful.</returns>
    private bool OpenConnection()
    {
        try
        {
            conn.Open();
            return true;
        }
        catch (SqlException ex)
        {
            //The two most common error numbers when connecting are as follows:
            //0: Cannot connect to server.
            //1045: Invalid user name and/or password.
            switch (ex.Number)
            {
                case 0:
                    //MessageBox.Show("Cannot connect to server.  Contact administrator");
                    break;

                case 1045:
                    //MessageBox.Show("Invalid username/password, please try again");
                    break;
            }
            return false;
        }
    }

    /// <summary>
    /// Close the open connection.
    /// </summary>
    /// <returns>Returns true if the connection closed successfully, else, false.</returns>
    private bool CloseConnection()
    {
        try
        {
            conn.Close();
            return true;
        }
        catch (SqlException ex)
        {
            //MessageBox.Show(ex.Message);
            return false;
        }
    }

    /// <summary>
    /// Inserts into a table.
    /// </summary>
    /// <param name="table">The table to insert into.</param>
    /// <param name="columns">The columns to insert into.</param>
    /// <param name="parameters">The parameters for the query.</param>
    /// <param name="values">The values for the associated parameters.</param>
    public void InsertInto(string table, string[] columns, string[] parameters, string[] values)
    {
        //open connection
        if (this.OpenConnection() == true)
        {
            string dbColumns = "";
            for (int j = 0; j < columns.Length; j++)
            {
                if (j == 0)
                {
                    dbColumns = columns[j];
                }
                else
                {
                    dbColumns = dbColumns + ", " + columns[j];
                }
            }
            string queryParams = "";
            for (int k = 0; k < parameters.Length; k++)
            {
                if (k == 0)
                {
                    queryParams = parameters[k];
                }
                else
                {
                    queryParams = queryParams + ", " + parameters[k];
                }
            }
            string query = "INSERT INTO " + table + " (" + dbColumns + ") VALUES (" + queryParams + ")";
            //create command and assign the query and connection from the constructor
            SqlCommand cmd = new SqlCommand(query, conn);
            for (int i = 0; i < parameters.Length; i++)
            {
                cmd.Parameters.AddWithValue(parameters[i], values[i]);
            }
            //Execute command
            cmd.ExecuteNonQuery();

            //close connection
            this.CloseConnection();
        }
    }

    /// <summary>
    /// Selects a string from the specified table and columns.
    /// </summary>
    /// <param name="column">The columns to select from.</param>
    /// <param name="table">The table to select.</param>
    /// <param name="where">The conditional where statement.</param>
    /// <param name="parameters">The parameters for the query.</param>
    /// <param name="values">The values for the associated parameters.</param>
    /// <returns>Returns the scalar value.</returns>
    public string Select(string column, string table, string where, string[] parameters, string[] values)
    {
        string scalar = "";
        //open connection
        if (this.OpenConnection() == true)
        {
            string query = "";
            query = "SELECT " + column + " FROM " + table + " WHERE " + where;
            SqlCommand cmd = new SqlCommand(query, conn);
            for (int i = 0; i < parameters.Length; i++)
            {
                cmd.Parameters.AddWithValue(parameters[i], values[i]);
            }
            scalar = cmd.ExecuteScalar().ToString();

            //close connection
            this.CloseConnection();
        }
        return scalar;
    }

    /// <summary>
    /// Deletes the row(s) from the specified table and where clause.
    /// </summary>
    /// <param name="table">The table to delete from.</param>
    /// <param name="where">Define what will be deleted.</param>
    /// <param name="parameters">The parameters for the query.</param>
    /// <param name="values">The values for the associated parameters.</param>
    public void DeleteFrom(string table, string where, string[] parameters, string[] values)
    {
        if (this.OpenConnection() == true)
        {
            string query = "DELETE FROM " + table + " WHERE " + where;
            SqlCommand cmd = new SqlCommand(query, conn);
            for (int i = 0; i < parameters.Length; i++)
            {
                cmd.Parameters.AddWithValue(parameters[i], values[i]);
            }
            //execute the query
            cmd.ExecuteNonQuery();

            //close connection
            this.CloseConnection();
        }
    }
}