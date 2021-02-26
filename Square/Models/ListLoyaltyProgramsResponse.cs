
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square.Http.Client;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class ListLoyaltyProgramsResponse 
    {
        public ListLoyaltyProgramsResponse(IList<Models.Error> errors = null,
            IList<Models.LoyaltyProgram> programs = null)
        {
            Errors = errors;
            Programs = programs;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// A list of `LoyaltyProgram` for the merchant.
        /// </summary>
        [JsonProperty("programs", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.LoyaltyProgram> Programs { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ListLoyaltyProgramsResponse : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Errors = {(Errors == null ? "null" : $"[{ string.Join(", ", Errors)} ]")}");
            toStringOutput.Add($"Programs = {(Programs == null ? "null" : $"[{ string.Join(", ", Programs)} ]")}");
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

            return obj is ListLoyaltyProgramsResponse other &&
                ((Context == null && other.Context == null) || (Context?.Equals(other.Context) == true)) &&
                ((Errors == null && other.Errors == null) || (Errors?.Equals(other.Errors) == true)) &&
                ((Programs == null && other.Programs == null) || (Programs?.Equals(other.Programs) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1778675748;

            if (Context != null)
            {
                hashCode += Context.GetHashCode();
            }

            if (Errors != null)
            {
               hashCode += Errors.GetHashCode();
            }

            if (Programs != null)
            {
               hashCode += Programs.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .Programs(Programs);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors;
            private IList<Models.LoyaltyProgram> programs;



            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public Builder Programs(IList<Models.LoyaltyProgram> programs)
            {
                this.programs = programs;
                return this;
            }

            public ListLoyaltyProgramsResponse Build()
            {
                return new ListLoyaltyProgramsResponse(errors,
                    programs);
            }
        }
    }
}