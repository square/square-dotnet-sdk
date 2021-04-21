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
    /// CustomerTextFilter.
    /// </summary>
    public class CustomerTextFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerTextFilter"/> class.
        /// </summary>
        /// <param name="exact">exact.</param>
        /// <param name="fuzzy">fuzzy.</param>
        public CustomerTextFilter(
            string exact = null,
            string fuzzy = null)
        {
            this.Exact = exact;
            this.Fuzzy = fuzzy;
        }

        /// <summary>
        /// Use the exact filter to select customers whose attributes match exactly the specified query.
        /// </summary>
        [JsonProperty("exact", NullValueHandling = NullValueHandling.Ignore)]
        public string Exact { get; }

        /// <summary>
        /// Use the fuzzy filter to select customers whose attributes match the specified query
        /// in a fuzzy manner. When the fuzzy option is used, search queries are tokenized, and then
        /// each query token must be matched somewhere in the searched attribute. For single token queries,
        /// this is effectively the same behavior as a partial match operation.
        /// </summary>
        [JsonProperty("fuzzy", NullValueHandling = NullValueHandling.Ignore)]
        public string Fuzzy { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CustomerTextFilter : ({string.Join(", ", toStringOutput)})";
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

            return obj is CustomerTextFilter other &&
                ((this.Exact == null && other.Exact == null) || (this.Exact?.Equals(other.Exact) == true)) &&
                ((this.Fuzzy == null && other.Fuzzy == null) || (this.Fuzzy?.Equals(other.Fuzzy) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1444472756;

            if (this.Exact != null)
            {
               hashCode += this.Exact.GetHashCode();
            }

            if (this.Fuzzy != null)
            {
               hashCode += this.Fuzzy.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Exact = {(this.Exact == null ? "null" : this.Exact == string.Empty ? "" : this.Exact)}");
            toStringOutput.Add($"this.Fuzzy = {(this.Fuzzy == null ? "null" : this.Fuzzy == string.Empty ? "" : this.Fuzzy)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Exact(this.Exact)
                .Fuzzy(this.Fuzzy);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string exact;
            private string fuzzy;

             /// <summary>
             /// Exact.
             /// </summary>
             /// <param name="exact"> exact. </param>
             /// <returns> Builder. </returns>
            public Builder Exact(string exact)
            {
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
                this.fuzzy = fuzzy;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CustomerTextFilter. </returns>
            public CustomerTextFilter Build()
            {
                return new CustomerTextFilter(
                    this.exact,
                    this.fuzzy);
            }
        }
    }
}