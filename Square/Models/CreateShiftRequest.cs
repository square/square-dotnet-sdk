
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
    public class CreateShiftRequest 
    {
        public CreateShiftRequest(Models.Shift shift,
            string idempotencyKey = null)
        {
            IdempotencyKey = idempotencyKey;
            Shift = shift;
        }

        /// <summary>
        /// Unique string value to insure the idempotency of the operation.
        /// </summary>
        [JsonProperty("idempotency_key", NullValueHandling = NullValueHandling.Ignore)]
        public string IdempotencyKey { get; }

        /// <summary>
        /// A record of the hourly rate, start, and end times for a single work shift
        /// for an employee. May include a record of the start and end times for breaks
        /// taken during the shift.
        /// </summary>
        [JsonProperty("shift")]
        public Models.Shift Shift { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateShiftRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"IdempotencyKey = {(IdempotencyKey == null ? "null" : IdempotencyKey == string.Empty ? "" : IdempotencyKey)}");
            toStringOutput.Add($"Shift = {(Shift == null ? "null" : Shift.ToString())}");
        }

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

            return obj is CreateShiftRequest other &&
                ((IdempotencyKey == null && other.IdempotencyKey == null) || (IdempotencyKey?.Equals(other.IdempotencyKey) == true)) &&
                ((Shift == null && other.Shift == null) || (Shift?.Equals(other.Shift) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1561193749;

            if (IdempotencyKey != null)
            {
               hashCode += IdempotencyKey.GetHashCode();
            }

            if (Shift != null)
            {
               hashCode += Shift.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(Shift)
                .IdempotencyKey(IdempotencyKey);
            return builder;
        }

        public class Builder
        {
            private Models.Shift shift;
            private string idempotencyKey;

            public Builder(Models.Shift shift)
            {
                this.shift = shift;
            }

            public Builder Shift(Models.Shift shift)
            {
                this.shift = shift;
                return this;
            }

            public Builder IdempotencyKey(string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
                return this;
            }

            public CreateShiftRequest Build()
            {
                return new CreateShiftRequest(shift,
                    idempotencyKey);
            }
        }
    }
}