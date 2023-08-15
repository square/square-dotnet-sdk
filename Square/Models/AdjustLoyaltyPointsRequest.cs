namespace Square.Models
{
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
    using Square;
    using Square.Utilities;

    /// <summary>
    /// AdjustLoyaltyPointsRequest.
    /// </summary>
    public class AdjustLoyaltyPointsRequest
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="AdjustLoyaltyPointsRequest"/> class.
        /// </summary>
        /// <param name="idempotencyKey">idempotency_key.</param>
        /// <param name="adjustPoints">adjust_points.</param>
        /// <param name="allowNegativeBalance">allow_negative_balance.</param>
        public AdjustLoyaltyPointsRequest(
            string idempotencyKey,
            Models.LoyaltyEventAdjustPoints adjustPoints,
            bool? allowNegativeBalance = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "allow_negative_balance", false }
            };

            this.IdempotencyKey = idempotencyKey;
            this.AdjustPoints = adjustPoints;
            if (allowNegativeBalance != null)
            {
                shouldSerialize["allow_negative_balance"] = true;
                this.AllowNegativeBalance = allowNegativeBalance;
            }

        }
        internal AdjustLoyaltyPointsRequest(Dictionary<string, bool> shouldSerialize,
            string idempotencyKey,
            Models.LoyaltyEventAdjustPoints adjustPoints,
            bool? allowNegativeBalance = null)
        {
            this.shouldSerialize = shouldSerialize;
            IdempotencyKey = idempotencyKey;
            AdjustPoints = adjustPoints;
            AllowNegativeBalance = allowNegativeBalance;
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

        /// <summary>
        /// Indicates whether to allow a negative adjustment to result in a negative balance. If `true`, a negative
        /// balance is allowed when subtracting points. If `false`, Square returns a `BAD_REQUEST` error when subtracting
        /// the specified number of points would result in a negative balance. The default value is `false`.
        /// </summary>
        [JsonProperty("allow_negative_balance")]
        public bool? AllowNegativeBalance { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"AdjustLoyaltyPointsRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAllowNegativeBalance()
        {
            return this.shouldSerialize["allow_negative_balance"];
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
            return obj is AdjustLoyaltyPointsRequest other &&                ((this.IdempotencyKey == null && other.IdempotencyKey == null) || (this.IdempotencyKey?.Equals(other.IdempotencyKey) == true)) &&
                ((this.AdjustPoints == null && other.AdjustPoints == null) || (this.AdjustPoints?.Equals(other.AdjustPoints) == true)) &&
                ((this.AllowNegativeBalance == null && other.AllowNegativeBalance == null) || (this.AllowNegativeBalance?.Equals(other.AllowNegativeBalance) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 134703595;
            hashCode = HashCode.Combine(this.IdempotencyKey, this.AdjustPoints, this.AllowNegativeBalance);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.IdempotencyKey = {(this.IdempotencyKey == null ? "null" : this.IdempotencyKey)}");
            toStringOutput.Add($"this.AdjustPoints = {(this.AdjustPoints == null ? "null" : this.AdjustPoints.ToString())}");
            toStringOutput.Add($"this.AllowNegativeBalance = {(this.AllowNegativeBalance == null ? "null" : this.AllowNegativeBalance.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.IdempotencyKey,
                this.AdjustPoints)
                .AllowNegativeBalance(this.AllowNegativeBalance);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "allow_negative_balance", false },
            };

            private string idempotencyKey;
            private Models.LoyaltyEventAdjustPoints adjustPoints;
            private bool? allowNegativeBalance;

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
             /// AllowNegativeBalance.
             /// </summary>
             /// <param name="allowNegativeBalance"> allowNegativeBalance. </param>
             /// <returns> Builder. </returns>
            public Builder AllowNegativeBalance(bool? allowNegativeBalance)
            {
                shouldSerialize["allow_negative_balance"] = true;
                this.allowNegativeBalance = allowNegativeBalance;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetAllowNegativeBalance()
            {
                this.shouldSerialize["allow_negative_balance"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> AdjustLoyaltyPointsRequest. </returns>
            public AdjustLoyaltyPointsRequest Build()
            {
                return new AdjustLoyaltyPointsRequest(shouldSerialize,
                    this.idempotencyKey,
                    this.adjustPoints,
                    this.allowNegativeBalance);
            }
        }
    }
}