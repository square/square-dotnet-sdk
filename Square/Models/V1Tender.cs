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
    /// V1Tender.
    /// </summary>
    public class V1Tender
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="V1Tender"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="type">type.</param>
        /// <param name="name">name.</param>
        /// <param name="employeeId">employee_id.</param>
        /// <param name="receiptUrl">receipt_url.</param>
        /// <param name="cardBrand">card_brand.</param>
        /// <param name="panSuffix">pan_suffix.</param>
        /// <param name="entryMethod">entry_method.</param>
        /// <param name="paymentNote">payment_note.</param>
        /// <param name="totalMoney">total_money.</param>
        /// <param name="tenderedMoney">tendered_money.</param>
        /// <param name="tenderedAt">tendered_at.</param>
        /// <param name="settledAt">settled_at.</param>
        /// <param name="changeBackMoney">change_back_money.</param>
        /// <param name="refundedMoney">refunded_money.</param>
        /// <param name="isExchange">is_exchange.</param>
        public V1Tender(
            string id = null,
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
            shouldSerialize = new Dictionary<string, bool>
            {
                { "name", false },
                { "employee_id", false },
                { "receipt_url", false },
                { "pan_suffix", false },
                { "payment_note", false },
                { "tendered_at", false },
                { "settled_at", false },
                { "is_exchange", false }
            };

            this.Id = id;
            this.Type = type;
            if (name != null)
            {
                shouldSerialize["name"] = true;
                this.Name = name;
            }

            if (employeeId != null)
            {
                shouldSerialize["employee_id"] = true;
                this.EmployeeId = employeeId;
            }

            if (receiptUrl != null)
            {
                shouldSerialize["receipt_url"] = true;
                this.ReceiptUrl = receiptUrl;
            }

            this.CardBrand = cardBrand;
            if (panSuffix != null)
            {
                shouldSerialize["pan_suffix"] = true;
                this.PanSuffix = panSuffix;
            }

            this.EntryMethod = entryMethod;
            if (paymentNote != null)
            {
                shouldSerialize["payment_note"] = true;
                this.PaymentNote = paymentNote;
            }

            this.TotalMoney = totalMoney;
            this.TenderedMoney = tenderedMoney;
            if (tenderedAt != null)
            {
                shouldSerialize["tendered_at"] = true;
                this.TenderedAt = tenderedAt;
            }

            if (settledAt != null)
            {
                shouldSerialize["settled_at"] = true;
                this.SettledAt = settledAt;
            }

            this.ChangeBackMoney = changeBackMoney;
            this.RefundedMoney = refundedMoney;
            if (isExchange != null)
            {
                shouldSerialize["is_exchange"] = true;
                this.IsExchange = isExchange;
            }

        }
        internal V1Tender(Dictionary<string, bool> shouldSerialize,
            string id = null,
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
            this.shouldSerialize = shouldSerialize;
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
        /// Gets or sets Type.
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
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
        [JsonProperty("card_brand", NullValueHandling = NullValueHandling.Ignore)]
        public string CardBrand { get; }

        /// <summary>
        /// The last four digits of the provided credit card's account number.
        /// </summary>
        [JsonProperty("pan_suffix")]
        public string PanSuffix { get; }

        /// <summary>
        /// Gets or sets EntryMethod.
        /// </summary>
        [JsonProperty("entry_method", NullValueHandling = NullValueHandling.Ignore)]
        public string EntryMethod { get; }

        /// <summary>
        /// Notes entered by the merchant about the tender at the time of payment, if any. Typically only present for tender with the type: OTHER.
        /// </summary>
        [JsonProperty("payment_note")]
        public string PaymentNote { get; }

        /// <summary>
        /// Gets or sets TotalMoney.
        /// </summary>
        [JsonProperty("total_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money TotalMoney { get; }

        /// <summary>
        /// Gets or sets TenderedMoney.
        /// </summary>
        [JsonProperty("tendered_money", NullValueHandling = NullValueHandling.Ignore)]
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
        /// Gets or sets ChangeBackMoney.
        /// </summary>
        [JsonProperty("change_back_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money ChangeBackMoney { get; }

        /// <summary>
        /// Gets or sets RefundedMoney.
        /// </summary>
        [JsonProperty("refunded_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money RefundedMoney { get; }

        /// <summary>
        /// Indicates whether or not the tender is associated with an exchange. If is_exchange is true, the tender represents the value of goods returned in an exchange not the actual money paid. The exchange value reduces the tender amounts needed to pay for items purchased in the exchange.
        /// </summary>
        [JsonProperty("is_exchange")]
        public bool? IsExchange { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1Tender : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeName()
        {
            return this.shouldSerialize["name"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEmployeeId()
        {
            return this.shouldSerialize["employee_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeReceiptUrl()
        {
            return this.shouldSerialize["receipt_url"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePanSuffix()
        {
            return this.shouldSerialize["pan_suffix"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePaymentNote()
        {
            return this.shouldSerialize["payment_note"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTenderedAt()
        {
            return this.shouldSerialize["tendered_at"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSettledAt()
        {
            return this.shouldSerialize["settled_at"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeIsExchange()
        {
            return this.shouldSerialize["is_exchange"];
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
            return obj is V1Tender other &&                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true)) &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.EmployeeId == null && other.EmployeeId == null) || (this.EmployeeId?.Equals(other.EmployeeId) == true)) &&
                ((this.ReceiptUrl == null && other.ReceiptUrl == null) || (this.ReceiptUrl?.Equals(other.ReceiptUrl) == true)) &&
                ((this.CardBrand == null && other.CardBrand == null) || (this.CardBrand?.Equals(other.CardBrand) == true)) &&
                ((this.PanSuffix == null && other.PanSuffix == null) || (this.PanSuffix?.Equals(other.PanSuffix) == true)) &&
                ((this.EntryMethod == null && other.EntryMethod == null) || (this.EntryMethod?.Equals(other.EntryMethod) == true)) &&
                ((this.PaymentNote == null && other.PaymentNote == null) || (this.PaymentNote?.Equals(other.PaymentNote) == true)) &&
                ((this.TotalMoney == null && other.TotalMoney == null) || (this.TotalMoney?.Equals(other.TotalMoney) == true)) &&
                ((this.TenderedMoney == null && other.TenderedMoney == null) || (this.TenderedMoney?.Equals(other.TenderedMoney) == true)) &&
                ((this.TenderedAt == null && other.TenderedAt == null) || (this.TenderedAt?.Equals(other.TenderedAt) == true)) &&
                ((this.SettledAt == null && other.SettledAt == null) || (this.SettledAt?.Equals(other.SettledAt) == true)) &&
                ((this.ChangeBackMoney == null && other.ChangeBackMoney == null) || (this.ChangeBackMoney?.Equals(other.ChangeBackMoney) == true)) &&
                ((this.RefundedMoney == null && other.RefundedMoney == null) || (this.RefundedMoney?.Equals(other.RefundedMoney) == true)) &&
                ((this.IsExchange == null && other.IsExchange == null) || (this.IsExchange?.Equals(other.IsExchange) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1002014939;
            hashCode = HashCode.Combine(this.Id, this.Type, this.Name, this.EmployeeId, this.ReceiptUrl, this.CardBrand, this.PanSuffix);

            hashCode = HashCode.Combine(hashCode, this.EntryMethod, this.PaymentNote, this.TotalMoney, this.TenderedMoney, this.TenderedAt, this.SettledAt, this.ChangeBackMoney);

            hashCode = HashCode.Combine(hashCode, this.RefundedMoney, this.IsExchange);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type.ToString())}");
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name)}");
            toStringOutput.Add($"this.EmployeeId = {(this.EmployeeId == null ? "null" : this.EmployeeId)}");
            toStringOutput.Add($"this.ReceiptUrl = {(this.ReceiptUrl == null ? "null" : this.ReceiptUrl)}");
            toStringOutput.Add($"this.CardBrand = {(this.CardBrand == null ? "null" : this.CardBrand.ToString())}");
            toStringOutput.Add($"this.PanSuffix = {(this.PanSuffix == null ? "null" : this.PanSuffix)}");
            toStringOutput.Add($"this.EntryMethod = {(this.EntryMethod == null ? "null" : this.EntryMethod.ToString())}");
            toStringOutput.Add($"this.PaymentNote = {(this.PaymentNote == null ? "null" : this.PaymentNote)}");
            toStringOutput.Add($"this.TotalMoney = {(this.TotalMoney == null ? "null" : this.TotalMoney.ToString())}");
            toStringOutput.Add($"this.TenderedMoney = {(this.TenderedMoney == null ? "null" : this.TenderedMoney.ToString())}");
            toStringOutput.Add($"this.TenderedAt = {(this.TenderedAt == null ? "null" : this.TenderedAt)}");
            toStringOutput.Add($"this.SettledAt = {(this.SettledAt == null ? "null" : this.SettledAt)}");
            toStringOutput.Add($"this.ChangeBackMoney = {(this.ChangeBackMoney == null ? "null" : this.ChangeBackMoney.ToString())}");
            toStringOutput.Add($"this.RefundedMoney = {(this.RefundedMoney == null ? "null" : this.RefundedMoney.ToString())}");
            toStringOutput.Add($"this.IsExchange = {(this.IsExchange == null ? "null" : this.IsExchange.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(this.Id)
                .Type(this.Type)
                .Name(this.Name)
                .EmployeeId(this.EmployeeId)
                .ReceiptUrl(this.ReceiptUrl)
                .CardBrand(this.CardBrand)
                .PanSuffix(this.PanSuffix)
                .EntryMethod(this.EntryMethod)
                .PaymentNote(this.PaymentNote)
                .TotalMoney(this.TotalMoney)
                .TenderedMoney(this.TenderedMoney)
                .TenderedAt(this.TenderedAt)
                .SettledAt(this.SettledAt)
                .ChangeBackMoney(this.ChangeBackMoney)
                .RefundedMoney(this.RefundedMoney)
                .IsExchange(this.IsExchange);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "name", false },
                { "employee_id", false },
                { "receipt_url", false },
                { "pan_suffix", false },
                { "payment_note", false },
                { "tendered_at", false },
                { "settled_at", false },
                { "is_exchange", false },
            };

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
             /// Name.
             /// </summary>
             /// <param name="name"> name. </param>
             /// <returns> Builder. </returns>
            public Builder Name(string name)
            {
                shouldSerialize["name"] = true;
                this.name = name;
                return this;
            }

             /// <summary>
             /// EmployeeId.
             /// </summary>
             /// <param name="employeeId"> employeeId. </param>
             /// <returns> Builder. </returns>
            public Builder EmployeeId(string employeeId)
            {
                shouldSerialize["employee_id"] = true;
                this.employeeId = employeeId;
                return this;
            }

             /// <summary>
             /// ReceiptUrl.
             /// </summary>
             /// <param name="receiptUrl"> receiptUrl. </param>
             /// <returns> Builder. </returns>
            public Builder ReceiptUrl(string receiptUrl)
            {
                shouldSerialize["receipt_url"] = true;
                this.receiptUrl = receiptUrl;
                return this;
            }

             /// <summary>
             /// CardBrand.
             /// </summary>
             /// <param name="cardBrand"> cardBrand. </param>
             /// <returns> Builder. </returns>
            public Builder CardBrand(string cardBrand)
            {
                this.cardBrand = cardBrand;
                return this;
            }

             /// <summary>
             /// PanSuffix.
             /// </summary>
             /// <param name="panSuffix"> panSuffix. </param>
             /// <returns> Builder. </returns>
            public Builder PanSuffix(string panSuffix)
            {
                shouldSerialize["pan_suffix"] = true;
                this.panSuffix = panSuffix;
                return this;
            }

             /// <summary>
             /// EntryMethod.
             /// </summary>
             /// <param name="entryMethod"> entryMethod. </param>
             /// <returns> Builder. </returns>
            public Builder EntryMethod(string entryMethod)
            {
                this.entryMethod = entryMethod;
                return this;
            }

             /// <summary>
             /// PaymentNote.
             /// </summary>
             /// <param name="paymentNote"> paymentNote. </param>
             /// <returns> Builder. </returns>
            public Builder PaymentNote(string paymentNote)
            {
                shouldSerialize["payment_note"] = true;
                this.paymentNote = paymentNote;
                return this;
            }

             /// <summary>
             /// TotalMoney.
             /// </summary>
             /// <param name="totalMoney"> totalMoney. </param>
             /// <returns> Builder. </returns>
            public Builder TotalMoney(Models.V1Money totalMoney)
            {
                this.totalMoney = totalMoney;
                return this;
            }

             /// <summary>
             /// TenderedMoney.
             /// </summary>
             /// <param name="tenderedMoney"> tenderedMoney. </param>
             /// <returns> Builder. </returns>
            public Builder TenderedMoney(Models.V1Money tenderedMoney)
            {
                this.tenderedMoney = tenderedMoney;
                return this;
            }

             /// <summary>
             /// TenderedAt.
             /// </summary>
             /// <param name="tenderedAt"> tenderedAt. </param>
             /// <returns> Builder. </returns>
            public Builder TenderedAt(string tenderedAt)
            {
                shouldSerialize["tendered_at"] = true;
                this.tenderedAt = tenderedAt;
                return this;
            }

             /// <summary>
             /// SettledAt.
             /// </summary>
             /// <param name="settledAt"> settledAt. </param>
             /// <returns> Builder. </returns>
            public Builder SettledAt(string settledAt)
            {
                shouldSerialize["settled_at"] = true;
                this.settledAt = settledAt;
                return this;
            }

             /// <summary>
             /// ChangeBackMoney.
             /// </summary>
             /// <param name="changeBackMoney"> changeBackMoney. </param>
             /// <returns> Builder. </returns>
            public Builder ChangeBackMoney(Models.V1Money changeBackMoney)
            {
                this.changeBackMoney = changeBackMoney;
                return this;
            }

             /// <summary>
             /// RefundedMoney.
             /// </summary>
             /// <param name="refundedMoney"> refundedMoney. </param>
             /// <returns> Builder. </returns>
            public Builder RefundedMoney(Models.V1Money refundedMoney)
            {
                this.refundedMoney = refundedMoney;
                return this;
            }

             /// <summary>
             /// IsExchange.
             /// </summary>
             /// <param name="isExchange"> isExchange. </param>
             /// <returns> Builder. </returns>
            public Builder IsExchange(bool? isExchange)
            {
                shouldSerialize["is_exchange"] = true;
                this.isExchange = isExchange;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetName()
            {
                this.shouldSerialize["name"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetEmployeeId()
            {
                this.shouldSerialize["employee_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetReceiptUrl()
            {
                this.shouldSerialize["receipt_url"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetPanSuffix()
            {
                this.shouldSerialize["pan_suffix"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetPaymentNote()
            {
                this.shouldSerialize["payment_note"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetTenderedAt()
            {
                this.shouldSerialize["tendered_at"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetSettledAt()
            {
                this.shouldSerialize["settled_at"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetIsExchange()
            {
                this.shouldSerialize["is_exchange"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> V1Tender. </returns>
            public V1Tender Build()
            {
                return new V1Tender(shouldSerialize,
                    this.id,
                    this.type,
                    this.name,
                    this.employeeId,
                    this.receiptUrl,
                    this.cardBrand,
                    this.panSuffix,
                    this.entryMethod,
                    this.paymentNote,
                    this.totalMoney,
                    this.tenderedMoney,
                    this.tenderedAt,
                    this.settledAt,
                    this.changeBackMoney,
                    this.refundedMoney,
                    this.isExchange);
            }
        }
    }
}