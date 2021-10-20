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
    /// CatalogCustomAttributeDefinitionSelectionConfig.
    /// </summary>
    public class CatalogCustomAttributeDefinitionSelectionConfig
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogCustomAttributeDefinitionSelectionConfig"/> class.
        /// </summary>
        /// <param name="maxAllowedSelections">max_allowed_selections.</param>
        /// <param name="allowedSelections">allowed_selections.</param>
        public CatalogCustomAttributeDefinitionSelectionConfig(
            int? maxAllowedSelections = null,
            IList<Models.CatalogCustomAttributeDefinitionSelectionConfigCustomAttributeSelection> allowedSelections = null)
        {
            this.MaxAllowedSelections = maxAllowedSelections;
            this.AllowedSelections = allowedSelections;
        }

        /// <summary>
        /// The maximum number of selections that can be set. The maximum value for this
        /// attribute is 100. The default value is 1. The value can be modified, but changing the value will not
        /// affect existing custom attribute values on objects. Clients need to
        /// handle custom attributes with more selected values than allowed by this limit.
        /// </summary>
        [JsonProperty("max_allowed_selections", NullValueHandling = NullValueHandling.Ignore)]
        public int? MaxAllowedSelections { get; }

        /// <summary>
        /// The set of valid `CatalogCustomAttributeSelections`. Up to a maximum of 100
        /// selections can be defined. Can be modified.
        /// </summary>
        [JsonProperty("allowed_selections", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.CatalogCustomAttributeDefinitionSelectionConfigCustomAttributeSelection> AllowedSelections { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogCustomAttributeDefinitionSelectionConfig : ({string.Join(", ", toStringOutput)})";
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

            return obj is CatalogCustomAttributeDefinitionSelectionConfig other &&
                ((this.MaxAllowedSelections == null && other.MaxAllowedSelections == null) || (this.MaxAllowedSelections?.Equals(other.MaxAllowedSelections) == true)) &&
                ((this.AllowedSelections == null && other.AllowedSelections == null) || (this.AllowedSelections?.Equals(other.AllowedSelections) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 960165059;
            hashCode = HashCode.Combine(this.MaxAllowedSelections, this.AllowedSelections);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.MaxAllowedSelections = {(this.MaxAllowedSelections == null ? "null" : this.MaxAllowedSelections.ToString())}");
            toStringOutput.Add($"this.AllowedSelections = {(this.AllowedSelections == null ? "null" : $"[{string.Join(", ", this.AllowedSelections)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .MaxAllowedSelections(this.MaxAllowedSelections)
                .AllowedSelections(this.AllowedSelections);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private int? maxAllowedSelections;
            private IList<Models.CatalogCustomAttributeDefinitionSelectionConfigCustomAttributeSelection> allowedSelections;

             /// <summary>
             /// MaxAllowedSelections.
             /// </summary>
             /// <param name="maxAllowedSelections"> maxAllowedSelections. </param>
             /// <returns> Builder. </returns>
            public Builder MaxAllowedSelections(int? maxAllowedSelections)
            {
                this.maxAllowedSelections = maxAllowedSelections;
                return this;
            }

             /// <summary>
             /// AllowedSelections.
             /// </summary>
             /// <param name="allowedSelections"> allowedSelections. </param>
             /// <returns> Builder. </returns>
            public Builder AllowedSelections(IList<Models.CatalogCustomAttributeDefinitionSelectionConfigCustomAttributeSelection> allowedSelections)
            {
                this.allowedSelections = allowedSelections;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogCustomAttributeDefinitionSelectionConfig. </returns>
            public CatalogCustomAttributeDefinitionSelectionConfig Build()
            {
                return new CatalogCustomAttributeDefinitionSelectionConfig(
                    this.maxAllowedSelections,
                    this.allowedSelections);
            }
        }
    }
}