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
    /// OrderLineItemAppliedDiscount.
    /// </summary>
    public class OrderLineItemAppliedDiscount
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderLineItemAppliedDiscount"/> class.
        /// </summary>
        /// <param name="discountUid">discount_uid.</param>
        /// <param name="uid">uid.</param>
        /// <param name="appliedMoney">applied_money.</param>
        public OrderLineItemAppliedDiscount(
            string discountUid,
            string uid = null,
            Models.Money appliedMoney = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "uid", false }
            };

            if (uid != null)
            {
                shouldSerialize["uid"] = true;
                this.Uid = uid;
            }

            this.DiscountUid = discountUid;
            this.AppliedMoney = appliedMoney;
        }
        internal OrderLineItemAppliedDiscount(Dictionary<string, bool> shouldSerialize,
            string discountUid,
            string uid = null,
            Models.Money appliedMoney = null)
        {
            this.shouldSerialize = shouldSerialize;
            Uid = uid;
            DiscountUid = discountUid;
            AppliedMoney = appliedMoney;
        }

        /// <summary>
        /// A unique ID that identifies the applied discount only within this order.
        /// </summary>
        [JsonProperty("uid")]
        public string Uid { get; }

        /// <summary>
        /// The `uid` of the discount that the applied discount represents. It must
        /// reference a discount present in the `order.discounts` field.
        /// This field is immutable. To change which discounts apply to a line item,
        /// you must delete the discount and re-add it as a new `OrderLineItemAppliedDiscount`.
        /// </summary>
        [JsonProperty("discount_uid")]
        public string DiscountUid { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("applied_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money AppliedMoney { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"OrderLineItemAppliedDiscount : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeUid()
        {
            return this.shouldSerialize["uid"];
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

            return obj is OrderLineItemAppliedDiscount other &&
                ((this.Uid == null && other.Uid == null) || (this.Uid?.Equals(other.Uid) == true)) &&
                ((this.DiscountUid == null && other.DiscountUid == null) || (this.DiscountUid?.Equals(other.DiscountUid) == true)) &&
                ((this.AppliedMoney == null && other.AppliedMoney == null) || (this.AppliedMoney?.Equals(other.AppliedMoney) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -855225717;
            hashCode = HashCode.Combine(this.Uid, this.DiscountUid, this.AppliedMoney);

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
            toStringOutput.Add($"this.AppliedMoney = {(this.AppliedMoney == null ? "null" : this.AppliedMoney.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.DiscountUid)
                .Uid(this.Uid)
                .AppliedMoney(this.AppliedMoney);
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
            };

            private string discountUid;
            private string uid;
            private Models.Money appliedMoney;

            public Builder(
                string discountUid)
            {
                this.discountUid = discountUid;
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
             /// AppliedMoney.
             /// </summary>
             /// <param name="appliedMoney"> appliedMoney. </param>
             /// <returns> Builder. </returns>
            public Builder AppliedMoney(Models.Money appliedMoney)
            {
                this.appliedMoney = appliedMoney;
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
            /// Builds class object.
            /// </summary>
            /// <returns> OrderLineItemAppliedDiscount. </returns>
            public OrderLineItemAppliedDiscount Build()
            {
                return new OrderLineItemAppliedDiscount(shouldSerialize,
                    this.discountUid,
                    this.uid,
                    this.appliedMoney);
            }
        }
    }
}