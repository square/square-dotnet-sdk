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
    /// RiskEvaluation.
    /// </summary>
    public class RiskEvaluation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RiskEvaluation"/> class.
        /// </summary>
        /// <param name="createdAt">created_at.</param>
        /// <param name="riskLevel">risk_level.</param>
        public RiskEvaluation(string createdAt = null, string riskLevel = null)
        {
            this.CreatedAt = createdAt;
            this.RiskLevel = riskLevel;
        }

        /// <summary>
        /// The timestamp when payment risk was evaluated, in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// Gets or sets RiskLevel.
        /// </summary>
        [JsonProperty("risk_level", NullValueHandling = NullValueHandling.Ignore)]
        public string RiskLevel { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"RiskEvaluation : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is RiskEvaluation other
                && (
                    this.CreatedAt == null && other.CreatedAt == null
                    || this.CreatedAt?.Equals(other.CreatedAt) == true
                )
                && (
                    this.RiskLevel == null && other.RiskLevel == null
                    || this.RiskLevel?.Equals(other.RiskLevel) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 692810603;
            hashCode = HashCode.Combine(hashCode, this.CreatedAt, this.RiskLevel);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.CreatedAt = {this.CreatedAt ?? "null"}");
            toStringOutput.Add(
                $"this.RiskLevel = {(this.RiskLevel == null ? "null" : this.RiskLevel.ToString())}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder().CreatedAt(this.CreatedAt).RiskLevel(this.RiskLevel);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string createdAt;
            private string riskLevel;

            /// <summary>
            /// CreatedAt.
            /// </summary>
            /// <param name="createdAt"> createdAt. </param>
            /// <returns> Builder. </returns>
            public Builder CreatedAt(string createdAt)
            {
                this.createdAt = createdAt;
                return this;
            }

            /// <summary>
            /// RiskLevel.
            /// </summary>
            /// <param name="riskLevel"> riskLevel. </param>
            /// <returns> Builder. </returns>
            public Builder RiskLevel(string riskLevel)
            {
                this.riskLevel = riskLevel;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> RiskEvaluation. </returns>
            public RiskEvaluation Build()
            {
                return new RiskEvaluation(this.createdAt, this.riskLevel);
            }
        }
    }
}
