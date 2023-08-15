namespace Square.Models
{
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

    /// <summary>
    /// SquareAccountDetails.
    /// </summary>
    public class SquareAccountDetails
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="SquareAccountDetails"/> class.
        /// </summary>
        /// <param name="paymentSourceToken">payment_source_token.</param>
        /// <param name="errors">errors.</param>
        public SquareAccountDetails(
            string paymentSourceToken = null,
            IList<Models.Error> errors = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "payment_source_token", false },
                { "errors", false }
            };

            if (paymentSourceToken != null)
            {
                shouldSerialize["payment_source_token"] = true;
                this.PaymentSourceToken = paymentSourceToken;
            }

            if (errors != null)
            {
                shouldSerialize["errors"] = true;
                this.Errors = errors;
            }

        }
        internal SquareAccountDetails(Dictionary<string, bool> shouldSerialize,
            string paymentSourceToken = null,
            IList<Models.Error> errors = null)
        {
            this.shouldSerialize = shouldSerialize;
            PaymentSourceToken = paymentSourceToken;
            Errors = errors;
        }

        /// <summary>
        /// Unique identifier for the payment source used for this payment.
        /// </summary>
        [JsonProperty("payment_source_token")]
        public string PaymentSourceToken { get; }

        /// <summary>
        /// Information about errors encountered during the request.
        /// </summary>
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SquareAccountDetails : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePaymentSourceToken()
        {
            return this.shouldSerialize["payment_source_token"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeErrors()
        {
            return this.shouldSerialize["errors"];
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
            return obj is SquareAccountDetails other &&                ((this.PaymentSourceToken == null && other.PaymentSourceToken == null) || (this.PaymentSourceToken?.Equals(other.PaymentSourceToken) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1977015291;
            hashCode = HashCode.Combine(this.PaymentSourceToken, this.Errors);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.PaymentSourceToken = {(this.PaymentSourceToken == null ? "null" : this.PaymentSourceToken)}");
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .PaymentSourceToken(this.PaymentSourceToken)
                .Errors(this.Errors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "payment_source_token", false },
                { "errors", false },
            };

            private string paymentSourceToken;
            private IList<Models.Error> errors;

             /// <summary>
             /// PaymentSourceToken.
             /// </summary>
             /// <param name="paymentSourceToken"> paymentSourceToken. </param>
             /// <returns> Builder. </returns>
            public Builder PaymentSourceToken(string paymentSourceToken)
            {
                shouldSerialize["payment_source_token"] = true;
                this.paymentSourceToken = paymentSourceToken;
                return this;
            }

             /// <summary>
             /// Errors.
             /// </summary>
             /// <param name="errors"> errors. </param>
             /// <returns> Builder. </returns>
            public Builder Errors(IList<Models.Error> errors)
            {
                shouldSerialize["errors"] = true;
                this.errors = errors;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetPaymentSourceToken()
            {
                this.shouldSerialize["payment_source_token"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetErrors()
            {
                this.shouldSerialize["errors"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> SquareAccountDetails. </returns>
            public SquareAccountDetails Build()
            {
                return new SquareAccountDetails(shouldSerialize,
                    this.paymentSourceToken,
                    this.errors);
            }
        }
    }
}