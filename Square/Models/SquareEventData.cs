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
    /// SquareEventData.
    /// </summary>
    public class SquareEventData
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="SquareEventData"/> class.
        /// </summary>
        /// <param name="type">type.</param>
        /// <param name="id">id.</param>
        /// <param name="deleted">deleted.</param>
        /// <param name="mObject">object.</param>
        public SquareEventData(
            string type = null,
            string id = null,
            bool? deleted = null,
            JsonObject mObject = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "type", false },
                { "deleted", false },
                { "object", false }
            };

            if (type != null)
            {
                shouldSerialize["type"] = true;
                this.Type = type;
            }

            this.Id = id;
            if (deleted != null)
            {
                shouldSerialize["deleted"] = true;
                this.Deleted = deleted;
            }

            if (mObject != null)
            {
                shouldSerialize["object"] = true;
                this.MObject = mObject;
            }

        }
        internal SquareEventData(Dictionary<string, bool> shouldSerialize,
            string type = null,
            string id = null,
            bool? deleted = null,
            JsonObject mObject = null)
        {
            this.shouldSerialize = shouldSerialize;
            Type = type;
            Id = id;
            Deleted = deleted;
            MObject = mObject;
        }

        /// <summary>
        /// Name of the affected object’s type.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; }

        /// <summary>
        /// ID of the affected object.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// Is true if the affected object was deleted. Otherwise absent.
        /// </summary>
        [JsonProperty("deleted")]
        public bool? Deleted { get; }

        /// <summary>
        /// An object containing fields and values relevant to the event. Is absent if affected object was deleted.
        /// </summary>
        [JsonProperty("object")]
        public JsonObject MObject { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SquareEventData : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeType()
        {
            return this.shouldSerialize["type"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDeleted()
        {
            return this.shouldSerialize["deleted"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeMObject()
        {
            return this.shouldSerialize["object"];
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

            return obj is SquareEventData other &&
                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true)) &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.Deleted == null && other.Deleted == null) || (this.Deleted?.Equals(other.Deleted) == true)) &&
                ((this.MObject == null && other.MObject == null) || (this.MObject?.Equals(other.MObject) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 554410150;
            hashCode = HashCode.Combine(this.Type, this.Id, this.Deleted, this.MObject);

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
            toStringOutput.Add($"this.Deleted = {(this.Deleted == null ? "null" : this.Deleted.ToString())}");
            toStringOutput.Add($"MObject = {(this.MObject == null ? "null" : this.MObject.ToString())}");
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
                .Deleted(this.Deleted)
                .MObject(this.MObject);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "type", false },
                { "deleted", false },
                { "object", false },
            };

            private string type;
            private string id;
            private bool? deleted;
            private JsonObject mObject;

             /// <summary>
             /// Type.
             /// </summary>
             /// <param name="type"> type. </param>
             /// <returns> Builder. </returns>
            public Builder Type(string type)
            {
                shouldSerialize["type"] = true;
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
             /// Deleted.
             /// </summary>
             /// <param name="deleted"> deleted. </param>
             /// <returns> Builder. </returns>
            public Builder Deleted(bool? deleted)
            {
                shouldSerialize["deleted"] = true;
                this.deleted = deleted;
                return this;
            }

             /// <summary>
             /// MObject.
             /// </summary>
             /// <param name="mObject"> mObject. </param>
             /// <returns> Builder. </returns>
            public Builder MObject(JsonObject mObject)
            {
                shouldSerialize["object"] = true;
                this.mObject = mObject;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetType()
            {
                this.shouldSerialize["type"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetDeleted()
            {
                this.shouldSerialize["deleted"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetMObject()
            {
                this.shouldSerialize["object"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> SquareEventData. </returns>
            public SquareEventData Build()
            {
                return new SquareEventData(shouldSerialize,
                    this.type,
                    this.id,
                    this.deleted,
                    this.mObject);
            }
        }
    }
}