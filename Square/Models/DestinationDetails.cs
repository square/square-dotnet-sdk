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
    /// DestinationDetails.
    /// </summary>
    public class DestinationDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DestinationDetails"/> class.
        /// </summary>
        /// <param name="cardDetails">card_details.</param>
        public DestinationDetails(
            Models.DestinationDetailsCardRefundDetails cardDetails = null)
        {
            this.CardDetails = cardDetails;
        }

        /// <summary>
        /// Gets or sets CardDetails.
        /// </summary>
        [JsonProperty("card_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.DestinationDetailsCardRefundDetails CardDetails { get; }

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
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }
            return obj is DestinationDetails other &&                ((this.CardDetails == null && other.CardDetails == null) || (this.CardDetails?.Equals(other.CardDetails) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1174244865;
            hashCode = HashCode.Combine(this.CardDetails);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.CardDetails = {(this.CardDetails == null ? "null" : this.CardDetails.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .CardDetails(this.CardDetails);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.DestinationDetailsCardRefundDetails cardDetails;

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
            /// Builds class object.
            /// </summary>
            /// <returns> DestinationDetails. </returns>
            public DestinationDetails Build()
            {
                return new DestinationDetails(
                    this.cardDetails);
            }
        }
    }
}