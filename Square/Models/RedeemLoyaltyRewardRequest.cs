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
    public class RedeemLoyaltyRewardRequest 
    {
        public RedeemLoyaltyRewardRequest(string idempotencyKey,
            string locationId)
        {
            IdempotencyKey = idempotencyKey;
            LocationId = locationId;
        }

        /// <summary>
        /// A unique string that identifies this `RedeemLoyaltyReward` request. 
        /// Keys can be any valid string, but must be unique for every request.
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <summary>
        /// The ID of the [location](#type-Location) where the reward is redeemed.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(IdempotencyKey,
                LocationId);
            return builder;
        }

        public class Builder
        {
            private string idempotencyKey;
            private string locationId;

            public Builder(string idempotencyKey,
                string locationId)
            {
                this.idempotencyKey = idempotencyKey;
                this.locationId = locationId;
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

            public RedeemLoyaltyRewardRequest Build()
            {
                return new RedeemLoyaltyRewardRequest(idempotencyKey,
                    locationId);
            }
        }
    }
}