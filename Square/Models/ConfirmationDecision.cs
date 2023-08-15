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
    /// ConfirmationDecision.
    /// </summary>
    public class ConfirmationDecision
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfirmationDecision"/> class.
        /// </summary>
        /// <param name="hasAgreed">has_agreed.</param>
        public ConfirmationDecision(
            bool? hasAgreed = null)
        {
            this.HasAgreed = hasAgreed;
        }

        /// <summary>
        /// The buyer's decision to the displayed terms.
        /// </summary>
        [JsonProperty("has_agreed", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasAgreed { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ConfirmationDecision : ({string.Join(", ", toStringOutput)})";
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
            return obj is ConfirmationDecision other &&                ((this.HasAgreed == null && other.HasAgreed == null) || (this.HasAgreed?.Equals(other.HasAgreed) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1085035545;
            hashCode = HashCode.Combine(this.HasAgreed);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.HasAgreed = {(this.HasAgreed == null ? "null" : this.HasAgreed.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .HasAgreed(this.HasAgreed);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private bool? hasAgreed;

             /// <summary>
             /// HasAgreed.
             /// </summary>
             /// <param name="hasAgreed"> hasAgreed. </param>
             /// <returns> Builder. </returns>
            public Builder HasAgreed(bool? hasAgreed)
            {
                this.hasAgreed = hasAgreed;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ConfirmationDecision. </returns>
            public ConfirmationDecision Build()
            {
                return new ConfirmationDecision(
                    this.hasAgreed);
            }
        }
    }
}