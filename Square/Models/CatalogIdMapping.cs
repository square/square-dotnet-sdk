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
    /// CatalogIdMapping.
    /// </summary>
    public class CatalogIdMapping
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogIdMapping"/> class.
        /// </summary>
        /// <param name="clientObjectId">client_object_id.</param>
        /// <param name="objectId">object_id.</param>
        public CatalogIdMapping(
            string clientObjectId = null,
            string objectId = null)
        {
            this.ClientObjectId = clientObjectId;
            this.ObjectId = objectId;
        }

        /// <summary>
        /// The client-supplied temporary `#`-prefixed ID for a new `CatalogObject`.
        /// </summary>
        [JsonProperty("client_object_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ClientObjectId { get; }

        /// <summary>
        /// The permanent ID for the CatalogObject created by the server.
        /// </summary>
        [JsonProperty("object_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ObjectId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogIdMapping : ({string.Join(", ", toStringOutput)})";
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

            return obj is CatalogIdMapping other &&
                ((this.ClientObjectId == null && other.ClientObjectId == null) || (this.ClientObjectId?.Equals(other.ClientObjectId) == true)) &&
                ((this.ObjectId == null && other.ObjectId == null) || (this.ObjectId?.Equals(other.ObjectId) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -2090188884;
            hashCode = HashCode.Combine(this.ClientObjectId, this.ObjectId);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ClientObjectId = {(this.ClientObjectId == null ? "null" : this.ClientObjectId == string.Empty ? "" : this.ClientObjectId)}");
            toStringOutput.Add($"this.ObjectId = {(this.ObjectId == null ? "null" : this.ObjectId == string.Empty ? "" : this.ObjectId)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .ClientObjectId(this.ClientObjectId)
                .ObjectId(this.ObjectId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string clientObjectId;
            private string objectId;

             /// <summary>
             /// ClientObjectId.
             /// </summary>
             /// <param name="clientObjectId"> clientObjectId. </param>
             /// <returns> Builder. </returns>
            public Builder ClientObjectId(string clientObjectId)
            {
                this.clientObjectId = clientObjectId;
                return this;
            }

             /// <summary>
             /// ObjectId.
             /// </summary>
             /// <param name="objectId"> objectId. </param>
             /// <returns> Builder. </returns>
            public Builder ObjectId(string objectId)
            {
                this.objectId = objectId;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogIdMapping. </returns>
            public CatalogIdMapping Build()
            {
                return new CatalogIdMapping(
                    this.clientObjectId,
                    this.objectId);
            }
        }
    }
}