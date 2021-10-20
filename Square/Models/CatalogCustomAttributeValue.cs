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
    /// CatalogCustomAttributeValue.
    /// </summary>
    public class CatalogCustomAttributeValue
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogCustomAttributeValue"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="stringValue">string_value.</param>
        /// <param name="customAttributeDefinitionId">custom_attribute_definition_id.</param>
        /// <param name="type">type.</param>
        /// <param name="numberValue">number_value.</param>
        /// <param name="booleanValue">boolean_value.</param>
        /// <param name="selectionUidValues">selection_uid_values.</param>
        /// <param name="key">key.</param>
        public CatalogCustomAttributeValue(
            string name = null,
            string stringValue = null,
            string customAttributeDefinitionId = null,
            string type = null,
            string numberValue = null,
            bool? booleanValue = null,
            IList<string> selectionUidValues = null,
            string key = null)
        {
            this.Name = name;
            this.StringValue = stringValue;
            this.CustomAttributeDefinitionId = customAttributeDefinitionId;
            this.Type = type;
            this.NumberValue = numberValue;
            this.BooleanValue = booleanValue;
            this.SelectionUidValues = selectionUidValues;
            this.Key = key;
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
        /// __Read-only.__ The id of the [CatalogCustomAttributeDefinition]($m/CatalogCustomAttributeDefinition) this value belongs to.
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogCustomAttributeValue : ({string.Join(", ", toStringOutput)})";
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

            return obj is CatalogCustomAttributeValue other &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.StringValue == null && other.StringValue == null) || (this.StringValue?.Equals(other.StringValue) == true)) &&
                ((this.CustomAttributeDefinitionId == null && other.CustomAttributeDefinitionId == null) || (this.CustomAttributeDefinitionId?.Equals(other.CustomAttributeDefinitionId) == true)) &&
                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true)) &&
                ((this.NumberValue == null && other.NumberValue == null) || (this.NumberValue?.Equals(other.NumberValue) == true)) &&
                ((this.BooleanValue == null && other.BooleanValue == null) || (this.BooleanValue?.Equals(other.BooleanValue) == true)) &&
                ((this.SelectionUidValues == null && other.SelectionUidValues == null) || (this.SelectionUidValues?.Equals(other.SelectionUidValues) == true)) &&
                ((this.Key == null && other.Key == null) || (this.Key?.Equals(other.Key) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1910658984;
            hashCode = HashCode.Combine(this.Name, this.StringValue, this.CustomAttributeDefinitionId, this.Type, this.NumberValue, this.BooleanValue, this.SelectionUidValues);

            hashCode = HashCode.Combine(hashCode, this.Key);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name == string.Empty ? "" : this.Name)}");
            toStringOutput.Add($"this.StringValue = {(this.StringValue == null ? "null" : this.StringValue == string.Empty ? "" : this.StringValue)}");
            toStringOutput.Add($"this.CustomAttributeDefinitionId = {(this.CustomAttributeDefinitionId == null ? "null" : this.CustomAttributeDefinitionId == string.Empty ? "" : this.CustomAttributeDefinitionId)}");
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type.ToString())}");
            toStringOutput.Add($"this.NumberValue = {(this.NumberValue == null ? "null" : this.NumberValue == string.Empty ? "" : this.NumberValue)}");
            toStringOutput.Add($"this.BooleanValue = {(this.BooleanValue == null ? "null" : this.BooleanValue.ToString())}");
            toStringOutput.Add($"this.SelectionUidValues = {(this.SelectionUidValues == null ? "null" : $"[{string.Join(", ", this.SelectionUidValues)} ]")}");
            toStringOutput.Add($"this.Key = {(this.Key == null ? "null" : this.Key == string.Empty ? "" : this.Key)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Name(this.Name)
                .StringValue(this.StringValue)
                .CustomAttributeDefinitionId(this.CustomAttributeDefinitionId)
                .Type(this.Type)
                .NumberValue(this.NumberValue)
                .BooleanValue(this.BooleanValue)
                .SelectionUidValues(this.SelectionUidValues)
                .Key(this.Key);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
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
             /// StringValue.
             /// </summary>
             /// <param name="stringValue"> stringValue. </param>
             /// <returns> Builder. </returns>
            public Builder StringValue(string stringValue)
            {
                this.stringValue = stringValue;
                return this;
            }

             /// <summary>
             /// CustomAttributeDefinitionId.
             /// </summary>
             /// <param name="customAttributeDefinitionId"> customAttributeDefinitionId. </param>
             /// <returns> Builder. </returns>
            public Builder CustomAttributeDefinitionId(string customAttributeDefinitionId)
            {
                this.customAttributeDefinitionId = customAttributeDefinitionId;
                return this;
            }

             /// <summary>
             /// Type.
             /// </summary>
             /// <param name="type"> type. </param>
             /// <returns> Builder. </returns>
            public Builder Type(string type)
            {
                this.type = type;
                return this;
            }

             /// <summary>
             /// NumberValue.
             /// </summary>
             /// <param name="numberValue"> numberValue. </param>
             /// <returns> Builder. </returns>
            public Builder NumberValue(string numberValue)
            {
                this.numberValue = numberValue;
                return this;
            }

             /// <summary>
             /// BooleanValue.
             /// </summary>
             /// <param name="booleanValue"> booleanValue. </param>
             /// <returns> Builder. </returns>
            public Builder BooleanValue(bool? booleanValue)
            {
                this.booleanValue = booleanValue;
                return this;
            }

             /// <summary>
             /// SelectionUidValues.
             /// </summary>
             /// <param name="selectionUidValues"> selectionUidValues. </param>
             /// <returns> Builder. </returns>
            public Builder SelectionUidValues(IList<string> selectionUidValues)
            {
                this.selectionUidValues = selectionUidValues;
                return this;
            }

             /// <summary>
             /// Key.
             /// </summary>
             /// <param name="key"> key. </param>
             /// <returns> Builder. </returns>
            public Builder Key(string key)
            {
                this.key = key;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogCustomAttributeValue. </returns>
            public CatalogCustomAttributeValue Build()
            {
                return new CatalogCustomAttributeValue(
                    this.name,
                    this.stringValue,
                    this.customAttributeDefinitionId,
                    this.type,
                    this.numberValue,
                    this.booleanValue,
                    this.selectionUidValues,
                    this.key);
            }
        }
    }
}