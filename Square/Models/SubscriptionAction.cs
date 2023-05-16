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
    /// SubscriptionAction.
    /// </summary>
    public class SubscriptionAction
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionAction"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="type">type.</param>
        /// <param name="effectiveDate">effective_date.</param>
        /// <param name="newPlanId">new_plan_id.</param>
        public SubscriptionAction(
            string id = null,
            string type = null,
            string effectiveDate = null,
            string newPlanId = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "effective_date", false },
                { "new_plan_id", false }
            };

            this.Id = id;
            this.Type = type;
            if (effectiveDate != null)
            {
                shouldSerialize["effective_date"] = true;
                this.EffectiveDate = effectiveDate;
            }

            if (newPlanId != null)
            {
                shouldSerialize["new_plan_id"] = true;
                this.NewPlanId = newPlanId;
            }

        }
        internal SubscriptionAction(Dictionary<string, bool> shouldSerialize,
            string id = null,
            string type = null,
            string effectiveDate = null,
            string newPlanId = null)
        {
            this.shouldSerialize = shouldSerialize;
            Id = id;
            Type = type;
            EffectiveDate = effectiveDate;
            NewPlanId = newPlanId;
        }

        /// <summary>
        /// The ID of an action scoped to a subscription.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// Supported types of an action as a pending change to a subscription.
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; }

        /// <summary>
        /// The `YYYY-MM-DD`-formatted date when the action occurs on the subscription.
        /// </summary>
        [JsonProperty("effective_date")]
        public string EffectiveDate { get; }

        /// <summary>
        /// The target subscription plan a subscription switches to, for a `SWAP_PLAN` action.
        /// </summary>
        [JsonProperty("new_plan_id")]
        public string NewPlanId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SubscriptionAction : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEffectiveDate()
        {
            return this.shouldSerialize["effective_date"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeNewPlanId()
        {
            return this.shouldSerialize["new_plan_id"];
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
            return obj is SubscriptionAction other &&                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true)) &&
                ((this.EffectiveDate == null && other.EffectiveDate == null) || (this.EffectiveDate?.Equals(other.EffectiveDate) == true)) &&
                ((this.NewPlanId == null && other.NewPlanId == null) || (this.NewPlanId?.Equals(other.NewPlanId) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1007039208;
            hashCode = HashCode.Combine(this.Id, this.Type, this.EffectiveDate, this.NewPlanId);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type.ToString())}");
            toStringOutput.Add($"this.EffectiveDate = {(this.EffectiveDate == null ? "null" : this.EffectiveDate == string.Empty ? "" : this.EffectiveDate)}");
            toStringOutput.Add($"this.NewPlanId = {(this.NewPlanId == null ? "null" : this.NewPlanId == string.Empty ? "" : this.NewPlanId)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(this.Id)
                .Type(this.Type)
                .EffectiveDate(this.EffectiveDate)
                .NewPlanId(this.NewPlanId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "effective_date", false },
                { "new_plan_id", false },
            };

            private string id;
            private string type;
            private string effectiveDate;
            private string newPlanId;

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
             /// Type.
             /// </summary>
             /// <param name="type"> type. </param>
             /// <returns> Builder. </returns>
            public Builder Type(string type)
            {
                this.type = type;
                return this;
            }

             /// <summary>
             /// EffectiveDate.
             /// </summary>
             /// <param name="effectiveDate"> effectiveDate. </param>
             /// <returns> Builder. </returns>
            public Builder EffectiveDate(string effectiveDate)
            {
                shouldSerialize["effective_date"] = true;
                this.effectiveDate = effectiveDate;
                return this;
            }

             /// <summary>
             /// NewPlanId.
             /// </summary>
             /// <param name="newPlanId"> newPlanId. </param>
             /// <returns> Builder. </returns>
            public Builder NewPlanId(string newPlanId)
            {
                shouldSerialize["new_plan_id"] = true;
                this.newPlanId = newPlanId;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetEffectiveDate()
            {
                this.shouldSerialize["effective_date"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetNewPlanId()
            {
                this.shouldSerialize["new_plan_id"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> SubscriptionAction. </returns>
            public SubscriptionAction Build()
            {
                return new SubscriptionAction(shouldSerialize,
                    this.id,
                    this.type,
                    this.effectiveDate,
                    this.newPlanId);
            }
        }
    }
}