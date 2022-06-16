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
    /// PaymentOptions.
    /// </summary>
    public class PaymentOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentOptions"/> class.
        /// </summary>
        /// <param name="autocomplete">autocomplete.</param>
        /// <param name="delayDuration">delay_duration.</param>
        /// <param name="acceptPartialAuthorization">accept_partial_authorization.</param>
        public PaymentOptions(
            bool? autocomplete = null,
            string delayDuration = null,
            bool? acceptPartialAuthorization = null)
        {
            this.Autocomplete = autocomplete;
            this.DelayDuration = delayDuration;
            this.AcceptPartialAuthorization = acceptPartialAuthorization;
        }

        /// <summary>
        /// Indicates whether the `Payment` objects created from this `TerminalCheckout` are automatically
        /// `COMPLETED` or left in an `APPROVED` state for later modification.
        /// </summary>
        [JsonProperty("autocomplete", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Autocomplete { get; }

        /// <summary>
        /// The duration of time after the payment's creation when Square automatically cancels the
        /// payment. This automatic cancellation applies only to payments that do not reach a terminal state
        /// (COMPLETED, CANCELED, or FAILED) before the `delay_duration` time period.
        /// This parameter should be specified as a time duration, in RFC 3339 format, with a minimum value
        /// of 1 minute.
        /// Note: This feature is only supported for card payments. This parameter can only be set for a delayed
        /// capture payment (`autocomplete=false`).
        /// Default:
        /// - Card-present payments: "PT36H" (36 hours) from the creation time.
        /// - Card-not-present payments: "P7D" (7 days) from the creation time.
        /// </summary>
        [JsonProperty("delay_duration", NullValueHandling = NullValueHandling.Ignore)]
        public string DelayDuration { get; }

        /// <summary>
        /// If set to `true` and charging a Square Gift Card, a payment might be returned with
        /// `amount_money` equal to less than what was requested. For example, a request for $20 when charging
        /// a Square Gift Card with a balance of $5 results in an APPROVED payment of $5. You might choose
        /// to prompt the buyer for an additional payment to cover the remainder or cancel the Gift Card
        /// payment.
        /// This field cannot be `true` when `autocomplete = true`.
        /// This field cannot be `true` when an `order_id` isn't specified.
        /// For more information, see
        /// [Take Partial Payments](https://developer.squareup.com/docs/payments-api/take-payments/card-payments/partial-payments-with-gift-cards).
        /// Default: false
        /// </summary>
        [JsonProperty("accept_partial_authorization", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AcceptPartialAuthorization { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"PaymentOptions : ({string.Join(", ", toStringOutput)})";
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

            return obj is PaymentOptions other &&
                ((this.Autocomplete == null && other.Autocomplete == null) || (this.Autocomplete?.Equals(other.Autocomplete) == true)) &&
                ((this.DelayDuration == null && other.DelayDuration == null) || (this.DelayDuration?.Equals(other.DelayDuration) == true)) &&
                ((this.AcceptPartialAuthorization == null && other.AcceptPartialAuthorization == null) || (this.AcceptPartialAuthorization?.Equals(other.AcceptPartialAuthorization) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 530475117;
            hashCode = HashCode.Combine(this.Autocomplete, this.DelayDuration, this.AcceptPartialAuthorization);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Autocomplete = {(this.Autocomplete == null ? "null" : this.Autocomplete.ToString())}");
            toStringOutput.Add($"this.DelayDuration = {(this.DelayDuration == null ? "null" : this.DelayDuration == string.Empty ? "" : this.DelayDuration)}");
            toStringOutput.Add($"this.AcceptPartialAuthorization = {(this.AcceptPartialAuthorization == null ? "null" : this.AcceptPartialAuthorization.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Autocomplete(this.Autocomplete)
                .DelayDuration(this.DelayDuration)
                .AcceptPartialAuthorization(this.AcceptPartialAuthorization);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private bool? autocomplete;
            private string delayDuration;
            private bool? acceptPartialAuthorization;

             /// <summary>
             /// Autocomplete.
             /// </summary>
             /// <param name="autocomplete"> autocomplete. </param>
             /// <returns> Builder. </returns>
            public Builder Autocomplete(bool? autocomplete)
            {
                this.autocomplete = autocomplete;
                return this;
            }

             /// <summary>
             /// DelayDuration.
             /// </summary>
             /// <param name="delayDuration"> delayDuration. </param>
             /// <returns> Builder. </returns>
            public Builder DelayDuration(string delayDuration)
            {
                this.delayDuration = delayDuration;
                return this;
            }

             /// <summary>
             /// AcceptPartialAuthorization.
             /// </summary>
             /// <param name="acceptPartialAuthorization"> acceptPartialAuthorization. </param>
             /// <returns> Builder. </returns>
            public Builder AcceptPartialAuthorization(bool? acceptPartialAuthorization)
            {
                this.acceptPartialAuthorization = acceptPartialAuthorization;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> PaymentOptions. </returns>
            public PaymentOptions Build()
            {
                return new PaymentOptions(
                    this.autocomplete,
                    this.delayDuration,
                    this.acceptPartialAuthorization);
            }
        }
    }
}