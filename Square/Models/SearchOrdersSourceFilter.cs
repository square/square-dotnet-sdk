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
    /// SearchOrdersSourceFilter.
    /// </summary>
    public class SearchOrdersSourceFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchOrdersSourceFilter"/> class.
        /// </summary>
        /// <param name="sourceNames">source_names.</param>
        public SearchOrdersSourceFilter(
            IList<string> sourceNames = null)
        {
            this.SourceNames = sourceNames;
        }

        /// <summary>
        /// Filters by the [Source]($m/OrderSource) `name`. The filter returns any orders
        /// with a `source.name` that matches any of the listed source names.
        /// Max: 10 source names.
        /// </summary>
        [JsonProperty("source_names", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> SourceNames { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SearchOrdersSourceFilter : ({string.Join(", ", toStringOutput)})";
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

            return obj is SearchOrdersSourceFilter other &&
                ((this.SourceNames == null && other.SourceNames == null) || (this.SourceNames?.Equals(other.SourceNames) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -530513052;

            if (this.SourceNames != null)
            {
               hashCode += this.SourceNames.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.SourceNames = {(this.SourceNames == null ? "null" : $"[{string.Join(", ", this.SourceNames)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .SourceNames(this.SourceNames);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<string> sourceNames;

             /// <summary>
             /// SourceNames.
             /// </summary>
             /// <param name="sourceNames"> sourceNames. </param>
             /// <returns> Builder. </returns>
            public Builder SourceNames(IList<string> sourceNames)
            {
                this.sourceNames = sourceNames;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> SearchOrdersSourceFilter. </returns>
            public SearchOrdersSourceFilter Build()
            {
                return new SearchOrdersSourceFilter(
                    this.sourceNames);
            }
        }
    }
}