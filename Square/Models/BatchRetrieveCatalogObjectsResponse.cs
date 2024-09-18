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
using Square.Http.Client;
using Square.Utilities;

namespace Square.Models
{
    /// <summary>
    /// BatchRetrieveCatalogObjectsResponse.
    /// </summary>
    public class BatchRetrieveCatalogObjectsResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BatchRetrieveCatalogObjectsResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="objects">objects.</param>
        /// <param name="relatedObjects">related_objects.</param>
        public BatchRetrieveCatalogObjectsResponse(
            IList<Models.Error> errors = null,
            IList<Models.CatalogObject> objects = null,
            IList<Models.CatalogObject> relatedObjects = null)
        {
            this.Errors = errors;
            this.Objects = objects;
            this.RelatedObjects = relatedObjects;
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
        /// A list of [CatalogObject](entity:CatalogObject)s returned.
        /// </summary>
        [JsonProperty("objects", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.CatalogObject> Objects { get; }

        /// <summary>
        /// A list of [CatalogObject](entity:CatalogObject)s referenced by the object in the `objects` field.
        /// </summary>
        [JsonProperty("related_objects", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.CatalogObject> RelatedObjects { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BatchRetrieveCatalogObjectsResponse : ({string.Join(", ", toStringOutput)})";
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
            return obj is BatchRetrieveCatalogObjectsResponse other &&                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true)) &&
                ((this.Objects == null && other.Objects == null) || (this.Objects?.Equals(other.Objects) == true)) &&
                ((this.RelatedObjects == null && other.RelatedObjects == null) || (this.RelatedObjects?.Equals(other.RelatedObjects) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 99974308;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.Errors, this.Objects, this.RelatedObjects);

            return hashCode;
        }
        internal BatchRetrieveCatalogObjectsResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
            toStringOutput.Add($"this.Objects = {(this.Objects == null ? "null" : $"[{string.Join(", ", this.Objects)} ]")}");
            toStringOutput.Add($"this.RelatedObjects = {(this.RelatedObjects == null ? "null" : $"[{string.Join(", ", this.RelatedObjects)} ]")}");
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
                .RelatedObjects(this.RelatedObjects);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private IList<Models.CatalogObject> objects;
            private IList<Models.CatalogObject> relatedObjects;

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
             /// RelatedObjects.
             /// </summary>
             /// <param name="relatedObjects"> relatedObjects. </param>
             /// <returns> Builder. </returns>
            public Builder RelatedObjects(IList<Models.CatalogObject> relatedObjects)
            {
                this.relatedObjects = relatedObjects;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> BatchRetrieveCatalogObjectsResponse. </returns>
            public BatchRetrieveCatalogObjectsResponse Build()
            {
                return new BatchRetrieveCatalogObjectsResponse(
                    this.errors,
                    this.objects,
                    this.relatedObjects);
            }
        }
    }
}