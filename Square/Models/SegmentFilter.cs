
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
    public class SegmentFilter 
    {
        public SegmentFilter(string serviceVariationId,
            Models.FilterValue teamMemberIdFilter = null)
        {
            ServiceVariationId = serviceVariationId;
            TeamMemberIdFilter = teamMemberIdFilter;
        }

        /// <summary>
        /// The ID of the [CatalogItemVariation](#type-CatalogItemVariation) representing the service booked in this segment.
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SegmentFilter : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"ServiceVariationId = {(ServiceVariationId == null ? "null" : ServiceVariationId == string.Empty ? "" : ServiceVariationId)}");
            toStringOutput.Add($"TeamMemberIdFilter = {(TeamMemberIdFilter == null ? "null" : TeamMemberIdFilter.ToString())}");
        }

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

            return obj is SegmentFilter other &&
                ((ServiceVariationId == null && other.ServiceVariationId == null) || (ServiceVariationId?.Equals(other.ServiceVariationId) == true)) &&
                ((TeamMemberIdFilter == null && other.TeamMemberIdFilter == null) || (TeamMemberIdFilter?.Equals(other.TeamMemberIdFilter) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -2080323319;

            if (ServiceVariationId != null)
            {
               hashCode += ServiceVariationId.GetHashCode();
            }

            if (TeamMemberIdFilter != null)
            {
               hashCode += TeamMemberIdFilter.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(ServiceVariationId)
                .TeamMemberIdFilter(TeamMemberIdFilter);
            return builder;
        }

        public class Builder
        {
            private string serviceVariationId;
            private Models.FilterValue teamMemberIdFilter;

            public Builder(string serviceVariationId)
            {
                this.serviceVariationId = serviceVariationId;
            }

            public Builder ServiceVariationId(string serviceVariationId)
            {
                this.serviceVariationId = serviceVariationId;
                return this;
            }

            public Builder TeamMemberIdFilter(Models.FilterValue teamMemberIdFilter)
            {
                this.teamMemberIdFilter = teamMemberIdFilter;
                return this;
            }

            public SegmentFilter Build()
            {
                return new SegmentFilter(serviceVariationId,
                    teamMemberIdFilter);
            }
        }
    }
}