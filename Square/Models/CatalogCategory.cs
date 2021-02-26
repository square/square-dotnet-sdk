
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
    public class CatalogCategory 
    {
        public CatalogCategory(string name = null)
        {
            Name = name;
        }

        /// <summary>
        /// The category name. This is a searchable attribute for use in applicable query filters, and its value length is of Unicode code points.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogCategory : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
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

            return obj is CatalogCategory other &&
                ((Name == null && other.Name == null) || (Name?.Equals(other.Name) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1264434683;

            if (Name != null)
            {
               hashCode += Name.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Name(Name);
            return builder;
        }

        public class Builder
        {
            private string name;



            public Builder Name(string name)
            {
                this.name = name;
                return this;
            }

            public CatalogCategory Build()
            {
                return new CatalogCategory(name);
            }
        }
    }
}