using System;
using System.Collections.Generic;
using System.Text;
using TNDStudios.Tools.Json.Objects;

namespace TNDStudios.Data.Repository
{
    /// <summary>
    /// Base implementation of the data repository pattern
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DataRepositoryBase<T> : IDataRepository<T> 
        where T : JsonBase
    {
        /// <summary>
        /// Hold the connection string
        /// </summary>
        public virtual String ConnectionString { get; set; }

        /// <summary>
        /// Get a set of data objects
        /// </summary>
        /// <returns>A set of mapped objects from the data source</returns>
        public virtual List<T> Get()
            => throw new NotImplementedException();

        /// <summary>
        /// Save a data object to the data destination
        /// </summary>
        /// <param name="data">The data item to be saved</param>
        /// <returns>
        /// A success or failure flag, the object will have it's id
        /// updated if it was successful etc ..
        /// </returns>
        public virtual Boolean Save(T data)
            => throw new NotImplementedException();
    }
}
