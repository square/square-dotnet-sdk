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
    /// Availability.
    /// </summary>
    public class Availability
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Availability"/> class.
        /// </summary>
        /// <param name="startAt">start_at.</param>
        /// <param name="locationId">location_id.</param>
        /// <param name="appointmentSegments">appointment_segments.</param>
        public Availability(
            string startAt = null,
            string locationId = null,
            IList<Models.AppointmentSegment> appointmentSegments = null)
        {
            this.StartAt = startAt;
            this.LocationId = locationId;
            this.AppointmentSegments = appointmentSegments;
        }

        /// <summary>
        /// The RFC 3339 timestamp specifying the beginning time of the slot available for booking.
        /// </summary>
        [JsonProperty("start_at", NullValueHandling = NullValueHandling.Ignore)]
        public string StartAt { get; }

        /// <summary>
        /// The ID of the location available for booking.
        /// </summary>
        [JsonProperty("location_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationId { get; }

        /// <summary>
        /// The list of appointment segments available for booking
        /// </summary>
        [JsonProperty("appointment_segments", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.AppointmentSegment> AppointmentSegments { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Availability : ({string.Join(", ", toStringOutput)})";
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

            return obj is Availability other &&
                ((this.StartAt == null && other.StartAt == null) || (this.StartAt?.Equals(other.StartAt) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.AppointmentSegments == null && other.AppointmentSegments == null) || (this.AppointmentSegments?.Equals(other.AppointmentSegments) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 133095493;

            if (this.StartAt != null)
            {
               hashCode += this.StartAt.GetHashCode();
            }

            if (this.LocationId != null)
            {
               hashCode += this.LocationId.GetHashCode();
            }

            if (this.AppointmentSegments != null)
            {
               hashCode += this.AppointmentSegments.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.StartAt = {(this.StartAt == null ? "null" : this.StartAt == string.Empty ? "" : this.StartAt)}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId == string.Empty ? "" : this.LocationId)}");
            toStringOutput.Add($"this.AppointmentSegments = {(this.AppointmentSegments == null ? "null" : $"[{string.Join(", ", this.AppointmentSegments)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .StartAt(this.StartAt)
                .LocationId(this.LocationId)
                .AppointmentSegments(this.AppointmentSegments);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string startAt;
            private string locationId;
            private IList<Models.AppointmentSegment> appointmentSegments;

             /// <summary>
             /// StartAt.
             /// </summary>
             /// <param name="startAt"> startAt. </param>
             /// <returns> Builder. </returns>
            public Builder StartAt(string startAt)
            {
                this.startAt = startAt;
                return this;
            }

             /// <summary>
             /// LocationId.
             /// </summary>
             /// <param name="locationId"> locationId. </param>
             /// <returns> Builder. </returns>
            public Builder LocationId(string locationId)
            {
                this.locationId = locationId;
                return this;
            }

             /// <summary>
             /// AppointmentSegments.
             /// </summary>
             /// <param name="appointmentSegments"> appointmentSegments. </param>
             /// <returns> Builder. </returns>
            public Builder AppointmentSegments(IList<Models.AppointmentSegment> appointmentSegments)
            {
                this.appointmentSegments = appointmentSegments;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> Availability. </returns>
            public Availability Build()
            {
                return new Availability(
                    this.startAt,
                    this.locationId,
                    this.appointmentSegments);
            }
        }
    }
}