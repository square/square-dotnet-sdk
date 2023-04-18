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
    /// InvoicePaymentRequest.
    /// </summary>
    public class InvoicePaymentRequest
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="InvoicePaymentRequest"/> class.
        /// </summary>
        /// <param name="uid">uid.</param>
        /// <param name="requestMethod">request_method.</param>
        /// <param name="requestType">request_type.</param>
        /// <param name="dueDate">due_date.</param>
        /// <param name="fixedAmountRequestedMoney">fixed_amount_requested_money.</param>
        /// <param name="percentageRequested">percentage_requested.</param>
        /// <param name="tippingEnabled">tipping_enabled.</param>
        /// <param name="automaticPaymentSource">automatic_payment_source.</param>
        /// <param name="cardId">card_id.</param>
        /// <param name="reminders">reminders.</param>
        /// <param name="computedAmountMoney">computed_amount_money.</param>
        /// <param name="totalCompletedAmountMoney">total_completed_amount_money.</param>
        /// <param name="roundingAdjustmentIncludedMoney">rounding_adjustment_included_money.</param>
        public InvoicePaymentRequest(
            string uid = null,
            string requestMethod = null,
            string requestType = null,
            string dueDate = null,
            Models.Money fixedAmountRequestedMoney = null,
            string percentageRequested = null,
            bool? tippingEnabled = null,
            string automaticPaymentSource = null,
            string cardId = null,
            IList<Models.InvoicePaymentReminder> reminders = null,
            Models.Money computedAmountMoney = null,
            Models.Money totalCompletedAmountMoney = null,
            Models.Money roundingAdjustmentIncludedMoney = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "uid", false },
                { "due_date", false },
                { "percentage_requested", false },
                { "tipping_enabled", false },
                { "card_id", false },
                { "reminders", false }
            };

            if (uid != null)
            {
                shouldSerialize["uid"] = true;
                this.Uid = uid;
            }

            this.RequestMethod = requestMethod;
            this.RequestType = requestType;
            if (dueDate != null)
            {
                shouldSerialize["due_date"] = true;
                this.DueDate = dueDate;
            }

            this.FixedAmountRequestedMoney = fixedAmountRequestedMoney;
            if (percentageRequested != null)
            {
                shouldSerialize["percentage_requested"] = true;
                this.PercentageRequested = percentageRequested;
            }

            if (tippingEnabled != null)
            {
                shouldSerialize["tipping_enabled"] = true;
                this.TippingEnabled = tippingEnabled;
            }

            this.AutomaticPaymentSource = automaticPaymentSource;
            if (cardId != null)
            {
                shouldSerialize["card_id"] = true;
                this.CardId = cardId;
            }

            if (reminders != null)
            {
                shouldSerialize["reminders"] = true;
                this.Reminders = reminders;
            }

            this.ComputedAmountMoney = computedAmountMoney;
            this.TotalCompletedAmountMoney = totalCompletedAmountMoney;
            this.RoundingAdjustmentIncludedMoney = roundingAdjustmentIncludedMoney;
        }
        internal InvoicePaymentRequest(Dictionary<string, bool> shouldSerialize,
            string uid = null,
            string requestMethod = null,
            string requestType = null,
            string dueDate = null,
            Models.Money fixedAmountRequestedMoney = null,
            string percentageRequested = null,
            bool? tippingEnabled = null,
            string automaticPaymentSource = null,
            string cardId = null,
            IList<Models.InvoicePaymentReminder> reminders = null,
            Models.Money computedAmountMoney = null,
            Models.Money totalCompletedAmountMoney = null,
            Models.Money roundingAdjustmentIncludedMoney = null)
        {
            this.shouldSerialize = shouldSerialize;
            Uid = uid;
            RequestMethod = requestMethod;
            RequestType = requestType;
            DueDate = dueDate;
            FixedAmountRequestedMoney = fixedAmountRequestedMoney;
            PercentageRequested = percentageRequested;
            TippingEnabled = tippingEnabled;
            AutomaticPaymentSource = automaticPaymentSource;
            CardId = cardId;
            Reminders = reminders;
            ComputedAmountMoney = computedAmountMoney;
            TotalCompletedAmountMoney = totalCompletedAmountMoney;
            RoundingAdjustmentIncludedMoney = roundingAdjustmentIncludedMoney;
        }

        /// <summary>
        /// The Square-generated ID of the payment request in an [invoice](entity:Invoice).
        /// </summary>
        [JsonProperty("uid")]
        public string Uid { get; }

        /// <summary>
        /// Specifies the action for Square to take for processing the invoice. For example,
        /// email the invoice, charge a customer's card on file, or do nothing. DEPRECATED at
        /// version 2021-01-21. The corresponding `request_method` field is replaced by the
        /// `Invoice.delivery_method` and `InvoicePaymentRequest.automatic_payment_source` fields.
        /// </summary>
        [JsonProperty("request_method", NullValueHandling = NullValueHandling.Ignore)]
        public string RequestMethod { get; }

        /// <summary>
        /// Indicates the type of the payment request. For more information, see
        /// [Configuring payment requests](https://developer.squareup.com/docs/invoices-api/create-publish-invoices#payment-requests).
        /// </summary>
        [JsonProperty("request_type", NullValueHandling = NullValueHandling.Ignore)]
        public string RequestType { get; }

        /// <summary>
        /// The due date (in the invoice's time zone) for the payment request, in `YYYY-MM-DD` format. This field
        /// is required to create a payment request. If an `automatic_payment_source` is defined for the request, Square
        /// charges the payment source on this date.
        /// After this date, the invoice becomes overdue. For example, a payment `due_date` of 2021-03-09 with a `timezone`
        /// of America/Los\_Angeles becomes overdue at midnight on March 9 in America/Los\_Angeles (which equals a UTC
        /// timestamp of 2021-03-10T08:00:00Z).
        /// </summary>
        [JsonProperty("due_date")]
        public string DueDate { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("fixed_amount_requested_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money FixedAmountRequestedMoney { get; }

        /// <summary>
        /// Specifies the amount for the payment request in percentage:
        /// - When the payment `request_type` is `DEPOSIT`, it is the percentage of the order's total amount.
        /// - When the payment `request_type` is `INSTALLMENT`, it is the percentage of the order's total less
        /// the deposit, if requested. The sum of the `percentage_requested` in all installment
        /// payment requests must be equal to 100.
        /// You cannot specify this when the payment `request_type` is `BALANCE` or when the
        /// payment request specifies the `fixed_amount_requested_money` field.
        /// </summary>
        [JsonProperty("percentage_requested")]
        public string PercentageRequested { get; }

        /// <summary>
        /// If set to true, the Square-hosted invoice page (the `public_url` field of the invoice)
        /// provides a place for the customer to pay a tip.
        /// This field is allowed only on the final payment request
        /// and the payment `request_type` must be `BALANCE` or `INSTALLMENT`.
        /// </summary>
        [JsonProperty("tipping_enabled")]
        public bool? TippingEnabled { get; }

        /// <summary>
        /// Indicates the automatic payment method for an [invoice payment request]($m/InvoicePaymentRequest).
        /// </summary>
        [JsonProperty("automatic_payment_source", NullValueHandling = NullValueHandling.Ignore)]
        public string AutomaticPaymentSource { get; }

        /// <summary>
        /// The ID of the credit or debit card on file to charge for the payment request. To get the cards on file for a customer,
        /// call [ListCards](api-endpoint:Cards-ListCards) and include the `customer_id` of the invoice recipient.
        /// </summary>
        [JsonProperty("card_id")]
        public string CardId { get; }

        /// <summary>
        /// A list of one or more reminders to send for the payment request.
        /// </summary>
        [JsonProperty("reminders")]
        public IList<Models.InvoicePaymentReminder> Reminders { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("computed_amount_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money ComputedAmountMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("total_completed_amount_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money TotalCompletedAmountMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("rounding_adjustment_included_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money RoundingAdjustmentIncludedMoney { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"InvoicePaymentRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeUid()
        {
            return this.shouldSerialize["uid"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDueDate()
        {
            return this.shouldSerialize["due_date"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePercentageRequested()
        {
            return this.shouldSerialize["percentage_requested"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTippingEnabled()
        {
            return this.shouldSerialize["tipping_enabled"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCardId()
        {
            return this.shouldSerialize["card_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeReminders()
        {
            return this.shouldSerialize["reminders"];
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

            return obj is InvoicePaymentRequest other &&
                ((this.Uid == null && other.Uid == null) || (this.Uid?.Equals(other.Uid) == true)) &&
                ((this.RequestMethod == null && other.RequestMethod == null) || (this.RequestMethod?.Equals(other.RequestMethod) == true)) &&
                ((this.RequestType == null && other.RequestType == null) || (this.RequestType?.Equals(other.RequestType) == true)) &&
                ((this.DueDate == null && other.DueDate == null) || (this.DueDate?.Equals(other.DueDate) == true)) &&
                ((this.FixedAmountRequestedMoney == null && other.FixedAmountRequestedMoney == null) || (this.FixedAmountRequestedMoney?.Equals(other.FixedAmountRequestedMoney) == true)) &&
                ((this.PercentageRequested == null && other.PercentageRequested == null) || (this.PercentageRequested?.Equals(other.PercentageRequested) == true)) &&
                ((this.TippingEnabled == null && other.TippingEnabled == null) || (this.TippingEnabled?.Equals(other.TippingEnabled) == true)) &&
                ((this.AutomaticPaymentSource == null && other.AutomaticPaymentSource == null) || (this.AutomaticPaymentSource?.Equals(other.AutomaticPaymentSource) == true)) &&
                ((this.CardId == null && other.CardId == null) || (this.CardId?.Equals(other.CardId) == true)) &&
                ((this.Reminders == null && other.Reminders == null) || (this.Reminders?.Equals(other.Reminders) == true)) &&
                ((this.ComputedAmountMoney == null && other.ComputedAmountMoney == null) || (this.ComputedAmountMoney?.Equals(other.ComputedAmountMoney) == true)) &&
                ((this.TotalCompletedAmountMoney == null && other.TotalCompletedAmountMoney == null) || (this.TotalCompletedAmountMoney?.Equals(other.TotalCompletedAmountMoney) == true)) &&
                ((this.RoundingAdjustmentIncludedMoney == null && other.RoundingAdjustmentIncludedMoney == null) || (this.RoundingAdjustmentIncludedMoney?.Equals(other.RoundingAdjustmentIncludedMoney) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 772730141;
            hashCode = HashCode.Combine(this.Uid, this.RequestMethod, this.RequestType, this.DueDate, this.FixedAmountRequestedMoney, this.PercentageRequested, this.TippingEnabled);

            hashCode = HashCode.Combine(hashCode, this.AutomaticPaymentSource, this.CardId, this.Reminders, this.ComputedAmountMoney, this.TotalCompletedAmountMoney, this.RoundingAdjustmentIncludedMoney);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Uid = {(this.Uid == null ? "null" : this.Uid == string.Empty ? "" : this.Uid)}");
            toStringOutput.Add($"this.RequestMethod = {(this.RequestMethod == null ? "null" : this.RequestMethod.ToString())}");
            toStringOutput.Add($"this.RequestType = {(this.RequestType == null ? "null" : this.RequestType.ToString())}");
            toStringOutput.Add($"this.DueDate = {(this.DueDate == null ? "null" : this.DueDate == string.Empty ? "" : this.DueDate)}");
            toStringOutput.Add($"this.FixedAmountRequestedMoney = {(this.FixedAmountRequestedMoney == null ? "null" : this.FixedAmountRequestedMoney.ToString())}");
            toStringOutput.Add($"this.PercentageRequested = {(this.PercentageRequested == null ? "null" : this.PercentageRequested == string.Empty ? "" : this.PercentageRequested)}");
            toStringOutput.Add($"this.TippingEnabled = {(this.TippingEnabled == null ? "null" : this.TippingEnabled.ToString())}");
            toStringOutput.Add($"this.AutomaticPaymentSource = {(this.AutomaticPaymentSource == null ? "null" : this.AutomaticPaymentSource.ToString())}");
            toStringOutput.Add($"this.CardId = {(this.CardId == null ? "null" : this.CardId == string.Empty ? "" : this.CardId)}");
            toStringOutput.Add($"this.Reminders = {(this.Reminders == null ? "null" : $"[{string.Join(", ", this.Reminders)} ]")}");
            toStringOutput.Add($"this.ComputedAmountMoney = {(this.ComputedAmountMoney == null ? "null" : this.ComputedAmountMoney.ToString())}");
            toStringOutput.Add($"this.TotalCompletedAmountMoney = {(this.TotalCompletedAmountMoney == null ? "null" : this.TotalCompletedAmountMoney.ToString())}");
            toStringOutput.Add($"this.RoundingAdjustmentIncludedMoney = {(this.RoundingAdjustmentIncludedMoney == null ? "null" : this.RoundingAdjustmentIncludedMoney.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Uid(this.Uid)
                .RequestMethod(this.RequestMethod)
                .RequestType(this.RequestType)
                .DueDate(this.DueDate)
                .FixedAmountRequestedMoney(this.FixedAmountRequestedMoney)
                .PercentageRequested(this.PercentageRequested)
                .TippingEnabled(this.TippingEnabled)
                .AutomaticPaymentSource(this.AutomaticPaymentSource)
                .CardId(this.CardId)
                .Reminders(this.Reminders)
                .ComputedAmountMoney(this.ComputedAmountMoney)
                .TotalCompletedAmountMoney(this.TotalCompletedAmountMoney)
                .RoundingAdjustmentIncludedMoney(this.RoundingAdjustmentIncludedMoney);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "uid", false },
                { "due_date", false },
                { "percentage_requested", false },
                { "tipping_enabled", false },
                { "card_id", false },
                { "reminders", false },
            };

            private string uid;
            private string requestMethod;
            private string requestType;
            private string dueDate;
            private Models.Money fixedAmountRequestedMoney;
            private string percentageRequested;
            private bool? tippingEnabled;
            private string automaticPaymentSource;
            private string cardId;
            private IList<Models.InvoicePaymentReminder> reminders;
            private Models.Money computedAmountMoney;
            private Models.Money totalCompletedAmountMoney;
            private Models.Money roundingAdjustmentIncludedMoney;

             /// <summary>
             /// Uid.
             /// </summary>
             /// <param name="uid"> uid. </param>
             /// <returns> Builder. </returns>
            public Builder Uid(string uid)
            {
                shouldSerialize["uid"] = true;
                this.uid = uid;
                return this;
            }

             /// <summary>
             /// RequestMethod.
             /// </summary>
             /// <param name="requestMethod"> requestMethod. </param>
             /// <returns> Builder. </returns>
            public Builder RequestMethod(string requestMethod)
            {
                this.requestMethod = requestMethod;
                return this;
            }

             /// <summary>
             /// RequestType.
             /// </summary>
             /// <param name="requestType"> requestType. </param>
             /// <returns> Builder. </returns>
            public Builder RequestType(string requestType)
            {
                this.requestType = requestType;
                return this;
            }

             /// <summary>
             /// DueDate.
             /// </summary>
             /// <param name="dueDate"> dueDate. </param>
             /// <returns> Builder. </returns>
            public Builder DueDate(string dueDate)
            {
                shouldSerialize["due_date"] = true;
                this.dueDate = dueDate;
                return this;
            }

             /// <summary>
             /// FixedAmountRequestedMoney.
             /// </summary>
             /// <param name="fixedAmountRequestedMoney"> fixedAmountRequestedMoney. </param>
             /// <returns> Builder. </returns>
            public Builder FixedAmountRequestedMoney(Models.Money fixedAmountRequestedMoney)
            {
                this.fixedAmountRequestedMoney = fixedAmountRequestedMoney;
                return this;
            }

             /// <summary>
             /// PercentageRequested.
             /// </summary>
             /// <param name="percentageRequested"> percentageRequested. </param>
             /// <returns> Builder. </returns>
            public Builder PercentageRequested(string percentageRequested)
            {
                shouldSerialize["percentage_requested"] = true;
                this.percentageRequested = percentageRequested;
                return this;
            }

             /// <summary>
             /// TippingEnabled.
             /// </summary>
             /// <param name="tippingEnabled"> tippingEnabled. </param>
             /// <returns> Builder. </returns>
            public Builder TippingEnabled(bool? tippingEnabled)
            {
                shouldSerialize["tipping_enabled"] = true;
                this.tippingEnabled = tippingEnabled;
                return this;
            }

             /// <summary>
             /// AutomaticPaymentSource.
             /// </summary>
             /// <param name="automaticPaymentSource"> automaticPaymentSource. </param>
             /// <returns> Builder. </returns>
            public Builder AutomaticPaymentSource(string automaticPaymentSource)
            {
                this.automaticPaymentSource = automaticPaymentSource;
                return this;
            }

             /// <summary>
             /// CardId.
             /// </summary>
             /// <param name="cardId"> cardId. </param>
             /// <returns> Builder. </returns>
            public Builder CardId(string cardId)
            {
                shouldSerialize["card_id"] = true;
                this.cardId = cardId;
                return this;
            }

             /// <summary>
             /// Reminders.
             /// </summary>
             /// <param name="reminders"> reminders. </param>
             /// <returns> Builder. </returns>
            public Builder Reminders(IList<Models.InvoicePaymentReminder> reminders)
            {
                shouldSerialize["reminders"] = true;
                this.reminders = reminders;
                return this;
            }

             /// <summary>
             /// ComputedAmountMoney.
             /// </summary>
             /// <param name="computedAmountMoney"> computedAmountMoney. </param>
             /// <returns> Builder. </returns>
            public Builder ComputedAmountMoney(Models.Money computedAmountMoney)
            {
                this.computedAmountMoney = computedAmountMoney;
                return this;
            }

             /// <summary>
             /// TotalCompletedAmountMoney.
             /// </summary>
             /// <param name="totalCompletedAmountMoney"> totalCompletedAmountMoney. </param>
             /// <returns> Builder. </returns>
            public Builder TotalCompletedAmountMoney(Models.Money totalCompletedAmountMoney)
            {
                this.totalCompletedAmountMoney = totalCompletedAmountMoney;
                return this;
            }

             /// <summary>
             /// RoundingAdjustmentIncludedMoney.
             /// </summary>
             /// <param name="roundingAdjustmentIncludedMoney"> roundingAdjustmentIncludedMoney. </param>
             /// <returns> Builder. </returns>
            public Builder RoundingAdjustmentIncludedMoney(Models.Money roundingAdjustmentIncludedMoney)
            {
                this.roundingAdjustmentIncludedMoney = roundingAdjustmentIncludedMoney;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetUid()
            {
                this.shouldSerialize["uid"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetDueDate()
            {
                this.shouldSerialize["due_date"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetPercentageRequested()
            {
                this.shouldSerialize["percentage_requested"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetTippingEnabled()
            {
                this.shouldSerialize["tipping_enabled"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCardId()
            {
                this.shouldSerialize["card_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetReminders()
            {
                this.shouldSerialize["reminders"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> InvoicePaymentRequest. </returns>
            public InvoicePaymentRequest Build()
            {
                return new InvoicePaymentRequest(shouldSerialize,
                    this.uid,
                    this.requestMethod,
                    this.requestType,
                    this.dueDate,
                    this.fixedAmountRequestedMoney,
                    this.percentageRequested,
                    this.tippingEnabled,
                    this.automaticPaymentSource,
                    this.cardId,
                    this.reminders,
                    this.computedAmountMoney,
                    this.totalCompletedAmountMoney,
                    this.roundingAdjustmentIncludedMoney);
            }
        }
    }
}