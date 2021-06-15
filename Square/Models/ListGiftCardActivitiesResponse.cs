namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Http.Client;
    using Square.Utilities;

    /// <summary>
    /// ListGiftCardActivitiesResponse.
    /// </summary>
    public class ListGiftCardActivitiesResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListGiftCardActivitiesResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="giftCardActivities">gift_card_activities.</param>
        /// <param name="cursor">cursor.</param>
        public ListGiftCardActivitiesResponse(
            IList<Models.Error> errors = null,
            IList<Models.GiftCardActivity> giftCardActivities = null,
            string cursor = null)
        {
            this.Errors = errors;
            this.GiftCardActivities = giftCardActivities;
            this.Cursor = cursor;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Gift card activities retrieved.
        /// </summary>
        [JsonProperty("gift_card_activities", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.GiftCardActivity> GiftCardActivities { get; }

        /// <summary>
        /// When a response is truncated, it includes a cursor that you can use in a
        /// subsequent request to fetch the next set of activities. If empty, this is
        /// the final response.
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ListGiftCardActivitiesResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
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

            return obj is ListGiftCardActivitiesResponse other &&
                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true)) &&
                ((this.GiftCardActivities == null && other.GiftCardActivities == null) || (this.GiftCardActivities?.Equals(other.GiftCardActivities) == true)) &&
                ((this.Cursor == null && other.Cursor == null) || (this.Cursor?.Equals(other.Cursor) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -833897416;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }

            if (this.Errors != null)
            {
               hashCode += this.Errors.GetHashCode();
            }

            if (this.GiftCardActivities != null)
            {
               hashCode += this.GiftCardActivities.GetHashCode();
            }

            if (this.Cursor != null)
            {
               hashCode += this.Cursor.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
            toStringOutput.Add($"this.GiftCardActivities = {(this.GiftCardActivities == null ? "null" : $"[{string.Join(", ", this.GiftCardActivities)} ]")}");
            toStringOutput.Add($"this.Cursor = {(this.Cursor == null ? "null" : this.Cursor == string.Empty ? "" : this.Cursor)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .GiftCardActivities(this.GiftCardActivities)
                .Cursor(this.Cursor);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private IList<Models.GiftCardActivity> giftCardActivities;
            private string cursor;

             /// <summary>
             /// Errors.
             /// </summary>
             /// <param name="errors"> errors. </param>
             /// <returns> Builder. </returns>
            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

             /// <summary>
             /// GiftCardActivities.
             /// </summary>
             /// <param name="giftCardActivities"> giftCardActivities. </param>
             /// <returns> Builder. </returns>
            public Builder GiftCardActivities(IList<Models.GiftCardActivity> giftCardActivities)
            {
                this.giftCardActivities = giftCardActivities;
                return this;
            }

             /// <summary>
             /// Cursor.
             /// </summary>
             /// <param name="cursor"> cursor. </param>
             /// <returns> Builder. </returns>
            public Builder Cursor(string cursor)
            {
                this.cursor = cursor;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ListGiftCardActivitiesResponse. </returns>
            public ListGiftCardActivitiesResponse Build()
            {
                return new ListGiftCardActivitiesResponse(
                    this.errors,
                    this.giftCardActivities,
                    this.cursor);
            }
        }
    }
}