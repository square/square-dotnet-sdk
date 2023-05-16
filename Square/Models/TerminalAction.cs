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
        /// <param name="type">type.</param>
        /// <param name="saveCardOptions">save_card_options.</param>
        /// <param name="receiptOptions">receipt_options.</param>
        /// <param name="deviceMetadata">device_metadata.</param>
        public TerminalAction(
            string id = null,
            string deviceId = null,
            string deadlineDuration = null,
            string status = null,
            string cancelReason = null,
            string createdAt = null,
            string updatedAt = null,
            string appId = null,
            string type = null,
            Models.SaveCardOptions saveCardOptions = null,
            Models.ReceiptOptions receiptOptions = null,
            Models.DeviceMetadata deviceMetadata = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "device_id", false },
                { "deadline_duration", false }
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
            this.Type = type;
            this.SaveCardOptions = saveCardOptions;
            this.ReceiptOptions = receiptOptions;
            this.DeviceMetadata = deviceMetadata;
        }
        internal TerminalAction(Dictionary<string, bool> shouldSerialize,
            string id = null,
            string deviceId = null,
            string deadlineDuration = null,
            string status = null,
            string cancelReason = null,
            string createdAt = null,
            string updatedAt = null,
            string appId = null,
            string type = null,
            Models.SaveCardOptions saveCardOptions = null,
            Models.ReceiptOptions receiptOptions = null,
            Models.DeviceMetadata deviceMetadata = null)
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
            Type = type;
            SaveCardOptions = saveCardOptions;
            ReceiptOptions = receiptOptions;
            DeviceMetadata = deviceMetadata;
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
        /// Describes the type of this unit and indicates which field contains the unit information. This is an ‘open’ enum.
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; }

        /// <summary>
        /// Describes save-card action fields.
        /// </summary>
        [JsonProperty("save_card_options", NullValueHandling = NullValueHandling.Ignore)]
        public Models.SaveCardOptions SaveCardOptions { get; }

        /// <summary>
        /// Describes receipt action fields.
        /// </summary>
        [JsonProperty("receipt_options", NullValueHandling = NullValueHandling.Ignore)]
        public Models.ReceiptOptions ReceiptOptions { get; }

        /// <summary>
        /// Gets or sets DeviceMetadata.
        /// </summary>
        [JsonProperty("device_metadata", NullValueHandling = NullValueHandling.Ignore)]
        public Models.DeviceMetadata DeviceMetadata { get; }

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
            return obj is TerminalAction other &&                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.DeviceId == null && other.DeviceId == null) || (this.DeviceId?.Equals(other.DeviceId) == true)) &&
                ((this.DeadlineDuration == null && other.DeadlineDuration == null) || (this.DeadlineDuration?.Equals(other.DeadlineDuration) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true)) &&
                ((this.CancelReason == null && other.CancelReason == null) || (this.CancelReason?.Equals(other.CancelReason) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((this.UpdatedAt == null && other.UpdatedAt == null) || (this.UpdatedAt?.Equals(other.UpdatedAt) == true)) &&
                ((this.AppId == null && other.AppId == null) || (this.AppId?.Equals(other.AppId) == true)) &&
                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true)) &&
                ((this.SaveCardOptions == null && other.SaveCardOptions == null) || (this.SaveCardOptions?.Equals(other.SaveCardOptions) == true)) &&
                ((this.ReceiptOptions == null && other.ReceiptOptions == null) || (this.ReceiptOptions?.Equals(other.ReceiptOptions) == true)) &&
                ((this.DeviceMetadata == null && other.DeviceMetadata == null) || (this.DeviceMetadata?.Equals(other.DeviceMetadata) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 195206616;
            hashCode = HashCode.Combine(this.Id, this.DeviceId, this.DeadlineDuration, this.Status, this.CancelReason, this.CreatedAt, this.UpdatedAt);

            hashCode = HashCode.Combine(hashCode, this.AppId, this.Type, this.SaveCardOptions, this.ReceiptOptions, this.DeviceMetadata);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.DeviceId = {(this.DeviceId == null ? "null" : this.DeviceId == string.Empty ? "" : this.DeviceId)}");
            toStringOutput.Add($"this.DeadlineDuration = {(this.DeadlineDuration == null ? "null" : this.DeadlineDuration == string.Empty ? "" : this.DeadlineDuration)}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status == string.Empty ? "" : this.Status)}");
            toStringOutput.Add($"this.CancelReason = {(this.CancelReason == null ? "null" : this.CancelReason.ToString())}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt == string.Empty ? "" : this.CreatedAt)}");
            toStringOutput.Add($"this.UpdatedAt = {(this.UpdatedAt == null ? "null" : this.UpdatedAt == string.Empty ? "" : this.UpdatedAt)}");
            toStringOutput.Add($"this.AppId = {(this.AppId == null ? "null" : this.AppId == string.Empty ? "" : this.AppId)}");
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type.ToString())}");
            toStringOutput.Add($"this.SaveCardOptions = {(this.SaveCardOptions == null ? "null" : this.SaveCardOptions.ToString())}");
            toStringOutput.Add($"this.ReceiptOptions = {(this.ReceiptOptions == null ? "null" : this.ReceiptOptions.ToString())}");
            toStringOutput.Add($"this.DeviceMetadata = {(this.DeviceMetadata == null ? "null" : this.DeviceMetadata.ToString())}");
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
                .Type(this.Type)
                .SaveCardOptions(this.SaveCardOptions)
                .ReceiptOptions(this.ReceiptOptions)
                .DeviceMetadata(this.DeviceMetadata);
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
            };

            private string id;
            private string deviceId;
            private string deadlineDuration;
            private string status;
            private string cancelReason;
            private string createdAt;
            private string updatedAt;
            private string appId;
            private string type;
            private Models.SaveCardOptions saveCardOptions;
            private Models.ReceiptOptions receiptOptions;
            private Models.DeviceMetadata deviceMetadata;

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
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetDeviceId()
            {
                this.shouldSerialize["device_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetDeadlineDuration()
            {
                this.shouldSerialize["deadline_duration"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> TerminalAction. </returns>
            public TerminalAction Build()
            {
                return new TerminalAction(shouldSerialize,
                    this.id,
                    this.deviceId,
                    this.deadlineDuration,
                    this.status,
                    this.cancelReason,
                    this.createdAt,
                    this.updatedAt,
                    this.appId,
                    this.type,
                    this.saveCardOptions,
                    this.receiptOptions,
                    this.deviceMetadata);
            }
        }
    }
}