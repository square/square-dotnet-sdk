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
    /// CustomAttributeFilter.
    /// </summary>
    public class CustomAttributeFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomAttributeFilter"/> class.
        /// </summary>
        /// <param name="customAttributeDefinitionId">custom_attribute_definition_id.</param>
        /// <param name="key">key.</param>
        /// <param name="stringFilter">string_filter.</param>
        /// <param name="numberFilter">number_filter.</param>
        /// <param name="selectionUidsFilter">selection_uids_filter.</param>
        /// <param name="boolFilter">bool_filter.</param>
        public CustomAttributeFilter(
            string customAttributeDefinitionId = null,
            string key = null,
            string stringFilter = null,
            Models.Range numberFilter = null,
            IList<string> selectionUidsFilter = null,
            bool? boolFilter = null)
        {
            this.CustomAttributeDefinitionId = customAttributeDefinitionId;
            this.Key = key;
            this.StringFilter = stringFilter;
            this.NumberFilter = numberFilter;
            this.SelectionUidsFilter = selectionUidsFilter;
            this.BoolFilter = boolFilter;
        }

        /// <summary>
        /// A query expression to filter items or item variations by matching their custom attributes'
        /// `custom_attribute_definition_id`
        /// property value against the the specified id.
        /// </summary>
        [JsonProperty("custom_attribute_definition_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomAttributeDefinitionId { get; }

        /// <summary>
        /// A query expression to filter items or item variations by matching their custom attributes'
        /// `key` property value against
        /// the specified key.
        /// </summary>
        [JsonProperty("key", NullValueHandling = NullValueHandling.Ignore)]
        public string Key { get; }

        /// <summary>
        /// A query expression to filter items or item variations by matching their custom attributes'
        /// `string_value`  property value
        /// against the specified text.
        /// </summary>
        [JsonProperty("string_filter", NullValueHandling = NullValueHandling.Ignore)]
        public string StringFilter { get; }

        /// <summary>
        /// The range of a number value between the specified lower and upper bounds.
        /// </summary>
        [JsonProperty("number_filter", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Range NumberFilter { get; }

        /// <summary>
        /// A query expression to filter items or item variations by matching  their custom attributes'
        /// `selection_uid_values`
        /// values against the specified selection uids.
        /// </summary>
        [JsonProperty("selection_uids_filter", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> SelectionUidsFilter { get; }

        /// <summary>
        /// A query expression to filter items or item variations by matching their custom attributes'
        /// `boolean_value` property values
        /// against the specified Boolean expression.
        /// </summary>
        [JsonProperty("bool_filter", NullValueHandling = NullValueHandling.Ignore)]
        public bool? BoolFilter { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CustomAttributeFilter : ({string.Join(", ", toStringOutput)})";
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

            return obj is CustomAttributeFilter other &&
                ((this.CustomAttributeDefinitionId == null && other.CustomAttributeDefinitionId == null) || (this.CustomAttributeDefinitionId?.Equals(other.CustomAttributeDefinitionId) == true)) &&
                ((this.Key == null && other.Key == null) || (this.Key?.Equals(other.Key) == true)) &&
                ((this.StringFilter == null && other.StringFilter == null) || (this.StringFilter?.Equals(other.StringFilter) == true)) &&
                ((this.NumberFilter == null && other.NumberFilter == null) || (this.NumberFilter?.Equals(other.NumberFilter) == true)) &&
                ((this.SelectionUidsFilter == null && other.SelectionUidsFilter == null) || (this.SelectionUidsFilter?.Equals(other.SelectionUidsFilter) == true)) &&
                ((this.BoolFilter == null && other.BoolFilter == null) || (this.BoolFilter?.Equals(other.BoolFilter) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1810299489;

            if (this.CustomAttributeDefinitionId != null)
            {
               hashCode += this.CustomAttributeDefinitionId.GetHashCode();
            }

            if (this.Key != null)
            {
               hashCode += this.Key.GetHashCode();
            }

            if (this.StringFilter != null)
            {
               hashCode += this.StringFilter.GetHashCode();
            }

            if (this.NumberFilter != null)
            {
               hashCode += this.NumberFilter.GetHashCode();
            }

            if (this.SelectionUidsFilter != null)
            {
               hashCode += this.SelectionUidsFilter.GetHashCode();
            }

            if (this.BoolFilter != null)
            {
               hashCode += this.BoolFilter.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.CustomAttributeDefinitionId = {(this.CustomAttributeDefinitionId == null ? "null" : this.CustomAttributeDefinitionId == string.Empty ? "" : this.CustomAttributeDefinitionId)}");
            toStringOutput.Add($"this.Key = {(this.Key == null ? "null" : this.Key == string.Empty ? "" : this.Key)}");
            toStringOutput.Add($"this.StringFilter = {(this.StringFilter == null ? "null" : this.StringFilter == string.Empty ? "" : this.StringFilter)}");
            toStringOutput.Add($"this.NumberFilter = {(this.NumberFilter == null ? "null" : this.NumberFilter.ToString())}");
            toStringOutput.Add($"this.SelectionUidsFilter = {(this.SelectionUidsFilter == null ? "null" : $"[{string.Join(", ", this.SelectionUidsFilter)} ]")}");
            toStringOutput.Add($"this.BoolFilter = {(this.BoolFilter == null ? "null" : this.BoolFilter.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .CustomAttributeDefinitionId(this.CustomAttributeDefinitionId)
                .Key(this.Key)
                .StringFilter(this.StringFilter)
                .NumberFilter(this.NumberFilter)
                .SelectionUidsFilter(this.SelectionUidsFilter)
                .BoolFilter(this.BoolFilter);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string customAttributeDefinitionId;
            private string key;
            private string stringFilter;
            private Models.Range numberFilter;
            private IList<string> selectionUidsFilter;
            private bool? boolFilter;

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
             /// StringFilter.
             /// </summary>
             /// <param name="stringFilter"> stringFilter. </param>
             /// <returns> Builder. </returns>
            public Builder StringFilter(string stringFilter)
            {
                this.stringFilter = stringFilter;
                return this;
            }

             /// <summary>
             /// NumberFilter.
             /// </summary>
             /// <param name="numberFilter"> numberFilter. </param>
             /// <returns> Builder. </returns>
            public Builder NumberFilter(Models.Range numberFilter)
            {
                this.numberFilter = numberFilter;
                return this;
            }

             /// <summary>
             /// SelectionUidsFilter.
             /// </summary>
             /// <param name="selectionUidsFilter"> selectionUidsFilter. </param>
             /// <returns> Builder. </returns>
            public Builder SelectionUidsFilter(IList<string> selectionUidsFilter)
            {
                this.selectionUidsFilter = selectionUidsFilter;
                return this;
            }

             /// <summary>
             /// BoolFilter.
             /// </summary>
             /// <param name="boolFilter"> boolFilter. </param>
             /// <returns> Builder. </returns>
            public Builder BoolFilter(bool? boolFilter)
            {
                this.boolFilter = boolFilter;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CustomAttributeFilter. </returns>
            public CustomAttributeFilter Build()
            {
                return new CustomAttributeFilter(
                    this.customAttributeDefinitionId,
                    this.key,
                    this.stringFilter,
                    this.numberFilter,
                    this.selectionUidsFilter,
                    this.boolFilter);
            }
        }
    }
}