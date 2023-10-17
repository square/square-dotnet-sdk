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
    using Square.Http.Client;
    using Square.Utilities;

    /// <summary>
    /// RetrieveLocationBookingProfileResponse.
    /// </summary>
    public class RetrieveLocationBookingProfileResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RetrieveLocationBookingProfileResponse"/> class.
        /// </summary>
        /// <param name="locationBookingProfile">location_booking_profile.</param>
        /// <param name="errors">errors.</param>
        public RetrieveLocationBookingProfileResponse(
            Models.LocationBookingProfile locationBookingProfile = null,
            IList<Models.Error> errors = null)
        {
            this.LocationBookingProfile = locationBookingProfile;
            this.Errors = errors;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// The booking profile of a seller's location, including the location's ID and whether the location is enabled for online booking.
        /// </summary>
        [JsonProperty("location_booking_profile", NullValueHandling = NullValueHandling.Ignore)]
        public Models.LocationBookingProfile LocationBookingProfile { get; }

        /// <summary>
        /// Errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"RetrieveLocationBookingProfileResponse : ({string.Join(", ", toStringOutput)})";
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
            return obj is RetrieveLocationBookingProfileResponse other &&                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.LocationBookingProfile == null && other.LocationBookingProfile == null) || (this.LocationBookingProfile?.Equals(other.LocationBookingProfile) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1211764508;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.LocationBookingProfile, this.Errors);

            return hashCode;
        }
        internal RetrieveLocationBookingProfileResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add($"this.LocationBookingProfile = {(this.LocationBookingProfile == null ? "null" : this.LocationBookingProfile.ToString())}");
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .LocationBookingProfile(this.LocationBookingProfile)
                .Errors(this.Errors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.LocationBookingProfile locationBookingProfile;
            private IList<Models.Error> errors;

             /// <summary>
             /// LocationBookingProfile.
             /// </summary>
             /// <param name="locationBookingProfile"> locationBookingProfile. </param>
             /// <returns> Builder. </returns>
            public Builder LocationBookingProfile(Models.LocationBookingProfile locationBookingProfile)
            {
                this.locationBookingProfile = locationBookingProfile;
                return this;
            }

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
            /// Builds class object.
            /// </summary>
            /// <returns> RetrieveLocationBookingProfileResponse. </returns>
            public RetrieveLocationBookingProfileResponse Build()
            {
                return new RetrieveLocationBookingProfileResponse(
                    this.locationBookingProfile,
                    this.errors);
            }
        }
    }
}