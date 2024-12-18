using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIMatic.Core.Utilities.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;

namespace Square.Models
{
    /// <summary>
    /// CatalogQuerySortedAttribute.
    /// </summary>
    public class CatalogQuerySortedAttribute
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogQuerySortedAttribute"/> class.
        /// </summary>
        /// <param name="attributeName">attribute_name.</param>
        /// <param name="initialAttributeValue">initial_attribute_value.</param>
        /// <param name="sortOrder">sort_order.</param>
        public CatalogQuerySortedAttribute(
            string attributeName,
            string initialAttributeValue = null,
            string sortOrder = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "initial_attribute_value", false }
            };
            this.AttributeName = attributeName;

            if (initialAttributeValue != null)
            {
                shouldSerialize["initial_attribute_value"] = true;
                this.InitialAttributeValue = initialAttributeValue;
            }
            this.SortOrder = sortOrder;
        }

        internal CatalogQuerySortedAttribute(
            Dictionary<string, bool> shouldSerialize,
            string attributeName,
            string initialAttributeValue = null,
            string sortOrder = null)
        {
            this.shouldSerialize = shouldSerialize;
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
        [JsonProperty("sort_order", NullValueHandling = NullValueHandling.Ignore)]
        public string SortOrder { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"CatalogQuerySortedAttribute : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeInitialAttributeValue()
        {
            return this.shouldSerialize["initial_attribute_value"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is CatalogQuerySortedAttribute other &&
                (this.AttributeName == null && other.AttributeName == null ||
                 this.AttributeName?.Equals(other.AttributeName) == true) &&
                (this.InitialAttributeValue == null && other.InitialAttributeValue == null ||
                 this.InitialAttributeValue?.Equals(other.InitialAttributeValue) == true) &&
                (this.SortOrder == null && other.SortOrder == null ||
                 this.SortOrder?.Equals(other.SortOrder) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -406098695;
            hashCode = HashCode.Combine(hashCode, this.AttributeName, this.InitialAttributeValue, this.SortOrder);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.AttributeName = {this.AttributeName ?? "null"}");
            toStringOutput.Add($"this.InitialAttributeValue = {this.InitialAttributeValue ?? "null"}");
            toStringOutput.Add($"this.SortOrder = {(this.SortOrder == null ? "null" : this.SortOrder.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.AttributeName)
                .InitialAttributeValue(this.InitialAttributeValue)
                .SortOrder(this.SortOrder);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "initial_attribute_value", false },
            };

            private string attributeName;
            private string initialAttributeValue;
            private string sortOrder;

            /// <summary>
            /// Initialize Builder for CatalogQuerySortedAttribute.
            /// </summary>
            /// <param name="attributeName"> attributeName. </param>
            public Builder(
                string attributeName)
            {
                this.attributeName = attributeName;
            }

             /// <summary>
             /// AttributeName.
             /// </summary>
             /// <param name="attributeName"> attributeName. </param>
             /// <returns> Builder. </returns>
            public Builder AttributeName(string attributeName)
            {
                this.attributeName = attributeName;
                return this;
            }

             /// <summary>
             /// InitialAttributeValue.
             /// </summary>
             /// <param name="initialAttributeValue"> initialAttributeValue. </param>
             /// <returns> Builder. </returns>
            public Builder InitialAttributeValue(string initialAttributeValue)
            {
                shouldSerialize["initial_attribute_value"] = true;
                this.initialAttributeValue = initialAttributeValue;
                return this;
            }

             /// <summary>
             /// SortOrder.
             /// </summary>
             /// <param name="sortOrder"> sortOrder. </param>
             /// <returns> Builder. </returns>
            public Builder SortOrder(string sortOrder)
            {
                this.sortOrder = sortOrder;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetInitialAttributeValue()
            {
                this.shouldSerialize["initial_attribute_value"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogQuerySortedAttribute. </returns>
            public CatalogQuerySortedAttribute Build()
            {
                return new CatalogQuerySortedAttribute(
                    shouldSerialize,
                    this.attributeName,
                    this.initialAttributeValue,
                    this.sortOrder);
            }
        }
    }
}