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
    /// DisputeEvidenceCreatedWebhookObject.
    /// </summary>
    public class DisputeEvidenceCreatedWebhookObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DisputeEvidenceCreatedWebhookObject"/> class.
        /// </summary>
        /// <param name="mObject">object.</param>
        public DisputeEvidenceCreatedWebhookObject(
            Models.Dispute mObject = null)
        {
            this.MObject = mObject;
        }

        /// <summary>
        /// Represents a dispute a cardholder initiated with their bank.
        /// </summary>
        [JsonProperty("object", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Dispute MObject { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"DisputeEvidenceCreatedWebhookObject : ({string.Join(", ", toStringOutput)})";
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

            return obj is DisputeEvidenceCreatedWebhookObject other &&
                ((this.MObject == null && other.MObject == null) || (this.MObject?.Equals(other.MObject) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1419891964;
            hashCode = HashCode.Combine(this.MObject);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.MObject = {(this.MObject == null ? "null" : this.MObject.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .MObject(this.MObject);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.Dispute mObject;

             /// <summary>
             /// MObject.
             /// </summary>
             /// <param name="mObject"> mObject. </param>
             /// <returns> Builder. </returns>
            public Builder MObject(Models.Dispute mObject)
            {
                this.mObject = mObject;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> DisputeEvidenceCreatedWebhookObject. </returns>
            public DisputeEvidenceCreatedWebhookObject Build()
            {
                return new DisputeEvidenceCreatedWebhookObject(
                    this.mObject);
            }
        }
    }
}