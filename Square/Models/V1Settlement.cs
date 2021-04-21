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
    using Square.Http.Client;
    using Square.Utilities;

    /// <summary>
    /// V1Settlement.
    /// </summary>
    public class V1Settlement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="V1Settlement"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="status">status.</param>
        /// <param name="totalMoney">total_money.</param>
        /// <param name="initiatedAt">initiated_at.</param>
        /// <param name="bankAccountId">bank_account_id.</param>
        /// <param name="entries">entries.</param>
        public V1Settlement(
            string id = null,
            string status = null,
            Models.V1Money totalMoney = null,
            string initiatedAt = null,
            string bankAccountId = null,
            IList<Models.V1SettlementEntry> entries = null)
        {
            this.Id = id;
            this.Status = status;
            this.TotalMoney = totalMoney;
            this.InitiatedAt = initiatedAt;
            this.BankAccountId = bankAccountId;
            this.Entries = entries;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// The settlement's unique identifier.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// Gets or sets Status.
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; }

        /// <summary>
        /// Gets or sets TotalMoney.
        /// </summary>
        [JsonProperty("total_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money TotalMoney { get; }

        /// <summary>
        /// The time when the settlement was submitted for deposit or withdrawal, in ISO 8601 format.
        /// </summary>
        [JsonProperty("initiated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string InitiatedAt { get; }

        /// <summary>
        /// The Square-issued unique identifier for the bank account associated with the settlement.
        /// </summary>
        [JsonProperty("bank_account_id", NullValueHandling = NullValueHandling.Ignore)]
        public string BankAccountId { get; }

        /// <summary>
        /// The entries included in this settlement.
        /// </summary>
        [JsonProperty("entries", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.V1SettlementEntry> Entries { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1Settlement : ({string.Join(", ", toStringOutput)})";
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

            return obj is V1Settlement other &&
                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true)) &&
                ((this.TotalMoney == null && other.TotalMoney == null) || (this.TotalMoney?.Equals(other.TotalMoney) == true)) &&
                ((this.InitiatedAt == null && other.InitiatedAt == null) || (this.InitiatedAt?.Equals(other.InitiatedAt) == true)) &&
                ((this.BankAccountId == null && other.BankAccountId == null) || (this.BankAccountId?.Equals(other.BankAccountId) == true)) &&
                ((this.Entries == null && other.Entries == null) || (this.Entries?.Equals(other.Entries) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 388412647;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }

            if (this.Id != null)
            {
               hashCode += this.Id.GetHashCode();
            }

            if (this.Status != null)
            {
               hashCode += this.Status.GetHashCode();
            }

            if (this.TotalMoney != null)
            {
               hashCode += this.TotalMoney.GetHashCode();
            }

            if (this.InitiatedAt != null)
            {
               hashCode += this.InitiatedAt.GetHashCode();
            }

            if (this.BankAccountId != null)
            {
               hashCode += this.BankAccountId.GetHashCode();
            }

            if (this.Entries != null)
            {
               hashCode += this.Entries.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status.ToString())}");
            toStringOutput.Add($"this.TotalMoney = {(this.TotalMoney == null ? "null" : this.TotalMoney.ToString())}");
            toStringOutput.Add($"this.InitiatedAt = {(this.InitiatedAt == null ? "null" : this.InitiatedAt == string.Empty ? "" : this.InitiatedAt)}");
            toStringOutput.Add($"this.BankAccountId = {(this.BankAccountId == null ? "null" : this.BankAccountId == string.Empty ? "" : this.BankAccountId)}");
            toStringOutput.Add($"this.Entries = {(this.Entries == null ? "null" : $"[{string.Join(", ", this.Entries)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(this.Id)
                .Status(this.Status)
                .TotalMoney(this.TotalMoney)
                .InitiatedAt(this.InitiatedAt)
                .BankAccountId(this.BankAccountId)
                .Entries(this.Entries);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string id;
            private string status;
            private Models.V1Money totalMoney;
            private string initiatedAt;
            private string bankAccountId;
            private IList<Models.V1SettlementEntry> entries;

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
             /// Status.
             /// </summary>
             /// <param name="status"> status. </param>
             /// <returns> Builder. </returns>
            public Builder Status(string status)
            {
                this.status = status;
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
             /// InitiatedAt.
             /// </summary>
             /// <param name="initiatedAt"> initiatedAt. </param>
             /// <returns> Builder. </returns>
            public Builder InitiatedAt(string initiatedAt)
            {
                this.initiatedAt = initiatedAt;
                return this;
            }

             /// <summary>
             /// BankAccountId.
             /// </summary>
             /// <param name="bankAccountId"> bankAccountId. </param>
             /// <returns> Builder. </returns>
            public Builder BankAccountId(string bankAccountId)
            {
                this.bankAccountId = bankAccountId;
                return this;
            }

             /// <summary>
             /// Entries.
             /// </summary>
             /// <param name="entries"> entries. </param>
             /// <returns> Builder. </returns>
            public Builder Entries(IList<Models.V1SettlementEntry> entries)
            {
                this.entries = entries;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> V1Settlement. </returns>
            public V1Settlement Build()
            {
                return new V1Settlement(
                    this.id,
                    this.status,
                    this.totalMoney,
                    this.initiatedAt,
                    this.bankAccountId,
                    this.entries);
            }
        }
    }
}