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
    /// PrePopulatedData.
    /// </summary>
    public class PrePopulatedData
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="PrePopulatedData"/> class.
        /// </summary>
        /// <param name="buyerEmail">buyer_email.</param>
        /// <param name="buyerPhoneNumber">buyer_phone_number.</param>
        /// <param name="buyerAddress">buyer_address.</param>
        public PrePopulatedData(
            string buyerEmail = null,
            string buyerPhoneNumber = null,
            Models.Address buyerAddress = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "buyer_email", false },
                { "buyer_phone_number", false }
            };

            if (buyerEmail != null)
            {
                shouldSerialize["buyer_email"] = true;
                this.BuyerEmail = buyerEmail;
            }

            if (buyerPhoneNumber != null)
            {
                shouldSerialize["buyer_phone_number"] = true;
                this.BuyerPhoneNumber = buyerPhoneNumber;
            }

            this.BuyerAddress = buyerAddress;
        }
        internal PrePopulatedData(Dictionary<string, bool> shouldSerialize,
            string buyerEmail = null,
            string buyerPhoneNumber = null,
            Models.Address buyerAddress = null)
        {
            this.shouldSerialize = shouldSerialize;
            BuyerEmail = buyerEmail;
            BuyerPhoneNumber = buyerPhoneNumber;
            BuyerAddress = buyerAddress;
        }

        /// <summary>
        /// The buyer email to prepopulate in the payment form.
        /// </summary>
        [JsonProperty("buyer_email")]
        public string BuyerEmail { get; }

        /// <summary>
        /// The buyer phone number to prepopulate in the payment form.
        /// </summary>
        [JsonProperty("buyer_phone_number")]
        public string BuyerPhoneNumber { get; }

        /// <summary>
        /// Represents a postal address in a country.
        /// For more information, see [Working with Addresses](https://developer.squareup.com/docs/build-basics/working-with-addresses).
        /// </summary>
        [JsonProperty("buyer_address", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Address BuyerAddress { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"PrePopulatedData : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeBuyerEmail()
        {
            return this.shouldSerialize["buyer_email"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeBuyerPhoneNumber()
        {
            return this.shouldSerialize["buyer_phone_number"];
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

            return obj is PrePopulatedData other &&
                ((this.BuyerEmail == null && other.BuyerEmail == null) || (this.BuyerEmail?.Equals(other.BuyerEmail) == true)) &&
                ((this.BuyerPhoneNumber == null && other.BuyerPhoneNumber == null) || (this.BuyerPhoneNumber?.Equals(other.BuyerPhoneNumber) == true)) &&
                ((this.BuyerAddress == null && other.BuyerAddress == null) || (this.BuyerAddress?.Equals(other.BuyerAddress) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1974752879;
            hashCode = HashCode.Combine(this.BuyerEmail, this.BuyerPhoneNumber, this.BuyerAddress);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.BuyerEmail = {(this.BuyerEmail == null ? "null" : this.BuyerEmail == string.Empty ? "" : this.BuyerEmail)}");
            toStringOutput.Add($"this.BuyerPhoneNumber = {(this.BuyerPhoneNumber == null ? "null" : this.BuyerPhoneNumber == string.Empty ? "" : this.BuyerPhoneNumber)}");
            toStringOutput.Add($"this.BuyerAddress = {(this.BuyerAddress == null ? "null" : this.BuyerAddress.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .BuyerEmail(this.BuyerEmail)
                .BuyerPhoneNumber(this.BuyerPhoneNumber)
                .BuyerAddress(this.BuyerAddress);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "buyer_email", false },
                { "buyer_phone_number", false },
            };

            private string buyerEmail;
            private string buyerPhoneNumber;
            private Models.Address buyerAddress;

             /// <summary>
             /// BuyerEmail.
             /// </summary>
             /// <param name="buyerEmail"> buyerEmail. </param>
             /// <returns> Builder. </returns>
            public Builder BuyerEmail(string buyerEmail)
            {
                shouldSerialize["buyer_email"] = true;
                this.buyerEmail = buyerEmail;
                return this;
            }

             /// <summary>
             /// BuyerPhoneNumber.
             /// </summary>
             /// <param name="buyerPhoneNumber"> buyerPhoneNumber. </param>
             /// <returns> Builder. </returns>
            public Builder BuyerPhoneNumber(string buyerPhoneNumber)
            {
                shouldSerialize["buyer_phone_number"] = true;
                this.buyerPhoneNumber = buyerPhoneNumber;
                return this;
            }

             /// <summary>
             /// BuyerAddress.
             /// </summary>
             /// <param name="buyerAddress"> buyerAddress. </param>
             /// <returns> Builder. </returns>
            public Builder BuyerAddress(Models.Address buyerAddress)
            {
                this.buyerAddress = buyerAddress;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetBuyerEmail()
            {
                this.shouldSerialize["buyer_email"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetBuyerPhoneNumber()
            {
                this.shouldSerialize["buyer_phone_number"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> PrePopulatedData. </returns>
            public PrePopulatedData Build()
            {
                return new PrePopulatedData(shouldSerialize,
                    this.buyerEmail,
                    this.buyerPhoneNumber,
                    this.buyerAddress);
            }
        }
    }
}