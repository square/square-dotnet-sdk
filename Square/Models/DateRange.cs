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
    /// DateRange.
    /// </summary>
    public class DateRange
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DateRange"/> class.
        /// </summary>
        /// <param name="startDate">start_date.</param>
        /// <param name="endDate">end_date.</param>
        public DateRange(
            string startDate = null,
            string endDate = null)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
        }

        /// <summary>
        /// String in `YYYY-MM-DD` format, e.g. `2017-10-31` per the ISO 8601
        /// extended format for calendar dates.
        /// The beginning of a date range (inclusive)
        /// </summary>
        [JsonProperty("start_date", NullValueHandling = NullValueHandling.Ignore)]
        public string StartDate { get; }

        /// <summary>
        /// String in `YYYY-MM-DD` format, e.g. `2017-10-31` per the ISO 8601
        /// extended format for calendar dates.
        /// The end of a date range (inclusive)
        /// </summary>
        [JsonProperty("end_date", NullValueHandling = NullValueHandling.Ignore)]
        public string EndDate { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"DateRange : ({string.Join(", ", toStringOutput)})";
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

            return obj is DateRange other &&
                ((this.StartDate == null && other.StartDate == null) || (this.StartDate?.Equals(other.StartDate) == true)) &&
                ((this.EndDate == null && other.EndDate == null) || (this.EndDate?.Equals(other.EndDate) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1178039224;

            if (this.StartDate != null)
            {
               hashCode += this.StartDate.GetHashCode();
            }

            if (this.EndDate != null)
            {
               hashCode += this.EndDate.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.StartDate = {(this.StartDate == null ? "null" : this.StartDate == string.Empty ? "" : this.StartDate)}");
            toStringOutput.Add($"this.EndDate = {(this.EndDate == null ? "null" : this.EndDate == string.Empty ? "" : this.EndDate)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .StartDate(this.StartDate)
                .EndDate(this.EndDate);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string startDate;
            private string endDate;

             /// <summary>
             /// StartDate.
             /// </summary>
             /// <param name="startDate"> startDate. </param>
             /// <returns> Builder. </returns>
            public Builder StartDate(string startDate)
            {
                this.startDate = startDate;
                return this;
            }

             /// <summary>
             /// EndDate.
             /// </summary>
             /// <param name="endDate"> endDate. </param>
             /// <returns> Builder. </returns>
            public Builder EndDate(string endDate)
            {
                this.endDate = endDate;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> DateRange. </returns>
            public DateRange Build()
            {
                return new DateRange(
                    this.startDate,
                    this.endDate);
            }
        }
    }
}