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