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
    using Square.Utilities;

    /// <summary>
    /// WorkweekConfig.
    /// </summary>
    public class WorkweekConfig
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkweekConfig"/> class.
        /// </summary>
        /// <param name="startOfWeek">start_of_week.</param>
        /// <param name="startOfDayLocalTime">start_of_day_local_time.</param>
        /// <param name="id">id.</param>
        /// <param name="version">version.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="updatedAt">updated_at.</param>
        public WorkweekConfig(
            string startOfWeek,
            string startOfDayLocalTime,
            string id = null,
            int? version = null,
            string createdAt = null,
            string updatedAt = null)
        {
            this.Id = id;
            this.StartOfWeek = startOfWeek;
            this.StartOfDayLocalTime = startOfDayLocalTime;
            this.Version = version;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
        }

        /// <summary>
        /// The UUID for this object.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The days of the week.
        /// </summary>
        [JsonProperty("start_of_week")]
        public string StartOfWeek { get; }

        /// <summary>
        /// The local time at which a business week starts. Represented as a
        /// string in `HH:MM` format (`HH:MM:SS` is also accepted, but seconds are
        /// truncated).
        /// </summary>
        [JsonProperty("start_of_day_local_time")]
        public string StartOfDayLocalTime { get; }

        /// <summary>
        /// Used for resolving concurrency issues. The request fails if the version
        /// provided does not match the server version at the time of the request. If not provided,
        /// Square executes a blind write; potentially overwriting data from another
        /// write.
        /// </summary>
        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public int? Version { get; }

        /// <summary>
        /// A read-only timestamp in RFC 3339 format; presented in UTC.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// A read-only timestamp in RFC 3339 format; presented in UTC.
        /// </summary>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAt { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"WorkweekConfig : ({string.Join(", ", toStringOutput)})";
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
            return obj is WorkweekConfig other &&                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.StartOfWeek == null && other.StartOfWeek == null) || (this.StartOfWeek?.Equals(other.StartOfWeek) == true)) &&
                ((this.StartOfDayLocalTime == null && other.StartOfDayLocalTime == null) || (this.StartOfDayLocalTime?.Equals(other.StartOfDayLocalTime) == true)) &&
                ((this.Version == null && other.Version == null) || (this.Version?.Equals(other.Version) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((this.UpdatedAt == null && other.UpdatedAt == null) || (this.UpdatedAt?.Equals(other.UpdatedAt) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1176790268;
            hashCode = HashCode.Combine(this.Id, this.StartOfWeek, this.StartOfDayLocalTime, this.Version, this.CreatedAt, this.UpdatedAt);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.StartOfWeek = {(this.StartOfWeek == null ? "null" : this.StartOfWeek.ToString())}");
            toStringOutput.Add($"this.StartOfDayLocalTime = {(this.StartOfDayLocalTime == null ? "null" : this.StartOfDayLocalTime)}");
            toStringOutput.Add($"this.Version = {(this.Version == null ? "null" : this.Version.ToString())}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt)}");
            toStringOutput.Add($"this.UpdatedAt = {(this.UpdatedAt == null ? "null" : this.UpdatedAt)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.StartOfWeek,
                this.StartOfDayLocalTime)
                .Id(this.Id)
                .Version(this.Version)
                .CreatedAt(this.CreatedAt)
                .UpdatedAt(this.UpdatedAt);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string startOfWeek;
            private string startOfDayLocalTime;
            private string id;
            private int? version;
            private string createdAt;
            private string updatedAt;

            public Builder(
                string startOfWeek,
                string startOfDayLocalTime)
            {
                this.startOfWeek = startOfWeek;
                this.startOfDayLocalTime = startOfDayLocalTime;
            }

             /// <summary>
             /// StartOfWeek.
             /// </summary>
             /// <param name="startOfWeek"> startOfWeek. </param>
             /// <returns> Builder. </returns>
            public Builder StartOfWeek(string startOfWeek)
            {
                this.startOfWeek = startOfWeek;
                return this;
            }

             /// <summary>
             /// StartOfDayLocalTime.
             /// </summary>
             /// <param name="startOfDayLocalTime"> startOfDayLocalTime. </param>
             /// <returns> Builder. </returns>
            public Builder StartOfDayLocalTime(string startOfDayLocalTime)
            {
                this.startOfDayLocalTime = startOfDayLocalTime;
                return this;
            }

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
            /// Builds class object.
            /// </summary>
            /// <returns> WorkweekConfig. </returns>
            public WorkweekConfig Build()
            {
                return new WorkweekConfig(
                    this.startOfWeek,
                    this.startOfDayLocalTime,
                    this.id,
                    this.version,
                    this.createdAt,
                    this.updatedAt);
            }
        }
    }
}