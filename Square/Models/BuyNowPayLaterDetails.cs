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
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="BuyNowPayLaterDetails"/> class.
        /// </summary>
        /// <param name="brand">brand.</param>
        /// <param name="afterpayDetails">afterpay_details.</param>
        /// <param name="clearpayDetails">clearpay_details.</param>
        public BuyNowPayLaterDetails(
            string brand = null,
            Models.AfterpayDetails afterpayDetails = null,
            Models.ClearpayDetails clearpayDetails = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "brand", false }
            };

            if (brand != null)
            {
                shouldSerialize["brand"] = true;
                this.Brand = brand;
            }

            this.AfterpayDetails = afterpayDetails;
            this.ClearpayDetails = clearpayDetails;
        }
        internal BuyNowPayLaterDetails(Dictionary<string, bool> shouldSerialize,
            string brand = null,
            Models.AfterpayDetails afterpayDetails = null,
            Models.ClearpayDetails clearpayDetails = null)
        {
            this.shouldSerialize = shouldSerialize;
            Brand = brand;
            AfterpayDetails = afterpayDetails;
            ClearpayDetails = clearpayDetails;
        }

        /// <summary>
        /// The brand used for the Buy Now Pay Later payment.
        /// The brand can be `AFTERPAY`, `CLEARPAY` or `UNKNOWN`.
        /// </summary>
        [JsonProperty("brand")]
        public string Brand { get; }

        /// <summary>
        /// Additional details about Afterpay payments.
        /// </summary>
        [JsonProperty("afterpay_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.AfterpayDetails AfterpayDetails { get; }

        /// <summary>
        /// Additional details about Clearpay payments.
        /// </summary>
        [JsonProperty("clearpay_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.ClearpayDetails ClearpayDetails { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BuyNowPayLaterDetails : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeBrand()
        {
            return this.shouldSerialize["brand"];
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
                ((this.AfterpayDetails == null && other.AfterpayDetails == null) || (this.AfterpayDetails?.Equals(other.AfterpayDetails) == true)) &&
                ((this.ClearpayDetails == null && other.ClearpayDetails == null) || (this.ClearpayDetails?.Equals(other.ClearpayDetails) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1757190860;
            hashCode = HashCode.Combine(this.Brand, this.AfterpayDetails, this.ClearpayDetails);

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
            toStringOutput.Add($"this.ClearpayDetails = {(this.ClearpayDetails == null ? "null" : this.ClearpayDetails.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Brand(this.Brand)
                .AfterpayDetails(this.AfterpayDetails)
                .ClearpayDetails(this.ClearpayDetails);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "brand", false },
            };

            private string brand;
            private Models.AfterpayDetails afterpayDetails;
            private Models.ClearpayDetails clearpayDetails;

             /// <summary>
             /// Brand.
             /// </summary>
             /// <param name="brand"> brand. </param>
             /// <returns> Builder. </returns>
            public Builder Brand(string brand)
            {
                shouldSerialize["brand"] = true;
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
             /// ClearpayDetails.
             /// </summary>
             /// <param name="clearpayDetails"> clearpayDetails. </param>
             /// <returns> Builder. </returns>
            public Builder ClearpayDetails(Models.ClearpayDetails clearpayDetails)
            {
                this.clearpayDetails = clearpayDetails;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetBrand()
            {
                this.shouldSerialize["brand"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> BuyNowPayLaterDetails. </returns>
            public BuyNowPayLaterDetails Build()
            {
                return new BuyNowPayLaterDetails(shouldSerialize,
                    this.brand,
                    this.afterpayDetails,
                    this.clearpayDetails);
            }
        }
    }
}