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
    /// CatalogSubscriptionPlanVariation.
    /// </summary>
    public class CatalogSubscriptionPlanVariation
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogSubscriptionPlanVariation"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="phases">phases.</param>
        /// <param name="subscriptionPlanId">subscription_plan_id.</param>
        public CatalogSubscriptionPlanVariation(
            string name,
            IList<Models.SubscriptionPhase> phases,
            string subscriptionPlanId = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "subscription_plan_id", false }
            };

            this.Name = name;
            this.Phases = phases;
            if (subscriptionPlanId != null)
            {
                shouldSerialize["subscription_plan_id"] = true;
                this.SubscriptionPlanId = subscriptionPlanId;
            }

        }
        internal CatalogSubscriptionPlanVariation(Dictionary<string, bool> shouldSerialize,
            string name,
            IList<Models.SubscriptionPhase> phases,
            string subscriptionPlanId = null)
        {
            this.shouldSerialize = shouldSerialize;
            Name = name;
            Phases = phases;
            SubscriptionPlanId = subscriptionPlanId;
        }

        /// <summary>
        /// The name of the plan variation.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// A list containing each [SubscriptionPhase](entity:SubscriptionPhase) for this plan variation.
        /// </summary>
        [JsonProperty("phases")]
        public IList<Models.SubscriptionPhase> Phases { get; }

        /// <summary>
        /// The id of the subscription plan, if there is one.
        /// </summary>
        [JsonProperty("subscription_plan_id")]
        public string SubscriptionPlanId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogSubscriptionPlanVariation : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSubscriptionPlanId()
        {
            return this.shouldSerialize["subscription_plan_id"];
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
            return obj is CatalogSubscriptionPlanVariation other &&                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.Phases == null && other.Phases == null) || (this.Phases?.Equals(other.Phases) == true)) &&
                ((this.SubscriptionPlanId == null && other.SubscriptionPlanId == null) || (this.SubscriptionPlanId?.Equals(other.SubscriptionPlanId) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -715027377;
            hashCode = HashCode.Combine(this.Name, this.Phases, this.SubscriptionPlanId);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name == string.Empty ? "" : this.Name)}");
            toStringOutput.Add($"this.Phases = {(this.Phases == null ? "null" : $"[{string.Join(", ", this.Phases)} ]")}");
            toStringOutput.Add($"this.SubscriptionPlanId = {(this.SubscriptionPlanId == null ? "null" : this.SubscriptionPlanId == string.Empty ? "" : this.SubscriptionPlanId)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Name,
                this.Phases)
                .SubscriptionPlanId(this.SubscriptionPlanId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "subscription_plan_id", false },
            };

            private string name;
            private IList<Models.SubscriptionPhase> phases;
            private string subscriptionPlanId;

            public Builder(
                string name,
                IList<Models.SubscriptionPhase> phases)
            {
                this.name = name;
                this.phases = phases;
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
             /// Phases.
             /// </summary>
             /// <param name="phases"> phases. </param>
             /// <returns> Builder. </returns>
            public Builder Phases(IList<Models.SubscriptionPhase> phases)
            {
                this.phases = phases;
                return this;
            }

             /// <summary>
             /// SubscriptionPlanId.
             /// </summary>
             /// <param name="subscriptionPlanId"> subscriptionPlanId. </param>
             /// <returns> Builder. </returns>
            public Builder SubscriptionPlanId(string subscriptionPlanId)
            {
                shouldSerialize["subscription_plan_id"] = true;
                this.subscriptionPlanId = subscriptionPlanId;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetSubscriptionPlanId()
            {
                this.shouldSerialize["subscription_plan_id"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogSubscriptionPlanVariation. </returns>
            public CatalogSubscriptionPlanVariation Build()
            {
                return new CatalogSubscriptionPlanVariation(shouldSerialize,
                    this.name,
                    this.phases,
                    this.subscriptionPlanId);
            }
        }
    }
}