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
    /// DestinationDetailsCashRefundDetails.
    /// </summary>
    public class DestinationDetailsCashRefundDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DestinationDetailsCashRefundDetails"/> class.
        /// </summary>
        /// <param name="sellerSuppliedMoney">seller_supplied_money.</param>
        /// <param name="changeBackMoney">change_back_money.</param>
        public DestinationDetailsCashRefundDetails(
            Models.Money sellerSuppliedMoney,
            Models.Money changeBackMoney = null)
        {
            this.SellerSuppliedMoney = sellerSuppliedMoney;
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
        [JsonProperty("seller_supplied_money")]
        public Models.Money SellerSuppliedMoney { get; }

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

            return $"DestinationDetailsCashRefundDetails : ({string.Join(", ", toStringOutput)})";
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
            return obj is DestinationDetailsCashRefundDetails other &&                ((this.SellerSuppliedMoney == null && other.SellerSuppliedMoney == null) || (this.SellerSuppliedMoney?.Equals(other.SellerSuppliedMoney) == true)) &&
                ((this.ChangeBackMoney == null && other.ChangeBackMoney == null) || (this.ChangeBackMoney?.Equals(other.ChangeBackMoney) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -2083907783;
            hashCode = HashCode.Combine(this.SellerSuppliedMoney, this.ChangeBackMoney);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.SellerSuppliedMoney = {(this.SellerSuppliedMoney == null ? "null" : this.SellerSuppliedMoney.ToString())}");
            toStringOutput.Add($"this.ChangeBackMoney = {(this.ChangeBackMoney == null ? "null" : this.ChangeBackMoney.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.SellerSuppliedMoney)
                .ChangeBackMoney(this.ChangeBackMoney);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.Money sellerSuppliedMoney;
            private Models.Money changeBackMoney;

            /// <summary>
            /// Initialize Builder for DestinationDetailsCashRefundDetails.
            /// </summary>
            /// <param name="sellerSuppliedMoney"> sellerSuppliedMoney. </param>
            public Builder(
                Models.Money sellerSuppliedMoney)
            {
                this.sellerSuppliedMoney = sellerSuppliedMoney;
            }

             /// <summary>
             /// SellerSuppliedMoney.
             /// </summary>
             /// <param name="sellerSuppliedMoney"> sellerSuppliedMoney. </param>
             /// <returns> Builder. </returns>
            public Builder SellerSuppliedMoney(Models.Money sellerSuppliedMoney)
            {
                this.sellerSuppliedMoney = sellerSuppliedMoney;
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
            /// <returns> DestinationDetailsCashRefundDetails. </returns>
            public DestinationDetailsCashRefundDetails Build()
            {
                return new DestinationDetailsCashRefundDetails(
                    this.sellerSuppliedMoney,
                    this.changeBackMoney);
            }
        }
    }
}