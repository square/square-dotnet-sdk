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
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// Getter for type
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; }

        /// <summary>
        /// A human-readable description of the tender.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; }

        /// <summary>
        /// The ID of the employee that processed the tender.
        /// </summary>
        [JsonProperty("employee_id", NullValueHandling = NullValueHandling.Ignore)]
        public string EmployeeId { get; }

        /// <summary>
        /// The URL of the receipt for the tender.
        /// </summary>
        [JsonProperty("receipt_url", NullValueHandling = NullValueHandling.Ignore)]
        public string ReceiptUrl { get; }

        /// <summary>
        /// The brand of a credit card.
        /// </summary>
        [JsonProperty("card_brand", NullValueHandling = NullValueHandling.Ignore)]
        public string CardBrand { get; }

        /// <summary>
        /// The last four digits of the provided credit card's account number.
        /// </summary>
        [JsonProperty("pan_suffix", NullValueHandling = NullValueHandling.Ignore)]
        public string PanSuffix { get; }

        /// <summary>
        /// Getter for entry_method
        /// </summary>
        [JsonProperty("entry_method", NullValueHandling = NullValueHandling.Ignore)]
        public string EntryMethod { get; }

        /// <summary>
        /// Notes entered by the merchant about the tender at the time of payment, if any. Typically only present for tender with the type: OTHER.
        /// </summary>
        [JsonProperty("payment_note", NullValueHandling = NullValueHandling.Ignore)]
        public string PaymentNote { get; }

        /// <summary>
        /// Getter for total_money
        /// </summary>
        [JsonProperty("total_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money TotalMoney { get; }

        /// <summary>
        /// Getter for tendered_money
        /// </summary>
        [JsonProperty("tendered_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money TenderedMoney { get; }

        /// <summary>
        /// The time when the tender was created, in ISO 8601 format.
        /// </summary>
        [JsonProperty("tendered_at", NullValueHandling = NullValueHandling.Ignore)]
        public string TenderedAt { get; }

        /// <summary>
        /// The time when the tender was settled, in ISO 8601 format.
        /// </summary>
        [JsonProperty("settled_at", NullValueHandling = NullValueHandling.Ignore)]
        public string SettledAt { get; }

        /// <summary>
        /// Getter for change_back_money
        /// </summary>
        [JsonProperty("change_back_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money ChangeBackMoney { get; }

        /// <summary>
        /// Getter for refunded_money
        /// </summary>
        [JsonProperty("refunded_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money RefundedMoney { get; }

        /// <summary>
        /// Indicates whether or not the tender is associated with an exchange. If is_exchange is true, the tender represents the value of goods returned in an exchange not the actual money paid. The exchange value reduces the tender amounts needed to pay for items purchased in the exchange.
        /// </summary>
        [JsonProperty("is_exchange", NullValueHandling = NullValueHandling.Ignore)]
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



            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

            public Builder Type(string type)
            {
                this.type = type;
                return this;
            }

            public Builder Name(string name)
            {
                this.name = name;
                return this;
            }

            public Builder EmployeeId(string employeeId)
            {
                this.employeeId = employeeId;
                return this;
            }

            public Builder ReceiptUrl(string receiptUrl)
            {
                this.receiptUrl = receiptUrl;
                return this;
            }

            public Builder CardBrand(string cardBrand)
            {
                this.cardBrand = cardBrand;
                return this;
            }

            public Builder PanSuffix(string panSuffix)
            {
                this.panSuffix = panSuffix;
                return this;
            }

            public Builder EntryMethod(string entryMethod)
            {
                this.entryMethod = entryMethod;
                return this;
            }

            public Builder PaymentNote(string paymentNote)
            {
                this.paymentNote = paymentNote;
                return this;
            }

            public Builder TotalMoney(Models.V1Money totalMoney)
            {
                this.totalMoney = totalMoney;
                return this;
            }

            public Builder TenderedMoney(Models.V1Money tenderedMoney)
            {
                this.tenderedMoney = tenderedMoney;
                return this;
            }

            public Builder TenderedAt(string tenderedAt)
            {
                this.tenderedAt = tenderedAt;
                return this;
            }

            public Builder SettledAt(string settledAt)
            {
                this.settledAt = settledAt;
                return this;
            }

            public Builder ChangeBackMoney(Models.V1Money changeBackMoney)
            {
                this.changeBackMoney = changeBackMoney;
                return this;
            }

            public Builder RefundedMoney(Models.V1Money refundedMoney)
            {
                this.refundedMoney = refundedMoney;
                return this;
            }

            public Builder IsExchange(bool? isExchange)
            {
                this.isExchange = isExchange;
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