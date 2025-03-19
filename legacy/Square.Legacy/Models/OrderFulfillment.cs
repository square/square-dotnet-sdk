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
    /// OrderFulfillment.
    /// </summary>
    public class OrderFulfillment
    {
        private readonly Dictionary<string, bool> shouldSerialize;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderFulfillment"/> class.
        /// </summary>
        /// <param name="uid">uid.</param>
        /// <param name="type">type.</param>
        /// <param name="state">state.</param>
        /// <param name="lineItemApplication">line_item_application.</param>
        /// <param name="entries">entries.</param>
        /// <param name="metadata">metadata.</param>
        /// <param name="pickupDetails">pickup_details.</param>
        /// <param name="shipmentDetails">shipment_details.</param>
        /// <param name="deliveryDetails">delivery_details.</param>
        public OrderFulfillment(
            string uid = null,
            string type = null,
            string state = null,
            string lineItemApplication = null,
            IList<Models.OrderFulfillmentFulfillmentEntry> entries = null,
            IDictionary<string, string> metadata = null,
            Models.OrderFulfillmentPickupDetails pickupDetails = null,
            Models.OrderFulfillmentShipmentDetails shipmentDetails = null,
            Models.OrderFulfillmentDeliveryDetails deliveryDetails = null
        )
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "uid", false },
                { "metadata", false },
            };

            if (uid != null)
            {
                shouldSerialize["uid"] = true;
                this.Uid = uid;
            }
            this.Type = type;
            this.State = state;
            this.LineItemApplication = lineItemApplication;
            this.Entries = entries;

            if (metadata != null)
            {
                shouldSerialize["metadata"] = true;
                this.Metadata = metadata;
            }
            this.PickupDetails = pickupDetails;
            this.ShipmentDetails = shipmentDetails;
            this.DeliveryDetails = deliveryDetails;
        }

        internal OrderFulfillment(
            Dictionary<string, bool> shouldSerialize,
            string uid = null,
            string type = null,
            string state = null,
            string lineItemApplication = null,
            IList<Models.OrderFulfillmentFulfillmentEntry> entries = null,
            IDictionary<string, string> metadata = null,
            Models.OrderFulfillmentPickupDetails pickupDetails = null,
            Models.OrderFulfillmentShipmentDetails shipmentDetails = null,
            Models.OrderFulfillmentDeliveryDetails deliveryDetails = null
        )
        {
            this.shouldSerialize = shouldSerialize;
            Uid = uid;
            Type = type;
            State = state;
            LineItemApplication = lineItemApplication;
            Entries = entries;
            Metadata = metadata;
            PickupDetails = pickupDetails;
            ShipmentDetails = shipmentDetails;
            DeliveryDetails = deliveryDetails;
        }

        /// <summary>
        /// A unique ID that identifies the fulfillment only within this order.
        /// </summary>
        [JsonProperty("uid")]
        public string Uid { get; }

        /// <summary>
        /// The type of fulfillment.
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; }

        /// <summary>
        /// The current state of this fulfillment.
        /// </summary>
        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public string State { get; }

        /// <summary>
        /// The `line_item_application` describes what order line items this fulfillment applies
        /// to. It can be `ALL` or `ENTRY_LIST` with a supplied list of fulfillment entries.
        /// </summary>
        [JsonProperty("line_item_application", NullValueHandling = NullValueHandling.Ignore)]
        public string LineItemApplication { get; }

        /// <summary>
        /// A list of entries pertaining to the fulfillment of an order. Each entry must reference
        /// a valid `uid` for an order line item in the `line_item_uid` field, as well as a `quantity` to
        /// fulfill.
        /// Multiple entries can reference the same line item `uid`, as long as the total quantity among
        /// all fulfillment entries referencing a single line item does not exceed the quantity of the
        /// order's line item itself.
        /// An order cannot be marked as `COMPLETED` before all fulfillments are `COMPLETED`,
        /// `CANCELED`, or `FAILED`. Fulfillments can be created and completed independently
        /// before order completion.
        /// </summary>
        [JsonProperty("entries", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.OrderFulfillmentFulfillmentEntry> Entries { get; }

        /// <summary>
        /// Application-defined data attached to this fulfillment. Metadata fields are intended
        /// to store descriptive references or associations with an entity in another system or store brief
        /// information about the object. Square does not process this field; it only stores and returns it
        /// in relevant API calls. Do not use metadata to store any sensitive information (such as personally
        /// identifiable information or card details).
        /// Keys written by applications must be 60 characters or less and must be in the character set
        /// `[a-zA-Z0-9_-]`. Entries can also include metadata generated by Square.Legacy. These keys are prefixed
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
        /// Contains details necessary to fulfill a pickup order.
        /// </summary>
        [JsonProperty("pickup_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.OrderFulfillmentPickupDetails PickupDetails { get; }

        /// <summary>
        /// Contains the details necessary to fulfill a shipment order.
        /// </summary>
        [JsonProperty("shipment_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.OrderFulfillmentShipmentDetails ShipmentDetails { get; }

        /// <summary>
        /// Describes delivery details of an order fulfillment.
        /// </summary>
        [JsonProperty("delivery_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.OrderFulfillmentDeliveryDetails DeliveryDetails { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"OrderFulfillment : ({string.Join(", ", toStringOutput)})";
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
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is OrderFulfillment other
                && (this.Uid == null && other.Uid == null || this.Uid?.Equals(other.Uid) == true)
                && (
                    this.Type == null && other.Type == null || this.Type?.Equals(other.Type) == true
                )
                && (
                    this.State == null && other.State == null
                    || this.State?.Equals(other.State) == true
                )
                && (
                    this.LineItemApplication == null && other.LineItemApplication == null
                    || this.LineItemApplication?.Equals(other.LineItemApplication) == true
                )
                && (
                    this.Entries == null && other.Entries == null
                    || this.Entries?.Equals(other.Entries) == true
                )
                && (
                    this.Metadata == null && other.Metadata == null
                    || this.Metadata?.Equals(other.Metadata) == true
                )
                && (
                    this.PickupDetails == null && other.PickupDetails == null
                    || this.PickupDetails?.Equals(other.PickupDetails) == true
                )
                && (
                    this.ShipmentDetails == null && other.ShipmentDetails == null
                    || this.ShipmentDetails?.Equals(other.ShipmentDetails) == true
                )
                && (
                    this.DeliveryDetails == null && other.DeliveryDetails == null
                    || this.DeliveryDetails?.Equals(other.DeliveryDetails) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1224947640;
            hashCode = HashCode.Combine(
                hashCode,
                this.Uid,
                this.Type,
                this.State,
                this.LineItemApplication,
                this.Entries,
                this.Metadata,
                this.PickupDetails
            );

            hashCode = HashCode.Combine(hashCode, this.ShipmentDetails, this.DeliveryDetails);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Uid = {this.Uid ?? "null"}");
            toStringOutput.Add(
                $"this.Type = {(this.Type == null ? "null" : this.Type.ToString())}"
            );
            toStringOutput.Add(
                $"this.State = {(this.State == null ? "null" : this.State.ToString())}"
            );
            toStringOutput.Add(
                $"this.LineItemApplication = {(this.LineItemApplication == null ? "null" : this.LineItemApplication.ToString())}"
            );
            toStringOutput.Add(
                $"this.Entries = {(this.Entries == null ? "null" : $"[{string.Join(", ", this.Entries)} ]")}"
            );
            toStringOutput.Add(
                $"Metadata = {(this.Metadata == null ? "null" : this.Metadata.ToString())}"
            );
            toStringOutput.Add(
                $"this.PickupDetails = {(this.PickupDetails == null ? "null" : this.PickupDetails.ToString())}"
            );
            toStringOutput.Add(
                $"this.ShipmentDetails = {(this.ShipmentDetails == null ? "null" : this.ShipmentDetails.ToString())}"
            );
            toStringOutput.Add(
                $"this.DeliveryDetails = {(this.DeliveryDetails == null ? "null" : this.DeliveryDetails.ToString())}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Uid(this.Uid)
                .Type(this.Type)
                .State(this.State)
                .LineItemApplication(this.LineItemApplication)
                .Entries(this.Entries)
                .Metadata(this.Metadata)
                .PickupDetails(this.PickupDetails)
                .ShipmentDetails(this.ShipmentDetails)
                .DeliveryDetails(this.DeliveryDetails);
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

            private string uid;
            private string type;
            private string state;
            private string lineItemApplication;
            private IList<Models.OrderFulfillmentFulfillmentEntry> entries;
            private IDictionary<string, string> metadata;
            private Models.OrderFulfillmentPickupDetails pickupDetails;
            private Models.OrderFulfillmentShipmentDetails shipmentDetails;
            private Models.OrderFulfillmentDeliveryDetails deliveryDetails;

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
            /// State.
            /// </summary>
            /// <param name="state"> state. </param>
            /// <returns> Builder. </returns>
            public Builder State(string state)
            {
                this.state = state;
                return this;
            }

            /// <summary>
            /// LineItemApplication.
            /// </summary>
            /// <param name="lineItemApplication"> lineItemApplication. </param>
            /// <returns> Builder. </returns>
            public Builder LineItemApplication(string lineItemApplication)
            {
                this.lineItemApplication = lineItemApplication;
                return this;
            }

            /// <summary>
            /// Entries.
            /// </summary>
            /// <param name="entries"> entries. </param>
            /// <returns> Builder. </returns>
            public Builder Entries(IList<Models.OrderFulfillmentFulfillmentEntry> entries)
            {
                this.entries = entries;
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
            /// PickupDetails.
            /// </summary>
            /// <param name="pickupDetails"> pickupDetails. </param>
            /// <returns> Builder. </returns>
            public Builder PickupDetails(Models.OrderFulfillmentPickupDetails pickupDetails)
            {
                this.pickupDetails = pickupDetails;
                return this;
            }

            /// <summary>
            /// ShipmentDetails.
            /// </summary>
            /// <param name="shipmentDetails"> shipmentDetails. </param>
            /// <returns> Builder. </returns>
            public Builder ShipmentDetails(Models.OrderFulfillmentShipmentDetails shipmentDetails)
            {
                this.shipmentDetails = shipmentDetails;
                return this;
            }

            /// <summary>
            /// DeliveryDetails.
            /// </summary>
            /// <param name="deliveryDetails"> deliveryDetails. </param>
            /// <returns> Builder. </returns>
            public Builder DeliveryDetails(Models.OrderFulfillmentDeliveryDetails deliveryDetails)
            {
                this.deliveryDetails = deliveryDetails;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetUid()
            {
                this.shouldSerialize["uid"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetMetadata()
            {
                this.shouldSerialize["metadata"] = false;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> OrderFulfillment. </returns>
            public OrderFulfillment Build()
            {
                return new OrderFulfillment(
                    shouldSerialize,
                    this.uid,
                    this.type,
                    this.state,
                    this.lineItemApplication,
                    this.entries,
                    this.metadata,
                    this.pickupDetails,
                    this.shipmentDetails,
                    this.deliveryDetails
                );
            }
        }
    }
}
