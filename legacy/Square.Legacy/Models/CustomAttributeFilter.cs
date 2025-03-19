using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIMatic.Core.Utilities.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square.Legacy;
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// CustomAttributeFilter.
    /// </summary>
    public class CustomAttributeFilter
    {
        private readonly Dictionary<string, bool> shouldSerialize;

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
            bool? boolFilter = null
        )
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "custom_attribute_definition_id", false },
                { "key", false },
                { "string_filter", false },
                { "selection_uids_filter", false },
                { "bool_filter", false },
            };

            if (customAttributeDefinitionId != null)
            {
                shouldSerialize["custom_attribute_definition_id"] = true;
                this.CustomAttributeDefinitionId = customAttributeDefinitionId;
            }

            if (key != null)
            {
                shouldSerialize["key"] = true;
                this.Key = key;
            }

            if (stringFilter != null)
            {
                shouldSerialize["string_filter"] = true;
                this.StringFilter = stringFilter;
            }
            this.NumberFilter = numberFilter;

            if (selectionUidsFilter != null)
            {
                shouldSerialize["selection_uids_filter"] = true;
                this.SelectionUidsFilter = selectionUidsFilter;
            }

            if (boolFilter != null)
            {
                shouldSerialize["bool_filter"] = true;
                this.BoolFilter = boolFilter;
            }
        }

        internal CustomAttributeFilter(
            Dictionary<string, bool> shouldSerialize,
            string customAttributeDefinitionId = null,
            string key = null,
            string stringFilter = null,
            Models.Range numberFilter = null,
            IList<string> selectionUidsFilter = null,
            bool? boolFilter = null
        )
        {
            this.shouldSerialize = shouldSerialize;
            CustomAttributeDefinitionId = customAttributeDefinitionId;
            Key = key;
            StringFilter = stringFilter;
            NumberFilter = numberFilter;
            SelectionUidsFilter = selectionUidsFilter;
            BoolFilter = boolFilter;
        }

        /// <summary>
        /// A query expression to filter items or item variations by matching their custom attributes'
        /// `custom_attribute_definition_id` property value against the the specified id.
        /// Exactly one of `custom_attribute_definition_id` or `key` must be specified.
        /// </summary>
        [JsonProperty("custom_attribute_definition_id")]
        public string CustomAttributeDefinitionId { get; }

        /// <summary>
        /// A query expression to filter items or item variations by matching their custom attributes'
        /// `key` property value against the specified key.
        /// Exactly one of `custom_attribute_definition_id` or `key` must be specified.
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; }

        /// <summary>
        /// A query expression to filter items or item variations by matching their custom attributes'
        /// `string_value`  property value against the specified text.
        /// Exactly one of `string_filter`, `number_filter`, `selection_uids_filter`, or `bool_filter` must be specified.
        /// </summary>
        [JsonProperty("string_filter")]
        public string StringFilter { get; }

        /// <summary>
        /// The range of a number value between the specified lower and upper bounds.
        /// </summary>
        [JsonProperty("number_filter", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Range NumberFilter { get; }

        /// <summary>
        /// A query expression to filter items or item variations by matching  their custom attributes'
        /// `selection_uid_values` values against the specified selection uids.
        /// Exactly one of `string_filter`, `number_filter`, `selection_uids_filter`, or `bool_filter` must be specified.
        /// </summary>
        [JsonProperty("selection_uids_filter")]
        public IList<string> SelectionUidsFilter { get; }

        /// <summary>
        /// A query expression to filter items or item variations by matching their custom attributes'
        /// `boolean_value` property values against the specified Boolean expression.
        /// Exactly one of `string_filter`, `number_filter`, `selection_uids_filter`, or `bool_filter` must be specified.
        /// </summary>
        [JsonProperty("bool_filter")]
        public bool? BoolFilter { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"CustomAttributeFilter : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCustomAttributeDefinitionId()
        {
            return this.shouldSerialize["custom_attribute_definition_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeKey()
        {
            return this.shouldSerialize["key"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeStringFilter()
        {
            return this.shouldSerialize["string_filter"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSelectionUidsFilter()
        {
            return this.shouldSerialize["selection_uids_filter"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeBoolFilter()
        {
            return this.shouldSerialize["bool_filter"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is CustomAttributeFilter other
                && (
                    this.CustomAttributeDefinitionId == null
                        && other.CustomAttributeDefinitionId == null
                    || this.CustomAttributeDefinitionId?.Equals(other.CustomAttributeDefinitionId)
                        == true
                )
                && (this.Key == null && other.Key == null || this.Key?.Equals(other.Key) == true)
                && (
                    this.StringFilter == null && other.StringFilter == null
                    || this.StringFilter?.Equals(other.StringFilter) == true
                )
                && (
                    this.NumberFilter == null && other.NumberFilter == null
                    || this.NumberFilter?.Equals(other.NumberFilter) == true
                )
                && (
                    this.SelectionUidsFilter == null && other.SelectionUidsFilter == null
                    || this.SelectionUidsFilter?.Equals(other.SelectionUidsFilter) == true
                )
                && (
                    this.BoolFilter == null && other.BoolFilter == null
                    || this.BoolFilter?.Equals(other.BoolFilter) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 1810299489;
            hashCode = HashCode.Combine(
                hashCode,
                this.CustomAttributeDefinitionId,
                this.Key,
                this.StringFilter,
                this.NumberFilter,
                this.SelectionUidsFilter,
                this.BoolFilter
            );

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add(
                $"this.CustomAttributeDefinitionId = {this.CustomAttributeDefinitionId ?? "null"}"
            );
            toStringOutput.Add($"this.Key = {this.Key ?? "null"}");
            toStringOutput.Add($"this.StringFilter = {this.StringFilter ?? "null"}");
            toStringOutput.Add(
                $"this.NumberFilter = {(this.NumberFilter == null ? "null" : this.NumberFilter.ToString())}"
            );
            toStringOutput.Add(
                $"this.SelectionUidsFilter = {(this.SelectionUidsFilter == null ? "null" : $"[{string.Join(", ", this.SelectionUidsFilter)} ]")}"
            );
            toStringOutput.Add(
                $"this.BoolFilter = {(this.BoolFilter == null ? "null" : this.BoolFilter.ToString())}"
            );
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
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "custom_attribute_definition_id", false },
                { "key", false },
                { "string_filter", false },
                { "selection_uids_filter", false },
                { "bool_filter", false },
            };

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
                shouldSerialize["custom_attribute_definition_id"] = true;
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
                shouldSerialize["key"] = true;
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
                shouldSerialize["string_filter"] = true;
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
                shouldSerialize["selection_uids_filter"] = true;
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
                shouldSerialize["bool_filter"] = true;
                this.boolFilter = boolFilter;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetCustomAttributeDefinitionId()
            {
                this.shouldSerialize["custom_attribute_definition_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetKey()
            {
                this.shouldSerialize["key"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetStringFilter()
            {
                this.shouldSerialize["string_filter"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetSelectionUidsFilter()
            {
                this.shouldSerialize["selection_uids_filter"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetBoolFilter()
            {
                this.shouldSerialize["bool_filter"] = false;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CustomAttributeFilter. </returns>
            public CustomAttributeFilter Build()
            {
                return new CustomAttributeFilter(
                    shouldSerialize,
                    this.customAttributeDefinitionId,
                    this.key,
                    this.stringFilter,
                    this.numberFilter,
                    this.selectionUidsFilter,
                    this.boolFilter
                );
            }
        }
    }
}
