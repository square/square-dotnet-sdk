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
    public class OrderSource 
    {
        public OrderSource(string name = null)
        {
            Name = name;
        }

        /// <summary>
        /// The name used to identify the place (physical or digital) that an order originates.
        /// If unset, the name defaults to the name of the application that created the order.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Name(Name);
            return builder;
        }

        public class Builder
        {
            private string name;

            public Builder() { }
            public Builder Name(string value)
            {
                name = value;
                return this;
            }

            public OrderSource Build()
            {
                return new OrderSource(name);
            }
        }
    }
}