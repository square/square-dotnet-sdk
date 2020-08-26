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
            private IList<Models.InventoryChange> changes = new List<Models.InventoryChange>();
            private bool? ignoreUnchangedCounts;

            public Builder() { }
            public Builder IdempotencyKey(string value)
            {
                idempotencyKey = value;
                return this;
            }

            public Builder Changes(IList<Models.InventoryChange> value)
            {
                changes = value;
                return this;
            }

            public Builder IgnoreUnchangedCounts(bool? value)
            {
                ignoreUnchangedCounts = value;
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