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
    /// CatalogIdMapping.
    /// </summary>
    public class CatalogIdMapping
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogIdMapping"/> class.
        /// </summary>
        /// <param name="clientObjectId">client_object_id.</param>
        /// <param name="objectId">object_id.</param>
        public CatalogIdMapping(
            string clientObjectId = null,
            string objectId = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "client_object_id", false },
                { "object_id", false }
            };

            if (clientObjectId != null)
            {
                shouldSerialize["client_object_id"] = true;
                this.ClientObjectId = clientObjectId;
            }

            if (objectId != null)
            {
                shouldSerialize["object_id"] = true;
                this.ObjectId = objectId;
            }

        }
        internal CatalogIdMapping(Dictionary<string, bool> shouldSerialize,
            string clientObjectId = null,
            string objectId = null)
        {
            this.shouldSerialize = shouldSerialize;
            ClientObjectId = clientObjectId;
            ObjectId = objectId;
        }

        /// <summary>
        /// The client-supplied temporary `#`-prefixed ID for a new `CatalogObject`.
        /// </summary>
        [JsonProperty("client_object_id")]
        public string ClientObjectId { get; }

        /// <summary>
        /// The permanent ID for the CatalogObject created by the server.
        /// </summary>
        [JsonProperty("object_id")]
        public string ObjectId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogIdMapping : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeClientObjectId()
        {
            return this.shouldSerialize["client_object_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeObjectId()
        {
            return this.shouldSerialize["object_id"];
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
            return obj is CatalogIdMapping other &&                ((this.ClientObjectId == null && other.ClientObjectId == null) || (this.ClientObjectId?.Equals(other.ClientObjectId) == true)) &&
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
            toStringOutput.Add($"this.ClientObjectId = {(this.ClientObjectId == null ? "null" : this.ClientObjectId)}");
            toStringOutput.Add($"this.ObjectId = {(this.ObjectId == null ? "null" : this.ObjectId)}");
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
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "client_object_id", false },
                { "object_id", false },
            };

            private string clientObjectId;
            private string objectId;

             /// <summary>
             /// ClientObjectId.
             /// </summary>
             /// <param name="clientObjectId"> clientObjectId. </param>
             /// <returns> Builder. </returns>
            public Builder ClientObjectId(string clientObjectId)
            {
                shouldSerialize["client_object_id"] = true;
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
                shouldSerialize["object_id"] = true;
                this.objectId = objectId;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetClientObjectId()
            {
                this.shouldSerialize["client_object_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetObjectId()
            {
                this.shouldSerialize["object_id"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogIdMapping. </returns>
            public CatalogIdMapping Build()
            {
                return new CatalogIdMapping(shouldSerialize,
                    this.clientObjectId,
                    this.objectId);
            }
        }
    }
}