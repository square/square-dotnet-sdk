
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
            string createdAt,
            Models.CatalogObjectReference pricingRuleReference = null)
        {
            Id = id;
            Points = points;
            Name = name;
            Definition = definition;
            CreatedAt = createdAt;
            PricingRuleReference = pricingRuleReference;
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
        /// Provides details about the reward tier discount. DEPRECATED at version 2020-12-16. Discount details
        /// are now defined using a catalog pricing rule and other catalog objects. For more information, see
        /// [Get discount details for the reward](https://developer.squareup.com/docs/loyalty-api/overview#get-discount-details).
        /// </summary>
        [JsonProperty("definition")]
        public Models.LoyaltyProgramRewardDefinition Definition { get; }

        /// <summary>
        /// The timestamp when the reward tier was created, in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; }

        /// <summary>
        /// A reference to a Catalog object at a specific version. In general this is
        /// used as an entry point into a graph of catalog objects, where the objects exist
        /// at a specific version.
        /// </summary>
        [JsonProperty("pricing_rule_reference", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CatalogObjectReference PricingRuleReference { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LoyaltyProgramRewardTier : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Id = {(Id == null ? "null" : Id == string.Empty ? "" : Id)}");
            toStringOutput.Add($"Points = {Points}");
            toStringOutput.Add($"Name = {(Name == null ? "null" : Name == string.Empty ? "" : Name)}");
            toStringOutput.Add($"Definition = {(Definition == null ? "null" : Definition.ToString())}");
            toStringOutput.Add($"CreatedAt = {(CreatedAt == null ? "null" : CreatedAt == string.Empty ? "" : CreatedAt)}");
            toStringOutput.Add($"PricingRuleReference = {(PricingRuleReference == null ? "null" : PricingRuleReference.ToString())}");
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

            return obj is LoyaltyProgramRewardTier other &&
                ((Id == null && other.Id == null) || (Id?.Equals(other.Id) == true)) &&
                Points.Equals(other.Points) &&
                ((Name == null && other.Name == null) || (Name?.Equals(other.Name) == true)) &&
                ((Definition == null && other.Definition == null) || (Definition?.Equals(other.Definition) == true)) &&
                ((CreatedAt == null && other.CreatedAt == null) || (CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((PricingRuleReference == null && other.PricingRuleReference == null) || (PricingRuleReference?.Equals(other.PricingRuleReference) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 1770802231;

            if (Id != null)
            {
               hashCode += Id.GetHashCode();
            }
            hashCode += Points.GetHashCode();

            if (Name != null)
            {
               hashCode += Name.GetHashCode();
            }

            if (Definition != null)
            {
               hashCode += Definition.GetHashCode();
            }

            if (CreatedAt != null)
            {
               hashCode += CreatedAt.GetHashCode();
            }

            if (PricingRuleReference != null)
            {
               hashCode += PricingRuleReference.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(Id,
                Points,
                Name,
                Definition,
                CreatedAt)
                .PricingRuleReference(PricingRuleReference);
            return builder;
        }

        public class Builder
        {
            private string id;
            private int points;
            private string name;
            private Models.LoyaltyProgramRewardDefinition definition;
            private string createdAt;
            private Models.CatalogObjectReference pricingRuleReference;

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

            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

            public Builder Points(int points)
            {
                this.points = points;
                return this;
            }

            public Builder Name(string name)
            {
                this.name = name;
                return this;
            }

            public Builder Definition(Models.LoyaltyProgramRewardDefinition definition)
            {
                this.definition = definition;
                return this;
            }

            public Builder CreatedAt(string createdAt)
            {
                this.createdAt = createdAt;
                return this;
            }

            public Builder PricingRuleReference(Models.CatalogObjectReference pricingRuleReference)
            {
                this.pricingRuleReference = pricingRuleReference;
                return this;
            }

            public LoyaltyProgramRewardTier Build()
            {
                return new LoyaltyProgramRewardTier(id,
                    points,
                    name,
                    definition,
                    createdAt,
                    pricingRuleReference);
            }
        }
    }
}