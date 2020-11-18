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
    public class ObtainTokenRequest 
    {
        public ObtainTokenRequest(string clientId,
            string clientSecret,
            string grantType,
            string code = null,
            string redirectUri = null,
            string refreshToken = null,
            string migrationToken = null,
            IList<string> scopes = null,
            bool? shortLived = null)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            Code = code;
            RedirectUri = redirectUri;
            GrantType = grantType;
            RefreshToken = refreshToken;
            MigrationToken = migrationToken;
            Scopes = scopes;
            ShortLived = shortLived;
        }

        /// <summary>
        /// The Square-issued ID of your application, available from the
        /// [application dashboard](https://connect.squareup.com/apps).
        /// </summary>
        [JsonProperty("client_id")]
        public string ClientId { get; }

        /// <summary>
        /// The Square-issued application secret for your application, available
        /// from the [application dashboard](https://connect.squareup.com/apps).
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
        /// The redirect URL assigned in the [application dashboard](https://connect.squareup.com/apps).
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
        /// A valid refresh token is required if `grant_type` is set to `refresh_token` ,
        /// to indicate the application wants a replacement for an expired OAuth access token.
        /// </summary>
        [JsonProperty("refresh_token", NullValueHandling = NullValueHandling.Ignore)]
        public string RefreshToken { get; }

        /// <summary>
        /// Legacy OAuth access token obtained using a Connect API version prior
        /// to 2019-03-13. This parameter is required if `grant_type` is set to
        /// `migration_token` to indicate that the application wants to get a replacement
        /// OAuth access token. The response also returns a refresh token.
        /// For more information, see [Migrate to Using Refresh Tokens](https://developer.squareup.com/docs/authz/oauth/migration).
        /// </summary>
        [JsonProperty("migration_token", NullValueHandling = NullValueHandling.Ignore)]
        public string MigrationToken { get; }

        /// <summary>
        /// __OPTIONAL__
        /// A JSON list of strings representing the permissions the application is requesting.
        /// For example: "`["MERCHANT_PROFILE_READ","PAYMENTS_READ","BANK_ACCOUNTS_READ"]`"
        /// The access token returned in the response is granted the permissions
        /// that comprise the intersection between the requested list of permissions, and those
        /// that belong to the provided refresh token.
        /// </summary>
        [JsonProperty("scopes", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> Scopes { get; }

        /// <summary>
        /// __OPTIONAL__
        /// A boolean indicating a request for a short-lived access token.
        /// The short-lived access token returned in the response will expire in 24 hours.
        /// </summary>
        [JsonProperty("short_lived", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ShortLived { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(ClientId,
                ClientSecret,
                GrantType)
                .Code(Code)
                .RedirectUri(RedirectUri)
                .RefreshToken(RefreshToken)
                .MigrationToken(MigrationToken)
                .Scopes(Scopes)
                .ShortLived(ShortLived);
            return builder;
        }

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

            public Builder(string clientId,
                string clientSecret,
                string grantType)
            {
                this.clientId = clientId;
                this.clientSecret = clientSecret;
                this.grantType = grantType;
            }

            public Builder ClientId(string clientId)
            {
                this.clientId = clientId;
                return this;
            }

            public Builder ClientSecret(string clientSecret)
            {
                this.clientSecret = clientSecret;
                return this;
            }

            public Builder GrantType(string grantType)
            {
                this.grantType = grantType;
                return this;
            }

            public Builder Code(string code)
            {
                this.code = code;
                return this;
            }

            public Builder RedirectUri(string redirectUri)
            {
                this.redirectUri = redirectUri;
                return this;
            }

            public Builder RefreshToken(string refreshToken)
            {
                this.refreshToken = refreshToken;
                return this;
            }

            public Builder MigrationToken(string migrationToken)
            {
                this.migrationToken = migrationToken;
                return this;
            }

            public Builder Scopes(IList<string> scopes)
            {
                this.scopes = scopes;
                return this;
            }

            public Builder ShortLived(bool? shortLived)
            {
                this.shortLived = shortLived;
                return this;
            }

            public ObtainTokenRequest Build()
            {
                return new ObtainTokenRequest(clientId,
                    clientSecret,
                    grantType,
                    code,
                    redirectUri,
                    refreshToken,
                    migrationToken,
                    scopes,
                    shortLived);
            }
        }
    }
}