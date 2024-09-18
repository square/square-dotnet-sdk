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
    /// LoyaltyPromotionIncentivePointsAdditionData.
    /// </summary>
    public class LoyaltyPromotionIncentivePointsAdditionData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoyaltyPromotionIncentivePointsAdditionData"/> class.
        /// </summary>
        /// <param name="pointsAddition">points_addition.</param>
        public LoyaltyPromotionIncentivePointsAdditionData(
            int pointsAddition)
        {
            this.PointsAddition = pointsAddition;
        }

        /// <summary>
        /// The number of additional points to earn each time the promotion is triggered. For example,
        /// suppose a purchase qualifies for 5 points from the base loyalty program. If the purchase also
        /// qualifies for a `POINTS_ADDITION` promotion incentive with a `points_addition` of 3, the buyer
        /// earns a total of 8 points (5 program points + 3 promotion points = 8 points).
        /// </summary>
        [JsonProperty("points_addition")]
        public int PointsAddition { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LoyaltyPromotionIncentivePointsAdditionData : ({string.Join(", ", toStringOutput)})";
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
            return obj is LoyaltyPromotionIncentivePointsAdditionData other &&                this.PointsAddition.Equals(other.PointsAddition);
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1204465322;
            hashCode = HashCode.Combine(this.PointsAddition);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.PointsAddition = {this.PointsAddition}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.PointsAddition);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private int pointsAddition;

            /// <summary>
            /// Initialize Builder for LoyaltyPromotionIncentivePointsAdditionData.
            /// </summary>
            /// <param name="pointsAddition"> pointsAddition. </param>
            public Builder(
                int pointsAddition)
            {
                this.pointsAddition = pointsAddition;
            }

             /// <summary>
             /// PointsAddition.
             /// </summary>
             /// <param name="pointsAddition"> pointsAddition. </param>
             /// <returns> Builder. </returns>
            public Builder PointsAddition(int pointsAddition)
            {
                this.pointsAddition = pointsAddition;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> LoyaltyPromotionIncentivePointsAdditionData. </returns>
            public LoyaltyPromotionIncentivePointsAdditionData Build()
            {
                return new LoyaltyPromotionIncentivePointsAdditionData(
                    this.pointsAddition);
            }
        }
    }
}