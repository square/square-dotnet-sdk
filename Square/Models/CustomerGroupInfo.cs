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
    public class CustomerGroupInfo 
    {
        public CustomerGroupInfo(string id,
            string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// The ID of the Customer Group.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// The name of the Customer Group.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(Id,
                Name);
            return builder;
        }

        public class Builder
        {
            private string id;
            private string name;

            public Builder(string id,
                string name)
            {
                this.id = id;
                this.name = name;
            }
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

            public CustomerGroupInfo Build()
            {
                return new CustomerGroupInfo(id,
                    name);
            }
        }
    }
}