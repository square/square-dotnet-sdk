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
    /// CatalogCustomAttributeDefinitionSelectionConfig.
    /// </summary>
    public class CatalogCustomAttributeDefinitionSelectionConfig
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogCustomAttributeDefinitionSelectionConfig"/> class.
        /// </summary>
        /// <param name="maxAllowedSelections">max_allowed_selections.</param>
        /// <param name="allowedSelections">allowed_selections.</param>
        public CatalogCustomAttributeDefinitionSelectionConfig(
            int? maxAllowedSelections = null,
            IList<Models.CatalogCustomAttributeDefinitionSelectionConfigCustomAttributeSelection> allowedSelections = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "max_allowed_selections", false },
                { "allowed_selections", false }
            };

            if (maxAllowedSelections != null)
            {
                shouldSerialize["max_allowed_selections"] = true;
                this.MaxAllowedSelections = maxAllowedSelections;
            }

            if (allowedSelections != null)
            {
                shouldSerialize["allowed_selections"] = true;
                this.AllowedSelections = allowedSelections;
            }

        }
        internal CatalogCustomAttributeDefinitionSelectionConfig(Dictionary<string, bool> shouldSerialize,
            int? maxAllowedSelections = null,
            IList<Models.CatalogCustomAttributeDefinitionSelectionConfigCustomAttributeSelection> allowedSelections = null)
        {
            this.shouldSerialize = shouldSerialize;
            MaxAllowedSelections = maxAllowedSelections;
            AllowedSelections = allowedSelections;
        }

        /// <summary>
        /// The maximum number of selections that can be set. The maximum value for this
        /// attribute is 100. The default value is 1. The value can be modified, but changing the value will not
        /// affect existing custom attribute values on objects. Clients need to
        /// handle custom attributes with more selected values than allowed by this limit.
        /// </summary>
        [JsonProperty("max_allowed_selections")]
        public int? MaxAllowedSelections { get; }

        /// <summary>
        /// The set of valid `CatalogCustomAttributeSelections`. Up to a maximum of 100
        /// selections can be defined. Can be modified.
        /// </summary>
        [JsonProperty("allowed_selections")]
        public IList<Models.CatalogCustomAttributeDefinitionSelectionConfigCustomAttributeSelection> AllowedSelections { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogCustomAttributeDefinitionSelectionConfig : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeMaxAllowedSelections()
        {
            return this.shouldSerialize["max_allowed_selections"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAllowedSelections()
        {
            return this.shouldSerialize["allowed_selections"];
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
            return obj is CatalogCustomAttributeDefinitionSelectionConfig other &&                ((this.MaxAllowedSelections == null && other.MaxAllowedSelections == null) || (this.MaxAllowedSelections?.Equals(other.MaxAllowedSelections) == true)) &&
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
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "max_allowed_selections", false },
                { "allowed_selections", false },
            };

            private int? maxAllowedSelections;
            private IList<Models.CatalogCustomAttributeDefinitionSelectionConfigCustomAttributeSelection> allowedSelections;

             /// <summary>
             /// MaxAllowedSelections.
             /// </summary>
             /// <param name="maxAllowedSelections"> maxAllowedSelections. </param>
             /// <returns> Builder. </returns>
            public Builder MaxAllowedSelections(int? maxAllowedSelections)
            {
                shouldSerialize["max_allowed_selections"] = true;
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
                shouldSerialize["allowed_selections"] = true;
                this.allowedSelections = allowedSelections;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetMaxAllowedSelections()
            {
                this.shouldSerialize["max_allowed_selections"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetAllowedSelections()
            {
                this.shouldSerialize["allowed_selections"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogCustomAttributeDefinitionSelectionConfig. </returns>
            public CatalogCustomAttributeDefinitionSelectionConfig Build()
            {
                return new CatalogCustomAttributeDefinitionSelectionConfig(shouldSerialize,
                    this.maxAllowedSelections,
                    this.allowedSelections);
            }
        }
    }
}