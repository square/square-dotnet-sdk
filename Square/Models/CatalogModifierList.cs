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
    /// CatalogModifierList.
    /// </summary>
    public class CatalogModifierList
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogModifierList"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="ordinal">ordinal.</param>
        /// <param name="selectionType">selection_type.</param>
        /// <param name="modifiers">modifiers.</param>
        public CatalogModifierList(
            string name = null,
            int? ordinal = null,
            string selectionType = null,
            IList<Models.CatalogObject> modifiers = null)
        {
            this.Name = name;
            this.Ordinal = ordinal;
            this.SelectionType = selectionType;
            this.Modifiers = modifiers;
        }

        /// <summary>
        /// The name for the `CatalogModifierList` instance. This is a searchable attribute for use in applicable query filters, and its value length is of Unicode code points.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; }

        /// <summary>
        /// Determines where this modifier list appears in a list of `CatalogModifierList` values.
        /// </summary>
        [JsonProperty("ordinal", NullValueHandling = NullValueHandling.Ignore)]
        public int? Ordinal { get; }

        /// <summary>
        /// Indicates whether a CatalogModifierList supports multiple selections.
        /// </summary>
        [JsonProperty("selection_type", NullValueHandling = NullValueHandling.Ignore)]
        public string SelectionType { get; }

        /// <summary>
        /// The options included in the `CatalogModifierList`.
        /// You must include at least one `CatalogModifier`.
        /// Each CatalogObject must have type `MODIFIER` and contain
        /// `CatalogModifier` data.
        /// </summary>
        [JsonProperty("modifiers", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.CatalogObject> Modifiers { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogModifierList : ({string.Join(", ", toStringOutput)})";
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

            return obj is CatalogModifierList other &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.Ordinal == null && other.Ordinal == null) || (this.Ordinal?.Equals(other.Ordinal) == true)) &&
                ((this.SelectionType == null && other.SelectionType == null) || (this.SelectionType?.Equals(other.SelectionType) == true)) &&
                ((this.Modifiers == null && other.Modifiers == null) || (this.Modifiers?.Equals(other.Modifiers) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1257227706;

            if (this.Name != null)
            {
               hashCode += this.Name.GetHashCode();
            }

            if (this.Ordinal != null)
            {
               hashCode += this.Ordinal.GetHashCode();
            }

            if (this.SelectionType != null)
            {
               hashCode += this.SelectionType.GetHashCode();
            }

            if (this.Modifiers != null)
            {
               hashCode += this.Modifiers.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name == string.Empty ? "" : this.Name)}");
            toStringOutput.Add($"this.Ordinal = {(this.Ordinal == null ? "null" : this.Ordinal.ToString())}");
            toStringOutput.Add($"this.SelectionType = {(this.SelectionType == null ? "null" : this.SelectionType.ToString())}");
            toStringOutput.Add($"this.Modifiers = {(this.Modifiers == null ? "null" : $"[{string.Join(", ", this.Modifiers)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Name(this.Name)
                .Ordinal(this.Ordinal)
                .SelectionType(this.SelectionType)
                .Modifiers(this.Modifiers);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string name;
            private int? ordinal;
            private string selectionType;
            private IList<Models.CatalogObject> modifiers;

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
             /// SelectionType.
             /// </summary>
             /// <param name="selectionType"> selectionType. </param>
             /// <returns> Builder. </returns>
            public Builder SelectionType(string selectionType)
            {
                this.selectionType = selectionType;
                return this;
            }

             /// <summary>
             /// Modifiers.
             /// </summary>
             /// <param name="modifiers"> modifiers. </param>
             /// <returns> Builder. </returns>
            public Builder Modifiers(IList<Models.CatalogObject> modifiers)
            {
                this.modifiers = modifiers;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogModifierList. </returns>
            public CatalogModifierList Build()
            {
                return new CatalogModifierList(
                    this.name,
                    this.ordinal,
                    this.selectionType,
                    this.modifiers);
            }
        }
    }
}