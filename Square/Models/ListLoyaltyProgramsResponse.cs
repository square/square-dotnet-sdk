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