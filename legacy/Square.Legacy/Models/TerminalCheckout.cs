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
    /// TerminalCheckout.
    /// </summary>
    public class TerminalCheckout
    {
        private readonly Dictionary<string, bool> shouldSerialize;

        /// <summary>
        /// Initializes a new instance of the <see cref="TerminalCheckout"/> class.
        /// </summary>
        /// <param name="amountMoney">amount_money.</param>
        /// <param name="deviceOptions">device_options.</param>
        /// <param name="id">id.</param>
        /// <param name="referenceId">reference_id.</param>
        /// <param name="note">note.</param>
        /// <param name="orderId">order_id.</param>
        /// <param name="paymentOptions">payment_options.</param>
        /// <param name="deadlineDuration">deadline_duration.</param>
        /// <param name="status">status.</param>
        /// <param name="cancelReason">cancel_reason.</param>
        /// <param name="paymentIds">payment_ids.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="updatedAt">updated_at.</param>
        /// <param name="appId">app_id.</param>
        /// <param name="locationId">location_id.</param>
        /// <param name="paymentType">payment_type.</param>
        /// <param name="teamMemberId">team_member_id.</param>
        /// <param name="customerId">customer_id.</param>
        /// <param name="appFeeMoney">app_fee_money.</param>
        /// <param name="statementDescriptionIdentifier">statement_description_identifier.</param>
        /// <param name="tipMoney">tip_money.</param>
        public TerminalCheckout(
            Models.Money amountMoney,
            Models.DeviceCheckoutOptions deviceOptions,
            string id = null,
            string referenceId = null,
            string note = null,
            string orderId = null,
            Models.PaymentOptions paymentOptions = null,
            string deadlineDuration = null,
            string status = null,
            string cancelReason = null,
            IList<string> paymentIds = null,
            string createdAt = null,
            string updatedAt = null,
            string appId = null,
            string locationId = null,
            string paymentType = null,
            string teamMemberId = null,
            string customerId = null,
            Models.Money appFeeMoney = null,
            string statementDescriptionIdentifier = null,
            Models.Money tipMoney = null
        )
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "reference_id", false },
                { "note", false },
                { "order_id", false },
                { "deadline_duration", false },
                { "team_member_id", false },
                { "customer_id", false },
                { "statement_description_identifier", false },
            };
            this.Id = id;
            this.AmountMoney = amountMoney;

            if (referenceId != null)
            {
                shouldSerialize["reference_id"] = true;
                this.ReferenceId = referenceId;
            }

            if (note != null)
            {
                shouldSerialize["note"] = true;
                this.Note = note;
            }

            if (orderId != null)
            {
                shouldSerialize["order_id"] = true;
                this.OrderId = orderId;
            }
            this.PaymentOptions = paymentOptions;
            this.DeviceOptions = deviceOptions;

            if (deadlineDuration != null)
            {
                shouldSerialize["deadline_duration"] = true;
                this.DeadlineDuration = deadlineDuration;
            }
            this.Status = status;
            this.CancelReason = cancelReason;
            this.PaymentIds = paymentIds;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
            this.AppId = appId;
            this.LocationId = locationId;
            this.PaymentType = paymentType;

            if (teamMemberId != null)
            {
                shouldSerialize["team_member_id"] = true;
                this.TeamMemberId = teamMemberId;
            }

            if (customerId != null)
            {
                shouldSerialize["customer_id"] = true;
                this.CustomerId = customerId;
            }
            this.AppFeeMoney = appFeeMoney;

            if (statementDescriptionIdentifier != null)
            {
                shouldSerialize["statement_description_identifier"] = true;
                this.StatementDescriptionIdentifier = statementDescriptionIdentifier;
            }
            this.TipMoney = tipMoney;
        }

        internal TerminalCheckout(
            Dictionary<string, bool> shouldSerialize,
            Models.Money amountMoney,
            Models.DeviceCheckoutOptions deviceOptions,
            string id = null,
            string referenceId = null,
            string note = null,
            string orderId = null,
            Models.PaymentOptions paymentOptions = null,
            string deadlineDuration = null,
            string status = null,
            string cancelReason = null,
            IList<string> paymentIds = null,
            string createdAt = null,
            string updatedAt = null,
            string appId = null,
            string locationId = null,
            string paymentType = null,
            string teamMemberId = null,
            string customerId = null,
            Models.Money appFeeMoney = null,
            string statementDescriptionIdentifier = null,
            Models.Money tipMoney = null
        )
        {
            this.shouldSerialize = shouldSerialize;
            Id = id;
            AmountMoney = amountMoney;
            ReferenceId = referenceId;
            Note = note;
            OrderId = orderId;
            PaymentOptions = paymentOptions;
            DeviceOptions = deviceOptions;
            DeadlineDuration = deadlineDuration;
            Status = status;
            CancelReason = cancelReason;
            PaymentIds = paymentIds;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            AppId = appId;
            LocationId = locationId;
            PaymentType = paymentType;
            TeamMemberId = teamMemberId;
            CustomerId = customerId;
            AppFeeMoney = appFeeMoney;
            StatementDescriptionIdentifier = statementDescriptionIdentifier;
            TipMoney = tipMoney;
        }

        /// <summary>
        /// A unique ID for this `TerminalCheckout`.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("amount_money")]
        public Models.Money AmountMoney { get; }

        /// <summary>
        /// An optional user-defined reference ID that can be used to associate
        /// this `TerminalCheckout` to another entity in an external system. For example, an order
        /// ID generated by a third-party shopping cart. The ID is also associated with any payments
        /// used to complete the checkout.
        /// </summary>
        [JsonProperty("reference_id")]
        public string ReferenceId { get; }

        /// <summary>
        /// An optional note to associate with the checkout, as well as with any payments used to complete the checkout.
        /// Note: maximum 500 characters
        /// </summary>
        [JsonProperty("note")]
        public string Note { get; }

        /// <summary>
        /// The reference to the Square order ID for the checkout request. Supported only in the US.
        /// </summary>
        [JsonProperty("order_id")]
        public string OrderId { get; }

        /// <summary>
        /// Gets or sets PaymentOptions.
        /// </summary>
        [JsonProperty("payment_options", NullValueHandling = NullValueHandling.Ignore)]
        public Models.PaymentOptions PaymentOptions { get; }

        /// <summary>
        /// Gets or sets DeviceOptions.
        /// </summary>
        [JsonProperty("device_options")]
        public Models.DeviceCheckoutOptions DeviceOptions { get; }

        /// <summary>
        /// An RFC 3339 duration, after which the checkout is automatically canceled.
        /// A `TerminalCheckout` that is `PENDING` is automatically `CANCELED` and has a cancellation reason
        /// of `TIMED_OUT`.
        /// Default: 5 minutes from creation
        /// Maximum: 5 minutes
        /// </summary>
        [JsonProperty("deadline_duration")]
        public string DeadlineDuration { get; }

        /// <summary>
        /// The status of the `TerminalCheckout`.
        /// Options: `PENDING`, `IN_PROGRESS`, `CANCEL_REQUESTED`, `CANCELED`, `COMPLETED`
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; }

        /// <summary>
        /// Gets or sets CancelReason.
        /// </summary>
        [JsonProperty("cancel_reason", NullValueHandling = NullValueHandling.Ignore)]
        public string CancelReason { get; }

        /// <summary>
        /// A list of IDs for payments created by this `TerminalCheckout`.
        /// </summary>
        [JsonProperty("payment_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> PaymentIds { get; }

        /// <summary>
        /// The time when the `TerminalCheckout` was created, as an RFC 3339 timestamp.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// The time when the `TerminalCheckout` was last updated, as an RFC 3339 timestamp.
        /// </summary>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAt { get; }

        /// <summary>
        /// The ID of the application that created the checkout.
        /// </summary>
        [JsonProperty("app_id", NullValueHandling = NullValueHandling.Ignore)]
        public string AppId { get; }

        /// <summary>
        /// The location of the device where the `TerminalCheckout` was directed.
        /// </summary>
        [JsonProperty("location_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationId { get; }

        /// <summary>
        /// Gets or sets PaymentType.
        /// </summary>
        [JsonProperty("payment_type", NullValueHandling = NullValueHandling.Ignore)]
        public string PaymentType { get; }

        /// <summary>
        /// An optional ID of the team member associated with creating the checkout.
        /// </summary>
        [JsonProperty("team_member_id")]
        public string TeamMemberId { get; }

        /// <summary>
        /// An optional ID of the customer associated with the checkout.
        /// </summary>
        [JsonProperty("customer_id")]
        public string CustomerId { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("app_fee_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money AppFeeMoney { get; }

        /// <summary>
        /// Optional additional payment information to include on the customer's card statement as
        /// part of the statement description. This can be, for example, an invoice number, ticket number,
        /// or short description that uniquely identifies the purchase. Supported only in the US.
        /// </summary>
        [JsonProperty("statement_description_identifier")]
        public string StatementDescriptionIdentifier { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("tip_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money TipMoney { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"TerminalCheckout : ({string.Join(", ", toStringOutput)})";
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
        public bool ShouldSerializeNote()
        {
            return this.shouldSerialize["note"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeOrderId()
        {
            return this.shouldSerialize["order_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDeadlineDuration()
        {
            return this.shouldSerialize["deadline_duration"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTeamMemberId()
        {
            return this.shouldSerialize["team_member_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCustomerId()
        {
            return this.shouldSerialize["customer_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeStatementDescriptionIdentifier()
        {
            return this.shouldSerialize["statement_description_identifier"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is TerminalCheckout other
                && (this.Id == null && other.Id == null || this.Id?.Equals(other.Id) == true)
                && (
                    this.AmountMoney == null && other.AmountMoney == null
                    || this.AmountMoney?.Equals(other.AmountMoney) == true
                )
                && (
                    this.ReferenceId == null && other.ReferenceId == null
                    || this.ReferenceId?.Equals(other.ReferenceId) == true
                )
                && (
                    this.Note == null && other.Note == null || this.Note?.Equals(other.Note) == true
                )
                && (
                    this.OrderId == null && other.OrderId == null
                    || this.OrderId?.Equals(other.OrderId) == true
                )
                && (
                    this.PaymentOptions == null && other.PaymentOptions == null
                    || this.PaymentOptions?.Equals(other.PaymentOptions) == true
                )
                && (
                    this.DeviceOptions == null && other.DeviceOptions == null
                    || this.DeviceOptions?.Equals(other.DeviceOptions) == true
                )
                && (
                    this.DeadlineDuration == null && other.DeadlineDuration == null
                    || this.DeadlineDuration?.Equals(other.DeadlineDuration) == true
                )
                && (
                    this.Status == null && other.Status == null
                    || this.Status?.Equals(other.Status) == true
                )
                && (
                    this.CancelReason == null && other.CancelReason == null
                    || this.CancelReason?.Equals(other.CancelReason) == true
                )
                && (
                    this.PaymentIds == null && other.PaymentIds == null
                    || this.PaymentIds?.Equals(other.PaymentIds) == true
                )
                && (
                    this.CreatedAt == null && other.CreatedAt == null
                    || this.CreatedAt?.Equals(other.CreatedAt) == true
                )
                && (
                    this.UpdatedAt == null && other.UpdatedAt == null
                    || this.UpdatedAt?.Equals(other.UpdatedAt) == true
                )
                && (
                    this.AppId == null && other.AppId == null
                    || this.AppId?.Equals(other.AppId) == true
                )
                && (
                    this.LocationId == null && other.LocationId == null
                    || this.LocationId?.Equals(other.LocationId) == true
                )
                && (
                    this.PaymentType == null && other.PaymentType == null
                    || this.PaymentType?.Equals(other.PaymentType) == true
                )
                && (
                    this.TeamMemberId == null && other.TeamMemberId == null
                    || this.TeamMemberId?.Equals(other.TeamMemberId) == true
                )
                && (
                    this.CustomerId == null && other.CustomerId == null
                    || this.CustomerId?.Equals(other.CustomerId) == true
                )
                && (
                    this.AppFeeMoney == null && other.AppFeeMoney == null
                    || this.AppFeeMoney?.Equals(other.AppFeeMoney) == true
                )
                && (
                    this.StatementDescriptionIdentifier == null
                        && other.StatementDescriptionIdentifier == null
                    || this.StatementDescriptionIdentifier?.Equals(
                        other.StatementDescriptionIdentifier
                    ) == true
                )
                && (
                    this.TipMoney == null && other.TipMoney == null
                    || this.TipMoney?.Equals(other.TipMoney) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -250194258;
            hashCode = HashCode.Combine(
                hashCode,
                this.Id,
                this.AmountMoney,
                this.ReferenceId,
                this.Note,
                this.OrderId,
                this.PaymentOptions,
                this.DeviceOptions
            );

            hashCode = HashCode.Combine(
                hashCode,
                this.DeadlineDuration,
                this.Status,
                this.CancelReason,
                this.PaymentIds,
                this.CreatedAt,
                this.UpdatedAt,
                this.AppId
            );

            hashCode = HashCode.Combine(
                hashCode,
                this.LocationId,
                this.PaymentType,
                this.TeamMemberId,
                this.CustomerId,
                this.AppFeeMoney,
                this.StatementDescriptionIdentifier,
                this.TipMoney
            );

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {this.Id ?? "null"}");
            toStringOutput.Add(
                $"this.AmountMoney = {(this.AmountMoney == null ? "null" : this.AmountMoney.ToString())}"
            );
            toStringOutput.Add($"this.ReferenceId = {this.ReferenceId ?? "null"}");
            toStringOutput.Add($"this.Note = {this.Note ?? "null"}");
            toStringOutput.Add($"this.OrderId = {this.OrderId ?? "null"}");
            toStringOutput.Add(
                $"this.PaymentOptions = {(this.PaymentOptions == null ? "null" : this.PaymentOptions.ToString())}"
            );
            toStringOutput.Add(
                $"this.DeviceOptions = {(this.DeviceOptions == null ? "null" : this.DeviceOptions.ToString())}"
            );
            toStringOutput.Add($"this.DeadlineDuration = {this.DeadlineDuration ?? "null"}");
            toStringOutput.Add($"this.Status = {this.Status ?? "null"}");
            toStringOutput.Add(
                $"this.CancelReason = {(this.CancelReason == null ? "null" : this.CancelReason.ToString())}"
            );
            toStringOutput.Add(
                $"this.PaymentIds = {(this.PaymentIds == null ? "null" : $"[{string.Join(", ", this.PaymentIds)} ]")}"
            );
            toStringOutput.Add($"this.CreatedAt = {this.CreatedAt ?? "null"}");
            toStringOutput.Add($"this.UpdatedAt = {this.UpdatedAt ?? "null"}");
            toStringOutput.Add($"this.AppId = {this.AppId ?? "null"}");
            toStringOutput.Add($"this.LocationId = {this.LocationId ?? "null"}");
            toStringOutput.Add(
                $"this.PaymentType = {(this.PaymentType == null ? "null" : this.PaymentType.ToString())}"
            );
            toStringOutput.Add($"this.TeamMemberId = {this.TeamMemberId ?? "null"}");
            toStringOutput.Add($"this.CustomerId = {this.CustomerId ?? "null"}");
            toStringOutput.Add(
                $"this.AppFeeMoney = {(this.AppFeeMoney == null ? "null" : this.AppFeeMoney.ToString())}"
            );
            toStringOutput.Add(
                $"this.StatementDescriptionIdentifier = {this.StatementDescriptionIdentifier ?? "null"}"
            );
            toStringOutput.Add(
                $"this.TipMoney = {(this.TipMoney == null ? "null" : this.TipMoney.ToString())}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(this.AmountMoney, this.DeviceOptions)
                .Id(this.Id)
                .ReferenceId(this.ReferenceId)
                .Note(this.Note)
                .OrderId(this.OrderId)
                .PaymentOptions(this.PaymentOptions)
                .DeadlineDuration(this.DeadlineDuration)
                .Status(this.Status)
                .CancelReason(this.CancelReason)
                .PaymentIds(this.PaymentIds)
                .CreatedAt(this.CreatedAt)
                .UpdatedAt(this.UpdatedAt)
                .AppId(this.AppId)
                .LocationId(this.LocationId)
                .PaymentType(this.PaymentType)
                .TeamMemberId(this.TeamMemberId)
                .CustomerId(this.CustomerId)
                .AppFeeMoney(this.AppFeeMoney)
                .StatementDescriptionIdentifier(this.StatementDescriptionIdentifier)
                .TipMoney(this.TipMoney);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "reference_id", false },
                { "note", false },
                { "order_id", false },
                { "deadline_duration", false },
                { "team_member_id", false },
                { "customer_id", false },
                { "statement_description_identifier", false },
            };

            private Models.Money amountMoney;
            private Models.DeviceCheckoutOptions deviceOptions;
            private string id;
            private string referenceId;
            private string note;
            private string orderId;
            private Models.PaymentOptions paymentOptions;
            private string deadlineDuration;
            private string status;
            private string cancelReason;
            private IList<string> paymentIds;
            private string createdAt;
            private string updatedAt;
            private string appId;
            private string locationId;
            private string paymentType;
            private string teamMemberId;
            private string customerId;
            private Models.Money appFeeMoney;
            private string statementDescriptionIdentifier;
            private Models.Money tipMoney;

            /// <summary>
            /// Initialize Builder for TerminalCheckout.
            /// </summary>
            /// <param name="amountMoney"> amountMoney. </param>
            /// <param name="deviceOptions"> deviceOptions. </param>
            public Builder(Models.Money amountMoney, Models.DeviceCheckoutOptions deviceOptions)
            {
                this.amountMoney = amountMoney;
                this.deviceOptions = deviceOptions;
            }

            /// <summary>
            /// AmountMoney.
            /// </summary>
            /// <param name="amountMoney"> amountMoney. </param>
            /// <returns> Builder. </returns>
            public Builder AmountMoney(Models.Money amountMoney)
            {
                this.amountMoney = amountMoney;
                return this;
            }

            /// <summary>
            /// DeviceOptions.
            /// </summary>
            /// <param name="deviceOptions"> deviceOptions. </param>
            /// <returns> Builder. </returns>
            public Builder DeviceOptions(Models.DeviceCheckoutOptions deviceOptions)
            {
                this.deviceOptions = deviceOptions;
                return this;
            }

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
            /// Note.
            /// </summary>
            /// <param name="note"> note. </param>
            /// <returns> Builder. </returns>
            public Builder Note(string note)
            {
                shouldSerialize["note"] = true;
                this.note = note;
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
            /// PaymentOptions.
            /// </summary>
            /// <param name="paymentOptions"> paymentOptions. </param>
            /// <returns> Builder. </returns>
            public Builder PaymentOptions(Models.PaymentOptions paymentOptions)
            {
                this.paymentOptions = paymentOptions;
                return this;
            }

            /// <summary>
            /// DeadlineDuration.
            /// </summary>
            /// <param name="deadlineDuration"> deadlineDuration. </param>
            /// <returns> Builder. </returns>
            public Builder DeadlineDuration(string deadlineDuration)
            {
                shouldSerialize["deadline_duration"] = true;
                this.deadlineDuration = deadlineDuration;
                return this;
            }

            /// <summary>
            /// Status.
            /// </summary>
            /// <param name="status"> status. </param>
            /// <returns> Builder. </returns>
            public Builder Status(string status)
            {
                this.status = status;
                return this;
            }

            /// <summary>
            /// CancelReason.
            /// </summary>
            /// <param name="cancelReason"> cancelReason. </param>
            /// <returns> Builder. </returns>
            public Builder CancelReason(string cancelReason)
            {
                this.cancelReason = cancelReason;
                return this;
            }

            /// <summary>
            /// PaymentIds.
            /// </summary>
            /// <param name="paymentIds"> paymentIds. </param>
            /// <returns> Builder. </returns>
            public Builder PaymentIds(IList<string> paymentIds)
            {
                this.paymentIds = paymentIds;
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
            /// UpdatedAt.
            /// </summary>
            /// <param name="updatedAt"> updatedAt. </param>
            /// <returns> Builder. </returns>
            public Builder UpdatedAt(string updatedAt)
            {
                this.updatedAt = updatedAt;
                return this;
            }

            /// <summary>
            /// AppId.
            /// </summary>
            /// <param name="appId"> appId. </param>
            /// <returns> Builder. </returns>
            public Builder AppId(string appId)
            {
                this.appId = appId;
                return this;
            }

            /// <summary>
            /// LocationId.
            /// </summary>
            /// <param name="locationId"> locationId. </param>
            /// <returns> Builder. </returns>
            public Builder LocationId(string locationId)
            {
                this.locationId = locationId;
                return this;
            }

            /// <summary>
            /// PaymentType.
            /// </summary>
            /// <param name="paymentType"> paymentType. </param>
            /// <returns> Builder. </returns>
            public Builder PaymentType(string paymentType)
            {
                this.paymentType = paymentType;
                return this;
            }

            /// <summary>
            /// TeamMemberId.
            /// </summary>
            /// <param name="teamMemberId"> teamMemberId. </param>
            /// <returns> Builder. </returns>
            public Builder TeamMemberId(string teamMemberId)
            {
                shouldSerialize["team_member_id"] = true;
                this.teamMemberId = teamMemberId;
                return this;
            }

            /// <summary>
            /// CustomerId.
            /// </summary>
            /// <param name="customerId"> customerId. </param>
            /// <returns> Builder. </returns>
            public Builder CustomerId(string customerId)
            {
                shouldSerialize["customer_id"] = true;
                this.customerId = customerId;
                return this;
            }

            /// <summary>
            /// AppFeeMoney.
            /// </summary>
            /// <param name="appFeeMoney"> appFeeMoney. </param>
            /// <returns> Builder. </returns>
            public Builder AppFeeMoney(Models.Money appFeeMoney)
            {
                this.appFeeMoney = appFeeMoney;
                return this;
            }

            /// <summary>
            /// StatementDescriptionIdentifier.
            /// </summary>
            /// <param name="statementDescriptionIdentifier"> statementDescriptionIdentifier. </param>
            /// <returns> Builder. </returns>
            public Builder StatementDescriptionIdentifier(string statementDescriptionIdentifier)
            {
                shouldSerialize["statement_description_identifier"] = true;
                this.statementDescriptionIdentifier = statementDescriptionIdentifier;
                return this;
            }

            /// <summary>
            /// TipMoney.
            /// </summary>
            /// <param name="tipMoney"> tipMoney. </param>
            /// <returns> Builder. </returns>
            public Builder TipMoney(Models.Money tipMoney)
            {
                this.tipMoney = tipMoney;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetReferenceId()
            {
                this.shouldSerialize["reference_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetNote()
            {
                this.shouldSerialize["note"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetOrderId()
            {
                this.shouldSerialize["order_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetDeadlineDuration()
            {
                this.shouldSerialize["deadline_duration"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetTeamMemberId()
            {
                this.shouldSerialize["team_member_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetCustomerId()
            {
                this.shouldSerialize["customer_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetStatementDescriptionIdentifier()
            {
                this.shouldSerialize["statement_description_identifier"] = false;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> TerminalCheckout. </returns>
            public TerminalCheckout Build()
            {
                return new TerminalCheckout(
                    shouldSerialize,
                    this.amountMoney,
                    this.deviceOptions,
                    this.id,
                    this.referenceId,
                    this.note,
                    this.orderId,
                    this.paymentOptions,
                    this.deadlineDuration,
                    this.status,
                    this.cancelReason,
                    this.paymentIds,
                    this.createdAt,
                    this.updatedAt,
                    this.appId,
                    this.locationId,
                    this.paymentType,
                    this.teamMemberId,
                    this.customerId,
                    this.appFeeMoney,
                    this.statementDescriptionIdentifier,
                    this.tipMoney
                );
            }
        }
    }
}
