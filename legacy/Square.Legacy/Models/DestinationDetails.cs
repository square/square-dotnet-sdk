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
    /// DestinationDetails.
    /// </summary>
    public class DestinationDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DestinationDetails"/> class.
        /// </summary>
        /// <param name="cardDetails">card_details.</param>
        /// <param name="cashDetails">cash_details.</param>
        /// <param name="externalDetails">external_details.</param>
        public DestinationDetails(
            Models.DestinationDetailsCardRefundDetails cardDetails = null,
            Models.DestinationDetailsCashRefundDetails cashDetails = null,
            Models.DestinationDetailsExternalRefundDetails externalDetails = null
        )
        {
            this.CardDetails = cardDetails;
            this.CashDetails = cashDetails;
            this.ExternalDetails = externalDetails;
        }

        /// <summary>
        /// Gets or sets CardDetails.
        /// </summary>
        [JsonProperty("card_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.DestinationDetailsCardRefundDetails CardDetails { get; }

        /// <summary>
        /// Stores details about a cash refund. Contains only non-confidential information.
        /// </summary>
        [JsonProperty("cash_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.DestinationDetailsCashRefundDetails CashDetails { get; }

        /// <summary>
        /// Stores details about an external refund. Contains only non-confidential information.
        /// </summary>
        [JsonProperty("external_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.DestinationDetailsExternalRefundDetails ExternalDetails { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"DestinationDetails : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is DestinationDetails other
                && (
                    this.CardDetails == null && other.CardDetails == null
                    || this.CardDetails?.Equals(other.CardDetails) == true
                )
                && (
                    this.CashDetails == null && other.CashDetails == null
                    || this.CashDetails?.Equals(other.CashDetails) == true
                )
                && (
                    this.ExternalDetails == null && other.ExternalDetails == null
                    || this.ExternalDetails?.Equals(other.ExternalDetails) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -165986961;
            hashCode = HashCode.Combine(
                hashCode,
                this.CardDetails,
                this.CashDetails,
                this.ExternalDetails
            );

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add(
                $"this.CardDetails = {(this.CardDetails == null ? "null" : this.CardDetails.ToString())}"
            );
            toStringOutput.Add(
                $"this.CashDetails = {(this.CashDetails == null ? "null" : this.CashDetails.ToString())}"
            );
            toStringOutput.Add(
                $"this.ExternalDetails = {(this.ExternalDetails == null ? "null" : this.ExternalDetails.ToString())}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .CardDetails(this.CardDetails)
                .CashDetails(this.CashDetails)
                .ExternalDetails(this.ExternalDetails);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.DestinationDetailsCardRefundDetails cardDetails;
            private Models.DestinationDetailsCashRefundDetails cashDetails;
            private Models.DestinationDetailsExternalRefundDetails externalDetails;

            /// <summary>
            /// CardDetails.
            /// </summary>
            /// <param name="cardDetails"> cardDetails. </param>
            /// <returns> Builder. </returns>
            public Builder CardDetails(Models.DestinationDetailsCardRefundDetails cardDetails)
            {
                this.cardDetails = cardDetails;
                return this;
            }

            /// <summary>
            /// CashDetails.
            /// </summary>
            /// <param name="cashDetails"> cashDetails. </param>
            /// <returns> Builder. </returns>
            public Builder CashDetails(Models.DestinationDetailsCashRefundDetails cashDetails)
            {
                this.cashDetails = cashDetails;
                return this;
            }

            /// <summary>
            /// ExternalDetails.
            /// </summary>
            /// <param name="externalDetails"> externalDetails. </param>
            /// <returns> Builder. </returns>
            public Builder ExternalDetails(
                Models.DestinationDetailsExternalRefundDetails externalDetails
            )
            {
                this.externalDetails = externalDetails;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> DestinationDetails. </returns>
            public DestinationDetails Build()
            {
                return new DestinationDetails(
                    this.cardDetails,
                    this.cashDetails,
                    this.externalDetails
                );
            }
        }
    }
}
