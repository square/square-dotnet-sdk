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
    /// ACHDetails.
    /// </summary>
    public class ACHDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ACHDetails"/> class.
        /// </summary>
        /// <param name="routingNumber">routing_number.</param>
        /// <param name="accountNumberSuffix">account_number_suffix.</param>
        /// <param name="accountType">account_type.</param>
        public ACHDetails(
            string routingNumber = null,
            string accountNumberSuffix = null,
            string accountType = null)
        {
            this.RoutingNumber = routingNumber;
            this.AccountNumberSuffix = accountNumberSuffix;
            this.AccountType = accountType;
        }

        /// <summary>
        /// The routing number for the bank account.
        /// </summary>
        [JsonProperty("routing_number", NullValueHandling = NullValueHandling.Ignore)]
        public string RoutingNumber { get; }

        /// <summary>
        /// The last few digits of the bank account number.
        /// </summary>
        [JsonProperty("account_number_suffix", NullValueHandling = NullValueHandling.Ignore)]
        public string AccountNumberSuffix { get; }

        /// <summary>
        /// The type of the bank account performing the transfer. The account type can be `CHECKING`,
        /// `SAVINGS`, or `UNKNOWN`.
        /// </summary>
        [JsonProperty("account_type", NullValueHandling = NullValueHandling.Ignore)]
        public string AccountType { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ACHDetails : ({string.Join(", ", toStringOutput)})";
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

            return obj is ACHDetails other &&
                ((this.RoutingNumber == null && other.RoutingNumber == null) || (this.RoutingNumber?.Equals(other.RoutingNumber) == true)) &&
                ((this.AccountNumberSuffix == null && other.AccountNumberSuffix == null) || (this.AccountNumberSuffix?.Equals(other.AccountNumberSuffix) == true)) &&
                ((this.AccountType == null && other.AccountType == null) || (this.AccountType?.Equals(other.AccountType) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1480381198;
            hashCode = HashCode.Combine(this.RoutingNumber, this.AccountNumberSuffix, this.AccountType);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.RoutingNumber = {(this.RoutingNumber == null ? "null" : this.RoutingNumber == string.Empty ? "" : this.RoutingNumber)}");
            toStringOutput.Add($"this.AccountNumberSuffix = {(this.AccountNumberSuffix == null ? "null" : this.AccountNumberSuffix == string.Empty ? "" : this.AccountNumberSuffix)}");
            toStringOutput.Add($"this.AccountType = {(this.AccountType == null ? "null" : this.AccountType == string.Empty ? "" : this.AccountType)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .RoutingNumber(this.RoutingNumber)
                .AccountNumberSuffix(this.AccountNumberSuffix)
                .AccountType(this.AccountType);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string routingNumber;
            private string accountNumberSuffix;
            private string accountType;

             /// <summary>
             /// RoutingNumber.
             /// </summary>
             /// <param name="routingNumber"> routingNumber. </param>
             /// <returns> Builder. </returns>
            public Builder RoutingNumber(string routingNumber)
            {
                this.routingNumber = routingNumber;
                return this;
            }

             /// <summary>
             /// AccountNumberSuffix.
             /// </summary>
             /// <param name="accountNumberSuffix"> accountNumberSuffix. </param>
             /// <returns> Builder. </returns>
            public Builder AccountNumberSuffix(string accountNumberSuffix)
            {
                this.accountNumberSuffix = accountNumberSuffix;
                return this;
            }

             /// <summary>
             /// AccountType.
             /// </summary>
             /// <param name="accountType"> accountType. </param>
             /// <returns> Builder. </returns>
            public Builder AccountType(string accountType)
            {
                this.accountType = accountType;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ACHDetails. </returns>
            public ACHDetails Build()
            {
                return new ACHDetails(
                    this.routingNumber,
                    this.accountNumberSuffix,
                    this.accountType);
            }
        }
    }
}