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
    /// CatalogSubscriptionPlan.
    /// </summary>
    public class CatalogSubscriptionPlan
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogSubscriptionPlan"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="phases">phases.</param>
        public CatalogSubscriptionPlan(
            string name,
            IList<Models.SubscriptionPhase> phases = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "phases", false }
            };

            this.Name = name;
            if (phases != null)
            {
                shouldSerialize["phases"] = true;
                this.Phases = phases;
            }

        }
        internal CatalogSubscriptionPlan(Dictionary<string, bool> shouldSerialize,
            string name,
            IList<Models.SubscriptionPhase> phases = null)
        {
            this.shouldSerialize = shouldSerialize;
            Name = name;
            Phases = phases;
        }

        /// <summary>
        /// The name of the plan.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// A list of SubscriptionPhase containing the [SubscriptionPhase](entity:SubscriptionPhase) for this plan.
        /// This field it required. Not including this field will throw a REQUIRED_FIELD_MISSING error
        /// </summary>
        [JsonProperty("phases")]
        public IList<Models.SubscriptionPhase> Phases { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogSubscriptionPlan : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePhases()
        {
            return this.shouldSerialize["phases"];
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

            return obj is CatalogSubscriptionPlan other &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.Phases == null && other.Phases == null) || (this.Phases?.Equals(other.Phases) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1144454728;
            hashCode = HashCode.Combine(this.Name, this.Phases);

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
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Name)
                .Phases(this.Phases);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "phases", false },
            };

            private string name;
            private IList<Models.SubscriptionPhase> phases;

            public Builder(
                string name)
            {
                this.name = name;
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
                shouldSerialize["phases"] = true;
                this.phases = phases;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetPhases()
            {
                this.shouldSerialize["phases"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogSubscriptionPlan. </returns>
            public CatalogSubscriptionPlan Build()
            {
                return new CatalogSubscriptionPlan(shouldSerialize,
                    this.name,
                    this.phases);
            }
        }
    }
}