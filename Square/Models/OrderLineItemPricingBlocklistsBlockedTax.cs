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
    /// OrderLineItemPricingBlocklistsBlockedTax.
    /// </summary>
    public class OrderLineItemPricingBlocklistsBlockedTax
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderLineItemPricingBlocklistsBlockedTax"/> class.
        /// </summary>
        /// <param name="uid">uid.</param>
        /// <param name="taxUid">tax_uid.</param>
        /// <param name="taxCatalogObjectId">tax_catalog_object_id.</param>
        public OrderLineItemPricingBlocklistsBlockedTax(
            string uid = null,
            string taxUid = null,
            string taxCatalogObjectId = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "uid", false },
                { "tax_uid", false },
                { "tax_catalog_object_id", false }
            };

            if (uid != null)
            {
                shouldSerialize["uid"] = true;
                this.Uid = uid;
            }

            if (taxUid != null)
            {
                shouldSerialize["tax_uid"] = true;
                this.TaxUid = taxUid;
            }

            if (taxCatalogObjectId != null)
            {
                shouldSerialize["tax_catalog_object_id"] = true;
                this.TaxCatalogObjectId = taxCatalogObjectId;
            }

        }
        internal OrderLineItemPricingBlocklistsBlockedTax(Dictionary<string, bool> shouldSerialize,
            string uid = null,
            string taxUid = null,
            string taxCatalogObjectId = null)
        {
            this.shouldSerialize = shouldSerialize;
            Uid = uid;
            TaxUid = taxUid;
            TaxCatalogObjectId = taxCatalogObjectId;
        }

        /// <summary>
        /// A unique ID of the `BlockedTax` within the order.
        /// </summary>
        [JsonProperty("uid")]
        public string Uid { get; }

        /// <summary>
        /// The `uid` of the tax that should be blocked. Use this field to block
        /// ad hoc taxes. For catalog, taxes use the `tax_catalog_object_id` field.
        /// </summary>
        [JsonProperty("tax_uid")]
        public string TaxUid { get; }

        /// <summary>
        /// The `catalog_object_id` of the tax that should be blocked.
        /// Use this field to block catalog taxes. For ad hoc taxes, use the
        /// `tax_uid` field.
        /// </summary>
        [JsonProperty("tax_catalog_object_id")]
        public string TaxCatalogObjectId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"OrderLineItemPricingBlocklistsBlockedTax : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeUid()
        {
            return this.shouldSerialize["uid"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTaxUid()
        {
            return this.shouldSerialize["tax_uid"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTaxCatalogObjectId()
        {
            return this.shouldSerialize["tax_catalog_object_id"];
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
            return obj is OrderLineItemPricingBlocklistsBlockedTax other &&                ((this.Uid == null && other.Uid == null) || (this.Uid?.Equals(other.Uid) == true)) &&
                ((this.TaxUid == null && other.TaxUid == null) || (this.TaxUid?.Equals(other.TaxUid) == true)) &&
                ((this.TaxCatalogObjectId == null && other.TaxCatalogObjectId == null) || (this.TaxCatalogObjectId?.Equals(other.TaxCatalogObjectId) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 91458610;
            hashCode = HashCode.Combine(this.Uid, this.TaxUid, this.TaxCatalogObjectId);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Uid = {(this.Uid == null ? "null" : this.Uid)}");
            toStringOutput.Add($"this.TaxUid = {(this.TaxUid == null ? "null" : this.TaxUid)}");
            toStringOutput.Add($"this.TaxCatalogObjectId = {(this.TaxCatalogObjectId == null ? "null" : this.TaxCatalogObjectId)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Uid(this.Uid)
                .TaxUid(this.TaxUid)
                .TaxCatalogObjectId(this.TaxCatalogObjectId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "uid", false },
                { "tax_uid", false },
                { "tax_catalog_object_id", false },
            };

            private string uid;
            private string taxUid;
            private string taxCatalogObjectId;

             /// <summary>
             /// Uid.
             /// </summary>
             /// <param name="uid"> uid. </param>
             /// <returns> Builder. </returns>
            public Builder Uid(string uid)
            {
                shouldSerialize["uid"] = true;
                this.uid = uid;
                return this;
            }

             /// <summary>
             /// TaxUid.
             /// </summary>
             /// <param name="taxUid"> taxUid. </param>
             /// <returns> Builder. </returns>
            public Builder TaxUid(string taxUid)
            {
                shouldSerialize["tax_uid"] = true;
                this.taxUid = taxUid;
                return this;
            }

             /// <summary>
             /// TaxCatalogObjectId.
             /// </summary>
             /// <param name="taxCatalogObjectId"> taxCatalogObjectId. </param>
             /// <returns> Builder. </returns>
            public Builder TaxCatalogObjectId(string taxCatalogObjectId)
            {
                shouldSerialize["tax_catalog_object_id"] = true;
                this.taxCatalogObjectId = taxCatalogObjectId;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetUid()
            {
                this.shouldSerialize["uid"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetTaxUid()
            {
                this.shouldSerialize["tax_uid"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetTaxCatalogObjectId()
            {
                this.shouldSerialize["tax_catalog_object_id"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> OrderLineItemPricingBlocklistsBlockedTax. </returns>
            public OrderLineItemPricingBlocklistsBlockedTax Build()
            {
                return new OrderLineItemPricingBlocklistsBlockedTax(shouldSerialize,
                    this.uid,
                    this.taxUid,
                    this.taxCatalogObjectId);
            }
        }
    }
}