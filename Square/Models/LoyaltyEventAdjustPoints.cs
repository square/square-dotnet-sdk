
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
    public class LoyaltyEventAdjustPoints 
    {
        public LoyaltyEventAdjustPoints(int points,
            string loyaltyProgramId = null,
            string reason = null)
        {
            LoyaltyProgramId = loyaltyProgramId;
            Points = points;
            Reason = reason;
        }

        /// <summary>
        /// The Square-assigned ID of the [loyalty program](#type-LoyaltyProgram).
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
        [JsonProperty("reason", NullValueHandling = NullValueHandling.Ignore)]
        public string Reason { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LoyaltyEventAdjustPoints : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"LoyaltyProgramId = {(LoyaltyProgramId == null ? "null" : LoyaltyProgramId == string.Empty ? "" : LoyaltyProgramId)}");
            toStringOutput.Add($"Points = {Points}");
            toStringOutput.Add($"Reason = {(Reason == null ? "null" : Reason == string.Empty ? "" : Reason)}");
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

            return obj is LoyaltyEventAdjustPoints other &&
                ((LoyaltyProgramId == null && other.LoyaltyProgramId == null) || (LoyaltyProgramId?.Equals(other.LoyaltyProgramId) == true)) &&
                Points.Equals(other.Points) &&
                ((Reason == null && other.Reason == null) || (Reason?.Equals(other.Reason) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 318164469;

            if (LoyaltyProgramId != null)
            {
               hashCode += LoyaltyProgramId.GetHashCode();
            }
            hashCode += Points.GetHashCode();

            if (Reason != null)
            {
               hashCode += Reason.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(Points)
                .LoyaltyProgramId(LoyaltyProgramId)
                .Reason(Reason);
            return builder;
        }

        public class Builder
        {
            private int points;
            private string loyaltyProgramId;
            private string reason;

            public Builder(int points)
            {
                this.points = points;
            }

            public Builder Points(int points)
            {
                this.points = points;
                return this;
            }

            public Builder LoyaltyProgramId(string loyaltyProgramId)
            {
                this.loyaltyProgramId = loyaltyProgramId;
                return this;
            }

            public Builder Reason(string reason)
            {
                this.reason = reason;
                return this;
            }

            public LoyaltyEventAdjustPoints Build()
            {
                return new LoyaltyEventAdjustPoints(points,
                    loyaltyProgramId,
                    reason);
            }
        }
    }
}