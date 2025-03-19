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
using Square.Legacy;
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// OrderLineItemPricingBlocklistsBlockedDiscount.
    /// </summary>
    public class OrderLineItemPricingBlocklistsBlockedDiscount
    {
        private readonly Dictionary<string, bool> shouldSerialize;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderLineItemPricingBlocklistsBlockedDiscount"/> class.
        /// </summary>
        /// <param name="uid">uid.</param>
        /// <param name="discountUid">discount_uid.</param>
        /// <param name="discountCatalogObjectId">discount_catalog_object_id.</param>
        public OrderLineItemPricingBlocklistsBlockedDiscount(
            string uid = null,
            string discountUid = null,
            string discountCatalogObjectId = null
        )
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "uid", false },
                { "discount_uid", false },
                { "discount_catalog_object_id", false },
            };

            if (uid != null)
            {
                shouldSerialize["uid"] = true;
                this.Uid = uid;
            }

            if (discountUid != null)
            {
                shouldSerialize["discount_uid"] = true;
                this.DiscountUid = discountUid;
            }

            if (discountCatalogObjectId != null)
            {
                shouldSerialize["discount_catalog_object_id"] = true;
                this.DiscountCatalogObjectId = discountCatalogObjectId;
            }
        }

        internal OrderLineItemPricingBlocklistsBlockedDiscount(
            Dictionary<string, bool> shouldSerialize,
            string uid = null,
            string discountUid = null,
            string discountCatalogObjectId = null
        )
        {
            this.shouldSerialize = shouldSerialize;
            Uid = uid;
            DiscountUid = discountUid;
            DiscountCatalogObjectId = discountCatalogObjectId;
        }

        /// <summary>
        /// A unique ID of the `BlockedDiscount` within the order.
        /// </summary>
        [JsonProperty("uid")]
        public string Uid { get; }

        /// <summary>
        /// The `uid` of the discount that should be blocked. Use this field to block
        /// ad hoc discounts. For catalog discounts, use the `discount_catalog_object_id` field.
        /// </summary>
        [JsonProperty("discount_uid")]
        public string DiscountUid { get; }

        /// <summary>
        /// The `catalog_object_id` of the discount that should be blocked.
        /// Use this field to block catalog discounts. For ad hoc discounts, use the
        /// `discount_uid` field.
        /// </summary>
        [JsonProperty("discount_catalog_object_id")]
        public string DiscountCatalogObjectId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"OrderLineItemPricingBlocklistsBlockedDiscount : ({string.Join(", ", toStringOutput)})";
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
        public bool ShouldSerializeDiscountUid()
        {
            return this.shouldSerialize["discount_uid"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDiscountCatalogObjectId()
        {
            return this.shouldSerialize["discount_catalog_object_id"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is OrderLineItemPricingBlocklistsBlockedDiscount other
                && (this.Uid == null && other.Uid == null || this.Uid?.Equals(other.Uid) == true)
                && (
                    this.DiscountUid == null && other.DiscountUid == null
                    || this.DiscountUid?.Equals(other.DiscountUid) == true
                )
                && (
                    this.DiscountCatalogObjectId == null && other.DiscountCatalogObjectId == null
                    || this.DiscountCatalogObjectId?.Equals(other.DiscountCatalogObjectId) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 532800568;
            hashCode = HashCode.Combine(
                hashCode,
                this.Uid,
                this.DiscountUid,
                this.DiscountCatalogObjectId
            );

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Uid = {this.Uid ?? "null"}");
            toStringOutput.Add($"this.DiscountUid = {this.DiscountUid ?? "null"}");
            toStringOutput.Add(
                $"this.DiscountCatalogObjectId = {this.DiscountCatalogObjectId ?? "null"}"
            );
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
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "uid", false },
                { "discount_uid", false },
                { "discount_catalog_object_id", false },
            };

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
                shouldSerialize["uid"] = true;
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
                shouldSerialize["discount_uid"] = true;
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
                shouldSerialize["discount_catalog_object_id"] = true;
                this.discountCatalogObjectId = discountCatalogObjectId;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetUid()
            {
                this.shouldSerialize["uid"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetDiscountUid()
            {
                this.shouldSerialize["discount_uid"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetDiscountCatalogObjectId()
            {
                this.shouldSerialize["discount_catalog_object_id"] = false;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> OrderLineItemPricingBlocklistsBlockedDiscount. </returns>
            public OrderLineItemPricingBlocklistsBlockedDiscount Build()
            {
                return new OrderLineItemPricingBlocklistsBlockedDiscount(
                    shouldSerialize,
                    this.uid,
                    this.discountUid,
                    this.discountCatalogObjectId
                );
            }
        }
    }
}
