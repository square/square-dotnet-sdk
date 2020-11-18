using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square.Http.Client;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class RetrieveBusinessBookingProfileResponse 
    {
        public RetrieveBusinessBookingProfileResponse(Models.BusinessBookingProfile businessBookingProfile = null,
            IList<Models.Error> errors = null)
        {
            BusinessBookingProfile = businessBookingProfile;
            Errors = errors;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Getter for business_booking_profile
        /// </summary>
        [JsonProperty("business_booking_profile", NullValueHandling = NullValueHandling.Ignore)]
        public Models.BusinessBookingProfile BusinessBookingProfile { get; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .BusinessBookingProfile(BusinessBookingProfile)
                .Errors(Errors);
            return builder;
        }

        public class Builder
        {
            private Models.BusinessBookingProfile businessBookingProfile;
            private IList<Models.Error> errors;



            public Builder BusinessBookingProfile(Models.BusinessBookingProfile businessBookingProfile)
            {
                this.businessBookingProfile = businessBookingProfile;
                return this;
            }

            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public RetrieveBusinessBookingProfileResponse Build()
            {
                return new RetrieveBusinessBookingProfileResponse(businessBookingProfile,
                    errors);
            }
        }
    }
}