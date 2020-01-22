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
    public class BalancePaymentDetails 
    {
        public BalancePaymentDetails(string accountId = null,
            string status = null)
        {
            AccountId = accountId;
            Status = status;
        }

        /// <summary>
        /// ID for the account used to fund the payment.
        /// </summary>
        [JsonProperty("account_id")]
        public string AccountId { get; }

        /// <summary>
        /// The balance payment’s current state. Can be `COMPLETED` or `FAILED`.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .AccountId(AccountId)
                .Status(Status);
            return builder;
        }

        public class Builder
        {
            private string accountId;
            private string status;

            public Builder() { }
            public Builder AccountId(string value)
            {
                accountId = value;
                return this;
            }

            public Builder Status(string value)
            {
                status = value;
                return this;
            }

            public BalancePaymentDetails Build()
            {
                return new BalancePaymentDetails(accountId,
                    status);
            }
        }
    }
}