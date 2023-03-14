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
    /// SwapPlanRequest.
    /// </summary>
    public class SwapPlanRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SwapPlanRequest"/> class.
        /// </summary>
        /// <param name="newPlanId">new_plan_id.</param>
        public SwapPlanRequest(
            string newPlanId)
        {
            this.NewPlanId = newPlanId;
        }

        /// <summary>
        /// The ID of the new subscription plan.
        /// </summary>
        [JsonProperty("new_plan_id")]
        public string NewPlanId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SwapPlanRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is SwapPlanRequest other &&
                ((this.NewPlanId == null && other.NewPlanId == null) || (this.NewPlanId?.Equals(other.NewPlanId) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -2048496344;
            hashCode = HashCode.Combine(this.NewPlanId);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.NewPlanId = {(this.NewPlanId == null ? "null" : this.NewPlanId == string.Empty ? "" : this.NewPlanId)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.NewPlanId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string newPlanId;

            public Builder(
                string newPlanId)
            {
                this.newPlanId = newPlanId;
            }

             /// <summary>
             /// NewPlanId.
             /// </summary>
             /// <param name="newPlanId"> newPlanId. </param>
             /// <returns> Builder. </returns>
            public Builder NewPlanId(string newPlanId)
            {
                this.newPlanId = newPlanId;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> SwapPlanRequest. </returns>
            public SwapPlanRequest Build()
            {
                return new SwapPlanRequest(
                    this.newPlanId);
            }
        }
    }
}