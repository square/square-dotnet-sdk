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
    /// AccumulateLoyaltyPointsRequest.
    /// </summary>
    public class AccumulateLoyaltyPointsRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccumulateLoyaltyPointsRequest"/> class.
        /// </summary>
        /// <param name="accumulatePoints">accumulate_points.</param>
        /// <param name="idempotencyKey">idempotency_key.</param>
        /// <param name="locationId">location_id.</param>
        public AccumulateLoyaltyPointsRequest(
            Models.LoyaltyEventAccumulatePoints accumulatePoints,
            string idempotencyKey,
            string locationId)
        {
            this.AccumulatePoints = accumulatePoints;
            this.IdempotencyKey = idempotencyKey;
            this.LocationId = locationId;
        }

        /// <summary>
        /// Provides metadata when the event `type` is `ACCUMULATE_POINTS`.
        /// </summary>
        [JsonProperty("accumulate_points")]
        public Models.LoyaltyEventAccumulatePoints AccumulatePoints { get; }

        /// <summary>
        /// A unique string that identifies the `AccumulateLoyaltyPoints` request.
        /// Keys can be any valid string but must be unique for every request.
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <summary>
        /// The [location]($m/Location) where the purchase was made.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"AccumulateLoyaltyPointsRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is AccumulateLoyaltyPointsRequest other &&
                ((this.AccumulatePoints == null && other.AccumulatePoints == null) || (this.AccumulatePoints?.Equals(other.AccumulatePoints) == true)) &&
                ((this.IdempotencyKey == null && other.IdempotencyKey == null) || (this.IdempotencyKey?.Equals(other.IdempotencyKey) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1421565193;
            hashCode = HashCode.Combine(this.AccumulatePoints, this.IdempotencyKey, this.LocationId);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.AccumulatePoints = {(this.AccumulatePoints == null ? "null" : this.AccumulatePoints.ToString())}");
            toStringOutput.Add($"this.IdempotencyKey = {(this.IdempotencyKey == null ? "null" : this.IdempotencyKey == string.Empty ? "" : this.IdempotencyKey)}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId == string.Empty ? "" : this.LocationId)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.AccumulatePoints,
                this.IdempotencyKey,
                this.LocationId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.LoyaltyEventAccumulatePoints accumulatePoints;
            private string idempotencyKey;
            private string locationId;

            public Builder(
                Models.LoyaltyEventAccumulatePoints accumulatePoints,
                string idempotencyKey,
                string locationId)
            {
                this.accumulatePoints = accumulatePoints;
                this.idempotencyKey = idempotencyKey;
                this.locationId = locationId;
            }

             /// <summary>
             /// AccumulatePoints.
             /// </summary>
             /// <param name="accumulatePoints"> accumulatePoints. </param>
             /// <returns> Builder. </returns>
            public Builder AccumulatePoints(Models.LoyaltyEventAccumulatePoints accumulatePoints)
            {
                this.accumulatePoints = accumulatePoints;
                return this;
            }

             /// <summary>
             /// IdempotencyKey.
             /// </summary>
             /// <param name="idempotencyKey"> idempotencyKey. </param>
             /// <returns> Builder. </returns>
            public Builder IdempotencyKey(string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
                return this;
            }

             /// <summary>
             /// LocationId.
             /// </summary>
             /// <param name="locationId"> locationId. </param>
             /// <returns> Builder. </returns>
            public Builder LocationId(string locationId)
            {
                this.locationId = locationId;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> AccumulateLoyaltyPointsRequest. </returns>
            public AccumulateLoyaltyPointsRequest Build()
            {
                return new AccumulateLoyaltyPointsRequest(
                    this.accumulatePoints,
                    this.idempotencyKey,
                    this.locationId);
            }
        }
    }
}