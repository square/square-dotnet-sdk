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
    /// Site.
    /// </summary>
    public class Site
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="Site"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="siteTitle">site_title.</param>
        /// <param name="domain">domain.</param>
        /// <param name="isPublished">is_published.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="updatedAt">updated_at.</param>
        public Site(
            string id = null,
            string siteTitle = null,
            string domain = null,
            bool? isPublished = null,
            string createdAt = null,
            string updatedAt = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "site_title", false },
                { "domain", false },
                { "is_published", false }
            };

            this.Id = id;
            if (siteTitle != null)
            {
                shouldSerialize["site_title"] = true;
                this.SiteTitle = siteTitle;
            }

            if (domain != null)
            {
                shouldSerialize["domain"] = true;
                this.Domain = domain;
            }

            if (isPublished != null)
            {
                shouldSerialize["is_published"] = true;
                this.IsPublished = isPublished;
            }

            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
        }
        internal Site(Dictionary<string, bool> shouldSerialize,
            string id = null,
            string siteTitle = null,
            string domain = null,
            bool? isPublished = null,
            string createdAt = null,
            string updatedAt = null)
        {
            this.shouldSerialize = shouldSerialize;
            Id = id;
            SiteTitle = siteTitle;
            Domain = domain;
            IsPublished = isPublished;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        /// <summary>
        /// The Square-assigned ID of the site.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The title of the site.
        /// </summary>
        [JsonProperty("site_title")]
        public string SiteTitle { get; }

        /// <summary>
        /// The domain of the site (without the protocol). For example, `mysite1.square.site`.
        /// </summary>
        [JsonProperty("domain")]
        public string Domain { get; }

        /// <summary>
        /// Indicates whether the site is published.
        /// </summary>
        [JsonProperty("is_published")]
        public bool? IsPublished { get; }

        /// <summary>
        /// The timestamp of when the site was created, in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// The timestamp of when the site was last updated, in RFC 3339 format.
        /// </summary>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAt { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Site : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSiteTitle()
        {
            return this.shouldSerialize["site_title"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDomain()
        {
            return this.shouldSerialize["domain"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeIsPublished()
        {
            return this.shouldSerialize["is_published"];
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
            return obj is Site other &&                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.SiteTitle == null && other.SiteTitle == null) || (this.SiteTitle?.Equals(other.SiteTitle) == true)) &&
                ((this.Domain == null && other.Domain == null) || (this.Domain?.Equals(other.Domain) == true)) &&
                ((this.IsPublished == null && other.IsPublished == null) || (this.IsPublished?.Equals(other.IsPublished) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((this.UpdatedAt == null && other.UpdatedAt == null) || (this.UpdatedAt?.Equals(other.UpdatedAt) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1874716552;
            hashCode = HashCode.Combine(this.Id, this.SiteTitle, this.Domain, this.IsPublished, this.CreatedAt, this.UpdatedAt);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.SiteTitle = {(this.SiteTitle == null ? "null" : this.SiteTitle == string.Empty ? "" : this.SiteTitle)}");
            toStringOutput.Add($"this.Domain = {(this.Domain == null ? "null" : this.Domain == string.Empty ? "" : this.Domain)}");
            toStringOutput.Add($"this.IsPublished = {(this.IsPublished == null ? "null" : this.IsPublished.ToString())}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt == string.Empty ? "" : this.CreatedAt)}");
            toStringOutput.Add($"this.UpdatedAt = {(this.UpdatedAt == null ? "null" : this.UpdatedAt == string.Empty ? "" : this.UpdatedAt)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(this.Id)
                .SiteTitle(this.SiteTitle)
                .Domain(this.Domain)
                .IsPublished(this.IsPublished)
                .CreatedAt(this.CreatedAt)
                .UpdatedAt(this.UpdatedAt);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "site_title", false },
                { "domain", false },
                { "is_published", false },
            };

            private string id;
            private string siteTitle;
            private string domain;
            private bool? isPublished;
            private string createdAt;
            private string updatedAt;

             /// <summary>
             /// Id.
             /// </summary>
             /// <param name="id"> id. </param>
             /// <returns> Builder. </returns>
            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

             /// <summary>
             /// SiteTitle.
             /// </summary>
             /// <param name="siteTitle"> siteTitle. </param>
             /// <returns> Builder. </returns>
            public Builder SiteTitle(string siteTitle)
            {
                shouldSerialize["site_title"] = true;
                this.siteTitle = siteTitle;
                return this;
            }

             /// <summary>
             /// Domain.
             /// </summary>
             /// <param name="domain"> domain. </param>
             /// <returns> Builder. </returns>
            public Builder Domain(string domain)
            {
                shouldSerialize["domain"] = true;
                this.domain = domain;
                return this;
            }

             /// <summary>
             /// IsPublished.
             /// </summary>
             /// <param name="isPublished"> isPublished. </param>
             /// <returns> Builder. </returns>
            public Builder IsPublished(bool? isPublished)
            {
                shouldSerialize["is_published"] = true;
                this.isPublished = isPublished;
                return this;
            }

             /// <summary>
             /// CreatedAt.
             /// </summary>
             /// <param name="createdAt"> createdAt. </param>
             /// <returns> Builder. </returns>
            public Builder CreatedAt(string createdAt)
            {
                this.createdAt = createdAt;
                return this;
            }

             /// <summary>
             /// UpdatedAt.
             /// </summary>
             /// <param name="updatedAt"> updatedAt. </param>
             /// <returns> Builder. </returns>
            public Builder UpdatedAt(string updatedAt)
            {
                this.updatedAt = updatedAt;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetSiteTitle()
            {
                this.shouldSerialize["site_title"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetDomain()
            {
                this.shouldSerialize["domain"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetIsPublished()
            {
                this.shouldSerialize["is_published"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> Site. </returns>
            public Site Build()
            {
                return new Site(shouldSerialize,
                    this.id,
                    this.siteTitle,
                    this.domain,
                    this.isPublished,
                    this.createdAt,
                    this.updatedAt);
            }
        }
    }
}