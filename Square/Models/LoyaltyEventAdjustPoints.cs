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
    /// LoyaltyEventAdjustPoints.
    /// </summary>
    public class LoyaltyEventAdjustPoints
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="LoyaltyEventAdjustPoints"/> class.
        /// </summary>
        /// <param name="points">points.</param>
        /// <param name="loyaltyProgramId">loyalty_program_id.</param>
        /// <param name="reason">reason.</param>
        public LoyaltyEventAdjustPoints(
            int points,
            string loyaltyProgramId = null,
            string reason = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "reason", false }
            };
            this.LoyaltyProgramId = loyaltyProgramId;
            this.Points = points;

            if (reason != null)
            {
                shouldSerialize["reason"] = true;
                this.Reason = reason;
            }
        }

        internal LoyaltyEventAdjustPoints(
            Dictionary<string, bool> shouldSerialize,
            int points,
            string loyaltyProgramId = null,
            string reason = null)
        {
            this.shouldSerialize = shouldSerialize;
            LoyaltyProgramId = loyaltyProgramId;
            Points = points;
            Reason = reason;
        }

        /// <summary>
        /// The Square-assigned ID of the [loyalty program](entity:LoyaltyProgram).
        /// </summary>
        [JsonProperty("loyalty_program_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LoyaltyProgramId { get; }

        /// <summary>
        /// The number of points added or removed.
        /// </summary>
        [JsonProperty("points")]
        public int Points { get; }

        /// <summary>
        /// The reason for the adjustment of points.
        /// </summary>
        [JsonProperty("reason")]
        public string Reason { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"LoyaltyEventAdjustPoints : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeReason()
        {
            return this.shouldSerialize["reason"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is LoyaltyEventAdjustPoints other &&
                (this.LoyaltyProgramId == null && other.LoyaltyProgramId == null ||
                 this.LoyaltyProgramId?.Equals(other.LoyaltyProgramId) == true) &&
                (this.Points.Equals(other.Points)) &&
                (this.Reason == null && other.Reason == null ||
                 this.Reason?.Equals(other.Reason) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 318164469;
            hashCode = HashCode.Combine(hashCode, this.LoyaltyProgramId, this.Points, this.Reason);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.LoyaltyProgramId = {this.LoyaltyProgramId ?? "null"}");
            toStringOutput.Add($"this.Points = {this.Points}");
            toStringOutput.Add($"this.Reason = {this.Reason ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Points)
                .LoyaltyProgramId(this.LoyaltyProgramId)
                .Reason(this.Reason);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "reason", false },
            };

            private int points;
            private string loyaltyProgramId;
            private string reason;

            /// <summary>
            /// Initialize Builder for LoyaltyEventAdjustPoints.
            /// </summary>
            /// <param name="points"> points. </param>
            public Builder(
                int points)
            {
                this.points = points;
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
             /// Reason.
             /// </summary>
             /// <param name="reason"> reason. </param>
             /// <returns> Builder. </returns>
            public Builder Reason(string reason)
            {
                shouldSerialize["reason"] = true;
                this.reason = reason;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetReason()
            {
                this.shouldSerialize["reason"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> LoyaltyEventAdjustPoints. </returns>
            public LoyaltyEventAdjustPoints Build()
            {
                return new LoyaltyEventAdjustPoints(
                    shouldSerialize,
                    this.points,
                    this.loyaltyProgramId,
                    this.reason);
            }
        }
    }
}