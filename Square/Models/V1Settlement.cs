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