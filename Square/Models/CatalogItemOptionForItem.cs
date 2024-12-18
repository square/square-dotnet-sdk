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
    /// CatalogItemOptionForItem.
    /// </summary>
    public class CatalogItemOptionForItem
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogItemOptionForItem"/> class.
        /// </summary>
        /// <param name="itemOptionId">item_option_id.</param>
        public CatalogItemOptionForItem(
            string itemOptionId = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "item_option_id", false }
            };

            if (itemOptionId != null)
            {
                shouldSerialize["item_option_id"] = true;
                this.ItemOptionId = itemOptionId;
            }
        }

        internal CatalogItemOptionForItem(
            Dictionary<string, bool> shouldSerialize,
            string itemOptionId = null)
        {
            this.shouldSerialize = shouldSerialize;
            ItemOptionId = itemOptionId;
        }

        /// <summary>
        /// The unique id of the item option, used to form the dimensions of the item option matrix in a specified order.
        /// </summary>
        [JsonProperty("item_option_id")]
        public string ItemOptionId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"CatalogItemOptionForItem : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeItemOptionId()
        {
            return this.shouldSerialize["item_option_id"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is CatalogItemOptionForItem other &&
                (this.ItemOptionId == null && other.ItemOptionId == null ||
                 this.ItemOptionId?.Equals(other.ItemOptionId) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 1801897765;
            hashCode = HashCode.Combine(hashCode, this.ItemOptionId);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ItemOptionId = {this.ItemOptionId ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .ItemOptionId(this.ItemOptionId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "item_option_id", false },
            };

            private string itemOptionId;

             /// <summary>
             /// ItemOptionId.
             /// </summary>
             /// <param name="itemOptionId"> itemOptionId. </param>
             /// <returns> Builder. </returns>
            public Builder ItemOptionId(string itemOptionId)
            {
                shouldSerialize["item_option_id"] = true;
                this.itemOptionId = itemOptionId;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetItemOptionId()
            {
                this.shouldSerialize["item_option_id"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogItemOptionForItem. </returns>
            public CatalogItemOptionForItem Build()
            {
                return new CatalogItemOptionForItem(
                    shouldSerialize,
                    this.itemOptionId);
            }
        }
    }
}