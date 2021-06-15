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
    /// CreateCustomerCardRequest.
    /// </summary>
    public class CreateCustomerCardRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCustomerCardRequest"/> class.
        /// </summary>
        /// <param name="cardNonce">card_nonce.</param>
        /// <param name="billingAddress">billing_address.</param>
        /// <param name="cardholderName">cardholder_name.</param>
        /// <param name="verificationToken">verification_token.</param>
        public CreateCustomerCardRequest(
            string cardNonce,
            Models.Address billingAddress = null,
            string cardholderName = null,
            string verificationToken = null)
        {
            this.CardNonce = cardNonce;
            this.BillingAddress = billingAddress;
            this.CardholderName = cardholderName;
            this.VerificationToken = verificationToken;
        }

        /// <summary>
        /// A card nonce representing the credit card to link to the customer.
        /// Card nonces are generated by the Square payment form when customers enter
        /// their card information. For more information, see
        /// [Walkthrough: Integrate Square Payments in a Website](https://developer.squareup.com/docs/web-payments/take-card-payment).
        /// __NOTE:__ Card nonces generated by digital wallets (such as Apple Pay)
        /// cannot be used to create a customer card.
        /// </summary>
        [JsonProperty("card_nonce")]
        public string CardNonce { get; }

        /// <summary>
        /// Represents a physical address.
        /// </summary>
        [JsonProperty("billing_address", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Address BillingAddress { get; }

        /// <summary>
        /// The full name printed on the credit card.
        /// </summary>
        [JsonProperty("cardholder_name", NullValueHandling = NullValueHandling.Ignore)]
        public string CardholderName { get; }

        /// <summary>
        /// An identifying token generated by [Payments.verifyBuyer()](https://developer.squareup.com/reference/sdks/web/payments/objects/Payments#Payments.verifyBuyer).
        /// Verification tokens encapsulate customer device information and 3-D Secure
        /// challenge results to indicate that Square has verified the buyer identity.
        /// </summary>
        [JsonProperty("verification_token", NullValueHandling = NullValueHandling.Ignore)]
        public string VerificationToken { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateCustomerCardRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is CreateCustomerCardRequest other &&
                ((this.CardNonce == null && other.CardNonce == null) || (this.CardNonce?.Equals(other.CardNonce) == true)) &&
                ((this.BillingAddress == null && other.BillingAddress == null) || (this.BillingAddress?.Equals(other.BillingAddress) == true)) &&
                ((this.CardholderName == null && other.CardholderName == null) || (this.CardholderName?.Equals(other.CardholderName) == true)) &&
                ((this.VerificationToken == null && other.VerificationToken == null) || (this.VerificationToken?.Equals(other.VerificationToken) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1509386817;

            if (this.CardNonce != null)
            {
               hashCode += this.CardNonce.GetHashCode();
            }

            if (this.BillingAddress != null)
            {
               hashCode += this.BillingAddress.GetHashCode();
            }

            if (this.CardholderName != null)
            {
               hashCode += this.CardholderName.GetHashCode();
            }

            if (this.VerificationToken != null)
            {
               hashCode += this.VerificationToken.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.CardNonce = {(this.CardNonce == null ? "null" : this.CardNonce == string.Empty ? "" : this.CardNonce)}");
            toStringOutput.Add($"this.BillingAddress = {(this.BillingAddress == null ? "null" : this.BillingAddress.ToString())}");
            toStringOutput.Add($"this.CardholderName = {(this.CardholderName == null ? "null" : this.CardholderName == string.Empty ? "" : this.CardholderName)}");
            toStringOutput.Add($"this.VerificationToken = {(this.VerificationToken == null ? "null" : this.VerificationToken == string.Empty ? "" : this.VerificationToken)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.CardNonce)
                .BillingAddress(this.BillingAddress)
                .CardholderName(this.CardholderName)
                .VerificationToken(this.VerificationToken);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string cardNonce;
            private Models.Address billingAddress;
            private string cardholderName;
            private string verificationToken;

            public Builder(
                string cardNonce)
            {
                this.cardNonce = cardNonce;
            }

             /// <summary>
             /// CardNonce.
             /// </summary>
             /// <param name="cardNonce"> cardNonce. </param>
             /// <returns> Builder. </returns>
            public Builder CardNonce(string cardNonce)
            {
                this.cardNonce = cardNonce;
                return this;
            }

             /// <summary>
             /// BillingAddress.
             /// </summary>
             /// <param name="billingAddress"> billingAddress. </param>
             /// <returns> Builder. </returns>
            public Builder BillingAddress(Models.Address billingAddress)
            {
                this.billingAddress = billingAddress;
                return this;
            }

             /// <summary>
             /// CardholderName.
             /// </summary>
             /// <param name="cardholderName"> cardholderName. </param>
             /// <returns> Builder. </returns>
            public Builder CardholderName(string cardholderName)
            {
                this.cardholderName = cardholderName;
                return this;
            }

             /// <summary>
             /// VerificationToken.
             /// </summary>
             /// <param name="verificationToken"> verificationToken. </param>
             /// <returns> Builder. </returns>
            public Builder VerificationToken(string verificationToken)
            {
                this.verificationToken = verificationToken;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CreateCustomerCardRequest. </returns>
            public CreateCustomerCardRequest Build()
            {
                return new CreateCustomerCardRequest(
                    this.cardNonce,
                    this.billingAddress,
                    this.cardholderName,
                    this.verificationToken);
            }
        }
    }
}