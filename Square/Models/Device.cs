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
    public class Device 
    {
        public Device(string id = null,
            string name = null)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// The device's Square-issued ID.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// The device's merchant-specified name.
        /// </summary>
        [JsonProperty("name")]
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

            public Builder() { }
            public Builder Id(string value)
            {
                id = value;
                return this;
            }

            public Builder Name(string value)
            {
                name = value;
                return this;
            }

            public Device Build()
            {
                return new Device(id,
                    name);
            }
        }
    }
}