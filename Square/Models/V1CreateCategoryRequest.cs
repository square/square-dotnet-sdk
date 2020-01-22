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
    public class V1CreateCategoryRequest 
    {
        public V1CreateCategoryRequest(Models.V1Category body = null)
        {
            Body = body;
        }

        /// <summary>
        /// V1Category
        /// </summary>
        [JsonProperty("body")]
        public Models.V1Category Body { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Body(Body);
            return builder;
        }

        public class Builder
        {
            private Models.V1Category body;

            public Builder() { }
            public Builder Body(Models.V1Category value)
            {
                body = value;
                return this;
            }

            public V1CreateCategoryRequest Build()
            {
                return new V1CreateCategoryRequest(body);
            }
        }
    }
}