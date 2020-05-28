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
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// A list of `LoyaltyProgram` for the merchant.
        /// </summary>
        [JsonProperty("programs")]
        public IList<Models.LoyaltyProgram> Programs { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .Programs(Programs);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors = new List<Models.Error>();
            private IList<Models.LoyaltyProgram> programs = new List<Models.LoyaltyProgram>();

            public Builder() { }
            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public Builder Programs(IList<Models.LoyaltyProgram> value)
            {
                programs = value;
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