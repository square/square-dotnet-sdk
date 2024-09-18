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
    /// TenderBuyNowPayLaterDetails.
    /// </summary>
    public class TenderBuyNowPayLaterDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TenderBuyNowPayLaterDetails"/> class.
        /// </summary>
        /// <param name="buyNowPayLaterBrand">buy_now_pay_later_brand.</param>
        /// <param name="status">status.</param>
        public TenderBuyNowPayLaterDetails(
            string buyNowPayLaterBrand = null,
            string status = null)
        {
            this.BuyNowPayLaterBrand = buyNowPayLaterBrand;
            this.Status = status;
        }

        /// <summary>
        /// Gets or sets BuyNowPayLaterBrand.
        /// </summary>
        [JsonProperty("buy_now_pay_later_brand", NullValueHandling = NullValueHandling.Ignore)]
        public string BuyNowPayLaterBrand { get; }

        /// <summary>
        /// Gets or sets Status.
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"TenderBuyNowPayLaterDetails : ({string.Join(", ", toStringOutput)})";
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
            return obj is TenderBuyNowPayLaterDetails other &&                ((this.BuyNowPayLaterBrand == null && other.BuyNowPayLaterBrand == null) || (this.BuyNowPayLaterBrand?.Equals(other.BuyNowPayLaterBrand) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1561943019;
            hashCode = HashCode.Combine(this.BuyNowPayLaterBrand, this.Status);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.BuyNowPayLaterBrand = {(this.BuyNowPayLaterBrand == null ? "null" : this.BuyNowPayLaterBrand.ToString())}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .BuyNowPayLaterBrand(this.BuyNowPayLaterBrand)
                .Status(this.Status);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string buyNowPayLaterBrand;
            private string status;

             /// <summary>
             /// BuyNowPayLaterBrand.
             /// </summary>
             /// <param name="buyNowPayLaterBrand"> buyNowPayLaterBrand. </param>
             /// <returns> Builder. </returns>
            public Builder BuyNowPayLaterBrand(string buyNowPayLaterBrand)
            {
                this.buyNowPayLaterBrand = buyNowPayLaterBrand;
                return this;
            }

             /// <summary>
             /// Status.
             /// </summary>
             /// <param name="status"> status. </param>
             /// <returns> Builder. </returns>
            public Builder Status(string status)
            {
                this.status = status;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> TenderBuyNowPayLaterDetails. </returns>
            public TenderBuyNowPayLaterDetails Build()
            {
                return new TenderBuyNowPayLaterDetails(
                    this.buyNowPayLaterBrand,
                    this.status);
            }
        }
    }
}