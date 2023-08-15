namespace Square.Models
{
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

    /// <summary>
    /// LoyaltyEventTypeFilter.
    /// </summary>
    public class LoyaltyEventTypeFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoyaltyEventTypeFilter"/> class.
        /// </summary>
        /// <param name="types">types.</param>
        public LoyaltyEventTypeFilter(
            IList<string> types)
        {
            this.Types = types;
        }

        /// <summary>
        /// The loyalty event types used to filter the result.
        /// If multiple values are specified, the endpoint uses a
        /// logical OR to combine them.
        /// See [LoyaltyEventType](#type-loyaltyeventtype) for possible values
        /// </summary>
        [JsonProperty("types")]
        public IList<string> Types { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LoyaltyEventTypeFilter : ({string.Join(", ", toStringOutput)})";
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
            return obj is LoyaltyEventTypeFilter other &&                ((this.Types == null && other.Types == null) || (this.Types?.Equals(other.Types) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 474693041;
            hashCode = HashCode.Combine(this.Types);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Types = {(this.Types == null ? "null" : $"[{string.Join(", ", this.Types)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Types);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<string> types;

            public Builder(
                IList<string> types)
            {
                this.types = types;
            }

             /// <summary>
             /// Types.
             /// </summary>
             /// <param name="types"> types. </param>
             /// <returns> Builder. </returns>
            public Builder Types(IList<string> types)
            {
                this.types = types;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> LoyaltyEventTypeFilter. </returns>
            public LoyaltyEventTypeFilter Build()
            {
                return new LoyaltyEventTypeFilter(
                    this.types);
            }
        }
    }
}