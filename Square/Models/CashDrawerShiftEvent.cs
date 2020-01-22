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
    public class CashDrawerShiftEvent 
    {
        public CashDrawerShiftEvent(string id = null,
            string employeeId = null,
            string eventType = null,
            Models.Money eventMoney = null,
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
        /// The unique ID of the event.
        /// </summary>
        [JsonProperty("id")]
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
        [JsonProperty("event_type")]
        public string EventType { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("event_money")]
        public Models.Money EventMoney { get; }

        /// <summary>
        /// The event time in ISO 8601 format.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; }

        /// <summary>
        /// An optional description of the event, entered by the employee that
        /// created the event.
        /// </summary>
        [JsonProperty("description")]
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
            private Models.Money eventMoney;
            private string createdAt;
            private string description;

            public Builder() { }
            public Builder Id(string value)
            {
                id = value;
                return this;
            }

            public Builder EmployeeId(string value)
            {
                employeeId = value;
                return this;
            }

            public Builder EventType(string value)
            {
                eventType = value;
                return this;
            }

            public Builder EventMoney(Models.Money value)
            {
                eventMoney = value;
                return this;
            }

            public Builder CreatedAt(string value)
            {
                createdAt = value;
                return this;
            }

            public Builder Description(string value)
            {
                description = value;
                return this;
            }

            public CashDrawerShiftEvent Build()
            {
                return new CashDrawerShiftEvent(id,
                    employeeId,
                    eventType,
                    eventMoney,
                    createdAt,
                    description);
            }
        }
    }
}