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
    /// DateRange.
    /// </summary>
    public class DateRange
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="DateRange"/> class.
        /// </summary>
        /// <param name="startDate">start_date.</param>
        /// <param name="endDate">end_date.</param>
        public DateRange(
            string startDate = null,
            string endDate = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "start_date", false },
                { "end_date", false }
            };

            if (startDate != null)
            {
                shouldSerialize["start_date"] = true;
                this.StartDate = startDate;
            }

            if (endDate != null)
            {
                shouldSerialize["end_date"] = true;
                this.EndDate = endDate;
            }

        }
        internal DateRange(Dictionary<string, bool> shouldSerialize,
            string startDate = null,
            string endDate = null)
        {
            this.shouldSerialize = shouldSerialize;
            StartDate = startDate;
            EndDate = endDate;
        }

        /// <summary>
        /// A string in `YYYY-MM-DD` format, such as `2017-10-31`, per the ISO 8601
        /// extended format for calendar dates.
        /// The beginning of a date range (inclusive).
        /// </summary>
        [JsonProperty("start_date")]
        public string StartDate { get; }

        /// <summary>
        /// A string in `YYYY-MM-DD` format, such as `2017-10-31`, per the ISO 8601
        /// extended format for calendar dates.
        /// The end of a date range (inclusive).
        /// </summary>
        [JsonProperty("end_date")]
        public string EndDate { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"DateRange : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeStartDate()
        {
            return this.shouldSerialize["start_date"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEndDate()
        {
            return this.shouldSerialize["end_date"];
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
            return obj is DateRange other &&                ((this.StartDate == null && other.StartDate == null) || (this.StartDate?.Equals(other.StartDate) == true)) &&
                ((this.EndDate == null && other.EndDate == null) || (this.EndDate?.Equals(other.EndDate) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1178039224;
            hashCode = HashCode.Combine(this.StartDate, this.EndDate);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.StartDate = {(this.StartDate == null ? "null" : this.StartDate)}");
            toStringOutput.Add($"this.EndDate = {(this.EndDate == null ? "null" : this.EndDate)}");
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
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "start_date", false },
                { "end_date", false },
            };

            private string startDate;
            private string endDate;

             /// <summary>
             /// StartDate.
             /// </summary>
             /// <param name="startDate"> startDate. </param>
             /// <returns> Builder. </returns>
            public Builder StartDate(string startDate)
            {
                shouldSerialize["start_date"] = true;
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
                shouldSerialize["end_date"] = true;
                this.endDate = endDate;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetStartDate()
            {
                this.shouldSerialize["start_date"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetEndDate()
            {
                this.shouldSerialize["end_date"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> DateRange. </returns>
            public DateRange Build()
            {
                return new DateRange(shouldSerialize,
                    this.startDate,
                    this.endDate);
            }
        }
    }
}