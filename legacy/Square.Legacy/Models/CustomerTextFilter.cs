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
    /// CustomerTextFilter.
    /// </summary>
    public class CustomerTextFilter
    {
        private readonly Dictionary<string, bool> shouldSerialize;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerTextFilter"/> class.
        /// </summary>
        /// <param name="exact">exact.</param>
        /// <param name="fuzzy">fuzzy.</param>
        public CustomerTextFilter(string exact = null, string fuzzy = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "exact", false },
                { "fuzzy", false },
            };

            if (exact != null)
            {
                shouldSerialize["exact"] = true;
                this.Exact = exact;
            }

            if (fuzzy != null)
            {
                shouldSerialize["fuzzy"] = true;
                this.Fuzzy = fuzzy;
            }
        }

        internal CustomerTextFilter(
            Dictionary<string, bool> shouldSerialize,
            string exact = null,
            string fuzzy = null
        )
        {
            this.shouldSerialize = shouldSerialize;
            Exact = exact;
            Fuzzy = fuzzy;
        }

        /// <summary>
        /// Use the exact filter to select customers whose attributes match exactly the specified query.
        /// </summary>
        [JsonProperty("exact")]
        public string Exact { get; }

        /// <summary>
        /// Use the fuzzy filter to select customers whose attributes match the specified query
        /// in a fuzzy manner. When the fuzzy option is used, search queries are tokenized, and then
        /// each query token must be matched somewhere in the searched attribute. For single token queries,
        /// this is effectively the same behavior as a partial match operation.
        /// </summary>
        [JsonProperty("fuzzy")]
        public string Fuzzy { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"CustomerTextFilter : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeExact()
        {
            return this.shouldSerialize["exact"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeFuzzy()
        {
            return this.shouldSerialize["fuzzy"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is CustomerTextFilter other
                && (
                    this.Exact == null && other.Exact == null
                    || this.Exact?.Equals(other.Exact) == true
                )
                && (
                    this.Fuzzy == null && other.Fuzzy == null
                    || this.Fuzzy?.Equals(other.Fuzzy) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1444472756;
            hashCode = HashCode.Combine(hashCode, this.Exact, this.Fuzzy);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Exact = {this.Exact ?? "null"}");
            toStringOutput.Add($"this.Fuzzy = {this.Fuzzy ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder().Exact(this.Exact).Fuzzy(this.Fuzzy);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "exact", false },
                { "fuzzy", false },
            };

            private string exact;
            private string fuzzy;

            /// <summary>
            /// Exact.
            /// </summary>
            /// <param name="exact"> exact. </param>
            /// <returns> Builder. </returns>
            public Builder Exact(string exact)
            {
                shouldSerialize["exact"] = true;
                this.exact = exact;
                return this;
            }

            /// <summary>
            /// Fuzzy.
            /// </summary>
            /// <param name="fuzzy"> fuzzy. </param>
            /// <returns> Builder. </returns>
            public Builder Fuzzy(string fuzzy)
            {
                shouldSerialize["fuzzy"] = true;
                this.fuzzy = fuzzy;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetExact()
            {
                this.shouldSerialize["exact"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetFuzzy()
            {
                this.shouldSerialize["fuzzy"] = false;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CustomerTextFilter. </returns>
            public CustomerTextFilter Build()
            {
                return new CustomerTextFilter(shouldSerialize, this.exact, this.fuzzy);
            }
        }
    }
}
