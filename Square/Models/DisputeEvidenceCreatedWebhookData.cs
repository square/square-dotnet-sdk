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
    /// DisputeEvidenceCreatedWebhookData.
    /// </summary>
    public class DisputeEvidenceCreatedWebhookData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DisputeEvidenceCreatedWebhookData"/> class.
        /// </summary>
        /// <param name="type">type.</param>
        /// <param name="id">id.</param>
        /// <param name="mObject">object.</param>
        public DisputeEvidenceCreatedWebhookData(
            string type = null,
            string id = null,
            Models.DisputeEvidenceCreatedWebhookObject mObject = null)
        {
            this.Type = type;
            this.Id = id;
            this.MObject = mObject;
        }

        /// <summary>
        /// Name of the affected dispute's type.
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; }

        /// <summary>
        /// ID of the affected dispute.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// Gets or sets MObject.
        /// </summary>
        [JsonProperty("object", NullValueHandling = NullValueHandling.Ignore)]
        public Models.DisputeEvidenceCreatedWebhookObject MObject { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"DisputeEvidenceCreatedWebhookData : ({string.Join(", ", toStringOutput)})";
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

            return obj is DisputeEvidenceCreatedWebhookData other &&
                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true)) &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.MObject == null && other.MObject == null) || (this.MObject?.Equals(other.MObject) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 2070725501;
            hashCode = HashCode.Combine(this.Type, this.Id, this.MObject);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type == string.Empty ? "" : this.Type)}");
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.MObject = {(this.MObject == null ? "null" : this.MObject.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Type(this.Type)
                .Id(this.Id)
                .MObject(this.MObject);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string type;
            private string id;
            private Models.DisputeEvidenceCreatedWebhookObject mObject;

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
             /// MObject.
             /// </summary>
             /// <param name="mObject"> mObject. </param>
             /// <returns> Builder. </returns>
            public Builder MObject(Models.DisputeEvidenceCreatedWebhookObject mObject)
            {
                this.mObject = mObject;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> DisputeEvidenceCreatedWebhookData. </returns>
            public DisputeEvidenceCreatedWebhookData Build()
            {
                return new DisputeEvidenceCreatedWebhookData(
                    this.type,
                    this.id,
                    this.mObject);
            }
        }
    }
}