using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIMatic.Core.Utilities.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;

namespace Square.Models
{
    /// <summary>
    /// CheckoutLocationSettingsPolicy.
    /// </summary>
    public class CheckoutLocationSettingsPolicy
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckoutLocationSettingsPolicy"/> class.
        /// </summary>
        /// <param name="uid">uid.</param>
        /// <param name="title">title.</param>
        /// <param name="description">description.</param>
        public CheckoutLocationSettingsPolicy(
            string uid = null,
            string title = null,
            string description = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "uid", false },
                { "title", false },
                { "description", false }
            };

            if (uid != null)
            {
                shouldSerialize["uid"] = true;
                this.Uid = uid;
            }

            if (title != null)
            {
                shouldSerialize["title"] = true;
                this.Title = title;
            }

            if (description != null)
            {
                shouldSerialize["description"] = true;
                this.Description = description;
            }
        }

        internal CheckoutLocationSettingsPolicy(
            Dictionary<string, bool> shouldSerialize,
            string uid = null,
            string title = null,
            string description = null)
        {
            this.shouldSerialize = shouldSerialize;
            Uid = uid;
            Title = title;
            Description = description;
        }

        /// <summary>
        /// A unique ID to identify the policy when making changes. You must set the UID for policy updates, but it’s optional when setting new policies.
        /// </summary>
        [JsonProperty("uid")]
        public string Uid { get; }

        /// <summary>
        /// The title of the policy. This is required when setting the description, though you can update it in a different request.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; }

        /// <summary>
        /// The description of the policy.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"CheckoutLocationSettingsPolicy : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeUid()
        {
            return this.shouldSerialize["uid"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTitle()
        {
            return this.shouldSerialize["title"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDescription()
        {
            return this.shouldSerialize["description"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is CheckoutLocationSettingsPolicy other &&
                (this.Uid == null && other.Uid == null ||
                 this.Uid?.Equals(other.Uid) == true) &&
                (this.Title == null && other.Title == null ||
                 this.Title?.Equals(other.Title) == true) &&
                (this.Description == null && other.Description == null ||
                 this.Description?.Equals(other.Description) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 1755412995;
            hashCode = HashCode.Combine(hashCode, this.Uid, this.Title, this.Description);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Uid = {this.Uid ?? "null"}");
            toStringOutput.Add($"this.Title = {this.Title ?? "null"}");
            toStringOutput.Add($"this.Description = {this.Description ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Uid(this.Uid)
                .Title(this.Title)
                .Description(this.Description);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "uid", false },
                { "title", false },
                { "description", false },
            };

            private string uid;
            private string title;
            private string description;

             /// <summary>
             /// Uid.
             /// </summary>
             /// <param name="uid"> uid. </param>
             /// <returns> Builder. </returns>
            public Builder Uid(string uid)
            {
                shouldSerialize["uid"] = true;
                this.uid = uid;
                return this;
            }

             /// <summary>
             /// Title.
             /// </summary>
             /// <param name="title"> title. </param>
             /// <returns> Builder. </returns>
            public Builder Title(string title)
            {
                shouldSerialize["title"] = true;
                this.title = title;
                return this;
            }

             /// <summary>
             /// Description.
             /// </summary>
             /// <param name="description"> description. </param>
             /// <returns> Builder. </returns>
            public Builder Description(string description)
            {
                shouldSerialize["description"] = true;
                this.description = description;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetUid()
            {
                this.shouldSerialize["uid"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetTitle()
            {
                this.shouldSerialize["title"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetDescription()
            {
                this.shouldSerialize["description"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CheckoutLocationSettingsPolicy. </returns>
            public CheckoutLocationSettingsPolicy Build()
            {
                return new CheckoutLocationSettingsPolicy(
                    shouldSerialize,
                    this.uid,
                    this.title,
                    this.description);
            }
        }
    }
}