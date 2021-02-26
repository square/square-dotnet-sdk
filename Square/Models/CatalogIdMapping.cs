
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
    public class CatalogIdMapping 
    {
        public CatalogIdMapping(string clientObjectId = null,
            string objectId = null)
        {
            ClientObjectId = clientObjectId;
            ObjectId = objectId;
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogIdMapping : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"ClientObjectId = {(ClientObjectId == null ? "null" : ClientObjectId == string.Empty ? "" : ClientObjectId)}");
            toStringOutput.Add($"ObjectId = {(ObjectId == null ? "null" : ObjectId == string.Empty ? "" : ObjectId)}");
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

            return obj is CatalogIdMapping other &&
                ((ClientObjectId == null && other.ClientObjectId == null) || (ClientObjectId?.Equals(other.ClientObjectId) == true)) &&
                ((ObjectId == null && other.ObjectId == null) || (ObjectId?.Equals(other.ObjectId) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -2090188884;

            if (ClientObjectId != null)
            {
               hashCode += ClientObjectId.GetHashCode();
            }

            if (ObjectId != null)
            {
               hashCode += ObjectId.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .ClientObjectId(ClientObjectId)
                .ObjectId(ObjectId);
            return builder;
        }

        public class Builder
        {
            private string clientObjectId;
            private string objectId;



            public Builder ClientObjectId(string clientObjectId)
            {
                this.clientObjectId = clientObjectId;
                return this;
            }

            public Builder ObjectId(string objectId)
            {
                this.objectId = objectId;
                return this;
            }

            public CatalogIdMapping Build()
            {
                return new CatalogIdMapping(clientObjectId,
                    objectId);
            }
        }
    }
}