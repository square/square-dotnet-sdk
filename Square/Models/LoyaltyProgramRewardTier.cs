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
    public class LoyaltyProgramRewardTier 
    {
        public LoyaltyProgramRewardTier(string id,
            int points,
            string name,
            Models.LoyaltyProgramRewardDefinition definition,
            string createdAt)
        {
            Id = id;
            Points = points;
            Name = name;
            Definition = definition;
            CreatedAt = createdAt;
        }

        /// <summary>
        /// The Square-assigned ID of the reward tier.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// The points exchanged for the reward tier.
        /// </summary>
        [JsonProperty("points")]
        public int Points { get; }

        /// <summary>
        /// The name of the reward tier.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// Provides details about the loyalty program reward tier definition.
        /// </summary>
        [JsonProperty("definition")]
        public Models.LoyaltyProgramRewardDefinition Definition { get; }

        /// <summary>
        /// The timestamp when the reward tier was created, in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(Id,
                Points,
                Name,
                Definition,
                CreatedAt);
            return builder;
        }

        public class Builder
        {
            private string id;
            private int points;
            private string name;
            private Models.LoyaltyProgramRewardDefinition definition;
            private string createdAt;

            public Builder(string id,
                int points,
                string name,
                Models.LoyaltyProgramRewardDefinition definition,
                string createdAt)
            {
                this.id = id;
                this.points = points;
                this.name = name;
                this.definition = definition;
                this.createdAt = createdAt;
            }
            public Builder Id(string value)
            {
                id = value;
                return this;
            }

            public Builder Points(int value)
            {
                points = value;
                return this;
            }

            public Builder Name(string value)
            {
                name = value;
                return this;
            }

            public Builder Definition(Models.LoyaltyProgramRewardDefinition value)
            {
                definition = value;
                return this;
            }

            public Builder CreatedAt(string value)
            {
                createdAt = value;
                return this;
            }

            public LoyaltyProgramRewardTier Build()
            {
                return new LoyaltyProgramRewardTier(id,
                    points,
                    name,
                    definition,
                    createdAt);
            }
        }
    }
}