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
    /// BatchChangeInventoryRequest.
    /// </summary>
    public class BatchChangeInventoryRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BatchChangeInventoryRequest"/> class.
        /// </summary>
        /// <param name="idempotencyKey">idempotency_key.</param>
        /// <param name="changes">changes.</param>
        /// <param name="ignoreUnchangedCounts">ignore_unchanged_counts.</param>
        public BatchChangeInventoryRequest(
            string idempotencyKey,
            IList<Models.InventoryChange> changes = null,
            bool? ignoreUnchangedCounts = null)
        {
            this.IdempotencyKey = idempotencyKey;
            this.Changes = changes;
            this.IgnoreUnchangedCounts = ignoreUnchangedCounts;
        }

        /// <summary>
        /// A client-supplied, universally unique identifier (UUID) for the
        /// request.
        /// See [Idempotency](https://developer.squareup.com/docs/basics/api101/idempotency) in the
        /// [API Development 101](https://developer.squareup.com/docs/basics/api101/overview) section for more
        /// information.
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <summary>
        /// The set of physical counts and inventory adjustments to be made.
        /// Changes are applied based on the client-supplied timestamp and may be sent
        /// out of order.
        /// </summary>
        [JsonProperty("changes", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.InventoryChange> Changes { get; }

        /// <summary>
        /// Indicates whether the current physical count should be ignored if
        /// the quantity is unchanged since the last physical count. Default: `true`.
        /// </summary>
        [JsonProperty("ignore_unchanged_counts", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IgnoreUnchangedCounts { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BatchChangeInventoryRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is BatchChangeInventoryRequest other &&
                ((this.IdempotencyKey == null && other.IdempotencyKey == null) || (this.IdempotencyKey?.Equals(other.IdempotencyKey) == true)) &&
                ((this.Changes == null && other.Changes == null) || (this.Changes?.Equals(other.Changes) == true)) &&
                ((this.IgnoreUnchangedCounts == null && other.IgnoreUnchangedCounts == null) || (this.IgnoreUnchangedCounts?.Equals(other.IgnoreUnchangedCounts) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1934758425;

            if (this.IdempotencyKey != null)
            {
               hashCode += this.IdempotencyKey.GetHashCode();
            }

            if (this.Changes != null)
            {
               hashCode += this.Changes.GetHashCode();
            }

            if (this.IgnoreUnchangedCounts != null)
            {
               hashCode += this.IgnoreUnchangedCounts.GetHashCode();
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
            toStringOutput.Add($"this.Changes = {(this.Changes == null ? "null" : $"[{string.Join(", ", this.Changes)} ]")}");
            toStringOutput.Add($"this.IgnoreUnchangedCounts = {(this.IgnoreUnchangedCounts == null ? "null" : this.IgnoreUnchangedCounts.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.IdempotencyKey)
                .Changes(this.Changes)
                .IgnoreUnchangedCounts(this.IgnoreUnchangedCounts);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string idempotencyKey;
            private IList<Models.InventoryChange> changes;
            private bool? ignoreUnchangedCounts;

            public Builder(
                string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
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
             /// Changes.
             /// </summary>
             /// <param name="changes"> changes. </param>
             /// <returns> Builder. </returns>
            public Builder Changes(IList<Models.InventoryChange> changes)
            {
                this.changes = changes;
                return this;
            }

             /// <summary>
             /// IgnoreUnchangedCounts.
             /// </summary>
             /// <param name="ignoreUnchangedCounts"> ignoreUnchangedCounts. </param>
             /// <returns> Builder. </returns>
            public Builder IgnoreUnchangedCounts(bool? ignoreUnchangedCounts)
            {
                this.ignoreUnchangedCounts = ignoreUnchangedCounts;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> BatchChangeInventoryRequest. </returns>
            public BatchChangeInventoryRequest Build()
            {
                return new BatchChangeInventoryRequest(
                    this.idempotencyKey,
                    this.changes,
                    this.ignoreUnchangedCounts);
            }
        }
    }
}