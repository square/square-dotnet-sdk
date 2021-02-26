
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
    public class LoyaltyEventLoyaltyAccountFilter 
    {
        public LoyaltyEventLoyaltyAccountFilter(string loyaltyAccountId)
        {
            LoyaltyAccountId = loyaltyAccountId;
        }

        /// <summary>
        /// The ID of the [loyalty account](#type-LoyaltyAccount) associated with loyalty events.
        /// </summary>
        [JsonProperty("loyalty_account_id")]
        public string LoyaltyAccountId { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LoyaltyEventLoyaltyAccountFilter : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"LoyaltyAccountId = {(LoyaltyAccountId == null ? "null" : LoyaltyAccountId == string.Empty ? "" : LoyaltyAccountId)}");
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

            return obj is LoyaltyEventLoyaltyAccountFilter other &&
                ((LoyaltyAccountId == null && other.LoyaltyAccountId == null) || (LoyaltyAccountId?.Equals(other.LoyaltyAccountId) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 1399145156;

            if (LoyaltyAccountId != null)
            {
               hashCode += LoyaltyAccountId.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(LoyaltyAccountId);
            return builder;
        }

        public class Builder
        {
            private string loyaltyAccountId;

            public Builder(string loyaltyAccountId)
            {
                this.loyaltyAccountId = loyaltyAccountId;
            }

            public Builder LoyaltyAccountId(string loyaltyAccountId)
            {
                this.loyaltyAccountId = loyaltyAccountId;
                return this;
            }

            public LoyaltyEventLoyaltyAccountFilter Build()
            {
                return new LoyaltyEventLoyaltyAccountFilter(loyaltyAccountId);
            }
        }
    }
}