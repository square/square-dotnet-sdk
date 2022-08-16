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
    /// LoyaltyPromotionIncentivePointsMultiplierData.
    /// </summary>
    public class LoyaltyPromotionIncentivePointsMultiplierData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoyaltyPromotionIncentivePointsMultiplierData"/> class.
        /// </summary>
        /// <param name="pointsMultiplier">points_multiplier.</param>
        public LoyaltyPromotionIncentivePointsMultiplierData(
            int pointsMultiplier)
        {
            this.PointsMultiplier = pointsMultiplier;
        }

        /// <summary>
        /// The multiplier used to calculate the number of points earned each time the promotion
        /// is triggered. For example, suppose a purchase qualifies for 5 points from the base loyalty program.
        /// If the purchase also qualifies for a `POINTS_MULTIPLIER` promotion incentive with a `points_multiplier`
        /// of 3, the buyer earns a total of 15 points (5 program points x 3 promotion multiplier = 15 points).
        /// </summary>
        [JsonProperty("points_multiplier")]
        public int PointsMultiplier { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LoyaltyPromotionIncentivePointsMultiplierData : ({string.Join(", ", toStringOutput)})";
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

            return obj is LoyaltyPromotionIncentivePointsMultiplierData other &&
                this.PointsMultiplier.Equals(other.PointsMultiplier);
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -381201494;
            hashCode = HashCode.Combine(this.PointsMultiplier);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.PointsMultiplier = {this.PointsMultiplier}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.PointsMultiplier);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private int pointsMultiplier;

            public Builder(
                int pointsMultiplier)
            {
                this.pointsMultiplier = pointsMultiplier;
            }

             /// <summary>
             /// PointsMultiplier.
             /// </summary>
             /// <param name="pointsMultiplier"> pointsMultiplier. </param>
             /// <returns> Builder. </returns>
            public Builder PointsMultiplier(int pointsMultiplier)
            {
                this.pointsMultiplier = pointsMultiplier;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> LoyaltyPromotionIncentivePointsMultiplierData. </returns>
            public LoyaltyPromotionIncentivePointsMultiplierData Build()
            {
                return new LoyaltyPromotionIncentivePointsMultiplierData(
                    this.pointsMultiplier);
            }
        }
    }
}