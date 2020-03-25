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
        [JsonProperty("enforce_uniqueness")]
        public bool? EnforceUniqueness { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .EnforceUniqueness(EnforceUniqueness);
            return builder;
        }

        public class Builder
        {
            private bool? enforceUniqueness;

            public Builder() { }
            public Builder EnforceUniqueness(bool? value)
            {
                enforceUniqueness = value;
                return this;
            }

            public CatalogCustomAttributeDefinitionStringConfig Build()
            {
                return new CatalogCustomAttributeDefinitionStringConfig(enforceUniqueness);
            }
        }
    }
}