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
        /// <param name="grantType">grant_type.</param>
        /// <param name="clientSecret">client_secret.</param>
        /// <param name="code">code.</param>
        /// <param name="redirectUri">redirect_uri.</param>
        /// <param name="refreshToken">refresh_token.</param>
        /// <param name="migrationToken">migration_token.</param>
        /// <param name="scopes">scopes.</param>
        /// <param name="shortLived">short_lived.</param>
        /// <param name="codeVerifier">code_verifier.</param>
        public ObtainTokenRequest(
            string clientId,
            string grantType,
            string clientSecret = null,
            string code = null,
            string redirectUri = null,
            string refreshToken = null,
            string migrationToken = null,
            IList<string> scopes = null,
            bool? shortLived = null,
            string codeVerifier = null)
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
            this.CodeVerifier = codeVerifier;
        }

        /// <summary>
        /// The Square-issued ID of your application, which is available in the OAuth page in the
        /// [Developer Dashboard](https://developer.squareup.com/apps).
        /// </summary>
        [JsonProperty("client_id")]
        public string ClientId { get; }

        /// <summary>
        /// The Square-issued application secret for your application, which is available in the OAuth page
        /// in the [Developer Dashboard](https://developer.squareup.com/apps). This parameter is only required when you are not using the [OAuth PKCE (Proof Key for Code Exchange) flow](https://developer.squareup.com/docs/oauth-api/overview#pkce-flow).
        /// The PKCE flow requires a `code_verifier` instead of a `client_secret`.
        /// </summary>
        [JsonProperty("client_secret", NullValueHandling = NullValueHandling.Ignore)]
        public string ClientSecret { get; }

        /// <summary>
        /// The authorization code to exchange.
        /// This code is required if `grant_type` is set to `authorization_code` to indicate that
        /// the application wants to exchange an authorization code for an OAuth access token.
        /// </summary>
        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; }

        /// <summary>
        /// The redirect URL assigned in the OAuth page for your application in the [Developer Dashboard](https://developer.squareup.com/apps).
        /// </summary>
        [JsonProperty("redirect_uri", NullValueHandling = NullValueHandling.Ignore)]
        public string RedirectUri { get; }

        /// <summary>
        /// Specifies the method to request an OAuth access token.
        /// Valid values are `authorization_code`, `refresh_token`, and `migration_token`.
        /// </summary>
        [JsonProperty("grant_type")]
        public string GrantType { get; }

        /// <summary>
        /// A valid refresh token for generating a new OAuth access token.
        /// A valid refresh token is required if `grant_type` is set to `refresh_token`
        /// to indicate that the application wants a replacement for an expired OAuth access token.
        /// </summary>
        [JsonProperty("refresh_token", NullValueHandling = NullValueHandling.Ignore)]
        public string RefreshToken { get; }

        /// <summary>
        /// A legacy OAuth access token obtained using a Connect API version prior
        /// to 2019-03-13. This parameter is required if `grant_type` is set to
        /// `migration_token` to indicate that the application wants to get a replacement
        /// OAuth access token. The response also returns a refresh token.
        /// For more information, see [Migrate to Using Refresh Tokens](https://developer.squareup.com/docs/oauth-api/migrate-to-refresh-tokens).
        /// </summary>
        [JsonProperty("migration_token", NullValueHandling = NullValueHandling.Ignore)]
        public string MigrationToken { get; }

        /// <summary>
        /// A JSON list of strings representing the permissions that the application is requesting.
        /// For example, "`["MERCHANT_PROFILE_READ","PAYMENTS_READ","BANK_ACCOUNTS_READ"]`".
        /// The access token returned in the response is granted the permissions
        /// that comprise the intersection between the requested list of permissions and those
        /// that belong to the provided refresh token.
        /// </summary>
        [JsonProperty("scopes", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> Scopes { get; }

        /// <summary>
        /// A Boolean indicating a request for a short-lived access token.
        /// The short-lived access token returned in the response expires in 24 hours.
        /// </summary>
        [JsonProperty("short_lived", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ShortLived { get; }

        /// <summary>
        /// Must be provided when using PKCE OAuth flow. The `code_verifier` will be used to verify against the
        /// `code_challenge` associated with the `authorization_code`.
        /// </summary>
        [JsonProperty("code_verifier", NullValueHandling = NullValueHandling.Ignore)]
        public string CodeVerifier { get; }

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
                ((this.ShortLived == null && other.ShortLived == null) || (this.ShortLived?.Equals(other.ShortLived) == true)) &&
                ((this.CodeVerifier == null && other.CodeVerifier == null) || (this.CodeVerifier?.Equals(other.CodeVerifier) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -798532521;
            hashCode = HashCode.Combine(this.ClientId, this.ClientSecret, this.Code, this.RedirectUri, this.GrantType, this.RefreshToken, this.MigrationToken);

            hashCode = HashCode.Combine(hashCode, this.Scopes, this.ShortLived, this.CodeVerifier);

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
            toStringOutput.Add($"this.CodeVerifier = {(this.CodeVerifier == null ? "null" : this.CodeVerifier == string.Empty ? "" : this.CodeVerifier)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.ClientId,
                this.GrantType)
                .ClientSecret(this.ClientSecret)
                .Code(this.Code)
                .RedirectUri(this.RedirectUri)
                .RefreshToken(this.RefreshToken)
                .MigrationToken(this.MigrationToken)
                .Scopes(this.Scopes)
                .ShortLived(this.ShortLived)
                .CodeVerifier(this.CodeVerifier);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string clientId;
            private string grantType;
            private string clientSecret;
            private string code;
            private string redirectUri;
            private string refreshToken;
            private string migrationToken;
            private IList<string> scopes;
            private bool? shortLived;
            private string codeVerifier;

            public Builder(
                string clientId,
                string grantType)
            {
                this.clientId = clientId;
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
             /// CodeVerifier.
             /// </summary>
             /// <param name="codeVerifier"> codeVerifier. </param>
             /// <returns> Builder. </returns>
            public Builder CodeVerifier(string codeVerifier)
            {
                this.codeVerifier = codeVerifier;
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
                    this.grantType,
                    this.clientSecret,
                    this.code,
                    this.redirectUri,
                    this.refreshToken,
                    this.migrationToken,
                    this.scopes,
                    this.shortLived,
                    this.codeVerifier);
            }
        }
    }
}