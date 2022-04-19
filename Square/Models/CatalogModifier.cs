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
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogModifier"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="priceMoney">price_money.</param>
        /// <param name="ordinal">ordinal.</param>
        /// <param name="modifierListId">modifier_list_id.</param>
        /// <param name="imageIds">image_ids.</param>
        public CatalogModifier(
            string name = null,
            Models.Money priceMoney = null,
            int? ordinal = null,
            string modifierListId = null,
            IList<string> imageIds = null)
        {
            this.Name = name;
            this.PriceMoney = priceMoney;
            this.Ordinal = ordinal;
            this.ModifierListId = modifierListId;
            this.ImageIds = imageIds;
        }

        /// <summary>
        /// The modifier name.  This is a searchable attribute for use in applicable query filters, and its value length is of Unicode code points.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
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
        [JsonProperty("ordinal", NullValueHandling = NullValueHandling.Ignore)]
        public int? Ordinal { get; }

        /// <summary>
        /// The ID of the `CatalogModifierList` associated with this modifier.
        /// </summary>
        [JsonProperty("modifier_list_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ModifierListId { get; }

        /// <summary>
        /// The IDs of images associated with this `CatalogModifier` instance.
        /// Currently these images are not displayed by Square, but are free to be displayed in 3rd party applications.
        /// </summary>
        [JsonProperty("image_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> ImageIds { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogModifier : ({string.Join(", ", toStringOutput)})";
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

            return obj is CatalogModifier other &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.PriceMoney == null && other.PriceMoney == null) || (this.PriceMoney?.Equals(other.PriceMoney) == true)) &&
                ((this.Ordinal == null && other.Ordinal == null) || (this.Ordinal?.Equals(other.Ordinal) == true)) &&
                ((this.ModifierListId == null && other.ModifierListId == null) || (this.ModifierListId?.Equals(other.ModifierListId) == true)) &&
                ((this.ImageIds == null && other.ImageIds == null) || (this.ImageIds?.Equals(other.ImageIds) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -255597588;
            hashCode = HashCode.Combine(this.Name, this.PriceMoney, this.Ordinal, this.ModifierListId, this.ImageIds);

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
            toStringOutput.Add($"this.ImageIds = {(this.ImageIds == null ? "null" : $"[{string.Join(", ", this.ImageIds)} ]")}");
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
                .ImageIds(this.ImageIds);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string name;
            private Models.Money priceMoney;
            private int? ordinal;
            private string modifierListId;
            private IList<string> imageIds;

             /// <summary>
             /// Name.
             /// </summary>
             /// <param name="name"> name. </param>
             /// <returns> Builder. </returns>
            public Builder Name(string name)
            {
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
                this.modifierListId = modifierListId;
                return this;
            }

             /// <summary>
             /// ImageIds.
             /// </summary>
             /// <param name="imageIds"> imageIds. </param>
             /// <returns> Builder. </returns>
            public Builder ImageIds(IList<string> imageIds)
            {
                this.imageIds = imageIds;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogModifier. </returns>
            public CatalogModifier Build()
            {
                return new CatalogModifier(
                    this.name,
                    this.priceMoney,
                    this.ordinal,
                    this.modifierListId,
                    this.imageIds);
            }
        }
    }
}