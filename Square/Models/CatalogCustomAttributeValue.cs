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
    public class CatalogCustomAttributeValue 
    {
        public CatalogCustomAttributeValue(string name = null,
            string stringValue = null,
            string customAttributeDefinitionId = null,
            string type = null,
            string numberValue = null,
            bool? booleanValue = null,
            IList<string> selectionUidValues = null,
            string key = null)
        {
            Name = name;
            StringValue = stringValue;
            CustomAttributeDefinitionId = customAttributeDefinitionId;
            Type = type;
            NumberValue = numberValue;
            BooleanValue = booleanValue;
            SelectionUidValues = selectionUidValues;
            Key = key;
        }

        /// <summary>
        /// The name of the custom attribute.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// The string value of the custom attribute.  Populated if `type` = `STRING`.
        /// </summary>
        [JsonProperty("string_value")]
        public string StringValue { get; }

        /// <summary>
        /// __Read-only.__ The id of the [CatalogCustomAttributeDefinition](#type-CatalogCustomAttributeDefinition) this value belongs to.
        /// </summary>
        [JsonProperty("custom_attribute_definition_id")]
        public string CustomAttributeDefinitionId { get; }

        /// <summary>
        /// Defines the possible types for a custom attribute.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; }

        /// <summary>
        /// Populated if `type` = `NUMBER`. Contains a string
        /// representation of a decimal number, using a `.` as the decimal separator.
        /// </summary>
        [JsonProperty("number_value")]
        public string NumberValue { get; }

        /// <summary>
        /// A `true` or `false` value. Populated if `type` = `BOOLEAN`.
        /// </summary>
        [JsonProperty("boolean_value")]
        public bool? BooleanValue { get; }

        /// <summary>
        /// One or more choices from `allowed_selections`. Populated if `type` = `SELECTION`.
        /// </summary>
        [JsonProperty("selection_uid_values")]
        public IList<string> SelectionUidValues { get; }

        /// <summary>
        /// __Read-only.__ A copy of key from the associated `CatalogCustomAttributeDefinition`.
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Name(Name)
                .StringValue(StringValue)
                .CustomAttributeDefinitionId(CustomAttributeDefinitionId)
                .Type(Type)
                .NumberValue(NumberValue)
                .BooleanValue(BooleanValue)
                .SelectionUidValues(SelectionUidValues)
                .Key(Key);
            return builder;
        }

        public class Builder
        {
            private string name;
            private string stringValue;
            private string customAttributeDefinitionId;
            private string type;
            private string numberValue;
            private bool? booleanValue;
            private IList<string> selectionUidValues = new List<string>();
            private string key;

            public Builder() { }
            public Builder Name(string value)
            {
                name = value;
                return this;
            }

            public Builder StringValue(string value)
            {
                stringValue = value;
                return this;
            }

            public Builder CustomAttributeDefinitionId(string value)
            {
                customAttributeDefinitionId = value;
                return this;
            }

            public Builder Type(string value)
            {
                type = value;
                return this;
            }

            public Builder NumberValue(string value)
            {
                numberValue = value;
                return this;
            }

            public Builder BooleanValue(bool? value)
            {
                booleanValue = value;
                return this;
            }

            public Builder SelectionUidValues(IList<string> value)
            {
                selectionUidValues = value;
                return this;
            }

            public Builder Key(string value)
            {
                key = value;
                return this;
            }

            public CatalogCustomAttributeValue Build()
            {
                return new CatalogCustomAttributeValue(name,
                    stringValue,
                    customAttributeDefinitionId,
                    type,
                    numberValue,
                    booleanValue,
                    selectionUidValues,
                    key);
            }
        }
    }
}