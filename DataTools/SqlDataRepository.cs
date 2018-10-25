using System;
using System.Collections.Generic;
using System.Text;
using TNDStudios.Tools.Json.Objects;

namespace TNDStudios.Data.Repository
{
    public class SqlDataRepository<T> : DataRepositoryBase<T>, IDataRepository<T>
        where T : JsonBase
    {
        public override List<T> Get()
        {
            return new List<T>();
        }

        public override bool Save(T data)
        {
            //String email = sfObject.Get<String>("Email");
            //String email2 = (String)sfObject.Get(typeof(String), "Email");            

            return true;
        }
    }
}
