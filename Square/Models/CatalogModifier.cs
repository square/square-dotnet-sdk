
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
    public class CatalogModifier 
    {
        public CatalogModifier(string name = null,
            Models.Money priceMoney = null,
            int? ordinal = null,
            string modifierListId = null)
        {
            Name = name;
            PriceMoney = priceMoney;
            Ordinal = ordinal;
            ModifierListId = modifierListId;
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogModifier : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Name = {(Name == null ? "null" : Name == string.Empty ? "" : Name)}");
            toStringOutput.Add($"PriceMoney = {(PriceMoney == null ? "null" : PriceMoney.ToString())}");
            toStringOutput.Add($"Ordinal = {(Ordinal == null ? "null" : Ordinal.ToString())}");
            toStringOutput.Add($"ModifierListId = {(ModifierListId == null ? "null" : ModifierListId == string.Empty ? "" : ModifierListId)}");
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

            return obj is CatalogModifier other &&
                ((Name == null && other.Name == null) || (Name?.Equals(other.Name) == true)) &&
                ((PriceMoney == null && other.PriceMoney == null) || (PriceMoney?.Equals(other.PriceMoney) == true)) &&
                ((Ordinal == null && other.Ordinal == null) || (Ordinal?.Equals(other.Ordinal) == true)) &&
                ((ModifierListId == null && other.ModifierListId == null) || (ModifierListId?.Equals(other.ModifierListId) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 858792878;

            if (Name != null)
            {
               hashCode += Name.GetHashCode();
            }

            if (PriceMoney != null)
            {
               hashCode += PriceMoney.GetHashCode();
            }

            if (Ordinal != null)
            {
               hashCode += Ordinal.GetHashCode();
            }

            if (ModifierListId != null)
            {
               hashCode += ModifierListId.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Name(Name)
                .PriceMoney(PriceMoney)
                .Ordinal(Ordinal)
                .ModifierListId(ModifierListId);
            return builder;
        }

        public class Builder
        {
            private string name;
            private Models.Money priceMoney;
            private int? ordinal;
            private string modifierListId;



            public Builder Name(string name)
            {
                this.name = name;
                return this;
            }

            public Builder PriceMoney(Models.Money priceMoney)
            {
                this.priceMoney = priceMoney;
                return this;
            }

            public Builder Ordinal(int? ordinal)
            {
                this.ordinal = ordinal;
                return this;
            }

            public Builder ModifierListId(string modifierListId)
            {
                this.modifierListId = modifierListId;
                return this;
            }

            public CatalogModifier Build()
            {
                return new CatalogModifier(name,
                    priceMoney,
                    ordinal,
                    modifierListId);
            }
        }
    }
}