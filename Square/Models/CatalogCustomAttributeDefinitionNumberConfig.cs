namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Utilities;

    /// <summary>
    /// CatalogCustomAttributeDefinitionNumberConfig.
    /// </summary>
    public class CatalogCustomAttributeDefinitionNumberConfig
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogCustomAttributeDefinitionNumberConfig"/> class.
        /// </summary>
        /// <param name="precision">precision.</param>
        public CatalogCustomAttributeDefinitionNumberConfig(
            int? precision = null)
        {
            this.Precision = precision;
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogCustomAttributeDefinitionNumberConfig : ({string.Join(", ", toStringOutput)})";
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

            return obj is CatalogCustomAttributeDefinitionNumberConfig other &&
                ((this.Precision == null && other.Precision == null) || (this.Precision?.Equals(other.Precision) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 196624818;
            hashCode = HashCode.Combine(this.Precision);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Precision = {(this.Precision == null ? "null" : this.Precision.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Precision(this.Precision);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private int? precision;

             /// <summary>
             /// Precision.
             /// </summary>
             /// <param name="precision"> precision. </param>
             /// <returns> Builder. </returns>
            public Builder Precision(int? precision)
            {
                this.precision = precision;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogCustomAttributeDefinitionNumberConfig. </returns>
            public CatalogCustomAttributeDefinitionNumberConfig Build()
            {
                return new CatalogCustomAttributeDefinitionNumberConfig(
                    this.precision);
            }
        }
    }
}