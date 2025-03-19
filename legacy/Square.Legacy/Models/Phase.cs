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
using Square.Legacy;
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// Phase.
    /// </summary>
    public class Phase
    {
        private readonly Dictionary<string, bool> shouldSerialize;

        /// <summary>
        /// Initializes a new instance of the <see cref="Phase"/> class.
        /// </summary>
        /// <param name="uid">uid.</param>
        /// <param name="ordinal">ordinal.</param>
        /// <param name="orderTemplateId">order_template_id.</param>
        /// <param name="planPhaseUid">plan_phase_uid.</param>
        public Phase(
            string uid = null,
            long? ordinal = null,
            string orderTemplateId = null,
            string planPhaseUid = null
        )
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "uid", false },
                { "ordinal", false },
                { "order_template_id", false },
                { "plan_phase_uid", false },
            };

            if (uid != null)
            {
                shouldSerialize["uid"] = true;
                this.Uid = uid;
            }

            if (ordinal != null)
            {
                shouldSerialize["ordinal"] = true;
                this.Ordinal = ordinal;
            }

            if (orderTemplateId != null)
            {
                shouldSerialize["order_template_id"] = true;
                this.OrderTemplateId = orderTemplateId;
            }

            if (planPhaseUid != null)
            {
                shouldSerialize["plan_phase_uid"] = true;
                this.PlanPhaseUid = planPhaseUid;
            }
        }

        internal Phase(
            Dictionary<string, bool> shouldSerialize,
            string uid = null,
            long? ordinal = null,
            string orderTemplateId = null,
            string planPhaseUid = null
        )
        {
            this.shouldSerialize = shouldSerialize;
            Uid = uid;
            Ordinal = ordinal;
            OrderTemplateId = orderTemplateId;
            PlanPhaseUid = planPhaseUid;
        }

        /// <summary>
        /// id of subscription phase
        /// </summary>
        [JsonProperty("uid")]
        public string Uid { get; }

        /// <summary>
        /// index of phase in total subscription plan
        /// </summary>
        [JsonProperty("ordinal")]
        public long? Ordinal { get; }

        /// <summary>
        /// id of order to be used in billing
        /// </summary>
        [JsonProperty("order_template_id")]
        public string OrderTemplateId { get; }

        /// <summary>
        /// the uid from the plan's phase in catalog
        /// </summary>
        [JsonProperty("plan_phase_uid")]
        public string PlanPhaseUid { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"Phase : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeUid()
        {
            return this.shouldSerialize["uid"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeOrdinal()
        {
            return this.shouldSerialize["ordinal"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeOrderTemplateId()
        {
            return this.shouldSerialize["order_template_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePlanPhaseUid()
        {
            return this.shouldSerialize["plan_phase_uid"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is Phase other
                && (this.Uid == null && other.Uid == null || this.Uid?.Equals(other.Uid) == true)
                && (
                    this.Ordinal == null && other.Ordinal == null
                    || this.Ordinal?.Equals(other.Ordinal) == true
                )
                && (
                    this.OrderTemplateId == null && other.OrderTemplateId == null
                    || this.OrderTemplateId?.Equals(other.OrderTemplateId) == true
                )
                && (
                    this.PlanPhaseUid == null && other.PlanPhaseUid == null
                    || this.PlanPhaseUid?.Equals(other.PlanPhaseUid) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1608566409;
            hashCode = HashCode.Combine(
                hashCode,
                this.Uid,
                this.Ordinal,
                this.OrderTemplateId,
                this.PlanPhaseUid
            );

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Uid = {this.Uid ?? "null"}");
            toStringOutput.Add(
                $"this.Ordinal = {(this.Ordinal == null ? "null" : this.Ordinal.ToString())}"
            );
            toStringOutput.Add($"this.OrderTemplateId = {this.OrderTemplateId ?? "null"}");
            toStringOutput.Add($"this.PlanPhaseUid = {this.PlanPhaseUid ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Uid(this.Uid)
                .Ordinal(this.Ordinal)
                .OrderTemplateId(this.OrderTemplateId)
                .PlanPhaseUid(this.PlanPhaseUid);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "uid", false },
                { "ordinal", false },
                { "order_template_id", false },
                { "plan_phase_uid", false },
            };

            private string uid;
            private long? ordinal;
            private string orderTemplateId;
            private string planPhaseUid;

            /// <summary>
            /// Uid.
            /// </summary>
            /// <param name="uid"> uid. </param>
            /// <returns> Builder. </returns>
            public Builder Uid(string uid)
            {
                shouldSerialize["uid"] = true;
                this.uid = uid;
                return this;
            }

            /// <summary>
            /// Ordinal.
            /// </summary>
            /// <param name="ordinal"> ordinal. </param>
            /// <returns> Builder. </returns>
            public Builder Ordinal(long? ordinal)
            {
                shouldSerialize["ordinal"] = true;
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
            /// PlanPhaseUid.
            /// </summary>
            /// <param name="planPhaseUid"> planPhaseUid. </param>
            /// <returns> Builder. </returns>
            public Builder PlanPhaseUid(string planPhaseUid)
            {
                shouldSerialize["plan_phase_uid"] = true;
                this.planPhaseUid = planPhaseUid;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetUid()
            {
                this.shouldSerialize["uid"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetOrdinal()
            {
                this.shouldSerialize["ordinal"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetOrderTemplateId()
            {
                this.shouldSerialize["order_template_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetPlanPhaseUid()
            {
                this.shouldSerialize["plan_phase_uid"] = false;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> Phase. </returns>
            public Phase Build()
            {
                return new Phase(
                    shouldSerialize,
                    this.uid,
                    this.ordinal,
                    this.orderTemplateId,
                    this.planPhaseUid
                );
            }
        }
    }
}
