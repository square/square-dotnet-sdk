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
    /// V1ListOrdersResponse.
    /// </summary>
    public class V1ListOrdersResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="V1ListOrdersResponse"/> class.
        /// </summary>
        /// <param name="items">items.</param>
        public V1ListOrdersResponse(IList<Models.V1Order> items = null)
        {
            this.Items = items;
        }

        /// <summary>
        /// Gets or sets Items.
        /// </summary>
        [JsonProperty("items", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.V1Order> Items { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"V1ListOrdersResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is V1ListOrdersResponse other
                && (
                    this.Items == null && other.Items == null
                    || this.Items?.Equals(other.Items) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 166605431;
            hashCode = HashCode.Combine(hashCode, this.Items);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add(
                $"this.Items = {(this.Items == null ? "null" : $"[{string.Join(", ", this.Items)} ]")}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder().Items(this.Items);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.V1Order> items;

            /// <summary>
            /// Items.
            /// </summary>
            /// <param name="items"> items. </param>
            /// <returns> Builder. </returns>
            public Builder Items(IList<Models.V1Order> items)
            {
                this.items = items;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> V1ListOrdersResponse. </returns>
            public V1ListOrdersResponse Build()
            {
                return new V1ListOrdersResponse(this.items);
            }
        }
    }
}
