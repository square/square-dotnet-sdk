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
    /// CatalogTimePeriod.
    /// </summary>
    public class CatalogTimePeriod
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogTimePeriod"/> class.
        /// </summary>
        /// <param name="mEvent">event.</param>
        public CatalogTimePeriod(
            string mEvent = null)
        {
            this.MEvent = mEvent;
        }

        /// <summary>
        /// An iCalendar (RFC 5545) [event](https://tools.ietf.org/html/rfc5545#section-3.6.1), which
        /// specifies the name, timing, duration and recurrence of this time period.
        /// Example:
        /// ```
        /// DTSTART:20190707T180000
        /// DURATION:P2H
        /// RRULE:FREQ=WEEKLY;BYDAY=MO,WE,FR
        /// ```
        /// Only `SUMMARY`, `DTSTART`, `DURATION` and `RRULE` fields are supported.
        /// `DTSTART` must be in local (unzoned) time format. Note that while `BEGIN:VEVENT`
        /// and `END:VEVENT` is not required in the request. The response will always
        /// include them.
        /// </summary>
        [JsonProperty("event", NullValueHandling = NullValueHandling.Ignore)]
        public string MEvent { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogTimePeriod : ({string.Join(", ", toStringOutput)})";
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

            return obj is CatalogTimePeriod other &&
                ((this.MEvent == null && other.MEvent == null) || (this.MEvent?.Equals(other.MEvent) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1787594864;

            if (this.MEvent != null)
            {
               hashCode += this.MEvent.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.MEvent = {(this.MEvent == null ? "null" : this.MEvent == string.Empty ? "" : this.MEvent)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .MEvent(this.MEvent);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string mEvent;

             /// <summary>
             /// MEvent.
             /// </summary>
             /// <param name="mEvent"> mEvent. </param>
             /// <returns> Builder. </returns>
            public Builder MEvent(string mEvent)
            {
                this.mEvent = mEvent;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogTimePeriod. </returns>
            public CatalogTimePeriod Build()
            {
                return new CatalogTimePeriod(
                    this.mEvent);
            }
        }
    }
}