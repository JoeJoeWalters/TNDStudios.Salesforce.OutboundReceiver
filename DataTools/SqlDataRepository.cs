using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        /// Default Constructor
        /// </summary>
        public SqlDataRepository()
        {

        }

        public override List<T> Get()
        {
            return new List<T>();
        }

        public override bool Save(T data)
        {
            Int32 insertCount = 0;

            using (var connection = new SqlConnection(ConnectionString))
            {
                insertCount = connection.Execute(InsertMapping, data);
            }

            return (insertCount != 0);
        }
    }
}
