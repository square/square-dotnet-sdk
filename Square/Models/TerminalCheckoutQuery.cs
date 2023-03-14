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
    /// TerminalCheckoutQuery.
    /// </summary>
    public class TerminalCheckoutQuery
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TerminalCheckoutQuery"/> class.
        /// </summary>
        /// <param name="filter">filter.</param>
        /// <param name="sort">sort.</param>
        public TerminalCheckoutQuery(
            Models.TerminalCheckoutQueryFilter filter = null,
            Models.TerminalCheckoutQuerySort sort = null)
        {
            this.Filter = filter;
            this.Sort = sort;
        }

        /// <summary>
        /// Gets or sets Filter.
        /// </summary>
        [JsonProperty("filter", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TerminalCheckoutQueryFilter Filter { get; }

        /// <summary>
        /// Gets or sets Sort.
        /// </summary>
        [JsonProperty("sort", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TerminalCheckoutQuerySort Sort { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"TerminalCheckoutQuery : ({string.Join(", ", toStringOutput)})";
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

            return obj is TerminalCheckoutQuery other &&
                ((this.Filter == null && other.Filter == null) || (this.Filter?.Equals(other.Filter) == true)) &&
                ((this.Sort == null && other.Sort == null) || (this.Sort?.Equals(other.Sort) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 2068917898;
            hashCode = HashCode.Combine(this.Filter, this.Sort);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Filter = {(this.Filter == null ? "null" : this.Filter.ToString())}");
            toStringOutput.Add($"this.Sort = {(this.Sort == null ? "null" : this.Sort.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Filter(this.Filter)
                .Sort(this.Sort);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.TerminalCheckoutQueryFilter filter;
            private Models.TerminalCheckoutQuerySort sort;

             /// <summary>
             /// Filter.
             /// </summary>
             /// <param name="filter"> filter. </param>
             /// <returns> Builder. </returns>
            public Builder Filter(Models.TerminalCheckoutQueryFilter filter)
            {
                this.filter = filter;
                return this;
            }

             /// <summary>
             /// Sort.
             /// </summary>
             /// <param name="sort"> sort. </param>
             /// <returns> Builder. </returns>
            public Builder Sort(Models.TerminalCheckoutQuerySort sort)
            {
                this.sort = sort;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> TerminalCheckoutQuery. </returns>
            public TerminalCheckoutQuery Build()
            {
                return new TerminalCheckoutQuery(
                    this.filter,
                    this.sort);
            }
        }
    }
}