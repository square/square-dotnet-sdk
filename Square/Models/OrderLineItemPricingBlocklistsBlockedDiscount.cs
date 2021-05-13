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
    /// OrderLineItemPricingBlocklistsBlockedDiscount.
    /// </summary>
    public class OrderLineItemPricingBlocklistsBlockedDiscount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderLineItemPricingBlocklistsBlockedDiscount"/> class.
        /// </summary>
        /// <param name="uid">uid.</param>
        /// <param name="discountUid">discount_uid.</param>
        /// <param name="discountCatalogObjectId">discount_catalog_object_id.</param>
        public OrderLineItemPricingBlocklistsBlockedDiscount(
            string uid = null,
            string discountUid = null,
            string discountCatalogObjectId = null)
        {
            this.Uid = uid;
            this.DiscountUid = discountUid;
            this.DiscountCatalogObjectId = discountCatalogObjectId;
        }

        /// <summary>
        /// A unique ID of the `BlockedDiscount` within the order.
        /// </summary>
        [JsonProperty("uid", NullValueHandling = NullValueHandling.Ignore)]
        public string Uid { get; }

        /// <summary>
        /// The `uid` of the discount that should be blocked. Use this field to block
        /// ad hoc discounts. For catalog discounts, use the `discount_catalog_object_id` field.
        /// </summary>
        [JsonProperty("discount_uid", NullValueHandling = NullValueHandling.Ignore)]
        public string DiscountUid { get; }

        /// <summary>
        /// The `catalog_object_id` of the discount that should be blocked.
        /// Use this field to block catalog discounts. For ad hoc discounts, use the
        /// `discount_uid` field.
        /// </summary>
        [JsonProperty("discount_catalog_object_id", NullValueHandling = NullValueHandling.Ignore)]
        public string DiscountCatalogObjectId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"OrderLineItemPricingBlocklistsBlockedDiscount : ({string.Join(", ", toStringOutput)})";
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

            return obj is OrderLineItemPricingBlocklistsBlockedDiscount other &&
                ((this.Uid == null && other.Uid == null) || (this.Uid?.Equals(other.Uid) == true)) &&
                ((this.DiscountUid == null && other.DiscountUid == null) || (this.DiscountUid?.Equals(other.DiscountUid) == true)) &&
                ((this.DiscountCatalogObjectId == null && other.DiscountCatalogObjectId == null) || (this.DiscountCatalogObjectId?.Equals(other.DiscountCatalogObjectId) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 532800568;

            if (this.Uid != null)
            {
               hashCode += this.Uid.GetHashCode();
            }

            if (this.DiscountUid != null)
            {
               hashCode += this.DiscountUid.GetHashCode();
            }

            if (this.DiscountCatalogObjectId != null)
            {
               hashCode += this.DiscountCatalogObjectId.GetHashCode();
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
            toStringOutput.Add($"this.DiscountUid = {(this.DiscountUid == null ? "null" : this.DiscountUid == string.Empty ? "" : this.DiscountUid)}");
            toStringOutput.Add($"this.DiscountCatalogObjectId = {(this.DiscountCatalogObjectId == null ? "null" : this.DiscountCatalogObjectId == string.Empty ? "" : this.DiscountCatalogObjectId)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Uid(this.Uid)
                .DiscountUid(this.DiscountUid)
                .DiscountCatalogObjectId(this.DiscountCatalogObjectId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string uid;
            private string discountUid;
            private string discountCatalogObjectId;

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
             /// DiscountUid.
             /// </summary>
             /// <param name="discountUid"> discountUid. </param>
             /// <returns> Builder. </returns>
            public Builder DiscountUid(string discountUid)
            {
                this.discountUid = discountUid;
                return this;
            }

             /// <summary>
             /// DiscountCatalogObjectId.
             /// </summary>
             /// <param name="discountCatalogObjectId"> discountCatalogObjectId. </param>
             /// <returns> Builder. </returns>
            public Builder DiscountCatalogObjectId(string discountCatalogObjectId)
            {
                this.discountCatalogObjectId = discountCatalogObjectId;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> OrderLineItemPricingBlocklistsBlockedDiscount. </returns>
            public OrderLineItemPricingBlocklistsBlockedDiscount Build()
            {
                return new OrderLineItemPricingBlocklistsBlockedDiscount(
                    this.uid,
                    this.discountUid,
                    this.discountCatalogObjectId);
            }
        }
    }
}