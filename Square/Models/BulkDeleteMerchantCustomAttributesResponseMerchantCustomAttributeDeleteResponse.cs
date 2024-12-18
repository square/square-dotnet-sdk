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

namespace Square.Models
{
    /// <summary>
    /// BulkDeleteMerchantCustomAttributesResponseMerchantCustomAttributeDeleteResponse.
    /// </summary>
    public class BulkDeleteMerchantCustomAttributesResponseMerchantCustomAttributeDeleteResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BulkDeleteMerchantCustomAttributesResponseMerchantCustomAttributeDeleteResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        public BulkDeleteMerchantCustomAttributesResponseMerchantCustomAttributeDeleteResponse(
            IList<Models.Error> errors = null)
        {
            this.Errors = errors;
        }

        /// <summary>
        /// Errors that occurred while processing the individual MerchantCustomAttributeDeleteRequest request
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"BulkDeleteMerchantCustomAttributesResponseMerchantCustomAttributeDeleteResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is BulkDeleteMerchantCustomAttributesResponseMerchantCustomAttributeDeleteResponse other &&
                (this.Errors == null && other.Errors == null ||
                 this.Errors?.Equals(other.Errors) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 86380383;
            hashCode = HashCode.Combine(hashCode, this.Errors);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;

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
            /// <returns> BulkDeleteMerchantCustomAttributesResponseMerchantCustomAttributeDeleteResponse. </returns>
            public BulkDeleteMerchantCustomAttributesResponseMerchantCustomAttributeDeleteResponse Build()
            {
                return new BulkDeleteMerchantCustomAttributesResponseMerchantCustomAttributeDeleteResponse(
                    this.errors);
            }
        }
    }
}