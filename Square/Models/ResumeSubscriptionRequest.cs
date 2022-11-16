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
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="ResumeSubscriptionRequest"/> class.
        /// </summary>
        /// <param name="resumeEffectiveDate">resume_effective_date.</param>
        /// <param name="resumeChangeTiming">resume_change_timing.</param>
        public ResumeSubscriptionRequest(
            string resumeEffectiveDate = null,
            string resumeChangeTiming = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "resume_effective_date", false }
            };

            if (resumeEffectiveDate != null)
            {
                shouldSerialize["resume_effective_date"] = true;
                this.ResumeEffectiveDate = resumeEffectiveDate;
            }

            this.ResumeChangeTiming = resumeChangeTiming;
        }
        internal ResumeSubscriptionRequest(Dictionary<string, bool> shouldSerialize,
            string resumeEffectiveDate = null,
            string resumeChangeTiming = null)
        {
            this.shouldSerialize = shouldSerialize;
            ResumeEffectiveDate = resumeEffectiveDate;
            ResumeChangeTiming = resumeChangeTiming;
        }

        /// <summary>
        /// The `YYYY-MM-DD`-formatted date when the subscription reactivated.
        /// </summary>
        [JsonProperty("resume_effective_date")]
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

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeResumeEffectiveDate()
        {
            return this.shouldSerialize["resume_effective_date"];
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
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "resume_effective_date", false },
            };

            private string resumeEffectiveDate;
            private string resumeChangeTiming;

             /// <summary>
             /// ResumeEffectiveDate.
             /// </summary>
             /// <param name="resumeEffectiveDate"> resumeEffectiveDate. </param>
             /// <returns> Builder. </returns>
            public Builder ResumeEffectiveDate(string resumeEffectiveDate)
            {
                shouldSerialize["resume_effective_date"] = true;
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
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetResumeEffectiveDate()
            {
                this.shouldSerialize["resume_effective_date"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ResumeSubscriptionRequest. </returns>
            public ResumeSubscriptionRequest Build()
            {
                return new ResumeSubscriptionRequest(shouldSerialize,
                    this.resumeEffectiveDate,
                    this.resumeChangeTiming);
            }
        }
    }
}