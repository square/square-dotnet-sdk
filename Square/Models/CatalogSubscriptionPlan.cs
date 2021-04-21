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
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogSubscriptionPlan"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="phases">phases.</param>
        public CatalogSubscriptionPlan(
            string name = null,
            IList<Models.SubscriptionPhase> phases = null)
        {
            this.Name = name;
            this.Phases = phases;
        }

        /// <summary>
        /// The name of the plan.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; }

        /// <summary>
        /// A list of SubscriptionPhase containing the [SubscriptionPhase]($m/SubscriptionPhase) for this plan.
        /// </summary>
        [JsonProperty("phases", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.SubscriptionPhase> Phases { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogSubscriptionPlan : ({string.Join(", ", toStringOutput)})";
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

            if (this.Name != null)
            {
               hashCode += this.Name.GetHashCode();
            }

            if (this.Phases != null)
            {
               hashCode += this.Phases.GetHashCode();
            }

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
            var builder = new Builder()
                .Name(this.Name)
                .Phases(this.Phases);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string name;
            private IList<Models.SubscriptionPhase> phases;

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
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogSubscriptionPlan. </returns>
            public CatalogSubscriptionPlan Build()
            {
                return new CatalogSubscriptionPlan(
                    this.name,
                    this.phases);
            }
        }
    }
}