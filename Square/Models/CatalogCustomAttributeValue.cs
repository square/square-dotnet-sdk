
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
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; }

        /// <summary>
        /// The string value of the custom attribute.  Populated if `type` = `STRING`.
        /// </summary>
        [JsonProperty("string_value", NullValueHandling = NullValueHandling.Ignore)]
        public string StringValue { get; }

        /// <summary>
        /// __Read-only.__ The id of the [CatalogCustomAttributeDefinition](#type-CatalogCustomAttributeDefinition) this value belongs to.
        /// </summary>
        [JsonProperty("custom_attribute_definition_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomAttributeDefinitionId { get; }

        /// <summary>
        /// Defines the possible types for a custom attribute.
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; }

        /// <summary>
        /// Populated if `type` = `NUMBER`. Contains a string
        /// representation of a decimal number, using a `.` as the decimal separator.
        /// </summary>
        [JsonProperty("number_value", NullValueHandling = NullValueHandling.Ignore)]
        public string NumberValue { get; }

        /// <summary>
        /// A `true` or `false` value. Populated if `type` = `BOOLEAN`.
        /// </summary>
        [JsonProperty("boolean_value", NullValueHandling = NullValueHandling.Ignore)]
        public bool? BooleanValue { get; }

        /// <summary>
        /// One or more choices from `allowed_selections`. Populated if `type` = `SELECTION`.
        /// </summary>
        [JsonProperty("selection_uid_values", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> SelectionUidValues { get; }

        /// <summary>
        /// __Read-only.__ A copy of key from the associated `CatalogCustomAttributeDefinition`.
        /// </summary>
        [JsonProperty("key", NullValueHandling = NullValueHandling.Ignore)]
        public string Key { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogCustomAttributeValue : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Name = {(Name == null ? "null" : Name == string.Empty ? "" : Name)}");
            toStringOutput.Add($"StringValue = {(StringValue == null ? "null" : StringValue == string.Empty ? "" : StringValue)}");
            toStringOutput.Add($"CustomAttributeDefinitionId = {(CustomAttributeDefinitionId == null ? "null" : CustomAttributeDefinitionId == string.Empty ? "" : CustomAttributeDefinitionId)}");
            toStringOutput.Add($"Type = {(Type == null ? "null" : Type.ToString())}");
            toStringOutput.Add($"NumberValue = {(NumberValue == null ? "null" : NumberValue == string.Empty ? "" : NumberValue)}");
            toStringOutput.Add($"BooleanValue = {(BooleanValue == null ? "null" : BooleanValue.ToString())}");
            toStringOutput.Add($"SelectionUidValues = {(SelectionUidValues == null ? "null" : $"[{ string.Join(", ", SelectionUidValues)} ]")}");
            toStringOutput.Add($"Key = {(Key == null ? "null" : Key == string.Empty ? "" : Key)}");
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

            return obj is CatalogCustomAttributeValue other &&
                ((Name == null && other.Name == null) || (Name?.Equals(other.Name) == true)) &&
                ((StringValue == null && other.StringValue == null) || (StringValue?.Equals(other.StringValue) == true)) &&
                ((CustomAttributeDefinitionId == null && other.CustomAttributeDefinitionId == null) || (CustomAttributeDefinitionId?.Equals(other.CustomAttributeDefinitionId) == true)) &&
                ((Type == null && other.Type == null) || (Type?.Equals(other.Type) == true)) &&
                ((NumberValue == null && other.NumberValue == null) || (NumberValue?.Equals(other.NumberValue) == true)) &&
                ((BooleanValue == null && other.BooleanValue == null) || (BooleanValue?.Equals(other.BooleanValue) == true)) &&
                ((SelectionUidValues == null && other.SelectionUidValues == null) || (SelectionUidValues?.Equals(other.SelectionUidValues) == true)) &&
                ((Key == null && other.Key == null) || (Key?.Equals(other.Key) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 1910658984;

            if (Name != null)
            {
               hashCode += Name.GetHashCode();
            }

            if (StringValue != null)
            {
               hashCode += StringValue.GetHashCode();
            }

            if (CustomAttributeDefinitionId != null)
            {
               hashCode += CustomAttributeDefinitionId.GetHashCode();
            }

            if (Type != null)
            {
               hashCode += Type.GetHashCode();
            }

            if (NumberValue != null)
            {
               hashCode += NumberValue.GetHashCode();
            }

            if (BooleanValue != null)
            {
               hashCode += BooleanValue.GetHashCode();
            }

            if (SelectionUidValues != null)
            {
               hashCode += SelectionUidValues.GetHashCode();
            }

            if (Key != null)
            {
               hashCode += Key.GetHashCode();
            }

            return hashCode;
        }

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
            private IList<string> selectionUidValues;
            private string key;



            public Builder Name(string name)
            {
                this.name = name;
                return this;
            }

            public Builder StringValue(string stringValue)
            {
                this.stringValue = stringValue;
                return this;
            }

            public Builder CustomAttributeDefinitionId(string customAttributeDefinitionId)
            {
                this.customAttributeDefinitionId = customAttributeDefinitionId;
                return this;
            }

            public Builder Type(string type)
            {
                this.type = type;
                return this;
            }

            public Builder NumberValue(string numberValue)
            {
                this.numberValue = numberValue;
                return this;
            }

            public Builder BooleanValue(bool? booleanValue)
            {
                this.booleanValue = booleanValue;
                return this;
            }

            public Builder SelectionUidValues(IList<string> selectionUidValues)
            {
                this.selectionUidValues = selectionUidValues;
                return this;
            }

            public Builder Key(string key)
            {
                this.key = key;
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