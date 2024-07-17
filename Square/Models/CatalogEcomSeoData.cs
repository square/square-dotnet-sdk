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
    /// CatalogEcomSeoData.
    /// </summary>
    public class CatalogEcomSeoData
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogEcomSeoData"/> class.
        /// </summary>
        /// <param name="pageTitle">page_title.</param>
        /// <param name="pageDescription">page_description.</param>
        /// <param name="permalink">permalink.</param>
        public CatalogEcomSeoData(
            string pageTitle = null,
            string pageDescription = null,
            string permalink = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "page_title", false },
                { "page_description", false },
                { "permalink", false }
            };

            if (pageTitle != null)
            {
                shouldSerialize["page_title"] = true;
                this.PageTitle = pageTitle;
            }

            if (pageDescription != null)
            {
                shouldSerialize["page_description"] = true;
                this.PageDescription = pageDescription;
            }

            if (permalink != null)
            {
                shouldSerialize["permalink"] = true;
                this.Permalink = permalink;
            }

        }
        internal CatalogEcomSeoData(Dictionary<string, bool> shouldSerialize,
            string pageTitle = null,
            string pageDescription = null,
            string permalink = null)
        {
            this.shouldSerialize = shouldSerialize;
            PageTitle = pageTitle;
            PageDescription = pageDescription;
            Permalink = permalink;
        }

        /// <summary>
        /// The SEO title used for the Square Online store.
        /// </summary>
        [JsonProperty("page_title")]
        public string PageTitle { get; }

        /// <summary>
        /// The SEO description used for the Square Online store.
        /// </summary>
        [JsonProperty("page_description")]
        public string PageDescription { get; }

        /// <summary>
        /// The SEO permalink used for the Square Online store.
        /// </summary>
        [JsonProperty("permalink")]
        public string Permalink { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogEcomSeoData : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePageTitle()
        {
            return this.shouldSerialize["page_title"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePageDescription()
        {
            return this.shouldSerialize["page_description"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePermalink()
        {
            return this.shouldSerialize["permalink"];
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
            return obj is CatalogEcomSeoData other &&                ((this.PageTitle == null && other.PageTitle == null) || (this.PageTitle?.Equals(other.PageTitle) == true)) &&
                ((this.PageDescription == null && other.PageDescription == null) || (this.PageDescription?.Equals(other.PageDescription) == true)) &&
                ((this.Permalink == null && other.Permalink == null) || (this.Permalink?.Equals(other.Permalink) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1727403244;
            hashCode = HashCode.Combine(this.PageTitle, this.PageDescription, this.Permalink);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.PageTitle = {(this.PageTitle == null ? "null" : this.PageTitle)}");
            toStringOutput.Add($"this.PageDescription = {(this.PageDescription == null ? "null" : this.PageDescription)}");
            toStringOutput.Add($"this.Permalink = {(this.Permalink == null ? "null" : this.Permalink)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .PageTitle(this.PageTitle)
                .PageDescription(this.PageDescription)
                .Permalink(this.Permalink);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "page_title", false },
                { "page_description", false },
                { "permalink", false },
            };

            private string pageTitle;
            private string pageDescription;
            private string permalink;

             /// <summary>
             /// PageTitle.
             /// </summary>
             /// <param name="pageTitle"> pageTitle. </param>
             /// <returns> Builder. </returns>
            public Builder PageTitle(string pageTitle)
            {
                shouldSerialize["page_title"] = true;
                this.pageTitle = pageTitle;
                return this;
            }

             /// <summary>
             /// PageDescription.
             /// </summary>
             /// <param name="pageDescription"> pageDescription. </param>
             /// <returns> Builder. </returns>
            public Builder PageDescription(string pageDescription)
            {
                shouldSerialize["page_description"] = true;
                this.pageDescription = pageDescription;
                return this;
            }

             /// <summary>
             /// Permalink.
             /// </summary>
             /// <param name="permalink"> permalink. </param>
             /// <returns> Builder. </returns>
            public Builder Permalink(string permalink)
            {
                shouldSerialize["permalink"] = true;
                this.permalink = permalink;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetPageTitle()
            {
                this.shouldSerialize["page_title"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetPageDescription()
            {
                this.shouldSerialize["page_description"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetPermalink()
            {
                this.shouldSerialize["permalink"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogEcomSeoData. </returns>
            public CatalogEcomSeoData Build()
            {
                return new CatalogEcomSeoData(shouldSerialize,
                    this.pageTitle,
                    this.pageDescription,
                    this.permalink);
            }
        }
    }
}