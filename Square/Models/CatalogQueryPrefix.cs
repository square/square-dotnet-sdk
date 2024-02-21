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
    /// CatalogQueryPrefix.
    /// </summary>
    public class CatalogQueryPrefix
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogQueryPrefix"/> class.
        /// </summary>
        /// <param name="attributeName">attribute_name.</param>
        /// <param name="attributePrefix">attribute_prefix.</param>
        public CatalogQueryPrefix(
            string attributeName,
            string attributePrefix)
        {
            this.AttributeName = attributeName;
            this.AttributePrefix = attributePrefix;
        }

        /// <summary>
        /// The name of the attribute to be searched.
        /// </summary>
        [JsonProperty("attribute_name")]
        public string AttributeName { get; }

        /// <summary>
        /// The desired prefix of the search attribute value.
        /// </summary>
        [JsonProperty("attribute_prefix")]
        public string AttributePrefix { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogQueryPrefix : ({string.Join(", ", toStringOutput)})";
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
            return obj is CatalogQueryPrefix other &&                ((this.AttributeName == null && other.AttributeName == null) || (this.AttributeName?.Equals(other.AttributeName) == true)) &&
                ((this.AttributePrefix == null && other.AttributePrefix == null) || (this.AttributePrefix?.Equals(other.AttributePrefix) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -167354518;
            hashCode = HashCode.Combine(this.AttributeName, this.AttributePrefix);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.AttributeName = {(this.AttributeName == null ? "null" : this.AttributeName)}");
            toStringOutput.Add($"this.AttributePrefix = {(this.AttributePrefix == null ? "null" : this.AttributePrefix)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.AttributeName,
                this.AttributePrefix);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string attributeName;
            private string attributePrefix;

            /// <summary>
            /// Initialize Builder for CatalogQueryPrefix.
            /// </summary>
            /// <param name="attributeName"> attributeName. </param>
            /// <param name="attributePrefix"> attributePrefix. </param>
            public Builder(
                string attributeName,
                string attributePrefix)
            {
                this.attributeName = attributeName;
                this.attributePrefix = attributePrefix;
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
             /// AttributePrefix.
             /// </summary>
             /// <param name="attributePrefix"> attributePrefix. </param>
             /// <returns> Builder. </returns>
            public Builder AttributePrefix(string attributePrefix)
            {
                this.attributePrefix = attributePrefix;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogQueryPrefix. </returns>
            public CatalogQueryPrefix Build()
            {
                return new CatalogQueryPrefix(
                    this.attributeName,
                    this.attributePrefix);
            }
        }
    }
}