
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class AccumulateLoyaltyPointsRequest 
    {
        public AccumulateLoyaltyPointsRequest(Models.LoyaltyEventAccumulatePoints accumulatePoints,
            string idempotencyKey,
            string locationId)
        {
            AccumulatePoints = accumulatePoints;
            IdempotencyKey = idempotencyKey;
            LocationId = locationId;
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
        /// The [location](#type-Location) where the purchase was made.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"AccumulateLoyaltyPointsRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"AccumulatePoints = {(AccumulatePoints == null ? "null" : AccumulatePoints.ToString())}");
            toStringOutput.Add($"IdempotencyKey = {(IdempotencyKey == null ? "null" : IdempotencyKey == string.Empty ? "" : IdempotencyKey)}");
            toStringOutput.Add($"LocationId = {(LocationId == null ? "null" : LocationId == string.Empty ? "" : LocationId)}");
        }

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
                ((AccumulatePoints == null && other.AccumulatePoints == null) || (AccumulatePoints?.Equals(other.AccumulatePoints) == true)) &&
                ((IdempotencyKey == null && other.IdempotencyKey == null) || (IdempotencyKey?.Equals(other.IdempotencyKey) == true)) &&
                ((LocationId == null && other.LocationId == null) || (LocationId?.Equals(other.LocationId) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1421565193;

            if (AccumulatePoints != null)
            {
               hashCode += AccumulatePoints.GetHashCode();
            }

            if (IdempotencyKey != null)
            {
               hashCode += IdempotencyKey.GetHashCode();
            }

            if (LocationId != null)
            {
               hashCode += LocationId.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(AccumulatePoints,
                IdempotencyKey,
                LocationId);
            return builder;
        }

        public class Builder
        {
            private Models.LoyaltyEventAccumulatePoints accumulatePoints;
            private string idempotencyKey;
            private string locationId;

            public Builder(Models.LoyaltyEventAccumulatePoints accumulatePoints,
                string idempotencyKey,
                string locationId)
            {
                this.accumulatePoints = accumulatePoints;
                this.idempotencyKey = idempotencyKey;
                this.locationId = locationId;
            }

            public Builder AccumulatePoints(Models.LoyaltyEventAccumulatePoints accumulatePoints)
            {
                this.accumulatePoints = accumulatePoints;
                return this;
            }

            public Builder IdempotencyKey(string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
                return this;
            }

            public Builder LocationId(string locationId)
            {
                this.locationId = locationId;
                return this;
            }

            public AccumulateLoyaltyPointsRequest Build()
            {
                return new AccumulateLoyaltyPointsRequest(accumulatePoints,
                    idempotencyKey,
                    locationId);
            }
        }
    }
}