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

namespace Square.Models
{
    /// <summary>
    /// CatalogAvailabilityPeriod.
    /// </summary>
    public class CatalogAvailabilityPeriod
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogAvailabilityPeriod"/> class.
        /// </summary>
        /// <param name="startLocalTime">start_local_time.</param>
        /// <param name="endLocalTime">end_local_time.</param>
        /// <param name="dayOfWeek">day_of_week.</param>
        public CatalogAvailabilityPeriod(
            string startLocalTime = null,
            string endLocalTime = null,
            string dayOfWeek = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "start_local_time", false },
                { "end_local_time", false }
            };

            if (startLocalTime != null)
            {
                shouldSerialize["start_local_time"] = true;
                this.StartLocalTime = startLocalTime;
            }

            if (endLocalTime != null)
            {
                shouldSerialize["end_local_time"] = true;
                this.EndLocalTime = endLocalTime;
            }

            this.DayOfWeek = dayOfWeek;
        }
        internal CatalogAvailabilityPeriod(Dictionary<string, bool> shouldSerialize,
            string startLocalTime = null,
            string endLocalTime = null,
            string dayOfWeek = null)
        {
            this.shouldSerialize = shouldSerialize;
            StartLocalTime = startLocalTime;
            EndLocalTime = endLocalTime;
            DayOfWeek = dayOfWeek;
        }

        /// <summary>
        /// The start time of an availability period, specified in local time using partial-time
        /// RFC 3339 format. For example, `8:30:00` for a period starting at 8:30 in the morning.
        /// Note that the seconds value is always :00, but it is appended for conformance to the RFC.
        /// </summary>
        [JsonProperty("start_local_time")]
        public string StartLocalTime { get; }

        /// <summary>
        /// The end time of an availability period, specified in local time using partial-time
        /// RFC 3339 format. For example, `21:00:00` for a period ending at 9:00 in the evening.
        /// Note that the seconds value is always :00, but it is appended for conformance to the RFC.
        /// </summary>
        [JsonProperty("end_local_time")]
        public string EndLocalTime { get; }

        /// <summary>
        /// Indicates the specific day  of the week.
        /// </summary>
        [JsonProperty("day_of_week", NullValueHandling = NullValueHandling.Ignore)]
        public string DayOfWeek { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogAvailabilityPeriod : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeStartLocalTime()
        {
            return this.shouldSerialize["start_local_time"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEndLocalTime()
        {
            return this.shouldSerialize["end_local_time"];
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
            return obj is CatalogAvailabilityPeriod other &&                ((this.StartLocalTime == null && other.StartLocalTime == null) || (this.StartLocalTime?.Equals(other.StartLocalTime) == true)) &&
                ((this.EndLocalTime == null && other.EndLocalTime == null) || (this.EndLocalTime?.Equals(other.EndLocalTime) == true)) &&
                ((this.DayOfWeek == null && other.DayOfWeek == null) || (this.DayOfWeek?.Equals(other.DayOfWeek) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -965005458;
            hashCode = HashCode.Combine(this.StartLocalTime, this.EndLocalTime, this.DayOfWeek);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.StartLocalTime = {(this.StartLocalTime == null ? "null" : this.StartLocalTime)}");
            toStringOutput.Add($"this.EndLocalTime = {(this.EndLocalTime == null ? "null" : this.EndLocalTime)}");
            toStringOutput.Add($"this.DayOfWeek = {(this.DayOfWeek == null ? "null" : this.DayOfWeek.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .StartLocalTime(this.StartLocalTime)
                .EndLocalTime(this.EndLocalTime)
                .DayOfWeek(this.DayOfWeek);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "start_local_time", false },
                { "end_local_time", false },
            };

            private string startLocalTime;
            private string endLocalTime;
            private string dayOfWeek;

             /// <summary>
             /// StartLocalTime.
             /// </summary>
             /// <param name="startLocalTime"> startLocalTime. </param>
             /// <returns> Builder. </returns>
            public Builder StartLocalTime(string startLocalTime)
            {
                shouldSerialize["start_local_time"] = true;
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
                shouldSerialize["end_local_time"] = true;
                this.endLocalTime = endLocalTime;
                return this;
            }

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
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetStartLocalTime()
            {
                this.shouldSerialize["start_local_time"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetEndLocalTime()
            {
                this.shouldSerialize["end_local_time"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogAvailabilityPeriod. </returns>
            public CatalogAvailabilityPeriod Build()
            {
                return new CatalogAvailabilityPeriod(shouldSerialize,
                    this.startLocalTime,
                    this.endLocalTime,
                    this.dayOfWeek);
            }
        }
    }
}