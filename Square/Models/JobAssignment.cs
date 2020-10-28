using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class JobAssignment 
    {
        public JobAssignment(string jobTitle,
            string payType,
            Models.Money hourlyRate = null,
            Models.Money annualRate = null,
            int? weeklyHours = null)
        {
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
        [JsonProperty("weekly_hours", NullValueHandling = NullValueHandling.Ignore)]
        public int? WeeklyHours { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(JobTitle,
                PayType)
                .HourlyRate(HourlyRate)
                .AnnualRate(AnnualRate)
                .WeeklyHours(WeeklyHours);
            return builder;
        }

        public class Builder
        {
            private string jobTitle;
            private string payType;
            private Models.Money hourlyRate;
            private Models.Money annualRate;
            private int? weeklyHours;

            public Builder(string jobTitle,
                string payType)
            {
                this.jobTitle = jobTitle;
                this.payType = payType;
            }

            public Builder JobTitle(string jobTitle)
            {
                this.jobTitle = jobTitle;
                return this;
            }

            public Builder PayType(string payType)
            {
                this.payType = payType;
                return this;
            }

            public Builder HourlyRate(Models.Money hourlyRate)
            {
                this.hourlyRate = hourlyRate;
                return this;
            }

            public Builder AnnualRate(Models.Money annualRate)
            {
                this.annualRate = annualRate;
                return this;
            }

            public Builder WeeklyHours(int? weeklyHours)
            {
                this.weeklyHours = weeklyHours;
                return this;
            }

            public JobAssignment Build()
            {
                return new JobAssignment(jobTitle,
                    payType,
                    hourlyRate,
                    annualRate,
                    weeklyHours);
            }
        }
    }
}