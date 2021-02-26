
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
    public class CatalogCustomAttributeDefinitionNumberConfig 
    {
        public CatalogCustomAttributeDefinitionNumberConfig(int? precision = null)
        {
            Precision = precision;
        }

        /// <summary>
        /// An integer between 0 and 5 that represents the maximum number of
        /// positions allowed after the decimal in number custom attribute values
        /// For example:
        /// - if the precision is 0, the quantity can be 1, 2, 3, etc.
        /// - if the precision is 1, the quantity can be 0.1, 0.2, etc.
        /// - if the precision is 2, the quantity can be 0.01, 0.12, etc.
        /// Default: 5
        /// </summary>
        [JsonProperty("precision", NullValueHandling = NullValueHandling.Ignore)]
        public int? Precision { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogCustomAttributeDefinitionNumberConfig : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Precision = {(Precision == null ? "null" : Precision.ToString())}");
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

            return obj is CatalogCustomAttributeDefinitionNumberConfig other &&
                ((Precision == null && other.Precision == null) || (Precision?.Equals(other.Precision) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 196624818;

            if (Precision != null)
            {
               hashCode += Precision.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Precision(Precision);
            return builder;
        }

        public class Builder
        {
            private int? precision;



            public Builder Precision(int? precision)
            {
                this.precision = precision;
                return this;
            }

            public CatalogCustomAttributeDefinitionNumberConfig Build()
            {
                return new CatalogCustomAttributeDefinitionNumberConfig(precision);
            }
        }
    }
}