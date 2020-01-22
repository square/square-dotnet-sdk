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
        [JsonProperty("on_by_default")]
        public bool? OnByDefault { get; }

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
            public Builder ModifierId(string value)
            {
                modifierId = value;
                return this;
            }

            public Builder OnByDefault(bool? value)
            {
                onByDefault = value;
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