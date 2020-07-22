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
    public class CatalogModifierList 
    {
        public CatalogModifierList(string name = null,
            int? ordinal = null,
            string selectionType = null,
            IList<Models.CatalogObject> modifiers = null)
        {
            Name = name;
            Ordinal = ordinal;
            SelectionType = selectionType;
            Modifiers = modifiers;
        }

        /// <summary>
        /// The name for the `CatalogModifierList` instance. This is a searchable attribute for use in applicable query filters, and its value length is of Unicode code points.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// Determines where this modifier list appears in a list of `CatalogModifierList` values.
        /// </summary>
        [JsonProperty("ordinal")]
        public int? Ordinal { get; }

        /// <summary>
        /// Indicates whether a CatalogModifierList supports multiple selections.
        /// </summary>
        [JsonProperty("selection_type")]
        public string SelectionType { get; }

        /// <summary>
        /// The options included in the `CatalogModifierList`.
        /// You must include at least one `CatalogModifier`.
        /// Each CatalogObject must have type `MODIFIER` and contain
        /// `CatalogModifier` data.
        /// </summary>
        [JsonProperty("modifiers")]
        public IList<Models.CatalogObject> Modifiers { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Name(Name)
                .Ordinal(Ordinal)
                .SelectionType(SelectionType)
                .Modifiers(Modifiers);
            return builder;
        }

        public class Builder
        {
            private string name;
            private int? ordinal;
            private string selectionType;
            private IList<Models.CatalogObject> modifiers = new List<Models.CatalogObject>();

            public Builder() { }
            public Builder Name(string value)
            {
                name = value;
                return this;
            }

            public Builder Ordinal(int? value)
            {
                ordinal = value;
                return this;
            }

            public Builder SelectionType(string value)
            {
                selectionType = value;
                return this;
            }

            public Builder Modifiers(IList<Models.CatalogObject> value)
            {
                modifiers = value;
                return this;
            }

            public CatalogModifierList Build()
            {
                return new CatalogModifierList(name,
                    ordinal,
                    selectionType,
                    modifiers);
            }
        }
    }
}