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
    public class InvoiceSort 
    {
        public InvoiceSort(string field,
            string order = null)
        {
            Field = field;
            Order = order;
        }

        /// <summary>
        /// Field to use for sorting.
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
            var builder = new Builder(Field)
                .Order(Order);
            return builder;
        }

        public class Builder
        {
            private string field;
            private string order;

            public Builder(string field)
            {
                this.field = field;
            }
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

            public InvoiceSort Build()
            {
                return new InvoiceSort(field,
                    order);
            }
        }
    }
}