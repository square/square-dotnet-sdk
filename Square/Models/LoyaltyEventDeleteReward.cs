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
    /// LoyaltyEventDeleteReward.
    /// </summary>
    public class LoyaltyEventDeleteReward
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoyaltyEventDeleteReward"/> class.
        /// </summary>
        /// <param name="loyaltyProgramId">loyalty_program_id.</param>
        /// <param name="points">points.</param>
        /// <param name="rewardId">reward_id.</param>
        public LoyaltyEventDeleteReward(
            string loyaltyProgramId,
            int points,
            string rewardId = null)
        {
            this.LoyaltyProgramId = loyaltyProgramId;
            this.RewardId = rewardId;
            this.Points = points;
        }

        /// <summary>
        /// The ID of the [loyalty program](entity:LoyaltyProgram).
        /// </summary>
        [JsonProperty("loyalty_program_id")]
        public string LoyaltyProgramId { get; }

        /// <summary>
        /// The ID of the deleted [loyalty reward](entity:LoyaltyReward).
        /// This field is returned only if the event source is `LOYALTY_API`.
        /// </summary>
        [JsonProperty("reward_id", NullValueHandling = NullValueHandling.Ignore)]
        public string RewardId { get; }

        /// <summary>
        /// The number of points returned to the loyalty account.
        /// </summary>
        [JsonProperty("points")]
        public int Points { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LoyaltyEventDeleteReward : ({string.Join(", ", toStringOutput)})";
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
            return obj is LoyaltyEventDeleteReward other &&                ((this.LoyaltyProgramId == null && other.LoyaltyProgramId == null) || (this.LoyaltyProgramId?.Equals(other.LoyaltyProgramId) == true)) &&
                ((this.RewardId == null && other.RewardId == null) || (this.RewardId?.Equals(other.RewardId) == true)) &&
                this.Points.Equals(other.Points);
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1128419050;
            hashCode = HashCode.Combine(this.LoyaltyProgramId, this.RewardId, this.Points);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.LoyaltyProgramId = {(this.LoyaltyProgramId == null ? "null" : this.LoyaltyProgramId)}");
            toStringOutput.Add($"this.RewardId = {(this.RewardId == null ? "null" : this.RewardId)}");
            toStringOutput.Add($"this.Points = {this.Points}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.LoyaltyProgramId,
                this.Points)
                .RewardId(this.RewardId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string loyaltyProgramId;
            private int points;
            private string rewardId;

            /// <summary>
            /// Initialize Builder for LoyaltyEventDeleteReward.
            /// </summary>
            /// <param name="loyaltyProgramId"> loyaltyProgramId. </param>
            /// <param name="points"> points. </param>
            public Builder(
                string loyaltyProgramId,
                int points)
            {
                this.loyaltyProgramId = loyaltyProgramId;
                this.points = points;
            }

             /// <summary>
             /// LoyaltyProgramId.
             /// </summary>
             /// <param name="loyaltyProgramId"> loyaltyProgramId. </param>
             /// <returns> Builder. </returns>
            public Builder LoyaltyProgramId(string loyaltyProgramId)
            {
                this.loyaltyProgramId = loyaltyProgramId;
                return this;
            }

             /// <summary>
             /// Points.
             /// </summary>
             /// <param name="points"> points. </param>
             /// <returns> Builder. </returns>
            public Builder Points(int points)
            {
                this.points = points;
                return this;
            }

             /// <summary>
             /// RewardId.
             /// </summary>
             /// <param name="rewardId"> rewardId. </param>
             /// <returns> Builder. </returns>
            public Builder RewardId(string rewardId)
            {
                this.rewardId = rewardId;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> LoyaltyEventDeleteReward. </returns>
            public LoyaltyEventDeleteReward Build()
            {
                return new LoyaltyEventDeleteReward(
                    this.loyaltyProgramId,
                    this.points,
                    this.rewardId);
            }
        }
    }
}