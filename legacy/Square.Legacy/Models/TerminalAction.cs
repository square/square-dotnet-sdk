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
    /// TerminalAction.
    /// </summary>
    public class TerminalAction
    {
        private readonly Dictionary<string, bool> shouldSerialize;

        /// <summary>
        /// Initializes a new instance of the <see cref="TerminalAction"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="deviceId">device_id.</param>
        /// <param name="deadlineDuration">deadline_duration.</param>
        /// <param name="status">status.</param>
        /// <param name="cancelReason">cancel_reason.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="updatedAt">updated_at.</param>
        /// <param name="appId">app_id.</param>
        /// <param name="locationId">location_id.</param>
        /// <param name="type">type.</param>
        /// <param name="qrCodeOptions">qr_code_options.</param>
        /// <param name="saveCardOptions">save_card_options.</param>
        /// <param name="signatureOptions">signature_options.</param>
        /// <param name="confirmationOptions">confirmation_options.</param>
        /// <param name="receiptOptions">receipt_options.</param>
        /// <param name="dataCollectionOptions">data_collection_options.</param>
        /// <param name="selectOptions">select_options.</param>
        /// <param name="deviceMetadata">device_metadata.</param>
        /// <param name="awaitNextAction">await_next_action.</param>
        /// <param name="awaitNextActionDuration">await_next_action_duration.</param>
        public TerminalAction(
            string id = null,
            string deviceId = null,
            string deadlineDuration = null,
            string status = null,
            string cancelReason = null,
            string createdAt = null,
            string updatedAt = null,
            string appId = null,
            string locationId = null,
            string type = null,
            Models.QrCodeOptions qrCodeOptions = null,
            Models.SaveCardOptions saveCardOptions = null,
            Models.SignatureOptions signatureOptions = null,
            Models.ConfirmationOptions confirmationOptions = null,
            Models.ReceiptOptions receiptOptions = null,
            Models.DataCollectionOptions dataCollectionOptions = null,
            Models.SelectOptions selectOptions = null,
            Models.DeviceMetadata deviceMetadata = null,
            bool? awaitNextAction = null,
            string awaitNextActionDuration = null
        )
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "device_id", false },
                { "deadline_duration", false },
                { "await_next_action", false },
                { "await_next_action_duration", false },
            };
            this.Id = id;

            if (deviceId != null)
            {
                shouldSerialize["device_id"] = true;
                this.DeviceId = deviceId;
            }

            if (deadlineDuration != null)
            {
                shouldSerialize["deadline_duration"] = true;
                this.DeadlineDuration = deadlineDuration;
            }
            this.Status = status;
            this.CancelReason = cancelReason;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
            this.AppId = appId;
            this.LocationId = locationId;
            this.Type = type;
            this.QrCodeOptions = qrCodeOptions;
            this.SaveCardOptions = saveCardOptions;
            this.SignatureOptions = signatureOptions;
            this.ConfirmationOptions = confirmationOptions;
            this.ReceiptOptions = receiptOptions;
            this.DataCollectionOptions = dataCollectionOptions;
            this.SelectOptions = selectOptions;
            this.DeviceMetadata = deviceMetadata;

            if (awaitNextAction != null)
            {
                shouldSerialize["await_next_action"] = true;
                this.AwaitNextAction = awaitNextAction;
            }

            if (awaitNextActionDuration != null)
            {
                shouldSerialize["await_next_action_duration"] = true;
                this.AwaitNextActionDuration = awaitNextActionDuration;
            }
        }

        internal TerminalAction(
            Dictionary<string, bool> shouldSerialize,
            string id = null,
            string deviceId = null,
            string deadlineDuration = null,
            string status = null,
            string cancelReason = null,
            string createdAt = null,
            string updatedAt = null,
            string appId = null,
            string locationId = null,
            string type = null,
            Models.QrCodeOptions qrCodeOptions = null,
            Models.SaveCardOptions saveCardOptions = null,
            Models.SignatureOptions signatureOptions = null,
            Models.ConfirmationOptions confirmationOptions = null,
            Models.ReceiptOptions receiptOptions = null,
            Models.DataCollectionOptions dataCollectionOptions = null,
            Models.SelectOptions selectOptions = null,
            Models.DeviceMetadata deviceMetadata = null,
            bool? awaitNextAction = null,
            string awaitNextActionDuration = null
        )
        {
            this.shouldSerialize = shouldSerialize;
            Id = id;
            DeviceId = deviceId;
            DeadlineDuration = deadlineDuration;
            Status = status;
            CancelReason = cancelReason;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            AppId = appId;
            LocationId = locationId;
            Type = type;
            QrCodeOptions = qrCodeOptions;
            SaveCardOptions = saveCardOptions;
            SignatureOptions = signatureOptions;
            ConfirmationOptions = confirmationOptions;
            ReceiptOptions = receiptOptions;
            DataCollectionOptions = dataCollectionOptions;
            SelectOptions = selectOptions;
            DeviceMetadata = deviceMetadata;
            AwaitNextAction = awaitNextAction;
            AwaitNextActionDuration = awaitNextActionDuration;
        }

        /// <summary>
        /// A unique ID for this `TerminalAction`.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The unique Id of the device intended for this `TerminalAction`.
        /// The Id can be retrieved from /v2/devices api.
        /// </summary>
        [JsonProperty("device_id")]
        public string DeviceId { get; }

        /// <summary>
        /// The duration as an RFC 3339 duration, after which the action will be automatically canceled.
        /// TerminalActions that are `PENDING` will be automatically `CANCELED` and have a cancellation reason
        /// of `TIMED_OUT`
        /// Default: 5 minutes from creation
        /// Maximum: 5 minutes
        /// </summary>
        [JsonProperty("deadline_duration")]
        public string DeadlineDuration { get; }

        /// <summary>
        /// The status of the `TerminalAction`.
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
        /// The time when the `TerminalAction` was created as an RFC 3339 timestamp.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// The time when the `TerminalAction` was last updated as an RFC 3339 timestamp.
        /// </summary>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAt { get; }

        /// <summary>
        /// The ID of the application that created the action.
        /// </summary>
        [JsonProperty("app_id", NullValueHandling = NullValueHandling.Ignore)]
        public string AppId { get; }

        /// <summary>
        /// The location id the action is attached to, if a link can be made.
        /// </summary>
        [JsonProperty("location_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationId { get; }

        /// <summary>
        /// Describes the type of this unit and indicates which field contains the unit information. This is an ‘open’ enum.
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; }

        /// <summary>
        /// Fields to describe the action that displays QR-Codes.
        /// </summary>
        [JsonProperty("qr_code_options", NullValueHandling = NullValueHandling.Ignore)]
        public Models.QrCodeOptions QrCodeOptions { get; }

        /// <summary>
        /// Describes save-card action fields.
        /// </summary>
        [JsonProperty("save_card_options", NullValueHandling = NullValueHandling.Ignore)]
        public Models.SaveCardOptions SaveCardOptions { get; }

        /// <summary>
        /// Gets or sets SignatureOptions.
        /// </summary>
        [JsonProperty("signature_options", NullValueHandling = NullValueHandling.Ignore)]
        public Models.SignatureOptions SignatureOptions { get; }

        /// <summary>
        /// Gets or sets ConfirmationOptions.
        /// </summary>
        [JsonProperty("confirmation_options", NullValueHandling = NullValueHandling.Ignore)]
        public Models.ConfirmationOptions ConfirmationOptions { get; }

        /// <summary>
        /// Describes receipt action fields.
        /// </summary>
        [JsonProperty("receipt_options", NullValueHandling = NullValueHandling.Ignore)]
        public Models.ReceiptOptions ReceiptOptions { get; }

        /// <summary>
        /// Gets or sets DataCollectionOptions.
        /// </summary>
        [JsonProperty("data_collection_options", NullValueHandling = NullValueHandling.Ignore)]
        public Models.DataCollectionOptions DataCollectionOptions { get; }

        /// <summary>
        /// Gets or sets SelectOptions.
        /// </summary>
        [JsonProperty("select_options", NullValueHandling = NullValueHandling.Ignore)]
        public Models.SelectOptions SelectOptions { get; }

        /// <summary>
        /// Gets or sets DeviceMetadata.
        /// </summary>
        [JsonProperty("device_metadata", NullValueHandling = NullValueHandling.Ignore)]
        public Models.DeviceMetadata DeviceMetadata { get; }

        /// <summary>
        /// Indicates the action will be linked to another action and requires a waiting dialog to be
        /// displayed instead of returning to the idle screen on completion of the action.
        /// Only supported on SIGNATURE, CONFIRMATION, DATA_COLLECTION, and SELECT types.
        /// </summary>
        [JsonProperty("await_next_action")]
        public bool? AwaitNextAction { get; }

        /// <summary>
        /// The timeout duration of the waiting dialog as an RFC 3339 duration, after which the
        /// waiting dialog will no longer be displayed and the Terminal will return to the idle screen.
        /// Default: 5 minutes from when the waiting dialog is displayed
        /// Maximum: 5 minutes
        /// </summary>
        [JsonProperty("await_next_action_duration")]
        public string AwaitNextActionDuration { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"TerminalAction : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDeviceId()
        {
            return this.shouldSerialize["device_id"];
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
        public bool ShouldSerializeAwaitNextAction()
        {
            return this.shouldSerialize["await_next_action"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAwaitNextActionDuration()
        {
            return this.shouldSerialize["await_next_action_duration"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is TerminalAction other
                && (this.Id == null && other.Id == null || this.Id?.Equals(other.Id) == true)
                && (
                    this.DeviceId == null && other.DeviceId == null
                    || this.DeviceId?.Equals(other.DeviceId) == true
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
                    this.Type == null && other.Type == null || this.Type?.Equals(other.Type) == true
                )
                && (
                    this.QrCodeOptions == null && other.QrCodeOptions == null
                    || this.QrCodeOptions?.Equals(other.QrCodeOptions) == true
                )
                && (
                    this.SaveCardOptions == null && other.SaveCardOptions == null
                    || this.SaveCardOptions?.Equals(other.SaveCardOptions) == true
                )
                && (
                    this.SignatureOptions == null && other.SignatureOptions == null
                    || this.SignatureOptions?.Equals(other.SignatureOptions) == true
                )
                && (
                    this.ConfirmationOptions == null && other.ConfirmationOptions == null
                    || this.ConfirmationOptions?.Equals(other.ConfirmationOptions) == true
                )
                && (
                    this.ReceiptOptions == null && other.ReceiptOptions == null
                    || this.ReceiptOptions?.Equals(other.ReceiptOptions) == true
                )
                && (
                    this.DataCollectionOptions == null && other.DataCollectionOptions == null
                    || this.DataCollectionOptions?.Equals(other.DataCollectionOptions) == true
                )
                && (
                    this.SelectOptions == null && other.SelectOptions == null
                    || this.SelectOptions?.Equals(other.SelectOptions) == true
                )
                && (
                    this.DeviceMetadata == null && other.DeviceMetadata == null
                    || this.DeviceMetadata?.Equals(other.DeviceMetadata) == true
                )
                && (
                    this.AwaitNextAction == null && other.AwaitNextAction == null
                    || this.AwaitNextAction?.Equals(other.AwaitNextAction) == true
                )
                && (
                    this.AwaitNextActionDuration == null && other.AwaitNextActionDuration == null
                    || this.AwaitNextActionDuration?.Equals(other.AwaitNextActionDuration) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 820116250;
            hashCode = HashCode.Combine(
                hashCode,
                this.Id,
                this.DeviceId,
                this.DeadlineDuration,
                this.Status,
                this.CancelReason,
                this.CreatedAt,
                this.UpdatedAt
            );

            hashCode = HashCode.Combine(
                hashCode,
                this.AppId,
                this.LocationId,
                this.Type,
                this.QrCodeOptions,
                this.SaveCardOptions,
                this.SignatureOptions,
                this.ConfirmationOptions
            );

            hashCode = HashCode.Combine(
                hashCode,
                this.ReceiptOptions,
                this.DataCollectionOptions,
                this.SelectOptions,
                this.DeviceMetadata,
                this.AwaitNextAction,
                this.AwaitNextActionDuration
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
            toStringOutput.Add($"this.DeviceId = {this.DeviceId ?? "null"}");
            toStringOutput.Add($"this.DeadlineDuration = {this.DeadlineDuration ?? "null"}");
            toStringOutput.Add($"this.Status = {this.Status ?? "null"}");
            toStringOutput.Add(
                $"this.CancelReason = {(this.CancelReason == null ? "null" : this.CancelReason.ToString())}"
            );
            toStringOutput.Add($"this.CreatedAt = {this.CreatedAt ?? "null"}");
            toStringOutput.Add($"this.UpdatedAt = {this.UpdatedAt ?? "null"}");
            toStringOutput.Add($"this.AppId = {this.AppId ?? "null"}");
            toStringOutput.Add($"this.LocationId = {this.LocationId ?? "null"}");
            toStringOutput.Add(
                $"this.Type = {(this.Type == null ? "null" : this.Type.ToString())}"
            );
            toStringOutput.Add(
                $"this.QrCodeOptions = {(this.QrCodeOptions == null ? "null" : this.QrCodeOptions.ToString())}"
            );
            toStringOutput.Add(
                $"this.SaveCardOptions = {(this.SaveCardOptions == null ? "null" : this.SaveCardOptions.ToString())}"
            );
            toStringOutput.Add(
                $"this.SignatureOptions = {(this.SignatureOptions == null ? "null" : this.SignatureOptions.ToString())}"
            );
            toStringOutput.Add(
                $"this.ConfirmationOptions = {(this.ConfirmationOptions == null ? "null" : this.ConfirmationOptions.ToString())}"
            );
            toStringOutput.Add(
                $"this.ReceiptOptions = {(this.ReceiptOptions == null ? "null" : this.ReceiptOptions.ToString())}"
            );
            toStringOutput.Add(
                $"this.DataCollectionOptions = {(this.DataCollectionOptions == null ? "null" : this.DataCollectionOptions.ToString())}"
            );
            toStringOutput.Add(
                $"this.SelectOptions = {(this.SelectOptions == null ? "null" : this.SelectOptions.ToString())}"
            );
            toStringOutput.Add(
                $"this.DeviceMetadata = {(this.DeviceMetadata == null ? "null" : this.DeviceMetadata.ToString())}"
            );
            toStringOutput.Add(
                $"this.AwaitNextAction = {(this.AwaitNextAction == null ? "null" : this.AwaitNextAction.ToString())}"
            );
            toStringOutput.Add(
                $"this.AwaitNextActionDuration = {this.AwaitNextActionDuration ?? "null"}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(this.Id)
                .DeviceId(this.DeviceId)
                .DeadlineDuration(this.DeadlineDuration)
                .Status(this.Status)
                .CancelReason(this.CancelReason)
                .CreatedAt(this.CreatedAt)
                .UpdatedAt(this.UpdatedAt)
                .AppId(this.AppId)
                .LocationId(this.LocationId)
                .Type(this.Type)
                .QrCodeOptions(this.QrCodeOptions)
                .SaveCardOptions(this.SaveCardOptions)
                .SignatureOptions(this.SignatureOptions)
                .ConfirmationOptions(this.ConfirmationOptions)
                .ReceiptOptions(this.ReceiptOptions)
                .DataCollectionOptions(this.DataCollectionOptions)
                .SelectOptions(this.SelectOptions)
                .DeviceMetadata(this.DeviceMetadata)
                .AwaitNextAction(this.AwaitNextAction)
                .AwaitNextActionDuration(this.AwaitNextActionDuration);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "device_id", false },
                { "deadline_duration", false },
                { "await_next_action", false },
                { "await_next_action_duration", false },
            };

            private string id;
            private string deviceId;
            private string deadlineDuration;
            private string status;
            private string cancelReason;
            private string createdAt;
            private string updatedAt;
            private string appId;
            private string locationId;
            private string type;
            private Models.QrCodeOptions qrCodeOptions;
            private Models.SaveCardOptions saveCardOptions;
            private Models.SignatureOptions signatureOptions;
            private Models.ConfirmationOptions confirmationOptions;
            private Models.ReceiptOptions receiptOptions;
            private Models.DataCollectionOptions dataCollectionOptions;
            private Models.SelectOptions selectOptions;
            private Models.DeviceMetadata deviceMetadata;
            private bool? awaitNextAction;
            private string awaitNextActionDuration;

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
            /// DeviceId.
            /// </summary>
            /// <param name="deviceId"> deviceId. </param>
            /// <returns> Builder. </returns>
            public Builder DeviceId(string deviceId)
            {
                shouldSerialize["device_id"] = true;
                this.deviceId = deviceId;
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
            /// QrCodeOptions.
            /// </summary>
            /// <param name="qrCodeOptions"> qrCodeOptions. </param>
            /// <returns> Builder. </returns>
            public Builder QrCodeOptions(Models.QrCodeOptions qrCodeOptions)
            {
                this.qrCodeOptions = qrCodeOptions;
                return this;
            }

            /// <summary>
            /// SaveCardOptions.
            /// </summary>
            /// <param name="saveCardOptions"> saveCardOptions. </param>
            /// <returns> Builder. </returns>
            public Builder SaveCardOptions(Models.SaveCardOptions saveCardOptions)
            {
                this.saveCardOptions = saveCardOptions;
                return this;
            }

            /// <summary>
            /// SignatureOptions.
            /// </summary>
            /// <param name="signatureOptions"> signatureOptions. </param>
            /// <returns> Builder. </returns>
            public Builder SignatureOptions(Models.SignatureOptions signatureOptions)
            {
                this.signatureOptions = signatureOptions;
                return this;
            }

            /// <summary>
            /// ConfirmationOptions.
            /// </summary>
            /// <param name="confirmationOptions"> confirmationOptions. </param>
            /// <returns> Builder. </returns>
            public Builder ConfirmationOptions(Models.ConfirmationOptions confirmationOptions)
            {
                this.confirmationOptions = confirmationOptions;
                return this;
            }

            /// <summary>
            /// ReceiptOptions.
            /// </summary>
            /// <param name="receiptOptions"> receiptOptions. </param>
            /// <returns> Builder. </returns>
            public Builder ReceiptOptions(Models.ReceiptOptions receiptOptions)
            {
                this.receiptOptions = receiptOptions;
                return this;
            }

            /// <summary>
            /// DataCollectionOptions.
            /// </summary>
            /// <param name="dataCollectionOptions"> dataCollectionOptions. </param>
            /// <returns> Builder. </returns>
            public Builder DataCollectionOptions(Models.DataCollectionOptions dataCollectionOptions)
            {
                this.dataCollectionOptions = dataCollectionOptions;
                return this;
            }

            /// <summary>
            /// SelectOptions.
            /// </summary>
            /// <param name="selectOptions"> selectOptions. </param>
            /// <returns> Builder. </returns>
            public Builder SelectOptions(Models.SelectOptions selectOptions)
            {
                this.selectOptions = selectOptions;
                return this;
            }

            /// <summary>
            /// DeviceMetadata.
            /// </summary>
            /// <param name="deviceMetadata"> deviceMetadata. </param>
            /// <returns> Builder. </returns>
            public Builder DeviceMetadata(Models.DeviceMetadata deviceMetadata)
            {
                this.deviceMetadata = deviceMetadata;
                return this;
            }

            /// <summary>
            /// AwaitNextAction.
            /// </summary>
            /// <param name="awaitNextAction"> awaitNextAction. </param>
            /// <returns> Builder. </returns>
            public Builder AwaitNextAction(bool? awaitNextAction)
            {
                shouldSerialize["await_next_action"] = true;
                this.awaitNextAction = awaitNextAction;
                return this;
            }

            /// <summary>
            /// AwaitNextActionDuration.
            /// </summary>
            /// <param name="awaitNextActionDuration"> awaitNextActionDuration. </param>
            /// <returns> Builder. </returns>
            public Builder AwaitNextActionDuration(string awaitNextActionDuration)
            {
                shouldSerialize["await_next_action_duration"] = true;
                this.awaitNextActionDuration = awaitNextActionDuration;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetDeviceId()
            {
                this.shouldSerialize["device_id"] = false;
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
            public void UnsetAwaitNextAction()
            {
                this.shouldSerialize["await_next_action"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetAwaitNextActionDuration()
            {
                this.shouldSerialize["await_next_action_duration"] = false;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> TerminalAction. </returns>
            public TerminalAction Build()
            {
                return new TerminalAction(
                    shouldSerialize,
                    this.id,
                    this.deviceId,
                    this.deadlineDuration,
                    this.status,
                    this.cancelReason,
                    this.createdAt,
                    this.updatedAt,
                    this.appId,
                    this.locationId,
                    this.type,
                    this.qrCodeOptions,
                    this.saveCardOptions,
                    this.signatureOptions,
                    this.confirmationOptions,
                    this.receiptOptions,
                    this.dataCollectionOptions,
                    this.selectOptions,
                    this.deviceMetadata,
                    this.awaitNextAction,
                    this.awaitNextActionDuration
                );
            }
        }
    }
}
