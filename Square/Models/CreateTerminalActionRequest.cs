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
    /// CreateTerminalActionRequest.
    /// </summary>
    public class CreateTerminalActionRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTerminalActionRequest"/> class.
        /// </summary>
        /// <param name="idempotencyKey">idempotency_key.</param>
        /// <param name="action">action.</param>
        public CreateTerminalActionRequest(
            string idempotencyKey,
            Models.TerminalAction action)
        {
            this.IdempotencyKey = idempotencyKey;
            this.Action = action;
        }

        /// <summary>
        /// A unique string that identifies this `CreateAction` request. Keys can be any valid string
        /// but must be unique for every `CreateAction` request.
        /// See [Idempotency keys](https://developer.squareup.com/docs/build-basics/common-api-patterns/idempotency) for more
        /// information.
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <summary>
        /// Represents an action processed by the Square Terminal.
        /// </summary>
        [JsonProperty("action")]
        public Models.TerminalAction Action { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateTerminalActionRequest : ({string.Join(", ", toStringOutput)})";
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
            return obj is CreateTerminalActionRequest other &&                ((this.IdempotencyKey == null && other.IdempotencyKey == null) || (this.IdempotencyKey?.Equals(other.IdempotencyKey) == true)) &&
                ((this.Action == null && other.Action == null) || (this.Action?.Equals(other.Action) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -635795787;
            hashCode = HashCode.Combine(this.IdempotencyKey, this.Action);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.IdempotencyKey = {(this.IdempotencyKey == null ? "null" : this.IdempotencyKey)}");
            toStringOutput.Add($"this.Action = {(this.Action == null ? "null" : this.Action.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.IdempotencyKey,
                this.Action);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string idempotencyKey;
            private Models.TerminalAction action;

            /// <summary>
            /// Initialize Builder for CreateTerminalActionRequest.
            /// </summary>
            /// <param name="idempotencyKey"> idempotencyKey. </param>
            /// <param name="action"> action. </param>
            public Builder(
                string idempotencyKey,
                Models.TerminalAction action)
            {
                this.idempotencyKey = idempotencyKey;
                this.action = action;
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
             /// Action.
             /// </summary>
             /// <param name="action"> action. </param>
             /// <returns> Builder. </returns>
            public Builder Action(Models.TerminalAction action)
            {
                this.action = action;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CreateTerminalActionRequest. </returns>
            public CreateTerminalActionRequest Build()
            {
                return new CreateTerminalActionRequest(
                    this.idempotencyKey,
                    this.action);
            }
        }
    }
}