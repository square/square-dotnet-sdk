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
    public class LoyaltyEventExpirePoints 
    {
        public LoyaltyEventExpirePoints(string loyaltyProgramId,
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
        /// The number of points expired.
        /// </summary>
        [JsonProperty("points")]
        public int Points { get; }

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
            public Builder LoyaltyProgramId(string value)
            {
                loyaltyProgramId = value;
                return this;
            }

            public Builder Points(int value)
            {
                points = value;
                return this;
            }

            public LoyaltyEventExpirePoints Build()
            {
                return new LoyaltyEventExpirePoints(loyaltyProgramId,
                    points);
            }
        }
    }
}