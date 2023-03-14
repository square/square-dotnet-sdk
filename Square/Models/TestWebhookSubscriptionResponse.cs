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
    using Square.Http.Client;
    using Square.Utilities;

    /// <summary>
    /// TestWebhookSubscriptionResponse.
    /// </summary>
    public class TestWebhookSubscriptionResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestWebhookSubscriptionResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="subscriptionTestResult">subscription_test_result.</param>
        public TestWebhookSubscriptionResponse(
            IList<Models.Error> errors = null,
            Models.SubscriptionTestResult subscriptionTestResult = null)
        {
            this.Errors = errors;
            this.SubscriptionTestResult = subscriptionTestResult;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Information on errors encountered during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Represents the details of a webhook subscription, including notification URL,
        /// event types, and signature key.
        /// </summary>
        [JsonProperty("subscription_test_result", NullValueHandling = NullValueHandling.Ignore)]
        public Models.SubscriptionTestResult SubscriptionTestResult { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"TestWebhookSubscriptionResponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is TestWebhookSubscriptionResponse other &&
                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true)) &&
                ((this.SubscriptionTestResult == null && other.SubscriptionTestResult == null) || (this.SubscriptionTestResult?.Equals(other.SubscriptionTestResult) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1884845889;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.Errors, this.SubscriptionTestResult);

            return hashCode;
        }
        internal TestWebhookSubscriptionResponse ContextSetter(HttpContext context)
        {
            this.Context = context;
            return this;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
            toStringOutput.Add($"this.SubscriptionTestResult = {(this.SubscriptionTestResult == null ? "null" : this.SubscriptionTestResult.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .SubscriptionTestResult(this.SubscriptionTestResult);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private Models.SubscriptionTestResult subscriptionTestResult;

             /// <summary>
             /// Errors.
             /// </summary>
             /// <param name="errors"> errors. </param>
             /// <returns> Builder. </returns>
            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

             /// <summary>
             /// SubscriptionTestResult.
             /// </summary>
             /// <param name="subscriptionTestResult"> subscriptionTestResult. </param>
             /// <returns> Builder. </returns>
            public Builder SubscriptionTestResult(Models.SubscriptionTestResult subscriptionTestResult)
            {
                this.subscriptionTestResult = subscriptionTestResult;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> TestWebhookSubscriptionResponse. </returns>
            public TestWebhookSubscriptionResponse Build()
            {
                return new TestWebhookSubscriptionResponse(
                    this.errors,
                    this.subscriptionTestResult);
            }
        }
    }
}