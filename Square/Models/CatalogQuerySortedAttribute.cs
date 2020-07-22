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
    public class CatalogQuerySortedAttribute 
    {
        public CatalogQuerySortedAttribute(string attributeName,
            string initialAttributeValue = null,
            string sortOrder = null)
        {
            AttributeName = attributeName;
            InitialAttributeValue = initialAttributeValue;
            SortOrder = sortOrder;
        }

        /// <summary>
        /// The attribute whose value is used as the sort key.
        /// </summary>
        [JsonProperty("attribute_name")]
        public string AttributeName { get; }

        /// <summary>
        /// The first attribute value to be returned by the query. Ascending sorts will return only
        /// objects with this value or greater, while descending sorts will return only objects with this value
        /// or less. If unset, start at the beginning (for ascending sorts) or end (for descending sorts).
        /// </summary>
        [JsonProperty("initial_attribute_value")]
        public string InitialAttributeValue { get; }

        /// <summary>
        /// The order (e.g., chronological or alphabetical) in which results from a request are returned.
        /// </summary>
        [JsonProperty("sort_order")]
        public string SortOrder { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(AttributeName)
                .InitialAttributeValue(InitialAttributeValue)
                .SortOrder(SortOrder);
            return builder;
        }

        public class Builder
        {
            private string attributeName;
            private string initialAttributeValue;
            private string sortOrder;

            public Builder(string attributeName)
            {
                this.attributeName = attributeName;
            }
            public Builder AttributeName(string value)
            {
                attributeName = value;
                return this;
            }

            public Builder InitialAttributeValue(string value)
            {
                initialAttributeValue = value;
                return this;
            }

            public Builder SortOrder(string value)
            {
                sortOrder = value;
                return this;
            }

            public CatalogQuerySortedAttribute Build()
            {
                return new CatalogQuerySortedAttribute(attributeName,
                    initialAttributeValue,
                    sortOrder);
            }
        }
    }
}