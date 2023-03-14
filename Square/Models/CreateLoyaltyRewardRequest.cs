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
    /// CreateLoyaltyRewardRequest.
    /// </summary>
    public class CreateLoyaltyRewardRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateLoyaltyRewardRequest"/> class.
        /// </summary>
        /// <param name="reward">reward.</param>
        /// <param name="idempotencyKey">idempotency_key.</param>
        public CreateLoyaltyRewardRequest(
            Models.LoyaltyReward reward,
            string idempotencyKey)
        {
            this.Reward = reward;
            this.IdempotencyKey = idempotencyKey;
        }

        /// <summary>
        /// Represents a contract to redeem loyalty points for a [reward tier]($m/LoyaltyProgramRewardTier) discount. Loyalty rewards can be in an ISSUED, REDEEMED, or DELETED state.
        /// For more information, see [Manage loyalty rewards](https://developer.squareup.com/docs/loyalty-api/loyalty-rewards).
        /// </summary>
        [JsonProperty("reward")]
        public Models.LoyaltyReward Reward { get; }

        /// <summary>
        /// A unique string that identifies this `CreateLoyaltyReward` request.
        /// Keys can be any valid string, but must be unique for every request.
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateLoyaltyRewardRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is CreateLoyaltyRewardRequest other &&
                ((this.Reward == null && other.Reward == null) || (this.Reward?.Equals(other.Reward) == true)) &&
                ((this.IdempotencyKey == null && other.IdempotencyKey == null) || (this.IdempotencyKey?.Equals(other.IdempotencyKey) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -767337134;
            hashCode = HashCode.Combine(this.Reward, this.IdempotencyKey);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Reward = {(this.Reward == null ? "null" : this.Reward.ToString())}");
            toStringOutput.Add($"this.IdempotencyKey = {(this.IdempotencyKey == null ? "null" : this.IdempotencyKey == string.Empty ? "" : this.IdempotencyKey)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Reward,
                this.IdempotencyKey);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.LoyaltyReward reward;
            private string idempotencyKey;

            public Builder(
                Models.LoyaltyReward reward,
                string idempotencyKey)
            {
                this.reward = reward;
                this.idempotencyKey = idempotencyKey;
            }

             /// <summary>
             /// Reward.
             /// </summary>
             /// <param name="reward"> reward. </param>
             /// <returns> Builder. </returns>
            public Builder Reward(Models.LoyaltyReward reward)
            {
                this.reward = reward;
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
            /// Builds class object.
            /// </summary>
            /// <returns> CreateLoyaltyRewardRequest. </returns>
            public CreateLoyaltyRewardRequest Build()
            {
                return new CreateLoyaltyRewardRequest(
                    this.reward,
                    this.idempotencyKey);
            }
        }
    }
}