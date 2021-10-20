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
    /// AdjustLoyaltyPointsRequest.
    /// </summary>
    public class AdjustLoyaltyPointsRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdjustLoyaltyPointsRequest"/> class.
        /// </summary>
        /// <param name="idempotencyKey">idempotency_key.</param>
        /// <param name="adjustPoints">adjust_points.</param>
        public AdjustLoyaltyPointsRequest(
            string idempotencyKey,
            Models.LoyaltyEventAdjustPoints adjustPoints)
        {
            this.IdempotencyKey = idempotencyKey;
            this.AdjustPoints = adjustPoints;
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"AdjustLoyaltyPointsRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is AdjustLoyaltyPointsRequest other &&
                ((this.IdempotencyKey == null && other.IdempotencyKey == null) || (this.IdempotencyKey?.Equals(other.IdempotencyKey) == true)) &&
                ((this.AdjustPoints == null && other.AdjustPoints == null) || (this.AdjustPoints?.Equals(other.AdjustPoints) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -855879166;
            hashCode = HashCode.Combine(this.IdempotencyKey, this.AdjustPoints);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.IdempotencyKey = {(this.IdempotencyKey == null ? "null" : this.IdempotencyKey == string.Empty ? "" : this.IdempotencyKey)}");
            toStringOutput.Add($"this.AdjustPoints = {(this.AdjustPoints == null ? "null" : this.AdjustPoints.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.IdempotencyKey,
                this.AdjustPoints);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string idempotencyKey;
            private Models.LoyaltyEventAdjustPoints adjustPoints;

            public Builder(
                string idempotencyKey,
                Models.LoyaltyEventAdjustPoints adjustPoints)
            {
                this.idempotencyKey = idempotencyKey;
                this.adjustPoints = adjustPoints;
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
             /// AdjustPoints.
             /// </summary>
             /// <param name="adjustPoints"> adjustPoints. </param>
             /// <returns> Builder. </returns>
            public Builder AdjustPoints(Models.LoyaltyEventAdjustPoints adjustPoints)
            {
                this.adjustPoints = adjustPoints;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> AdjustLoyaltyPointsRequest. </returns>
            public AdjustLoyaltyPointsRequest Build()
            {
                return new AdjustLoyaltyPointsRequest(
                    this.idempotencyKey,
                    this.adjustPoints);
            }
        }
    }
}