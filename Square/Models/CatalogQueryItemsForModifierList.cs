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
    public class CatalogQueryItemsForModifierList 
    {
        public CatalogQueryItemsForModifierList(IList<string> modifierListIds)
        {
            ModifierListIds = modifierListIds;
        }

        /// <summary>
        /// A set of `CatalogModifierList` IDs to be used to find associated `CatalogItem`s.
        /// </summary>
        [JsonProperty("modifier_list_ids")]
        public IList<string> ModifierListIds { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(ModifierListIds);
            return builder;
        }

        public class Builder
        {
            private IList<string> modifierListIds;

            public Builder(IList<string> modifierListIds)
            {
                this.modifierListIds = modifierListIds;
            }
            public Builder ModifierListIds(IList<string> value)
            {
                modifierListIds = value;
                return this;
            }

            public CatalogQueryItemsForModifierList Build()
            {
                return new CatalogQueryItemsForModifierList(modifierListIds);
            }
        }
    }
}