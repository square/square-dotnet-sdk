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
    /// RetrieveSubscriptionRequest.
    /// </summary>
    public class RetrieveSubscriptionRequest
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="RetrieveSubscriptionRequest"/> class.
        /// </summary>
        /// <param name="include">include.</param>
        public RetrieveSubscriptionRequest(
            string include = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "include", false }
            };

            if (include != null)
            {
                shouldSerialize["include"] = true;
                this.Include = include;
            }
        }

        internal RetrieveSubscriptionRequest(
            Dictionary<string, bool> shouldSerialize,
            string include = null)
        {
            this.shouldSerialize = shouldSerialize;
            Include = include;
        }

        /// <summary>
        /// A query parameter to specify related information to be included in the response.
        /// The supported query parameter values are:
        /// - `actions`: to include scheduled actions on the targeted subscription.
        /// </summary>
        [JsonProperty("include")]
        public string Include { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"RetrieveSubscriptionRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeInclude()
        {
            return this.shouldSerialize["include"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is RetrieveSubscriptionRequest other &&
                (this.Include == null && other.Include == null ||
                 this.Include?.Equals(other.Include) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 791482379;
            hashCode = HashCode.Combine(hashCode, this.Include);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Include = {this.Include ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Include(this.Include);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "include", false },
            };

            private string include;

             /// <summary>
             /// Include.
             /// </summary>
             /// <param name="include"> include. </param>
             /// <returns> Builder. </returns>
            public Builder Include(string include)
            {
                shouldSerialize["include"] = true;
                this.include = include;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetInclude()
            {
                this.shouldSerialize["include"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> RetrieveSubscriptionRequest. </returns>
            public RetrieveSubscriptionRequest Build()
            {
                return new RetrieveSubscriptionRequest(
                    shouldSerialize,
                    this.include);
            }
        }
    }
}