using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square.Http.Client;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class V1ModifierList 
    {
        public V1ModifierList(string id = null,
            string name = null,
            string selectionType = null,
            IList<Models.V1ModifierOption> modifierOptions = null,
            string v2Id = null)
        {
            Id = id;
            Name = name;
            SelectionType = selectionType;
            ModifierOptions = modifierOptions;
            V2Id = v2Id;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// The modifier list's unique ID.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// The modifier list's name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// Getter for selection_type
        /// </summary>
        [JsonProperty("selection_type")]
        public string SelectionType { get; }

        /// <summary>
        /// The options included in the modifier list.
        /// </summary>
        [JsonProperty("modifier_options")]
        public IList<Models.V1ModifierOption> ModifierOptions { get; }

        /// <summary>
        /// The ID of the CatalogObject in the Connect v2 API. Objects that are shared across multiple locations share the same v2 ID.
        /// </summary>
        [JsonProperty("v2_id")]
        public string V2Id { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(Id)
                .Name(Name)
                .SelectionType(SelectionType)
                .ModifierOptions(ModifierOptions)
                .V2Id(V2Id);
            return builder;
        }

        public class Builder
        {
            private string id;
            private string name;
            private string selectionType;
            private IList<Models.V1ModifierOption> modifierOptions = new List<Models.V1ModifierOption>();
            private string v2Id;

            public Builder() { }
            public Builder Id(string value)
            {
                id = value;
                return this;
            }

            public Builder Name(string value)
            {
                name = value;
                return this;
            }

            public Builder SelectionType(string value)
            {
                selectionType = value;
                return this;
            }

            public Builder ModifierOptions(IList<Models.V1ModifierOption> value)
            {
                modifierOptions = value;
                return this;
            }

            public Builder V2Id(string value)
            {
                v2Id = value;
                return this;
            }

            public V1ModifierList Build()
            {
                return new V1ModifierList(id,
                    name,
                    selectionType,
                    modifierOptions,
                    v2Id);
            }
        }
    }
}