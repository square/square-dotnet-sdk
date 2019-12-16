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
    public class CatalogQueryFilteredItemsCustomAttributeFilter 
    {
        public CatalogQueryFilteredItemsCustomAttributeFilter(string filterType = null,
            IList<string> customAttributeDefinitionIds = null,
            string customAttributeValueExact = null,
            string customAttributeValuePrefix = null,
            string customAttributeMinValue = null,
            string customAttributeMaxValue = null)
        {
            FilterType = filterType;
            CustomAttributeDefinitionIds = customAttributeDefinitionIds;
            CustomAttributeValueExact = customAttributeValueExact;
            CustomAttributeValuePrefix = customAttributeValuePrefix;
            CustomAttributeMinValue = customAttributeMinValue;
            CustomAttributeMaxValue = customAttributeMaxValue;
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("filter_type")]
        public string FilterType { get; }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("custom_attribute_definition_ids")]
        public IList<string> CustomAttributeDefinitionIds { get; }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("custom_attribute_value_exact")]
        public string CustomAttributeValueExact { get; }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("custom_attribute_value_prefix")]
        public string CustomAttributeValuePrefix { get; }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("custom_attribute_min_value")]
        public string CustomAttributeMinValue { get; }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("custom_attribute_max_value")]
        public string CustomAttributeMaxValue { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .FilterType(FilterType)
                .CustomAttributeDefinitionIds(CustomAttributeDefinitionIds)
                .CustomAttributeValueExact(CustomAttributeValueExact)
                .CustomAttributeValuePrefix(CustomAttributeValuePrefix)
                .CustomAttributeMinValue(CustomAttributeMinValue)
                .CustomAttributeMaxValue(CustomAttributeMaxValue);
            return builder;
        }

        public class Builder
        {
            private string filterType;
            private IList<string> customAttributeDefinitionIds;
            private string customAttributeValueExact;
            private string customAttributeValuePrefix;
            private string customAttributeMinValue;
            private string customAttributeMaxValue;

            public Builder() { }
            public Builder FilterType(string value)
            {
                filterType = value;
                return this;
            }

            public Builder CustomAttributeDefinitionIds(IList<string> value)
            {
                customAttributeDefinitionIds = value;
                return this;
            }

            public Builder CustomAttributeValueExact(string value)
            {
                customAttributeValueExact = value;
                return this;
            }

            public Builder CustomAttributeValuePrefix(string value)
            {
                customAttributeValuePrefix = value;
                return this;
            }

            public Builder CustomAttributeMinValue(string value)
            {
                customAttributeMinValue = value;
                return this;
            }

            public Builder CustomAttributeMaxValue(string value)
            {
                customAttributeMaxValue = value;
                return this;
            }

            public CatalogQueryFilteredItemsCustomAttributeFilter Build()
            {
                return new CatalogQueryFilteredItemsCustomAttributeFilter(filterType,
                    customAttributeDefinitionIds,
                    customAttributeValueExact,
                    customAttributeValuePrefix,
                    customAttributeMinValue,
                    customAttributeMaxValue);
            }
        }
    }
} 