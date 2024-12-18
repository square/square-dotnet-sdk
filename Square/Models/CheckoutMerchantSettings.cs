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
    /// CheckoutMerchantSettings.
    /// </summary>
    public class CheckoutMerchantSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckoutMerchantSettings"/> class.
        /// </summary>
        /// <param name="paymentMethods">payment_methods.</param>
        /// <param name="updatedAt">updated_at.</param>
        public CheckoutMerchantSettings(
            Models.CheckoutMerchantSettingsPaymentMethods paymentMethods = null,
            string updatedAt = null)
        {
            this.PaymentMethods = paymentMethods;
            this.UpdatedAt = updatedAt;
        }

        /// <summary>
        /// Gets or sets PaymentMethods.
        /// </summary>
        [JsonProperty("payment_methods", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CheckoutMerchantSettingsPaymentMethods PaymentMethods { get; }

        /// <summary>
        /// The timestamp when the settings were last updated, in RFC 3339 format.
        /// Examples for January 25th, 2020 6:25:34pm Pacific Standard Time:
        /// UTC: 2020-01-26T02:25:34Z
        /// Pacific Standard Time with UTC offset: 2020-01-25T18:25:34-08:00
        /// </summary>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAt { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"CheckoutMerchantSettings : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is CheckoutMerchantSettings other &&
                (this.PaymentMethods == null && other.PaymentMethods == null ||
                 this.PaymentMethods?.Equals(other.PaymentMethods) == true) &&
                (this.UpdatedAt == null && other.UpdatedAt == null ||
                 this.UpdatedAt?.Equals(other.UpdatedAt) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -395742093;
            hashCode = HashCode.Combine(hashCode, this.PaymentMethods, this.UpdatedAt);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.PaymentMethods = {(this.PaymentMethods == null ? "null" : this.PaymentMethods.ToString())}");
            toStringOutput.Add($"this.UpdatedAt = {this.UpdatedAt ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .PaymentMethods(this.PaymentMethods)
                .UpdatedAt(this.UpdatedAt);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.CheckoutMerchantSettingsPaymentMethods paymentMethods;
            private string updatedAt;

             /// <summary>
             /// PaymentMethods.
             /// </summary>
             /// <param name="paymentMethods"> paymentMethods. </param>
             /// <returns> Builder. </returns>
            public Builder PaymentMethods(Models.CheckoutMerchantSettingsPaymentMethods paymentMethods)
            {
                this.paymentMethods = paymentMethods;
                return this;
            }

             /// <summary>
             /// UpdatedAt.
             /// </summary>
             /// <param name="updatedAt"> updatedAt. </param>
             /// <returns> Builder. </returns>
            public Builder UpdatedAt(string updatedAt)
            {
                this.updatedAt = updatedAt;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CheckoutMerchantSettings. </returns>
            public CheckoutMerchantSettings Build()
            {
                return new CheckoutMerchantSettings(
                    this.paymentMethods,
                    this.updatedAt);
            }
        }
    }
}