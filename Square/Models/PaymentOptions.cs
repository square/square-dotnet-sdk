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
    /// PaymentOptions.
    /// </summary>
    public class PaymentOptions
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentOptions"/> class.
        /// </summary>
        /// <param name="autocomplete">autocomplete.</param>
        /// <param name="delayDuration">delay_duration.</param>
        /// <param name="acceptPartialAuthorization">accept_partial_authorization.</param>
        /// <param name="delayAction">delay_action.</param>
        public PaymentOptions(
            bool? autocomplete = null,
            string delayDuration = null,
            bool? acceptPartialAuthorization = null,
            string delayAction = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "autocomplete", false },
                { "delay_duration", false },
                { "accept_partial_authorization", false }
            };

            if (autocomplete != null)
            {
                shouldSerialize["autocomplete"] = true;
                this.Autocomplete = autocomplete;
            }

            if (delayDuration != null)
            {
                shouldSerialize["delay_duration"] = true;
                this.DelayDuration = delayDuration;
            }

            if (acceptPartialAuthorization != null)
            {
                shouldSerialize["accept_partial_authorization"] = true;
                this.AcceptPartialAuthorization = acceptPartialAuthorization;
            }

            this.DelayAction = delayAction;
        }
        internal PaymentOptions(Dictionary<string, bool> shouldSerialize,
            bool? autocomplete = null,
            string delayDuration = null,
            bool? acceptPartialAuthorization = null,
            string delayAction = null)
        {
            this.shouldSerialize = shouldSerialize;
            Autocomplete = autocomplete;
            DelayDuration = delayDuration;
            AcceptPartialAuthorization = acceptPartialAuthorization;
            DelayAction = delayAction;
        }

        /// <summary>
        /// Indicates whether the `Payment` objects created from this `TerminalCheckout` are automatically
        /// `COMPLETED` or left in an `APPROVED` state for later modification.
        /// </summary>
        [JsonProperty("autocomplete")]
        public bool? Autocomplete { get; }

        /// <summary>
        /// The duration of time after the payment's creation when Square automatically cancels the
        /// payment. This automatic cancellation applies only to payments that do not reach a terminal state
        /// (COMPLETED or CANCELED) before the `delay_duration` time period.
        /// This parameter should be specified as a time duration, in RFC 3339 format, with a minimum value
        /// of 1 minute.
        /// Note: This feature is only supported for card payments. This parameter can only be set for a delayed
        /// capture payment (`autocomplete=false`).
        /// Default:
        /// - Card-present payments: "PT36H" (36 hours) from the creation time.
        /// - Card-not-present payments: "P7D" (7 days) from the creation time.
        /// </summary>
        [JsonProperty("delay_duration")]
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
        [JsonProperty("accept_partial_authorization")]
        public bool? AcceptPartialAuthorization { get; }

        /// <summary>
        /// Describes the action to be applied to a delayed capture payment when the delay_duration
        /// has elapsed.
        /// </summary>
        [JsonProperty("delay_action", NullValueHandling = NullValueHandling.Ignore)]
        public string DelayAction { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"PaymentOptions : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAutocomplete()
        {
            return this.shouldSerialize["autocomplete"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDelayDuration()
        {
            return this.shouldSerialize["delay_duration"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAcceptPartialAuthorization()
        {
            return this.shouldSerialize["accept_partial_authorization"];
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
            return obj is PaymentOptions other &&                ((this.Autocomplete == null && other.Autocomplete == null) || (this.Autocomplete?.Equals(other.Autocomplete) == true)) &&
                ((this.DelayDuration == null && other.DelayDuration == null) || (this.DelayDuration?.Equals(other.DelayDuration) == true)) &&
                ((this.AcceptPartialAuthorization == null && other.AcceptPartialAuthorization == null) || (this.AcceptPartialAuthorization?.Equals(other.AcceptPartialAuthorization) == true)) &&
                ((this.DelayAction == null && other.DelayAction == null) || (this.DelayAction?.Equals(other.DelayAction) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 56745792;
            hashCode = HashCode.Combine(this.Autocomplete, this.DelayDuration, this.AcceptPartialAuthorization, this.DelayAction);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Autocomplete = {(this.Autocomplete == null ? "null" : this.Autocomplete.ToString())}");
            toStringOutput.Add($"this.DelayDuration = {(this.DelayDuration == null ? "null" : this.DelayDuration)}");
            toStringOutput.Add($"this.AcceptPartialAuthorization = {(this.AcceptPartialAuthorization == null ? "null" : this.AcceptPartialAuthorization.ToString())}");
            toStringOutput.Add($"this.DelayAction = {(this.DelayAction == null ? "null" : this.DelayAction.ToString())}");
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
                .AcceptPartialAuthorization(this.AcceptPartialAuthorization)
                .DelayAction(this.DelayAction);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "autocomplete", false },
                { "delay_duration", false },
                { "accept_partial_authorization", false },
            };

            private bool? autocomplete;
            private string delayDuration;
            private bool? acceptPartialAuthorization;
            private string delayAction;

             /// <summary>
             /// Autocomplete.
             /// </summary>
             /// <param name="autocomplete"> autocomplete. </param>
             /// <returns> Builder. </returns>
            public Builder Autocomplete(bool? autocomplete)
            {
                shouldSerialize["autocomplete"] = true;
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
                shouldSerialize["delay_duration"] = true;
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
                shouldSerialize["accept_partial_authorization"] = true;
                this.acceptPartialAuthorization = acceptPartialAuthorization;
                return this;
            }

             /// <summary>
             /// DelayAction.
             /// </summary>
             /// <param name="delayAction"> delayAction. </param>
             /// <returns> Builder. </returns>
            public Builder DelayAction(string delayAction)
            {
                this.delayAction = delayAction;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetAutocomplete()
            {
                this.shouldSerialize["autocomplete"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetDelayDuration()
            {
                this.shouldSerialize["delay_duration"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetAcceptPartialAuthorization()
            {
                this.shouldSerialize["accept_partial_authorization"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> PaymentOptions. </returns>
            public PaymentOptions Build()
            {
                return new PaymentOptions(shouldSerialize,
                    this.autocomplete,
                    this.delayDuration,
                    this.acceptPartialAuthorization,
                    this.delayAction);
            }
        }
    }
}