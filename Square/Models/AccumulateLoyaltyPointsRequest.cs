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
            public Builder AccumulatePoints(Models.LoyaltyEventAccumulatePoints value)
            {
                accumulatePoints = value;
                return this;
            }

            public Builder IdempotencyKey(string value)
            {
                idempotencyKey = value;
                return this;
            }

            public Builder LocationId(string value)
            {
                locationId = value;
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