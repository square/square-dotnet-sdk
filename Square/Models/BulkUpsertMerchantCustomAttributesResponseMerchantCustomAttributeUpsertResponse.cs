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
    /// BulkUpsertMerchantCustomAttributesResponseMerchantCustomAttributeUpsertResponse.
    /// </summary>
    public class BulkUpsertMerchantCustomAttributesResponseMerchantCustomAttributeUpsertResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BulkUpsertMerchantCustomAttributesResponseMerchantCustomAttributeUpsertResponse"/> class.
        /// </summary>
        /// <param name="merchantId">merchant_id.</param>
        /// <param name="customAttribute">custom_attribute.</param>
        /// <param name="errors">errors.</param>
        public BulkUpsertMerchantCustomAttributesResponseMerchantCustomAttributeUpsertResponse(
            string merchantId = null,
            Models.CustomAttribute customAttribute = null,
            IList<Models.Error> errors = null)
        {
            this.MerchantId = merchantId;
            this.CustomAttribute = customAttribute;
            this.Errors = errors;
        }

        /// <summary>
        /// The ID of the merchant associated with the custom attribute.
        /// </summary>
        [JsonProperty("merchant_id", NullValueHandling = NullValueHandling.Ignore)]
        public string MerchantId { get; }

        /// <summary>
        /// A custom attribute value. Each custom attribute value has a corresponding
        /// `CustomAttributeDefinition` object.
        /// </summary>
        [JsonProperty("custom_attribute", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CustomAttribute CustomAttribute { get; }

        /// <summary>
        /// Any errors that occurred while processing the individual request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BulkUpsertMerchantCustomAttributesResponseMerchantCustomAttributeUpsertResponse : ({string.Join(", ", toStringOutput)})";
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
            return obj is BulkUpsertMerchantCustomAttributesResponseMerchantCustomAttributeUpsertResponse other &&                ((this.MerchantId == null && other.MerchantId == null) || (this.MerchantId?.Equals(other.MerchantId) == true)) &&
                ((this.CustomAttribute == null && other.CustomAttribute == null) || (this.CustomAttribute?.Equals(other.CustomAttribute) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -388295245;
            hashCode = HashCode.Combine(this.MerchantId, this.CustomAttribute, this.Errors);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.MerchantId = {(this.MerchantId == null ? "null" : this.MerchantId)}");
            toStringOutput.Add($"this.CustomAttribute = {(this.CustomAttribute == null ? "null" : this.CustomAttribute.ToString())}");
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .MerchantId(this.MerchantId)
                .CustomAttribute(this.CustomAttribute)
                .Errors(this.Errors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string merchantId;
            private Models.CustomAttribute customAttribute;
            private IList<Models.Error> errors;

             /// <summary>
             /// MerchantId.
             /// </summary>
             /// <param name="merchantId"> merchantId. </param>
             /// <returns> Builder. </returns>
            public Builder MerchantId(string merchantId)
            {
                this.merchantId = merchantId;
                return this;
            }

             /// <summary>
             /// CustomAttribute.
             /// </summary>
             /// <param name="customAttribute"> customAttribute. </param>
             /// <returns> Builder. </returns>
            public Builder CustomAttribute(Models.CustomAttribute customAttribute)
            {
                this.customAttribute = customAttribute;
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
            /// <returns> BulkUpsertMerchantCustomAttributesResponseMerchantCustomAttributeUpsertResponse. </returns>
            public BulkUpsertMerchantCustomAttributesResponseMerchantCustomAttributeUpsertResponse Build()
            {
                return new BulkUpsertMerchantCustomAttributesResponseMerchantCustomAttributeUpsertResponse(
                    this.merchantId,
                    this.customAttribute,
                    this.errors);
            }
        }
    }
}