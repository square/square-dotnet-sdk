namespace Square.Models
{
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

    /// <summary>
    /// CatalogQuerySet.
    /// </summary>
    public class CatalogQuerySet
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogQuerySet"/> class.
        /// </summary>
        /// <param name="attributeName">attribute_name.</param>
        /// <param name="attributeValues">attribute_values.</param>
        public CatalogQuerySet(
            string attributeName,
            IList<string> attributeValues)
        {
            this.AttributeName = attributeName;
            this.AttributeValues = attributeValues;
        }

        /// <summary>
        /// The name of the attribute to be searched. Matching of the attribute name is exact.
        /// </summary>
        [JsonProperty("attribute_name")]
        public string AttributeName { get; }

        /// <summary>
        /// The desired values of the search attribute. Matching of the attribute values is exact and case insensitive.
        /// A maximum of 250 values may be searched in a request.
        /// </summary>
        [JsonProperty("attribute_values")]
        public IList<string> AttributeValues { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogQuerySet : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
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
            return obj is CatalogQuerySet other &&                ((this.AttributeName == null && other.AttributeName == null) || (this.AttributeName?.Equals(other.AttributeName) == true)) &&
                ((this.AttributeValues == null && other.AttributeValues == null) || (this.AttributeValues?.Equals(other.AttributeValues) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 478444029;
            hashCode = HashCode.Combine(this.AttributeName, this.AttributeValues);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.AttributeName = {(this.AttributeName == null ? "null" : this.AttributeName)}");
            toStringOutput.Add($"this.AttributeValues = {(this.AttributeValues == null ? "null" : $"[{string.Join(", ", this.AttributeValues)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.AttributeName,
                this.AttributeValues);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string attributeName;
            private IList<string> attributeValues;

            /// <summary>
            /// Initialize Builder for CatalogQuerySet.
            /// </summary>
            /// <param name="attributeName"> attributeName. </param>
            /// <param name="attributeValues"> attributeValues. </param>
            public Builder(
                string attributeName,
                IList<string> attributeValues)
            {
                this.attributeName = attributeName;
                this.attributeValues = attributeValues;
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
             /// AttributeValues.
             /// </summary>
             /// <param name="attributeValues"> attributeValues. </param>
             /// <returns> Builder. </returns>
            public Builder AttributeValues(IList<string> attributeValues)
            {
                this.attributeValues = attributeValues;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogQuerySet. </returns>
            public CatalogQuerySet Build()
            {
                return new CatalogQuerySet(
                    this.attributeName,
                    this.attributeValues);
            }
        }
    }
}