
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
    public class CatalogModifierOverride 
    {
        public CatalogModifierOverride(string modifierId,
            bool? onByDefault = null)
        {
            ModifierId = modifierId;
            OnByDefault = onByDefault;
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogModifierOverride : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"ModifierId = {(ModifierId == null ? "null" : ModifierId == string.Empty ? "" : ModifierId)}");
            toStringOutput.Add($"OnByDefault = {(OnByDefault == null ? "null" : OnByDefault.ToString())}");
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

            return obj is CatalogModifierOverride other &&
                ((ModifierId == null && other.ModifierId == null) || (ModifierId?.Equals(other.ModifierId) == true)) &&
                ((OnByDefault == null && other.OnByDefault == null) || (OnByDefault?.Equals(other.OnByDefault) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1142174100;

            if (ModifierId != null)
            {
               hashCode += ModifierId.GetHashCode();
            }

            if (OnByDefault != null)
            {
               hashCode += OnByDefault.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(ModifierId)
                .OnByDefault(OnByDefault);
            return builder;
        }

        public class Builder
        {
            private string modifierId;
            private bool? onByDefault;

            public Builder(string modifierId)
            {
                this.modifierId = modifierId;
            }

            public Builder ModifierId(string modifierId)
            {
                this.modifierId = modifierId;
                return this;
            }

            public Builder OnByDefault(bool? onByDefault)
            {
                this.onByDefault = onByDefault;
                return this;
            }

            public CatalogModifierOverride Build()
            {
                return new CatalogModifierOverride(modifierId,
                    onByDefault);
            }
        }
    }
}