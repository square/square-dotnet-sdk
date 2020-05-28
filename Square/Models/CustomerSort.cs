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
    public class CustomerSort 
    {
        public CustomerSort(string field = null,
            string order = null)
        {
            Field = field;
            Order = order;
        }

        /// <summary>
        /// Specifies customer attributes as the sort key to customer profiles returned from a search.
        /// </summary>
        [JsonProperty("field")]
        public string Field { get; }

        /// <summary>
        /// The order (e.g., chronological or alphabetical) in which results from a request are returned.
        /// </summary>
        [JsonProperty("order")]
        public string Order { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Field(Field)
                .Order(Order);
            return builder;
        }

        public class Builder
        {
            private string field;
            private string order;

            public Builder() { }
            public Builder Field(string value)
            {
                field = value;
                return this;
            }

            public Builder Order(string value)
            {
                order = value;
                return this;
            }

            public CustomerSort Build()
            {
                return new CustomerSort(field,
                    order);
            }
        }
    }
}