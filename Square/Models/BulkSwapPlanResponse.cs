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
    using Square.Http.Client;
    using Square.Utilities;

    /// <summary>
    /// BulkSwapPlanResponse.
    /// </summary>
    public class BulkSwapPlanResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BulkSwapPlanResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="affectedSubscriptions">affected_subscriptions.</param>
        public BulkSwapPlanResponse(
            IList<Models.Error> errors = null,
            int? affectedSubscriptions = null)
        {
            this.Errors = errors;
            this.AffectedSubscriptions = affectedSubscriptions;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Errors encountered during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// The number of affected subscriptions.
        /// </summary>
        [JsonProperty("affected_subscriptions", NullValueHandling = NullValueHandling.Ignore)]
        public int? AffectedSubscriptions { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BulkSwapPlanResponse : ({string.Join(", ", toStringOutput)})";
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
            return obj is BulkSwapPlanResponse other &&                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true)) &&
                ((this.AffectedSubscriptions == null && other.AffectedSubscriptions == null) || (this.AffectedSubscriptions?.Equals(other.AffectedSubscriptions) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1153695832;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.Errors, this.AffectedSubscriptions);

            return hashCode;
        }
        internal BulkSwapPlanResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add($"this.AffectedSubscriptions = {(this.AffectedSubscriptions == null ? "null" : this.AffectedSubscriptions.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .AffectedSubscriptions(this.AffectedSubscriptions);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private int? affectedSubscriptions;

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
             /// AffectedSubscriptions.
             /// </summary>
             /// <param name="affectedSubscriptions"> affectedSubscriptions. </param>
             /// <returns> Builder. </returns>
            public Builder AffectedSubscriptions(int? affectedSubscriptions)
            {
                this.affectedSubscriptions = affectedSubscriptions;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> BulkSwapPlanResponse. </returns>
            public BulkSwapPlanResponse Build()
            {
                return new BulkSwapPlanResponse(
                    this.errors,
                    this.affectedSubscriptions);
            }
        }
    }
}