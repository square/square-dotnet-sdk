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
    /// JobAssignment.
    /// </summary>
    public class JobAssignment
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="JobAssignment"/> class.
        /// </summary>
        /// <param name="payType">pay_type.</param>
        /// <param name="jobTitle">job_title.</param>
        /// <param name="hourlyRate">hourly_rate.</param>
        /// <param name="annualRate">annual_rate.</param>
        /// <param name="weeklyHours">weekly_hours.</param>
        /// <param name="jobId">job_id.</param>
        public JobAssignment(
            string payType,
            string jobTitle = null,
            Models.Money hourlyRate = null,
            Models.Money annualRate = null,
            int? weeklyHours = null,
            string jobId = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "job_title", false },
                { "weekly_hours", false },
                { "job_id", false }
            };

            if (jobTitle != null)
            {
                shouldSerialize["job_title"] = true;
                this.JobTitle = jobTitle;
            }
            this.PayType = payType;
            this.HourlyRate = hourlyRate;
            this.AnnualRate = annualRate;

            if (weeklyHours != null)
            {
                shouldSerialize["weekly_hours"] = true;
                this.WeeklyHours = weeklyHours;
            }

            if (jobId != null)
            {
                shouldSerialize["job_id"] = true;
                this.JobId = jobId;
            }
        }

        internal JobAssignment(
            Dictionary<string, bool> shouldSerialize,
            string payType,
            string jobTitle = null,
            Models.Money hourlyRate = null,
            Models.Money annualRate = null,
            int? weeklyHours = null,
            string jobId = null)
        {
            this.shouldSerialize = shouldSerialize;
            JobTitle = jobTitle;
            PayType = payType;
            HourlyRate = hourlyRate;
            AnnualRate = annualRate;
            WeeklyHours = weeklyHours;
            JobId = jobId;
        }

        /// <summary>
        /// The title of the job.
        /// </summary>
        [JsonProperty("job_title")]
        public string JobTitle { get; }

        /// <summary>
        /// Enumerates the possible pay types that a job can be assigned.
        /// </summary>
        [JsonProperty("pay_type")]
        public string PayType { get; }

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
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("annual_rate", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money AnnualRate { get; }

        /// <summary>
        /// The planned hours per week for the job. Set if the job `PayType` is `SALARY`.
        /// </summary>
        [JsonProperty("weekly_hours")]
        public int? WeeklyHours { get; }

        /// <summary>
        /// The ID of the [job]($m/Job).
        /// </summary>
        [JsonProperty("job_id")]
        public string JobId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"JobAssignment : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeJobTitle()
        {
            return this.shouldSerialize["job_title"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeWeeklyHours()
        {
            return this.shouldSerialize["weekly_hours"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeJobId()
        {
            return this.shouldSerialize["job_id"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is JobAssignment other &&
                (this.JobTitle == null && other.JobTitle == null ||
                 this.JobTitle?.Equals(other.JobTitle) == true) &&
                (this.PayType == null && other.PayType == null ||
                 this.PayType?.Equals(other.PayType) == true) &&
                (this.HourlyRate == null && other.HourlyRate == null ||
                 this.HourlyRate?.Equals(other.HourlyRate) == true) &&
                (this.AnnualRate == null && other.AnnualRate == null ||
                 this.AnnualRate?.Equals(other.AnnualRate) == true) &&
                (this.WeeklyHours == null && other.WeeklyHours == null ||
                 this.WeeklyHours?.Equals(other.WeeklyHours) == true) &&
                (this.JobId == null && other.JobId == null ||
                 this.JobId?.Equals(other.JobId) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1238704248;
            hashCode = HashCode.Combine(hashCode, this.JobTitle, this.PayType, this.HourlyRate, this.AnnualRate, this.WeeklyHours, this.JobId);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.JobTitle = {this.JobTitle ?? "null"}");
            toStringOutput.Add($"this.PayType = {(this.PayType == null ? "null" : this.PayType.ToString())}");
            toStringOutput.Add($"this.HourlyRate = {(this.HourlyRate == null ? "null" : this.HourlyRate.ToString())}");
            toStringOutput.Add($"this.AnnualRate = {(this.AnnualRate == null ? "null" : this.AnnualRate.ToString())}");
            toStringOutput.Add($"this.WeeklyHours = {(this.WeeklyHours == null ? "null" : this.WeeklyHours.ToString())}");
            toStringOutput.Add($"this.JobId = {this.JobId ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.PayType)
                .JobTitle(this.JobTitle)
                .HourlyRate(this.HourlyRate)
                .AnnualRate(this.AnnualRate)
                .WeeklyHours(this.WeeklyHours)
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
                { "job_title", false },
                { "weekly_hours", false },
                { "job_id", false },
            };

            private string payType;
            private string jobTitle;
            private Models.Money hourlyRate;
            private Models.Money annualRate;
            private int? weeklyHours;
            private string jobId;

            /// <summary>
            /// Initialize Builder for JobAssignment.
            /// </summary>
            /// <param name="payType"> payType. </param>
            public Builder(
                string payType)
            {
                this.payType = payType;
            }

             /// <summary>
             /// PayType.
             /// </summary>
             /// <param name="payType"> payType. </param>
             /// <returns> Builder. </returns>
            public Builder PayType(string payType)
            {
                this.payType = payType;
                return this;
            }

             /// <summary>
             /// JobTitle.
             /// </summary>
             /// <param name="jobTitle"> jobTitle. </param>
             /// <returns> Builder. </returns>
            public Builder JobTitle(string jobTitle)
            {
                shouldSerialize["job_title"] = true;
                this.jobTitle = jobTitle;
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
             /// AnnualRate.
             /// </summary>
             /// <param name="annualRate"> annualRate. </param>
             /// <returns> Builder. </returns>
            public Builder AnnualRate(Models.Money annualRate)
            {
                this.annualRate = annualRate;
                return this;
            }

             /// <summary>
             /// WeeklyHours.
             /// </summary>
             /// <param name="weeklyHours"> weeklyHours. </param>
             /// <returns> Builder. </returns>
            public Builder WeeklyHours(int? weeklyHours)
            {
                shouldSerialize["weekly_hours"] = true;
                this.weeklyHours = weeklyHours;
                return this;
            }

             /// <summary>
             /// JobId.
             /// </summary>
             /// <param name="jobId"> jobId. </param>
             /// <returns> Builder. </returns>
            public Builder JobId(string jobId)
            {
                shouldSerialize["job_id"] = true;
                this.jobId = jobId;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetJobTitle()
            {
                this.shouldSerialize["job_title"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetWeeklyHours()
            {
                this.shouldSerialize["weekly_hours"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetJobId()
            {
                this.shouldSerialize["job_id"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> JobAssignment. </returns>
            public JobAssignment Build()
            {
                return new JobAssignment(
                    shouldSerialize,
                    this.payType,
                    this.jobTitle,
                    this.hourlyRate,
                    this.annualRate,
                    this.weeklyHours,
                    this.jobId);
            }
        }
    }
}