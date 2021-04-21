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
    /// FilterValue.
    /// </summary>
    public class FilterValue
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FilterValue"/> class.
        /// </summary>
        /// <param name="all">all.</param>
        /// <param name="any">any.</param>
        /// <param name="none">none.</param>
        public FilterValue(
            IList<string> all = null,
            IList<string> any = null,
            IList<string> none = null)
        {
            this.All = all;
            this.Any = any;
            this.None = none;
        }

        /// <summary>
        /// A list of terms that must be present on the field of the resource.
        /// </summary>
        [JsonProperty("all", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> All { get; }

        /// <summary>
        /// A list of terms where at least one of them must be present on the
        /// field of the resource.
        /// </summary>
        [JsonProperty("any", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> Any { get; }

        /// <summary>
        /// A list of terms that must not be present on the field the resource
        /// </summary>
        [JsonProperty("none", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> None { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"FilterValue : ({string.Join(", ", toStringOutput)})";
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

            return obj is FilterValue other &&
                ((this.All == null && other.All == null) || (this.All?.Equals(other.All) == true)) &&
                ((this.Any == null && other.Any == null) || (this.Any?.Equals(other.Any) == true)) &&
                ((this.None == null && other.None == null) || (this.None?.Equals(other.None) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 547827750;

            if (this.All != null)
            {
               hashCode += this.All.GetHashCode();
            }

            if (this.Any != null)
            {
               hashCode += this.Any.GetHashCode();
            }

            if (this.None != null)
            {
               hashCode += this.None.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.All = {(this.All == null ? "null" : $"[{string.Join(", ", this.All)} ]")}");
            toStringOutput.Add($"this.Any = {(this.Any == null ? "null" : $"[{string.Join(", ", this.Any)} ]")}");
            toStringOutput.Add($"this.None = {(this.None == null ? "null" : $"[{string.Join(", ", this.None)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .All(this.All)
                .Any(this.Any)
                .None(this.None);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<string> all;
            private IList<string> any;
            private IList<string> none;

             /// <summary>
             /// All.
             /// </summary>
             /// <param name="all"> all. </param>
             /// <returns> Builder. </returns>
            public Builder All(IList<string> all)
            {
                this.all = all;
                return this;
            }

             /// <summary>
             /// Any.
             /// </summary>
             /// <param name="any"> any. </param>
             /// <returns> Builder. </returns>
            public Builder Any(IList<string> any)
            {
                this.any = any;
                return this;
            }

             /// <summary>
             /// None.
             /// </summary>
             /// <param name="none"> none. </param>
             /// <returns> Builder. </returns>
            public Builder None(IList<string> none)
            {
                this.none = none;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> FilterValue. </returns>
            public FilterValue Build()
            {
                return new FilterValue(
                    this.all,
                    this.any,
                    this.none);
            }
        }
    }
}