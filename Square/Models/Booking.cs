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
    /// Booking.
    /// </summary>
    public class Booking
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Booking"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="version">version.</param>
        /// <param name="status">status.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="updatedAt">updated_at.</param>
        /// <param name="startAt">start_at.</param>
        /// <param name="locationId">location_id.</param>
        /// <param name="customerId">customer_id.</param>
        /// <param name="customerNote">customer_note.</param>
        /// <param name="sellerNote">seller_note.</param>
        /// <param name="appointmentSegments">appointment_segments.</param>
        /// <param name="transitionTimeMinutes">transition_time_minutes.</param>
        /// <param name="allDay">all_day.</param>
        /// <param name="locationType">location_type.</param>
        /// <param name="creatorDetails">creator_details.</param>
        /// <param name="source">source.</param>
        public Booking(
            string id = null,
            int? version = null,
            string status = null,
            string createdAt = null,
            string updatedAt = null,
            string startAt = null,
            string locationId = null,
            string customerId = null,
            string customerNote = null,
            string sellerNote = null,
            IList<Models.AppointmentSegment> appointmentSegments = null,
            int? transitionTimeMinutes = null,
            bool? allDay = null,
            string locationType = null,
            Models.BookingCreatorDetails creatorDetails = null,
            string source = null)
        {
            this.Id = id;
            this.Version = version;
            this.Status = status;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
            this.StartAt = startAt;
            this.LocationId = locationId;
            this.CustomerId = customerId;
            this.CustomerNote = customerNote;
            this.SellerNote = sellerNote;
            this.AppointmentSegments = appointmentSegments;
            this.TransitionTimeMinutes = transitionTimeMinutes;
            this.AllDay = allDay;
            this.LocationType = locationType;
            this.CreatorDetails = creatorDetails;
            this.Source = source;
        }

        /// <summary>
        /// A unique ID of this object representing a booking.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The revision number for the booking used for optimistic concurrency.
        /// </summary>
        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public int? Version { get; }

        /// <summary>
        /// Supported booking statuses.
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; }

        /// <summary>
        /// The RFC 3339 timestamp specifying the creation time of this booking.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// The RFC 3339 timestamp specifying the most recent update time of this booking.
        /// </summary>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAt { get; }

        /// <summary>
        /// The RFC 3339 timestamp specifying the starting time of this booking.
        /// </summary>
        [JsonProperty("start_at", NullValueHandling = NullValueHandling.Ignore)]
        public string StartAt { get; }

        /// <summary>
        /// The ID of the [Location]($m/Location) object representing the location where the booked service is provided.
        /// </summary>
        [JsonProperty("location_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationId { get; }

        /// <summary>
        /// The ID of the [Customer]($m/Customer) object representing the customer receiving the booked service.
        /// </summary>
        [JsonProperty("customer_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomerId { get; }

        /// <summary>
        /// The free-text field for the customer to supply notes about the booking. For example, the note can be preferences that cannot be expressed by supported attributes of a relevant [CatalogObject]($m/CatalogObject) instance.
        /// </summary>
        [JsonProperty("customer_note", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomerNote { get; }

        /// <summary>
        /// The free-text field for the seller to supply notes about the booking. For example, the note can be preferences that cannot be expressed by supported attributes of a specific [CatalogObject]($m/CatalogObject) instance.
        /// This field should not be visible to customers.
        /// </summary>
        [JsonProperty("seller_note", NullValueHandling = NullValueHandling.Ignore)]
        public string SellerNote { get; }

        /// <summary>
        /// A list of appointment segments for this booking.
        /// </summary>
        [JsonProperty("appointment_segments", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.AppointmentSegment> AppointmentSegments { get; }

        /// <summary>
        /// Additional time at the end of a booking.
        /// Applications should not make this field visible to customers of a seller.
        /// </summary>
        [JsonProperty("transition_time_minutes", NullValueHandling = NullValueHandling.Ignore)]
        public int? TransitionTimeMinutes { get; }

        /// <summary>
        /// Whether the booking is of a full business day.
        /// </summary>
        [JsonProperty("all_day", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AllDay { get; }

        /// <summary>
        /// Supported types of location where service is provided.
        /// </summary>
        [JsonProperty("location_type", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationType { get; }

        /// <summary>
        /// Information about a booking creator.
        /// </summary>
        [JsonProperty("creator_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.BookingCreatorDetails CreatorDetails { get; }

        /// <summary>
        /// Supported sources a booking was created from.
        /// </summary>
        [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
        public string Source { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Booking : ({string.Join(", ", toStringOutput)})";
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

            return obj is Booking other &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.Version == null && other.Version == null) || (this.Version?.Equals(other.Version) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((this.UpdatedAt == null && other.UpdatedAt == null) || (this.UpdatedAt?.Equals(other.UpdatedAt) == true)) &&
                ((this.StartAt == null && other.StartAt == null) || (this.StartAt?.Equals(other.StartAt) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.CustomerId == null && other.CustomerId == null) || (this.CustomerId?.Equals(other.CustomerId) == true)) &&
                ((this.CustomerNote == null && other.CustomerNote == null) || (this.CustomerNote?.Equals(other.CustomerNote) == true)) &&
                ((this.SellerNote == null && other.SellerNote == null) || (this.SellerNote?.Equals(other.SellerNote) == true)) &&
                ((this.AppointmentSegments == null && other.AppointmentSegments == null) || (this.AppointmentSegments?.Equals(other.AppointmentSegments) == true)) &&
                ((this.TransitionTimeMinutes == null && other.TransitionTimeMinutes == null) || (this.TransitionTimeMinutes?.Equals(other.TransitionTimeMinutes) == true)) &&
                ((this.AllDay == null && other.AllDay == null) || (this.AllDay?.Equals(other.AllDay) == true)) &&
                ((this.LocationType == null && other.LocationType == null) || (this.LocationType?.Equals(other.LocationType) == true)) &&
                ((this.CreatorDetails == null && other.CreatorDetails == null) || (this.CreatorDetails?.Equals(other.CreatorDetails) == true)) &&
                ((this.Source == null && other.Source == null) || (this.Source?.Equals(other.Source) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 817434864;
            hashCode = HashCode.Combine(this.Id, this.Version, this.Status, this.CreatedAt, this.UpdatedAt, this.StartAt, this.LocationId);

            hashCode = HashCode.Combine(hashCode, this.CustomerId, this.CustomerNote, this.SellerNote, this.AppointmentSegments, this.TransitionTimeMinutes, this.AllDay, this.LocationType);

            hashCode = HashCode.Combine(hashCode, this.CreatorDetails, this.Source);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.Version = {(this.Version == null ? "null" : this.Version.ToString())}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status.ToString())}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt == string.Empty ? "" : this.CreatedAt)}");
            toStringOutput.Add($"this.UpdatedAt = {(this.UpdatedAt == null ? "null" : this.UpdatedAt == string.Empty ? "" : this.UpdatedAt)}");
            toStringOutput.Add($"this.StartAt = {(this.StartAt == null ? "null" : this.StartAt == string.Empty ? "" : this.StartAt)}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId == string.Empty ? "" : this.LocationId)}");
            toStringOutput.Add($"this.CustomerId = {(this.CustomerId == null ? "null" : this.CustomerId == string.Empty ? "" : this.CustomerId)}");
            toStringOutput.Add($"this.CustomerNote = {(this.CustomerNote == null ? "null" : this.CustomerNote == string.Empty ? "" : this.CustomerNote)}");
            toStringOutput.Add($"this.SellerNote = {(this.SellerNote == null ? "null" : this.SellerNote == string.Empty ? "" : this.SellerNote)}");
            toStringOutput.Add($"this.AppointmentSegments = {(this.AppointmentSegments == null ? "null" : $"[{string.Join(", ", this.AppointmentSegments)} ]")}");
            toStringOutput.Add($"this.TransitionTimeMinutes = {(this.TransitionTimeMinutes == null ? "null" : this.TransitionTimeMinutes.ToString())}");
            toStringOutput.Add($"this.AllDay = {(this.AllDay == null ? "null" : this.AllDay.ToString())}");
            toStringOutput.Add($"this.LocationType = {(this.LocationType == null ? "null" : this.LocationType.ToString())}");
            toStringOutput.Add($"this.CreatorDetails = {(this.CreatorDetails == null ? "null" : this.CreatorDetails.ToString())}");
            toStringOutput.Add($"this.Source = {(this.Source == null ? "null" : this.Source.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(this.Id)
                .Version(this.Version)
                .Status(this.Status)
                .CreatedAt(this.CreatedAt)
                .UpdatedAt(this.UpdatedAt)
                .StartAt(this.StartAt)
                .LocationId(this.LocationId)
                .CustomerId(this.CustomerId)
                .CustomerNote(this.CustomerNote)
                .SellerNote(this.SellerNote)
                .AppointmentSegments(this.AppointmentSegments)
                .TransitionTimeMinutes(this.TransitionTimeMinutes)
                .AllDay(this.AllDay)
                .LocationType(this.LocationType)
                .CreatorDetails(this.CreatorDetails)
                .Source(this.Source);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string id;
            private int? version;
            private string status;
            private string createdAt;
            private string updatedAt;
            private string startAt;
            private string locationId;
            private string customerId;
            private string customerNote;
            private string sellerNote;
            private IList<Models.AppointmentSegment> appointmentSegments;
            private int? transitionTimeMinutes;
            private bool? allDay;
            private string locationType;
            private Models.BookingCreatorDetails creatorDetails;
            private string source;

             /// <summary>
             /// Id.
             /// </summary>
             /// <param name="id"> id. </param>
             /// <returns> Builder. </returns>
            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

             /// <summary>
             /// Version.
             /// </summary>
             /// <param name="version"> version. </param>
             /// <returns> Builder. </returns>
            public Builder Version(int? version)
            {
                this.version = version;
                return this;
            }

             /// <summary>
             /// Status.
             /// </summary>
             /// <param name="status"> status. </param>
             /// <returns> Builder. </returns>
            public Builder Status(string status)
            {
                this.status = status;
                return this;
            }

             /// <summary>
             /// CreatedAt.
             /// </summary>
             /// <param name="createdAt"> createdAt. </param>
             /// <returns> Builder. </returns>
            public Builder CreatedAt(string createdAt)
            {
                this.createdAt = createdAt;
                return this;
            }

             /// <summary>
             /// UpdatedAt.
             /// </summary>
             /// <param name="updatedAt"> updatedAt. </param>
             /// <returns> Builder. </returns>
            public Builder UpdatedAt(string updatedAt)
            {
                this.updatedAt = updatedAt;
                return this;
            }

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
             /// CustomerId.
             /// </summary>
             /// <param name="customerId"> customerId. </param>
             /// <returns> Builder. </returns>
            public Builder CustomerId(string customerId)
            {
                this.customerId = customerId;
                return this;
            }

             /// <summary>
             /// CustomerNote.
             /// </summary>
             /// <param name="customerNote"> customerNote. </param>
             /// <returns> Builder. </returns>
            public Builder CustomerNote(string customerNote)
            {
                this.customerNote = customerNote;
                return this;
            }

             /// <summary>
             /// SellerNote.
             /// </summary>
             /// <param name="sellerNote"> sellerNote. </param>
             /// <returns> Builder. </returns>
            public Builder SellerNote(string sellerNote)
            {
                this.sellerNote = sellerNote;
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
             /// TransitionTimeMinutes.
             /// </summary>
             /// <param name="transitionTimeMinutes"> transitionTimeMinutes. </param>
             /// <returns> Builder. </returns>
            public Builder TransitionTimeMinutes(int? transitionTimeMinutes)
            {
                this.transitionTimeMinutes = transitionTimeMinutes;
                return this;
            }

             /// <summary>
             /// AllDay.
             /// </summary>
             /// <param name="allDay"> allDay. </param>
             /// <returns> Builder. </returns>
            public Builder AllDay(bool? allDay)
            {
                this.allDay = allDay;
                return this;
            }

             /// <summary>
             /// LocationType.
             /// </summary>
             /// <param name="locationType"> locationType. </param>
             /// <returns> Builder. </returns>
            public Builder LocationType(string locationType)
            {
                this.locationType = locationType;
                return this;
            }

             /// <summary>
             /// CreatorDetails.
             /// </summary>
             /// <param name="creatorDetails"> creatorDetails. </param>
             /// <returns> Builder. </returns>
            public Builder CreatorDetails(Models.BookingCreatorDetails creatorDetails)
            {
                this.creatorDetails = creatorDetails;
                return this;
            }

             /// <summary>
             /// Source.
             /// </summary>
             /// <param name="source"> source. </param>
             /// <returns> Builder. </returns>
            public Builder Source(string source)
            {
                this.source = source;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> Booking. </returns>
            public Booking Build()
            {
                return new Booking(
                    this.id,
                    this.version,
                    this.status,
                    this.createdAt,
                    this.updatedAt,
                    this.startAt,
                    this.locationId,
                    this.customerId,
                    this.customerNote,
                    this.sellerNote,
                    this.appointmentSegments,
                    this.transitionTimeMinutes,
                    this.allDay,
                    this.locationType,
                    this.creatorDetails,
                    this.source);
            }
        }
    }
}