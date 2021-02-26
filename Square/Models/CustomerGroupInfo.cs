
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CustomerGroupInfo : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Id = {(Id == null ? "null" : Id == string.Empty ? "" : Id)}");
            toStringOutput.Add($"Name = {(Name == null ? "null" : Name == string.Empty ? "" : Name)}");
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }

            return obj is CustomerGroupInfo other &&
                ((Id == null && other.Id == null) || (Id?.Equals(other.Id) == true)) &&
                ((Name == null && other.Name == null) || (Name?.Equals(other.Name) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -35220093;

            if (Id != null)
            {
               hashCode += Id.GetHashCode();
            }

            if (Name != null)
            {
               hashCode += Name.GetHashCode();
            }

            return hashCode;
        }

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

            public CustomerGroupInfo Build()
            {
                return new CustomerGroupInfo(id,
                    name);
            }
        }
    }
}