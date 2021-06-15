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
    using Square.Utilities;

    /// <summary>
    /// ObtainTokenRequest.
    /// </summary>
    public class ObtainTokenRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ObtainTokenRequest"/> class.
        /// </summary>
        /// <param name="clientId">client_id.</param>
        /// <param name="clientSecret">client_secret.</param>
        /// <param name="grantType">grant_type.</param>
        /// <param name="code">code.</param>
        /// <param name="redirectUri">redirect_uri.</param>
        /// <param name="refreshToken">refresh_token.</param>
        /// <param name="migrationToken">migration_token.</param>
        /// <param name="scopes">scopes.</param>
        /// <param name="shortLived">short_lived.</param>
        public ObtainTokenRequest(
            string clientId,
            string clientSecret,
            string grantType,
            string code = null,
            string redirectUri = null,
            string refreshToken = null,
            string migrationToken = null,
            IList<string> scopes = null,
            bool? shortLived = null)
        {
            this.ClientId = clientId;
            this.ClientSecret = clientSecret;
            this.Code = code;
            this.RedirectUri = redirectUri;
            this.GrantType = grantType;
            this.RefreshToken = refreshToken;
            this.MigrationToken = migrationToken;
            this.Scopes = scopes;
            this.ShortLived = shortLived;
        }

        /// <summary>
        /// The Square-issued ID of your application, available from the
        /// [developer dashboard](https://developer.squareup.com/apps).
        /// </summary>
        [JsonProperty("client_id")]
        public string ClientId { get; }

        /// <summary>
        /// The Square-issued application secret for your application, available
        /// from the [developer dashboard](https://developer.squareup.com/apps).
        /// </summary>
        [JsonProperty("client_secret")]
        public string ClientSecret { get; }

        /// <summary>
        /// The authorization code to exchange.
        /// This is required if `grant_type` is set to `authorization_code`, to indicate that
        /// the application wants to exchange an authorization code for an OAuth access token.
        /// </summary>
        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; }

        /// <summary>
        /// The redirect URL assigned in the [developer dashboard](https://developer.squareup.com/apps).
        /// </summary>
        [JsonProperty("redirect_uri", NullValueHandling = NullValueHandling.Ignore)]
        public string RedirectUri { get; }

        /// <summary>
        /// Specifies the method to request an OAuth access token.
        /// Valid values are: `authorization_code`, `refresh_token`, and `migration_token`
        /// </summary>
        [JsonProperty("grant_type")]
        public string GrantType { get; }

        /// <summary>
        /// A valid refresh token for generating a new OAuth access token.
        /// A valid refresh token is required if `grant_type` is set to `refresh_token` , to indicate the application wants a replacement for an expired OAuth access token.
        /// </summary>
        [JsonProperty("refresh_token", NullValueHandling = NullValueHandling.Ignore)]
        public string RefreshToken { get; }

        /// <summary>
        /// Legacy OAuth access token obtained using a Connect API version prior
        /// to 2019-03-13. This parameter is required if `grant_type` is set to
        /// `migration_token` to indicate that the application wants to get a replacement
        /// OAuth access token. The response also returns a refresh token.
        /// For more information, see [Migrate to Using Refresh Tokens](https://developer.squareup.com/docs/oauth-api/migrate-to-refresh-tokens).
        /// </summary>
        [JsonProperty("migration_token", NullValueHandling = NullValueHandling.Ignore)]
        public string MigrationToken { get; }

        /// <summary>
        /// A JSON list of strings representing the permissions the application is requesting.
        /// For example: "`["MERCHANT_PROFILE_READ","PAYMENTS_READ","BANK_ACCOUNTS_READ"]`"
        /// The access token returned in the response is granted the permissions
        /// that comprise the intersection between the requested list of permissions, and those
        /// that belong to the provided refresh token.
        /// </summary>
        [JsonProperty("scopes", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> Scopes { get; }

        /// <summary>
        /// A boolean indicating a request for a short-lived access token.
        /// The short-lived access token returned in the response will expire in 24 hours.
        /// </summary>
        [JsonProperty("short_lived", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ShortLived { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ObtainTokenRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is ObtainTokenRequest other &&
                ((this.ClientId == null && other.ClientId == null) || (this.ClientId?.Equals(other.ClientId) == true)) &&
                ((this.ClientSecret == null && other.ClientSecret == null) || (this.ClientSecret?.Equals(other.ClientSecret) == true)) &&
                ((this.Code == null && other.Code == null) || (this.Code?.Equals(other.Code) == true)) &&
                ((this.RedirectUri == null && other.RedirectUri == null) || (this.RedirectUri?.Equals(other.RedirectUri) == true)) &&
                ((this.GrantType == null && other.GrantType == null) || (this.GrantType?.Equals(other.GrantType) == true)) &&
                ((this.RefreshToken == null && other.RefreshToken == null) || (this.RefreshToken?.Equals(other.RefreshToken) == true)) &&
                ((this.MigrationToken == null && other.MigrationToken == null) || (this.MigrationToken?.Equals(other.MigrationToken) == true)) &&
                ((this.Scopes == null && other.Scopes == null) || (this.Scopes?.Equals(other.Scopes) == true)) &&
                ((this.ShortLived == null && other.ShortLived == null) || (this.ShortLived?.Equals(other.ShortLived) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -994318680;

            if (this.ClientId != null)
            {
               hashCode += this.ClientId.GetHashCode();
            }

            if (this.ClientSecret != null)
            {
               hashCode += this.ClientSecret.GetHashCode();
            }

            if (this.Code != null)
            {
               hashCode += this.Code.GetHashCode();
            }

            if (this.RedirectUri != null)
            {
               hashCode += this.RedirectUri.GetHashCode();
            }

            if (this.GrantType != null)
            {
               hashCode += this.GrantType.GetHashCode();
            }

            if (this.RefreshToken != null)
            {
               hashCode += this.RefreshToken.GetHashCode();
            }

            if (this.MigrationToken != null)
            {
               hashCode += this.MigrationToken.GetHashCode();
            }

            if (this.Scopes != null)
            {
               hashCode += this.Scopes.GetHashCode();
            }

            if (this.ShortLived != null)
            {
               hashCode += this.ShortLived.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ClientId = {(this.ClientId == null ? "null" : this.ClientId == string.Empty ? "" : this.ClientId)}");
            toStringOutput.Add($"this.ClientSecret = {(this.ClientSecret == null ? "null" : this.ClientSecret == string.Empty ? "" : this.ClientSecret)}");
            toStringOutput.Add($"this.Code = {(this.Code == null ? "null" : this.Code == string.Empty ? "" : this.Code)}");
            toStringOutput.Add($"this.RedirectUri = {(this.RedirectUri == null ? "null" : this.RedirectUri == string.Empty ? "" : this.RedirectUri)}");
            toStringOutput.Add($"this.GrantType = {(this.GrantType == null ? "null" : this.GrantType == string.Empty ? "" : this.GrantType)}");
            toStringOutput.Add($"this.RefreshToken = {(this.RefreshToken == null ? "null" : this.RefreshToken == string.Empty ? "" : this.RefreshToken)}");
            toStringOutput.Add($"this.MigrationToken = {(this.MigrationToken == null ? "null" : this.MigrationToken == string.Empty ? "" : this.MigrationToken)}");
            toStringOutput.Add($"this.Scopes = {(this.Scopes == null ? "null" : $"[{string.Join(", ", this.Scopes)} ]")}");
            toStringOutput.Add($"this.ShortLived = {(this.ShortLived == null ? "null" : this.ShortLived.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.ClientId,
                this.ClientSecret,
                this.GrantType)
                .Code(this.Code)
                .RedirectUri(this.RedirectUri)
                .RefreshToken(this.RefreshToken)
                .MigrationToken(this.MigrationToken)
                .Scopes(this.Scopes)
                .ShortLived(this.ShortLived);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string clientId;
            private string clientSecret;
            private string grantType;
            private string code;
            private string redirectUri;
            private string refreshToken;
            private string migrationToken;
            private IList<string> scopes;
            private bool? shortLived;

            public Builder(
                string clientId,
                string clientSecret,
                string grantType)
            {
                this.clientId = clientId;
                this.clientSecret = clientSecret;
                this.grantType = grantType;
            }

             /// <summary>
             /// ClientId.
             /// </summary>
             /// <param name="clientId"> clientId. </param>
             /// <returns> Builder. </returns>
            public Builder ClientId(string clientId)
            {
                this.clientId = clientId;
                return this;
            }

             /// <summary>
             /// ClientSecret.
             /// </summary>
             /// <param name="clientSecret"> clientSecret. </param>
             /// <returns> Builder. </returns>
            public Builder ClientSecret(string clientSecret)
            {
                this.clientSecret = clientSecret;
                return this;
            }

             /// <summary>
             /// GrantType.
             /// </summary>
             /// <param name="grantType"> grantType. </param>
             /// <returns> Builder. </returns>
            public Builder GrantType(string grantType)
            {
                this.grantType = grantType;
                return this;
            }

             /// <summary>
             /// Code.
             /// </summary>
             /// <param name="code"> code. </param>
             /// <returns> Builder. </returns>
            public Builder Code(string code)
            {
                this.code = code;
                return this;
            }

             /// <summary>
             /// RedirectUri.
             /// </summary>
             /// <param name="redirectUri"> redirectUri. </param>
             /// <returns> Builder. </returns>
            public Builder RedirectUri(string redirectUri)
            {
                this.redirectUri = redirectUri;
                return this;
            }

             /// <summary>
             /// RefreshToken.
             /// </summary>
             /// <param name="refreshToken"> refreshToken. </param>
             /// <returns> Builder. </returns>
            public Builder RefreshToken(string refreshToken)
            {
                this.refreshToken = refreshToken;
                return this;
            }

             /// <summary>
             /// MigrationToken.
             /// </summary>
             /// <param name="migrationToken"> migrationToken. </param>
             /// <returns> Builder. </returns>
            public Builder MigrationToken(string migrationToken)
            {
                this.migrationToken = migrationToken;
                return this;
            }

             /// <summary>
             /// Scopes.
             /// </summary>
             /// <param name="scopes"> scopes. </param>
             /// <returns> Builder. </returns>
            public Builder Scopes(IList<string> scopes)
            {
                this.scopes = scopes;
                return this;
            }

             /// <summary>
             /// ShortLived.
             /// </summary>
             /// <param name="shortLived"> shortLived. </param>
             /// <returns> Builder. </returns>
            public Builder ShortLived(bool? shortLived)
            {
                this.shortLived = shortLived;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ObtainTokenRequest. </returns>
            public ObtainTokenRequest Build()
            {
                return new ObtainTokenRequest(
                    this.clientId,
                    this.clientSecret,
                    this.grantType,
                    this.code,
                    this.redirectUri,
                    this.refreshToken,
                    this.migrationToken,
                    this.scopes,
                    this.shortLived);
            }
        }
    }
}