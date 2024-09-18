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
        /// <param name="jobTitle">job_title.</param>
        /// <param name="payType">pay_type.</param>
        /// <param name="hourlyRate">hourly_rate.</param>
        /// <param name="annualRate">annual_rate.</param>
        /// <param name="weeklyHours">weekly_hours.</param>
        public JobAssignment(
            string jobTitle,
            string payType,
            Models.Money hourlyRate = null,
            Models.Money annualRate = null,
            int? weeklyHours = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "weekly_hours", false }
            };

            this.JobTitle = jobTitle;
            this.PayType = payType;
            this.HourlyRate = hourlyRate;
            this.AnnualRate = annualRate;
            if (weeklyHours != null)
            {
                shouldSerialize["weekly_hours"] = true;
                this.WeeklyHours = weeklyHours;
            }

        }
        internal JobAssignment(Dictionary<string, bool> shouldSerialize,
            string jobTitle,
            string payType,
            Models.Money hourlyRate = null,
            Models.Money annualRate = null,
            int? weeklyHours = null)
        {
            this.shouldSerialize = shouldSerialize;
            JobTitle = jobTitle;
            PayType = payType;
            HourlyRate = hourlyRate;
            AnnualRate = annualRate;
            WeeklyHours = weeklyHours;
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
        public bool ShouldSerializeWeeklyHours()
        {
            return this.shouldSerialize["weekly_hours"];
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
            return obj is JobAssignment other &&                ((this.JobTitle == null && other.JobTitle == null) || (this.JobTitle?.Equals(other.JobTitle) == true)) &&
                ((this.PayType == null && other.PayType == null) || (this.PayType?.Equals(other.PayType) == true)) &&
                ((this.HourlyRate == null && other.HourlyRate == null) || (this.HourlyRate?.Equals(other.HourlyRate) == true)) &&
                ((this.AnnualRate == null && other.AnnualRate == null) || (this.AnnualRate?.Equals(other.AnnualRate) == true)) &&
                ((this.WeeklyHours == null && other.WeeklyHours == null) || (this.WeeklyHours?.Equals(other.WeeklyHours) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 2078452856;
            hashCode = HashCode.Combine(this.JobTitle, this.PayType, this.HourlyRate, this.AnnualRate, this.WeeklyHours);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.JobTitle = {(this.JobTitle == null ? "null" : this.JobTitle)}");
            toStringOutput.Add($"this.PayType = {(this.PayType == null ? "null" : this.PayType.ToString())}");
            toStringOutput.Add($"this.HourlyRate = {(this.HourlyRate == null ? "null" : this.HourlyRate.ToString())}");
            toStringOutput.Add($"this.AnnualRate = {(this.AnnualRate == null ? "null" : this.AnnualRate.ToString())}");
            toStringOutput.Add($"this.WeeklyHours = {(this.WeeklyHours == null ? "null" : this.WeeklyHours.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.JobTitle,
                this.PayType)
                .HourlyRate(this.HourlyRate)
                .AnnualRate(this.AnnualRate)
                .WeeklyHours(this.WeeklyHours);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "weekly_hours", false },
            };

            private string jobTitle;
            private string payType;
            private Models.Money hourlyRate;
            private Models.Money annualRate;
            private int? weeklyHours;

            /// <summary>
            /// Initialize Builder for JobAssignment.
            /// </summary>
            /// <param name="jobTitle"> jobTitle. </param>
            /// <param name="payType"> payType. </param>
            public Builder(
                string jobTitle,
                string payType)
            {
                this.jobTitle = jobTitle;
                this.payType = payType;
            }

             /// <summary>
             /// JobTitle.
             /// </summary>
             /// <param name="jobTitle"> jobTitle. </param>
             /// <returns> Builder. </returns>
            public Builder JobTitle(string jobTitle)
            {
                this.jobTitle = jobTitle;
                return this;
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
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetWeeklyHours()
            {
                this.shouldSerialize["weekly_hours"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> JobAssignment. </returns>
            public JobAssignment Build()
            {
                return new JobAssignment(shouldSerialize,
                    this.jobTitle,
                    this.payType,
                    this.hourlyRate,
                    this.annualRate,
                    this.weeklyHours);
            }
        }
    }
}