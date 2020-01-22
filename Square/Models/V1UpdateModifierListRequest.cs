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
    public class V1UpdateModifierListRequest 
    {
        public V1UpdateModifierListRequest(string name = null,
            string selectionType = null)
        {
            Name = name;
            SelectionType = selectionType;
        }

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

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Name(Name)
                .SelectionType(SelectionType);
            return builder;
        }

        public class Builder
        {
            private string name;
            private string selectionType;

            public Builder() { }
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

            public V1UpdateModifierListRequest Build()
            {
                return new V1UpdateModifierListRequest(name,
                    selectionType);
            }
        }
    }
}