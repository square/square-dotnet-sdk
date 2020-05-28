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
        [JsonProperty("loyalty_program_id")]
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
            public Builder Points(int value)
            {
                points = value;
                return this;
            }

            public Builder LoyaltyProgramId(string value)
            {
                loyaltyProgramId = value;
                return this;
            }

            public Builder Reason(string value)
            {
                reason = value;
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