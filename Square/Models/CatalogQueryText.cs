
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
    public class CatalogQueryText 
    {
        public CatalogQueryText(IList<string> keywords)
        {
            Keywords = keywords;
        }

        /// <summary>
        /// A list of 1, 2, or 3 search keywords. Keywords with fewer than 3 characters are ignored.
        /// </summary>
        [JsonProperty("keywords")]
        public IList<string> Keywords { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogQueryText : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Keywords = {(Keywords == null ? "null" : $"[{ string.Join(", ", Keywords)} ]")}");
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

            return obj is CatalogQueryText other &&
                ((Keywords == null && other.Keywords == null) || (Keywords?.Equals(other.Keywords) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -192618322;

            if (Keywords != null)
            {
               hashCode += Keywords.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(Keywords);
            return builder;
        }

        public class Builder
        {
            private IList<string> keywords;

            public Builder(IList<string> keywords)
            {
                this.keywords = keywords;
            }

            public Builder Keywords(IList<string> keywords)
            {
                this.keywords = keywords;
                return this;
            }

            public CatalogQueryText Build()
            {
                return new CatalogQueryText(keywords);
            }
        }
    }
}