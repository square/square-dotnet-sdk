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
    /// PaymentBalanceActivityTaxOnFeeDetail.
    /// </summary>
    public class PaymentBalanceActivityTaxOnFeeDetail
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentBalanceActivityTaxOnFeeDetail"/> class.
        /// </summary>
        /// <param name="paymentId">payment_id.</param>
        /// <param name="taxRateDescription">tax_rate_description.</param>
        public PaymentBalanceActivityTaxOnFeeDetail(
            string paymentId = null,
            string taxRateDescription = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "payment_id", false },
                { "tax_rate_description", false }
            };

            if (paymentId != null)
            {
                shouldSerialize["payment_id"] = true;
                this.PaymentId = paymentId;
            }

            if (taxRateDescription != null)
            {
                shouldSerialize["tax_rate_description"] = true;
                this.TaxRateDescription = taxRateDescription;
            }

        }
        internal PaymentBalanceActivityTaxOnFeeDetail(Dictionary<string, bool> shouldSerialize,
            string paymentId = null,
            string taxRateDescription = null)
        {
            this.shouldSerialize = shouldSerialize;
            PaymentId = paymentId;
            TaxRateDescription = taxRateDescription;
        }

        /// <summary>
        /// The ID of the payment associated with this activity.
        /// </summary>
        [JsonProperty("payment_id")]
        public string PaymentId { get; }

        /// <summary>
        /// The description of the tax rate being applied. For example: "GST", "HST".
        /// </summary>
        [JsonProperty("tax_rate_description")]
        public string TaxRateDescription { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"PaymentBalanceActivityTaxOnFeeDetail : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePaymentId()
        {
            return this.shouldSerialize["payment_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTaxRateDescription()
        {
            return this.shouldSerialize["tax_rate_description"];
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

            return obj is PaymentBalanceActivityTaxOnFeeDetail other &&
                ((this.PaymentId == null && other.PaymentId == null) || (this.PaymentId?.Equals(other.PaymentId) == true)) &&
                ((this.TaxRateDescription == null && other.TaxRateDescription == null) || (this.TaxRateDescription?.Equals(other.TaxRateDescription) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1979815303;
            hashCode = HashCode.Combine(this.PaymentId, this.TaxRateDescription);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.PaymentId = {(this.PaymentId == null ? "null" : this.PaymentId == string.Empty ? "" : this.PaymentId)}");
            toStringOutput.Add($"this.TaxRateDescription = {(this.TaxRateDescription == null ? "null" : this.TaxRateDescription == string.Empty ? "" : this.TaxRateDescription)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .PaymentId(this.PaymentId)
                .TaxRateDescription(this.TaxRateDescription);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "payment_id", false },
                { "tax_rate_description", false },
            };

            private string paymentId;
            private string taxRateDescription;

             /// <summary>
             /// PaymentId.
             /// </summary>
             /// <param name="paymentId"> paymentId. </param>
             /// <returns> Builder. </returns>
            public Builder PaymentId(string paymentId)
            {
                shouldSerialize["payment_id"] = true;
                this.paymentId = paymentId;
                return this;
            }

             /// <summary>
             /// TaxRateDescription.
             /// </summary>
             /// <param name="taxRateDescription"> taxRateDescription. </param>
             /// <returns> Builder. </returns>
            public Builder TaxRateDescription(string taxRateDescription)
            {
                shouldSerialize["tax_rate_description"] = true;
                this.taxRateDescription = taxRateDescription;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetPaymentId()
            {
                this.shouldSerialize["payment_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetTaxRateDescription()
            {
                this.shouldSerialize["tax_rate_description"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> PaymentBalanceActivityTaxOnFeeDetail. </returns>
            public PaymentBalanceActivityTaxOnFeeDetail Build()
            {
                return new PaymentBalanceActivityTaxOnFeeDetail(shouldSerialize,
                    this.paymentId,
                    this.taxRateDescription);
            }
        }
    }
}