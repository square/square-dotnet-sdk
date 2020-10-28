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
    public class CashDrawerDevice 
    {
        public CashDrawerDevice(string id = null,
            string name = null)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// The device Square-issued ID
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The device merchant-specified name.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(Id)
                .Name(Name);
            return builder;
        }

        public class Builder
        {
            private string id;
            private string name;



            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

            public Builder Name(string name)
            {
                this.name = name;
                return this;
            }

            public CashDrawerDevice Build()
            {
                return new CashDrawerDevice(id,
                    name);
            }
        }
    }
}