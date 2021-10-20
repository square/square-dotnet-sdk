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
    /// CreateCustomerGroupRequest.
    /// </summary>
    public class CreateCustomerGroupRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCustomerGroupRequest"/> class.
        /// </summary>
        /// <param name="mGroup">group.</param>
        /// <param name="idempotencyKey">idempotency_key.</param>
        public CreateCustomerGroupRequest(
            Models.CustomerGroup mGroup,
            string idempotencyKey = null)
        {
            this.IdempotencyKey = idempotencyKey;
            this.MGroup = mGroup;
        }

        /// <summary>
        /// The idempotency key for the request. For more information, see [Idempotency](https://developer.squareup.com/docs/basics/api101/idempotency).
        /// </summary>
        [JsonProperty("idempotency_key", NullValueHandling = NullValueHandling.Ignore)]
        public string IdempotencyKey { get; }

        /// <summary>
        /// Represents a group of customer profiles.
        /// Customer groups can be created, be modified, and have their membership defined using
        /// the Customers API or within the Customer Directory in the Square Seller Dashboard or Point of Sale.
        /// </summary>
        [JsonProperty("group")]
        public Models.CustomerGroup MGroup { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateCustomerGroupRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is CreateCustomerGroupRequest other &&
                ((this.IdempotencyKey == null && other.IdempotencyKey == null) || (this.IdempotencyKey?.Equals(other.IdempotencyKey) == true)) &&
                ((this.MGroup == null && other.MGroup == null) || (this.MGroup?.Equals(other.MGroup) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1522931870;
            hashCode = HashCode.Combine(this.IdempotencyKey, this.MGroup);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.IdempotencyKey = {(this.IdempotencyKey == null ? "null" : this.IdempotencyKey == string.Empty ? "" : this.IdempotencyKey)}");
            toStringOutput.Add($"this.MGroup = {(this.MGroup == null ? "null" : this.MGroup.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.MGroup)
                .IdempotencyKey(this.IdempotencyKey);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.CustomerGroup mGroup;
            private string idempotencyKey;

            public Builder(
                Models.CustomerGroup mGroup)
            {
                this.mGroup = mGroup;
            }

             /// <summary>
             /// MGroup.
             /// </summary>
             /// <param name="mGroup"> mGroup. </param>
             /// <returns> Builder. </returns>
            public Builder MGroup(Models.CustomerGroup mGroup)
            {
                this.mGroup = mGroup;
                return this;
            }

             /// <summary>
             /// IdempotencyKey.
             /// </summary>
             /// <param name="idempotencyKey"> idempotencyKey. </param>
             /// <returns> Builder. </returns>
            public Builder IdempotencyKey(string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CreateCustomerGroupRequest. </returns>
            public CreateCustomerGroupRequest Build()
            {
                return new CreateCustomerGroupRequest(
                    this.mGroup,
                    this.idempotencyKey);
            }
        }
    }
}