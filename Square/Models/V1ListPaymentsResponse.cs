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
    /// V1ListPaymentsResponse.
    /// </summary>
    public class V1ListPaymentsResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="V1ListPaymentsResponse"/> class.
        /// </summary>
        /// <param name="items">items.</param>
        public V1ListPaymentsResponse(
            IList<Models.V1Payment> items = null)
        {
            this.Items = items;
        }

        /// <summary>
        /// Gets or sets Items.
        /// </summary>
        [JsonProperty("items", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.V1Payment> Items { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1ListPaymentsResponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is V1ListPaymentsResponse other &&
                ((this.Items == null && other.Items == null) || (this.Items?.Equals(other.Items) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -722526871;
            hashCode = HashCode.Combine(this.Items);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Items = {(this.Items == null ? "null" : $"[{string.Join(", ", this.Items)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Items(this.Items);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.V1Payment> items;

             /// <summary>
             /// Items.
             /// </summary>
             /// <param name="items"> items. </param>
             /// <returns> Builder. </returns>
            public Builder Items(IList<Models.V1Payment> items)
            {
                this.items = items;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> V1ListPaymentsResponse. </returns>
            public V1ListPaymentsResponse Build()
            {
                return new V1ListPaymentsResponse(
                    this.items);
            }
        }
    }
}