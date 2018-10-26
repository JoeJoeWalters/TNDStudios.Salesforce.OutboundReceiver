using System;
using System.Collections.Generic;
using TNDStudios.Tools.Json.Objects;

namespace TNDStudios.Data.Repository
{
    // https://medium.com/dapper-net/custom-columns-mapping-1cd45dfd51d6

    /// <summary>
    /// Interface to define the data repository pattern
    /// </summary>
    /// <typeparam name="T">The data type to be handled</typeparam>
    public interface IDataRepository<T> 
        //where T : JsonBase
    {
        /// <summary>
        /// Connection string for the repository
        /// </summary>
        String ConnectionString { get; set; }

        /// <summary>
        /// Get a set of data objects
        /// </summary>
        /// <returns>A set of mapped objects from the data source</returns>
        List<T> Get();

        /// <summary>
        /// Save a data object to the data destination
        /// </summary>
        /// <param name="data">The data item to be saved</param>
        /// <returns>
        /// A success or failure flag, the object will have it's id
        /// updated if it was successful etc ..
        /// </returns>
        Boolean Save(T data);
    }
}
