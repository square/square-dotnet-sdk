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
    /// CatalogModifier.
    /// </summary>
    public class CatalogModifier
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogModifier"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="priceMoney">price_money.</param>
        /// <param name="ordinal">ordinal.</param>
        /// <param name="modifierListId">modifier_list_id.</param>
        /// <param name="locationOverrides">location_overrides.</param>
        /// <param name="imageId">image_id.</param>
        public CatalogModifier(
            string name = null,
            Models.Money priceMoney = null,
            int? ordinal = null,
            string modifierListId = null,
            IList<Models.ModifierLocationOverrides> locationOverrides = null,
            string imageId = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "name", false },
                { "ordinal", false },
                { "modifier_list_id", false },
                { "location_overrides", false },
                { "image_id", false }
            };

            if (name != null)
            {
                shouldSerialize["name"] = true;
                this.Name = name;
            }

            this.PriceMoney = priceMoney;
            if (ordinal != null)
            {
                shouldSerialize["ordinal"] = true;
                this.Ordinal = ordinal;
            }

            if (modifierListId != null)
            {
                shouldSerialize["modifier_list_id"] = true;
                this.ModifierListId = modifierListId;
            }

            if (locationOverrides != null)
            {
                shouldSerialize["location_overrides"] = true;
                this.LocationOverrides = locationOverrides;
            }

            if (imageId != null)
            {
                shouldSerialize["image_id"] = true;
                this.ImageId = imageId;
            }

        }
        internal CatalogModifier(Dictionary<string, bool> shouldSerialize,
            string name = null,
            Models.Money priceMoney = null,
            int? ordinal = null,
            string modifierListId = null,
            IList<Models.ModifierLocationOverrides> locationOverrides = null,
            string imageId = null)
        {
            this.shouldSerialize = shouldSerialize;
            Name = name;
            PriceMoney = priceMoney;
            Ordinal = ordinal;
            ModifierListId = modifierListId;
            LocationOverrides = locationOverrides;
            ImageId = imageId;
        }

        /// <summary>
        /// The modifier name.  This is a searchable attribute for use in applicable query filters, and its value length is of Unicode code points.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("price_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money PriceMoney { get; }

        /// <summary>
        /// Determines where this `CatalogModifier` appears in the `CatalogModifierList`.
        /// </summary>
        [JsonProperty("ordinal")]
        public int? Ordinal { get; }

        /// <summary>
        /// The ID of the `CatalogModifierList` associated with this modifier.
        /// </summary>
        [JsonProperty("modifier_list_id")]
        public string ModifierListId { get; }

        /// <summary>
        /// Location-specific price overrides.
        /// </summary>
        [JsonProperty("location_overrides")]
        public IList<Models.ModifierLocationOverrides> LocationOverrides { get; }

        /// <summary>
        /// The ID of the image associated with this `CatalogModifier` instance.
        /// Currently this image is not displayed by Square, but is free to be displayed in 3rd party applications.
        /// </summary>
        [JsonProperty("image_id")]
        public string ImageId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogModifier : ({string.Join(", ", toStringOutput)})";
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
        public bool ShouldSerializeOrdinal()
        {
            return this.shouldSerialize["ordinal"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeModifierListId()
        {
            return this.shouldSerialize["modifier_list_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLocationOverrides()
        {
            return this.shouldSerialize["location_overrides"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeImageId()
        {
            return this.shouldSerialize["image_id"];
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
            return obj is CatalogModifier other &&                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.PriceMoney == null && other.PriceMoney == null) || (this.PriceMoney?.Equals(other.PriceMoney) == true)) &&
                ((this.Ordinal == null && other.Ordinal == null) || (this.Ordinal?.Equals(other.Ordinal) == true)) &&
                ((this.ModifierListId == null && other.ModifierListId == null) || (this.ModifierListId?.Equals(other.ModifierListId) == true)) &&
                ((this.LocationOverrides == null && other.LocationOverrides == null) || (this.LocationOverrides?.Equals(other.LocationOverrides) == true)) &&
                ((this.ImageId == null && other.ImageId == null) || (this.ImageId?.Equals(other.ImageId) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1040481339;
            hashCode = HashCode.Combine(this.Name, this.PriceMoney, this.Ordinal, this.ModifierListId, this.LocationOverrides, this.ImageId);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name == string.Empty ? "" : this.Name)}");
            toStringOutput.Add($"this.PriceMoney = {(this.PriceMoney == null ? "null" : this.PriceMoney.ToString())}");
            toStringOutput.Add($"this.Ordinal = {(this.Ordinal == null ? "null" : this.Ordinal.ToString())}");
            toStringOutput.Add($"this.ModifierListId = {(this.ModifierListId == null ? "null" : this.ModifierListId == string.Empty ? "" : this.ModifierListId)}");
            toStringOutput.Add($"this.LocationOverrides = {(this.LocationOverrides == null ? "null" : $"[{string.Join(", ", this.LocationOverrides)} ]")}");
            toStringOutput.Add($"this.ImageId = {(this.ImageId == null ? "null" : this.ImageId == string.Empty ? "" : this.ImageId)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Name(this.Name)
                .PriceMoney(this.PriceMoney)
                .Ordinal(this.Ordinal)
                .ModifierListId(this.ModifierListId)
                .LocationOverrides(this.LocationOverrides)
                .ImageId(this.ImageId);
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
                { "ordinal", false },
                { "modifier_list_id", false },
                { "location_overrides", false },
                { "image_id", false },
            };

            private string name;
            private Models.Money priceMoney;
            private int? ordinal;
            private string modifierListId;
            private IList<Models.ModifierLocationOverrides> locationOverrides;
            private string imageId;

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
             /// PriceMoney.
             /// </summary>
             /// <param name="priceMoney"> priceMoney. </param>
             /// <returns> Builder. </returns>
            public Builder PriceMoney(Models.Money priceMoney)
            {
                this.priceMoney = priceMoney;
                return this;
            }

             /// <summary>
             /// Ordinal.
             /// </summary>
             /// <param name="ordinal"> ordinal. </param>
             /// <returns> Builder. </returns>
            public Builder Ordinal(int? ordinal)
            {
                shouldSerialize["ordinal"] = true;
                this.ordinal = ordinal;
                return this;
            }

             /// <summary>
             /// ModifierListId.
             /// </summary>
             /// <param name="modifierListId"> modifierListId. </param>
             /// <returns> Builder. </returns>
            public Builder ModifierListId(string modifierListId)
            {
                shouldSerialize["modifier_list_id"] = true;
                this.modifierListId = modifierListId;
                return this;
            }

             /// <summary>
             /// LocationOverrides.
             /// </summary>
             /// <param name="locationOverrides"> locationOverrides. </param>
             /// <returns> Builder. </returns>
            public Builder LocationOverrides(IList<Models.ModifierLocationOverrides> locationOverrides)
            {
                shouldSerialize["location_overrides"] = true;
                this.locationOverrides = locationOverrides;
                return this;
            }

             /// <summary>
             /// ImageId.
             /// </summary>
             /// <param name="imageId"> imageId. </param>
             /// <returns> Builder. </returns>
            public Builder ImageId(string imageId)
            {
                shouldSerialize["image_id"] = true;
                this.imageId = imageId;
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
            public void UnsetOrdinal()
            {
                this.shouldSerialize["ordinal"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetModifierListId()
            {
                this.shouldSerialize["modifier_list_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetLocationOverrides()
            {
                this.shouldSerialize["location_overrides"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetImageId()
            {
                this.shouldSerialize["image_id"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogModifier. </returns>
            public CatalogModifier Build()
            {
                return new CatalogModifier(shouldSerialize,
                    this.name,
                    this.priceMoney,
                    this.ordinal,
                    this.modifierListId,
                    this.locationOverrides,
                    this.imageId);
            }
        }
    }
}