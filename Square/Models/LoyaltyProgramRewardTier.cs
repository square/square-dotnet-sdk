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
    /// LoyaltyProgramRewardTier.
    /// </summary>
    public class LoyaltyProgramRewardTier
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoyaltyProgramRewardTier"/> class.
        /// </summary>
        /// <param name="points">points.</param>
        /// <param name="pricingRuleReference">pricing_rule_reference.</param>
        /// <param name="id">id.</param>
        /// <param name="name">name.</param>
        /// <param name="definition">definition.</param>
        /// <param name="createdAt">created_at.</param>
        public LoyaltyProgramRewardTier(
            int points,
            Models.CatalogObjectReference pricingRuleReference,
            string id = null,
            string name = null,
            Models.LoyaltyProgramRewardDefinition definition = null,
            string createdAt = null)
        {
            this.Id = id;
            this.Points = points;
            this.Name = name;
            this.Definition = definition;
            this.CreatedAt = createdAt;
            this.PricingRuleReference = pricingRuleReference;
        }

        /// <summary>
        /// The Square-assigned ID of the reward tier.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The points exchanged for the reward tier.
        /// </summary>
        [JsonProperty("points")]
        public int Points { get; }

        /// <summary>
        /// The name of the reward tier.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; }

        /// <summary>
        /// Provides details about the reward tier discount. DEPRECATED at version 2020-12-16. Discount details
        /// are now defined using a catalog pricing rule and other catalog objects. For more information, see
        /// [Getting discount details for a reward tier](https://developer.squareup.com/docs/loyalty-api/loyalty-rewards#get-discount-details).
        /// </summary>
        [JsonProperty("definition", NullValueHandling = NullValueHandling.Ignore)]
        public Models.LoyaltyProgramRewardDefinition Definition { get; }

        /// <summary>
        /// The timestamp when the reward tier was created, in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// A reference to a Catalog object at a specific version. In general this is
        /// used as an entry point into a graph of catalog objects, where the objects exist
        /// at a specific version.
        /// </summary>
        [JsonProperty("pricing_rule_reference")]
        public Models.CatalogObjectReference PricingRuleReference { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LoyaltyProgramRewardTier : ({string.Join(", ", toStringOutput)})";
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
            return obj is LoyaltyProgramRewardTier other &&                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                this.Points.Equals(other.Points) &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.Definition == null && other.Definition == null) || (this.Definition?.Equals(other.Definition) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((this.PricingRuleReference == null && other.PricingRuleReference == null) || (this.PricingRuleReference?.Equals(other.PricingRuleReference) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1770802231;
            hashCode = HashCode.Combine(this.Id, this.Points, this.Name, this.Definition, this.CreatedAt, this.PricingRuleReference);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.Points = {this.Points}");
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name)}");
            toStringOutput.Add($"this.Definition = {(this.Definition == null ? "null" : this.Definition.ToString())}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt)}");
            toStringOutput.Add($"this.PricingRuleReference = {(this.PricingRuleReference == null ? "null" : this.PricingRuleReference.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Points,
                this.PricingRuleReference)
                .Id(this.Id)
                .Name(this.Name)
                .Definition(this.Definition)
                .CreatedAt(this.CreatedAt);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private int points;
            private Models.CatalogObjectReference pricingRuleReference;
            private string id;
            private string name;
            private Models.LoyaltyProgramRewardDefinition definition;
            private string createdAt;

            /// <summary>
            /// Initialize Builder for LoyaltyProgramRewardTier.
            /// </summary>
            /// <param name="points"> points. </param>
            /// <param name="pricingRuleReference"> pricingRuleReference. </param>
            public Builder(
                int points,
                Models.CatalogObjectReference pricingRuleReference)
            {
                this.points = points;
                this.pricingRuleReference = pricingRuleReference;
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
             /// PricingRuleReference.
             /// </summary>
             /// <param name="pricingRuleReference"> pricingRuleReference. </param>
             /// <returns> Builder. </returns>
            public Builder PricingRuleReference(Models.CatalogObjectReference pricingRuleReference)
            {
                this.pricingRuleReference = pricingRuleReference;
                return this;
            }

             /// <summary>
             /// Id.
             /// </summary>
             /// <param name="id"> id. </param>
             /// <returns> Builder. </returns>
            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

             /// <summary>
             /// Name.
             /// </summary>
             /// <param name="name"> name. </param>
             /// <returns> Builder. </returns>
            public Builder Name(string name)
            {
                this.name = name;
                return this;
            }

             /// <summary>
             /// Definition.
             /// </summary>
             /// <param name="definition"> definition. </param>
             /// <returns> Builder. </returns>
            public Builder Definition(Models.LoyaltyProgramRewardDefinition definition)
            {
                this.definition = definition;
                return this;
            }

             /// <summary>
             /// CreatedAt.
             /// </summary>
             /// <param name="createdAt"> createdAt. </param>
             /// <returns> Builder. </returns>
            public Builder CreatedAt(string createdAt)
            {
                this.createdAt = createdAt;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> LoyaltyProgramRewardTier. </returns>
            public LoyaltyProgramRewardTier Build()
            {
                return new LoyaltyProgramRewardTier(
                    this.points,
                    this.pricingRuleReference,
                    this.id,
                    this.name,
                    this.definition,
                    this.createdAt);
            }
        }
    }
}