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
    /// RetrieveBusinessBookingProfileResponse.
    /// </summary>
    public class RetrieveBusinessBookingProfileResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RetrieveBusinessBookingProfileResponse"/> class.
        /// </summary>
        /// <param name="businessBookingProfile">business_booking_profile.</param>
        /// <param name="errors">errors.</param>
        public RetrieveBusinessBookingProfileResponse(
            Models.BusinessBookingProfile businessBookingProfile = null,
            IList<Models.Error> errors = null)
        {
            this.BusinessBookingProfile = businessBookingProfile;
            this.Errors = errors;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Gets or sets BusinessBookingProfile.
        /// </summary>
        [JsonProperty("business_booking_profile", NullValueHandling = NullValueHandling.Ignore)]
        public Models.BusinessBookingProfile BusinessBookingProfile { get; }

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

            return $"RetrieveBusinessBookingProfileResponse : ({string.Join(", ", toStringOutput)})";
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
            return obj is RetrieveBusinessBookingProfileResponse other &&                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.BusinessBookingProfile == null && other.BusinessBookingProfile == null) || (this.BusinessBookingProfile?.Equals(other.BusinessBookingProfile) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1635211081;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.BusinessBookingProfile, this.Errors);

            return hashCode;
        }
        internal RetrieveBusinessBookingProfileResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add($"this.BusinessBookingProfile = {(this.BusinessBookingProfile == null ? "null" : this.BusinessBookingProfile.ToString())}");
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .BusinessBookingProfile(this.BusinessBookingProfile)
                .Errors(this.Errors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.BusinessBookingProfile businessBookingProfile;
            private IList<Models.Error> errors;

             /// <summary>
             /// BusinessBookingProfile.
             /// </summary>
             /// <param name="businessBookingProfile"> businessBookingProfile. </param>
             /// <returns> Builder. </returns>
            public Builder BusinessBookingProfile(Models.BusinessBookingProfile businessBookingProfile)
            {
                this.businessBookingProfile = businessBookingProfile;
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
            /// <returns> RetrieveBusinessBookingProfileResponse. </returns>
            public RetrieveBusinessBookingProfileResponse Build()
            {
                return new RetrieveBusinessBookingProfileResponse(
                    this.businessBookingProfile,
                    this.errors);
            }
        }
    }
}