using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square.Http.Client;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class V1Fee 
    {
        public V1Fee(string id = null,
            string name = null,
            string rate = null,
            string calculationPhase = null,
            string adjustmentType = null,
            bool? appliesToCustomAmounts = null,
            bool? enabled = null,
            string inclusionType = null,
            string type = null,
            string v2Id = null)
        {
            Id = id;
            Name = name;
            Rate = rate;
            CalculationPhase = calculationPhase;
            AdjustmentType = adjustmentType;
            AppliesToCustomAmounts = appliesToCustomAmounts;
            Enabled = enabled;
            InclusionType = inclusionType;
            Type = type;
            V2Id = v2Id;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// The fee's unique ID.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The fee's name.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; }

        /// <summary>
        /// The rate of the fee, as a string representation of a decimal number. A value of 0.07 corresponds to a rate of 7%.
        /// </summary>
        [JsonProperty("rate", NullValueHandling = NullValueHandling.Ignore)]
        public string Rate { get; }

        /// <summary>
        /// Getter for calculation_phase
        /// </summary>
        [JsonProperty("calculation_phase", NullValueHandling = NullValueHandling.Ignore)]
        public string CalculationPhase { get; }

        /// <summary>
        /// Getter for adjustment_type
        /// </summary>
        [JsonProperty("adjustment_type", NullValueHandling = NullValueHandling.Ignore)]
        public string AdjustmentType { get; }

        /// <summary>
        /// If true, the fee applies to custom amounts entered into Square Point of Sale that are not associated with a particular item.
        /// </summary>
        [JsonProperty("applies_to_custom_amounts", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AppliesToCustomAmounts { get; }

        /// <summary>
        /// If true, the fee is applied to all appropriate items. If false, the fee is not applied at all.
        /// </summary>
        [JsonProperty("enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Enabled { get; }

        /// <summary>
        /// Getter for inclusion_type
        /// </summary>
        [JsonProperty("inclusion_type", NullValueHandling = NullValueHandling.Ignore)]
        public string InclusionType { get; }

        /// <summary>
        /// Getter for type
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; }

        /// <summary>
        /// The ID of the CatalogObject in the Connect v2 API. Objects that are shared across multiple locations share the same v2 ID.
        /// </summary>
        [JsonProperty("v2_id", NullValueHandling = NullValueHandling.Ignore)]
        public string V2Id { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(Id)
                .Name(Name)
                .Rate(Rate)
                .CalculationPhase(CalculationPhase)
                .AdjustmentType(AdjustmentType)
                .AppliesToCustomAmounts(AppliesToCustomAmounts)
                .Enabled(Enabled)
                .InclusionType(InclusionType)
                .Type(Type)
                .V2Id(V2Id);
            return builder;
        }

        public class Builder
        {
            private string id;
            private string name;
            private string rate;
            private string calculationPhase;
            private string adjustmentType;
            private bool? appliesToCustomAmounts;
            private bool? enabled;
            private string inclusionType;
            private string type;
            private string v2Id;



            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

            public Builder Name(string name)
            {
                this.name = name;
                return this;
            }

            public Builder Rate(string rate)
            {
                this.rate = rate;
                return this;
            }

            public Builder CalculationPhase(string calculationPhase)
            {
                this.calculationPhase = calculationPhase;
                return this;
            }

            public Builder AdjustmentType(string adjustmentType)
            {
                this.adjustmentType = adjustmentType;
                return this;
            }

            public Builder AppliesToCustomAmounts(bool? appliesToCustomAmounts)
            {
                this.appliesToCustomAmounts = appliesToCustomAmounts;
                return this;
            }

            public Builder Enabled(bool? enabled)
            {
                this.enabled = enabled;
                return this;
            }

            public Builder InclusionType(string inclusionType)
            {
                this.inclusionType = inclusionType;
                return this;
            }

            public Builder Type(string type)
            {
                this.type = type;
                return this;
            }

            public Builder V2Id(string v2Id)
            {
                this.v2Id = v2Id;
                return this;
            }

            public V1Fee Build()
            {
                return new V1Fee(id,
                    name,
                    rate,
                    calculationPhase,
                    adjustmentType,
                    appliesToCustomAmounts,
                    enabled,
                    inclusionType,
                    type,
                    v2Id);
            }
        }
    }
}