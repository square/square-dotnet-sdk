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
    /// CashAppDetails.
    /// </summary>
    public class CashAppDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CashAppDetails"/> class.
        /// </summary>
        /// <param name="buyerFullName">buyer_full_name.</param>
        /// <param name="buyerCountryCode">buyer_country_code.</param>
        /// <param name="buyerCashtag">buyer_cashtag.</param>
        public CashAppDetails(
            string buyerFullName = null,
            string buyerCountryCode = null,
            string buyerCashtag = null)
        {
            this.BuyerFullName = buyerFullName;
            this.BuyerCountryCode = buyerCountryCode;
            this.BuyerCashtag = buyerCashtag;
        }

        /// <summary>
        /// The name of the Cash App account holder.
        /// </summary>
        [JsonProperty("buyer_full_name", NullValueHandling = NullValueHandling.Ignore)]
        public string BuyerFullName { get; }

        /// <summary>
        /// The country of the Cash App account holder, in ISO 3166-1-alpha-2 format.
        /// For possible values, see [Country]($m/Country).
        /// </summary>
        [JsonProperty("buyer_country_code", NullValueHandling = NullValueHandling.Ignore)]
        public string BuyerCountryCode { get; }

        /// <summary>
        /// $Cashtag of the Cash App account holder.
        /// </summary>
        [JsonProperty("buyer_cashtag", NullValueHandling = NullValueHandling.Ignore)]
        public string BuyerCashtag { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CashAppDetails : ({string.Join(", ", toStringOutput)})";
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

            return obj is CashAppDetails other &&
                ((this.BuyerFullName == null && other.BuyerFullName == null) || (this.BuyerFullName?.Equals(other.BuyerFullName) == true)) &&
                ((this.BuyerCountryCode == null && other.BuyerCountryCode == null) || (this.BuyerCountryCode?.Equals(other.BuyerCountryCode) == true)) &&
                ((this.BuyerCashtag == null && other.BuyerCashtag == null) || (this.BuyerCashtag?.Equals(other.BuyerCashtag) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1138097825;
            hashCode = HashCode.Combine(this.BuyerFullName, this.BuyerCountryCode, this.BuyerCashtag);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.BuyerFullName = {(this.BuyerFullName == null ? "null" : this.BuyerFullName == string.Empty ? "" : this.BuyerFullName)}");
            toStringOutput.Add($"this.BuyerCountryCode = {(this.BuyerCountryCode == null ? "null" : this.BuyerCountryCode == string.Empty ? "" : this.BuyerCountryCode)}");
            toStringOutput.Add($"this.BuyerCashtag = {(this.BuyerCashtag == null ? "null" : this.BuyerCashtag == string.Empty ? "" : this.BuyerCashtag)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .BuyerFullName(this.BuyerFullName)
                .BuyerCountryCode(this.BuyerCountryCode)
                .BuyerCashtag(this.BuyerCashtag);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string buyerFullName;
            private string buyerCountryCode;
            private string buyerCashtag;

             /// <summary>
             /// BuyerFullName.
             /// </summary>
             /// <param name="buyerFullName"> buyerFullName. </param>
             /// <returns> Builder. </returns>
            public Builder BuyerFullName(string buyerFullName)
            {
                this.buyerFullName = buyerFullName;
                return this;
            }

             /// <summary>
             /// BuyerCountryCode.
             /// </summary>
             /// <param name="buyerCountryCode"> buyerCountryCode. </param>
             /// <returns> Builder. </returns>
            public Builder BuyerCountryCode(string buyerCountryCode)
            {
                this.buyerCountryCode = buyerCountryCode;
                return this;
            }

             /// <summary>
             /// BuyerCashtag.
             /// </summary>
             /// <param name="buyerCashtag"> buyerCashtag. </param>
             /// <returns> Builder. </returns>
            public Builder BuyerCashtag(string buyerCashtag)
            {
                this.buyerCashtag = buyerCashtag;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CashAppDetails. </returns>
            public CashAppDetails Build()
            {
                return new CashAppDetails(
                    this.buyerFullName,
                    this.buyerCountryCode,
                    this.buyerCashtag);
            }
        }
    }
}