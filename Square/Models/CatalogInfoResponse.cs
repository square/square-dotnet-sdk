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
    public class CatalogInfoResponse 
    {
        public CatalogInfoResponse(IList<Models.Error> errors = null,
            Models.CatalogInfoResponseLimits limits = null,
            Models.StandardUnitDescriptionGroup standardUnitDescriptionGroup = null)
        {
            Errors = errors;
            Limits = limits;
            StandardUnitDescriptionGroup = standardUnitDescriptionGroup;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Getter for limits
        /// </summary>
        [JsonProperty("limits", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CatalogInfoResponseLimits Limits { get; }

        /// <summary>
        /// Group of standard measurement units.
        /// </summary>
        [JsonProperty("standard_unit_description_group", NullValueHandling = NullValueHandling.Ignore)]
        public Models.StandardUnitDescriptionGroup StandardUnitDescriptionGroup { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .Limits(Limits)
                .StandardUnitDescriptionGroup(StandardUnitDescriptionGroup);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors;
            private Models.CatalogInfoResponseLimits limits;
            private Models.StandardUnitDescriptionGroup standardUnitDescriptionGroup;



            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public Builder Limits(Models.CatalogInfoResponseLimits limits)
            {
                this.limits = limits;
                return this;
            }

            public Builder StandardUnitDescriptionGroup(Models.StandardUnitDescriptionGroup standardUnitDescriptionGroup)
            {
                this.standardUnitDescriptionGroup = standardUnitDescriptionGroup;
                return this;
            }

            public CatalogInfoResponse Build()
            {
                return new CatalogInfoResponse(errors,
                    limits,
                    standardUnitDescriptionGroup);
            }
        }
    }
}