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
    /// BuyNowPayLaterDetails.
    /// </summary>
    public class BuyNowPayLaterDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BuyNowPayLaterDetails"/> class.
        /// </summary>
        /// <param name="brand">brand.</param>
        /// <param name="afterpayDetails">afterpay_details.</param>
        public BuyNowPayLaterDetails(
            string brand = null,
            Models.AfterpayDetails afterpayDetails = null)
        {
            this.Brand = brand;
            this.AfterpayDetails = afterpayDetails;
        }

        /// <summary>
        /// The brand used for the Buy Now Pay Later payment.
        /// The brand can be `AFTERPAY` or `UNKNOWN`.
        /// </summary>
        [JsonProperty("brand", NullValueHandling = NullValueHandling.Ignore)]
        public string Brand { get; }

        /// <summary>
        /// Additional details about Afterpay payments.
        /// </summary>
        [JsonProperty("afterpay_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.AfterpayDetails AfterpayDetails { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BuyNowPayLaterDetails : ({string.Join(", ", toStringOutput)})";
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

            return obj is BuyNowPayLaterDetails other &&
                ((this.Brand == null && other.Brand == null) || (this.Brand?.Equals(other.Brand) == true)) &&
                ((this.AfterpayDetails == null && other.AfterpayDetails == null) || (this.AfterpayDetails?.Equals(other.AfterpayDetails) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1354392029;
            hashCode = HashCode.Combine(this.Brand, this.AfterpayDetails);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Brand = {(this.Brand == null ? "null" : this.Brand == string.Empty ? "" : this.Brand)}");
            toStringOutput.Add($"this.AfterpayDetails = {(this.AfterpayDetails == null ? "null" : this.AfterpayDetails.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Brand(this.Brand)
                .AfterpayDetails(this.AfterpayDetails);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string brand;
            private Models.AfterpayDetails afterpayDetails;

             /// <summary>
             /// Brand.
             /// </summary>
             /// <param name="brand"> brand. </param>
             /// <returns> Builder. </returns>
            public Builder Brand(string brand)
            {
                this.brand = brand;
                return this;
            }

             /// <summary>
             /// AfterpayDetails.
             /// </summary>
             /// <param name="afterpayDetails"> afterpayDetails. </param>
             /// <returns> Builder. </returns>
            public Builder AfterpayDetails(Models.AfterpayDetails afterpayDetails)
            {
                this.afterpayDetails = afterpayDetails;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> BuyNowPayLaterDetails. </returns>
            public BuyNowPayLaterDetails Build()
            {
                return new BuyNowPayLaterDetails(
                    this.brand,
                    this.afterpayDetails);
            }
        }
    }
}