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
    /// OrderLineItemAppliedTax.
    /// </summary>
    public class OrderLineItemAppliedTax
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderLineItemAppliedTax"/> class.
        /// </summary>
        /// <param name="taxUid">tax_uid.</param>
        /// <param name="uid">uid.</param>
        /// <param name="appliedMoney">applied_money.</param>
        public OrderLineItemAppliedTax(
            string taxUid,
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

            this.TaxUid = taxUid;
            this.AppliedMoney = appliedMoney;
        }
        internal OrderLineItemAppliedTax(Dictionary<string, bool> shouldSerialize,
            string taxUid,
            string uid = null,
            Models.Money appliedMoney = null)
        {
            this.shouldSerialize = shouldSerialize;
            Uid = uid;
            TaxUid = taxUid;
            AppliedMoney = appliedMoney;
        }

        /// <summary>
        /// A unique ID that identifies the applied tax only within this order.
        /// </summary>
        [JsonProperty("uid")]
        public string Uid { get; }

        /// <summary>
        /// The `uid` of the tax for which this applied tax represents. It must reference
        /// a tax present in the `order.taxes` field.
        /// This field is immutable. To change which taxes apply to a line item, delete and add a new
        /// `OrderLineItemAppliedTax`.
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"OrderLineItemAppliedTax : ({string.Join(", ", toStringOutput)})";
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

            return obj is OrderLineItemAppliedTax other &&
                ((this.Uid == null && other.Uid == null) || (this.Uid?.Equals(other.Uid) == true)) &&
                ((this.TaxUid == null && other.TaxUid == null) || (this.TaxUid?.Equals(other.TaxUid) == true)) &&
                ((this.AppliedMoney == null && other.AppliedMoney == null) || (this.AppliedMoney?.Equals(other.AppliedMoney) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1624626539;
            hashCode = HashCode.Combine(this.Uid, this.TaxUid, this.AppliedMoney);

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
            toStringOutput.Add($"this.AppliedMoney = {(this.AppliedMoney == null ? "null" : this.AppliedMoney.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.TaxUid)
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

            private string taxUid;
            private string uid;
            private Models.Money appliedMoney;

            public Builder(
                string taxUid)
            {
                this.taxUid = taxUid;
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
            /// <returns> OrderLineItemAppliedTax. </returns>
            public OrderLineItemAppliedTax Build()
            {
                return new OrderLineItemAppliedTax(shouldSerialize,
                    this.taxUid,
                    this.uid,
                    this.appliedMoney);
            }
        }
    }
}