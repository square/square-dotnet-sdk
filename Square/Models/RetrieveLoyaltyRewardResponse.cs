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
using Square.Http.Client;
using Square.Utilities;

namespace Square.Models
{
    /// <summary>
    /// RetrieveLoyaltyRewardResponse.
    /// </summary>
    public class RetrieveLoyaltyRewardResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RetrieveLoyaltyRewardResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="reward">reward.</param>
        public RetrieveLoyaltyRewardResponse(
            IList<Models.Error> errors = null,
            Models.LoyaltyReward reward = null)
        {
            this.Errors = errors;
            this.Reward = reward;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Represents a contract to redeem loyalty points for a [reward tier]($m/LoyaltyProgramRewardTier) discount. Loyalty rewards can be in an ISSUED, REDEEMED, or DELETED state.
        /// For more information, see [Manage loyalty rewards](https://developer.squareup.com/docs/loyalty-api/loyalty-rewards).
        /// </summary>
        [JsonProperty("reward", NullValueHandling = NullValueHandling.Ignore)]
        public Models.LoyaltyReward Reward { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"RetrieveLoyaltyRewardResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is RetrieveLoyaltyRewardResponse other && 
                ((this.Context == null && other.Context == null) 
                 || this.Context?.Equals(other.Context) == true) && 
                (this.Errors == null && other.Errors == null ||
                 this.Errors?.Equals(other.Errors) == true) &&
                (this.Reward == null && other.Reward == null ||
                 this.Reward?.Equals(other.Reward) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1832831396;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(hashCode, this.Errors, this.Reward);

            return hashCode;
        }

        internal RetrieveLoyaltyRewardResponse ContextSetter(HttpContext context)
        {
            this.Context = context;
            return this;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
            toStringOutput.Add($"this.Reward = {(this.Reward == null ? "null" : this.Reward.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .Reward(this.Reward);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private Models.LoyaltyReward reward;

             /// <summary>
             /// Errors.
             /// </summary>
             /// <param name="errors"> errors. </param>
             /// <returns> Builder. </returns>
            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
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
            /// Builds class object.
            /// </summary>
            /// <returns> RetrieveLoyaltyRewardResponse. </returns>
            public RetrieveLoyaltyRewardResponse Build()
            {
                return new RetrieveLoyaltyRewardResponse(
                    this.errors,
                    this.reward);
            }
        }
    }
}