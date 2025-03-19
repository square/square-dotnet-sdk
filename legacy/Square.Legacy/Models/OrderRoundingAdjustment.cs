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
    /// OrderRoundingAdjustment.
    /// </summary>
    public class OrderRoundingAdjustment
    {
        private readonly Dictionary<string, bool> shouldSerialize;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderRoundingAdjustment"/> class.
        /// </summary>
        /// <param name="uid">uid.</param>
        /// <param name="name">name.</param>
        /// <param name="amountMoney">amount_money.</param>
        public OrderRoundingAdjustment(
            string uid = null,
            string name = null,
            Models.Money amountMoney = null
        )
        {
            shouldSerialize = new Dictionary<string, bool> { { "uid", false }, { "name", false } };

            if (uid != null)
            {
                shouldSerialize["uid"] = true;
                this.Uid = uid;
            }

            if (name != null)
            {
                shouldSerialize["name"] = true;
                this.Name = name;
            }
            this.AmountMoney = amountMoney;
        }

        internal OrderRoundingAdjustment(
            Dictionary<string, bool> shouldSerialize,
            string uid = null,
            string name = null,
            Models.Money amountMoney = null
        )
        {
            this.shouldSerialize = shouldSerialize;
            Uid = uid;
            Name = name;
            AmountMoney = amountMoney;
        }

        /// <summary>
        /// A unique ID that identifies the rounding adjustment only within this order.
        /// </summary>
        [JsonProperty("uid")]
        public string Uid { get; }

        /// <summary>
        /// The name of the rounding adjustment from the original sale order.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("amount_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money AmountMoney { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"OrderRoundingAdjustment : ({string.Join(", ", toStringOutput)})";
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
        public bool ShouldSerializeName()
        {
            return this.shouldSerialize["name"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is OrderRoundingAdjustment other
                && (this.Uid == null && other.Uid == null || this.Uid?.Equals(other.Uid) == true)
                && (
                    this.Name == null && other.Name == null || this.Name?.Equals(other.Name) == true
                )
                && (
                    this.AmountMoney == null && other.AmountMoney == null
                    || this.AmountMoney?.Equals(other.AmountMoney) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 1589528681;
            hashCode = HashCode.Combine(hashCode, this.Uid, this.Name, this.AmountMoney);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Uid = {this.Uid ?? "null"}");
            toStringOutput.Add($"this.Name = {this.Name ?? "null"}");
            toStringOutput.Add(
                $"this.AmountMoney = {(this.AmountMoney == null ? "null" : this.AmountMoney.ToString())}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder().Uid(this.Uid).Name(this.Name).AmountMoney(this.AmountMoney);
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
                { "name", false },
            };

            private string uid;
            private string name;
            private Models.Money amountMoney;

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
            /// Name.
            /// </summary>
            /// <param name="name"> name. </param>
            /// <returns> Builder. </returns>
            public Builder Name(string name)
            {
                shouldSerialize["name"] = true;
                this.name = name;
                return this;
            }

            /// <summary>
            /// AmountMoney.
            /// </summary>
            /// <param name="amountMoney"> amountMoney. </param>
            /// <returns> Builder. </returns>
            public Builder AmountMoney(Models.Money amountMoney)
            {
                this.amountMoney = amountMoney;
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
            public void UnsetName()
            {
                this.shouldSerialize["name"] = false;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> OrderRoundingAdjustment. </returns>
            public OrderRoundingAdjustment Build()
            {
                return new OrderRoundingAdjustment(
                    shouldSerialize,
                    this.uid,
                    this.name,
                    this.amountMoney
                );
            }
        }
    }
}
