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
    /// CashAppDetails.
    /// </summary>
    public class CashAppDetails
    {
        private readonly Dictionary<string, bool> shouldSerialize;
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
            shouldSerialize = new Dictionary<string, bool>
            {
                { "buyer_full_name", false },
                { "buyer_country_code", false }
            };

            if (buyerFullName != null)
            {
                shouldSerialize["buyer_full_name"] = true;
                this.BuyerFullName = buyerFullName;
            }

            if (buyerCountryCode != null)
            {
                shouldSerialize["buyer_country_code"] = true;
                this.BuyerCountryCode = buyerCountryCode;
            }

            this.BuyerCashtag = buyerCashtag;
        }
        internal CashAppDetails(Dictionary<string, bool> shouldSerialize,
            string buyerFullName = null,
            string buyerCountryCode = null,
            string buyerCashtag = null)
        {
            this.shouldSerialize = shouldSerialize;
            BuyerFullName = buyerFullName;
            BuyerCountryCode = buyerCountryCode;
            BuyerCashtag = buyerCashtag;
        }

        /// <summary>
        /// The name of the Cash App account holder.
        /// </summary>
        [JsonProperty("buyer_full_name")]
        public string BuyerFullName { get; }

        /// <summary>
        /// The country of the Cash App account holder, in ISO 3166-1-alpha-2 format.
        /// For possible values, see [Country](entity:Country).
        /// </summary>
        [JsonProperty("buyer_country_code")]
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

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeBuyerFullName()
        {
            return this.shouldSerialize["buyer_full_name"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeBuyerCountryCode()
        {
            return this.shouldSerialize["buyer_country_code"];
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
            return obj is CashAppDetails other &&                ((this.BuyerFullName == null && other.BuyerFullName == null) || (this.BuyerFullName?.Equals(other.BuyerFullName) == true)) &&
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
            toStringOutput.Add($"this.BuyerFullName = {(this.BuyerFullName == null ? "null" : this.BuyerFullName)}");
            toStringOutput.Add($"this.BuyerCountryCode = {(this.BuyerCountryCode == null ? "null" : this.BuyerCountryCode)}");
            toStringOutput.Add($"this.BuyerCashtag = {(this.BuyerCashtag == null ? "null" : this.BuyerCashtag)}");
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
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "buyer_full_name", false },
                { "buyer_country_code", false },
            };

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
                shouldSerialize["buyer_full_name"] = true;
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
                shouldSerialize["buyer_country_code"] = true;
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
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetBuyerFullName()
            {
                this.shouldSerialize["buyer_full_name"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetBuyerCountryCode()
            {
                this.shouldSerialize["buyer_country_code"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CashAppDetails. </returns>
            public CashAppDetails Build()
            {
                return new CashAppDetails(shouldSerialize,
                    this.buyerFullName,
                    this.buyerCountryCode,
                    this.buyerCashtag);
            }
        }
    }
}