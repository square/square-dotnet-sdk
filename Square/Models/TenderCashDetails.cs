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
    /// TenderCashDetails.
    /// </summary>
    public class TenderCashDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TenderCashDetails"/> class.
        /// </summary>
        /// <param name="buyerTenderedMoney">buyer_tendered_money.</param>
        /// <param name="changeBackMoney">change_back_money.</param>
        public TenderCashDetails(
            Models.Money buyerTenderedMoney = null,
            Models.Money changeBackMoney = null)
        {
            this.BuyerTenderedMoney = buyerTenderedMoney;
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
        [JsonProperty("buyer_tendered_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money BuyerTenderedMoney { get; }

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

            return $"TenderCashDetails : ({string.Join(", ", toStringOutput)})";
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

            return obj is TenderCashDetails other &&
                ((this.BuyerTenderedMoney == null && other.BuyerTenderedMoney == null) || (this.BuyerTenderedMoney?.Equals(other.BuyerTenderedMoney) == true)) &&
                ((this.ChangeBackMoney == null && other.ChangeBackMoney == null) || (this.ChangeBackMoney?.Equals(other.ChangeBackMoney) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1409552788;
            hashCode = HashCode.Combine(this.BuyerTenderedMoney, this.ChangeBackMoney);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.BuyerTenderedMoney = {(this.BuyerTenderedMoney == null ? "null" : this.BuyerTenderedMoney.ToString())}");
            toStringOutput.Add($"this.ChangeBackMoney = {(this.ChangeBackMoney == null ? "null" : this.ChangeBackMoney.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .BuyerTenderedMoney(this.BuyerTenderedMoney)
                .ChangeBackMoney(this.ChangeBackMoney);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.Money buyerTenderedMoney;
            private Models.Money changeBackMoney;

             /// <summary>
             /// BuyerTenderedMoney.
             /// </summary>
             /// <param name="buyerTenderedMoney"> buyerTenderedMoney. </param>
             /// <returns> Builder. </returns>
            public Builder BuyerTenderedMoney(Models.Money buyerTenderedMoney)
            {
                this.buyerTenderedMoney = buyerTenderedMoney;
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
            /// <returns> TenderCashDetails. </returns>
            public TenderCashDetails Build()
            {
                return new TenderCashDetails(
                    this.buyerTenderedMoney,
                    this.changeBackMoney);
            }
        }
    }
}