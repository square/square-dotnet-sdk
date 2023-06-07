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
    /// PhaseInput.
    /// </summary>
    public class PhaseInput
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="PhaseInput"/> class.
        /// </summary>
        /// <param name="ordinal">ordinal.</param>
        /// <param name="orderTemplateId">order_template_id.</param>
        public PhaseInput(
            int ordinal,
            string orderTemplateId = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "order_template_id", false }
            };

            this.Ordinal = ordinal;
            if (orderTemplateId != null)
            {
                shouldSerialize["order_template_id"] = true;
                this.OrderTemplateId = orderTemplateId;
            }

        }
        internal PhaseInput(Dictionary<string, bool> shouldSerialize,
            int ordinal,
            string orderTemplateId = null)
        {
            this.shouldSerialize = shouldSerialize;
            Ordinal = ordinal;
            OrderTemplateId = orderTemplateId;
        }

        /// <summary>
        /// index of phase in total subscription plan
        /// </summary>
        [JsonProperty("ordinal")]
        public int Ordinal { get; }

        /// <summary>
        /// id of order to be used in billing
        /// </summary>
        [JsonProperty("order_template_id")]
        public string OrderTemplateId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"PhaseInput : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeOrderTemplateId()
        {
            return this.shouldSerialize["order_template_id"];
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
            return obj is PhaseInput other &&                this.Ordinal.Equals(other.Ordinal) &&
                ((this.OrderTemplateId == null && other.OrderTemplateId == null) || (this.OrderTemplateId?.Equals(other.OrderTemplateId) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -2074738993;
            hashCode = HashCode.Combine(this.Ordinal, this.OrderTemplateId);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Ordinal = {this.Ordinal}");
            toStringOutput.Add($"this.OrderTemplateId = {(this.OrderTemplateId == null ? "null" : this.OrderTemplateId == string.Empty ? "" : this.OrderTemplateId)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Ordinal)
                .OrderTemplateId(this.OrderTemplateId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "order_template_id", false },
            };

            private int ordinal;
            private string orderTemplateId;

            public Builder(
                int ordinal)
            {
                this.ordinal = ordinal;
            }

             /// <summary>
             /// Ordinal.
             /// </summary>
             /// <param name="ordinal"> ordinal. </param>
             /// <returns> Builder. </returns>
            public Builder Ordinal(int ordinal)
            {
                this.ordinal = ordinal;
                return this;
            }

             /// <summary>
             /// OrderTemplateId.
             /// </summary>
             /// <param name="orderTemplateId"> orderTemplateId. </param>
             /// <returns> Builder. </returns>
            public Builder OrderTemplateId(string orderTemplateId)
            {
                shouldSerialize["order_template_id"] = true;
                this.orderTemplateId = orderTemplateId;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetOrderTemplateId()
            {
                this.shouldSerialize["order_template_id"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> PhaseInput. </returns>
            public PhaseInput Build()
            {
                return new PhaseInput(shouldSerialize,
                    this.ordinal,
                    this.orderTemplateId);
            }
        }
    }
}