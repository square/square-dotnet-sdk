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
    /// BulkSwapPlanRequest.
    /// </summary>
    public class BulkSwapPlanRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BulkSwapPlanRequest"/> class.
        /// </summary>
        /// <param name="newPlanVariationId">new_plan_variation_id.</param>
        /// <param name="oldPlanVariationId">old_plan_variation_id.</param>
        /// <param name="locationId">location_id.</param>
        public BulkSwapPlanRequest(
            string newPlanVariationId,
            string oldPlanVariationId,
            string locationId)
        {
            this.NewPlanVariationId = newPlanVariationId;
            this.OldPlanVariationId = oldPlanVariationId;
            this.LocationId = locationId;
        }

        /// <summary>
        /// The ID of the new subscription plan variation.
        /// This field is required.
        /// </summary>
        [JsonProperty("new_plan_variation_id")]
        public string NewPlanVariationId { get; }

        /// <summary>
        /// The ID of the plan variation whose subscriptions should be swapped. Active subscriptions
        /// using this plan variation will be subscribed to the new plan variation on their next billing
        /// day.
        /// </summary>
        [JsonProperty("old_plan_variation_id")]
        public string OldPlanVariationId { get; }

        /// <summary>
        /// The ID of the location to associate with the swapped subscriptions.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BulkSwapPlanRequest : ({string.Join(", ", toStringOutput)})";
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
            return obj is BulkSwapPlanRequest other &&                ((this.NewPlanVariationId == null && other.NewPlanVariationId == null) || (this.NewPlanVariationId?.Equals(other.NewPlanVariationId) == true)) &&
                ((this.OldPlanVariationId == null && other.OldPlanVariationId == null) || (this.OldPlanVariationId?.Equals(other.OldPlanVariationId) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1040152150;
            hashCode = HashCode.Combine(this.NewPlanVariationId, this.OldPlanVariationId, this.LocationId);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.NewPlanVariationId = {(this.NewPlanVariationId == null ? "null" : this.NewPlanVariationId)}");
            toStringOutput.Add($"this.OldPlanVariationId = {(this.OldPlanVariationId == null ? "null" : this.OldPlanVariationId)}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.NewPlanVariationId,
                this.OldPlanVariationId,
                this.LocationId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string newPlanVariationId;
            private string oldPlanVariationId;
            private string locationId;

            /// <summary>
            /// Initialize Builder for BulkSwapPlanRequest.
            /// </summary>
            /// <param name="newPlanVariationId"> newPlanVariationId. </param>
            /// <param name="oldPlanVariationId"> oldPlanVariationId. </param>
            /// <param name="locationId"> locationId. </param>
            public Builder(
                string newPlanVariationId,
                string oldPlanVariationId,
                string locationId)
            {
                this.newPlanVariationId = newPlanVariationId;
                this.oldPlanVariationId = oldPlanVariationId;
                this.locationId = locationId;
            }

             /// <summary>
             /// NewPlanVariationId.
             /// </summary>
             /// <param name="newPlanVariationId"> newPlanVariationId. </param>
             /// <returns> Builder. </returns>
            public Builder NewPlanVariationId(string newPlanVariationId)
            {
                this.newPlanVariationId = newPlanVariationId;
                return this;
            }

             /// <summary>
             /// OldPlanVariationId.
             /// </summary>
             /// <param name="oldPlanVariationId"> oldPlanVariationId. </param>
             /// <returns> Builder. </returns>
            public Builder OldPlanVariationId(string oldPlanVariationId)
            {
                this.oldPlanVariationId = oldPlanVariationId;
                return this;
            }

             /// <summary>
             /// LocationId.
             /// </summary>
             /// <param name="locationId"> locationId. </param>
             /// <returns> Builder. </returns>
            public Builder LocationId(string locationId)
            {
                this.locationId = locationId;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> BulkSwapPlanRequest. </returns>
            public BulkSwapPlanRequest Build()
            {
                return new BulkSwapPlanRequest(
                    this.newPlanVariationId,
                    this.oldPlanVariationId,
                    this.locationId);
            }
        }
    }
}