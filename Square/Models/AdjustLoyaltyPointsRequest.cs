
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"AdjustLoyaltyPointsRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"IdempotencyKey = {(IdempotencyKey == null ? "null" : IdempotencyKey == string.Empty ? "" : IdempotencyKey)}");
            toStringOutput.Add($"AdjustPoints = {(AdjustPoints == null ? "null" : AdjustPoints.ToString())}");
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

            return obj is AdjustLoyaltyPointsRequest other &&
                ((IdempotencyKey == null && other.IdempotencyKey == null) || (IdempotencyKey?.Equals(other.IdempotencyKey) == true)) &&
                ((AdjustPoints == null && other.AdjustPoints == null) || (AdjustPoints?.Equals(other.AdjustPoints) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -855879166;

            if (IdempotencyKey != null)
            {
               hashCode += IdempotencyKey.GetHashCode();
            }

            if (AdjustPoints != null)
            {
               hashCode += AdjustPoints.GetHashCode();
            }

            return hashCode;
        }

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

            public Builder IdempotencyKey(string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
                return this;
            }

            public Builder AdjustPoints(Models.LoyaltyEventAdjustPoints adjustPoints)
            {
                this.adjustPoints = adjustPoints;
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