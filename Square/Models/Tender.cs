namespace Square.Models
{
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

    /// <summary>
    /// Tender.
    /// </summary>
    public class Tender
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="Tender"/> class.
        /// </summary>
        /// <param name="type">type.</param>
        /// <param name="id">id.</param>
        /// <param name="locationId">location_id.</param>
        /// <param name="transactionId">transaction_id.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="note">note.</param>
        /// <param name="amountMoney">amount_money.</param>
        /// <param name="tipMoney">tip_money.</param>
        /// <param name="processingFeeMoney">processing_fee_money.</param>
        /// <param name="customerId">customer_id.</param>
        /// <param name="cardDetails">card_details.</param>
        /// <param name="cashDetails">cash_details.</param>
        /// <param name="bankAccountDetails">bank_account_details.</param>
        /// <param name="buyNowPayLaterDetails">buy_now_pay_later_details.</param>
        /// <param name="squareAccountDetails">square_account_details.</param>
        /// <param name="additionalRecipients">additional_recipients.</param>
        /// <param name="paymentId">payment_id.</param>
        public Tender(
            string type,
            string id = null,
            string locationId = null,
            string transactionId = null,
            string createdAt = null,
            string note = null,
            Models.Money amountMoney = null,
            Models.Money tipMoney = null,
            Models.Money processingFeeMoney = null,
            string customerId = null,
            Models.TenderCardDetails cardDetails = null,
            Models.TenderCashDetails cashDetails = null,
            Models.TenderBankAccountDetails bankAccountDetails = null,
            Models.TenderBuyNowPayLaterDetails buyNowPayLaterDetails = null,
            Models.TenderSquareAccountDetails squareAccountDetails = null,
            IList<Models.AdditionalRecipient> additionalRecipients = null,
            string paymentId = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "location_id", false },
                { "transaction_id", false },
                { "note", false },
                { "customer_id", false },
                { "additional_recipients", false },
                { "payment_id", false }
            };

            this.Id = id;
            if (locationId != null)
            {
                shouldSerialize["location_id"] = true;
                this.LocationId = locationId;
            }

            if (transactionId != null)
            {
                shouldSerialize["transaction_id"] = true;
                this.TransactionId = transactionId;
            }

            this.CreatedAt = createdAt;
            if (note != null)
            {
                shouldSerialize["note"] = true;
                this.Note = note;
            }

            this.AmountMoney = amountMoney;
            this.TipMoney = tipMoney;
            this.ProcessingFeeMoney = processingFeeMoney;
            if (customerId != null)
            {
                shouldSerialize["customer_id"] = true;
                this.CustomerId = customerId;
            }

            this.Type = type;
            this.CardDetails = cardDetails;
            this.CashDetails = cashDetails;
            this.BankAccountDetails = bankAccountDetails;
            this.BuyNowPayLaterDetails = buyNowPayLaterDetails;
            this.SquareAccountDetails = squareAccountDetails;
            if (additionalRecipients != null)
            {
                shouldSerialize["additional_recipients"] = true;
                this.AdditionalRecipients = additionalRecipients;
            }

            if (paymentId != null)
            {
                shouldSerialize["payment_id"] = true;
                this.PaymentId = paymentId;
            }

        }
        internal Tender(Dictionary<string, bool> shouldSerialize,
            string type,
            string id = null,
            string locationId = null,
            string transactionId = null,
            string createdAt = null,
            string note = null,
            Models.Money amountMoney = null,
            Models.Money tipMoney = null,
            Models.Money processingFeeMoney = null,
            string customerId = null,
            Models.TenderCardDetails cardDetails = null,
            Models.TenderCashDetails cashDetails = null,
            Models.TenderBankAccountDetails bankAccountDetails = null,
            Models.TenderBuyNowPayLaterDetails buyNowPayLaterDetails = null,
            Models.TenderSquareAccountDetails squareAccountDetails = null,
            IList<Models.AdditionalRecipient> additionalRecipients = null,
            string paymentId = null)
        {
            this.shouldSerialize = shouldSerialize;
            Id = id;
            LocationId = locationId;
            TransactionId = transactionId;
            CreatedAt = createdAt;
            Note = note;
            AmountMoney = amountMoney;
            TipMoney = tipMoney;
            ProcessingFeeMoney = processingFeeMoney;
            CustomerId = customerId;
            Type = type;
            CardDetails = cardDetails;
            CashDetails = cashDetails;
            BankAccountDetails = bankAccountDetails;
            BuyNowPayLaterDetails = buyNowPayLaterDetails;
            SquareAccountDetails = squareAccountDetails;
            AdditionalRecipients = additionalRecipients;
            PaymentId = paymentId;
        }

        /// <summary>
        /// The tender's unique ID. It is the associated payment ID.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The ID of the transaction's associated location.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        /// <summary>
        /// The ID of the tender's associated transaction.
        /// </summary>
        [JsonProperty("transaction_id")]
        public string TransactionId { get; }

        /// <summary>
        /// The timestamp for when the tender was created, in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// An optional note associated with the tender at the time of payment.
        /// </summary>
        [JsonProperty("note")]
        public string Note { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("amount_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money AmountMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("tip_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money TipMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("processing_fee_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money ProcessingFeeMoney { get; }

        /// <summary>
        /// If the tender is associated with a customer or represents a customer's card on file,
        /// this is the ID of the associated customer.
        /// </summary>
        [JsonProperty("customer_id")]
        public string CustomerId { get; }

        /// <summary>
        /// Indicates a tender's type.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; }

        /// <summary>
        /// Represents additional details of a tender with `type` `CARD` or `SQUARE_GIFT_CARD`
        /// </summary>
        [JsonProperty("card_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TenderCardDetails CardDetails { get; }

        /// <summary>
        /// Represents the details of a tender with `type` `CASH`.
        /// </summary>
        [JsonProperty("cash_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TenderCashDetails CashDetails { get; }

        /// <summary>
        /// Represents the details of a tender with `type` `BANK_ACCOUNT`.
        /// See [BankAccountPaymentDetails]($m/BankAccountPaymentDetails)
        /// for more exposed details of a bank account payment.
        /// </summary>
        [JsonProperty("bank_account_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TenderBankAccountDetails BankAccountDetails { get; }

        /// <summary>
        /// Represents the details of a tender with `type` `BUY_NOW_PAY_LATER`.
        /// </summary>
        [JsonProperty("buy_now_pay_later_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TenderBuyNowPayLaterDetails BuyNowPayLaterDetails { get; }

        /// <summary>
        /// Represents the details of a tender with `type` `SQUARE_ACCOUNT`.
        /// </summary>
        [JsonProperty("square_account_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TenderSquareAccountDetails SquareAccountDetails { get; }

        /// <summary>
        /// Additional recipients (other than the merchant) receiving a portion of this tender.
        /// For example, fees assessed on the purchase by a third party integration.
        /// </summary>
        [JsonProperty("additional_recipients")]
        public IList<Models.AdditionalRecipient> AdditionalRecipients { get; }

        /// <summary>
        /// The ID of the [Payment](entity:Payment) that corresponds to this tender.
        /// This value is only present for payments created with the v2 Payments API.
        /// </summary>
        [JsonProperty("payment_id")]
        public string PaymentId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Tender : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLocationId()
        {
            return this.shouldSerialize["location_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTransactionId()
        {
            return this.shouldSerialize["transaction_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeNote()
        {
            return this.shouldSerialize["note"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCustomerId()
        {
            return this.shouldSerialize["customer_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAdditionalRecipients()
        {
            return this.shouldSerialize["additional_recipients"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePaymentId()
        {
            return this.shouldSerialize["payment_id"];
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
            return obj is Tender other &&                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.TransactionId == null && other.TransactionId == null) || (this.TransactionId?.Equals(other.TransactionId) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((this.Note == null && other.Note == null) || (this.Note?.Equals(other.Note) == true)) &&
                ((this.AmountMoney == null && other.AmountMoney == null) || (this.AmountMoney?.Equals(other.AmountMoney) == true)) &&
                ((this.TipMoney == null && other.TipMoney == null) || (this.TipMoney?.Equals(other.TipMoney) == true)) &&
                ((this.ProcessingFeeMoney == null && other.ProcessingFeeMoney == null) || (this.ProcessingFeeMoney?.Equals(other.ProcessingFeeMoney) == true)) &&
                ((this.CustomerId == null && other.CustomerId == null) || (this.CustomerId?.Equals(other.CustomerId) == true)) &&
                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true)) &&
                ((this.CardDetails == null && other.CardDetails == null) || (this.CardDetails?.Equals(other.CardDetails) == true)) &&
                ((this.CashDetails == null && other.CashDetails == null) || (this.CashDetails?.Equals(other.CashDetails) == true)) &&
                ((this.BankAccountDetails == null && other.BankAccountDetails == null) || (this.BankAccountDetails?.Equals(other.BankAccountDetails) == true)) &&
                ((this.BuyNowPayLaterDetails == null && other.BuyNowPayLaterDetails == null) || (this.BuyNowPayLaterDetails?.Equals(other.BuyNowPayLaterDetails) == true)) &&
                ((this.SquareAccountDetails == null && other.SquareAccountDetails == null) || (this.SquareAccountDetails?.Equals(other.SquareAccountDetails) == true)) &&
                ((this.AdditionalRecipients == null && other.AdditionalRecipients == null) || (this.AdditionalRecipients?.Equals(other.AdditionalRecipients) == true)) &&
                ((this.PaymentId == null && other.PaymentId == null) || (this.PaymentId?.Equals(other.PaymentId) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -2135423023;
            hashCode = HashCode.Combine(this.Id, this.LocationId, this.TransactionId, this.CreatedAt, this.Note, this.AmountMoney, this.TipMoney);

            hashCode = HashCode.Combine(hashCode, this.ProcessingFeeMoney, this.CustomerId, this.Type, this.CardDetails, this.CashDetails, this.BankAccountDetails, this.BuyNowPayLaterDetails);

            hashCode = HashCode.Combine(hashCode, this.SquareAccountDetails, this.AdditionalRecipients, this.PaymentId);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId)}");
            toStringOutput.Add($"this.TransactionId = {(this.TransactionId == null ? "null" : this.TransactionId)}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt)}");
            toStringOutput.Add($"this.Note = {(this.Note == null ? "null" : this.Note)}");
            toStringOutput.Add($"this.AmountMoney = {(this.AmountMoney == null ? "null" : this.AmountMoney.ToString())}");
            toStringOutput.Add($"this.TipMoney = {(this.TipMoney == null ? "null" : this.TipMoney.ToString())}");
            toStringOutput.Add($"this.ProcessingFeeMoney = {(this.ProcessingFeeMoney == null ? "null" : this.ProcessingFeeMoney.ToString())}");
            toStringOutput.Add($"this.CustomerId = {(this.CustomerId == null ? "null" : this.CustomerId)}");
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type.ToString())}");
            toStringOutput.Add($"this.CardDetails = {(this.CardDetails == null ? "null" : this.CardDetails.ToString())}");
            toStringOutput.Add($"this.CashDetails = {(this.CashDetails == null ? "null" : this.CashDetails.ToString())}");
            toStringOutput.Add($"this.BankAccountDetails = {(this.BankAccountDetails == null ? "null" : this.BankAccountDetails.ToString())}");
            toStringOutput.Add($"this.BuyNowPayLaterDetails = {(this.BuyNowPayLaterDetails == null ? "null" : this.BuyNowPayLaterDetails.ToString())}");
            toStringOutput.Add($"this.SquareAccountDetails = {(this.SquareAccountDetails == null ? "null" : this.SquareAccountDetails.ToString())}");
            toStringOutput.Add($"this.AdditionalRecipients = {(this.AdditionalRecipients == null ? "null" : $"[{string.Join(", ", this.AdditionalRecipients)} ]")}");
            toStringOutput.Add($"this.PaymentId = {(this.PaymentId == null ? "null" : this.PaymentId)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Type)
                .Id(this.Id)
                .LocationId(this.LocationId)
                .TransactionId(this.TransactionId)
                .CreatedAt(this.CreatedAt)
                .Note(this.Note)
                .AmountMoney(this.AmountMoney)
                .TipMoney(this.TipMoney)
                .ProcessingFeeMoney(this.ProcessingFeeMoney)
                .CustomerId(this.CustomerId)
                .CardDetails(this.CardDetails)
                .CashDetails(this.CashDetails)
                .BankAccountDetails(this.BankAccountDetails)
                .BuyNowPayLaterDetails(this.BuyNowPayLaterDetails)
                .SquareAccountDetails(this.SquareAccountDetails)
                .AdditionalRecipients(this.AdditionalRecipients)
                .PaymentId(this.PaymentId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "location_id", false },
                { "transaction_id", false },
                { "note", false },
                { "customer_id", false },
                { "additional_recipients", false },
                { "payment_id", false },
            };

            private string type;
            private string id;
            private string locationId;
            private string transactionId;
            private string createdAt;
            private string note;
            private Models.Money amountMoney;
            private Models.Money tipMoney;
            private Models.Money processingFeeMoney;
            private string customerId;
            private Models.TenderCardDetails cardDetails;
            private Models.TenderCashDetails cashDetails;
            private Models.TenderBankAccountDetails bankAccountDetails;
            private Models.TenderBuyNowPayLaterDetails buyNowPayLaterDetails;
            private Models.TenderSquareAccountDetails squareAccountDetails;
            private IList<Models.AdditionalRecipient> additionalRecipients;
            private string paymentId;

            /// <summary>
            /// Initialize Builder for Tender.
            /// </summary>
            /// <param name="type"> type. </param>
            public Builder(
                string type)
            {
                this.type = type;
            }

             /// <summary>
             /// Type.
             /// </summary>
             /// <param name="type"> type. </param>
             /// <returns> Builder. </returns>
            public Builder Type(string type)
            {
                this.type = type;
                return this;
            }

             /// <summary>
             /// Id.
             /// </summary>
             /// <param name="id"> id. </param>
             /// <returns> Builder. </returns>
            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

             /// <summary>
             /// LocationId.
             /// </summary>
             /// <param name="locationId"> locationId. </param>
             /// <returns> Builder. </returns>
            public Builder LocationId(string locationId)
            {
                shouldSerialize["location_id"] = true;
                this.locationId = locationId;
                return this;
            }

             /// <summary>
             /// TransactionId.
             /// </summary>
             /// <param name="transactionId"> transactionId. </param>
             /// <returns> Builder. </returns>
            public Builder TransactionId(string transactionId)
            {
                shouldSerialize["transaction_id"] = true;
                this.transactionId = transactionId;
                return this;
            }

             /// <summary>
             /// CreatedAt.
             /// </summary>
             /// <param name="createdAt"> createdAt. </param>
             /// <returns> Builder. </returns>
            public Builder CreatedAt(string createdAt)
            {
                this.createdAt = createdAt;
                return this;
            }

             /// <summary>
             /// Note.
             /// </summary>
             /// <param name="note"> note. </param>
             /// <returns> Builder. </returns>
            public Builder Note(string note)
            {
                shouldSerialize["note"] = true;
                this.note = note;
                return this;
            }

             /// <summary>
             /// AmountMoney.
             /// </summary>
             /// <param name="amountMoney"> amountMoney. </param>
             /// <returns> Builder. </returns>
            public Builder AmountMoney(Models.Money amountMoney)
            {
                this.amountMoney = amountMoney;
                return this;
            }

             /// <summary>
             /// TipMoney.
             /// </summary>
             /// <param name="tipMoney"> tipMoney. </param>
             /// <returns> Builder. </returns>
            public Builder TipMoney(Models.Money tipMoney)
            {
                this.tipMoney = tipMoney;
                return this;
            }

             /// <summary>
             /// ProcessingFeeMoney.
             /// </summary>
             /// <param name="processingFeeMoney"> processingFeeMoney. </param>
             /// <returns> Builder. </returns>
            public Builder ProcessingFeeMoney(Models.Money processingFeeMoney)
            {
                this.processingFeeMoney = processingFeeMoney;
                return this;
            }

             /// <summary>
             /// CustomerId.
             /// </summary>
             /// <param name="customerId"> customerId. </param>
             /// <returns> Builder. </returns>
            public Builder CustomerId(string customerId)
            {
                shouldSerialize["customer_id"] = true;
                this.customerId = customerId;
                return this;
            }

             /// <summary>
             /// CardDetails.
             /// </summary>
             /// <param name="cardDetails"> cardDetails. </param>
             /// <returns> Builder. </returns>
            public Builder CardDetails(Models.TenderCardDetails cardDetails)
            {
                this.cardDetails = cardDetails;
                return this;
            }

             /// <summary>
             /// CashDetails.
             /// </summary>
             /// <param name="cashDetails"> cashDetails. </param>
             /// <returns> Builder. </returns>
            public Builder CashDetails(Models.TenderCashDetails cashDetails)
            {
                this.cashDetails = cashDetails;
                return this;
            }

             /// <summary>
             /// BankAccountDetails.
             /// </summary>
             /// <param name="bankAccountDetails"> bankAccountDetails. </param>
             /// <returns> Builder. </returns>
            public Builder BankAccountDetails(Models.TenderBankAccountDetails bankAccountDetails)
            {
                this.bankAccountDetails = bankAccountDetails;
                return this;
            }

             /// <summary>
             /// BuyNowPayLaterDetails.
             /// </summary>
             /// <param name="buyNowPayLaterDetails"> buyNowPayLaterDetails. </param>
             /// <returns> Builder. </returns>
            public Builder BuyNowPayLaterDetails(Models.TenderBuyNowPayLaterDetails buyNowPayLaterDetails)
            {
                this.buyNowPayLaterDetails = buyNowPayLaterDetails;
                return this;
            }

             /// <summary>
             /// SquareAccountDetails.
             /// </summary>
             /// <param name="squareAccountDetails"> squareAccountDetails. </param>
             /// <returns> Builder. </returns>
            public Builder SquareAccountDetails(Models.TenderSquareAccountDetails squareAccountDetails)
            {
                this.squareAccountDetails = squareAccountDetails;
                return this;
            }

             /// <summary>
             /// AdditionalRecipients.
             /// </summary>
             /// <param name="additionalRecipients"> additionalRecipients. </param>
             /// <returns> Builder. </returns>
            public Builder AdditionalRecipients(IList<Models.AdditionalRecipient> additionalRecipients)
            {
                shouldSerialize["additional_recipients"] = true;
                this.additionalRecipients = additionalRecipients;
                return this;
            }

             /// <summary>
             /// PaymentId.
             /// </summary>
             /// <param name="paymentId"> paymentId. </param>
             /// <returns> Builder. </returns>
            public Builder PaymentId(string paymentId)
            {
                shouldSerialize["payment_id"] = true;
                this.paymentId = paymentId;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetLocationId()
            {
                this.shouldSerialize["location_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetTransactionId()
            {
                this.shouldSerialize["transaction_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetNote()
            {
                this.shouldSerialize["note"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCustomerId()
            {
                this.shouldSerialize["customer_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetAdditionalRecipients()
            {
                this.shouldSerialize["additional_recipients"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetPaymentId()
            {
                this.shouldSerialize["payment_id"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> Tender. </returns>
            public Tender Build()
            {
                return new Tender(shouldSerialize,
                    this.type,
                    this.id,
                    this.locationId,
                    this.transactionId,
                    this.createdAt,
                    this.note,
                    this.amountMoney,
                    this.tipMoney,
                    this.processingFeeMoney,
                    this.customerId,
                    this.cardDetails,
                    this.cashDetails,
                    this.bankAccountDetails,
                    this.buyNowPayLaterDetails,
                    this.squareAccountDetails,
                    this.additionalRecipients,
                    this.paymentId);
            }
        }
    }
}