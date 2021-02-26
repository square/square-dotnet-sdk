
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
    public class LoyaltyEventOther 
    {
        public LoyaltyEventOther(string loyaltyProgramId,
            int points)
        {
            LoyaltyProgramId = loyaltyProgramId;
            Points = points;
        }

        /// <summary>
        /// The Square-assigned ID of the [loyalty program](#type-LoyaltyProgram).
        /// </summary>
        [JsonProperty("loyalty_program_id")]
        public string LoyaltyProgramId { get; }

        /// <summary>
        /// The number of points added or removed.
        /// </summary>
        [JsonProperty("points")]
        public int Points { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LoyaltyEventOther : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"LoyaltyProgramId = {(LoyaltyProgramId == null ? "null" : LoyaltyProgramId == string.Empty ? "" : LoyaltyProgramId)}");
            toStringOutput.Add($"Points = {Points}");
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

            return obj is LoyaltyEventOther other &&
                ((LoyaltyProgramId == null && other.LoyaltyProgramId == null) || (LoyaltyProgramId?.Equals(other.LoyaltyProgramId) == true)) &&
                Points.Equals(other.Points);
        }

        public override int GetHashCode()
        {
            int hashCode = 1520527476;

            if (LoyaltyProgramId != null)
            {
               hashCode += LoyaltyProgramId.GetHashCode();
            }
            hashCode += Points.GetHashCode();

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(LoyaltyProgramId,
                Points);
            return builder;
        }

        public class Builder
        {
            private string loyaltyProgramId;
            private int points;

            public Builder(string loyaltyProgramId,
                int points)
            {
                this.loyaltyProgramId = loyaltyProgramId;
                this.points = points;
            }

            public Builder LoyaltyProgramId(string loyaltyProgramId)
            {
                this.loyaltyProgramId = loyaltyProgramId;
                return this;
            }

            public Builder Points(int points)
            {
                this.points = points;
                return this;
            }

            public LoyaltyEventOther Build()
            {
                return new LoyaltyEventOther(loyaltyProgramId,
                    points);
            }
        }
    }
}