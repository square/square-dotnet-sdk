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
    /// SubscriptionPricing.
    /// </summary>
    public class SubscriptionPricing
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionPricing"/> class.
        /// </summary>
        /// <param name="type">type.</param>
        /// <param name="discountIds">discount_ids.</param>
        /// <param name="priceMoney">price_money.</param>
        public SubscriptionPricing(
            string type = null,
            IList<string> discountIds = null,
            Models.Money priceMoney = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "discount_ids", false }
            };

            this.Type = type;
            if (discountIds != null)
            {
                shouldSerialize["discount_ids"] = true;
                this.DiscountIds = discountIds;
            }

            this.PriceMoney = priceMoney;
        }
        internal SubscriptionPricing(Dictionary<string, bool> shouldSerialize,
            string type = null,
            IList<string> discountIds = null,
            Models.Money priceMoney = null)
        {
            this.shouldSerialize = shouldSerialize;
            Type = type;
            DiscountIds = discountIds;
            PriceMoney = priceMoney;
        }

        /// <summary>
        /// Determines the pricing of a [Subscription]($m/Subscription)
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; }

        /// <summary>
        /// The ids of the discount catalog objects
        /// </summary>
        [JsonProperty("discount_ids")]
        public IList<string> DiscountIds { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("price_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money PriceMoney { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SubscriptionPricing : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDiscountIds()
        {
            return this.shouldSerialize["discount_ids"];
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
            return obj is SubscriptionPricing other &&                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true)) &&
                ((this.DiscountIds == null && other.DiscountIds == null) || (this.DiscountIds?.Equals(other.DiscountIds) == true)) &&
                ((this.PriceMoney == null && other.PriceMoney == null) || (this.PriceMoney?.Equals(other.PriceMoney) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -279861606;
            hashCode = HashCode.Combine(this.Type, this.DiscountIds, this.PriceMoney);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type.ToString())}");
            toStringOutput.Add($"this.DiscountIds = {(this.DiscountIds == null ? "null" : $"[{string.Join(", ", this.DiscountIds)} ]")}");
            toStringOutput.Add($"this.PriceMoney = {(this.PriceMoney == null ? "null" : this.PriceMoney.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Type(this.Type)
                .DiscountIds(this.DiscountIds)
                .PriceMoney(this.PriceMoney);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "discount_ids", false },
            };

            private string type;
            private IList<string> discountIds;
            private Models.Money priceMoney;

             /// <summary>
             /// Type.
             /// </summary>
             /// <param name="type"> type. </param>
             /// <returns> Builder. </returns>
            public Builder Type(string type)
            {
                this.type = type;
                return this;
            }

             /// <summary>
             /// DiscountIds.
             /// </summary>
             /// <param name="discountIds"> discountIds. </param>
             /// <returns> Builder. </returns>
            public Builder DiscountIds(IList<string> discountIds)
            {
                shouldSerialize["discount_ids"] = true;
                this.discountIds = discountIds;
                return this;
            }

             /// <summary>
             /// PriceMoney.
             /// </summary>
             /// <param name="priceMoney"> priceMoney. </param>
             /// <returns> Builder. </returns>
            public Builder PriceMoney(Models.Money priceMoney)
            {
                this.priceMoney = priceMoney;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetDiscountIds()
            {
                this.shouldSerialize["discount_ids"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> SubscriptionPricing. </returns>
            public SubscriptionPricing Build()
            {
                return new SubscriptionPricing(shouldSerialize,
                    this.type,
                    this.discountIds,
                    this.priceMoney);
            }
        }
    }
}