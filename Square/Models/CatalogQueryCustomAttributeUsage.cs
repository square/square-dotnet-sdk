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
    public class CatalogQueryCustomAttributeUsage 
    {
        public CatalogQueryCustomAttributeUsage(IList<string> customAttributeDefinitionIds = null,
            bool? hasValue = null)
        {
            CustomAttributeDefinitionIds = customAttributeDefinitionIds;
            HasValue = hasValue;
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("custom_attribute_definition_ids")]
        public IList<string> CustomAttributeDefinitionIds { get; }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("has_value")]
        public bool? HasValue { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .CustomAttributeDefinitionIds(CustomAttributeDefinitionIds)
                .HasValue(HasValue);
            return builder;
        }

        public class Builder
        {
            private IList<string> customAttributeDefinitionIds;
            private bool? hasValue;

            public Builder() { }
            public Builder CustomAttributeDefinitionIds(IList<string> value)
            {
                customAttributeDefinitionIds = value;
                return this;
            }

            public Builder HasValue(bool? value)
            {
                hasValue = value;
                return this;
            }

            public CatalogQueryCustomAttributeUsage Build()
            {
                return new CatalogQueryCustomAttributeUsage(customAttributeDefinitionIds,
                    hasValue);
            }
        }
    }
} 