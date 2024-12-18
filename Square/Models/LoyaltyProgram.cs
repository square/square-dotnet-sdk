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

namespace Square.Models
{
    /// <summary>
    /// LoyaltyProgram.
    /// </summary>
    public class LoyaltyProgram
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="LoyaltyProgram"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="status">status.</param>
        /// <param name="rewardTiers">reward_tiers.</param>
        /// <param name="expirationPolicy">expiration_policy.</param>
        /// <param name="terminology">terminology.</param>
        /// <param name="locationIds">location_ids.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="updatedAt">updated_at.</param>
        /// <param name="accrualRules">accrual_rules.</param>
        public LoyaltyProgram(
            string id = null,
            string status = null,
            IList<Models.LoyaltyProgramRewardTier> rewardTiers = null,
            Models.LoyaltyProgramExpirationPolicy expirationPolicy = null,
            Models.LoyaltyProgramTerminology terminology = null,
            IList<string> locationIds = null,
            string createdAt = null,
            string updatedAt = null,
            IList<Models.LoyaltyProgramAccrualRule> accrualRules = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "reward_tiers", false },
                { "location_ids", false },
                { "accrual_rules", false }
            };
            this.Id = id;
            this.Status = status;

            if (rewardTiers != null)
            {
                shouldSerialize["reward_tiers"] = true;
                this.RewardTiers = rewardTiers;
            }
            this.ExpirationPolicy = expirationPolicy;
            this.Terminology = terminology;

            if (locationIds != null)
            {
                shouldSerialize["location_ids"] = true;
                this.LocationIds = locationIds;
            }
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;

            if (accrualRules != null)
            {
                shouldSerialize["accrual_rules"] = true;
                this.AccrualRules = accrualRules;
            }
        }

        internal LoyaltyProgram(
            Dictionary<string, bool> shouldSerialize,
            string id = null,
            string status = null,
            IList<Models.LoyaltyProgramRewardTier> rewardTiers = null,
            Models.LoyaltyProgramExpirationPolicy expirationPolicy = null,
            Models.LoyaltyProgramTerminology terminology = null,
            IList<string> locationIds = null,
            string createdAt = null,
            string updatedAt = null,
            IList<Models.LoyaltyProgramAccrualRule> accrualRules = null)
        {
            this.shouldSerialize = shouldSerialize;
            Id = id;
            Status = status;
            RewardTiers = rewardTiers;
            ExpirationPolicy = expirationPolicy;
            Terminology = terminology;
            LocationIds = locationIds;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            AccrualRules = accrualRules;
        }

        /// <summary>
        /// The Square-assigned ID of the loyalty program. Updates to
        /// the loyalty program do not modify the identifier.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// Indicates whether the program is currently active.
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
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
        [JsonProperty("terminology", NullValueHandling = NullValueHandling.Ignore)]
        public Models.LoyaltyProgramTerminology Terminology { get; }

        /// <summary>
        /// The [locations](entity:Location) at which the program is active.
        /// </summary>
        [JsonProperty("location_ids")]
        public IList<string> LocationIds { get; }

        /// <summary>
        /// The timestamp when the program was created, in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// The timestamp when the reward was last updated, in RFC 3339 format.
        /// </summary>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAt { get; }

        /// <summary>
        /// Defines how buyers can earn loyalty points from the base loyalty program.
        /// To check for associated [loyalty promotions](entity:LoyaltyPromotion) that enable
        /// buyers to earn extra points, call [ListLoyaltyPromotions](api-endpoint:Loyalty-ListLoyaltyPromotions).
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

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeRewardTiers()
        {
            return this.shouldSerialize["reward_tiers"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLocationIds()
        {
            return this.shouldSerialize["location_ids"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAccrualRules()
        {
            return this.shouldSerialize["accrual_rules"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is LoyaltyProgram other &&
                (this.Id == null && other.Id == null ||
                 this.Id?.Equals(other.Id) == true) &&
                (this.Status == null && other.Status == null ||
                 this.Status?.Equals(other.Status) == true) &&
                (this.RewardTiers == null && other.RewardTiers == null ||
                 this.RewardTiers?.Equals(other.RewardTiers) == true) &&
                (this.ExpirationPolicy == null && other.ExpirationPolicy == null ||
                 this.ExpirationPolicy?.Equals(other.ExpirationPolicy) == true) &&
                (this.Terminology == null && other.Terminology == null ||
                 this.Terminology?.Equals(other.Terminology) == true) &&
                (this.LocationIds == null && other.LocationIds == null ||
                 this.LocationIds?.Equals(other.LocationIds) == true) &&
                (this.CreatedAt == null && other.CreatedAt == null ||
                 this.CreatedAt?.Equals(other.CreatedAt) == true) &&
                (this.UpdatedAt == null && other.UpdatedAt == null ||
                 this.UpdatedAt?.Equals(other.UpdatedAt) == true) &&
                (this.AccrualRules == null && other.AccrualRules == null ||
                 this.AccrualRules?.Equals(other.AccrualRules) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 2031047851;
            hashCode = HashCode.Combine(hashCode, this.Id, this.Status, this.RewardTiers, this.ExpirationPolicy, this.Terminology, this.LocationIds, this.CreatedAt);

            hashCode = HashCode.Combine(hashCode, this.UpdatedAt, this.AccrualRules);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {this.Id ?? "null"}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status.ToString())}");
            toStringOutput.Add($"this.RewardTiers = {(this.RewardTiers == null ? "null" : $"[{string.Join(", ", this.RewardTiers)} ]")}");
            toStringOutput.Add($"this.ExpirationPolicy = {(this.ExpirationPolicy == null ? "null" : this.ExpirationPolicy.ToString())}");
            toStringOutput.Add($"this.Terminology = {(this.Terminology == null ? "null" : this.Terminology.ToString())}");
            toStringOutput.Add($"this.LocationIds = {(this.LocationIds == null ? "null" : $"[{string.Join(", ", this.LocationIds)} ]")}");
            toStringOutput.Add($"this.CreatedAt = {this.CreatedAt ?? "null"}");
            toStringOutput.Add($"this.UpdatedAt = {this.UpdatedAt ?? "null"}");
            toStringOutput.Add($"this.AccrualRules = {(this.AccrualRules == null ? "null" : $"[{string.Join(", ", this.AccrualRules)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(this.Id)
                .Status(this.Status)
                .RewardTiers(this.RewardTiers)
                .ExpirationPolicy(this.ExpirationPolicy)
                .Terminology(this.Terminology)
                .LocationIds(this.LocationIds)
                .CreatedAt(this.CreatedAt)
                .UpdatedAt(this.UpdatedAt)
                .AccrualRules(this.AccrualRules);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "reward_tiers", false },
                { "location_ids", false },
                { "accrual_rules", false },
            };

            private string id;
            private string status;
            private IList<Models.LoyaltyProgramRewardTier> rewardTiers;
            private Models.LoyaltyProgramExpirationPolicy expirationPolicy;
            private Models.LoyaltyProgramTerminology terminology;
            private IList<string> locationIds;
            private string createdAt;
            private string updatedAt;
            private IList<Models.LoyaltyProgramAccrualRule> accrualRules;

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
                shouldSerialize["reward_tiers"] = true;
                this.rewardTiers = rewardTiers;
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
                shouldSerialize["location_ids"] = true;
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
                shouldSerialize["accrual_rules"] = true;
                this.accrualRules = accrualRules;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetRewardTiers()
            {
                this.shouldSerialize["reward_tiers"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetLocationIds()
            {
                this.shouldSerialize["location_ids"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetAccrualRules()
            {
                this.shouldSerialize["accrual_rules"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> LoyaltyProgram. </returns>
            public LoyaltyProgram Build()
            {
                return new LoyaltyProgram(
                    shouldSerialize,
                    this.id,
                    this.status,
                    this.rewardTiers,
                    this.expirationPolicy,
                    this.terminology,
                    this.locationIds,
                    this.createdAt,
                    this.updatedAt,
                    this.accrualRules);
            }
        }
    }
}