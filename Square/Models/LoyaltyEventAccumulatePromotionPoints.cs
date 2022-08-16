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
    /// LoyaltyEventAccumulatePromotionPoints.
    /// </summary>
    public class LoyaltyEventAccumulatePromotionPoints
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoyaltyEventAccumulatePromotionPoints"/> class.
        /// </summary>
        /// <param name="points">points.</param>
        /// <param name="orderId">order_id.</param>
        /// <param name="loyaltyProgramId">loyalty_program_id.</param>
        /// <param name="loyaltyPromotionId">loyalty_promotion_id.</param>
        public LoyaltyEventAccumulatePromotionPoints(
            int points,
            string orderId,
            string loyaltyProgramId = null,
            string loyaltyPromotionId = null)
        {
            this.LoyaltyProgramId = loyaltyProgramId;
            this.LoyaltyPromotionId = loyaltyPromotionId;
            this.Points = points;
            this.OrderId = orderId;
        }

        /// <summary>
        /// The Square-assigned ID of the [loyalty program]($m/LoyaltyProgram).
        /// </summary>
        [JsonProperty("loyalty_program_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LoyaltyProgramId { get; }

        /// <summary>
        /// The Square-assigned ID of the [loyalty promotion]($m/LoyaltyPromotion).
        /// </summary>
        [JsonProperty("loyalty_promotion_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LoyaltyPromotionId { get; }

        /// <summary>
        /// The number of points earned by the event.
        /// </summary>
        [JsonProperty("points")]
        public int Points { get; }

        /// <summary>
        /// The ID of the [order]($m/Order) for which the buyer earned the promotion points.
        /// Only applications that use the Orders API to process orders can trigger this event.
        /// </summary>
        [JsonProperty("order_id")]
        public string OrderId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LoyaltyEventAccumulatePromotionPoints : ({string.Join(", ", toStringOutput)})";
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

            return obj is LoyaltyEventAccumulatePromotionPoints other &&
                ((this.LoyaltyProgramId == null && other.LoyaltyProgramId == null) || (this.LoyaltyProgramId?.Equals(other.LoyaltyProgramId) == true)) &&
                ((this.LoyaltyPromotionId == null && other.LoyaltyPromotionId == null) || (this.LoyaltyPromotionId?.Equals(other.LoyaltyPromotionId) == true)) &&
                this.Points.Equals(other.Points) &&
                ((this.OrderId == null && other.OrderId == null) || (this.OrderId?.Equals(other.OrderId) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -346811038;
            hashCode = HashCode.Combine(this.LoyaltyProgramId, this.LoyaltyPromotionId, this.Points, this.OrderId);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.LoyaltyProgramId = {(this.LoyaltyProgramId == null ? "null" : this.LoyaltyProgramId == string.Empty ? "" : this.LoyaltyProgramId)}");
            toStringOutput.Add($"this.LoyaltyPromotionId = {(this.LoyaltyPromotionId == null ? "null" : this.LoyaltyPromotionId == string.Empty ? "" : this.LoyaltyPromotionId)}");
            toStringOutput.Add($"this.Points = {this.Points}");
            toStringOutput.Add($"this.OrderId = {(this.OrderId == null ? "null" : this.OrderId == string.Empty ? "" : this.OrderId)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Points,
                this.OrderId)
                .LoyaltyProgramId(this.LoyaltyProgramId)
                .LoyaltyPromotionId(this.LoyaltyPromotionId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private int points;
            private string orderId;
            private string loyaltyProgramId;
            private string loyaltyPromotionId;

            public Builder(
                int points,
                string orderId)
            {
                this.points = points;
                this.orderId = orderId;
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
             /// OrderId.
             /// </summary>
             /// <param name="orderId"> orderId. </param>
             /// <returns> Builder. </returns>
            public Builder OrderId(string orderId)
            {
                this.orderId = orderId;
                return this;
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
             /// LoyaltyPromotionId.
             /// </summary>
             /// <param name="loyaltyPromotionId"> loyaltyPromotionId. </param>
             /// <returns> Builder. </returns>
            public Builder LoyaltyPromotionId(string loyaltyPromotionId)
            {
                this.loyaltyPromotionId = loyaltyPromotionId;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> LoyaltyEventAccumulatePromotionPoints. </returns>
            public LoyaltyEventAccumulatePromotionPoints Build()
            {
                return new LoyaltyEventAccumulatePromotionPoints(
                    this.points,
                    this.orderId,
                    this.loyaltyProgramId,
                    this.loyaltyPromotionId);
            }
        }
    }
}