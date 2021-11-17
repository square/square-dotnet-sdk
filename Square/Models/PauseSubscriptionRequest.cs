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
    /// PauseSubscriptionRequest.
    /// </summary>
    public class PauseSubscriptionRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PauseSubscriptionRequest"/> class.
        /// </summary>
        /// <param name="pauseEffectiveDate">pause_effective_date.</param>
        /// <param name="pauseCycleDuration">pause_cycle_duration.</param>
        /// <param name="resumeEffectiveDate">resume_effective_date.</param>
        /// <param name="resumeChangeTiming">resume_change_timing.</param>
        /// <param name="pauseReason">pause_reason.</param>
        public PauseSubscriptionRequest(
            string pauseEffectiveDate = null,
            long? pauseCycleDuration = null,
            string resumeEffectiveDate = null,
            string resumeChangeTiming = null,
            string pauseReason = null)
        {
            this.PauseEffectiveDate = pauseEffectiveDate;
            this.PauseCycleDuration = pauseCycleDuration;
            this.ResumeEffectiveDate = resumeEffectiveDate;
            this.ResumeChangeTiming = resumeChangeTiming;
            this.PauseReason = pauseReason;
        }

        /// <summary>
        /// The `YYYY-MM-DD`-formatted date when the scheduled `PAUSE` action takes place on the subscription.
        /// When this date is unspecified or falls within the current billing cycle, the subscription is paused
        /// on the starting date of the next billing cycle.
        /// </summary>
        [JsonProperty("pause_effective_date", NullValueHandling = NullValueHandling.Ignore)]
        public string PauseEffectiveDate { get; }

        /// <summary>
        /// The number of billing cycles the subscription will be paused before it is reactivated.
        /// When this is set, a `RESUME` action is also scheduled to take place on the subscription at
        /// the end of the specified pause cycle duration. In this case, neither `resume_effective_date`
        /// nor `resume_change_timing` may be specified.
        /// </summary>
        [JsonProperty("pause_cycle_duration", NullValueHandling = NullValueHandling.Ignore)]
        public long? PauseCycleDuration { get; }

        /// <summary>
        /// The date when the subscription is reactivated by a scheduled `RESUME` action.
        /// This date must be at least one billing cycle ahead of `pause_effective_date`.
        /// </summary>
        [JsonProperty("resume_effective_date", NullValueHandling = NullValueHandling.Ignore)]
        public string ResumeEffectiveDate { get; }

        /// <summary>
        /// Supported timings when a pending change, as an action, takes place to a subscription.
        /// </summary>
        [JsonProperty("resume_change_timing", NullValueHandling = NullValueHandling.Ignore)]
        public string ResumeChangeTiming { get; }

        /// <summary>
        /// The user-provided reason to pause the subscription.
        /// </summary>
        [JsonProperty("pause_reason", NullValueHandling = NullValueHandling.Ignore)]
        public string PauseReason { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"PauseSubscriptionRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is PauseSubscriptionRequest other &&
                ((this.PauseEffectiveDate == null && other.PauseEffectiveDate == null) || (this.PauseEffectiveDate?.Equals(other.PauseEffectiveDate) == true)) &&
                ((this.PauseCycleDuration == null && other.PauseCycleDuration == null) || (this.PauseCycleDuration?.Equals(other.PauseCycleDuration) == true)) &&
                ((this.ResumeEffectiveDate == null && other.ResumeEffectiveDate == null) || (this.ResumeEffectiveDate?.Equals(other.ResumeEffectiveDate) == true)) &&
                ((this.ResumeChangeTiming == null && other.ResumeChangeTiming == null) || (this.ResumeChangeTiming?.Equals(other.ResumeChangeTiming) == true)) &&
                ((this.PauseReason == null && other.PauseReason == null) || (this.PauseReason?.Equals(other.PauseReason) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1939468888;
            hashCode = HashCode.Combine(this.PauseEffectiveDate, this.PauseCycleDuration, this.ResumeEffectiveDate, this.ResumeChangeTiming, this.PauseReason);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.PauseEffectiveDate = {(this.PauseEffectiveDate == null ? "null" : this.PauseEffectiveDate == string.Empty ? "" : this.PauseEffectiveDate)}");
            toStringOutput.Add($"this.PauseCycleDuration = {(this.PauseCycleDuration == null ? "null" : this.PauseCycleDuration.ToString())}");
            toStringOutput.Add($"this.ResumeEffectiveDate = {(this.ResumeEffectiveDate == null ? "null" : this.ResumeEffectiveDate == string.Empty ? "" : this.ResumeEffectiveDate)}");
            toStringOutput.Add($"this.ResumeChangeTiming = {(this.ResumeChangeTiming == null ? "null" : this.ResumeChangeTiming.ToString())}");
            toStringOutput.Add($"this.PauseReason = {(this.PauseReason == null ? "null" : this.PauseReason == string.Empty ? "" : this.PauseReason)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .PauseEffectiveDate(this.PauseEffectiveDate)
                .PauseCycleDuration(this.PauseCycleDuration)
                .ResumeEffectiveDate(this.ResumeEffectiveDate)
                .ResumeChangeTiming(this.ResumeChangeTiming)
                .PauseReason(this.PauseReason);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string pauseEffectiveDate;
            private long? pauseCycleDuration;
            private string resumeEffectiveDate;
            private string resumeChangeTiming;
            private string pauseReason;

             /// <summary>
             /// PauseEffectiveDate.
             /// </summary>
             /// <param name="pauseEffectiveDate"> pauseEffectiveDate. </param>
             /// <returns> Builder. </returns>
            public Builder PauseEffectiveDate(string pauseEffectiveDate)
            {
                this.pauseEffectiveDate = pauseEffectiveDate;
                return this;
            }

             /// <summary>
             /// PauseCycleDuration.
             /// </summary>
             /// <param name="pauseCycleDuration"> pauseCycleDuration. </param>
             /// <returns> Builder. </returns>
            public Builder PauseCycleDuration(long? pauseCycleDuration)
            {
                this.pauseCycleDuration = pauseCycleDuration;
                return this;
            }

             /// <summary>
             /// ResumeEffectiveDate.
             /// </summary>
             /// <param name="resumeEffectiveDate"> resumeEffectiveDate. </param>
             /// <returns> Builder. </returns>
            public Builder ResumeEffectiveDate(string resumeEffectiveDate)
            {
                this.resumeEffectiveDate = resumeEffectiveDate;
                return this;
            }

             /// <summary>
             /// ResumeChangeTiming.
             /// </summary>
             /// <param name="resumeChangeTiming"> resumeChangeTiming. </param>
             /// <returns> Builder. </returns>
            public Builder ResumeChangeTiming(string resumeChangeTiming)
            {
                this.resumeChangeTiming = resumeChangeTiming;
                return this;
            }

             /// <summary>
             /// PauseReason.
             /// </summary>
             /// <param name="pauseReason"> pauseReason. </param>
             /// <returns> Builder. </returns>
            public Builder PauseReason(string pauseReason)
            {
                this.pauseReason = pauseReason;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> PauseSubscriptionRequest. </returns>
            public PauseSubscriptionRequest Build()
            {
                return new PauseSubscriptionRequest(
                    this.pauseEffectiveDate,
                    this.pauseCycleDuration,
                    this.resumeEffectiveDate,
                    this.resumeChangeTiming,
                    this.pauseReason);
            }
        }
    }
}