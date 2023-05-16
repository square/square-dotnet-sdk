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
    /// Transaction.
    /// </summary>
    public class Transaction
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="Transaction"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="locationId">location_id.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="tenders">tenders.</param>
        /// <param name="refunds">refunds.</param>
        /// <param name="referenceId">reference_id.</param>
        /// <param name="product">product.</param>
        /// <param name="clientId">client_id.</param>
        /// <param name="shippingAddress">shipping_address.</param>
        /// <param name="orderId">order_id.</param>
        public Transaction(
            string id = null,
            string locationId = null,
            string createdAt = null,
            IList<Models.Tender> tenders = null,
            IList<Models.Refund> refunds = null,
            string referenceId = null,
            string product = null,
            string clientId = null,
            Models.Address shippingAddress = null,
            string orderId = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "location_id", false },
                { "tenders", false },
                { "refunds", false },
                { "reference_id", false },
                { "client_id", false },
                { "order_id", false }
            };

            this.Id = id;
            if (locationId != null)
            {
                shouldSerialize["location_id"] = true;
                this.LocationId = locationId;
            }

            this.CreatedAt = createdAt;
            if (tenders != null)
            {
                shouldSerialize["tenders"] = true;
                this.Tenders = tenders;
            }

            if (refunds != null)
            {
                shouldSerialize["refunds"] = true;
                this.Refunds = refunds;
            }

            if (referenceId != null)
            {
                shouldSerialize["reference_id"] = true;
                this.ReferenceId = referenceId;
            }

            this.Product = product;
            if (clientId != null)
            {
                shouldSerialize["client_id"] = true;
                this.ClientId = clientId;
            }

            this.ShippingAddress = shippingAddress;
            if (orderId != null)
            {
                shouldSerialize["order_id"] = true;
                this.OrderId = orderId;
            }

        }
        internal Transaction(Dictionary<string, bool> shouldSerialize,
            string id = null,
            string locationId = null,
            string createdAt = null,
            IList<Models.Tender> tenders = null,
            IList<Models.Refund> refunds = null,
            string referenceId = null,
            string product = null,
            string clientId = null,
            Models.Address shippingAddress = null,
            string orderId = null)
        {
            this.shouldSerialize = shouldSerialize;
            Id = id;
            LocationId = locationId;
            CreatedAt = createdAt;
            Tenders = tenders;
            Refunds = refunds;
            ReferenceId = referenceId;
            Product = product;
            ClientId = clientId;
            ShippingAddress = shippingAddress;
            OrderId = orderId;
        }

        /// <summary>
        /// The transaction's unique ID, issued by Square payments servers.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The ID of the transaction's associated location.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        /// <summary>
        /// The timestamp for when the transaction was created, in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// The tenders used to pay in the transaction.
        /// </summary>
        [JsonProperty("tenders")]
        public IList<Models.Tender> Tenders { get; }

        /// <summary>
        /// Refunds that have been applied to any tender in the transaction.
        /// </summary>
        [JsonProperty("refunds")]
        public IList<Models.Refund> Refunds { get; }

        /// <summary>
        /// If the transaction was created with the [Charge](api-endpoint:Transactions-Charge)
        /// endpoint, this value is the same as the value provided for the `reference_id`
        /// parameter in the request to that endpoint. Otherwise, it is not set.
        /// </summary>
        [JsonProperty("reference_id")]
        public string ReferenceId { get; }

        /// <summary>
        /// Indicates the Square product used to process a transaction.
        /// </summary>
        [JsonProperty("product", NullValueHandling = NullValueHandling.Ignore)]
        public string Product { get; }

        /// <summary>
        /// If the transaction was created in the Square Point of Sale app, this value
        /// is the ID generated for the transaction by Square Point of Sale.
        /// This ID has no relationship to the transaction's canonical `id`, which is
        /// generated by Square's backend servers. This value is generated for bookkeeping
        /// purposes, in case the transaction cannot immediately be completed (for example,
        /// if the transaction is processed in offline mode).
        /// It is not currently possible with the Connect API to perform a transaction
        /// lookup by this value.
        /// </summary>
        [JsonProperty("client_id")]
        public string ClientId { get; }

        /// <summary>
        /// Represents a postal address in a country.
        /// For more information, see [Working with Addresses](https://developer.squareup.com/docs/build-basics/working-with-addresses).
        /// </summary>
        [JsonProperty("shipping_address", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Address ShippingAddress { get; }

        /// <summary>
        /// The order_id is an identifier for the order associated with this transaction, if any.
        /// </summary>
        [JsonProperty("order_id")]
        public string OrderId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Transaction : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLocationId()
        {
            return this.shouldSerialize["location_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTenders()
        {
            return this.shouldSerialize["tenders"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeRefunds()
        {
            return this.shouldSerialize["refunds"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeReferenceId()
        {
            return this.shouldSerialize["reference_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeClientId()
        {
            return this.shouldSerialize["client_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeOrderId()
        {
            return this.shouldSerialize["order_id"];
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
            return obj is Transaction other &&                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((this.Tenders == null && other.Tenders == null) || (this.Tenders?.Equals(other.Tenders) == true)) &&
                ((this.Refunds == null && other.Refunds == null) || (this.Refunds?.Equals(other.Refunds) == true)) &&
                ((this.ReferenceId == null && other.ReferenceId == null) || (this.ReferenceId?.Equals(other.ReferenceId) == true)) &&
                ((this.Product == null && other.Product == null) || (this.Product?.Equals(other.Product) == true)) &&
                ((this.ClientId == null && other.ClientId == null) || (this.ClientId?.Equals(other.ClientId) == true)) &&
                ((this.ShippingAddress == null && other.ShippingAddress == null) || (this.ShippingAddress?.Equals(other.ShippingAddress) == true)) &&
                ((this.OrderId == null && other.OrderId == null) || (this.OrderId?.Equals(other.OrderId) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 226628405;
            hashCode = HashCode.Combine(this.Id, this.LocationId, this.CreatedAt, this.Tenders, this.Refunds, this.ReferenceId, this.Product);

            hashCode = HashCode.Combine(hashCode, this.ClientId, this.ShippingAddress, this.OrderId);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId == string.Empty ? "" : this.LocationId)}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt == string.Empty ? "" : this.CreatedAt)}");
            toStringOutput.Add($"this.Tenders = {(this.Tenders == null ? "null" : $"[{string.Join(", ", this.Tenders)} ]")}");
            toStringOutput.Add($"this.Refunds = {(this.Refunds == null ? "null" : $"[{string.Join(", ", this.Refunds)} ]")}");
            toStringOutput.Add($"this.ReferenceId = {(this.ReferenceId == null ? "null" : this.ReferenceId == string.Empty ? "" : this.ReferenceId)}");
            toStringOutput.Add($"this.Product = {(this.Product == null ? "null" : this.Product.ToString())}");
            toStringOutput.Add($"this.ClientId = {(this.ClientId == null ? "null" : this.ClientId == string.Empty ? "" : this.ClientId)}");
            toStringOutput.Add($"this.ShippingAddress = {(this.ShippingAddress == null ? "null" : this.ShippingAddress.ToString())}");
            toStringOutput.Add($"this.OrderId = {(this.OrderId == null ? "null" : this.OrderId == string.Empty ? "" : this.OrderId)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(this.Id)
                .LocationId(this.LocationId)
                .CreatedAt(this.CreatedAt)
                .Tenders(this.Tenders)
                .Refunds(this.Refunds)
                .ReferenceId(this.ReferenceId)
                .Product(this.Product)
                .ClientId(this.ClientId)
                .ShippingAddress(this.ShippingAddress)
                .OrderId(this.OrderId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "location_id", false },
                { "tenders", false },
                { "refunds", false },
                { "reference_id", false },
                { "client_id", false },
                { "order_id", false },
            };

            private string id;
            private string locationId;
            private string createdAt;
            private IList<Models.Tender> tenders;
            private IList<Models.Refund> refunds;
            private string referenceId;
            private string product;
            private string clientId;
            private Models.Address shippingAddress;
            private string orderId;

             /// <summary>
             /// Id.
             /// </summary>
             /// <param name="id"> id. </param>
             /// <returns> Builder. </returns>
            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

             /// <summary>
             /// LocationId.
             /// </summary>
             /// <param name="locationId"> locationId. </param>
             /// <returns> Builder. </returns>
            public Builder LocationId(string locationId)
            {
                shouldSerialize["location_id"] = true;
                this.locationId = locationId;
                return this;
            }

             /// <summary>
             /// CreatedAt.
             /// </summary>
             /// <param name="createdAt"> createdAt. </param>
             /// <returns> Builder. </returns>
            public Builder CreatedAt(string createdAt)
            {
                this.createdAt = createdAt;
                return this;
            }

             /// <summary>
             /// Tenders.
             /// </summary>
             /// <param name="tenders"> tenders. </param>
             /// <returns> Builder. </returns>
            public Builder Tenders(IList<Models.Tender> tenders)
            {
                shouldSerialize["tenders"] = true;
                this.tenders = tenders;
                return this;
            }

             /// <summary>
             /// Refunds.
             /// </summary>
             /// <param name="refunds"> refunds. </param>
             /// <returns> Builder. </returns>
            public Builder Refunds(IList<Models.Refund> refunds)
            {
                shouldSerialize["refunds"] = true;
                this.refunds = refunds;
                return this;
            }

             /// <summary>
             /// ReferenceId.
             /// </summary>
             /// <param name="referenceId"> referenceId. </param>
             /// <returns> Builder. </returns>
            public Builder ReferenceId(string referenceId)
            {
                shouldSerialize["reference_id"] = true;
                this.referenceId = referenceId;
                return this;
            }

             /// <summary>
             /// Product.
             /// </summary>
             /// <param name="product"> product. </param>
             /// <returns> Builder. </returns>
            public Builder Product(string product)
            {
                this.product = product;
                return this;
            }

             /// <summary>
             /// ClientId.
             /// </summary>
             /// <param name="clientId"> clientId. </param>
             /// <returns> Builder. </returns>
            public Builder ClientId(string clientId)
            {
                shouldSerialize["client_id"] = true;
                this.clientId = clientId;
                return this;
            }

             /// <summary>
             /// ShippingAddress.
             /// </summary>
             /// <param name="shippingAddress"> shippingAddress. </param>
             /// <returns> Builder. </returns>
            public Builder ShippingAddress(Models.Address shippingAddress)
            {
                this.shippingAddress = shippingAddress;
                return this;
            }

             /// <summary>
             /// OrderId.
             /// </summary>
             /// <param name="orderId"> orderId. </param>
             /// <returns> Builder. </returns>
            public Builder OrderId(string orderId)
            {
                shouldSerialize["order_id"] = true;
                this.orderId = orderId;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetLocationId()
            {
                this.shouldSerialize["location_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetTenders()
            {
                this.shouldSerialize["tenders"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetRefunds()
            {
                this.shouldSerialize["refunds"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetReferenceId()
            {
                this.shouldSerialize["reference_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetClientId()
            {
                this.shouldSerialize["client_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetOrderId()
            {
                this.shouldSerialize["order_id"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> Transaction. </returns>
            public Transaction Build()
            {
                return new Transaction(shouldSerialize,
                    this.id,
                    this.locationId,
                    this.createdAt,
                    this.tenders,
                    this.refunds,
                    this.referenceId,
                    this.product,
                    this.clientId,
                    this.shippingAddress,
                    this.orderId);
            }
        }
    }
}