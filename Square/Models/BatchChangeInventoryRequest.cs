
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class BatchChangeInventoryRequest 
    {
        public BatchChangeInventoryRequest(string idempotencyKey = null,
            IList<Models.InventoryChange> changes = null,
            bool? ignoreUnchangedCounts = null)
        {
            IdempotencyKey = idempotencyKey;
            Changes = changes;
            IgnoreUnchangedCounts = ignoreUnchangedCounts;
        }

        /// <summary>
        /// A client-supplied, universally unique identifier (UUID) for the
        /// request.
        /// See [Idempotency](https://developer.squareup.com/docs/basics/api101/idempotency) in the
        /// [API Development 101](https://developer.squareup.com/docs/basics/api101/overview) section for more
        /// information.
        /// </summary>
        [JsonProperty("idempotency_key", NullValueHandling = NullValueHandling.Ignore)]
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BatchChangeInventoryRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"IdempotencyKey = {(IdempotencyKey == null ? "null" : IdempotencyKey == string.Empty ? "" : IdempotencyKey)}");
            toStringOutput.Add($"Changes = {(Changes == null ? "null" : $"[{ string.Join(", ", Changes)} ]")}");
            toStringOutput.Add($"IgnoreUnchangedCounts = {(IgnoreUnchangedCounts == null ? "null" : IgnoreUnchangedCounts.ToString())}");
        }

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
                ((IdempotencyKey == null && other.IdempotencyKey == null) || (IdempotencyKey?.Equals(other.IdempotencyKey) == true)) &&
                ((Changes == null && other.Changes == null) || (Changes?.Equals(other.Changes) == true)) &&
                ((IgnoreUnchangedCounts == null && other.IgnoreUnchangedCounts == null) || (IgnoreUnchangedCounts?.Equals(other.IgnoreUnchangedCounts) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 1934758425;

            if (IdempotencyKey != null)
            {
               hashCode += IdempotencyKey.GetHashCode();
            }

            if (Changes != null)
            {
               hashCode += Changes.GetHashCode();
            }

            if (IgnoreUnchangedCounts != null)
            {
               hashCode += IgnoreUnchangedCounts.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .IdempotencyKey(IdempotencyKey)
                .Changes(Changes)
                .IgnoreUnchangedCounts(IgnoreUnchangedCounts);
            return builder;
        }

        public class Builder
        {
            private string idempotencyKey;
            private IList<Models.InventoryChange> changes;
            private bool? ignoreUnchangedCounts;



            public Builder IdempotencyKey(string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
                return this;
            }

            public Builder Changes(IList<Models.InventoryChange> changes)
            {
                this.changes = changes;
                return this;
            }

            public Builder IgnoreUnchangedCounts(bool? ignoreUnchangedCounts)
            {
                this.ignoreUnchangedCounts = ignoreUnchangedCounts;
                return this;
            }

            public BatchChangeInventoryRequest Build()
            {
                return new BatchChangeInventoryRequest(idempotencyKey,
                    changes,
                    ignoreUnchangedCounts);
            }
        }
    }
}