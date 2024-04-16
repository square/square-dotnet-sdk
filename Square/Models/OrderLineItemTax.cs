namespace Square.Models
{
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
    using Square;
    using Square.Utilities;

    /// <summary>
    /// OrderLineItemTax.
    /// </summary>
    public class OrderLineItemTax
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderLineItemTax"/> class.
        /// </summary>
        /// <param name="uid">uid.</param>
        /// <param name="catalogObjectId">catalog_object_id.</param>
        /// <param name="catalogVersion">catalog_version.</param>
        /// <param name="name">name.</param>
        /// <param name="type">type.</param>
        /// <param name="percentage">percentage.</param>
        /// <param name="metadata">metadata.</param>
        /// <param name="appliedMoney">applied_money.</param>
        /// <param name="scope">scope.</param>
        /// <param name="autoApplied">auto_applied.</param>
        public OrderLineItemTax(
            string uid = null,
            string catalogObjectId = null,
            long? catalogVersion = null,
            string name = null,
            string type = null,
            string percentage = null,
            IDictionary<string, string> metadata = null,
            Models.Money appliedMoney = null,
            string scope = null,
            bool? autoApplied = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "uid", false },
                { "catalog_object_id", false },
                { "catalog_version", false },
                { "name", false },
                { "percentage", false },
                { "metadata", false }
            };

            if (uid != null)
            {
                shouldSerialize["uid"] = true;
                this.Uid = uid;
            }

            if (catalogObjectId != null)
            {
                shouldSerialize["catalog_object_id"] = true;
                this.CatalogObjectId = catalogObjectId;
            }

            if (catalogVersion != null)
            {
                shouldSerialize["catalog_version"] = true;
                this.CatalogVersion = catalogVersion;
            }

            if (name != null)
            {
                shouldSerialize["name"] = true;
                this.Name = name;
            }

            this.Type = type;
            if (percentage != null)
            {
                shouldSerialize["percentage"] = true;
                this.Percentage = percentage;
            }

            if (metadata != null)
            {
                shouldSerialize["metadata"] = true;
                this.Metadata = metadata;
            }

            this.AppliedMoney = appliedMoney;
            this.Scope = scope;
            this.AutoApplied = autoApplied;
        }
        internal OrderLineItemTax(Dictionary<string, bool> shouldSerialize,
            string uid = null,
            string catalogObjectId = null,
            long? catalogVersion = null,
            string name = null,
            string type = null,
            string percentage = null,
            IDictionary<string, string> metadata = null,
            Models.Money appliedMoney = null,
            string scope = null,
            bool? autoApplied = null)
        {
            this.shouldSerialize = shouldSerialize;
            Uid = uid;
            CatalogObjectId = catalogObjectId;
            CatalogVersion = catalogVersion;
            Name = name;
            Type = type;
            Percentage = percentage;
            Metadata = metadata;
            AppliedMoney = appliedMoney;
            Scope = scope;
            AutoApplied = autoApplied;
        }

        /// <summary>
        /// A unique ID that identifies the tax only within this order.
        /// </summary>
        [JsonProperty("uid")]
        public string Uid { get; }

        /// <summary>
        /// The catalog object ID referencing [CatalogTax](entity:CatalogTax).
        /// </summary>
        [JsonProperty("catalog_object_id")]
        public string CatalogObjectId { get; }

        /// <summary>
        /// The version of the catalog object that this tax references.
        /// </summary>
        [JsonProperty("catalog_version")]
        public long? CatalogVersion { get; }

        /// <summary>
        /// The tax's name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// Indicates how the tax is applied to the associated line item or order.
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; }

        /// <summary>
        /// The percentage of the tax, as a string representation of a decimal
        /// number. For example, a value of `"7.25"` corresponds to a percentage of
        /// 7.25%.
        /// </summary>
        [JsonProperty("percentage")]
        public string Percentage { get; }

        /// <summary>
        /// Application-defined data attached to this tax. Metadata fields are intended
        /// to store descriptive references or associations with an entity in another system or store brief
        /// information about the object. Square does not process this field; it only stores and returns it
        /// in relevant API calls. Do not use metadata to store any sensitive information (such as personally
        /// identifiable information or card details).
        /// Keys written by applications must be 60 characters or less and must be in the character set
        /// `[a-zA-Z0-9_-]`. Entries can also include metadata generated by Square. These keys are prefixed
        /// with a namespace, separated from the key with a ':' character.
        /// Values have a maximum length of 255 characters.
        /// An application can have up to 10 entries per metadata field.
        /// Entries written by applications are private and can only be read or modified by the same
        /// application.
        /// For more information, see [Metadata](https://developer.squareup.com/docs/build-basics/metadata).
        /// </summary>
        [JsonProperty("metadata")]
        public IDictionary<string, string> Metadata { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("applied_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money AppliedMoney { get; }

        /// <summary>
        /// Indicates whether this is a line-item or order-level tax.
        /// </summary>
        [JsonProperty("scope", NullValueHandling = NullValueHandling.Ignore)]
        public string Scope { get; }

        /// <summary>
        /// Determines whether the tax was automatically applied to the order based on
        /// the catalog configuration. For an example, see
        /// [Automatically Apply Taxes to an Order](https://developer.squareup.com/docs/orders-api/apply-taxes-and-discounts/auto-apply-taxes).
        /// </summary>
        [JsonProperty("auto_applied", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AutoApplied { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"OrderLineItemTax : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeUid()
        {
            return this.shouldSerialize["uid"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCatalogObjectId()
        {
            return this.shouldSerialize["catalog_object_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCatalogVersion()
        {
            return this.shouldSerialize["catalog_version"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeName()
        {
            return this.shouldSerialize["name"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePercentage()
        {
            return this.shouldSerialize["percentage"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeMetadata()
        {
            return this.shouldSerialize["metadata"];
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
            return obj is OrderLineItemTax other &&                ((this.Uid == null && other.Uid == null) || (this.Uid?.Equals(other.Uid) == true)) &&
                ((this.CatalogObjectId == null && other.CatalogObjectId == null) || (this.CatalogObjectId?.Equals(other.CatalogObjectId) == true)) &&
                ((this.CatalogVersion == null && other.CatalogVersion == null) || (this.CatalogVersion?.Equals(other.CatalogVersion) == true)) &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true)) &&
                ((this.Percentage == null && other.Percentage == null) || (this.Percentage?.Equals(other.Percentage) == true)) &&
                ((this.Metadata == null && other.Metadata == null) || (this.Metadata?.Equals(other.Metadata) == true)) &&
                ((this.AppliedMoney == null && other.AppliedMoney == null) || (this.AppliedMoney?.Equals(other.AppliedMoney) == true)) &&
                ((this.Scope == null && other.Scope == null) || (this.Scope?.Equals(other.Scope) == true)) &&
                ((this.AutoApplied == null && other.AutoApplied == null) || (this.AutoApplied?.Equals(other.AutoApplied) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 670391105;
            hashCode = HashCode.Combine(this.Uid, this.CatalogObjectId, this.CatalogVersion, this.Name, this.Type, this.Percentage, this.Metadata);

            hashCode = HashCode.Combine(hashCode, this.AppliedMoney, this.Scope, this.AutoApplied);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Uid = {(this.Uid == null ? "null" : this.Uid)}");
            toStringOutput.Add($"this.CatalogObjectId = {(this.CatalogObjectId == null ? "null" : this.CatalogObjectId)}");
            toStringOutput.Add($"this.CatalogVersion = {(this.CatalogVersion == null ? "null" : this.CatalogVersion.ToString())}");
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name)}");
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type.ToString())}");
            toStringOutput.Add($"this.Percentage = {(this.Percentage == null ? "null" : this.Percentage)}");
            toStringOutput.Add($"Metadata = {(this.Metadata == null ? "null" : this.Metadata.ToString())}");
            toStringOutput.Add($"this.AppliedMoney = {(this.AppliedMoney == null ? "null" : this.AppliedMoney.ToString())}");
            toStringOutput.Add($"this.Scope = {(this.Scope == null ? "null" : this.Scope.ToString())}");
            toStringOutput.Add($"this.AutoApplied = {(this.AutoApplied == null ? "null" : this.AutoApplied.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Uid(this.Uid)
                .CatalogObjectId(this.CatalogObjectId)
                .CatalogVersion(this.CatalogVersion)
                .Name(this.Name)
                .Type(this.Type)
                .Percentage(this.Percentage)
                .Metadata(this.Metadata)
                .AppliedMoney(this.AppliedMoney)
                .Scope(this.Scope)
                .AutoApplied(this.AutoApplied);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "uid", false },
                { "catalog_object_id", false },
                { "catalog_version", false },
                { "name", false },
                { "percentage", false },
                { "metadata", false },
            };

            private string uid;
            private string catalogObjectId;
            private long? catalogVersion;
            private string name;
            private string type;
            private string percentage;
            private IDictionary<string, string> metadata;
            private Models.Money appliedMoney;
            private string scope;
            private bool? autoApplied;

             /// <summary>
             /// Uid.
             /// </summary>
             /// <param name="uid"> uid. </param>
             /// <returns> Builder. </returns>
            public Builder Uid(string uid)
            {
                shouldSerialize["uid"] = true;
                this.uid = uid;
                return this;
            }

             /// <summary>
             /// CatalogObjectId.
             /// </summary>
             /// <param name="catalogObjectId"> catalogObjectId. </param>
             /// <returns> Builder. </returns>
            public Builder CatalogObjectId(string catalogObjectId)
            {
                shouldSerialize["catalog_object_id"] = true;
                this.catalogObjectId = catalogObjectId;
                return this;
            }

             /// <summary>
             /// CatalogVersion.
             /// </summary>
             /// <param name="catalogVersion"> catalogVersion. </param>
             /// <returns> Builder. </returns>
            public Builder CatalogVersion(long? catalogVersion)
            {
                shouldSerialize["catalog_version"] = true;
                this.catalogVersion = catalogVersion;
                return this;
            }

             /// <summary>
             /// Name.
             /// </summary>
             /// <param name="name"> name. </param>
             /// <returns> Builder. </returns>
            public Builder Name(string name)
            {
                shouldSerialize["name"] = true;
                this.name = name;
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
             /// Percentage.
             /// </summary>
             /// <param name="percentage"> percentage. </param>
             /// <returns> Builder. </returns>
            public Builder Percentage(string percentage)
            {
                shouldSerialize["percentage"] = true;
                this.percentage = percentage;
                return this;
            }

             /// <summary>
             /// Metadata.
             /// </summary>
             /// <param name="metadata"> metadata. </param>
             /// <returns> Builder. </returns>
            public Builder Metadata(IDictionary<string, string> metadata)
            {
                shouldSerialize["metadata"] = true;
                this.metadata = metadata;
                return this;
            }

             /// <summary>
             /// AppliedMoney.
             /// </summary>
             /// <param name="appliedMoney"> appliedMoney. </param>
             /// <returns> Builder. </returns>
            public Builder AppliedMoney(Models.Money appliedMoney)
            {
                this.appliedMoney = appliedMoney;
                return this;
            }

             /// <summary>
             /// Scope.
             /// </summary>
             /// <param name="scope"> scope. </param>
             /// <returns> Builder. </returns>
            public Builder Scope(string scope)
            {
                this.scope = scope;
                return this;
            }

             /// <summary>
             /// AutoApplied.
             /// </summary>
             /// <param name="autoApplied"> autoApplied. </param>
             /// <returns> Builder. </returns>
            public Builder AutoApplied(bool? autoApplied)
            {
                this.autoApplied = autoApplied;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetUid()
            {
                this.shouldSerialize["uid"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCatalogObjectId()
            {
                this.shouldSerialize["catalog_object_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCatalogVersion()
            {
                this.shouldSerialize["catalog_version"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetName()
            {
                this.shouldSerialize["name"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetPercentage()
            {
                this.shouldSerialize["percentage"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetMetadata()
            {
                this.shouldSerialize["metadata"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> OrderLineItemTax. </returns>
            public OrderLineItemTax Build()
            {
                return new OrderLineItemTax(shouldSerialize,
                    this.uid,
                    this.catalogObjectId,
                    this.catalogVersion,
                    this.name,
                    this.type,
                    this.percentage,
                    this.metadata,
                    this.appliedMoney,
                    this.scope,
                    this.autoApplied);
            }
        }
    }
}