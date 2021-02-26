
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
    public class CatalogCustomAttributeDefinitionStringConfig 
    {
        public CatalogCustomAttributeDefinitionStringConfig(bool? enforceUniqueness = null)
        {
            EnforceUniqueness = enforceUniqueness;
        }

        /// <summary>
        /// If true, each Custom Attribute instance associated with this Custom Attribute
        /// Definition must have a unique value within the seller's catalog. For
        /// example, this may be used for a value like a SKU that should not be
        /// duplicated within a seller's catalog. May not be modified after the
        /// definition has been created.
        /// </summary>
        [JsonProperty("enforce_uniqueness", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EnforceUniqueness { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogCustomAttributeDefinitionStringConfig : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"EnforceUniqueness = {(EnforceUniqueness == null ? "null" : EnforceUniqueness.ToString())}");
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

            return obj is CatalogCustomAttributeDefinitionStringConfig other &&
                ((EnforceUniqueness == null && other.EnforceUniqueness == null) || (EnforceUniqueness?.Equals(other.EnforceUniqueness) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 209404828;

            if (EnforceUniqueness != null)
            {
               hashCode += EnforceUniqueness.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .EnforceUniqueness(EnforceUniqueness);
            return builder;
        }

        public class Builder
        {
            private bool? enforceUniqueness;



            public Builder EnforceUniqueness(bool? enforceUniqueness)
            {
                this.enforceUniqueness = enforceUniqueness;
                return this;
            }

            public CatalogCustomAttributeDefinitionStringConfig Build()
            {
                return new CatalogCustomAttributeDefinitionStringConfig(enforceUniqueness);
            }
        }
    }
}