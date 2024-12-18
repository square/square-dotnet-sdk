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

namespace Square.Models
{
    /// <summary>
    /// SwapPlanRequest.
    /// </summary>
    public class SwapPlanRequest
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="SwapPlanRequest"/> class.
        /// </summary>
        /// <param name="newPlanVariationId">new_plan_variation_id.</param>
        /// <param name="phases">phases.</param>
        public SwapPlanRequest(
            string newPlanVariationId = null,
            IList<Models.PhaseInput> phases = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "new_plan_variation_id", false },
                { "phases", false }
            };

            if (newPlanVariationId != null)
            {
                shouldSerialize["new_plan_variation_id"] = true;
                this.NewPlanVariationId = newPlanVariationId;
            }

            if (phases != null)
            {
                shouldSerialize["phases"] = true;
                this.Phases = phases;
            }
        }

        internal SwapPlanRequest(
            Dictionary<string, bool> shouldSerialize,
            string newPlanVariationId = null,
            IList<Models.PhaseInput> phases = null)
        {
            this.shouldSerialize = shouldSerialize;
            NewPlanVariationId = newPlanVariationId;
            Phases = phases;
        }

        /// <summary>
        /// The ID of the new subscription plan variation.
        /// This field is required.
        /// </summary>
        [JsonProperty("new_plan_variation_id")]
        public string NewPlanVariationId { get; }

        /// <summary>
        /// A list of PhaseInputs, to pass phase-specific information used in the swap.
        /// </summary>
        [JsonProperty("phases")]
        public IList<Models.PhaseInput> Phases { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"SwapPlanRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeNewPlanVariationId()
        {
            return this.shouldSerialize["new_plan_variation_id"];
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
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is SwapPlanRequest other &&
                (this.NewPlanVariationId == null && other.NewPlanVariationId == null ||
                 this.NewPlanVariationId?.Equals(other.NewPlanVariationId) == true) &&
                (this.Phases == null && other.Phases == null ||
                 this.Phases?.Equals(other.Phases) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 888035690;
            hashCode = HashCode.Combine(hashCode, this.NewPlanVariationId, this.Phases);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.NewPlanVariationId = {this.NewPlanVariationId ?? "null"}");
            toStringOutput.Add($"this.Phases = {(this.Phases == null ? "null" : $"[{string.Join(", ", this.Phases)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .NewPlanVariationId(this.NewPlanVariationId)
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
                { "new_plan_variation_id", false },
                { "phases", false },
            };

            private string newPlanVariationId;
            private IList<Models.PhaseInput> phases;

             /// <summary>
             /// NewPlanVariationId.
             /// </summary>
             /// <param name="newPlanVariationId"> newPlanVariationId. </param>
             /// <returns> Builder. </returns>
            public Builder NewPlanVariationId(string newPlanVariationId)
            {
                shouldSerialize["new_plan_variation_id"] = true;
                this.newPlanVariationId = newPlanVariationId;
                return this;
            }

             /// <summary>
             /// Phases.
             /// </summary>
             /// <param name="phases"> phases. </param>
             /// <returns> Builder. </returns>
            public Builder Phases(IList<Models.PhaseInput> phases)
            {
                shouldSerialize["phases"] = true;
                this.phases = phases;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetNewPlanVariationId()
            {
                this.shouldSerialize["new_plan_variation_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetPhases()
            {
                this.shouldSerialize["phases"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> SwapPlanRequest. </returns>
            public SwapPlanRequest Build()
            {
                return new SwapPlanRequest(
                    shouldSerialize,
                    this.newPlanVariationId,
                    this.phases);
            }
        }
    }
}