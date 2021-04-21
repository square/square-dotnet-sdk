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
    /// SearchTeamMembersQuery.
    /// </summary>
    public class SearchTeamMembersQuery
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchTeamMembersQuery"/> class.
        /// </summary>
        /// <param name="filter">filter.</param>
        public SearchTeamMembersQuery(
            Models.SearchTeamMembersFilter filter = null)
        {
            this.Filter = filter;
        }

        /// <summary>
        /// Represents a filter used in a search for `TeamMember` objects. `AND` logic is applied
        /// between the individual fields, and `OR` logic is applied within list-based fields.
        /// For example, setting this filter value,
        /// ```
        /// filter = (locations_ids = ["A", "B"], status = ACTIVE)
        /// ```
        /// returns only active team members assigned to either location "A" or "B".
        /// </summary>
        [JsonProperty("filter", NullValueHandling = NullValueHandling.Ignore)]
        public Models.SearchTeamMembersFilter Filter { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SearchTeamMembersQuery : ({string.Join(", ", toStringOutput)})";
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

            return obj is SearchTeamMembersQuery other &&
                ((this.Filter == null && other.Filter == null) || (this.Filter?.Equals(other.Filter) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1472876926;

            if (this.Filter != null)
            {
               hashCode += this.Filter.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Filter = {(this.Filter == null ? "null" : this.Filter.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Filter(this.Filter);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.SearchTeamMembersFilter filter;

             /// <summary>
             /// Filter.
             /// </summary>
             /// <param name="filter"> filter. </param>
             /// <returns> Builder. </returns>
            public Builder Filter(Models.SearchTeamMembersFilter filter)
            {
                this.filter = filter;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> SearchTeamMembersQuery. </returns>
            public SearchTeamMembersQuery Build()
            {
                return new SearchTeamMembersQuery(
                    this.filter);
            }
        }
    }
}