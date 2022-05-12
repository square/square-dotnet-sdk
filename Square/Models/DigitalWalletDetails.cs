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
    /// DigitalWalletDetails.
    /// </summary>
    public class DigitalWalletDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DigitalWalletDetails"/> class.
        /// </summary>
        /// <param name="status">status.</param>
        /// <param name="brand">brand.</param>
        /// <param name="cashAppDetails">cash_app_details.</param>
        public DigitalWalletDetails(
            string status = null,
            string brand = null,
            Models.CashAppDetails cashAppDetails = null)
        {
            this.Status = status;
            this.Brand = brand;
            this.CashAppDetails = cashAppDetails;
        }

        /// <summary>
        /// The status of the `WALLET` payment. The status can be `AUTHORIZED`, `CAPTURED`, `VOIDED`, or
        /// `FAILED`.
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; }

        /// <summary>
        /// The brand used for the `WALLET` payment. The brand can be `CASH_APP` or `UNKNOWN`.
        /// </summary>
        [JsonProperty("brand", NullValueHandling = NullValueHandling.Ignore)]
        public string Brand { get; }

        /// <summary>
        /// Additional details about `WALLET` type payments with the `brand` of `CASH_APP`.
        /// </summary>
        [JsonProperty("cash_app_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CashAppDetails CashAppDetails { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"DigitalWalletDetails : ({string.Join(", ", toStringOutput)})";
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

            return obj is DigitalWalletDetails other &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true)) &&
                ((this.Brand == null && other.Brand == null) || (this.Brand?.Equals(other.Brand) == true)) &&
                ((this.CashAppDetails == null && other.CashAppDetails == null) || (this.CashAppDetails?.Equals(other.CashAppDetails) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1321495610;
            hashCode = HashCode.Combine(this.Status, this.Brand, this.CashAppDetails);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status == string.Empty ? "" : this.Status)}");
            toStringOutput.Add($"this.Brand = {(this.Brand == null ? "null" : this.Brand == string.Empty ? "" : this.Brand)}");
            toStringOutput.Add($"this.CashAppDetails = {(this.CashAppDetails == null ? "null" : this.CashAppDetails.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Status(this.Status)
                .Brand(this.Brand)
                .CashAppDetails(this.CashAppDetails);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string status;
            private string brand;
            private Models.CashAppDetails cashAppDetails;

             /// <summary>
             /// Status.
             /// </summary>
             /// <param name="status"> status. </param>
             /// <returns> Builder. </returns>
            public Builder Status(string status)
            {
                this.status = status;
                return this;
            }

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
             /// CashAppDetails.
             /// </summary>
             /// <param name="cashAppDetails"> cashAppDetails. </param>
             /// <returns> Builder. </returns>
            public Builder CashAppDetails(Models.CashAppDetails cashAppDetails)
            {
                this.cashAppDetails = cashAppDetails;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> DigitalWalletDetails. </returns>
            public DigitalWalletDetails Build()
            {
                return new DigitalWalletDetails(
                    this.status,
                    this.brand,
                    this.cashAppDetails);
            }
        }
    }
}