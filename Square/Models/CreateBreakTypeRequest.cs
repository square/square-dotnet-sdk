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
    public class CreateBreakTypeRequest 
    {
        public CreateBreakTypeRequest(Models.BreakType breakType,
            string idempotencyKey = null)
        {
            IdempotencyKey = idempotencyKey;
            BreakType = breakType;
        }

        /// <summary>
        /// Unique string value to insure idempotency of the operation
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <summary>
        /// A defined break template that sets an expectation for possible `Break`
        /// instances on a `Shift`.
        /// </summary>
        [JsonProperty("break_type")]
        public Models.BreakType BreakType { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(BreakType)
                .IdempotencyKey(IdempotencyKey);
            return builder;
        }

        public class Builder
        {
            private Models.BreakType breakType;
            private string idempotencyKey;

            public Builder(Models.BreakType breakType)
            {
                this.breakType = breakType;
            }
            public Builder BreakType(Models.BreakType value)
            {
                breakType = value;
                return this;
            }

            public Builder IdempotencyKey(string value)
            {
                idempotencyKey = value;
                return this;
            }

            public CreateBreakTypeRequest Build()
            {
                return new CreateBreakTypeRequest(breakType,
                    idempotencyKey);
            }
        }
    }
}