
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
        [JsonProperty("uid", NullValueHandling = NullValueHandling.Ignore)]
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
        [JsonProperty("applied_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money AppliedMoney { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"OrderLineItemAppliedTax : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Uid = {(Uid == null ? "null" : Uid == string.Empty ? "" : Uid)}");
            toStringOutput.Add($"TaxUid = {(TaxUid == null ? "null" : TaxUid == string.Empty ? "" : TaxUid)}");
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

            return obj is OrderLineItemAppliedTax other &&
                ((Uid == null && other.Uid == null) || (Uid?.Equals(other.Uid) == true)) &&
                ((TaxUid == null && other.TaxUid == null) || (TaxUid?.Equals(other.TaxUid) == true)) &&
                ((AppliedMoney == null && other.AppliedMoney == null) || (AppliedMoney?.Equals(other.AppliedMoney) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1624626539;

            if (Uid != null)
            {
               hashCode += Uid.GetHashCode();
            }

            if (TaxUid != null)
            {
               hashCode += TaxUid.GetHashCode();
            }

            if (AppliedMoney != null)
            {
               hashCode += AppliedMoney.GetHashCode();
            }

            return hashCode;
        }

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

            public Builder TaxUid(string taxUid)
            {
                this.taxUid = taxUid;
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

            public OrderLineItemAppliedTax Build()
            {
                return new OrderLineItemAppliedTax(taxUid,
                    uid,
                    appliedMoney);
            }
        }
    }
}