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

namespace Square.Models
{
    /// <summary>
    /// ACHDetails.
    /// </summary>
    public class ACHDetails
    {
        private readonly Dictionary<string, bool> shouldSerialize;
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
            shouldSerialize = new Dictionary<string, bool>
            {
                { "routing_number", false },
                { "account_number_suffix", false },
                { "account_type", false }
            };

            if (routingNumber != null)
            {
                shouldSerialize["routing_number"] = true;
                this.RoutingNumber = routingNumber;
            }

            if (accountNumberSuffix != null)
            {
                shouldSerialize["account_number_suffix"] = true;
                this.AccountNumberSuffix = accountNumberSuffix;
            }

            if (accountType != null)
            {
                shouldSerialize["account_type"] = true;
                this.AccountType = accountType;
            }
        }

        internal ACHDetails(
            Dictionary<string, bool> shouldSerialize,
            string routingNumber = null,
            string accountNumberSuffix = null,
            string accountType = null)
        {
            this.shouldSerialize = shouldSerialize;
            RoutingNumber = routingNumber;
            AccountNumberSuffix = accountNumberSuffix;
            AccountType = accountType;
        }

        /// <summary>
        /// The routing number for the bank account.
        /// </summary>
        [JsonProperty("routing_number")]
        public string RoutingNumber { get; }

        /// <summary>
        /// The last few digits of the bank account number.
        /// </summary>
        [JsonProperty("account_number_suffix")]
        public string AccountNumberSuffix { get; }

        /// <summary>
        /// The type of the bank account performing the transfer. The account type can be `CHECKING`,
        /// `SAVINGS`, or `UNKNOWN`.
        /// </summary>
        [JsonProperty("account_type")]
        public string AccountType { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"ACHDetails : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeRoutingNumber()
        {
            return this.shouldSerialize["routing_number"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAccountNumberSuffix()
        {
            return this.shouldSerialize["account_number_suffix"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAccountType()
        {
            return this.shouldSerialize["account_type"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is ACHDetails other &&
                (this.RoutingNumber == null && other.RoutingNumber == null ||
                 this.RoutingNumber?.Equals(other.RoutingNumber) == true) &&
                (this.AccountNumberSuffix == null && other.AccountNumberSuffix == null ||
                 this.AccountNumberSuffix?.Equals(other.AccountNumberSuffix) == true) &&
                (this.AccountType == null && other.AccountType == null ||
                 this.AccountType?.Equals(other.AccountType) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1480381198;
            hashCode = HashCode.Combine(hashCode, this.RoutingNumber, this.AccountNumberSuffix, this.AccountType);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.RoutingNumber = {this.RoutingNumber ?? "null"}");
            toStringOutput.Add($"this.AccountNumberSuffix = {this.AccountNumberSuffix ?? "null"}");
            toStringOutput.Add($"this.AccountType = {this.AccountType ?? "null"}");
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
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "routing_number", false },
                { "account_number_suffix", false },
                { "account_type", false },
            };

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
                shouldSerialize["routing_number"] = true;
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
                shouldSerialize["account_number_suffix"] = true;
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
                shouldSerialize["account_type"] = true;
                this.accountType = accountType;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetRoutingNumber()
            {
                this.shouldSerialize["routing_number"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetAccountNumberSuffix()
            {
                this.shouldSerialize["account_number_suffix"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetAccountType()
            {
                this.shouldSerialize["account_type"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ACHDetails. </returns>
            public ACHDetails Build()
            {
                return new ACHDetails(
                    shouldSerialize,
                    this.routingNumber,
                    this.accountNumberSuffix,
                    this.accountType);
            }
        }
    }
}