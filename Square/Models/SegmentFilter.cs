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
    /// SegmentFilter.
    /// </summary>
    public class SegmentFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SegmentFilter"/> class.
        /// </summary>
        /// <param name="serviceVariationId">service_variation_id.</param>
        /// <param name="teamMemberIdFilter">team_member_id_filter.</param>
        public SegmentFilter(
            string serviceVariationId,
            Models.FilterValue teamMemberIdFilter = null)
        {
            this.ServiceVariationId = serviceVariationId;
            this.TeamMemberIdFilter = teamMemberIdFilter;
        }

        /// <summary>
        /// The ID of the [CatalogItemVariation](entity:CatalogItemVariation) object representing the service booked in this segment.
        /// </summary>
        [JsonProperty("service_variation_id")]
        public string ServiceVariationId { get; }

        /// <summary>
        /// A filter to select resources based on an exact field value. For any given
        /// value, the value can only be in one property. Depending on the field, either
        /// all properties can be set or only a subset will be available.
        /// Refer to the documentation of the field.
        /// </summary>
        [JsonProperty("team_member_id_filter", NullValueHandling = NullValueHandling.Ignore)]
        public Models.FilterValue TeamMemberIdFilter { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SegmentFilter : ({string.Join(", ", toStringOutput)})";
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
            return obj is SegmentFilter other &&                ((this.ServiceVariationId == null && other.ServiceVariationId == null) || (this.ServiceVariationId?.Equals(other.ServiceVariationId) == true)) &&
                ((this.TeamMemberIdFilter == null && other.TeamMemberIdFilter == null) || (this.TeamMemberIdFilter?.Equals(other.TeamMemberIdFilter) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -2080323319;
            hashCode = HashCode.Combine(this.ServiceVariationId, this.TeamMemberIdFilter);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ServiceVariationId = {(this.ServiceVariationId == null ? "null" : this.ServiceVariationId)}");
            toStringOutput.Add($"this.TeamMemberIdFilter = {(this.TeamMemberIdFilter == null ? "null" : this.TeamMemberIdFilter.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.ServiceVariationId)
                .TeamMemberIdFilter(this.TeamMemberIdFilter);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string serviceVariationId;
            private Models.FilterValue teamMemberIdFilter;

            /// <summary>
            /// Initialize Builder for SegmentFilter.
            /// </summary>
            /// <param name="serviceVariationId"> serviceVariationId. </param>
            public Builder(
                string serviceVariationId)
            {
                this.serviceVariationId = serviceVariationId;
            }

             /// <summary>
             /// ServiceVariationId.
             /// </summary>
             /// <param name="serviceVariationId"> serviceVariationId. </param>
             /// <returns> Builder. </returns>
            public Builder ServiceVariationId(string serviceVariationId)
            {
                this.serviceVariationId = serviceVariationId;
                return this;
            }

             /// <summary>
             /// TeamMemberIdFilter.
             /// </summary>
             /// <param name="teamMemberIdFilter"> teamMemberIdFilter. </param>
             /// <returns> Builder. </returns>
            public Builder TeamMemberIdFilter(Models.FilterValue teamMemberIdFilter)
            {
                this.teamMemberIdFilter = teamMemberIdFilter;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> SegmentFilter. </returns>
            public SegmentFilter Build()
            {
                return new SegmentFilter(
                    this.serviceVariationId,
                    this.teamMemberIdFilter);
            }
        }
    }
}