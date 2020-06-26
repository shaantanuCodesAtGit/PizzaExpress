using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Data.Respository
{
    public abstract class FileContext
    {
        protected readonly string ConnectionString;

        protected FileContext(string connectionString)
        {
            ConnectionString = connectionString;

            // init props.
            InitSet();
        }

        /// <summary>
        /// Init mainly derived class properties which are of type Respository.
        /// </summary>
        private void InitSet()
        {
            var propertyInfos = this.GetType().GetProperties()
                .Where(x => x.PropertyType.IsGenericType
                            && x.PropertyType.GetGenericTypeDefinition() == typeof(Respository<>));

            var repoType = typeof(Respository<>);
            foreach (var propertyInfo in propertyInfos)
            {
                var getGenericArg = propertyInfo.PropertyType.GetGenericArguments()[0];
                Type[] typeArgs = { getGenericArg };
                var gen = repoType.MakeGenericType(typeArgs);

                propertyInfo.SetValue(this, Activator.CreateInstance(gen, ConnectionString), null);
            }
        }
    }
}
