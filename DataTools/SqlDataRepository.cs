using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using TNDStudios.Tools.Json.Objects;

namespace TNDStudios.Data.Repository
{
    /// <summary>
    /// Implementation of the repository pattern for use with Microsoft SQL
    /// </summary>
    /// <typeparam name="T">The type of object to be handled</typeparam>
    public class SqlDataRepository<T> : DataRepositoryBase<T>, IDataRepository<T>
    //where T : JsonBase
    {
        /// <summary>
        /// The table to save to
        /// </summary>
        public String Table { get; set; }

        /// <summary>
        /// The insert mapping string
        /// </summary>
        public String InsertMapping { get; set; }

        /// <summary>
        /// The insert mapping string
        /// </summary>
        public String SelectMapping { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SqlDataRepository()
        {

        }

        /// <summary>
        /// Get a list of items from the database
        /// </summary>
        /// <returns>The list of items that matches the query</returns>
        public override List<T> Get()
        {
            // Open a connection to the SQL Server database
            using (var connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    // Query the data from the SQL statement using Dapper
                    return (connection.Query<T>(SelectMapping)).ToList();
                }
                catch { }
            }

            // Something must have gone wrong to get here so return an empty list
            return new List<T>();
        }

        /// <summary>
        /// Save data to the SQL Server
        /// </summary>
        /// <param name="data">The data item to be saved</param>
        /// <returns>A success or failure flag</returns>
        public override Boolean Save(T data)
        {
            Int32 insertCount = 0; // Marker to indicate how many records were saved (1 or 0 in this case)

            // Create and use a SQL Connection
            using (var connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    // Try to insert the data to the table in SQL and get the record count back
                    insertCount = connection.Execute(InsertMapping, data);
                }
                catch { }
            }

            // If we indicate that there was a record added then return success
            return (insertCount != 0);
        }
    }
}
