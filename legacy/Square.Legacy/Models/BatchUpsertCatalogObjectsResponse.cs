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
using Square.Legacy.Http.Client;
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// BatchUpsertCatalogObjectsResponse.
    /// </summary>
    public class BatchUpsertCatalogObjectsResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BatchUpsertCatalogObjectsResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="objects">objects.</param>
        /// <param name="updatedAt">updated_at.</param>
        /// <param name="idMappings">id_mappings.</param>
        public BatchUpsertCatalogObjectsResponse(
            IList<Models.Error> errors = null,
            IList<Models.CatalogObject> objects = null,
            string updatedAt = null,
            IList<Models.CatalogIdMapping> idMappings = null
        )
        {
            this.Errors = errors;
            this.Objects = objects;
            this.UpdatedAt = updatedAt;
            this.IdMappings = idMappings;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// The created successfully created CatalogObjects.
        /// </summary>
        [JsonProperty("objects", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.CatalogObject> Objects { get; }

        /// <summary>
        /// The database [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates) of this update in RFC 3339 format, e.g., "2016-09-04T23:59:33.123Z".
        /// </summary>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAt { get; }

        /// <summary>
        /// The mapping between client and server IDs for this upsert.
        /// </summary>
        [JsonProperty("id_mappings", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.CatalogIdMapping> IdMappings { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"BatchUpsertCatalogObjectsResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is BatchUpsertCatalogObjectsResponse other
                && (
                    (this.Context == null && other.Context == null)
                    || this.Context?.Equals(other.Context) == true
                )
                && (
                    this.Errors == null && other.Errors == null
                    || this.Errors?.Equals(other.Errors) == true
                )
                && (
                    this.Objects == null && other.Objects == null
                    || this.Objects?.Equals(other.Objects) == true
                )
                && (
                    this.UpdatedAt == null && other.UpdatedAt == null
                    || this.UpdatedAt?.Equals(other.UpdatedAt) == true
                )
                && (
                    this.IdMappings == null && other.IdMappings == null
                    || this.IdMappings?.Equals(other.IdMappings) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -2062011310;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(
                hashCode,
                this.Errors,
                this.Objects,
                this.UpdatedAt,
                this.IdMappings
            );

            return hashCode;
        }

        internal BatchUpsertCatalogObjectsResponse ContextSetter(HttpContext context)
        {
            this.Context = context;
            return this;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add(
                $"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}"
            );
            toStringOutput.Add(
                $"this.Objects = {(this.Objects == null ? "null" : $"[{string.Join(", ", this.Objects)} ]")}"
            );
            toStringOutput.Add($"this.UpdatedAt = {this.UpdatedAt ?? "null"}");
            toStringOutput.Add(
                $"this.IdMappings = {(this.IdMappings == null ? "null" : $"[{string.Join(", ", this.IdMappings)} ]")}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .Objects(this.Objects)
                .UpdatedAt(this.UpdatedAt)
                .IdMappings(this.IdMappings);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private IList<Models.CatalogObject> objects;
            private string updatedAt;
            private IList<Models.CatalogIdMapping> idMappings;

            /// <summary>
            /// Errors.
            /// </summary>
            /// <param name="errors"> errors. </param>
            /// <returns> Builder. </returns>
            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            /// <summary>
            /// Objects.
            /// </summary>
            /// <param name="objects"> objects. </param>
            /// <returns> Builder. </returns>
            public Builder Objects(IList<Models.CatalogObject> objects)
            {
                this.objects = objects;
                return this;
            }

            /// <summary>
            /// UpdatedAt.
            /// </summary>
            /// <param name="updatedAt"> updatedAt. </param>
            /// <returns> Builder. </returns>
            public Builder UpdatedAt(string updatedAt)
            {
                this.updatedAt = updatedAt;
                return this;
            }

            /// <summary>
            /// IdMappings.
            /// </summary>
            /// <param name="idMappings"> idMappings. </param>
            /// <returns> Builder. </returns>
            public Builder IdMappings(IList<Models.CatalogIdMapping> idMappings)
            {
                this.idMappings = idMappings;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> BatchUpsertCatalogObjectsResponse. </returns>
            public BatchUpsertCatalogObjectsResponse Build()
            {
                return new BatchUpsertCatalogObjectsResponse(
                    this.errors,
                    this.objects,
                    this.updatedAt,
                    this.idMappings
                );
            }
        }
    }
}
