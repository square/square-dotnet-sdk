
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogInfoResponse : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Errors = {(Errors == null ? "null" : $"[{ string.Join(", ", Errors)} ]")}");
            toStringOutput.Add($"Limits = {(Limits == null ? "null" : Limits.ToString())}");
            toStringOutput.Add($"StandardUnitDescriptionGroup = {(StandardUnitDescriptionGroup == null ? "null" : StandardUnitDescriptionGroup.ToString())}");
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

            return obj is CatalogInfoResponse other &&
                ((Context == null && other.Context == null) || (Context?.Equals(other.Context) == true)) &&
                ((Errors == null && other.Errors == null) || (Errors?.Equals(other.Errors) == true)) &&
                ((Limits == null && other.Limits == null) || (Limits?.Equals(other.Limits) == true)) &&
                ((StandardUnitDescriptionGroup == null && other.StandardUnitDescriptionGroup == null) || (StandardUnitDescriptionGroup?.Equals(other.StandardUnitDescriptionGroup) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -614027011;

            if (Context != null)
            {
                hashCode += Context.GetHashCode();
            }

            if (Errors != null)
            {
               hashCode += Errors.GetHashCode();
            }

            if (Limits != null)
            {
               hashCode += Limits.GetHashCode();
            }

            if (StandardUnitDescriptionGroup != null)
            {
               hashCode += StandardUnitDescriptionGroup.GetHashCode();
            }

            return hashCode;
        }

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