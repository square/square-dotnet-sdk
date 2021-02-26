
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
    public class CheckAppointmentsOnboardedResponse 
    {
        public CheckAppointmentsOnboardedResponse(bool? appointmentsOnboarded = null,
            IList<Models.Error> errors = null)
        {
            AppointmentsOnboarded = appointmentsOnboarded;
            Errors = errors;
        }

        /// <summary>
        /// Indicates whether the seller has enabled the Square Appointments service (`true`) or not (`false`).
        /// </summary>
        [JsonProperty("appointments_onboarded", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AppointmentsOnboarded { get; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CheckAppointmentsOnboardedResponse : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"AppointmentsOnboarded = {(AppointmentsOnboarded == null ? "null" : AppointmentsOnboarded.ToString())}");
            toStringOutput.Add($"Errors = {(Errors == null ? "null" : $"[{ string.Join(", ", Errors)} ]")}");
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

            return obj is CheckAppointmentsOnboardedResponse other &&
                ((AppointmentsOnboarded == null && other.AppointmentsOnboarded == null) || (AppointmentsOnboarded?.Equals(other.AppointmentsOnboarded) == true)) &&
                ((Errors == null && other.Errors == null) || (Errors?.Equals(other.Errors) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1012390189;

            if (AppointmentsOnboarded != null)
            {
               hashCode += AppointmentsOnboarded.GetHashCode();
            }

            if (Errors != null)
            {
               hashCode += Errors.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .AppointmentsOnboarded(AppointmentsOnboarded)
                .Errors(Errors);
            return builder;
        }

        public class Builder
        {
            private bool? appointmentsOnboarded;
            private IList<Models.Error> errors;



            public Builder AppointmentsOnboarded(bool? appointmentsOnboarded)
            {
                this.appointmentsOnboarded = appointmentsOnboarded;
                return this;
            }

            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public CheckAppointmentsOnboardedResponse Build()
            {
                return new CheckAppointmentsOnboardedResponse(appointmentsOnboarded,
                    errors);
            }
        }
    }
}