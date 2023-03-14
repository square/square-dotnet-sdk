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
    /// CashDrawerShiftEvent.
    /// </summary>
    public class CashDrawerShiftEvent
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="CashDrawerShiftEvent"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="employeeId">employee_id.</param>
        /// <param name="eventType">event_type.</param>
        /// <param name="eventMoney">event_money.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="description">description.</param>
        public CashDrawerShiftEvent(
            string id = null,
            string employeeId = null,
            string eventType = null,
            Models.Money eventMoney = null,
            string createdAt = null,
            string description = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "employee_id", false },
                { "description", false }
            };

            this.Id = id;
            if (employeeId != null)
            {
                shouldSerialize["employee_id"] = true;
                this.EmployeeId = employeeId;
            }

            this.EventType = eventType;
            this.EventMoney = eventMoney;
            this.CreatedAt = createdAt;
            if (description != null)
            {
                shouldSerialize["description"] = true;
                this.Description = description;
            }

        }
        internal CashDrawerShiftEvent(Dictionary<string, bool> shouldSerialize,
            string id = null,
            string employeeId = null,
            string eventType = null,
            Models.Money eventMoney = null,
            string createdAt = null,
            string description = null)
        {
            this.shouldSerialize = shouldSerialize;
            Id = id;
            EmployeeId = employeeId;
            EventType = eventType;
            EventMoney = eventMoney;
            CreatedAt = createdAt;
            Description = description;
        }

        /// <summary>
        /// The unique ID of the event.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The ID of the employee that created the event.
        /// </summary>
        [JsonProperty("employee_id")]
        public string EmployeeId { get; }

        /// <summary>
        /// The types of events on a CashDrawerShift.
        /// Each event type represents an employee action on the actual cash drawer
        /// represented by a CashDrawerShift.
        /// </summary>
        [JsonProperty("event_type", NullValueHandling = NullValueHandling.Ignore)]
        public string EventType { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("event_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money EventMoney { get; }

        /// <summary>
        /// The event time in ISO 8601 format.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// An optional description of the event, entered by the employee that
        /// created the event.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CashDrawerShiftEvent : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEmployeeId()
        {
            return this.shouldSerialize["employee_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDescription()
        {
            return this.shouldSerialize["description"];
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

            return obj is CashDrawerShiftEvent other &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.EmployeeId == null && other.EmployeeId == null) || (this.EmployeeId?.Equals(other.EmployeeId) == true)) &&
                ((this.EventType == null && other.EventType == null) || (this.EventType?.Equals(other.EventType) == true)) &&
                ((this.EventMoney == null && other.EventMoney == null) || (this.EventMoney?.Equals(other.EventMoney) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((this.Description == null && other.Description == null) || (this.Description?.Equals(other.Description) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1056052778;
            hashCode = HashCode.Combine(this.Id, this.EmployeeId, this.EventType, this.EventMoney, this.CreatedAt, this.Description);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.EmployeeId = {(this.EmployeeId == null ? "null" : this.EmployeeId == string.Empty ? "" : this.EmployeeId)}");
            toStringOutput.Add($"this.EventType = {(this.EventType == null ? "null" : this.EventType.ToString())}");
            toStringOutput.Add($"this.EventMoney = {(this.EventMoney == null ? "null" : this.EventMoney.ToString())}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt == string.Empty ? "" : this.CreatedAt)}");
            toStringOutput.Add($"this.Description = {(this.Description == null ? "null" : this.Description == string.Empty ? "" : this.Description)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(this.Id)
                .EmployeeId(this.EmployeeId)
                .EventType(this.EventType)
                .EventMoney(this.EventMoney)
                .CreatedAt(this.CreatedAt)
                .Description(this.Description);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "employee_id", false },
                { "description", false },
            };

            private string id;
            private string employeeId;
            private string eventType;
            private Models.Money eventMoney;
            private string createdAt;
            private string description;

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
             /// EmployeeId.
             /// </summary>
             /// <param name="employeeId"> employeeId. </param>
             /// <returns> Builder. </returns>
            public Builder EmployeeId(string employeeId)
            {
                shouldSerialize["employee_id"] = true;
                this.employeeId = employeeId;
                return this;
            }

             /// <summary>
             /// EventType.
             /// </summary>
             /// <param name="eventType"> eventType. </param>
             /// <returns> Builder. </returns>
            public Builder EventType(string eventType)
            {
                this.eventType = eventType;
                return this;
            }

             /// <summary>
             /// EventMoney.
             /// </summary>
             /// <param name="eventMoney"> eventMoney. </param>
             /// <returns> Builder. </returns>
            public Builder EventMoney(Models.Money eventMoney)
            {
                this.eventMoney = eventMoney;
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
             /// Description.
             /// </summary>
             /// <param name="description"> description. </param>
             /// <returns> Builder. </returns>
            public Builder Description(string description)
            {
                shouldSerialize["description"] = true;
                this.description = description;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetEmployeeId()
            {
                this.shouldSerialize["employee_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetDescription()
            {
                this.shouldSerialize["description"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CashDrawerShiftEvent. </returns>
            public CashDrawerShiftEvent Build()
            {
                return new CashDrawerShiftEvent(shouldSerialize,
                    this.id,
                    this.employeeId,
                    this.eventType,
                    this.eventMoney,
                    this.createdAt,
                    this.description);
            }
        }
    }
}