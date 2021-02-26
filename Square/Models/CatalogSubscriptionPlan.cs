
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
    public class CatalogSubscriptionPlan 
    {
        public CatalogSubscriptionPlan(string name = null,
            IList<Models.SubscriptionPhase> phases = null)
        {
            Name = name;
            Phases = phases;
        }

        /// <summary>
        /// The name of the plan.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; }

        /// <summary>
        /// A list of SubscriptionPhase containing the [SubscriptionPhase](#type-SubscriptionPhase) for this plan.
        /// </summary>
        [JsonProperty("phases", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.SubscriptionPhase> Phases { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogSubscriptionPlan : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Name = {(Name == null ? "null" : Name == string.Empty ? "" : Name)}");
            toStringOutput.Add($"Phases = {(Phases == null ? "null" : $"[{ string.Join(", ", Phases)} ]")}");
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

            return obj is CatalogSubscriptionPlan other &&
                ((Name == null && other.Name == null) || (Name?.Equals(other.Name) == true)) &&
                ((Phases == null && other.Phases == null) || (Phases?.Equals(other.Phases) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 1144454728;

            if (Name != null)
            {
               hashCode += Name.GetHashCode();
            }

            if (Phases != null)
            {
               hashCode += Phases.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Name(Name)
                .Phases(Phases);
            return builder;
        }

        public class Builder
        {
            private string name;
            private IList<Models.SubscriptionPhase> phases;



            public Builder Name(string name)
            {
                this.name = name;
                return this;
            }

            public Builder Phases(IList<Models.SubscriptionPhase> phases)
            {
                this.phases = phases;
                return this;
            }

            public CatalogSubscriptionPlan Build()
            {
                return new CatalogSubscriptionPlan(name,
                    phases);
            }
        }
    }
}