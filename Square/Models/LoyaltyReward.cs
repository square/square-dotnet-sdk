
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
    public class LoyaltyReward 
    {
        public LoyaltyReward(string loyaltyAccountId,
            string rewardTierId,
            string id = null,
            string status = null,
            int? points = null,
            string orderId = null,
            string createdAt = null,
            string updatedAt = null,
            string redeemedAt = null)
        {
            Id = id;
            Status = status;
            LoyaltyAccountId = loyaltyAccountId;
            RewardTierId = rewardTierId;
            Points = points;
            OrderId = orderId;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            RedeemedAt = redeemedAt;
        }

        /// <summary>
        /// The Square-assigned ID of the loyalty reward.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The status of the loyalty reward.
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; }

        /// <summary>
        /// The Square-assigned ID of the [loyalty account](#type-LoyaltyAccount) to which the reward belongs.
        /// </summary>
        [JsonProperty("loyalty_account_id")]
        public string LoyaltyAccountId { get; }

        /// <summary>
        /// The Square-assigned ID of the [reward tier](#type-LoyaltyProgramRewardTier) used to create the reward.
        /// </summary>
        [JsonProperty("reward_tier_id")]
        public string RewardTierId { get; }

        /// <summary>
        /// The number of loyalty points used for the reward.
        /// </summary>
        [JsonProperty("points", NullValueHandling = NullValueHandling.Ignore)]
        public int? Points { get; }

        /// <summary>
        /// The Square-assigned ID of the [order](#type-Order) to which the reward is attached.
        /// </summary>
        [JsonProperty("order_id", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderId { get; }

        /// <summary>
        /// The timestamp when the reward was created, in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// The timestamp when the reward was last updated, in RFC 3339 format.
        /// </summary>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAt { get; }

        /// <summary>
        /// The timestamp when the reward was redeemed, in RFC 3339 format.
        /// </summary>
        [JsonProperty("redeemed_at", NullValueHandling = NullValueHandling.Ignore)]
        public string RedeemedAt { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LoyaltyReward : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Id = {(Id == null ? "null" : Id == string.Empty ? "" : Id)}");
            toStringOutput.Add($"Status = {(Status == null ? "null" : Status.ToString())}");
            toStringOutput.Add($"LoyaltyAccountId = {(LoyaltyAccountId == null ? "null" : LoyaltyAccountId == string.Empty ? "" : LoyaltyAccountId)}");
            toStringOutput.Add($"RewardTierId = {(RewardTierId == null ? "null" : RewardTierId == string.Empty ? "" : RewardTierId)}");
            toStringOutput.Add($"Points = {(Points == null ? "null" : Points.ToString())}");
            toStringOutput.Add($"OrderId = {(OrderId == null ? "null" : OrderId == string.Empty ? "" : OrderId)}");
            toStringOutput.Add($"CreatedAt = {(CreatedAt == null ? "null" : CreatedAt == string.Empty ? "" : CreatedAt)}");
            toStringOutput.Add($"UpdatedAt = {(UpdatedAt == null ? "null" : UpdatedAt == string.Empty ? "" : UpdatedAt)}");
            toStringOutput.Add($"RedeemedAt = {(RedeemedAt == null ? "null" : RedeemedAt == string.Empty ? "" : RedeemedAt)}");
        }

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

            return obj is LoyaltyReward other &&
                ((Id == null && other.Id == null) || (Id?.Equals(other.Id) == true)) &&
                ((Status == null && other.Status == null) || (Status?.Equals(other.Status) == true)) &&
                ((LoyaltyAccountId == null && other.LoyaltyAccountId == null) || (LoyaltyAccountId?.Equals(other.LoyaltyAccountId) == true)) &&
                ((RewardTierId == null && other.RewardTierId == null) || (RewardTierId?.Equals(other.RewardTierId) == true)) &&
                ((Points == null && other.Points == null) || (Points?.Equals(other.Points) == true)) &&
                ((OrderId == null && other.OrderId == null) || (OrderId?.Equals(other.OrderId) == true)) &&
                ((CreatedAt == null && other.CreatedAt == null) || (CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((UpdatedAt == null && other.UpdatedAt == null) || (UpdatedAt?.Equals(other.UpdatedAt) == true)) &&
                ((RedeemedAt == null && other.RedeemedAt == null) || (RedeemedAt?.Equals(other.RedeemedAt) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1604808841;

            if (Id != null)
            {
               hashCode += Id.GetHashCode();
            }

            if (Status != null)
            {
               hashCode += Status.GetHashCode();
            }

            if (LoyaltyAccountId != null)
            {
               hashCode += LoyaltyAccountId.GetHashCode();
            }

            if (RewardTierId != null)
            {
               hashCode += RewardTierId.GetHashCode();
            }

            if (Points != null)
            {
               hashCode += Points.GetHashCode();
            }

            if (OrderId != null)
            {
               hashCode += OrderId.GetHashCode();
            }

            if (CreatedAt != null)
            {
               hashCode += CreatedAt.GetHashCode();
            }

            if (UpdatedAt != null)
            {
               hashCode += UpdatedAt.GetHashCode();
            }

            if (RedeemedAt != null)
            {
               hashCode += RedeemedAt.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(LoyaltyAccountId,
                RewardTierId)
                .Id(Id)
                .Status(Status)
                .Points(Points)
                .OrderId(OrderId)
                .CreatedAt(CreatedAt)
                .UpdatedAt(UpdatedAt)
                .RedeemedAt(RedeemedAt);
            return builder;
        }

        public class Builder
        {
            private string loyaltyAccountId;
            private string rewardTierId;
            private string id;
            private string status;
            private int? points;
            private string orderId;
            private string createdAt;
            private string updatedAt;
            private string redeemedAt;

            public Builder(string loyaltyAccountId,
                string rewardTierId)
            {
                this.loyaltyAccountId = loyaltyAccountId;
                this.rewardTierId = rewardTierId;
            }

            public Builder LoyaltyAccountId(string loyaltyAccountId)
            {
                this.loyaltyAccountId = loyaltyAccountId;
                return this;
            }

            public Builder RewardTierId(string rewardTierId)
            {
                this.rewardTierId = rewardTierId;
                return this;
            }

            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

            public Builder Status(string status)
            {
                this.status = status;
                return this;
            }

            public Builder Points(int? points)
            {
                this.points = points;
                return this;
            }

            public Builder OrderId(string orderId)
            {
                this.orderId = orderId;
                return this;
            }

            public Builder CreatedAt(string createdAt)
            {
                this.createdAt = createdAt;
                return this;
            }

            public Builder UpdatedAt(string updatedAt)
            {
                this.updatedAt = updatedAt;
                return this;
            }

            public Builder RedeemedAt(string redeemedAt)
            {
                this.redeemedAt = redeemedAt;
                return this;
            }

            public LoyaltyReward Build()
            {
                return new LoyaltyReward(loyaltyAccountId,
                    rewardTierId,
                    id,
                    status,
                    points,
                    orderId,
                    createdAt,
                    updatedAt,
                    redeemedAt);
            }
        }
    }
}