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
    /// BatchUpsertCatalogObjectsRequest.
    /// </summary>
    public class BatchUpsertCatalogObjectsRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BatchUpsertCatalogObjectsRequest"/> class.
        /// </summary>
        /// <param name="idempotencyKey">idempotency_key.</param>
        /// <param name="batches">batches.</param>
        public BatchUpsertCatalogObjectsRequest(
            string idempotencyKey,
            IList<Models.CatalogObjectBatch> batches
        )
        {
            this.IdempotencyKey = idempotencyKey;
            this.Batches = batches;
        }

        /// <summary>
        /// A value you specify that uniquely identifies this
        /// request among all your requests. A common way to create
        /// a valid idempotency key is to use a Universally unique
        /// identifier (UUID).
        /// If you're unsure whether a particular request was successful,
        /// you can reattempt it with the same idempotency key without
        /// worrying about creating duplicate objects.
        /// See [Idempotency](https://developer.squareup.com/docs/build-basics/common-api-patterns/idempotency) for more information.
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <summary>
        /// A batch of CatalogObjects to be inserted/updated atomically.
        /// The objects within a batch will be inserted in an all-or-nothing fashion, i.e., if an error occurs
        /// attempting to insert or update an object within a batch, the entire batch will be rejected. However, an error
        /// in one batch will not affect other batches within the same request.
        /// For each object, its `updated_at` field is ignored and replaced with a current [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates), and its
        /// `is_deleted` field must not be set to `true`.
        /// To modify an existing object, supply its ID. To create a new object, use an ID starting
        /// with `#`. These IDs may be used to create relationships between an object and attributes of
        /// other objects that reference it. For example, you can create a CatalogItem with
        /// ID `#ABC` and a CatalogItemVariation with its `item_id` attribute set to
        /// `#ABC` in order to associate the CatalogItemVariation with its parent
        /// CatalogItem.
        /// Any `#`-prefixed IDs are valid only within a single atomic batch, and will be replaced by server-generated IDs.
        /// Each batch may contain up to 1,000 objects. The total number of objects across all batches for a single request
        /// may not exceed 10,000. If either of these limits is violated, an error will be returned and no objects will
        /// be inserted or updated.
        /// </summary>
        [JsonProperty("batches")]
        public IList<Models.CatalogObjectBatch> Batches { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"BatchUpsertCatalogObjectsRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is BatchUpsertCatalogObjectsRequest other
                && (
                    this.IdempotencyKey == null && other.IdempotencyKey == null
                    || this.IdempotencyKey?.Equals(other.IdempotencyKey) == true
                )
                && (
                    this.Batches == null && other.Batches == null
                    || this.Batches?.Equals(other.Batches) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -376663980;
            hashCode = HashCode.Combine(hashCode, this.IdempotencyKey, this.Batches);

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
                $"this.Batches = {(this.Batches == null ? "null" : $"[{string.Join(", ", this.Batches)} ]")}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(this.IdempotencyKey, this.Batches);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string idempotencyKey;
            private IList<Models.CatalogObjectBatch> batches;

            /// <summary>
            /// Initialize Builder for BatchUpsertCatalogObjectsRequest.
            /// </summary>
            /// <param name="idempotencyKey"> idempotencyKey. </param>
            /// <param name="batches"> batches. </param>
            public Builder(string idempotencyKey, IList<Models.CatalogObjectBatch> batches)
            {
                this.idempotencyKey = idempotencyKey;
                this.batches = batches;
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
            /// Batches.
            /// </summary>
            /// <param name="batches"> batches. </param>
            /// <returns> Builder. </returns>
            public Builder Batches(IList<Models.CatalogObjectBatch> batches)
            {
                this.batches = batches;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> BatchUpsertCatalogObjectsRequest. </returns>
            public BatchUpsertCatalogObjectsRequest Build()
            {
                return new BatchUpsertCatalogObjectsRequest(this.idempotencyKey, this.batches);
            }
        }
    }
}
