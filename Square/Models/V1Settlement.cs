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
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// Getter for status
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; }

        /// <summary>
        /// Getter for total_money
        /// </summary>
        [JsonProperty("total_money")]
        public Models.V1Money TotalMoney { get; }

        /// <summary>
        /// The time when the settlement was submitted for deposit or withdrawal, in ISO 8601 format.
        /// </summary>
        [JsonProperty("initiated_at")]
        public string InitiatedAt { get; }

        /// <summary>
        /// The Square-issued unique identifier for the bank account associated with the settlement.
        /// </summary>
        [JsonProperty("bank_account_id")]
        public string BankAccountId { get; }

        /// <summary>
        /// The entries included in this settlement.
        /// </summary>
        [JsonProperty("entries")]
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
            private IList<Models.V1SettlementEntry> entries = new List<Models.V1SettlementEntry>();

            public Builder() { }
            public Builder Id(string value)
            {
                id = value;
                return this;
            }

            public Builder Status(string value)
            {
                status = value;
                return this;
            }

            public Builder TotalMoney(Models.V1Money value)
            {
                totalMoney = value;
                return this;
            }

            public Builder InitiatedAt(string value)
            {
                initiatedAt = value;
                return this;
            }

            public Builder BankAccountId(string value)
            {
                bankAccountId = value;
                return this;
            }

            public Builder Entries(IList<Models.V1SettlementEntry> value)
            {
                entries = value;
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