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
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// CreateShiftRequest.
    /// </summary>
    public class CreateShiftRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateShiftRequest"/> class.
        /// </summary>
        /// <param name="shift">shift.</param>
        /// <param name="idempotencyKey">idempotency_key.</param>
        public CreateShiftRequest(Models.Shift shift, string idempotencyKey = null)
        {
            this.IdempotencyKey = idempotencyKey;
            this.Shift = shift;
        }

        /// <summary>
        /// A unique string value to ensure the idempotency of the operation.
        /// </summary>
        [JsonProperty("idempotency_key", NullValueHandling = NullValueHandling.Ignore)]
        public string IdempotencyKey { get; }

        /// <summary>
        /// A record of the hourly rate, start, and end times for a single work shift
        /// for an employee. This might include a record of the start and end times for breaks
        /// taken during the shift.
        /// </summary>
        [JsonProperty("shift")]
        public Models.Shift Shift { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"CreateShiftRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is CreateShiftRequest other
                && (
                    this.IdempotencyKey == null && other.IdempotencyKey == null
                    || this.IdempotencyKey?.Equals(other.IdempotencyKey) == true
                )
                && (
                    this.Shift == null && other.Shift == null
                    || this.Shift?.Equals(other.Shift) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1561193749;
            hashCode = HashCode.Combine(hashCode, this.IdempotencyKey, this.Shift);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.IdempotencyKey = {this.IdempotencyKey ?? "null"}");
            toStringOutput.Add(
                $"this.Shift = {(this.Shift == null ? "null" : this.Shift.ToString())}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(this.Shift).IdempotencyKey(this.IdempotencyKey);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.Shift shift;
            private string idempotencyKey;

            /// <summary>
            /// Initialize Builder for CreateShiftRequest.
            /// </summary>
            /// <param name="shift"> shift. </param>
            public Builder(Models.Shift shift)
            {
                this.shift = shift;
            }

            /// <summary>
            /// Shift.
            /// </summary>
            /// <param name="shift"> shift. </param>
            /// <returns> Builder. </returns>
            public Builder Shift(Models.Shift shift)
            {
                this.shift = shift;
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
            /// <returns> CreateShiftRequest. </returns>
            public CreateShiftRequest Build()
            {
                return new CreateShiftRequest(this.shift, this.idempotencyKey);
            }
        }
    }
}
