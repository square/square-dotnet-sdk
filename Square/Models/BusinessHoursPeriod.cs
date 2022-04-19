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
    /// BusinessHoursPeriod.
    /// </summary>
    public class BusinessHoursPeriod
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessHoursPeriod"/> class.
        /// </summary>
        /// <param name="dayOfWeek">day_of_week.</param>
        /// <param name="startLocalTime">start_local_time.</param>
        /// <param name="endLocalTime">end_local_time.</param>
        public BusinessHoursPeriod(
            string dayOfWeek = null,
            string startLocalTime = null,
            string endLocalTime = null)
        {
            this.DayOfWeek = dayOfWeek;
            this.StartLocalTime = startLocalTime;
            this.EndLocalTime = endLocalTime;
        }

        /// <summary>
        /// Indicates the specific day  of the week.
        /// </summary>
        [JsonProperty("day_of_week", NullValueHandling = NullValueHandling.Ignore)]
        public string DayOfWeek { get; }

        /// <summary>
        /// The start time of a business hours period, specified in local time using partial-time
        /// RFC 3339 format. For example, `8:30:00` for a period starting at 8:30 in the morning.
        /// Note that the seconds value is always :00, but it is appended for conformance to the RFC.
        /// </summary>
        [JsonProperty("start_local_time", NullValueHandling = NullValueHandling.Ignore)]
        public string StartLocalTime { get; }

        /// <summary>
        /// The end time of a business hours period, specified in local time using partial-time
        /// RFC 3339 format. For example, `21:00:00` for a period ending at 9:00 in the evening.
        /// Note that the seconds value is always :00, but it is appended for conformance to the RFC.
        /// </summary>
        [JsonProperty("end_local_time", NullValueHandling = NullValueHandling.Ignore)]
        public string EndLocalTime { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BusinessHoursPeriod : ({string.Join(", ", toStringOutput)})";
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

            return obj is BusinessHoursPeriod other &&
                ((this.DayOfWeek == null && other.DayOfWeek == null) || (this.DayOfWeek?.Equals(other.DayOfWeek) == true)) &&
                ((this.StartLocalTime == null && other.StartLocalTime == null) || (this.StartLocalTime?.Equals(other.StartLocalTime) == true)) &&
                ((this.EndLocalTime == null && other.EndLocalTime == null) || (this.EndLocalTime?.Equals(other.EndLocalTime) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 870467587;
            hashCode = HashCode.Combine(this.DayOfWeek, this.StartLocalTime, this.EndLocalTime);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.DayOfWeek = {(this.DayOfWeek == null ? "null" : this.DayOfWeek.ToString())}");
            toStringOutput.Add($"this.StartLocalTime = {(this.StartLocalTime == null ? "null" : this.StartLocalTime == string.Empty ? "" : this.StartLocalTime)}");
            toStringOutput.Add($"this.EndLocalTime = {(this.EndLocalTime == null ? "null" : this.EndLocalTime == string.Empty ? "" : this.EndLocalTime)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .DayOfWeek(this.DayOfWeek)
                .StartLocalTime(this.StartLocalTime)
                .EndLocalTime(this.EndLocalTime);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string dayOfWeek;
            private string startLocalTime;
            private string endLocalTime;

             /// <summary>
             /// DayOfWeek.
             /// </summary>
             /// <param name="dayOfWeek"> dayOfWeek. </param>
             /// <returns> Builder. </returns>
            public Builder DayOfWeek(string dayOfWeek)
            {
                this.dayOfWeek = dayOfWeek;
                return this;
            }

             /// <summary>
             /// StartLocalTime.
             /// </summary>
             /// <param name="startLocalTime"> startLocalTime. </param>
             /// <returns> Builder. </returns>
            public Builder StartLocalTime(string startLocalTime)
            {
                this.startLocalTime = startLocalTime;
                return this;
            }

             /// <summary>
             /// EndLocalTime.
             /// </summary>
             /// <param name="endLocalTime"> endLocalTime. </param>
             /// <returns> Builder. </returns>
            public Builder EndLocalTime(string endLocalTime)
            {
                this.endLocalTime = endLocalTime;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> BusinessHoursPeriod. </returns>
            public BusinessHoursPeriod Build()
            {
                return new BusinessHoursPeriod(
                    this.dayOfWeek,
                    this.startLocalTime,
                    this.endLocalTime);
            }
        }
    }
}