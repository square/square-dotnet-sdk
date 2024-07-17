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
    /// CatalogCategory.
    /// </summary>
    public class CatalogCategory
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogCategory"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="imageIds">image_ids.</param>
        /// <param name="categoryType">category_type.</param>
        /// <param name="parentCategory">parent_category.</param>
        /// <param name="isTopLevel">is_top_level.</param>
        /// <param name="channels">channels.</param>
        /// <param name="availabilityPeriodIds">availability_period_ids.</param>
        /// <param name="onlineVisibility">online_visibility.</param>
        /// <param name="rootCategory">root_category.</param>
        /// <param name="ecomSeoData">ecom_seo_data.</param>
        /// <param name="pathToRoot">path_to_root.</param>
        public CatalogCategory(
            string name = null,
            IList<string> imageIds = null,
            string categoryType = null,
            Models.CatalogObjectCategory parentCategory = null,
            bool? isTopLevel = null,
            IList<string> channels = null,
            IList<string> availabilityPeriodIds = null,
            bool? onlineVisibility = null,
            string rootCategory = null,
            Models.CatalogEcomSeoData ecomSeoData = null,
            IList<Models.CategoryPathToRootNode> pathToRoot = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "name", false },
                { "image_ids", false },
                { "is_top_level", false },
                { "channels", false },
                { "availability_period_ids", false },
                { "online_visibility", false },
                { "path_to_root", false }
            };

            if (name != null)
            {
                shouldSerialize["name"] = true;
                this.Name = name;
            }

            if (imageIds != null)
            {
                shouldSerialize["image_ids"] = true;
                this.ImageIds = imageIds;
            }

            this.CategoryType = categoryType;
            this.ParentCategory = parentCategory;
            if (isTopLevel != null)
            {
                shouldSerialize["is_top_level"] = true;
                this.IsTopLevel = isTopLevel;
            }

            if (channels != null)
            {
                shouldSerialize["channels"] = true;
                this.Channels = channels;
            }

            if (availabilityPeriodIds != null)
            {
                shouldSerialize["availability_period_ids"] = true;
                this.AvailabilityPeriodIds = availabilityPeriodIds;
            }

            if (onlineVisibility != null)
            {
                shouldSerialize["online_visibility"] = true;
                this.OnlineVisibility = onlineVisibility;
            }

            this.RootCategory = rootCategory;
            this.EcomSeoData = ecomSeoData;
            if (pathToRoot != null)
            {
                shouldSerialize["path_to_root"] = true;
                this.PathToRoot = pathToRoot;
            }

        }
        internal CatalogCategory(Dictionary<string, bool> shouldSerialize,
            string name = null,
            IList<string> imageIds = null,
            string categoryType = null,
            Models.CatalogObjectCategory parentCategory = null,
            bool? isTopLevel = null,
            IList<string> channels = null,
            IList<string> availabilityPeriodIds = null,
            bool? onlineVisibility = null,
            string rootCategory = null,
            Models.CatalogEcomSeoData ecomSeoData = null,
            IList<Models.CategoryPathToRootNode> pathToRoot = null)
        {
            this.shouldSerialize = shouldSerialize;
            Name = name;
            ImageIds = imageIds;
            CategoryType = categoryType;
            ParentCategory = parentCategory;
            IsTopLevel = isTopLevel;
            Channels = channels;
            AvailabilityPeriodIds = availabilityPeriodIds;
            OnlineVisibility = onlineVisibility;
            RootCategory = rootCategory;
            EcomSeoData = ecomSeoData;
            PathToRoot = pathToRoot;
        }

        /// <summary>
        /// The category name. This is a searchable attribute for use in applicable query filters, and its value length is of Unicode code points.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// The IDs of images associated with this `CatalogCategory` instance.
        /// Currently these images are not displayed by Square, but are free to be displayed in 3rd party applications.
        /// </summary>
        [JsonProperty("image_ids")]
        public IList<string> ImageIds { get; }

        /// <summary>
        /// Indicates the type of a category.
        /// </summary>
        [JsonProperty("category_type", NullValueHandling = NullValueHandling.Ignore)]
        public string CategoryType { get; }

        /// <summary>
        /// A category that can be assigned to an item or a parent category that can be assigned
        /// to another category. For example, a clothing category can be assigned to a t-shirt item or
        /// be made as the parent category to the pants category.
        /// </summary>
        [JsonProperty("parent_category", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CatalogObjectCategory ParentCategory { get; }

        /// <summary>
        /// Indicates whether a category is a top level category, which does not have any parent_category.
        /// </summary>
        [JsonProperty("is_top_level")]
        public bool? IsTopLevel { get; }

        /// <summary>
        /// A list of IDs representing channels, such as a Square Online site, where the category can be made visible.
        /// </summary>
        [JsonProperty("channels")]
        public IList<string> Channels { get; }

        /// <summary>
        /// The IDs of the `CatalogAvailabilityPeriod` objects associated with the category.
        /// </summary>
        [JsonProperty("availability_period_ids")]
        public IList<string> AvailabilityPeriodIds { get; }

        /// <summary>
        /// Indicates whether the category is visible (`true`) or hidden (`false`) on all of the seller's Square Online sites.
        /// </summary>
        [JsonProperty("online_visibility")]
        public bool? OnlineVisibility { get; }

        /// <summary>
        /// The top-level category in a category hierarchy.
        /// </summary>
        [JsonProperty("root_category", NullValueHandling = NullValueHandling.Ignore)]
        public string RootCategory { get; }

        /// <summary>
        /// SEO data for for a seller's Square Online store.
        /// </summary>
        [JsonProperty("ecom_seo_data", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CatalogEcomSeoData EcomSeoData { get; }

        /// <summary>
        /// The path from the category to its root category. The first node of the path is the parent of the category
        /// and the last is the root category. The path is empty if the category is a root category.
        /// </summary>
        [JsonProperty("path_to_root")]
        public IList<Models.CategoryPathToRootNode> PathToRoot { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogCategory : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeName()
        {
            return this.shouldSerialize["name"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeImageIds()
        {
            return this.shouldSerialize["image_ids"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeIsTopLevel()
        {
            return this.shouldSerialize["is_top_level"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeChannels()
        {
            return this.shouldSerialize["channels"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAvailabilityPeriodIds()
        {
            return this.shouldSerialize["availability_period_ids"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeOnlineVisibility()
        {
            return this.shouldSerialize["online_visibility"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePathToRoot()
        {
            return this.shouldSerialize["path_to_root"];
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
            return obj is CatalogCategory other &&                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.ImageIds == null && other.ImageIds == null) || (this.ImageIds?.Equals(other.ImageIds) == true)) &&
                ((this.CategoryType == null && other.CategoryType == null) || (this.CategoryType?.Equals(other.CategoryType) == true)) &&
                ((this.ParentCategory == null && other.ParentCategory == null) || (this.ParentCategory?.Equals(other.ParentCategory) == true)) &&
                ((this.IsTopLevel == null && other.IsTopLevel == null) || (this.IsTopLevel?.Equals(other.IsTopLevel) == true)) &&
                ((this.Channels == null && other.Channels == null) || (this.Channels?.Equals(other.Channels) == true)) &&
                ((this.AvailabilityPeriodIds == null && other.AvailabilityPeriodIds == null) || (this.AvailabilityPeriodIds?.Equals(other.AvailabilityPeriodIds) == true)) &&
                ((this.OnlineVisibility == null && other.OnlineVisibility == null) || (this.OnlineVisibility?.Equals(other.OnlineVisibility) == true)) &&
                ((this.RootCategory == null && other.RootCategory == null) || (this.RootCategory?.Equals(other.RootCategory) == true)) &&
                ((this.EcomSeoData == null && other.EcomSeoData == null) || (this.EcomSeoData?.Equals(other.EcomSeoData) == true)) &&
                ((this.PathToRoot == null && other.PathToRoot == null) || (this.PathToRoot?.Equals(other.PathToRoot) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1335470543;
            hashCode = HashCode.Combine(this.Name, this.ImageIds, this.CategoryType, this.ParentCategory, this.IsTopLevel, this.Channels, this.AvailabilityPeriodIds);

            hashCode = HashCode.Combine(hashCode, this.OnlineVisibility, this.RootCategory, this.EcomSeoData, this.PathToRoot);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name)}");
            toStringOutput.Add($"this.ImageIds = {(this.ImageIds == null ? "null" : $"[{string.Join(", ", this.ImageIds)} ]")}");
            toStringOutput.Add($"this.CategoryType = {(this.CategoryType == null ? "null" : this.CategoryType.ToString())}");
            toStringOutput.Add($"this.ParentCategory = {(this.ParentCategory == null ? "null" : this.ParentCategory.ToString())}");
            toStringOutput.Add($"this.IsTopLevel = {(this.IsTopLevel == null ? "null" : this.IsTopLevel.ToString())}");
            toStringOutput.Add($"this.Channels = {(this.Channels == null ? "null" : $"[{string.Join(", ", this.Channels)} ]")}");
            toStringOutput.Add($"this.AvailabilityPeriodIds = {(this.AvailabilityPeriodIds == null ? "null" : $"[{string.Join(", ", this.AvailabilityPeriodIds)} ]")}");
            toStringOutput.Add($"this.OnlineVisibility = {(this.OnlineVisibility == null ? "null" : this.OnlineVisibility.ToString())}");
            toStringOutput.Add($"this.RootCategory = {(this.RootCategory == null ? "null" : this.RootCategory)}");
            toStringOutput.Add($"this.EcomSeoData = {(this.EcomSeoData == null ? "null" : this.EcomSeoData.ToString())}");
            toStringOutput.Add($"this.PathToRoot = {(this.PathToRoot == null ? "null" : $"[{string.Join(", ", this.PathToRoot)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Name(this.Name)
                .ImageIds(this.ImageIds)
                .CategoryType(this.CategoryType)
                .ParentCategory(this.ParentCategory)
                .IsTopLevel(this.IsTopLevel)
                .Channels(this.Channels)
                .AvailabilityPeriodIds(this.AvailabilityPeriodIds)
                .OnlineVisibility(this.OnlineVisibility)
                .RootCategory(this.RootCategory)
                .EcomSeoData(this.EcomSeoData)
                .PathToRoot(this.PathToRoot);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "name", false },
                { "image_ids", false },
                { "is_top_level", false },
                { "channels", false },
                { "availability_period_ids", false },
                { "online_visibility", false },
                { "path_to_root", false },
            };

            private string name;
            private IList<string> imageIds;
            private string categoryType;
            private Models.CatalogObjectCategory parentCategory;
            private bool? isTopLevel;
            private IList<string> channels;
            private IList<string> availabilityPeriodIds;
            private bool? onlineVisibility;
            private string rootCategory;
            private Models.CatalogEcomSeoData ecomSeoData;
            private IList<Models.CategoryPathToRootNode> pathToRoot;

             /// <summary>
             /// Name.
             /// </summary>
             /// <param name="name"> name. </param>
             /// <returns> Builder. </returns>
            public Builder Name(string name)
            {
                shouldSerialize["name"] = true;
                this.name = name;
                return this;
            }

             /// <summary>
             /// ImageIds.
             /// </summary>
             /// <param name="imageIds"> imageIds. </param>
             /// <returns> Builder. </returns>
            public Builder ImageIds(IList<string> imageIds)
            {
                shouldSerialize["image_ids"] = true;
                this.imageIds = imageIds;
                return this;
            }

             /// <summary>
             /// CategoryType.
             /// </summary>
             /// <param name="categoryType"> categoryType. </param>
             /// <returns> Builder. </returns>
            public Builder CategoryType(string categoryType)
            {
                this.categoryType = categoryType;
                return this;
            }

             /// <summary>
             /// ParentCategory.
             /// </summary>
             /// <param name="parentCategory"> parentCategory. </param>
             /// <returns> Builder. </returns>
            public Builder ParentCategory(Models.CatalogObjectCategory parentCategory)
            {
                this.parentCategory = parentCategory;
                return this;
            }

             /// <summary>
             /// IsTopLevel.
             /// </summary>
             /// <param name="isTopLevel"> isTopLevel. </param>
             /// <returns> Builder. </returns>
            public Builder IsTopLevel(bool? isTopLevel)
            {
                shouldSerialize["is_top_level"] = true;
                this.isTopLevel = isTopLevel;
                return this;
            }

             /// <summary>
             /// Channels.
             /// </summary>
             /// <param name="channels"> channels. </param>
             /// <returns> Builder. </returns>
            public Builder Channels(IList<string> channels)
            {
                shouldSerialize["channels"] = true;
                this.channels = channels;
                return this;
            }

             /// <summary>
             /// AvailabilityPeriodIds.
             /// </summary>
             /// <param name="availabilityPeriodIds"> availabilityPeriodIds. </param>
             /// <returns> Builder. </returns>
            public Builder AvailabilityPeriodIds(IList<string> availabilityPeriodIds)
            {
                shouldSerialize["availability_period_ids"] = true;
                this.availabilityPeriodIds = availabilityPeriodIds;
                return this;
            }

             /// <summary>
             /// OnlineVisibility.
             /// </summary>
             /// <param name="onlineVisibility"> onlineVisibility. </param>
             /// <returns> Builder. </returns>
            public Builder OnlineVisibility(bool? onlineVisibility)
            {
                shouldSerialize["online_visibility"] = true;
                this.onlineVisibility = onlineVisibility;
                return this;
            }

             /// <summary>
             /// RootCategory.
             /// </summary>
             /// <param name="rootCategory"> rootCategory. </param>
             /// <returns> Builder. </returns>
            public Builder RootCategory(string rootCategory)
            {
                this.rootCategory = rootCategory;
                return this;
            }

             /// <summary>
             /// EcomSeoData.
             /// </summary>
             /// <param name="ecomSeoData"> ecomSeoData. </param>
             /// <returns> Builder. </returns>
            public Builder EcomSeoData(Models.CatalogEcomSeoData ecomSeoData)
            {
                this.ecomSeoData = ecomSeoData;
                return this;
            }

             /// <summary>
             /// PathToRoot.
             /// </summary>
             /// <param name="pathToRoot"> pathToRoot. </param>
             /// <returns> Builder. </returns>
            public Builder PathToRoot(IList<Models.CategoryPathToRootNode> pathToRoot)
            {
                shouldSerialize["path_to_root"] = true;
                this.pathToRoot = pathToRoot;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetName()
            {
                this.shouldSerialize["name"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetImageIds()
            {
                this.shouldSerialize["image_ids"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetIsTopLevel()
            {
                this.shouldSerialize["is_top_level"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetChannels()
            {
                this.shouldSerialize["channels"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetAvailabilityPeriodIds()
            {
                this.shouldSerialize["availability_period_ids"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetOnlineVisibility()
            {
                this.shouldSerialize["online_visibility"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetPathToRoot()
            {
                this.shouldSerialize["path_to_root"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogCategory. </returns>
            public CatalogCategory Build()
            {
                return new CatalogCategory(shouldSerialize,
                    this.name,
                    this.imageIds,
                    this.categoryType,
                    this.parentCategory,
                    this.isTopLevel,
                    this.channels,
                    this.availabilityPeriodIds,
                    this.onlineVisibility,
                    this.rootCategory,
                    this.ecomSeoData,
                    this.pathToRoot);
            }
        }
    }
}