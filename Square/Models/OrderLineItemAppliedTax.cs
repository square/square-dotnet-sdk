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
    public class OrderLineItemAppliedTax 
    {
        public OrderLineItemAppliedTax(string taxUid,
            string uid = null,
            Models.Money appliedMoney = null)
        {
            Uid = uid;
            TaxUid = taxUid;
            AppliedMoney = appliedMoney;
        }

        /// <summary>
        /// Unique ID that identifies the applied tax only within this order.
        /// </summary>
        [JsonProperty("uid")]
        public string Uid { get; }

        /// <summary>
        /// The `uid` of the tax for which this applied tax represents.  Must reference
        /// a tax present in the `order.taxes` field.
        /// This field is immutable. To change which taxes apply to a line item, delete and add new
        /// `OrderLineItemAppliedTax`s.
        /// </summary>
        [JsonProperty("tax_uid")]
        public string TaxUid { get; }

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
            var builder = new Builder(TaxUid)
                .Uid(Uid)
                .AppliedMoney(AppliedMoney);
            return builder;
        }

        public class Builder
        {
            private string taxUid;
            private string uid;
            private Models.Money appliedMoney;

            public Builder(string taxUid)
            {
                this.taxUid = taxUid;
            }
            public Builder TaxUid(string value)
            {
                taxUid = value;
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

            public OrderLineItemAppliedTax Build()
            {
                return new OrderLineItemAppliedTax(taxUid,
                    uid,
                    appliedMoney);
            }
        }
    }
}