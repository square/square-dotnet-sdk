using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class CatalogObjectBatch 
    {
        public CatalogObjectBatch(IList<Models.CatalogObject> objects = null)
        {
            Objects = objects;
        }

        /// <summary>
        /// A list of CatalogObjects belonging to this batch.
        /// </summary>
        [JsonProperty("objects")]
        public IList<Models.CatalogObject> Objects { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Objects(Objects);
            return builder;
        }

        public class Builder
        {
            private IList<Models.CatalogObject> objects = new List<Models.CatalogObject>();

            public Builder() { }
            public Builder Objects(IList<Models.CatalogObject> value)
            {
                objects = value;
                return this;
            }

            public CatalogObjectBatch Build()
            {
                return new CatalogObjectBatch(objects);
            }
        }
    }
}