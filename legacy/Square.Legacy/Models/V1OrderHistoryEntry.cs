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
    /// V1OrderHistoryEntry.
    /// </summary>
    public class V1OrderHistoryEntry
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="V1OrderHistoryEntry"/> class.
        /// </summary>
        /// <param name="action">action.</param>
        /// <param name="createdAt">created_at.</param>
        public V1OrderHistoryEntry(string action = null, string createdAt = null)
        {
            this.Action = action;
            this.CreatedAt = createdAt;
        }

        /// <summary>
        /// Gets or sets Action.
        /// </summary>
        [JsonProperty("action", NullValueHandling = NullValueHandling.Ignore)]
        public string Action { get; }

        /// <summary>
        /// The time when the action was performed, in ISO 8601 format.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"V1OrderHistoryEntry : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is V1OrderHistoryEntry other
                && (
                    this.Action == null && other.Action == null
                    || this.Action?.Equals(other.Action) == true
                )
                && (
                    this.CreatedAt == null && other.CreatedAt == null
                    || this.CreatedAt?.Equals(other.CreatedAt) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -2009518531;
            hashCode = HashCode.Combine(hashCode, this.Action, this.CreatedAt);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add(
                $"this.Action = {(this.Action == null ? "null" : this.Action.ToString())}"
            );
            toStringOutput.Add($"this.CreatedAt = {this.CreatedAt ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder().Action(this.Action).CreatedAt(this.CreatedAt);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string action;
            private string createdAt;

            /// <summary>
            /// Action.
            /// </summary>
            /// <param name="action"> action. </param>
            /// <returns> Builder. </returns>
            public Builder Action(string action)
            {
                this.action = action;
                return this;
            }

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
            /// Builds class object.
            /// </summary>
            /// <returns> V1OrderHistoryEntry. </returns>
            public V1OrderHistoryEntry Build()
            {
                return new V1OrderHistoryEntry(this.action, this.createdAt);
            }
        }
    }
}
