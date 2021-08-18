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
    /// CreateBreakTypeRequest.
    /// </summary>
    public class CreateBreakTypeRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateBreakTypeRequest"/> class.
        /// </summary>
        /// <param name="breakType">break_type.</param>
        /// <param name="idempotencyKey">idempotency_key.</param>
        public CreateBreakTypeRequest(
            Models.BreakType breakType,
            string idempotencyKey = null)
        {
            this.IdempotencyKey = idempotencyKey;
            this.BreakType = breakType;
        }

        /// <summary>
        /// A unique string value to ensure the idempotency of the operation.
        /// </summary>
        [JsonProperty("idempotency_key", NullValueHandling = NullValueHandling.Ignore)]
        public string IdempotencyKey { get; }

        /// <summary>
        /// A defined break template that sets an expectation for possible `Break`
        /// instances on a `Shift`.
        /// </summary>
        [JsonProperty("break_type")]
        public Models.BreakType BreakType { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateBreakTypeRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is CreateBreakTypeRequest other &&
                ((this.IdempotencyKey == null && other.IdempotencyKey == null) || (this.IdempotencyKey?.Equals(other.IdempotencyKey) == true)) &&
                ((this.BreakType == null && other.BreakType == null) || (this.BreakType?.Equals(other.BreakType) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 441165331;

            if (this.IdempotencyKey != null)
            {
               hashCode += this.IdempotencyKey.GetHashCode();
            }

            if (this.BreakType != null)
            {
               hashCode += this.BreakType.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.IdempotencyKey = {(this.IdempotencyKey == null ? "null" : this.IdempotencyKey == string.Empty ? "" : this.IdempotencyKey)}");
            toStringOutput.Add($"this.BreakType = {(this.BreakType == null ? "null" : this.BreakType.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.BreakType)
                .IdempotencyKey(this.IdempotencyKey);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.BreakType breakType;
            private string idempotencyKey;

            public Builder(
                Models.BreakType breakType)
            {
                this.breakType = breakType;
            }

             /// <summary>
             /// BreakType.
             /// </summary>
             /// <param name="breakType"> breakType. </param>
             /// <returns> Builder. </returns>
            public Builder BreakType(Models.BreakType breakType)
            {
                this.breakType = breakType;
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
            /// <returns> CreateBreakTypeRequest. </returns>
            public CreateBreakTypeRequest Build()
            {
                return new CreateBreakTypeRequest(
                    this.breakType,
                    this.idempotencyKey);
            }
        }
    }
}