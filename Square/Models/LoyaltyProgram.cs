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
    /// LoyaltyProgram.
    /// </summary>
    public class LoyaltyProgram
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoyaltyProgram"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="status">status.</param>
        /// <param name="rewardTiers">reward_tiers.</param>
        /// <param name="terminology">terminology.</param>
        /// <param name="locationIds">location_ids.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="updatedAt">updated_at.</param>
        /// <param name="accrualRules">accrual_rules.</param>
        /// <param name="expirationPolicy">expiration_policy.</param>
        public LoyaltyProgram(
            string id,
            string status,
            IList<Models.LoyaltyProgramRewardTier> rewardTiers,
            Models.LoyaltyProgramTerminology terminology,
            IList<string> locationIds,
            string createdAt,
            string updatedAt,
            IList<Models.LoyaltyProgramAccrualRule> accrualRules,
            Models.LoyaltyProgramExpirationPolicy expirationPolicy = null)
        {
            this.Id = id;
            this.Status = status;
            this.RewardTiers = rewardTiers;
            this.ExpirationPolicy = expirationPolicy;
            this.Terminology = terminology;
            this.LocationIds = locationIds;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
            this.AccrualRules = accrualRules;
        }

        /// <summary>
        /// The Square-assigned ID of the loyalty program. Updates to
        /// the loyalty program do not modify the identifier.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// Indicates whether the program is currently active.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; }

        /// <summary>
        /// The list of rewards for buyers, sorted by ascending points.
        /// </summary>
        [JsonProperty("reward_tiers")]
        public IList<Models.LoyaltyProgramRewardTier> RewardTiers { get; }

        /// <summary>
        /// Describes when the loyalty program expires.
        /// </summary>
        [JsonProperty("expiration_policy", NullValueHandling = NullValueHandling.Ignore)]
        public Models.LoyaltyProgramExpirationPolicy ExpirationPolicy { get; }

        /// <summary>
        /// Represents the naming used for loyalty points.
        /// </summary>
        [JsonProperty("terminology")]
        public Models.LoyaltyProgramTerminology Terminology { get; }

        /// <summary>
        /// The [locations]($m/Location) at which the program is active.
        /// </summary>
        [JsonProperty("location_ids")]
        public IList<string> LocationIds { get; }

        /// <summary>
        /// The timestamp when the program was created, in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; }

        /// <summary>
        /// The timestamp when the reward was last updated, in RFC 3339 format.
        /// </summary>
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; }

        /// <summary>
        /// Defines how buyers can earn loyalty points.
        /// </summary>
        [JsonProperty("accrual_rules")]
        public IList<Models.LoyaltyProgramAccrualRule> AccrualRules { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LoyaltyProgram : ({string.Join(", ", toStringOutput)})";
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

            return obj is LoyaltyProgram other &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true)) &&
                ((this.RewardTiers == null && other.RewardTiers == null) || (this.RewardTiers?.Equals(other.RewardTiers) == true)) &&
                ((this.ExpirationPolicy == null && other.ExpirationPolicy == null) || (this.ExpirationPolicy?.Equals(other.ExpirationPolicy) == true)) &&
                ((this.Terminology == null && other.Terminology == null) || (this.Terminology?.Equals(other.Terminology) == true)) &&
                ((this.LocationIds == null && other.LocationIds == null) || (this.LocationIds?.Equals(other.LocationIds) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((this.UpdatedAt == null && other.UpdatedAt == null) || (this.UpdatedAt?.Equals(other.UpdatedAt) == true)) &&
                ((this.AccrualRules == null && other.AccrualRules == null) || (this.AccrualRules?.Equals(other.AccrualRules) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 2031047851;
            hashCode = HashCode.Combine(this.Id, this.Status, this.RewardTiers, this.ExpirationPolicy, this.Terminology, this.LocationIds, this.CreatedAt);

            hashCode = HashCode.Combine(hashCode, this.UpdatedAt, this.AccrualRules);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status.ToString())}");
            toStringOutput.Add($"this.RewardTiers = {(this.RewardTiers == null ? "null" : $"[{string.Join(", ", this.RewardTiers)} ]")}");
            toStringOutput.Add($"this.ExpirationPolicy = {(this.ExpirationPolicy == null ? "null" : this.ExpirationPolicy.ToString())}");
            toStringOutput.Add($"this.Terminology = {(this.Terminology == null ? "null" : this.Terminology.ToString())}");
            toStringOutput.Add($"this.LocationIds = {(this.LocationIds == null ? "null" : $"[{string.Join(", ", this.LocationIds)} ]")}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt == string.Empty ? "" : this.CreatedAt)}");
            toStringOutput.Add($"this.UpdatedAt = {(this.UpdatedAt == null ? "null" : this.UpdatedAt == string.Empty ? "" : this.UpdatedAt)}");
            toStringOutput.Add($"this.AccrualRules = {(this.AccrualRules == null ? "null" : $"[{string.Join(", ", this.AccrualRules)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Id,
                this.Status,
                this.RewardTiers,
                this.Terminology,
                this.LocationIds,
                this.CreatedAt,
                this.UpdatedAt,
                this.AccrualRules)
                .ExpirationPolicy(this.ExpirationPolicy);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string id;
            private string status;
            private IList<Models.LoyaltyProgramRewardTier> rewardTiers;
            private Models.LoyaltyProgramTerminology terminology;
            private IList<string> locationIds;
            private string createdAt;
            private string updatedAt;
            private IList<Models.LoyaltyProgramAccrualRule> accrualRules;
            private Models.LoyaltyProgramExpirationPolicy expirationPolicy;

            public Builder(
                string id,
                string status,
                IList<Models.LoyaltyProgramRewardTier> rewardTiers,
                Models.LoyaltyProgramTerminology terminology,
                IList<string> locationIds,
                string createdAt,
                string updatedAt,
                IList<Models.LoyaltyProgramAccrualRule> accrualRules)
            {
                this.id = id;
                this.status = status;
                this.rewardTiers = rewardTiers;
                this.terminology = terminology;
                this.locationIds = locationIds;
                this.createdAt = createdAt;
                this.updatedAt = updatedAt;
                this.accrualRules = accrualRules;
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
             /// Status.
             /// </summary>
             /// <param name="status"> status. </param>
             /// <returns> Builder. </returns>
            public Builder Status(string status)
            {
                this.status = status;
                return this;
            }

             /// <summary>
             /// RewardTiers.
             /// </summary>
             /// <param name="rewardTiers"> rewardTiers. </param>
             /// <returns> Builder. </returns>
            public Builder RewardTiers(IList<Models.LoyaltyProgramRewardTier> rewardTiers)
            {
                this.rewardTiers = rewardTiers;
                return this;
            }

             /// <summary>
             /// Terminology.
             /// </summary>
             /// <param name="terminology"> terminology. </param>
             /// <returns> Builder. </returns>
            public Builder Terminology(Models.LoyaltyProgramTerminology terminology)
            {
                this.terminology = terminology;
                return this;
            }

             /// <summary>
             /// LocationIds.
             /// </summary>
             /// <param name="locationIds"> locationIds. </param>
             /// <returns> Builder. </returns>
            public Builder LocationIds(IList<string> locationIds)
            {
                this.locationIds = locationIds;
                return this;
            }

             /// <summary>
             /// CreatedAt.
             /// </summary>
             /// <param name="createdAt"> createdAt. </param>
             /// <returns> Builder. </returns>
            public Builder CreatedAt(string createdAt)
            {
                this.createdAt = createdAt;
                return this;
            }

             /// <summary>
             /// UpdatedAt.
             /// </summary>
             /// <param name="updatedAt"> updatedAt. </param>
             /// <returns> Builder. </returns>
            public Builder UpdatedAt(string updatedAt)
            {
                this.updatedAt = updatedAt;
                return this;
            }

             /// <summary>
             /// AccrualRules.
             /// </summary>
             /// <param name="accrualRules"> accrualRules. </param>
             /// <returns> Builder. </returns>
            public Builder AccrualRules(IList<Models.LoyaltyProgramAccrualRule> accrualRules)
            {
                this.accrualRules = accrualRules;
                return this;
            }

             /// <summary>
             /// ExpirationPolicy.
             /// </summary>
             /// <param name="expirationPolicy"> expirationPolicy. </param>
             /// <returns> Builder. </returns>
            public Builder ExpirationPolicy(Models.LoyaltyProgramExpirationPolicy expirationPolicy)
            {
                this.expirationPolicy = expirationPolicy;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> LoyaltyProgram. </returns>
            public LoyaltyProgram Build()
            {
                return new LoyaltyProgram(
                    this.id,
                    this.status,
                    this.rewardTiers,
                    this.terminology,
                    this.locationIds,
                    this.createdAt,
                    this.updatedAt,
                    this.accrualRules,
                    this.expirationPolicy);
            }
        }
    }
}