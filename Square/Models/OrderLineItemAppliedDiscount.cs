
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
    public class OrderLineItemAppliedDiscount 
    {
        public OrderLineItemAppliedDiscount(string discountUid,
            string uid = null,
            Models.Money appliedMoney = null)
        {
            Uid = uid;
            DiscountUid = discountUid;
            AppliedMoney = appliedMoney;
        }

        /// <summary>
        /// Unique ID that identifies the applied discount only within this order.
        /// </summary>
        [JsonProperty("uid", NullValueHandling = NullValueHandling.Ignore)]
        public string Uid { get; }

        /// <summary>
        /// The `uid` of the discount the applied discount represents. Must
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"OrderLineItemAppliedDiscount : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Uid = {(Uid == null ? "null" : Uid == string.Empty ? "" : Uid)}");
            toStringOutput.Add($"DiscountUid = {(DiscountUid == null ? "null" : DiscountUid == string.Empty ? "" : DiscountUid)}");
            toStringOutput.Add($"AppliedMoney = {(AppliedMoney == null ? "null" : AppliedMoney.ToString())}");
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

            return obj is OrderLineItemAppliedDiscount other &&
                ((Uid == null && other.Uid == null) || (Uid?.Equals(other.Uid) == true)) &&
                ((DiscountUid == null && other.DiscountUid == null) || (DiscountUid?.Equals(other.DiscountUid) == true)) &&
                ((AppliedMoney == null && other.AppliedMoney == null) || (AppliedMoney?.Equals(other.AppliedMoney) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -855225717;

            if (Uid != null)
            {
               hashCode += Uid.GetHashCode();
            }

            if (DiscountUid != null)
            {
               hashCode += DiscountUid.GetHashCode();
            }

            if (AppliedMoney != null)
            {
               hashCode += AppliedMoney.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(DiscountUid)
                .Uid(Uid)
                .AppliedMoney(AppliedMoney);
            return builder;
        }

        public class Builder
        {
            private string discountUid;
            private string uid;
            private Models.Money appliedMoney;

            public Builder(string discountUid)
            {
                this.discountUid = discountUid;
            }

            public Builder DiscountUid(string discountUid)
            {
                this.discountUid = discountUid;
                return this;
            }

            public Builder Uid(string uid)
            {
                this.uid = uid;
                return this;
            }

            public Builder AppliedMoney(Models.Money appliedMoney)
            {
                this.appliedMoney = appliedMoney;
                return this;
            }

            public OrderLineItemAppliedDiscount Build()
            {
                return new OrderLineItemAppliedDiscount(discountUid,
                    uid,
                    appliedMoney);
            }
        }
    }
}