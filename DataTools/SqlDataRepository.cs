using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using TNDStudios.Tools.Json.Objects;

namespace TNDStudios.Data.Repository
{
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

        public override List<T> Get()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    return (connection.Query<T>(SelectMapping)).ToList();
                }
                catch { }
            }

            return new List<T>();
        }

        public override bool Save(T data)
        {
            Int32 insertCount = 0;

            using (var connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    insertCount = connection.Execute(InsertMapping, data);
                }
                catch { }
            }

            return (insertCount != 0);
        }
    }
}
