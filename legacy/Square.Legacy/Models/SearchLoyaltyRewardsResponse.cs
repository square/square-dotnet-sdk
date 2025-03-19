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
using Square.Legacy;
using Square.Legacy.Http.Client;
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// SearchLoyaltyRewardsResponse.
    /// </summary>
    public class SearchLoyaltyRewardsResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchLoyaltyRewardsResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="rewards">rewards.</param>
        /// <param name="cursor">cursor.</param>
        public SearchLoyaltyRewardsResponse(
            IList<Models.Error> errors = null,
            IList<Models.LoyaltyReward> rewards = null,
            string cursor = null
        )
        {
            this.Errors = errors;
            this.Rewards = rewards;
            this.Cursor = cursor;
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
        /// The loyalty rewards that satisfy the search criteria.
        /// These are returned in descending order by `updated_at`.
        /// </summary>
        [JsonProperty("rewards", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.LoyaltyReward> Rewards { get; }

        /// <summary>
        /// The pagination cursor to be used in a subsequent
        /// request. If empty, this is the final response.
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"SearchLoyaltyRewardsResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is SearchLoyaltyRewardsResponse other
                && (
                    (this.Context == null && other.Context == null)
                    || this.Context?.Equals(other.Context) == true
                )
                && (
                    this.Errors == null && other.Errors == null
                    || this.Errors?.Equals(other.Errors) == true
                )
                && (
                    this.Rewards == null && other.Rewards == null
                    || this.Rewards?.Equals(other.Rewards) == true
                )
                && (
                    this.Cursor == null && other.Cursor == null
                    || this.Cursor?.Equals(other.Cursor) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -527472052;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(hashCode, this.Errors, this.Rewards, this.Cursor);

            return hashCode;
        }

        internal SearchLoyaltyRewardsResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add(
                $"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}"
            );
            toStringOutput.Add(
                $"this.Rewards = {(this.Rewards == null ? "null" : $"[{string.Join(", ", this.Rewards)} ]")}"
            );
            toStringOutput.Add($"this.Cursor = {this.Cursor ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .Rewards(this.Rewards)
                .Cursor(this.Cursor);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private IList<Models.LoyaltyReward> rewards;
            private string cursor;

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
            /// Rewards.
            /// </summary>
            /// <param name="rewards"> rewards. </param>
            /// <returns> Builder. </returns>
            public Builder Rewards(IList<Models.LoyaltyReward> rewards)
            {
                this.rewards = rewards;
                return this;
            }

            /// <summary>
            /// Cursor.
            /// </summary>
            /// <param name="cursor"> cursor. </param>
            /// <returns> Builder. </returns>
            public Builder Cursor(string cursor)
            {
                this.cursor = cursor;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> SearchLoyaltyRewardsResponse. </returns>
            public SearchLoyaltyRewardsResponse Build()
            {
                return new SearchLoyaltyRewardsResponse(this.errors, this.rewards, this.cursor);
            }
        }
    }
}
