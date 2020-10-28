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
    public class CreateMobileAuthorizationCodeRequest 
    {
        public CreateMobileAuthorizationCodeRequest(string locationId = null)
        {
            LocationId = locationId;
        }

        /// <summary>
        /// The Square location ID the authorization code should be tied to.
        /// </summary>
        [JsonProperty("location_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationId { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .LocationId(LocationId);
            return builder;
        }

        public class Builder
        {
            private string locationId;



            public Builder LocationId(string locationId)
            {
                this.locationId = locationId;
                return this;
            }

            public CreateMobileAuthorizationCodeRequest Build()
            {
                return new CreateMobileAuthorizationCodeRequest(locationId);
            }
        }
    }
}