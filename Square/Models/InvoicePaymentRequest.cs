
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class InvoicePaymentRequest 
    {
        public InvoicePaymentRequest(string uid = null,
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
        /// The Square-generated ID of the payment request in an [invoice](#type-invoice).
        /// </summary>
        [JsonProperty("uid", NullValueHandling = NullValueHandling.Ignore)]
        public string Uid { get; }

        /// <summary>
        /// Specifies the action for Square to take for processing the invoice. For example, 
        /// email the invoice, charge a customer's card on file, or do nothing. DEPRECATED at version 2021-01-21. The corresponding `request_method` field is replaced by the `Invoice.delivery_method` and `InvoicePaymentRequest.automatic_payment_source` fields.
        /// </summary>
        [JsonProperty("request_method", NullValueHandling = NullValueHandling.Ignore)]
        public string RequestMethod { get; }

        /// <summary>
        /// Indicates the type of the payment request. An invoice supports the following payment request combinations:
        /// - 1 balance
        /// - 1 deposit with 1 balance
        /// - 2 - 12 installments
        /// - 1 deposit with 2 - 12 installments
        /// For more information, 
        /// see [Payment requests](https://developer.squareup.com/docs/invoices-api/overview#payment-requests).
        /// </summary>
        [JsonProperty("request_type", NullValueHandling = NullValueHandling.Ignore)]
        public string RequestType { get; }

        /// <summary>
        /// The due date (in the invoice location's time zone) for the payment request, in `YYYY-MM-DD` format. 
        /// After this date, the invoice becomes overdue. This field is required to create a payment request.
        /// </summary>
        [JsonProperty("due_date", NullValueHandling = NullValueHandling.Ignore)]
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
        /// - When the payment `request_type` is `DEPOSIT`, it is the percentage of the order total amount.
        /// - When the payment `request_type` is `INSTALLMENT`, it is the percentage of the order total less 
        /// the deposit, if requested. The sum of the `percentage_requested` in all installment 
        /// payment requests must be equal to 100.
        /// You cannot specify this when the payment `request_type` is `BALANCE` or when the 
        /// payment request specifies the `fixed_amount_requested_money` field.
        /// </summary>
        [JsonProperty("percentage_requested", NullValueHandling = NullValueHandling.Ignore)]
        public string PercentageRequested { get; }

        /// <summary>
        /// If set to true, the Square-hosted invoice page (the `public_url` field of the invoice) 
        /// provides a place for the customer to pay a tip. 
        /// This field is allowed only on the final payment request  
        /// and the payment `request_type` must be `BALANCE` or `INSTALLMENT`.
        /// </summary>
        [JsonProperty("tipping_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? TippingEnabled { get; }

        /// <summary>
        /// Indicates the automatic payment method for an [invoice payment request](#type-InvoicePaymentRequest).
        /// </summary>
        [JsonProperty("automatic_payment_source", NullValueHandling = NullValueHandling.Ignore)]
        public string AutomaticPaymentSource { get; }

        /// <summary>
        /// The ID of the card on file to charge for the payment request. To get the customer’s card on file,
        /// use the `customer_id` of the invoice recipient to call [RetrieveCustomer](#endpoint-Customers-RetrieveCustomer)
        /// in the Customers API. Then, get the ID of the target card from the `cards` field in the response.
        /// </summary>
        [JsonProperty("card_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CardId { get; }

        /// <summary>
        /// A list of one or more reminders to send for the payment request.
        /// </summary>
        [JsonProperty("reminders", NullValueHandling = NullValueHandling.Ignore)]
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"InvoicePaymentRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Uid = {(Uid == null ? "null" : Uid == string.Empty ? "" : Uid)}");
            toStringOutput.Add($"RequestMethod = {(RequestMethod == null ? "null" : RequestMethod.ToString())}");
            toStringOutput.Add($"RequestType = {(RequestType == null ? "null" : RequestType.ToString())}");
            toStringOutput.Add($"DueDate = {(DueDate == null ? "null" : DueDate == string.Empty ? "" : DueDate)}");
            toStringOutput.Add($"FixedAmountRequestedMoney = {(FixedAmountRequestedMoney == null ? "null" : FixedAmountRequestedMoney.ToString())}");
            toStringOutput.Add($"PercentageRequested = {(PercentageRequested == null ? "null" : PercentageRequested == string.Empty ? "" : PercentageRequested)}");
            toStringOutput.Add($"TippingEnabled = {(TippingEnabled == null ? "null" : TippingEnabled.ToString())}");
            toStringOutput.Add($"AutomaticPaymentSource = {(AutomaticPaymentSource == null ? "null" : AutomaticPaymentSource.ToString())}");
            toStringOutput.Add($"CardId = {(CardId == null ? "null" : CardId == string.Empty ? "" : CardId)}");
            toStringOutput.Add($"Reminders = {(Reminders == null ? "null" : $"[{ string.Join(", ", Reminders)} ]")}");
            toStringOutput.Add($"ComputedAmountMoney = {(ComputedAmountMoney == null ? "null" : ComputedAmountMoney.ToString())}");
            toStringOutput.Add($"TotalCompletedAmountMoney = {(TotalCompletedAmountMoney == null ? "null" : TotalCompletedAmountMoney.ToString())}");
            toStringOutput.Add($"RoundingAdjustmentIncludedMoney = {(RoundingAdjustmentIncludedMoney == null ? "null" : RoundingAdjustmentIncludedMoney.ToString())}");
        }

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
                ((Uid == null && other.Uid == null) || (Uid?.Equals(other.Uid) == true)) &&
                ((RequestMethod == null && other.RequestMethod == null) || (RequestMethod?.Equals(other.RequestMethod) == true)) &&
                ((RequestType == null && other.RequestType == null) || (RequestType?.Equals(other.RequestType) == true)) &&
                ((DueDate == null && other.DueDate == null) || (DueDate?.Equals(other.DueDate) == true)) &&
                ((FixedAmountRequestedMoney == null && other.FixedAmountRequestedMoney == null) || (FixedAmountRequestedMoney?.Equals(other.FixedAmountRequestedMoney) == true)) &&
                ((PercentageRequested == null && other.PercentageRequested == null) || (PercentageRequested?.Equals(other.PercentageRequested) == true)) &&
                ((TippingEnabled == null && other.TippingEnabled == null) || (TippingEnabled?.Equals(other.TippingEnabled) == true)) &&
                ((AutomaticPaymentSource == null && other.AutomaticPaymentSource == null) || (AutomaticPaymentSource?.Equals(other.AutomaticPaymentSource) == true)) &&
                ((CardId == null && other.CardId == null) || (CardId?.Equals(other.CardId) == true)) &&
                ((Reminders == null && other.Reminders == null) || (Reminders?.Equals(other.Reminders) == true)) &&
                ((ComputedAmountMoney == null && other.ComputedAmountMoney == null) || (ComputedAmountMoney?.Equals(other.ComputedAmountMoney) == true)) &&
                ((TotalCompletedAmountMoney == null && other.TotalCompletedAmountMoney == null) || (TotalCompletedAmountMoney?.Equals(other.TotalCompletedAmountMoney) == true)) &&
                ((RoundingAdjustmentIncludedMoney == null && other.RoundingAdjustmentIncludedMoney == null) || (RoundingAdjustmentIncludedMoney?.Equals(other.RoundingAdjustmentIncludedMoney) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 772730141;

            if (Uid != null)
            {
               hashCode += Uid.GetHashCode();
            }

            if (RequestMethod != null)
            {
               hashCode += RequestMethod.GetHashCode();
            }

            if (RequestType != null)
            {
               hashCode += RequestType.GetHashCode();
            }

            if (DueDate != null)
            {
               hashCode += DueDate.GetHashCode();
            }

            if (FixedAmountRequestedMoney != null)
            {
               hashCode += FixedAmountRequestedMoney.GetHashCode();
            }

            if (PercentageRequested != null)
            {
               hashCode += PercentageRequested.GetHashCode();
            }

            if (TippingEnabled != null)
            {
               hashCode += TippingEnabled.GetHashCode();
            }

            if (AutomaticPaymentSource != null)
            {
               hashCode += AutomaticPaymentSource.GetHashCode();
            }

            if (CardId != null)
            {
               hashCode += CardId.GetHashCode();
            }

            if (Reminders != null)
            {
               hashCode += Reminders.GetHashCode();
            }

            if (ComputedAmountMoney != null)
            {
               hashCode += ComputedAmountMoney.GetHashCode();
            }

            if (TotalCompletedAmountMoney != null)
            {
               hashCode += TotalCompletedAmountMoney.GetHashCode();
            }

            if (RoundingAdjustmentIncludedMoney != null)
            {
               hashCode += RoundingAdjustmentIncludedMoney.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Uid(Uid)
                .RequestMethod(RequestMethod)
                .RequestType(RequestType)
                .DueDate(DueDate)
                .FixedAmountRequestedMoney(FixedAmountRequestedMoney)
                .PercentageRequested(PercentageRequested)
                .TippingEnabled(TippingEnabled)
                .AutomaticPaymentSource(AutomaticPaymentSource)
                .CardId(CardId)
                .Reminders(Reminders)
                .ComputedAmountMoney(ComputedAmountMoney)
                .TotalCompletedAmountMoney(TotalCompletedAmountMoney)
                .RoundingAdjustmentIncludedMoney(RoundingAdjustmentIncludedMoney);
            return builder;
        }

        public class Builder
        {
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



            public Builder Uid(string uid)
            {
                this.uid = uid;
                return this;
            }

            public Builder RequestMethod(string requestMethod)
            {
                this.requestMethod = requestMethod;
                return this;
            }

            public Builder RequestType(string requestType)
            {
                this.requestType = requestType;
                return this;
            }

            public Builder DueDate(string dueDate)
            {
                this.dueDate = dueDate;
                return this;
            }

            public Builder FixedAmountRequestedMoney(Models.Money fixedAmountRequestedMoney)
            {
                this.fixedAmountRequestedMoney = fixedAmountRequestedMoney;
                return this;
            }

            public Builder PercentageRequested(string percentageRequested)
            {
                this.percentageRequested = percentageRequested;
                return this;
            }

            public Builder TippingEnabled(bool? tippingEnabled)
            {
                this.tippingEnabled = tippingEnabled;
                return this;
            }

            public Builder AutomaticPaymentSource(string automaticPaymentSource)
            {
                this.automaticPaymentSource = automaticPaymentSource;
                return this;
            }

            public Builder CardId(string cardId)
            {
                this.cardId = cardId;
                return this;
            }

            public Builder Reminders(IList<Models.InvoicePaymentReminder> reminders)
            {
                this.reminders = reminders;
                return this;
            }

            public Builder ComputedAmountMoney(Models.Money computedAmountMoney)
            {
                this.computedAmountMoney = computedAmountMoney;
                return this;
            }

            public Builder TotalCompletedAmountMoney(Models.Money totalCompletedAmountMoney)
            {
                this.totalCompletedAmountMoney = totalCompletedAmountMoney;
                return this;
            }

            public Builder RoundingAdjustmentIncludedMoney(Models.Money roundingAdjustmentIncludedMoney)
            {
                this.roundingAdjustmentIncludedMoney = roundingAdjustmentIncludedMoney;
                return this;
            }

            public InvoicePaymentRequest Build()
            {
                return new InvoicePaymentRequest(uid,
                    requestMethod,
                    requestType,
                    dueDate,
                    fixedAmountRequestedMoney,
                    percentageRequested,
                    tippingEnabled,
                    automaticPaymentSource,
                    cardId,
                    reminders,
                    computedAmountMoney,
                    totalCompletedAmountMoney,
                    roundingAdjustmentIncludedMoney);
            }
        }
    }
}