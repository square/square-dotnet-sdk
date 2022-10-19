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
    /// InvoiceAcceptedPaymentMethods.
    /// </summary>
    public class InvoiceAcceptedPaymentMethods
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceAcceptedPaymentMethods"/> class.
        /// </summary>
        /// <param name="card">card.</param>
        /// <param name="squareGiftCard">square_gift_card.</param>
        /// <param name="bankAccount">bank_account.</param>
        /// <param name="buyNowPayLater">buy_now_pay_later.</param>
        public InvoiceAcceptedPaymentMethods(
            bool? card = null,
            bool? squareGiftCard = null,
            bool? bankAccount = null,
            bool? buyNowPayLater = null)
        {
            this.Card = card;
            this.SquareGiftCard = squareGiftCard;
            this.BankAccount = bankAccount;
            this.BuyNowPayLater = buyNowPayLater;
        }

        /// <summary>
        /// Indicates whether credit card or debit card payments are accepted. The default value is `false`.
        /// </summary>
        [JsonProperty("card", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Card { get; }

        /// <summary>
        /// Indicates whether Square gift card payments are accepted. The default value is `false`.
        /// </summary>
        [JsonProperty("square_gift_card", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SquareGiftCard { get; }

        /// <summary>
        /// Indicates whether bank transfer payments are accepted. The default value is `false`.
        /// This option is allowed only for invoices that have a single payment request of the `BALANCE` type.
        /// </summary>
        [JsonProperty("bank_account", NullValueHandling = NullValueHandling.Ignore)]
        public bool? BankAccount { get; }

        /// <summary>
        /// Indicates whether Afterpay (also known as Clearpay) payments are accepted. The default value is `false`.
        /// This option is allowed only for invoices that have a single payment request of the `BALANCE` type. This payment method is
        /// supported if the seller account accepts Afterpay payments and the seller location is in a country where Afterpay
        /// invoice payments are supported. As a best practice, consider enabling an additional payment method when allowing
        /// `buy_now_pay_later` payments. For more information, including detailed requirements and processing limits, see
        /// [Buy Now Pay Later payments with Afterpay](https://developer.squareup.com/docs/invoices-api/overview#buy-now-pay-later).
        /// </summary>
        [JsonProperty("buy_now_pay_later", NullValueHandling = NullValueHandling.Ignore)]
        public bool? BuyNowPayLater { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"InvoiceAcceptedPaymentMethods : ({string.Join(", ", toStringOutput)})";
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

            return obj is InvoiceAcceptedPaymentMethods other &&
                ((this.Card == null && other.Card == null) || (this.Card?.Equals(other.Card) == true)) &&
                ((this.SquareGiftCard == null && other.SquareGiftCard == null) || (this.SquareGiftCard?.Equals(other.SquareGiftCard) == true)) &&
                ((this.BankAccount == null && other.BankAccount == null) || (this.BankAccount?.Equals(other.BankAccount) == true)) &&
                ((this.BuyNowPayLater == null && other.BuyNowPayLater == null) || (this.BuyNowPayLater?.Equals(other.BuyNowPayLater) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1178422628;
            hashCode = HashCode.Combine(this.Card, this.SquareGiftCard, this.BankAccount, this.BuyNowPayLater);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Card = {(this.Card == null ? "null" : this.Card.ToString())}");
            toStringOutput.Add($"this.SquareGiftCard = {(this.SquareGiftCard == null ? "null" : this.SquareGiftCard.ToString())}");
            toStringOutput.Add($"this.BankAccount = {(this.BankAccount == null ? "null" : this.BankAccount.ToString())}");
            toStringOutput.Add($"this.BuyNowPayLater = {(this.BuyNowPayLater == null ? "null" : this.BuyNowPayLater.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Card(this.Card)
                .SquareGiftCard(this.SquareGiftCard)
                .BankAccount(this.BankAccount)
                .BuyNowPayLater(this.BuyNowPayLater);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private bool? card;
            private bool? squareGiftCard;
            private bool? bankAccount;
            private bool? buyNowPayLater;

             /// <summary>
             /// Card.
             /// </summary>
             /// <param name="card"> card. </param>
             /// <returns> Builder. </returns>
            public Builder Card(bool? card)
            {
                this.card = card;
                return this;
            }

             /// <summary>
             /// SquareGiftCard.
             /// </summary>
             /// <param name="squareGiftCard"> squareGiftCard. </param>
             /// <returns> Builder. </returns>
            public Builder SquareGiftCard(bool? squareGiftCard)
            {
                this.squareGiftCard = squareGiftCard;
                return this;
            }

             /// <summary>
             /// BankAccount.
             /// </summary>
             /// <param name="bankAccount"> bankAccount. </param>
             /// <returns> Builder. </returns>
            public Builder BankAccount(bool? bankAccount)
            {
                this.bankAccount = bankAccount;
                return this;
            }

             /// <summary>
             /// BuyNowPayLater.
             /// </summary>
             /// <param name="buyNowPayLater"> buyNowPayLater. </param>
             /// <returns> Builder. </returns>
            public Builder BuyNowPayLater(bool? buyNowPayLater)
            {
                this.buyNowPayLater = buyNowPayLater;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> InvoiceAcceptedPaymentMethods. </returns>
            public InvoiceAcceptedPaymentMethods Build()
            {
                return new InvoiceAcceptedPaymentMethods(
                    this.card,
                    this.squareGiftCard,
                    this.bankAccount,
                    this.buyNowPayLater);
            }
        }
    }
}