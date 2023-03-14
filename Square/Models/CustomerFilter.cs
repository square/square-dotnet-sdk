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
    /// CustomerFilter.
    /// </summary>
    public class CustomerFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerFilter"/> class.
        /// </summary>
        /// <param name="creationSource">creation_source.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="updatedAt">updated_at.</param>
        /// <param name="emailAddress">email_address.</param>
        /// <param name="phoneNumber">phone_number.</param>
        /// <param name="referenceId">reference_id.</param>
        /// <param name="groupIds">group_ids.</param>
        /// <param name="customAttribute">custom_attribute.</param>
        /// <param name="segmentIds">segment_ids.</param>
        public CustomerFilter(
            Models.CustomerCreationSourceFilter creationSource = null,
            Models.TimeRange createdAt = null,
            Models.TimeRange updatedAt = null,
            Models.CustomerTextFilter emailAddress = null,
            Models.CustomerTextFilter phoneNumber = null,
            Models.CustomerTextFilter referenceId = null,
            Models.FilterValue groupIds = null,
            Models.CustomerCustomAttributeFilters customAttribute = null,
            Models.FilterValue segmentIds = null)
        {
            this.CreationSource = creationSource;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
            this.EmailAddress = emailAddress;
            this.PhoneNumber = phoneNumber;
            this.ReferenceId = referenceId;
            this.GroupIds = groupIds;
            this.CustomAttribute = customAttribute;
            this.SegmentIds = segmentIds;
        }

        /// <summary>
        /// The creation source filter.
        /// If one or more creation sources are set, customer profiles are included in,
        /// or excluded from, the result if they match at least one of the filter criteria.
        /// </summary>
        [JsonProperty("creation_source", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CustomerCreationSourceFilter CreationSource { get; }

        /// <summary>
        /// Represents a generic time range. The start and end values are
        /// represented in RFC 3339 format. Time ranges are customized to be
        /// inclusive or exclusive based on the needs of a particular endpoint.
        /// Refer to the relevant endpoint-specific documentation to determine
        /// how time ranges are handled.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TimeRange CreatedAt { get; }

        /// <summary>
        /// Represents a generic time range. The start and end values are
        /// represented in RFC 3339 format. Time ranges are customized to be
        /// inclusive or exclusive based on the needs of a particular endpoint.
        /// Refer to the relevant endpoint-specific documentation to determine
        /// how time ranges are handled.
        /// </summary>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TimeRange UpdatedAt { get; }

        /// <summary>
        /// A filter to select customers based on exact or fuzzy matching of
        /// customer attributes against a specified query. Depending on the customer attributes,
        /// the filter can be case-sensitive. This filter can be exact or fuzzy, but it cannot be both.
        /// </summary>
        [JsonProperty("email_address", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CustomerTextFilter EmailAddress { get; }

        /// <summary>
        /// A filter to select customers based on exact or fuzzy matching of
        /// customer attributes against a specified query. Depending on the customer attributes,
        /// the filter can be case-sensitive. This filter can be exact or fuzzy, but it cannot be both.
        /// </summary>
        [JsonProperty("phone_number", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CustomerTextFilter PhoneNumber { get; }

        /// <summary>
        /// A filter to select customers based on exact or fuzzy matching of
        /// customer attributes against a specified query. Depending on the customer attributes,
        /// the filter can be case-sensitive. This filter can be exact or fuzzy, but it cannot be both.
        /// </summary>
        [JsonProperty("reference_id", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CustomerTextFilter ReferenceId { get; }

        /// <summary>
        /// A filter to select resources based on an exact field value. For any given
        /// value, the value can only be in one property. Depending on the field, either
        /// all properties can be set or only a subset will be available.
        /// Refer to the documentation of the field.
        /// </summary>
        [JsonProperty("group_ids", NullValueHandling = NullValueHandling.Ignore)]
        public Models.FilterValue GroupIds { get; }

        /// <summary>
        /// The custom attribute filters in a set of [customer filters]($m/CustomerFilter) used in a search query. Use this filter
        /// to search based on [custom attributes]($m/CustomAttribute) that are assigned to customer profiles. For more information, see
        /// [Search by custom attribute](https://developer.squareup.com/docs/customers-api/use-the-api/search-customers#search-by-custom-attribute).
        /// </summary>
        [JsonProperty("custom_attribute", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CustomerCustomAttributeFilters CustomAttribute { get; }

        /// <summary>
        /// A filter to select resources based on an exact field value. For any given
        /// value, the value can only be in one property. Depending on the field, either
        /// all properties can be set or only a subset will be available.
        /// Refer to the documentation of the field.
        /// </summary>
        [JsonProperty("segment_ids", NullValueHandling = NullValueHandling.Ignore)]
        public Models.FilterValue SegmentIds { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CustomerFilter : ({string.Join(", ", toStringOutput)})";
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

            return obj is CustomerFilter other &&
                ((this.CreationSource == null && other.CreationSource == null) || (this.CreationSource?.Equals(other.CreationSource) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((this.UpdatedAt == null && other.UpdatedAt == null) || (this.UpdatedAt?.Equals(other.UpdatedAt) == true)) &&
                ((this.EmailAddress == null && other.EmailAddress == null) || (this.EmailAddress?.Equals(other.EmailAddress) == true)) &&
                ((this.PhoneNumber == null && other.PhoneNumber == null) || (this.PhoneNumber?.Equals(other.PhoneNumber) == true)) &&
                ((this.ReferenceId == null && other.ReferenceId == null) || (this.ReferenceId?.Equals(other.ReferenceId) == true)) &&
                ((this.GroupIds == null && other.GroupIds == null) || (this.GroupIds?.Equals(other.GroupIds) == true)) &&
                ((this.CustomAttribute == null && other.CustomAttribute == null) || (this.CustomAttribute?.Equals(other.CustomAttribute) == true)) &&
                ((this.SegmentIds == null && other.SegmentIds == null) || (this.SegmentIds?.Equals(other.SegmentIds) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -671238203;
            hashCode = HashCode.Combine(this.CreationSource, this.CreatedAt, this.UpdatedAt, this.EmailAddress, this.PhoneNumber, this.ReferenceId, this.GroupIds);

            hashCode = HashCode.Combine(hashCode, this.CustomAttribute, this.SegmentIds);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.CreationSource = {(this.CreationSource == null ? "null" : this.CreationSource.ToString())}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt.ToString())}");
            toStringOutput.Add($"this.UpdatedAt = {(this.UpdatedAt == null ? "null" : this.UpdatedAt.ToString())}");
            toStringOutput.Add($"this.EmailAddress = {(this.EmailAddress == null ? "null" : this.EmailAddress.ToString())}");
            toStringOutput.Add($"this.PhoneNumber = {(this.PhoneNumber == null ? "null" : this.PhoneNumber.ToString())}");
            toStringOutput.Add($"this.ReferenceId = {(this.ReferenceId == null ? "null" : this.ReferenceId.ToString())}");
            toStringOutput.Add($"this.GroupIds = {(this.GroupIds == null ? "null" : this.GroupIds.ToString())}");
            toStringOutput.Add($"this.CustomAttribute = {(this.CustomAttribute == null ? "null" : this.CustomAttribute.ToString())}");
            toStringOutput.Add($"this.SegmentIds = {(this.SegmentIds == null ? "null" : this.SegmentIds.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .CreationSource(this.CreationSource)
                .CreatedAt(this.CreatedAt)
                .UpdatedAt(this.UpdatedAt)
                .EmailAddress(this.EmailAddress)
                .PhoneNumber(this.PhoneNumber)
                .ReferenceId(this.ReferenceId)
                .GroupIds(this.GroupIds)
                .CustomAttribute(this.CustomAttribute)
                .SegmentIds(this.SegmentIds);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.CustomerCreationSourceFilter creationSource;
            private Models.TimeRange createdAt;
            private Models.TimeRange updatedAt;
            private Models.CustomerTextFilter emailAddress;
            private Models.CustomerTextFilter phoneNumber;
            private Models.CustomerTextFilter referenceId;
            private Models.FilterValue groupIds;
            private Models.CustomerCustomAttributeFilters customAttribute;
            private Models.FilterValue segmentIds;

             /// <summary>
             /// CreationSource.
             /// </summary>
             /// <param name="creationSource"> creationSource. </param>
             /// <returns> Builder. </returns>
            public Builder CreationSource(Models.CustomerCreationSourceFilter creationSource)
            {
                this.creationSource = creationSource;
                return this;
            }

             /// <summary>
             /// CreatedAt.
             /// </summary>
             /// <param name="createdAt"> createdAt. </param>
             /// <returns> Builder. </returns>
            public Builder CreatedAt(Models.TimeRange createdAt)
            {
                this.createdAt = createdAt;
                return this;
            }

             /// <summary>
             /// UpdatedAt.
             /// </summary>
             /// <param name="updatedAt"> updatedAt. </param>
             /// <returns> Builder. </returns>
            public Builder UpdatedAt(Models.TimeRange updatedAt)
            {
                this.updatedAt = updatedAt;
                return this;
            }

             /// <summary>
             /// EmailAddress.
             /// </summary>
             /// <param name="emailAddress"> emailAddress. </param>
             /// <returns> Builder. </returns>
            public Builder EmailAddress(Models.CustomerTextFilter emailAddress)
            {
                this.emailAddress = emailAddress;
                return this;
            }

             /// <summary>
             /// PhoneNumber.
             /// </summary>
             /// <param name="phoneNumber"> phoneNumber. </param>
             /// <returns> Builder. </returns>
            public Builder PhoneNumber(Models.CustomerTextFilter phoneNumber)
            {
                this.phoneNumber = phoneNumber;
                return this;
            }

             /// <summary>
             /// ReferenceId.
             /// </summary>
             /// <param name="referenceId"> referenceId. </param>
             /// <returns> Builder. </returns>
            public Builder ReferenceId(Models.CustomerTextFilter referenceId)
            {
                this.referenceId = referenceId;
                return this;
            }

             /// <summary>
             /// GroupIds.
             /// </summary>
             /// <param name="groupIds"> groupIds. </param>
             /// <returns> Builder. </returns>
            public Builder GroupIds(Models.FilterValue groupIds)
            {
                this.groupIds = groupIds;
                return this;
            }

             /// <summary>
             /// CustomAttribute.
             /// </summary>
             /// <param name="customAttribute"> customAttribute. </param>
             /// <returns> Builder. </returns>
            public Builder CustomAttribute(Models.CustomerCustomAttributeFilters customAttribute)
            {
                this.customAttribute = customAttribute;
                return this;
            }

             /// <summary>
             /// SegmentIds.
             /// </summary>
             /// <param name="segmentIds"> segmentIds. </param>
             /// <returns> Builder. </returns>
            public Builder SegmentIds(Models.FilterValue segmentIds)
            {
                this.segmentIds = segmentIds;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CustomerFilter. </returns>
            public CustomerFilter Build()
            {
                return new CustomerFilter(
                    this.creationSource,
                    this.createdAt,
                    this.updatedAt,
                    this.emailAddress,
                    this.phoneNumber,
                    this.referenceId,
                    this.groupIds,
                    this.customAttribute,
                    this.segmentIds);
            }
        }
    }
}