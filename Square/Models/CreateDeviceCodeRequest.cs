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
    /// CreateDeviceCodeRequest.
    /// </summary>
    public class CreateDeviceCodeRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateDeviceCodeRequest"/> class.
        /// </summary>
        /// <param name="idempotencyKey">idempotency_key.</param>
        /// <param name="deviceCode">device_code.</param>
        public CreateDeviceCodeRequest(
            string idempotencyKey,
            Models.DeviceCode deviceCode)
        {
            this.IdempotencyKey = idempotencyKey;
            this.DeviceCode = deviceCode;
        }

        /// <summary>
        /// A unique string that identifies this CreateDeviceCode request. Keys can
        /// be any valid string but must be unique for every CreateDeviceCode request.
        /// See [Idempotency keys](https://developer.squareup.com/docs/build-basics/common-api-patterns/idempotency) for more information.
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <summary>
        /// Gets or sets DeviceCode.
        /// </summary>
        [JsonProperty("device_code")]
        public Models.DeviceCode DeviceCode { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"CreateDeviceCodeRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is CreateDeviceCodeRequest other &&
                (this.IdempotencyKey == null && other.IdempotencyKey == null ||
                 this.IdempotencyKey?.Equals(other.IdempotencyKey) == true) &&
                (this.DeviceCode == null && other.DeviceCode == null ||
                 this.DeviceCode?.Equals(other.DeviceCode) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 1794633711;
            hashCode = HashCode.Combine(hashCode, this.IdempotencyKey, this.DeviceCode);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.IdempotencyKey = {this.IdempotencyKey ?? "null"}");
            toStringOutput.Add($"this.DeviceCode = {(this.DeviceCode == null ? "null" : this.DeviceCode.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.IdempotencyKey,
                this.DeviceCode);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string idempotencyKey;
            private Models.DeviceCode deviceCode;

            /// <summary>
            /// Initialize Builder for CreateDeviceCodeRequest.
            /// </summary>
            /// <param name="idempotencyKey"> idempotencyKey. </param>
            /// <param name="deviceCode"> deviceCode. </param>
            public Builder(
                string idempotencyKey,
                Models.DeviceCode deviceCode)
            {
                this.idempotencyKey = idempotencyKey;
                this.deviceCode = deviceCode;
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
             /// DeviceCode.
             /// </summary>
             /// <param name="deviceCode"> deviceCode. </param>
             /// <returns> Builder. </returns>
            public Builder DeviceCode(Models.DeviceCode deviceCode)
            {
                this.deviceCode = deviceCode;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CreateDeviceCodeRequest. </returns>
            public CreateDeviceCodeRequest Build()
            {
                return new CreateDeviceCodeRequest(
                    this.idempotencyKey,
                    this.deviceCode);
            }
        }
    }
}