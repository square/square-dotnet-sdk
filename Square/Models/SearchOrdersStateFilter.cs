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
    /// SearchOrdersStateFilter.
    /// </summary>
    public class SearchOrdersStateFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchOrdersStateFilter"/> class.
        /// </summary>
        /// <param name="states">states.</param>
        public SearchOrdersStateFilter(
            IList<string> states)
        {
            this.States = states;
        }

        /// <summary>
        /// States to filter for.
        /// See [OrderState](#type-orderstate) for possible values
        /// </summary>
        [JsonProperty("states")]
        public IList<string> States { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"SearchOrdersStateFilter : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is SearchOrdersStateFilter other &&
                (this.States == null && other.States == null ||
                 this.States?.Equals(other.States) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 615021182;
            hashCode = HashCode.Combine(hashCode, this.States);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.States = {(this.States == null ? "null" : $"[{string.Join(", ", this.States)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.States);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<string> states;

            /// <summary>
            /// Initialize Builder for SearchOrdersStateFilter.
            /// </summary>
            /// <param name="states"> states. </param>
            public Builder(
                IList<string> states)
            {
                this.states = states;
            }

             /// <summary>
             /// States.
             /// </summary>
             /// <param name="states"> states. </param>
             /// <returns> Builder. </returns>
            public Builder States(IList<string> states)
            {
                this.states = states;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> SearchOrdersStateFilter. </returns>
            public SearchOrdersStateFilter Build()
            {
                return new SearchOrdersStateFilter(
                    this.states);
            }
        }
    }
}