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
    public class LoyaltyProgram 
    {
        public LoyaltyProgram(string id,
            string status,
            IList<Models.LoyaltyProgramRewardTier> rewardTiers,
            Models.LoyaltyProgramTerminology terminology,
            IList<string> locationIds,
            string createdAt,
            string updatedAt,
            IList<Models.LoyaltyProgramAccrualRule> accrualRules,
            Models.LoyaltyProgramExpirationPolicy expirationPolicy = null)
        {
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
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// Whether the program is currently active.
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
        [JsonProperty("expiration_policy")]
        public Models.LoyaltyProgramExpirationPolicy ExpirationPolicy { get; }

        /// <summary>
        /// Getter for terminology
        /// </summary>
        [JsonProperty("terminology")]
        public Models.LoyaltyProgramTerminology Terminology { get; }

        /// <summary>
        /// The [locations](#type-Location) at which the program is active.
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

        public Builder ToBuilder()
        {
            var builder = new Builder(Id,
                Status,
                RewardTiers,
                Terminology,
                LocationIds,
                CreatedAt,
                UpdatedAt,
                AccrualRules)
                .ExpirationPolicy(ExpirationPolicy);
            return builder;
        }

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

            public Builder(string id,
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
            public Builder Id(string value)
            {
                id = value;
                return this;
            }

            public Builder Status(string value)
            {
                status = value;
                return this;
            }

            public Builder RewardTiers(IList<Models.LoyaltyProgramRewardTier> value)
            {
                rewardTiers = value;
                return this;
            }

            public Builder Terminology(Models.LoyaltyProgramTerminology value)
            {
                terminology = value;
                return this;
            }

            public Builder LocationIds(IList<string> value)
            {
                locationIds = value;
                return this;
            }

            public Builder CreatedAt(string value)
            {
                createdAt = value;
                return this;
            }

            public Builder UpdatedAt(string value)
            {
                updatedAt = value;
                return this;
            }

            public Builder AccrualRules(IList<Models.LoyaltyProgramAccrualRule> value)
            {
                accrualRules = value;
                return this;
            }

            public Builder ExpirationPolicy(Models.LoyaltyProgramExpirationPolicy value)
            {
                expirationPolicy = value;
                return this;
            }

            public LoyaltyProgram Build()
            {
                return new LoyaltyProgram(id,
                    status,
                    rewardTiers,
                    terminology,
                    locationIds,
                    createdAt,
                    updatedAt,
                    accrualRules,
                    expirationPolicy);
            }
        }
    }
}