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
    public class V1Tender 
    {
        public V1Tender(string id = null,
            string type = null,
            string name = null,
            string employeeId = null,
            string receiptUrl = null,
            string cardBrand = null,
            string panSuffix = null,
            string entryMethod = null,
            string paymentNote = null,
            Models.V1Money totalMoney = null,
            Models.V1Money tenderedMoney = null,
            string tenderedAt = null,
            string settledAt = null,
            Models.V1Money changeBackMoney = null,
            Models.V1Money refundedMoney = null,
            bool? isExchange = null)
        {
            Id = id;
            Type = type;
            Name = name;
            EmployeeId = employeeId;
            ReceiptUrl = receiptUrl;
            CardBrand = cardBrand;
            PanSuffix = panSuffix;
            EntryMethod = entryMethod;
            PaymentNote = paymentNote;
            TotalMoney = totalMoney;
            TenderedMoney = tenderedMoney;
            TenderedAt = tenderedAt;
            SettledAt = settledAt;
            ChangeBackMoney = changeBackMoney;
            RefundedMoney = refundedMoney;
            IsExchange = isExchange;
        }

        /// <summary>
        /// The tender's unique ID.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// Getter for type
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; }

        /// <summary>
        /// A human-readable description of the tender.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// The ID of the employee that processed the tender.
        /// </summary>
        [JsonProperty("employee_id")]
        public string EmployeeId { get; }

        /// <summary>
        /// The URL of the receipt for the tender.
        /// </summary>
        [JsonProperty("receipt_url")]
        public string ReceiptUrl { get; }

        /// <summary>
        /// The brand of a credit card.
        /// </summary>
        [JsonProperty("card_brand")]
        public string CardBrand { get; }

        /// <summary>
        /// The last four digits of the provided credit card's account number.
        /// </summary>
        [JsonProperty("pan_suffix")]
        public string PanSuffix { get; }

        /// <summary>
        /// Getter for entry_method
        /// </summary>
        [JsonProperty("entry_method")]
        public string EntryMethod { get; }

        /// <summary>
        /// Notes entered by the merchant about the tender at the time of payment, if any. Typically only present for tender with the type: OTHER.
        /// </summary>
        [JsonProperty("payment_note")]
        public string PaymentNote { get; }

        /// <summary>
        /// Getter for total_money
        /// </summary>
        [JsonProperty("total_money")]
        public Models.V1Money TotalMoney { get; }

        /// <summary>
        /// Getter for tendered_money
        /// </summary>
        [JsonProperty("tendered_money")]
        public Models.V1Money TenderedMoney { get; }

        /// <summary>
        /// The time when the tender was created, in ISO 8601 format.
        /// </summary>
        [JsonProperty("tendered_at")]
        public string TenderedAt { get; }

        /// <summary>
        /// The time when the tender was settled, in ISO 8601 format.
        /// </summary>
        [JsonProperty("settled_at")]
        public string SettledAt { get; }

        /// <summary>
        /// Getter for change_back_money
        /// </summary>
        [JsonProperty("change_back_money")]
        public Models.V1Money ChangeBackMoney { get; }

        /// <summary>
        /// Getter for refunded_money
        /// </summary>
        [JsonProperty("refunded_money")]
        public Models.V1Money RefundedMoney { get; }

        /// <summary>
        /// Indicates whether or not the tender is associated with an exchange. If is_exchange is true, the tender represents the value of goods returned in an exchange not the actual money paid. The exchange value reduces the tender amounts needed to pay for items purchased in the exchange.
        /// </summary>
        [JsonProperty("is_exchange")]
        public bool? IsExchange { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(Id)
                .Type(Type)
                .Name(Name)
                .EmployeeId(EmployeeId)
                .ReceiptUrl(ReceiptUrl)
                .CardBrand(CardBrand)
                .PanSuffix(PanSuffix)
                .EntryMethod(EntryMethod)
                .PaymentNote(PaymentNote)
                .TotalMoney(TotalMoney)
                .TenderedMoney(TenderedMoney)
                .TenderedAt(TenderedAt)
                .SettledAt(SettledAt)
                .ChangeBackMoney(ChangeBackMoney)
                .RefundedMoney(RefundedMoney)
                .IsExchange(IsExchange);
            return builder;
        }

        public class Builder
        {
            private string id;
            private string type;
            private string name;
            private string employeeId;
            private string receiptUrl;
            private string cardBrand;
            private string panSuffix;
            private string entryMethod;
            private string paymentNote;
            private Models.V1Money totalMoney;
            private Models.V1Money tenderedMoney;
            private string tenderedAt;
            private string settledAt;
            private Models.V1Money changeBackMoney;
            private Models.V1Money refundedMoney;
            private bool? isExchange;

            public Builder() { }
            public Builder Id(string value)
            {
                id = value;
                return this;
            }

            public Builder Type(string value)
            {
                type = value;
                return this;
            }

            public Builder Name(string value)
            {
                name = value;
                return this;
            }

            public Builder EmployeeId(string value)
            {
                employeeId = value;
                return this;
            }

            public Builder ReceiptUrl(string value)
            {
                receiptUrl = value;
                return this;
            }

            public Builder CardBrand(string value)
            {
                cardBrand = value;
                return this;
            }

            public Builder PanSuffix(string value)
            {
                panSuffix = value;
                return this;
            }

            public Builder EntryMethod(string value)
            {
                entryMethod = value;
                return this;
            }

            public Builder PaymentNote(string value)
            {
                paymentNote = value;
                return this;
            }

            public Builder TotalMoney(Models.V1Money value)
            {
                totalMoney = value;
                return this;
            }

            public Builder TenderedMoney(Models.V1Money value)
            {
                tenderedMoney = value;
                return this;
            }

            public Builder TenderedAt(string value)
            {
                tenderedAt = value;
                return this;
            }

            public Builder SettledAt(string value)
            {
                settledAt = value;
                return this;
            }

            public Builder ChangeBackMoney(Models.V1Money value)
            {
                changeBackMoney = value;
                return this;
            }

            public Builder RefundedMoney(Models.V1Money value)
            {
                refundedMoney = value;
                return this;
            }

            public Builder IsExchange(bool? value)
            {
                isExchange = value;
                return this;
            }

            public V1Tender Build()
            {
                return new V1Tender(id,
                    type,
                    name,
                    employeeId,
                    receiptUrl,
                    cardBrand,
                    panSuffix,
                    entryMethod,
                    paymentNote,
                    totalMoney,
                    tenderedMoney,
                    tenderedAt,
                    settledAt,
                    changeBackMoney,
                    refundedMoney,
                    isExchange);
            }
        }
    }
}