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
    /// ListLocationBookingProfilesResponse.
    /// </summary>
    public class ListLocationBookingProfilesResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListLocationBookingProfilesResponse"/> class.
        /// </summary>
        /// <param name="locationBookingProfiles">location_booking_profiles.</param>
        /// <param name="cursor">cursor.</param>
        /// <param name="errors">errors.</param>
        public ListLocationBookingProfilesResponse(
            IList<Models.LocationBookingProfile> locationBookingProfiles = null,
            string cursor = null,
            IList<Models.Error> errors = null)
        {
            this.LocationBookingProfiles = locationBookingProfiles;
            this.Cursor = cursor;
            this.Errors = errors;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// The list of a seller's location booking profiles.
        /// </summary>
        [JsonProperty("location_booking_profiles", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.LocationBookingProfile> LocationBookingProfiles { get; }

        /// <summary>
        /// The pagination cursor to be used in the subsequent request to get the next page of the results. Stop retrieving the next page of the results when the cursor is not set.
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

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

            return $"ListLocationBookingProfilesResponse : ({string.Join(", ", toStringOutput)})";
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
            return obj is ListLocationBookingProfilesResponse other &&                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.LocationBookingProfiles == null && other.LocationBookingProfiles == null) || (this.LocationBookingProfiles?.Equals(other.LocationBookingProfiles) == true)) &&
                ((this.Cursor == null && other.Cursor == null) || (this.Cursor?.Equals(other.Cursor) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 904318020;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.LocationBookingProfiles, this.Cursor, this.Errors);

            return hashCode;
        }
        internal ListLocationBookingProfilesResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add($"this.LocationBookingProfiles = {(this.LocationBookingProfiles == null ? "null" : $"[{string.Join(", ", this.LocationBookingProfiles)} ]")}");
            toStringOutput.Add($"this.Cursor = {(this.Cursor == null ? "null" : this.Cursor)}");
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .LocationBookingProfiles(this.LocationBookingProfiles)
                .Cursor(this.Cursor)
                .Errors(this.Errors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.LocationBookingProfile> locationBookingProfiles;
            private string cursor;
            private IList<Models.Error> errors;

             /// <summary>
             /// LocationBookingProfiles.
             /// </summary>
             /// <param name="locationBookingProfiles"> locationBookingProfiles. </param>
             /// <returns> Builder. </returns>
            public Builder LocationBookingProfiles(IList<Models.LocationBookingProfile> locationBookingProfiles)
            {
                this.locationBookingProfiles = locationBookingProfiles;
                return this;
            }

             /// <summary>
             /// Cursor.
             /// </summary>
             /// <param name="cursor"> cursor. </param>
             /// <returns> Builder. </returns>
            public Builder Cursor(string cursor)
            {
                this.cursor = cursor;
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
            /// <returns> ListLocationBookingProfilesResponse. </returns>
            public ListLocationBookingProfilesResponse Build()
            {
                return new ListLocationBookingProfilesResponse(
                    this.locationBookingProfiles,
                    this.cursor,
                    this.errors);
            }
        }
    }
}