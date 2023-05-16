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
    /// CustomerCreationSourceFilter.
    /// </summary>
    public class CustomerCreationSourceFilter
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerCreationSourceFilter"/> class.
        /// </summary>
        /// <param name="values">values.</param>
        /// <param name="rule">rule.</param>
        public CustomerCreationSourceFilter(
            IList<string> values = null,
            string rule = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "values", false }
            };

            if (values != null)
            {
                shouldSerialize["values"] = true;
                this.Values = values;
            }

            this.Rule = rule;
        }
        internal CustomerCreationSourceFilter(Dictionary<string, bool> shouldSerialize,
            IList<string> values = null,
            string rule = null)
        {
            this.shouldSerialize = shouldSerialize;
            Values = values;
            Rule = rule;
        }

        /// <summary>
        /// The list of creation sources used as filtering criteria.
        /// See [CustomerCreationSource](#type-customercreationsource) for possible values
        /// </summary>
        [JsonProperty("values")]
        public IList<string> Values { get; }

        /// <summary>
        /// Indicates whether customers should be included in, or excluded from,
        /// the result set when they match the filtering criteria.
        /// </summary>
        [JsonProperty("rule", NullValueHandling = NullValueHandling.Ignore)]
        public string Rule { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CustomerCreationSourceFilter : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeValues()
        {
            return this.shouldSerialize["values"];
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
            return obj is CustomerCreationSourceFilter other &&                ((this.Values == null && other.Values == null) || (this.Values?.Equals(other.Values) == true)) &&
                ((this.Rule == null && other.Rule == null) || (this.Rule?.Equals(other.Rule) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 2051047657;
            hashCode = HashCode.Combine(this.Values, this.Rule);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Values = {(this.Values == null ? "null" : $"[{string.Join(", ", this.Values)} ]")}");
            toStringOutput.Add($"this.Rule = {(this.Rule == null ? "null" : this.Rule.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Values(this.Values)
                .Rule(this.Rule);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "values", false },
            };

            private IList<string> values;
            private string rule;

             /// <summary>
             /// Values.
             /// </summary>
             /// <param name="values"> values. </param>
             /// <returns> Builder. </returns>
            public Builder Values(IList<string> values)
            {
                shouldSerialize["values"] = true;
                this.values = values;
                return this;
            }

             /// <summary>
             /// Rule.
             /// </summary>
             /// <param name="rule"> rule. </param>
             /// <returns> Builder. </returns>
            public Builder Rule(string rule)
            {
                this.rule = rule;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetValues()
            {
                this.shouldSerialize["values"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CustomerCreationSourceFilter. </returns>
            public CustomerCreationSourceFilter Build()
            {
                return new CustomerCreationSourceFilter(shouldSerialize,
                    this.values,
                    this.rule);
            }
        }
    }
}