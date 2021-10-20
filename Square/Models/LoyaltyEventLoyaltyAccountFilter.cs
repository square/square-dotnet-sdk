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
    using Square.Utilities;

    /// <summary>
    /// LoyaltyEventLoyaltyAccountFilter.
    /// </summary>
    public class LoyaltyEventLoyaltyAccountFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoyaltyEventLoyaltyAccountFilter"/> class.
        /// </summary>
        /// <param name="loyaltyAccountId">loyalty_account_id.</param>
        public LoyaltyEventLoyaltyAccountFilter(
            string loyaltyAccountId)
        {
            this.LoyaltyAccountId = loyaltyAccountId;
        }

        /// <summary>
        /// The ID of the [loyalty account]($m/LoyaltyAccount) associated with loyalty events.
        /// </summary>
        [JsonProperty("loyalty_account_id")]
        public string LoyaltyAccountId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LoyaltyEventLoyaltyAccountFilter : ({string.Join(", ", toStringOutput)})";
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

            return obj is LoyaltyEventLoyaltyAccountFilter other &&
                ((this.LoyaltyAccountId == null && other.LoyaltyAccountId == null) || (this.LoyaltyAccountId?.Equals(other.LoyaltyAccountId) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1399145156;
            hashCode = HashCode.Combine(this.LoyaltyAccountId);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.LoyaltyAccountId = {(this.LoyaltyAccountId == null ? "null" : this.LoyaltyAccountId == string.Empty ? "" : this.LoyaltyAccountId)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.LoyaltyAccountId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string loyaltyAccountId;

            public Builder(
                string loyaltyAccountId)
            {
                this.loyaltyAccountId = loyaltyAccountId;
            }

             /// <summary>
             /// LoyaltyAccountId.
             /// </summary>
             /// <param name="loyaltyAccountId"> loyaltyAccountId. </param>
             /// <returns> Builder. </returns>
            public Builder LoyaltyAccountId(string loyaltyAccountId)
            {
                this.loyaltyAccountId = loyaltyAccountId;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> LoyaltyEventLoyaltyAccountFilter. </returns>
            public LoyaltyEventLoyaltyAccountFilter Build()
            {
                return new LoyaltyEventLoyaltyAccountFilter(
                    this.loyaltyAccountId);
            }
        }
    }
}