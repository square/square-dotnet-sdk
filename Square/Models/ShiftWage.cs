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
    /// ShiftWage.
    /// </summary>
    public class ShiftWage
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="ShiftWage"/> class.
        /// </summary>
        /// <param name="title">title.</param>
        /// <param name="hourlyRate">hourly_rate.</param>
        /// <param name="jobId">job_id.</param>
        public ShiftWage(
            string title = null,
            Models.Money hourlyRate = null,
            string jobId = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "title", false }
            };

            if (title != null)
            {
                shouldSerialize["title"] = true;
                this.Title = title;
            }

            this.HourlyRate = hourlyRate;
            this.JobId = jobId;
        }
        internal ShiftWage(Dictionary<string, bool> shouldSerialize,
            string title = null,
            Models.Money hourlyRate = null,
            string jobId = null)
        {
            this.shouldSerialize = shouldSerialize;
            Title = title;
            HourlyRate = hourlyRate;
            JobId = jobId;
        }

        /// <summary>
        /// The name of the job performed during this shift.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("hourly_rate", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money HourlyRate { get; }

        /// <summary>
        /// The id of the job performed during this shift. Square
        /// labor-reporting UIs might group shifts together by id. This cannot be used to retrieve the job.
        /// </summary>
        [JsonProperty("job_id", NullValueHandling = NullValueHandling.Ignore)]
        public string JobId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ShiftWage : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTitle()
        {
            return this.shouldSerialize["title"];
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
            return obj is ShiftWage other &&                ((this.Title == null && other.Title == null) || (this.Title?.Equals(other.Title) == true)) &&
                ((this.HourlyRate == null && other.HourlyRate == null) || (this.HourlyRate?.Equals(other.HourlyRate) == true)) &&
                ((this.JobId == null && other.JobId == null) || (this.JobId?.Equals(other.JobId) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 6779659;
            hashCode = HashCode.Combine(this.Title, this.HourlyRate, this.JobId);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Title = {(this.Title == null ? "null" : this.Title == string.Empty ? "" : this.Title)}");
            toStringOutput.Add($"this.HourlyRate = {(this.HourlyRate == null ? "null" : this.HourlyRate.ToString())}");
            toStringOutput.Add($"this.JobId = {(this.JobId == null ? "null" : this.JobId == string.Empty ? "" : this.JobId)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Title(this.Title)
                .HourlyRate(this.HourlyRate)
                .JobId(this.JobId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "title", false },
            };

            private string title;
            private Models.Money hourlyRate;
            private string jobId;

             /// <summary>
             /// Title.
             /// </summary>
             /// <param name="title"> title. </param>
             /// <returns> Builder. </returns>
            public Builder Title(string title)
            {
                shouldSerialize["title"] = true;
                this.title = title;
                return this;
            }

             /// <summary>
             /// HourlyRate.
             /// </summary>
             /// <param name="hourlyRate"> hourlyRate. </param>
             /// <returns> Builder. </returns>
            public Builder HourlyRate(Models.Money hourlyRate)
            {
                this.hourlyRate = hourlyRate;
                return this;
            }

             /// <summary>
             /// JobId.
             /// </summary>
             /// <param name="jobId"> jobId. </param>
             /// <returns> Builder. </returns>
            public Builder JobId(string jobId)
            {
                this.jobId = jobId;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetTitle()
            {
                this.shouldSerialize["title"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ShiftWage. </returns>
            public ShiftWage Build()
            {
                return new ShiftWage(shouldSerialize,
                    this.title,
                    this.hourlyRate,
                    this.jobId);
            }
        }
    }
}