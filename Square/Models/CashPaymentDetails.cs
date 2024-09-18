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

namespace Square.Models
{
    /// <summary>
    /// CashPaymentDetails.
    /// </summary>
    public class CashPaymentDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CashPaymentDetails"/> class.
        /// </summary>
        /// <param name="buyerSuppliedMoney">buyer_supplied_money.</param>
        /// <param name="changeBackMoney">change_back_money.</param>
        public CashPaymentDetails(
            Models.Money buyerSuppliedMoney,
            Models.Money changeBackMoney = null)
        {
            this.BuyerSuppliedMoney = buyerSuppliedMoney;
            this.ChangeBackMoney = changeBackMoney;
        }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("buyer_supplied_money")]
        public Models.Money BuyerSuppliedMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("change_back_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money ChangeBackMoney { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CashPaymentDetails : ({string.Join(", ", toStringOutput)})";
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
            return obj is CashPaymentDetails other &&                ((this.BuyerSuppliedMoney == null && other.BuyerSuppliedMoney == null) || (this.BuyerSuppliedMoney?.Equals(other.BuyerSuppliedMoney) == true)) &&
                ((this.ChangeBackMoney == null && other.ChangeBackMoney == null) || (this.ChangeBackMoney?.Equals(other.ChangeBackMoney) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1355903831;
            hashCode = HashCode.Combine(this.BuyerSuppliedMoney, this.ChangeBackMoney);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.BuyerSuppliedMoney = {(this.BuyerSuppliedMoney == null ? "null" : this.BuyerSuppliedMoney.ToString())}");
            toStringOutput.Add($"this.ChangeBackMoney = {(this.ChangeBackMoney == null ? "null" : this.ChangeBackMoney.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.BuyerSuppliedMoney)
                .ChangeBackMoney(this.ChangeBackMoney);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.Money buyerSuppliedMoney;
            private Models.Money changeBackMoney;

            /// <summary>
            /// Initialize Builder for CashPaymentDetails.
            /// </summary>
            /// <param name="buyerSuppliedMoney"> buyerSuppliedMoney. </param>
            public Builder(
                Models.Money buyerSuppliedMoney)
            {
                this.buyerSuppliedMoney = buyerSuppliedMoney;
            }

             /// <summary>
             /// BuyerSuppliedMoney.
             /// </summary>
             /// <param name="buyerSuppliedMoney"> buyerSuppliedMoney. </param>
             /// <returns> Builder. </returns>
            public Builder BuyerSuppliedMoney(Models.Money buyerSuppliedMoney)
            {
                this.buyerSuppliedMoney = buyerSuppliedMoney;
                return this;
            }

             /// <summary>
             /// ChangeBackMoney.
             /// </summary>
             /// <param name="changeBackMoney"> changeBackMoney. </param>
             /// <returns> Builder. </returns>
            public Builder ChangeBackMoney(Models.Money changeBackMoney)
            {
                this.changeBackMoney = changeBackMoney;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CashPaymentDetails. </returns>
            public CashPaymentDetails Build()
            {
                return new CashPaymentDetails(
                    this.buyerSuppliedMoney,
                    this.changeBackMoney);
            }
        }
    }
}