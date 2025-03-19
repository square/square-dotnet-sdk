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
using Square.Legacy;
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// ChargeResponse.
    /// </summary>
    public class ChargeResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChargeResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="transaction">transaction.</param>
        public ChargeResponse(
            IList<Models.Error> errors = null,
            Models.Transaction transaction = null
        )
        {
            this.Errors = errors;
            this.Transaction = transaction;
        }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Represents a transaction processed with Square, either with the
        /// Connect API or with Square Point of Sale.
        /// The `tenders` field of this object lists all methods of payment used to pay in
        /// the transaction.
        /// </summary>
        [JsonProperty("transaction", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Transaction Transaction { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"ChargeResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is ChargeResponse other
                && (
                    this.Errors == null && other.Errors == null
                    || this.Errors?.Equals(other.Errors) == true
                )
                && (
                    this.Transaction == null && other.Transaction == null
                    || this.Transaction?.Equals(other.Transaction) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1244238675;
            hashCode = HashCode.Combine(hashCode, this.Errors, this.Transaction);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add(
                $"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}"
            );
            toStringOutput.Add(
                $"this.Transaction = {(this.Transaction == null ? "null" : this.Transaction.ToString())}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder().Errors(this.Errors).Transaction(this.Transaction);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private Models.Transaction transaction;

            /// <summary>
            /// Errors.
            /// </summary>
            /// <param name="errors"> errors. </param>
            /// <returns> Builder. </returns>
            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            /// <summary>
            /// Transaction.
            /// </summary>
            /// <param name="transaction"> transaction. </param>
            /// <returns> Builder. </returns>
            public Builder Transaction(Models.Transaction transaction)
            {
                this.transaction = transaction;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ChargeResponse. </returns>
            public ChargeResponse Build()
            {
                return new ChargeResponse(this.errors, this.transaction);
            }
        }
    }
}
