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
    /// CatalogCustomAttributeDefinitionStringConfig.
    /// </summary>
    public class CatalogCustomAttributeDefinitionStringConfig
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogCustomAttributeDefinitionStringConfig"/> class.
        /// </summary>
        /// <param name="enforceUniqueness">enforce_uniqueness.</param>
        public CatalogCustomAttributeDefinitionStringConfig(
            bool? enforceUniqueness = null)
        {
            this.EnforceUniqueness = enforceUniqueness;
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogCustomAttributeDefinitionStringConfig : ({string.Join(", ", toStringOutput)})";
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

            return obj is CatalogCustomAttributeDefinitionStringConfig other &&
                ((this.EnforceUniqueness == null && other.EnforceUniqueness == null) || (this.EnforceUniqueness?.Equals(other.EnforceUniqueness) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 209404828;
            hashCode = HashCode.Combine(this.EnforceUniqueness);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.EnforceUniqueness = {(this.EnforceUniqueness == null ? "null" : this.EnforceUniqueness.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .EnforceUniqueness(this.EnforceUniqueness);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private bool? enforceUniqueness;

             /// <summary>
             /// EnforceUniqueness.
             /// </summary>
             /// <param name="enforceUniqueness"> enforceUniqueness. </param>
             /// <returns> Builder. </returns>
            public Builder EnforceUniqueness(bool? enforceUniqueness)
            {
                this.enforceUniqueness = enforceUniqueness;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogCustomAttributeDefinitionStringConfig. </returns>
            public CatalogCustomAttributeDefinitionStringConfig Build()
            {
                return new CatalogCustomAttributeDefinitionStringConfig(
                    this.enforceUniqueness);
            }
        }
    }
}