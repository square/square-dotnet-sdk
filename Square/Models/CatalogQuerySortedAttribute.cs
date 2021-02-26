
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
        [JsonProperty("initial_attribute_value", NullValueHandling = NullValueHandling.Ignore)]
        public string InitialAttributeValue { get; }

        /// <summary>
        /// The order (e.g., chronological or alphabetical) in which results from a request are returned.
        /// </summary>
        [JsonProperty("sort_order", NullValueHandling = NullValueHandling.Ignore)]
        public string SortOrder { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogQuerySortedAttribute : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"AttributeName = {(AttributeName == null ? "null" : AttributeName == string.Empty ? "" : AttributeName)}");
            toStringOutput.Add($"InitialAttributeValue = {(InitialAttributeValue == null ? "null" : InitialAttributeValue == string.Empty ? "" : InitialAttributeValue)}");
            toStringOutput.Add($"SortOrder = {(SortOrder == null ? "null" : SortOrder.ToString())}");
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

            return obj is CatalogQuerySortedAttribute other &&
                ((AttributeName == null && other.AttributeName == null) || (AttributeName?.Equals(other.AttributeName) == true)) &&
                ((InitialAttributeValue == null && other.InitialAttributeValue == null) || (InitialAttributeValue?.Equals(other.InitialAttributeValue) == true)) &&
                ((SortOrder == null && other.SortOrder == null) || (SortOrder?.Equals(other.SortOrder) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -406098695;

            if (AttributeName != null)
            {
               hashCode += AttributeName.GetHashCode();
            }

            if (InitialAttributeValue != null)
            {
               hashCode += InitialAttributeValue.GetHashCode();
            }

            if (SortOrder != null)
            {
               hashCode += SortOrder.GetHashCode();
            }

            return hashCode;
        }

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

            public Builder AttributeName(string attributeName)
            {
                this.attributeName = attributeName;
                return this;
            }

            public Builder InitialAttributeValue(string initialAttributeValue)
            {
                this.initialAttributeValue = initialAttributeValue;
                return this;
            }

            public Builder SortOrder(string sortOrder)
            {
                this.sortOrder = sortOrder;
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