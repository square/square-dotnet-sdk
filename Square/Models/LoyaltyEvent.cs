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
    /// LoyaltyEvent.
    /// </summary>
    public class LoyaltyEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoyaltyEvent"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="type">type.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="loyaltyAccountId">loyalty_account_id.</param>
        /// <param name="source">source.</param>
        /// <param name="accumulatePoints">accumulate_points.</param>
        /// <param name="createReward">create_reward.</param>
        /// <param name="redeemReward">redeem_reward.</param>
        /// <param name="deleteReward">delete_reward.</param>
        /// <param name="adjustPoints">adjust_points.</param>
        /// <param name="locationId">location_id.</param>
        /// <param name="expirePoints">expire_points.</param>
        /// <param name="otherEvent">other_event.</param>
        /// <param name="accumulatePromotionPoints">accumulate_promotion_points.</param>
        public LoyaltyEvent(
            string id,
            string type,
            string createdAt,
            string loyaltyAccountId,
            string source,
            Models.LoyaltyEventAccumulatePoints accumulatePoints = null,
            Models.LoyaltyEventCreateReward createReward = null,
            Models.LoyaltyEventRedeemReward redeemReward = null,
            Models.LoyaltyEventDeleteReward deleteReward = null,
            Models.LoyaltyEventAdjustPoints adjustPoints = null,
            string locationId = null,
            Models.LoyaltyEventExpirePoints expirePoints = null,
            Models.LoyaltyEventOther otherEvent = null,
            Models.LoyaltyEventAccumulatePromotionPoints accumulatePromotionPoints = null)
        {
            this.Id = id;
            this.Type = type;
            this.CreatedAt = createdAt;
            this.AccumulatePoints = accumulatePoints;
            this.CreateReward = createReward;
            this.RedeemReward = redeemReward;
            this.DeleteReward = deleteReward;
            this.AdjustPoints = adjustPoints;
            this.LoyaltyAccountId = loyaltyAccountId;
            this.LocationId = locationId;
            this.Source = source;
            this.ExpirePoints = expirePoints;
            this.OtherEvent = otherEvent;
            this.AccumulatePromotionPoints = accumulatePromotionPoints;
        }

        /// <summary>
        /// The Square-assigned ID of the loyalty event.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// The type of the loyalty event.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; }

        /// <summary>
        /// The timestamp when the event was created, in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; }

        /// <summary>
        /// Provides metadata when the event `type` is `ACCUMULATE_POINTS`.
        /// </summary>
        [JsonProperty("accumulate_points", NullValueHandling = NullValueHandling.Ignore)]
        public Models.LoyaltyEventAccumulatePoints AccumulatePoints { get; }

        /// <summary>
        /// Provides metadata when the event `type` is `CREATE_REWARD`.
        /// </summary>
        [JsonProperty("create_reward", NullValueHandling = NullValueHandling.Ignore)]
        public Models.LoyaltyEventCreateReward CreateReward { get; }

        /// <summary>
        /// Provides metadata when the event `type` is `REDEEM_REWARD`.
        /// </summary>
        [JsonProperty("redeem_reward", NullValueHandling = NullValueHandling.Ignore)]
        public Models.LoyaltyEventRedeemReward RedeemReward { get; }

        /// <summary>
        /// Provides metadata when the event `type` is `DELETE_REWARD`.
        /// </summary>
        [JsonProperty("delete_reward", NullValueHandling = NullValueHandling.Ignore)]
        public Models.LoyaltyEventDeleteReward DeleteReward { get; }

        /// <summary>
        /// Provides metadata when the event `type` is `ADJUST_POINTS`.
        /// </summary>
        [JsonProperty("adjust_points", NullValueHandling = NullValueHandling.Ignore)]
        public Models.LoyaltyEventAdjustPoints AdjustPoints { get; }

        /// <summary>
        /// The ID of the [loyalty account](entity:LoyaltyAccount) associated with the event.
        /// </summary>
        [JsonProperty("loyalty_account_id")]
        public string LoyaltyAccountId { get; }

        /// <summary>
        /// The ID of the [location](entity:Location) where the event occurred.
        /// </summary>
        [JsonProperty("location_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationId { get; }

        /// <summary>
        /// Defines whether the event was generated by the Square Point of Sale.
        /// </summary>
        [JsonProperty("source")]
        public string Source { get; }

        /// <summary>
        /// Provides metadata when the event `type` is `EXPIRE_POINTS`.
        /// </summary>
        [JsonProperty("expire_points", NullValueHandling = NullValueHandling.Ignore)]
        public Models.LoyaltyEventExpirePoints ExpirePoints { get; }

        /// <summary>
        /// Provides metadata when the event `type` is `OTHER`.
        /// </summary>
        [JsonProperty("other_event", NullValueHandling = NullValueHandling.Ignore)]
        public Models.LoyaltyEventOther OtherEvent { get; }

        /// <summary>
        /// Provides metadata when the event `type` is `ACCUMULATE_PROMOTION_POINTS`.
        /// </summary>
        [JsonProperty("accumulate_promotion_points", NullValueHandling = NullValueHandling.Ignore)]
        public Models.LoyaltyEventAccumulatePromotionPoints AccumulatePromotionPoints { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LoyaltyEvent : ({string.Join(", ", toStringOutput)})";
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
            return obj is LoyaltyEvent other &&                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((this.AccumulatePoints == null && other.AccumulatePoints == null) || (this.AccumulatePoints?.Equals(other.AccumulatePoints) == true)) &&
                ((this.CreateReward == null && other.CreateReward == null) || (this.CreateReward?.Equals(other.CreateReward) == true)) &&
                ((this.RedeemReward == null && other.RedeemReward == null) || (this.RedeemReward?.Equals(other.RedeemReward) == true)) &&
                ((this.DeleteReward == null && other.DeleteReward == null) || (this.DeleteReward?.Equals(other.DeleteReward) == true)) &&
                ((this.AdjustPoints == null && other.AdjustPoints == null) || (this.AdjustPoints?.Equals(other.AdjustPoints) == true)) &&
                ((this.LoyaltyAccountId == null && other.LoyaltyAccountId == null) || (this.LoyaltyAccountId?.Equals(other.LoyaltyAccountId) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.Source == null && other.Source == null) || (this.Source?.Equals(other.Source) == true)) &&
                ((this.ExpirePoints == null && other.ExpirePoints == null) || (this.ExpirePoints?.Equals(other.ExpirePoints) == true)) &&
                ((this.OtherEvent == null && other.OtherEvent == null) || (this.OtherEvent?.Equals(other.OtherEvent) == true)) &&
                ((this.AccumulatePromotionPoints == null && other.AccumulatePromotionPoints == null) || (this.AccumulatePromotionPoints?.Equals(other.AccumulatePromotionPoints) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1796206158;
            hashCode = HashCode.Combine(this.Id, this.Type, this.CreatedAt, this.AccumulatePoints, this.CreateReward, this.RedeemReward, this.DeleteReward);

            hashCode = HashCode.Combine(hashCode, this.AdjustPoints, this.LoyaltyAccountId, this.LocationId, this.Source, this.ExpirePoints, this.OtherEvent, this.AccumulatePromotionPoints);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type.ToString())}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt)}");
            toStringOutput.Add($"this.AccumulatePoints = {(this.AccumulatePoints == null ? "null" : this.AccumulatePoints.ToString())}");
            toStringOutput.Add($"this.CreateReward = {(this.CreateReward == null ? "null" : this.CreateReward.ToString())}");
            toStringOutput.Add($"this.RedeemReward = {(this.RedeemReward == null ? "null" : this.RedeemReward.ToString())}");
            toStringOutput.Add($"this.DeleteReward = {(this.DeleteReward == null ? "null" : this.DeleteReward.ToString())}");
            toStringOutput.Add($"this.AdjustPoints = {(this.AdjustPoints == null ? "null" : this.AdjustPoints.ToString())}");
            toStringOutput.Add($"this.LoyaltyAccountId = {(this.LoyaltyAccountId == null ? "null" : this.LoyaltyAccountId)}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId)}");
            toStringOutput.Add($"this.Source = {(this.Source == null ? "null" : this.Source.ToString())}");
            toStringOutput.Add($"this.ExpirePoints = {(this.ExpirePoints == null ? "null" : this.ExpirePoints.ToString())}");
            toStringOutput.Add($"this.OtherEvent = {(this.OtherEvent == null ? "null" : this.OtherEvent.ToString())}");
            toStringOutput.Add($"this.AccumulatePromotionPoints = {(this.AccumulatePromotionPoints == null ? "null" : this.AccumulatePromotionPoints.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Id,
                this.Type,
                this.CreatedAt,
                this.LoyaltyAccountId,
                this.Source)
                .AccumulatePoints(this.AccumulatePoints)
                .CreateReward(this.CreateReward)
                .RedeemReward(this.RedeemReward)
                .DeleteReward(this.DeleteReward)
                .AdjustPoints(this.AdjustPoints)
                .LocationId(this.LocationId)
                .ExpirePoints(this.ExpirePoints)
                .OtherEvent(this.OtherEvent)
                .AccumulatePromotionPoints(this.AccumulatePromotionPoints);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string id;
            private string type;
            private string createdAt;
            private string loyaltyAccountId;
            private string source;
            private Models.LoyaltyEventAccumulatePoints accumulatePoints;
            private Models.LoyaltyEventCreateReward createReward;
            private Models.LoyaltyEventRedeemReward redeemReward;
            private Models.LoyaltyEventDeleteReward deleteReward;
            private Models.LoyaltyEventAdjustPoints adjustPoints;
            private string locationId;
            private Models.LoyaltyEventExpirePoints expirePoints;
            private Models.LoyaltyEventOther otherEvent;
            private Models.LoyaltyEventAccumulatePromotionPoints accumulatePromotionPoints;

            /// <summary>
            /// Initialize Builder for LoyaltyEvent.
            /// </summary>
            /// <param name="id"> id. </param>
            /// <param name="type"> type. </param>
            /// <param name="createdAt"> createdAt. </param>
            /// <param name="loyaltyAccountId"> loyaltyAccountId. </param>
            /// <param name="source"> source. </param>
            public Builder(
                string id,
                string type,
                string createdAt,
                string loyaltyAccountId,
                string source)
            {
                this.id = id;
                this.type = type;
                this.createdAt = createdAt;
                this.loyaltyAccountId = loyaltyAccountId;
                this.source = source;
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
             /// Type.
             /// </summary>
             /// <param name="type"> type. </param>
             /// <returns> Builder. </returns>
            public Builder Type(string type)
            {
                this.type = type;
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
             /// LoyaltyAccountId.
             /// </summary>
             /// <param name="loyaltyAccountId"> loyaltyAccountId. </param>
             /// <returns> Builder. </returns>
            public Builder LoyaltyAccountId(string loyaltyAccountId)
            {
                this.loyaltyAccountId = loyaltyAccountId;
                return this;
            }

             /// <summary>
             /// Source.
             /// </summary>
             /// <param name="source"> source. </param>
             /// <returns> Builder. </returns>
            public Builder Source(string source)
            {
                this.source = source;
                return this;
            }

             /// <summary>
             /// AccumulatePoints.
             /// </summary>
             /// <param name="accumulatePoints"> accumulatePoints. </param>
             /// <returns> Builder. </returns>
            public Builder AccumulatePoints(Models.LoyaltyEventAccumulatePoints accumulatePoints)
            {
                this.accumulatePoints = accumulatePoints;
                return this;
            }

             /// <summary>
             /// CreateReward.
             /// </summary>
             /// <param name="createReward"> createReward. </param>
             /// <returns> Builder. </returns>
            public Builder CreateReward(Models.LoyaltyEventCreateReward createReward)
            {
                this.createReward = createReward;
                return this;
            }

             /// <summary>
             /// RedeemReward.
             /// </summary>
             /// <param name="redeemReward"> redeemReward. </param>
             /// <returns> Builder. </returns>
            public Builder RedeemReward(Models.LoyaltyEventRedeemReward redeemReward)
            {
                this.redeemReward = redeemReward;
                return this;
            }

             /// <summary>
             /// DeleteReward.
             /// </summary>
             /// <param name="deleteReward"> deleteReward. </param>
             /// <returns> Builder. </returns>
            public Builder DeleteReward(Models.LoyaltyEventDeleteReward deleteReward)
            {
                this.deleteReward = deleteReward;
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
             /// LocationId.
             /// </summary>
             /// <param name="locationId"> locationId. </param>
             /// <returns> Builder. </returns>
            public Builder LocationId(string locationId)
            {
                this.locationId = locationId;
                return this;
            }

             /// <summary>
             /// ExpirePoints.
             /// </summary>
             /// <param name="expirePoints"> expirePoints. </param>
             /// <returns> Builder. </returns>
            public Builder ExpirePoints(Models.LoyaltyEventExpirePoints expirePoints)
            {
                this.expirePoints = expirePoints;
                return this;
            }

             /// <summary>
             /// OtherEvent.
             /// </summary>
             /// <param name="otherEvent"> otherEvent. </param>
             /// <returns> Builder. </returns>
            public Builder OtherEvent(Models.LoyaltyEventOther otherEvent)
            {
                this.otherEvent = otherEvent;
                return this;
            }

             /// <summary>
             /// AccumulatePromotionPoints.
             /// </summary>
             /// <param name="accumulatePromotionPoints"> accumulatePromotionPoints. </param>
             /// <returns> Builder. </returns>
            public Builder AccumulatePromotionPoints(Models.LoyaltyEventAccumulatePromotionPoints accumulatePromotionPoints)
            {
                this.accumulatePromotionPoints = accumulatePromotionPoints;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> LoyaltyEvent. </returns>
            public LoyaltyEvent Build()
            {
                return new LoyaltyEvent(
                    this.id,
                    this.type,
                    this.createdAt,
                    this.loyaltyAccountId,
                    this.source,
                    this.accumulatePoints,
                    this.createReward,
                    this.redeemReward,
                    this.deleteReward,
                    this.adjustPoints,
                    this.locationId,
                    this.expirePoints,
                    this.otherEvent,
                    this.accumulatePromotionPoints);
            }
        }
    }
}