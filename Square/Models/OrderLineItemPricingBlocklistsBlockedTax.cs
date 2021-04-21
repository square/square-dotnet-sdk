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
    /// OrderLineItemPricingBlocklistsBlockedTax.
    /// </summary>
    public class OrderLineItemPricingBlocklistsBlockedTax
    {
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
            this.Uid = uid;
            this.TaxUid = taxUid;
            this.TaxCatalogObjectId = taxCatalogObjectId;
        }

        /// <summary>
        /// Unique ID of the `BlockedTax` within the order.
        /// </summary>
        [JsonProperty("uid", NullValueHandling = NullValueHandling.Ignore)]
        public string Uid { get; }

        /// <summary>
        /// The `uid` of the tax that should be blocked. Use this field to block
        /// ad-hoc taxes. For catalog taxes use the `tax_catalog_object_id` field.
        /// </summary>
        [JsonProperty("tax_uid", NullValueHandling = NullValueHandling.Ignore)]
        public string TaxUid { get; }

        /// <summary>
        /// The `catalog_object_id` of the tax that should be blocked.
        /// Use this field to block catalog taxes. For ad-hoc taxes use the
        /// `tax_uid` field.
        /// </summary>
        [JsonProperty("tax_catalog_object_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TaxCatalogObjectId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"OrderLineItemPricingBlocklistsBlockedTax : ({string.Join(", ", toStringOutput)})";
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

            return obj is OrderLineItemPricingBlocklistsBlockedTax other &&
                ((this.Uid == null && other.Uid == null) || (this.Uid?.Equals(other.Uid) == true)) &&
                ((this.TaxUid == null && other.TaxUid == null) || (this.TaxUid?.Equals(other.TaxUid) == true)) &&
                ((this.TaxCatalogObjectId == null && other.TaxCatalogObjectId == null) || (this.TaxCatalogObjectId?.Equals(other.TaxCatalogObjectId) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 91458610;

            if (this.Uid != null)
            {
               hashCode += this.Uid.GetHashCode();
            }

            if (this.TaxUid != null)
            {
               hashCode += this.TaxUid.GetHashCode();
            }

            if (this.TaxCatalogObjectId != null)
            {
               hashCode += this.TaxCatalogObjectId.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Uid = {(this.Uid == null ? "null" : this.Uid == string.Empty ? "" : this.Uid)}");
            toStringOutput.Add($"this.TaxUid = {(this.TaxUid == null ? "null" : this.TaxUid == string.Empty ? "" : this.TaxUid)}");
            toStringOutput.Add($"this.TaxCatalogObjectId = {(this.TaxCatalogObjectId == null ? "null" : this.TaxCatalogObjectId == string.Empty ? "" : this.TaxCatalogObjectId)}");
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
                this.taxCatalogObjectId = taxCatalogObjectId;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> OrderLineItemPricingBlocklistsBlockedTax. </returns>
            public OrderLineItemPricingBlocklistsBlockedTax Build()
            {
                return new OrderLineItemPricingBlocklistsBlockedTax(
                    this.uid,
                    this.taxUid,
                    this.taxCatalogObjectId);
            }
        }
    }
}