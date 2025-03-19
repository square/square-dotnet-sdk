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
    /// RetrieveMerchantResponse.
    /// </summary>
    public class RetrieveMerchantResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RetrieveMerchantResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="merchant">merchant.</param>
        public RetrieveMerchantResponse(
            IList<Models.Error> errors = null,
            Models.Merchant merchant = null
        )
        {
            this.Errors = errors;
            this.Merchant = merchant;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Information on errors encountered during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Represents a business that sells with Square.Legacy.
        /// </summary>
        [JsonProperty("merchant", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Merchant Merchant { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"RetrieveMerchantResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is RetrieveMerchantResponse other
                && (
                    (this.Context == null && other.Context == null)
                    || this.Context?.Equals(other.Context) == true
                )
                && (
                    this.Errors == null && other.Errors == null
                    || this.Errors?.Equals(other.Errors) == true
                )
                && (
                    this.Merchant == null && other.Merchant == null
                    || this.Merchant?.Equals(other.Merchant) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 1177191163;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(hashCode, this.Errors, this.Merchant);

            return hashCode;
        }

        internal RetrieveMerchantResponse ContextSetter(HttpContext context)
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
                $"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}"
            );
            toStringOutput.Add(
                $"this.Merchant = {(this.Merchant == null ? "null" : this.Merchant.ToString())}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder().Errors(this.Errors).Merchant(this.Merchant);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private Models.Merchant merchant;

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
            /// Merchant.
            /// </summary>
            /// <param name="merchant"> merchant. </param>
            /// <returns> Builder. </returns>
            public Builder Merchant(Models.Merchant merchant)
            {
                this.merchant = merchant;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> RetrieveMerchantResponse. </returns>
            public RetrieveMerchantResponse Build()
            {
                return new RetrieveMerchantResponse(this.errors, this.merchant);
            }
        }
    }
}
