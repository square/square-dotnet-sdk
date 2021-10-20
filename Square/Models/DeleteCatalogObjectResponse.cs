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
    using Square.Http.Client;
    using Square.Utilities;

    /// <summary>
    /// DeleteCatalogObjectResponse.
    /// </summary>
    public class DeleteCatalogObjectResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteCatalogObjectResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="deletedObjectIds">deleted_object_ids.</param>
        /// <param name="deletedAt">deleted_at.</param>
        public DeleteCatalogObjectResponse(
            IList<Models.Error> errors = null,
            IList<string> deletedObjectIds = null,
            string deletedAt = null)
        {
            this.Errors = errors;
            this.DeletedObjectIds = deletedObjectIds;
            this.DeletedAt = deletedAt;
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
        /// The IDs of all catalog objects deleted by this request.
        /// Multiple IDs may be returned when associated objects are also deleted, for example
        /// a catalog item variation will be deleted (and its ID included in this field)
        /// when its parent catalog item is deleted.
        /// </summary>
        [JsonProperty("deleted_object_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> DeletedObjectIds { get; }

        /// <summary>
        /// The database [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        /// of this deletion in RFC 3339 format, e.g., `2016-09-04T23:59:33.123Z`.
        /// </summary>
        [JsonProperty("deleted_at", NullValueHandling = NullValueHandling.Ignore)]
        public string DeletedAt { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"DeleteCatalogObjectResponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is DeleteCatalogObjectResponse other &&
                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true)) &&
                ((this.DeletedObjectIds == null && other.DeletedObjectIds == null) || (this.DeletedObjectIds?.Equals(other.DeletedObjectIds) == true)) &&
                ((this.DeletedAt == null && other.DeletedAt == null) || (this.DeletedAt?.Equals(other.DeletedAt) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 98566356;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.Errors, this.DeletedObjectIds, this.DeletedAt);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
            toStringOutput.Add($"this.DeletedObjectIds = {(this.DeletedObjectIds == null ? "null" : $"[{string.Join(", ", this.DeletedObjectIds)} ]")}");
            toStringOutput.Add($"this.DeletedAt = {(this.DeletedAt == null ? "null" : this.DeletedAt == string.Empty ? "" : this.DeletedAt)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .DeletedObjectIds(this.DeletedObjectIds)
                .DeletedAt(this.DeletedAt);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private IList<string> deletedObjectIds;
            private string deletedAt;

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
             /// DeletedObjectIds.
             /// </summary>
             /// <param name="deletedObjectIds"> deletedObjectIds. </param>
             /// <returns> Builder. </returns>
            public Builder DeletedObjectIds(IList<string> deletedObjectIds)
            {
                this.deletedObjectIds = deletedObjectIds;
                return this;
            }

             /// <summary>
             /// DeletedAt.
             /// </summary>
             /// <param name="deletedAt"> deletedAt. </param>
             /// <returns> Builder. </returns>
            public Builder DeletedAt(string deletedAt)
            {
                this.deletedAt = deletedAt;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> DeleteCatalogObjectResponse. </returns>
            public DeleteCatalogObjectResponse Build()
            {
                return new DeleteCatalogObjectResponse(
                    this.errors,
                    this.deletedObjectIds,
                    this.deletedAt);
            }
        }
    }
}