
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square.Http.Client;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class V1Settlement 
    {
        public V1Settlement(string id = null,
            string status = null,
            Models.V1Money totalMoney = null,
            string initiatedAt = null,
            string bankAccountId = null,
            IList<Models.V1SettlementEntry> entries = null)
        {
            Id = id;
            Status = status;
            TotalMoney = totalMoney;
            InitiatedAt = initiatedAt;
            BankAccountId = bankAccountId;
            Entries = entries;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// The settlement's unique identifier.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// Getter for status
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; }

        /// <summary>
        /// Getter for total_money
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1Settlement : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Id = {(Id == null ? "null" : Id == string.Empty ? "" : Id)}");
            toStringOutput.Add($"Status = {(Status == null ? "null" : Status.ToString())}");
            toStringOutput.Add($"TotalMoney = {(TotalMoney == null ? "null" : TotalMoney.ToString())}");
            toStringOutput.Add($"InitiatedAt = {(InitiatedAt == null ? "null" : InitiatedAt == string.Empty ? "" : InitiatedAt)}");
            toStringOutput.Add($"BankAccountId = {(BankAccountId == null ? "null" : BankAccountId == string.Empty ? "" : BankAccountId)}");
            toStringOutput.Add($"Entries = {(Entries == null ? "null" : $"[{ string.Join(", ", Entries)} ]")}");
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

            return obj is V1Settlement other &&
                ((Context == null && other.Context == null) || (Context?.Equals(other.Context) == true)) &&
                ((Id == null && other.Id == null) || (Id?.Equals(other.Id) == true)) &&
                ((Status == null && other.Status == null) || (Status?.Equals(other.Status) == true)) &&
                ((TotalMoney == null && other.TotalMoney == null) || (TotalMoney?.Equals(other.TotalMoney) == true)) &&
                ((InitiatedAt == null && other.InitiatedAt == null) || (InitiatedAt?.Equals(other.InitiatedAt) == true)) &&
                ((BankAccountId == null && other.BankAccountId == null) || (BankAccountId?.Equals(other.BankAccountId) == true)) &&
                ((Entries == null && other.Entries == null) || (Entries?.Equals(other.Entries) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 388412647;

            if (Context != null)
            {
                hashCode += Context.GetHashCode();
            }

            if (Id != null)
            {
               hashCode += Id.GetHashCode();
            }

            if (Status != null)
            {
               hashCode += Status.GetHashCode();
            }

            if (TotalMoney != null)
            {
               hashCode += TotalMoney.GetHashCode();
            }

            if (InitiatedAt != null)
            {
               hashCode += InitiatedAt.GetHashCode();
            }

            if (BankAccountId != null)
            {
               hashCode += BankAccountId.GetHashCode();
            }

            if (Entries != null)
            {
               hashCode += Entries.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(Id)
                .Status(Status)
                .TotalMoney(TotalMoney)
                .InitiatedAt(InitiatedAt)
                .BankAccountId(BankAccountId)
                .Entries(Entries);
            return builder;
        }

        public class Builder
        {
            private string id;
            private string status;
            private Models.V1Money totalMoney;
            private string initiatedAt;
            private string bankAccountId;
            private IList<Models.V1SettlementEntry> entries;



            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

            public Builder Status(string status)
            {
                this.status = status;
                return this;
            }

            public Builder TotalMoney(Models.V1Money totalMoney)
            {
                this.totalMoney = totalMoney;
                return this;
            }

            public Builder InitiatedAt(string initiatedAt)
            {
                this.initiatedAt = initiatedAt;
                return this;
            }

            public Builder BankAccountId(string bankAccountId)
            {
                this.bankAccountId = bankAccountId;
                return this;
            }

            public Builder Entries(IList<Models.V1SettlementEntry> entries)
            {
                this.entries = entries;
                return this;
            }

            public V1Settlement Build()
            {
                return new V1Settlement(id,
                    status,
                    totalMoney,
                    initiatedAt,
                    bankAccountId,
                    entries);
            }
        }
    }
}