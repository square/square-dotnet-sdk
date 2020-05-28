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
    public class AdjustLoyaltyPointsRequest 
    {
        public AdjustLoyaltyPointsRequest(string idempotencyKey,
            Models.LoyaltyEventAdjustPoints adjustPoints)
        {
            IdempotencyKey = idempotencyKey;
            AdjustPoints = adjustPoints;
        }

        /// <summary>
        /// A unique string that identifies this `AdjustLoyaltyPoints` request. 
        /// Keys can be any valid string, but must be unique for every request.
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <summary>
        /// Provides metadata when the event `type` is `ADJUST_POINTS`.
        /// </summary>
        [JsonProperty("adjust_points")]
        public Models.LoyaltyEventAdjustPoints AdjustPoints { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(IdempotencyKey,
                AdjustPoints);
            return builder;
        }

        public class Builder
        {
            private string idempotencyKey;
            private Models.LoyaltyEventAdjustPoints adjustPoints;

            public Builder(string idempotencyKey,
                Models.LoyaltyEventAdjustPoints adjustPoints)
            {
                this.idempotencyKey = idempotencyKey;
                this.adjustPoints = adjustPoints;
            }
            public Builder IdempotencyKey(string value)
            {
                idempotencyKey = value;
                return this;
            }

            public Builder AdjustPoints(Models.LoyaltyEventAdjustPoints value)
            {
                adjustPoints = value;
                return this;
            }

            public AdjustLoyaltyPointsRequest Build()
            {
                return new AdjustLoyaltyPointsRequest(idempotencyKey,
                    adjustPoints);
            }
        }
    }
}