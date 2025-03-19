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
using Square.Legacy.Http.Client;
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// GetPayoutResponse.
    /// </summary>
    public class GetPayoutResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetPayoutResponse"/> class.
        /// </summary>
        /// <param name="payout">payout.</param>
        /// <param name="errors">errors.</param>
        public GetPayoutResponse(Models.Payout payout = null, IList<Models.Error> errors = null)
        {
            this.Payout = payout;
            this.Errors = errors;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// An accounting of the amount owed the seller and record of the actual transfer to their
        /// external bank account or to the Square balance.
        /// </summary>
        [JsonProperty("payout", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Payout Payout { get; }

        /// <summary>
        /// Information about errors encountered during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"GetPayoutResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is GetPayoutResponse other
                && (
                    (this.Context == null && other.Context == null)
                    || this.Context?.Equals(other.Context) == true
                )
                && (
                    this.Payout == null && other.Payout == null
                    || this.Payout?.Equals(other.Payout) == true
                )
                && (
                    this.Errors == null && other.Errors == null
                    || this.Errors?.Equals(other.Errors) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1175245725;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(hashCode, this.Payout, this.Errors);

            return hashCode;
        }

        internal GetPayoutResponse ContextSetter(HttpContext context)
        {
            this.Context = context;
            return this;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add(
                $"this.Payout = {(this.Payout == null ? "null" : this.Payout.ToString())}"
            );
            toStringOutput.Add(
                $"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder().Payout(this.Payout).Errors(this.Errors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.Payout payout;
            private IList<Models.Error> errors;

            /// <summary>
            /// Payout.
            /// </summary>
            /// <param name="payout"> payout. </param>
            /// <returns> Builder. </returns>
            public Builder Payout(Models.Payout payout)
            {
                this.payout = payout;
                return this;
            }

            /// <summary>
            /// Errors.
            /// </summary>
            /// <param name="errors"> errors. </param>
            /// <returns> Builder. </returns>
            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> GetPayoutResponse. </returns>
            public GetPayoutResponse Build()
            {
                return new GetPayoutResponse(this.payout, this.errors);
            }
        }
    }
}
