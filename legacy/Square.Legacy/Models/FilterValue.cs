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
    /// FilterValue.
    /// </summary>
    public class FilterValue
    {
        private readonly Dictionary<string, bool> shouldSerialize;

        /// <summary>
        /// Initializes a new instance of the <see cref="FilterValue"/> class.
        /// </summary>
        /// <param name="all">all.</param>
        /// <param name="any">any.</param>
        /// <param name="none">none.</param>
        public FilterValue(
            IList<string> all = null,
            IList<string> any = null,
            IList<string> none = null
        )
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "all", false },
                { "any", false },
                { "none", false },
            };

            if (all != null)
            {
                shouldSerialize["all"] = true;
                this.All = all;
            }

            if (any != null)
            {
                shouldSerialize["any"] = true;
                this.Any = any;
            }

            if (none != null)
            {
                shouldSerialize["none"] = true;
                this.None = none;
            }
        }

        internal FilterValue(
            Dictionary<string, bool> shouldSerialize,
            IList<string> all = null,
            IList<string> any = null,
            IList<string> none = null
        )
        {
            this.shouldSerialize = shouldSerialize;
            All = all;
            Any = any;
            None = none;
        }

        /// <summary>
        /// A list of terms that must be present on the field of the resource.
        /// </summary>
        [JsonProperty("all")]
        public IList<string> All { get; }

        /// <summary>
        /// A list of terms where at least one of them must be present on the
        /// field of the resource.
        /// </summary>
        [JsonProperty("any")]
        public IList<string> Any { get; }

        /// <summary>
        /// A list of terms that must not be present on the field the resource
        /// </summary>
        [JsonProperty("none")]
        public IList<string> None { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"FilterValue : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAll()
        {
            return this.shouldSerialize["all"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAny()
        {
            return this.shouldSerialize["any"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeNone()
        {
            return this.shouldSerialize["none"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is FilterValue other
                && (this.All == null && other.All == null || this.All?.Equals(other.All) == true)
                && (this.Any == null && other.Any == null || this.Any?.Equals(other.Any) == true)
                && (
                    this.None == null && other.None == null || this.None?.Equals(other.None) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 547827750;
            hashCode = HashCode.Combine(hashCode, this.All, this.Any, this.None);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add(
                $"this.All = {(this.All == null ? "null" : $"[{string.Join(", ", this.All)} ]")}"
            );
            toStringOutput.Add(
                $"this.Any = {(this.Any == null ? "null" : $"[{string.Join(", ", this.Any)} ]")}"
            );
            toStringOutput.Add(
                $"this.None = {(this.None == null ? "null" : $"[{string.Join(", ", this.None)} ]")}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder().All(this.All).Any(this.Any).None(this.None);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "all", false },
                { "any", false },
                { "none", false },
            };

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
                shouldSerialize["all"] = true;
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
                shouldSerialize["any"] = true;
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
                shouldSerialize["none"] = true;
                this.none = none;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetAll()
            {
                this.shouldSerialize["all"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetAny()
            {
                this.shouldSerialize["any"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetNone()
            {
                this.shouldSerialize["none"] = false;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> FilterValue. </returns>
            public FilterValue Build()
            {
                return new FilterValue(shouldSerialize, this.all, this.any, this.none);
            }
        }
    }
}
