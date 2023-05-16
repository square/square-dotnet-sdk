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
    /// LoyaltyEventExpirePoints.
    /// </summary>
    public class LoyaltyEventExpirePoints
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoyaltyEventExpirePoints"/> class.
        /// </summary>
        /// <param name="loyaltyProgramId">loyalty_program_id.</param>
        /// <param name="points">points.</param>
        public LoyaltyEventExpirePoints(
            string loyaltyProgramId,
            int points)
        {
            this.LoyaltyProgramId = loyaltyProgramId;
            this.Points = points;
        }

        /// <summary>
        /// The Square-assigned ID of the [loyalty program](entity:LoyaltyProgram).
        /// </summary>
        [JsonProperty("loyalty_program_id")]
        public string LoyaltyProgramId { get; }

        /// <summary>
        /// The number of points expired.
        /// </summary>
        [JsonProperty("points")]
        public int Points { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LoyaltyEventExpirePoints : ({string.Join(", ", toStringOutput)})";
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
            return obj is LoyaltyEventExpirePoints other &&                ((this.LoyaltyProgramId == null && other.LoyaltyProgramId == null) || (this.LoyaltyProgramId?.Equals(other.LoyaltyProgramId) == true)) &&
                this.Points.Equals(other.Points);
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -583489154;
            hashCode = HashCode.Combine(this.LoyaltyProgramId, this.Points);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.LoyaltyProgramId = {(this.LoyaltyProgramId == null ? "null" : this.LoyaltyProgramId == string.Empty ? "" : this.LoyaltyProgramId)}");
            toStringOutput.Add($"this.Points = {this.Points}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.LoyaltyProgramId,
                this.Points);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string loyaltyProgramId;
            private int points;

            public Builder(
                string loyaltyProgramId,
                int points)
            {
                this.loyaltyProgramId = loyaltyProgramId;
                this.points = points;
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
            /// Builds class object.
            /// </summary>
            /// <returns> LoyaltyEventExpirePoints. </returns>
            public LoyaltyEventExpirePoints Build()
            {
                return new LoyaltyEventExpirePoints(
                    this.loyaltyProgramId,
                    this.points);
            }
        }
    }
}