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
using Square.Legacy;
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// LocationBookingProfile.
    /// </summary>
    public class LocationBookingProfile
    {
        private readonly Dictionary<string, bool> shouldSerialize;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationBookingProfile"/> class.
        /// </summary>
        /// <param name="locationId">location_id.</param>
        /// <param name="bookingSiteUrl">booking_site_url.</param>
        /// <param name="onlineBookingEnabled">online_booking_enabled.</param>
        public LocationBookingProfile(
            string locationId = null,
            string bookingSiteUrl = null,
            bool? onlineBookingEnabled = null
        )
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "location_id", false },
                { "booking_site_url", false },
                { "online_booking_enabled", false },
            };

            if (locationId != null)
            {
                shouldSerialize["location_id"] = true;
                this.LocationId = locationId;
            }

            if (bookingSiteUrl != null)
            {
                shouldSerialize["booking_site_url"] = true;
                this.BookingSiteUrl = bookingSiteUrl;
            }

            if (onlineBookingEnabled != null)
            {
                shouldSerialize["online_booking_enabled"] = true;
                this.OnlineBookingEnabled = onlineBookingEnabled;
            }
        }

        internal LocationBookingProfile(
            Dictionary<string, bool> shouldSerialize,
            string locationId = null,
            string bookingSiteUrl = null,
            bool? onlineBookingEnabled = null
        )
        {
            this.shouldSerialize = shouldSerialize;
            LocationId = locationId;
            BookingSiteUrl = bookingSiteUrl;
            OnlineBookingEnabled = onlineBookingEnabled;
        }

        /// <summary>
        /// The ID of the [location](entity:Location).
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        /// <summary>
        /// Url for the online booking site for this location.
        /// </summary>
        [JsonProperty("booking_site_url")]
        public string BookingSiteUrl { get; }

        /// <summary>
        /// Indicates whether the location is enabled for online booking.
        /// </summary>
        [JsonProperty("online_booking_enabled")]
        public bool? OnlineBookingEnabled { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"LocationBookingProfile : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLocationId()
        {
            return this.shouldSerialize["location_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeBookingSiteUrl()
        {
            return this.shouldSerialize["booking_site_url"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeOnlineBookingEnabled()
        {
            return this.shouldSerialize["online_booking_enabled"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is LocationBookingProfile other
                && (
                    this.LocationId == null && other.LocationId == null
                    || this.LocationId?.Equals(other.LocationId) == true
                )
                && (
                    this.BookingSiteUrl == null && other.BookingSiteUrl == null
                    || this.BookingSiteUrl?.Equals(other.BookingSiteUrl) == true
                )
                && (
                    this.OnlineBookingEnabled == null && other.OnlineBookingEnabled == null
                    || this.OnlineBookingEnabled?.Equals(other.OnlineBookingEnabled) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1041209173;
            hashCode = HashCode.Combine(
                hashCode,
                this.LocationId,
                this.BookingSiteUrl,
                this.OnlineBookingEnabled
            );

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.LocationId = {this.LocationId ?? "null"}");
            toStringOutput.Add($"this.BookingSiteUrl = {this.BookingSiteUrl ?? "null"}");
            toStringOutput.Add(
                $"this.OnlineBookingEnabled = {(this.OnlineBookingEnabled == null ? "null" : this.OnlineBookingEnabled.ToString())}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .LocationId(this.LocationId)
                .BookingSiteUrl(this.BookingSiteUrl)
                .OnlineBookingEnabled(this.OnlineBookingEnabled);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "location_id", false },
                { "booking_site_url", false },
                { "online_booking_enabled", false },
            };

            private string locationId;
            private string bookingSiteUrl;
            private bool? onlineBookingEnabled;

            /// <summary>
            /// LocationId.
            /// </summary>
            /// <param name="locationId"> locationId. </param>
            /// <returns> Builder. </returns>
            public Builder LocationId(string locationId)
            {
                shouldSerialize["location_id"] = true;
                this.locationId = locationId;
                return this;
            }

            /// <summary>
            /// BookingSiteUrl.
            /// </summary>
            /// <param name="bookingSiteUrl"> bookingSiteUrl. </param>
            /// <returns> Builder. </returns>
            public Builder BookingSiteUrl(string bookingSiteUrl)
            {
                shouldSerialize["booking_site_url"] = true;
                this.bookingSiteUrl = bookingSiteUrl;
                return this;
            }

            /// <summary>
            /// OnlineBookingEnabled.
            /// </summary>
            /// <param name="onlineBookingEnabled"> onlineBookingEnabled. </param>
            /// <returns> Builder. </returns>
            public Builder OnlineBookingEnabled(bool? onlineBookingEnabled)
            {
                shouldSerialize["online_booking_enabled"] = true;
                this.onlineBookingEnabled = onlineBookingEnabled;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetLocationId()
            {
                this.shouldSerialize["location_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetBookingSiteUrl()
            {
                this.shouldSerialize["booking_site_url"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetOnlineBookingEnabled()
            {
                this.shouldSerialize["online_booking_enabled"] = false;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> LocationBookingProfile. </returns>
            public LocationBookingProfile Build()
            {
                return new LocationBookingProfile(
                    shouldSerialize,
                    this.locationId,
                    this.bookingSiteUrl,
                    this.onlineBookingEnabled
                );
            }
        }
    }
}
