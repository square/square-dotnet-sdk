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
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceAcceptedPaymentMethods"/> class.
        /// </summary>
        /// <param name="card">card.</param>
        /// <param name="squareGiftCard">square_gift_card.</param>
        /// <param name="bankAccount">bank_account.</param>
        /// <param name="buyNowPayLater">buy_now_pay_later.</param>
        /// <param name="cashAppPay">cash_app_pay.</param>
        public InvoiceAcceptedPaymentMethods(
            bool? card = null,
            bool? squareGiftCard = null,
            bool? bankAccount = null,
            bool? buyNowPayLater = null,
            bool? cashAppPay = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "card", false },
                { "square_gift_card", false },
                { "bank_account", false },
                { "buy_now_pay_later", false },
                { "cash_app_pay", false }
            };

            if (card != null)
            {
                shouldSerialize["card"] = true;
                this.Card = card;
            }

            if (squareGiftCard != null)
            {
                shouldSerialize["square_gift_card"] = true;
                this.SquareGiftCard = squareGiftCard;
            }

            if (bankAccount != null)
            {
                shouldSerialize["bank_account"] = true;
                this.BankAccount = bankAccount;
            }

            if (buyNowPayLater != null)
            {
                shouldSerialize["buy_now_pay_later"] = true;
                this.BuyNowPayLater = buyNowPayLater;
            }

            if (cashAppPay != null)
            {
                shouldSerialize["cash_app_pay"] = true;
                this.CashAppPay = cashAppPay;
            }

        }
        internal InvoiceAcceptedPaymentMethods(Dictionary<string, bool> shouldSerialize,
            bool? card = null,
            bool? squareGiftCard = null,
            bool? bankAccount = null,
            bool? buyNowPayLater = null,
            bool? cashAppPay = null)
        {
            this.shouldSerialize = shouldSerialize;
            Card = card;
            SquareGiftCard = squareGiftCard;
            BankAccount = bankAccount;
            BuyNowPayLater = buyNowPayLater;
            CashAppPay = cashAppPay;
        }

        /// <summary>
        /// Indicates whether credit card or debit card payments are accepted. The default value is `false`.
        /// </summary>
        [JsonProperty("card")]
        public bool? Card { get; }

        /// <summary>
        /// Indicates whether Square gift card payments are accepted. The default value is `false`.
        /// </summary>
        [JsonProperty("square_gift_card")]
        public bool? SquareGiftCard { get; }

        /// <summary>
        /// Indicates whether ACH bank transfer payments are accepted. The default value is `false`.
        /// </summary>
        [JsonProperty("bank_account")]
        public bool? BankAccount { get; }

        /// <summary>
        /// Indicates whether Afterpay (also known as Clearpay) payments are accepted. The default value is `false`.
        /// This option is allowed only for invoices that have a single payment request of the `BALANCE` type. This payment method is
        /// supported if the seller account accepts Afterpay payments and the seller location is in a country where Afterpay
        /// invoice payments are supported. As a best practice, consider enabling an additional payment method when allowing
        /// `buy_now_pay_later` payments. For more information, including detailed requirements and processing limits, see
        /// [Buy Now Pay Later payments with Afterpay](https://developer.squareup.com/docs/invoices-api/overview#buy-now-pay-later).
        /// </summary>
        [JsonProperty("buy_now_pay_later")]
        public bool? BuyNowPayLater { get; }

        /// <summary>
        /// Indicates whether Cash App payments are accepted. The default value is `false`.
        /// This payment method is supported only for seller [locations](entity:Location) in the United States.
        /// </summary>
        [JsonProperty("cash_app_pay")]
        public bool? CashAppPay { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"InvoiceAcceptedPaymentMethods : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCard()
        {
            return this.shouldSerialize["card"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSquareGiftCard()
        {
            return this.shouldSerialize["square_gift_card"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeBankAccount()
        {
            return this.shouldSerialize["bank_account"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeBuyNowPayLater()
        {
            return this.shouldSerialize["buy_now_pay_later"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCashAppPay()
        {
            return this.shouldSerialize["cash_app_pay"];
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
            return obj is InvoiceAcceptedPaymentMethods other &&                ((this.Card == null && other.Card == null) || (this.Card?.Equals(other.Card) == true)) &&
                ((this.SquareGiftCard == null && other.SquareGiftCard == null) || (this.SquareGiftCard?.Equals(other.SquareGiftCard) == true)) &&
                ((this.BankAccount == null && other.BankAccount == null) || (this.BankAccount?.Equals(other.BankAccount) == true)) &&
                ((this.BuyNowPayLater == null && other.BuyNowPayLater == null) || (this.BuyNowPayLater?.Equals(other.BuyNowPayLater) == true)) &&
                ((this.CashAppPay == null && other.CashAppPay == null) || (this.CashAppPay?.Equals(other.CashAppPay) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 74998553;
            hashCode = HashCode.Combine(this.Card, this.SquareGiftCard, this.BankAccount, this.BuyNowPayLater, this.CashAppPay);

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
            toStringOutput.Add($"this.CashAppPay = {(this.CashAppPay == null ? "null" : this.CashAppPay.ToString())}");
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
                .BuyNowPayLater(this.BuyNowPayLater)
                .CashAppPay(this.CashAppPay);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "card", false },
                { "square_gift_card", false },
                { "bank_account", false },
                { "buy_now_pay_later", false },
                { "cash_app_pay", false },
            };

            private bool? card;
            private bool? squareGiftCard;
            private bool? bankAccount;
            private bool? buyNowPayLater;
            private bool? cashAppPay;

             /// <summary>
             /// Card.
             /// </summary>
             /// <param name="card"> card. </param>
             /// <returns> Builder. </returns>
            public Builder Card(bool? card)
            {
                shouldSerialize["card"] = true;
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
                shouldSerialize["square_gift_card"] = true;
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
                shouldSerialize["bank_account"] = true;
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
                shouldSerialize["buy_now_pay_later"] = true;
                this.buyNowPayLater = buyNowPayLater;
                return this;
            }

             /// <summary>
             /// CashAppPay.
             /// </summary>
             /// <param name="cashAppPay"> cashAppPay. </param>
             /// <returns> Builder. </returns>
            public Builder CashAppPay(bool? cashAppPay)
            {
                shouldSerialize["cash_app_pay"] = true;
                this.cashAppPay = cashAppPay;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCard()
            {
                this.shouldSerialize["card"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetSquareGiftCard()
            {
                this.shouldSerialize["square_gift_card"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetBankAccount()
            {
                this.shouldSerialize["bank_account"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetBuyNowPayLater()
            {
                this.shouldSerialize["buy_now_pay_later"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCashAppPay()
            {
                this.shouldSerialize["cash_app_pay"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> InvoiceAcceptedPaymentMethods. </returns>
            public InvoiceAcceptedPaymentMethods Build()
            {
                return new InvoiceAcceptedPaymentMethods(shouldSerialize,
                    this.card,
                    this.squareGiftCard,
                    this.bankAccount,
                    this.buyNowPayLater,
                    this.cashAppPay);
            }
        }
    }
}