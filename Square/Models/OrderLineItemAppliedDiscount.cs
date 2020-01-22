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
        [JsonProperty("uid")]
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
        [JsonProperty("applied_money")]
        public Models.Money AppliedMoney { get; }

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
            public Builder DiscountUid(string value)
            {
                discountUid = value;
                return this;
            }

            public Builder Uid(string value)
            {
                uid = value;
                return this;
            }

            public Builder AppliedMoney(Models.Money value)
            {
                appliedMoney = value;
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