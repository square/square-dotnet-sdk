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
    /// ResumeSubscriptionRequest.
    /// </summary>
    public class ResumeSubscriptionRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResumeSubscriptionRequest"/> class.
        /// </summary>
        /// <param name="resumeEffectiveDate">resume_effective_date.</param>
        /// <param name="resumeChangeTiming">resume_change_timing.</param>
        public ResumeSubscriptionRequest(
            string resumeEffectiveDate = null,
            string resumeChangeTiming = null)
        {
            this.ResumeEffectiveDate = resumeEffectiveDate;
            this.ResumeChangeTiming = resumeChangeTiming;
        }

        /// <summary>
        /// The `YYYY-MM-DD`-formatted date when the subscription reactivated.
        /// </summary>
        [JsonProperty("resume_effective_date", NullValueHandling = NullValueHandling.Ignore)]
        public string ResumeEffectiveDate { get; }

        /// <summary>
        /// Supported timings when a pending change, as an action, takes place to a subscription.
        /// </summary>
        [JsonProperty("resume_change_timing", NullValueHandling = NullValueHandling.Ignore)]
        public string ResumeChangeTiming { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ResumeSubscriptionRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is ResumeSubscriptionRequest other &&
                ((this.ResumeEffectiveDate == null && other.ResumeEffectiveDate == null) || (this.ResumeEffectiveDate?.Equals(other.ResumeEffectiveDate) == true)) &&
                ((this.ResumeChangeTiming == null && other.ResumeChangeTiming == null) || (this.ResumeChangeTiming?.Equals(other.ResumeChangeTiming) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1612746632;
            hashCode = HashCode.Combine(this.ResumeEffectiveDate, this.ResumeChangeTiming);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ResumeEffectiveDate = {(this.ResumeEffectiveDate == null ? "null" : this.ResumeEffectiveDate == string.Empty ? "" : this.ResumeEffectiveDate)}");
            toStringOutput.Add($"this.ResumeChangeTiming = {(this.ResumeChangeTiming == null ? "null" : this.ResumeChangeTiming.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .ResumeEffectiveDate(this.ResumeEffectiveDate)
                .ResumeChangeTiming(this.ResumeChangeTiming);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string resumeEffectiveDate;
            private string resumeChangeTiming;

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
            /// Builds class object.
            /// </summary>
            /// <returns> ResumeSubscriptionRequest. </returns>
            public ResumeSubscriptionRequest Build()
            {
                return new ResumeSubscriptionRequest(
                    this.resumeEffectiveDate,
                    this.resumeChangeTiming);
            }
        }
    }
}