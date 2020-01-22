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
    public class V1UpdateCategoryRequest 
    {
        public V1UpdateCategoryRequest(Models.V1Category body)
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
            var builder = new Builder(Body);
            return builder;
        }

        public class Builder
        {
            private Models.V1Category body;

            public Builder(Models.V1Category body)
            {
                this.body = body;
            }
            public Builder Body(Models.V1Category value)
            {
                body = value;
                return this;
            }

            public V1UpdateCategoryRequest Build()
            {
                return new V1UpdateCategoryRequest(body);
            }
        }
    }
}