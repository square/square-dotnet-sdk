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
    /// OrderReward.
    /// </summary>
    public class OrderReward
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderReward"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="rewardTierId">reward_tier_id.</param>
        public OrderReward(
            string id,
            string rewardTierId)
        {
            this.Id = id;
            this.RewardTierId = rewardTierId;
        }

        /// <summary>
        /// The identifier of the reward.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// The identifier of the reward tier corresponding to this reward.
        /// </summary>
        [JsonProperty("reward_tier_id")]
        public string RewardTierId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"OrderReward : ({string.Join(", ", toStringOutput)})";
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

            return obj is OrderReward other &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.RewardTierId == null && other.RewardTierId == null) || (this.RewardTierId?.Equals(other.RewardTierId) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 2052630566;

            if (this.Id != null)
            {
               hashCode += this.Id.GetHashCode();
            }

            if (this.RewardTierId != null)
            {
               hashCode += this.RewardTierId.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.RewardTierId = {(this.RewardTierId == null ? "null" : this.RewardTierId == string.Empty ? "" : this.RewardTierId)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Id,
                this.RewardTierId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string id;
            private string rewardTierId;

            public Builder(
                string id,
                string rewardTierId)
            {
                this.id = id;
                this.rewardTierId = rewardTierId;
            }

             /// <summary>
             /// Id.
             /// </summary>
             /// <param name="id"> id. </param>
             /// <returns> Builder. </returns>
            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

             /// <summary>
             /// RewardTierId.
             /// </summary>
             /// <param name="rewardTierId"> rewardTierId. </param>
             /// <returns> Builder. </returns>
            public Builder RewardTierId(string rewardTierId)
            {
                this.rewardTierId = rewardTierId;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> OrderReward. </returns>
            public OrderReward Build()
            {
                return new OrderReward(
                    this.id,
                    this.rewardTierId);
            }
        }
    }
}