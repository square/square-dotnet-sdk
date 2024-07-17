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
    /// LoyaltyPromotionIncentivePointsMultiplierData.
    /// </summary>
    public class LoyaltyPromotionIncentivePointsMultiplierData
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="LoyaltyPromotionIncentivePointsMultiplierData"/> class.
        /// </summary>
        /// <param name="pointsMultiplier">points_multiplier.</param>
        /// <param name="multiplier">multiplier.</param>
        public LoyaltyPromotionIncentivePointsMultiplierData(
            int? pointsMultiplier = null,
            string multiplier = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "points_multiplier", false },
                { "multiplier", false }
            };

            if (pointsMultiplier != null)
            {
                shouldSerialize["points_multiplier"] = true;
                this.PointsMultiplier = pointsMultiplier;
            }

            if (multiplier != null)
            {
                shouldSerialize["multiplier"] = true;
                this.Multiplier = multiplier;
            }

        }
        internal LoyaltyPromotionIncentivePointsMultiplierData(Dictionary<string, bool> shouldSerialize,
            int? pointsMultiplier = null,
            string multiplier = null)
        {
            this.shouldSerialize = shouldSerialize;
            PointsMultiplier = pointsMultiplier;
            Multiplier = multiplier;
        }

        /// <summary>
        /// The multiplier used to calculate the number of points earned each time the promotion
        /// is triggered. For example, suppose a purchase qualifies for 5 points from the base loyalty program.
        /// If the purchase also qualifies for a `POINTS_MULTIPLIER` promotion incentive with a `points_multiplier`
        /// of 3, the buyer earns a total of 15 points (5 program points x 3 promotion multiplier = 15 points).
        /// DEPRECATED at version 2023-08-16. Replaced by the `multiplier` field.
        /// One of the following is required when specifying a points multiplier:
        /// - (Recommended) The `multiplier` field.
        /// - This deprecated `points_multiplier` field. If provided in the request, Square also returns `multiplier`
        /// with the equivalent value.
        /// </summary>
        [JsonProperty("points_multiplier")]
        public int? PointsMultiplier { get; }

        /// <summary>
        /// The multiplier used to calculate the number of points earned each time the promotion is triggered,
        /// specified as a string representation of a decimal. Square supports multipliers up to 10x, with three
        /// point precision for decimal multipliers. For example, suppose a purchase qualifies for 4 points from the
        /// base loyalty program. If the purchase also qualifies for a `POINTS_MULTIPLIER` promotion incentive with a
        /// `multiplier` of "1.5", the buyer earns a total of 6 points (4 program points x 1.5 promotion multiplier = 6 points).
        /// Fractional points are dropped.
        /// One of the following is required when specifying a points multiplier:
        /// - (Recommended) This `multiplier` field.
        /// - The deprecated `points_multiplier` field. If provided in the request, Square also returns `multiplier`
        /// with the equivalent value.
        /// </summary>
        [JsonProperty("multiplier")]
        public string Multiplier { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LoyaltyPromotionIncentivePointsMultiplierData : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePointsMultiplier()
        {
            return this.shouldSerialize["points_multiplier"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeMultiplier()
        {
            return this.shouldSerialize["multiplier"];
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
            return obj is LoyaltyPromotionIncentivePointsMultiplierData other &&                ((this.PointsMultiplier == null && other.PointsMultiplier == null) || (this.PointsMultiplier?.Equals(other.PointsMultiplier) == true)) &&
                ((this.Multiplier == null && other.Multiplier == null) || (this.Multiplier?.Equals(other.Multiplier) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -79851321;
            hashCode = HashCode.Combine(this.PointsMultiplier, this.Multiplier);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.PointsMultiplier = {(this.PointsMultiplier == null ? "null" : this.PointsMultiplier.ToString())}");
            toStringOutput.Add($"this.Multiplier = {(this.Multiplier == null ? "null" : this.Multiplier)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .PointsMultiplier(this.PointsMultiplier)
                .Multiplier(this.Multiplier);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "points_multiplier", false },
                { "multiplier", false },
            };

            private int? pointsMultiplier;
            private string multiplier;

             /// <summary>
             /// PointsMultiplier.
             /// </summary>
             /// <param name="pointsMultiplier"> pointsMultiplier. </param>
             /// <returns> Builder. </returns>
            public Builder PointsMultiplier(int? pointsMultiplier)
            {
                shouldSerialize["points_multiplier"] = true;
                this.pointsMultiplier = pointsMultiplier;
                return this;
            }

             /// <summary>
             /// Multiplier.
             /// </summary>
             /// <param name="multiplier"> multiplier. </param>
             /// <returns> Builder. </returns>
            public Builder Multiplier(string multiplier)
            {
                shouldSerialize["multiplier"] = true;
                this.multiplier = multiplier;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetPointsMultiplier()
            {
                this.shouldSerialize["points_multiplier"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetMultiplier()
            {
                this.shouldSerialize["multiplier"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> LoyaltyPromotionIncentivePointsMultiplierData. </returns>
            public LoyaltyPromotionIncentivePointsMultiplierData Build()
            {
                return new LoyaltyPromotionIncentivePointsMultiplierData(shouldSerialize,
                    this.pointsMultiplier,
                    this.multiplier);
            }
        }
    }
}