
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
        /// The ID of the account used to fund the payment.
        /// </summary>
        [JsonProperty("account_id", NullValueHandling = NullValueHandling.Ignore)]
        public string AccountId { get; }

        /// <summary>
        /// The balance payment’s current state. The state can be COMPLETED or FAILED.
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BalancePaymentDetails : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"AccountId = {(AccountId == null ? "null" : AccountId == string.Empty ? "" : AccountId)}");
            toStringOutput.Add($"Status = {(Status == null ? "null" : Status == string.Empty ? "" : Status)}");
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

            return obj is BalancePaymentDetails other &&
                ((AccountId == null && other.AccountId == null) || (AccountId?.Equals(other.AccountId) == true)) &&
                ((Status == null && other.Status == null) || (Status?.Equals(other.Status) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1939833591;

            if (AccountId != null)
            {
               hashCode += AccountId.GetHashCode();
            }

            if (Status != null)
            {
               hashCode += Status.GetHashCode();
            }

            return hashCode;
        }

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



            public Builder AccountId(string accountId)
            {
                this.accountId = accountId;
                return this;
            }

            public Builder Status(string status)
            {
                this.status = status;
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