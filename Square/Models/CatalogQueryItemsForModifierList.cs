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
    /// CatalogQueryItemsForModifierList.
    /// </summary>
    public class CatalogQueryItemsForModifierList
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogQueryItemsForModifierList"/> class.
        /// </summary>
        /// <param name="modifierListIds">modifier_list_ids.</param>
        public CatalogQueryItemsForModifierList(
            IList<string> modifierListIds)
        {
            this.ModifierListIds = modifierListIds;
        }

        /// <summary>
        /// A set of `CatalogModifierList` IDs to be used to find associated `CatalogItem`s.
        /// </summary>
        [JsonProperty("modifier_list_ids")]
        public IList<string> ModifierListIds { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"CatalogQueryItemsForModifierList : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is CatalogQueryItemsForModifierList other &&
                (this.ModifierListIds == null && other.ModifierListIds == null ||
                 this.ModifierListIds?.Equals(other.ModifierListIds) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 969503410;
            hashCode = HashCode.Combine(hashCode, this.ModifierListIds);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ModifierListIds = {(this.ModifierListIds == null ? "null" : $"[{string.Join(", ", this.ModifierListIds)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.ModifierListIds);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<string> modifierListIds;

            /// <summary>
            /// Initialize Builder for CatalogQueryItemsForModifierList.
            /// </summary>
            /// <param name="modifierListIds"> modifierListIds. </param>
            public Builder(
                IList<string> modifierListIds)
            {
                this.modifierListIds = modifierListIds;
            }

             /// <summary>
             /// ModifierListIds.
             /// </summary>
             /// <param name="modifierListIds"> modifierListIds. </param>
             /// <returns> Builder. </returns>
            public Builder ModifierListIds(IList<string> modifierListIds)
            {
                this.modifierListIds = modifierListIds;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogQueryItemsForModifierList. </returns>
            public CatalogQueryItemsForModifierList Build()
            {
                return new CatalogQueryItemsForModifierList(
                    this.modifierListIds);
            }
        }
    }
}