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
    /// CatalogModifierOverride.
    /// </summary>
    public class CatalogModifierOverride
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogModifierOverride"/> class.
        /// </summary>
        /// <param name="modifierId">modifier_id.</param>
        /// <param name="onByDefault">on_by_default.</param>
        public CatalogModifierOverride(
            string modifierId,
            bool? onByDefault = null)
        {
            this.ModifierId = modifierId;
            this.OnByDefault = onByDefault;
        }

        /// <summary>
        /// The ID of the `CatalogModifier` whose default behavior is being overridden.
        /// </summary>
        [JsonProperty("modifier_id")]
        public string ModifierId { get; }

        /// <summary>
        /// If `true`, this `CatalogModifier` should be selected by default for this `CatalogItem`.
        /// </summary>
        [JsonProperty("on_by_default", NullValueHandling = NullValueHandling.Ignore)]
        public bool? OnByDefault { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogModifierOverride : ({string.Join(", ", toStringOutput)})";
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

            return obj is CatalogModifierOverride other &&
                ((this.ModifierId == null && other.ModifierId == null) || (this.ModifierId?.Equals(other.ModifierId) == true)) &&
                ((this.OnByDefault == null && other.OnByDefault == null) || (this.OnByDefault?.Equals(other.OnByDefault) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1142174100;

            if (this.ModifierId != null)
            {
               hashCode += this.ModifierId.GetHashCode();
            }

            if (this.OnByDefault != null)
            {
               hashCode += this.OnByDefault.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ModifierId = {(this.ModifierId == null ? "null" : this.ModifierId == string.Empty ? "" : this.ModifierId)}");
            toStringOutput.Add($"this.OnByDefault = {(this.OnByDefault == null ? "null" : this.OnByDefault.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.ModifierId)
                .OnByDefault(this.OnByDefault);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string modifierId;
            private bool? onByDefault;

            public Builder(
                string modifierId)
            {
                this.modifierId = modifierId;
            }

             /// <summary>
             /// ModifierId.
             /// </summary>
             /// <param name="modifierId"> modifierId. </param>
             /// <returns> Builder. </returns>
            public Builder ModifierId(string modifierId)
            {
                this.modifierId = modifierId;
                return this;
            }

             /// <summary>
             /// OnByDefault.
             /// </summary>
             /// <param name="onByDefault"> onByDefault. </param>
             /// <returns> Builder. </returns>
            public Builder OnByDefault(bool? onByDefault)
            {
                this.onByDefault = onByDefault;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogModifierOverride. </returns>
            public CatalogModifierOverride Build()
            {
                return new CatalogModifierOverride(
                    this.modifierId,
                    this.onByDefault);
            }
        }
    }
}