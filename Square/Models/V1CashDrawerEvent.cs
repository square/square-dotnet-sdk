using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class V1CashDrawerEvent 
    {
        public V1CashDrawerEvent(string id = null,
            string employeeId = null,
            string eventType = null,
            Models.V1Money eventMoney = null,
            string createdAt = null,
            string description = null)
        {
            Id = id;
            EmployeeId = employeeId;
            EventType = eventType;
            EventMoney = eventMoney;
            CreatedAt = createdAt;
            Description = description;
        }

        /// <summary>
        /// The event's unique ID.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The ID of the employee that created the event.
        /// </summary>
        [JsonProperty("employee_id", NullValueHandling = NullValueHandling.Ignore)]
        public string EmployeeId { get; }

        /// <summary>
        /// Getter for event_type
        /// </summary>
        [JsonProperty("event_type", NullValueHandling = NullValueHandling.Ignore)]
        public string EventType { get; }

        /// <summary>
        /// Getter for event_money
        /// </summary>
        [JsonProperty("event_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money EventMoney { get; }

        /// <summary>
        /// The time when the event occurred, in ISO 8601 format.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// An optional description of the event, entered by the employee that created it.
        /// </summary>
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(Id)
                .EmployeeId(EmployeeId)
                .EventType(EventType)
                .EventMoney(EventMoney)
                .CreatedAt(CreatedAt)
                .Description(Description);
            return builder;
        }

        public class Builder
        {
            private string id;
            private string employeeId;
            private string eventType;
            private Models.V1Money eventMoney;
            private string createdAt;
            private string description;



            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

            public Builder EmployeeId(string employeeId)
            {
                this.employeeId = employeeId;
                return this;
            }

            public Builder EventType(string eventType)
            {
                this.eventType = eventType;
                return this;
            }

            public Builder EventMoney(Models.V1Money eventMoney)
            {
                this.eventMoney = eventMoney;
                return this;
            }

            public Builder CreatedAt(string createdAt)
            {
                this.createdAt = createdAt;
                return this;
            }

            public Builder Description(string description)
            {
                this.description = description;
                return this;
            }

            public V1CashDrawerEvent Build()
            {
                return new V1CashDrawerEvent(id,
                    employeeId,
                    eventType,
                    eventMoney,
                    createdAt,
                    description);
            }
        }
    }
}