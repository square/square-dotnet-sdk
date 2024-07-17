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
    /// OrderLineItemAppliedServiceCharge.
    /// </summary>
    public class OrderLineItemAppliedServiceCharge
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderLineItemAppliedServiceCharge"/> class.
        /// </summary>
        /// <param name="serviceChargeUid">service_charge_uid.</param>
        /// <param name="uid">uid.</param>
        /// <param name="appliedMoney">applied_money.</param>
        public OrderLineItemAppliedServiceCharge(
            string serviceChargeUid,
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

            this.ServiceChargeUid = serviceChargeUid;
            this.AppliedMoney = appliedMoney;
        }
        internal OrderLineItemAppliedServiceCharge(Dictionary<string, bool> shouldSerialize,
            string serviceChargeUid,
            string uid = null,
            Models.Money appliedMoney = null)
        {
            this.shouldSerialize = shouldSerialize;
            Uid = uid;
            ServiceChargeUid = serviceChargeUid;
            AppliedMoney = appliedMoney;
        }

        /// <summary>
        /// A unique ID that identifies the applied service charge only within this order.
        /// </summary>
        [JsonProperty("uid")]
        public string Uid { get; }

        /// <summary>
        /// The `uid` of the service charge that the applied service charge represents. It must
        /// reference a service charge present in the `order.service_charges` field.
        /// This field is immutable. To change which service charges apply to a line item,
        /// delete and add a new `OrderLineItemAppliedServiceCharge`.
        /// </summary>
        [JsonProperty("service_charge_uid")]
        public string ServiceChargeUid { get; }

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

            return $"OrderLineItemAppliedServiceCharge : ({string.Join(", ", toStringOutput)})";
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
            return obj is OrderLineItemAppliedServiceCharge other &&                ((this.Uid == null && other.Uid == null) || (this.Uid?.Equals(other.Uid) == true)) &&
                ((this.ServiceChargeUid == null && other.ServiceChargeUid == null) || (this.ServiceChargeUid?.Equals(other.ServiceChargeUid) == true)) &&
                ((this.AppliedMoney == null && other.AppliedMoney == null) || (this.AppliedMoney?.Equals(other.AppliedMoney) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1704627862;
            hashCode = HashCode.Combine(this.Uid, this.ServiceChargeUid, this.AppliedMoney);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Uid = {(this.Uid == null ? "null" : this.Uid)}");
            toStringOutput.Add($"this.ServiceChargeUid = {(this.ServiceChargeUid == null ? "null" : this.ServiceChargeUid)}");
            toStringOutput.Add($"this.AppliedMoney = {(this.AppliedMoney == null ? "null" : this.AppliedMoney.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.ServiceChargeUid)
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

            private string serviceChargeUid;
            private string uid;
            private Models.Money appliedMoney;

            /// <summary>
            /// Initialize Builder for OrderLineItemAppliedServiceCharge.
            /// </summary>
            /// <param name="serviceChargeUid"> serviceChargeUid. </param>
            public Builder(
                string serviceChargeUid)
            {
                this.serviceChargeUid = serviceChargeUid;
            }

             /// <summary>
             /// ServiceChargeUid.
             /// </summary>
             /// <param name="serviceChargeUid"> serviceChargeUid. </param>
             /// <returns> Builder. </returns>
            public Builder ServiceChargeUid(string serviceChargeUid)
            {
                this.serviceChargeUid = serviceChargeUid;
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
            /// <returns> OrderLineItemAppliedServiceCharge. </returns>
            public OrderLineItemAppliedServiceCharge Build()
            {
                return new OrderLineItemAppliedServiceCharge(shouldSerialize,
                    this.serviceChargeUid,
                    this.uid,
                    this.appliedMoney);
            }
        }
    }
}