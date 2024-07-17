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
    /// BatchChangeInventoryRequest.
    /// </summary>
    public class BatchChangeInventoryRequest
    {
        private readonly Dictionary<string, bool> shouldSerialize;
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
            shouldSerialize = new Dictionary<string, bool>
            {
                { "changes", false },
                { "ignore_unchanged_counts", false }
            };

            this.IdempotencyKey = idempotencyKey;
            if (changes != null)
            {
                shouldSerialize["changes"] = true;
                this.Changes = changes;
            }

            if (ignoreUnchangedCounts != null)
            {
                shouldSerialize["ignore_unchanged_counts"] = true;
                this.IgnoreUnchangedCounts = ignoreUnchangedCounts;
            }

        }
        internal BatchChangeInventoryRequest(Dictionary<string, bool> shouldSerialize,
            string idempotencyKey,
            IList<Models.InventoryChange> changes = null,
            bool? ignoreUnchangedCounts = null)
        {
            this.shouldSerialize = shouldSerialize;
            IdempotencyKey = idempotencyKey;
            Changes = changes;
            IgnoreUnchangedCounts = ignoreUnchangedCounts;
        }

        /// <summary>
        /// A client-supplied, universally unique identifier (UUID) for the
        /// request.
        /// See [Idempotency](https://developer.squareup.com/docs/build-basics/common-api-patterns/idempotency) in the
        /// [API Development 101](https://developer.squareup.com/docs/buildbasics) section for more
        /// information.
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <summary>
        /// The set of physical counts and inventory adjustments to be made.
        /// Changes are applied based on the client-supplied timestamp and may be sent
        /// out of order.
        /// </summary>
        [JsonProperty("changes")]
        public IList<Models.InventoryChange> Changes { get; }

        /// <summary>
        /// Indicates whether the current physical count should be ignored if
        /// the quantity is unchanged since the last physical count. Default: `true`.
        /// </summary>
        [JsonProperty("ignore_unchanged_counts")]
        public bool? IgnoreUnchangedCounts { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BatchChangeInventoryRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeChanges()
        {
            return this.shouldSerialize["changes"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeIgnoreUnchangedCounts()
        {
            return this.shouldSerialize["ignore_unchanged_counts"];
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
            return obj is BatchChangeInventoryRequest other &&                ((this.IdempotencyKey == null && other.IdempotencyKey == null) || (this.IdempotencyKey?.Equals(other.IdempotencyKey) == true)) &&
                ((this.Changes == null && other.Changes == null) || (this.Changes?.Equals(other.Changes) == true)) &&
                ((this.IgnoreUnchangedCounts == null && other.IgnoreUnchangedCounts == null) || (this.IgnoreUnchangedCounts?.Equals(other.IgnoreUnchangedCounts) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1934758425;
            hashCode = HashCode.Combine(this.IdempotencyKey, this.Changes, this.IgnoreUnchangedCounts);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.IdempotencyKey = {(this.IdempotencyKey == null ? "null" : this.IdempotencyKey)}");
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
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "changes", false },
                { "ignore_unchanged_counts", false },
            };

            private string idempotencyKey;
            private IList<Models.InventoryChange> changes;
            private bool? ignoreUnchangedCounts;

            /// <summary>
            /// Initialize Builder for BatchChangeInventoryRequest.
            /// </summary>
            /// <param name="idempotencyKey"> idempotencyKey. </param>
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
                shouldSerialize["changes"] = true;
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
                shouldSerialize["ignore_unchanged_counts"] = true;
                this.ignoreUnchangedCounts = ignoreUnchangedCounts;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetChanges()
            {
                this.shouldSerialize["changes"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetIgnoreUnchangedCounts()
            {
                this.shouldSerialize["ignore_unchanged_counts"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> BatchChangeInventoryRequest. </returns>
            public BatchChangeInventoryRequest Build()
            {
                return new BatchChangeInventoryRequest(shouldSerialize,
                    this.idempotencyKey,
                    this.changes,
                    this.ignoreUnchangedCounts);
            }
        }
    }
}