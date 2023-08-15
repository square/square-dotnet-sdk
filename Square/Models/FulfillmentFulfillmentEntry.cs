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
    /// FulfillmentFulfillmentEntry.
    /// </summary>
    public class FulfillmentFulfillmentEntry
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="FulfillmentFulfillmentEntry"/> class.
        /// </summary>
        /// <param name="lineItemUid">line_item_uid.</param>
        /// <param name="quantity">quantity.</param>
        /// <param name="uid">uid.</param>
        /// <param name="metadata">metadata.</param>
        public FulfillmentFulfillmentEntry(
            string lineItemUid,
            string quantity,
            string uid = null,
            IDictionary<string, string> metadata = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "uid", false },
                { "metadata", false }
            };

            if (uid != null)
            {
                shouldSerialize["uid"] = true;
                this.Uid = uid;
            }

            this.LineItemUid = lineItemUid;
            this.Quantity = quantity;
            if (metadata != null)
            {
                shouldSerialize["metadata"] = true;
                this.Metadata = metadata;
            }

        }
        internal FulfillmentFulfillmentEntry(Dictionary<string, bool> shouldSerialize,
            string lineItemUid,
            string quantity,
            string uid = null,
            IDictionary<string, string> metadata = null)
        {
            this.shouldSerialize = shouldSerialize;
            Uid = uid;
            LineItemUid = lineItemUid;
            Quantity = quantity;
            Metadata = metadata;
        }

        /// <summary>
        /// A unique ID that identifies the fulfillment entry only within this order.
        /// </summary>
        [JsonProperty("uid")]
        public string Uid { get; }

        /// <summary>
        /// The `uid` from the order line item.
        /// </summary>
        [JsonProperty("line_item_uid")]
        public string LineItemUid { get; }

        /// <summary>
        /// The quantity of the line item being fulfilled, formatted as a decimal number.
        /// For example, `"3"`.
        /// Fulfillments for line items with a `quantity_unit` can have non-integer quantities.
        /// For example, `"1.70000"`.
        /// </summary>
        [JsonProperty("quantity")]
        public string Quantity { get; }

        /// <summary>
        /// Application-defined data attached to this fulfillment entry. Metadata fields are intended
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"FulfillmentFulfillmentEntry : ({string.Join(", ", toStringOutput)})";
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
            return obj is FulfillmentFulfillmentEntry other &&                ((this.Uid == null && other.Uid == null) || (this.Uid?.Equals(other.Uid) == true)) &&
                ((this.LineItemUid == null && other.LineItemUid == null) || (this.LineItemUid?.Equals(other.LineItemUid) == true)) &&
                ((this.Quantity == null && other.Quantity == null) || (this.Quantity?.Equals(other.Quantity) == true)) &&
                ((this.Metadata == null && other.Metadata == null) || (this.Metadata?.Equals(other.Metadata) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 731693737;
            hashCode = HashCode.Combine(this.Uid, this.LineItemUid, this.Quantity, this.Metadata);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Uid = {(this.Uid == null ? "null" : this.Uid)}");
            toStringOutput.Add($"this.LineItemUid = {(this.LineItemUid == null ? "null" : this.LineItemUid)}");
            toStringOutput.Add($"this.Quantity = {(this.Quantity == null ? "null" : this.Quantity)}");
            toStringOutput.Add($"Metadata = {(this.Metadata == null ? "null" : this.Metadata.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.LineItemUid,
                this.Quantity)
                .Uid(this.Uid)
                .Metadata(this.Metadata);
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
                { "metadata", false },
            };

            private string lineItemUid;
            private string quantity;
            private string uid;
            private IDictionary<string, string> metadata;

            public Builder(
                string lineItemUid,
                string quantity)
            {
                this.lineItemUid = lineItemUid;
                this.quantity = quantity;
            }

             /// <summary>
             /// LineItemUid.
             /// </summary>
             /// <param name="lineItemUid"> lineItemUid. </param>
             /// <returns> Builder. </returns>
            public Builder LineItemUid(string lineItemUid)
            {
                this.lineItemUid = lineItemUid;
                return this;
            }

             /// <summary>
             /// Quantity.
             /// </summary>
             /// <param name="quantity"> quantity. </param>
             /// <returns> Builder. </returns>
            public Builder Quantity(string quantity)
            {
                this.quantity = quantity;
                return this;
            }

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
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetUid()
            {
                this.shouldSerialize["uid"] = false;
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
            /// <returns> FulfillmentFulfillmentEntry. </returns>
            public FulfillmentFulfillmentEntry Build()
            {
                return new FulfillmentFulfillmentEntry(shouldSerialize,
                    this.lineItemUid,
                    this.quantity,
                    this.uid,
                    this.metadata);
            }
        }
    }
}