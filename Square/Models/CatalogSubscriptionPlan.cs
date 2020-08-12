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
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// A list of SubscriptionPhase containing the [SubscriptionPhase](#type-SubscriptionPhase) for this plan.
        /// </summary>
        [JsonProperty("phases")]
        public IList<Models.SubscriptionPhase> Phases { get; }

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
            private IList<Models.SubscriptionPhase> phases = new List<Models.SubscriptionPhase>();

            public Builder() { }
            public Builder Name(string value)
            {
                name = value;
                return this;
            }

            public Builder Phases(IList<Models.SubscriptionPhase> value)
            {
                phases = value;
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