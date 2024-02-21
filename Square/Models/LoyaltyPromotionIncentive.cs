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
    /// LoyaltyPromotionIncentive.
    /// </summary>
    public class LoyaltyPromotionIncentive
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoyaltyPromotionIncentive"/> class.
        /// </summary>
        /// <param name="type">type.</param>
        /// <param name="pointsMultiplierData">points_multiplier_data.</param>
        /// <param name="pointsAdditionData">points_addition_data.</param>
        public LoyaltyPromotionIncentive(
            string type,
            Models.LoyaltyPromotionIncentivePointsMultiplierData pointsMultiplierData = null,
            Models.LoyaltyPromotionIncentivePointsAdditionData pointsAdditionData = null)
        {
            this.Type = type;
            this.PointsMultiplierData = pointsMultiplierData;
            this.PointsAdditionData = pointsAdditionData;
        }

        /// <summary>
        /// Indicates the type of points incentive for a [loyalty promotion]($m/LoyaltyPromotion),
        /// which is used to determine how buyers can earn points from the promotion.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; }

        /// <summary>
        /// Represents the metadata for a `POINTS_MULTIPLIER` type of [loyalty promotion incentive]($m/LoyaltyPromotionIncentive).
        /// </summary>
        [JsonProperty("points_multiplier_data", NullValueHandling = NullValueHandling.Ignore)]
        public Models.LoyaltyPromotionIncentivePointsMultiplierData PointsMultiplierData { get; }

        /// <summary>
        /// Represents the metadata for a `POINTS_ADDITION` type of [loyalty promotion incentive]($m/LoyaltyPromotionIncentive).
        /// </summary>
        [JsonProperty("points_addition_data", NullValueHandling = NullValueHandling.Ignore)]
        public Models.LoyaltyPromotionIncentivePointsAdditionData PointsAdditionData { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LoyaltyPromotionIncentive : ({string.Join(", ", toStringOutput)})";
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
            return obj is LoyaltyPromotionIncentive other &&                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true)) &&
                ((this.PointsMultiplierData == null && other.PointsMultiplierData == null) || (this.PointsMultiplierData?.Equals(other.PointsMultiplierData) == true)) &&
                ((this.PointsAdditionData == null && other.PointsAdditionData == null) || (this.PointsAdditionData?.Equals(other.PointsAdditionData) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -440874065;
            hashCode = HashCode.Combine(this.Type, this.PointsMultiplierData, this.PointsAdditionData);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type.ToString())}");
            toStringOutput.Add($"this.PointsMultiplierData = {(this.PointsMultiplierData == null ? "null" : this.PointsMultiplierData.ToString())}");
            toStringOutput.Add($"this.PointsAdditionData = {(this.PointsAdditionData == null ? "null" : this.PointsAdditionData.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Type)
                .PointsMultiplierData(this.PointsMultiplierData)
                .PointsAdditionData(this.PointsAdditionData);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string type;
            private Models.LoyaltyPromotionIncentivePointsMultiplierData pointsMultiplierData;
            private Models.LoyaltyPromotionIncentivePointsAdditionData pointsAdditionData;

            /// <summary>
            /// Initialize Builder for LoyaltyPromotionIncentive.
            /// </summary>
            /// <param name="type"> type. </param>
            public Builder(
                string type)
            {
                this.type = type;
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
             /// PointsMultiplierData.
             /// </summary>
             /// <param name="pointsMultiplierData"> pointsMultiplierData. </param>
             /// <returns> Builder. </returns>
            public Builder PointsMultiplierData(Models.LoyaltyPromotionIncentivePointsMultiplierData pointsMultiplierData)
            {
                this.pointsMultiplierData = pointsMultiplierData;
                return this;
            }

             /// <summary>
             /// PointsAdditionData.
             /// </summary>
             /// <param name="pointsAdditionData"> pointsAdditionData. </param>
             /// <returns> Builder. </returns>
            public Builder PointsAdditionData(Models.LoyaltyPromotionIncentivePointsAdditionData pointsAdditionData)
            {
                this.pointsAdditionData = pointsAdditionData;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> LoyaltyPromotionIncentive. </returns>
            public LoyaltyPromotionIncentive Build()
            {
                return new LoyaltyPromotionIncentive(
                    this.type,
                    this.pointsMultiplierData,
                    this.pointsAdditionData);
            }
        }
    }
}