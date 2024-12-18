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

namespace Square.Models
{
    /// <summary>
    /// SearchTeamMembersFilter.
    /// </summary>
    public class SearchTeamMembersFilter
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchTeamMembersFilter"/> class.
        /// </summary>
        /// <param name="locationIds">location_ids.</param>
        /// <param name="status">status.</param>
        /// <param name="isOwner">is_owner.</param>
        public SearchTeamMembersFilter(
            IList<string> locationIds = null,
            string status = null,
            bool? isOwner = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "location_ids", false },
                { "is_owner", false }
            };

            if (locationIds != null)
            {
                shouldSerialize["location_ids"] = true;
                this.LocationIds = locationIds;
            }
            this.Status = status;

            if (isOwner != null)
            {
                shouldSerialize["is_owner"] = true;
                this.IsOwner = isOwner;
            }
        }

        internal SearchTeamMembersFilter(
            Dictionary<string, bool> shouldSerialize,
            IList<string> locationIds = null,
            string status = null,
            bool? isOwner = null)
        {
            this.shouldSerialize = shouldSerialize;
            LocationIds = locationIds;
            Status = status;
            IsOwner = isOwner;
        }

        /// <summary>
        /// When present, filters by team members assigned to the specified locations.
        /// When empty, includes team members assigned to any location.
        /// </summary>
        [JsonProperty("location_ids")]
        public IList<string> LocationIds { get; }

        /// <summary>
        /// Enumerates the possible statuses the team member can have within a business.
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; }

        /// <summary>
        /// When present and set to true, returns the team member who is the owner of the Square account.
        /// </summary>
        [JsonProperty("is_owner")]
        public bool? IsOwner { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"SearchTeamMembersFilter : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLocationIds()
        {
            return this.shouldSerialize["location_ids"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeIsOwner()
        {
            return this.shouldSerialize["is_owner"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is SearchTeamMembersFilter other &&
                (this.LocationIds == null && other.LocationIds == null ||
                 this.LocationIds?.Equals(other.LocationIds) == true) &&
                (this.Status == null && other.Status == null ||
                 this.Status?.Equals(other.Status) == true) &&
                (this.IsOwner == null && other.IsOwner == null ||
                 this.IsOwner?.Equals(other.IsOwner) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 1386663614;
            hashCode = HashCode.Combine(hashCode, this.LocationIds, this.Status, this.IsOwner);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.LocationIds = {(this.LocationIds == null ? "null" : $"[{string.Join(", ", this.LocationIds)} ]")}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status.ToString())}");
            toStringOutput.Add($"this.IsOwner = {(this.IsOwner == null ? "null" : this.IsOwner.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .LocationIds(this.LocationIds)
                .Status(this.Status)
                .IsOwner(this.IsOwner);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "location_ids", false },
                { "is_owner", false },
            };

            private IList<string> locationIds;
            private string status;
            private bool? isOwner;

             /// <summary>
             /// LocationIds.
             /// </summary>
             /// <param name="locationIds"> locationIds. </param>
             /// <returns> Builder. </returns>
            public Builder LocationIds(IList<string> locationIds)
            {
                shouldSerialize["location_ids"] = true;
                this.locationIds = locationIds;
                return this;
            }

             /// <summary>
             /// Status.
             /// </summary>
             /// <param name="status"> status. </param>
             /// <returns> Builder. </returns>
            public Builder Status(string status)
            {
                this.status = status;
                return this;
            }

             /// <summary>
             /// IsOwner.
             /// </summary>
             /// <param name="isOwner"> isOwner. </param>
             /// <returns> Builder. </returns>
            public Builder IsOwner(bool? isOwner)
            {
                shouldSerialize["is_owner"] = true;
                this.isOwner = isOwner;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetLocationIds()
            {
                this.shouldSerialize["location_ids"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetIsOwner()
            {
                this.shouldSerialize["is_owner"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> SearchTeamMembersFilter. </returns>
            public SearchTeamMembersFilter Build()
            {
                return new SearchTeamMembersFilter(
                    shouldSerialize,
                    this.locationIds,
                    this.status,
                    this.isOwner);
            }
        }
    }
}