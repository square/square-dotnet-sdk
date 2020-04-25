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
            string migrationToken = null)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            Code = code;
            RedirectUri = redirectUri;
            GrantType = grantType;
            RefreshToken = refreshToken;
            MigrationToken = migrationToken;
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
        [JsonProperty("code")]
        public string Code { get; }

        /// <summary>
        /// The redirect URL assigned in the [application dashboard](https://connect.squareup.com/apps).
        /// </summary>
        [JsonProperty("redirect_uri")]
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
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; }

        /// <summary>
        /// Legacy OAuth access token obtained using a Connect API version prior
        /// to 2019-03-13. This parameter is required if `grant_type` is set to
        /// `migration_token` to indicate that the application wants to get a replacement
        /// OAuth access token. The response also returns a refresh token.
        /// For more information, see [Migrate to Using Refresh Tokens](https://developer.squareup.com/docs/authz/oauth/migration).
        /// </summary>
        [JsonProperty("migration_token")]
        public string MigrationToken { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(ClientId,
                ClientSecret,
                GrantType)
                .Code(Code)
                .RedirectUri(RedirectUri)
                .RefreshToken(RefreshToken)
                .MigrationToken(MigrationToken);
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

            public Builder(string clientId,
                string clientSecret,
                string grantType)
            {
                this.clientId = clientId;
                this.clientSecret = clientSecret;
                this.grantType = grantType;
            }
            public Builder ClientId(string value)
            {
                clientId = value;
                return this;
            }

            public Builder ClientSecret(string value)
            {
                clientSecret = value;
                return this;
            }

            public Builder GrantType(string value)
            {
                grantType = value;
                return this;
            }

            public Builder Code(string value)
            {
                code = value;
                return this;
            }

            public Builder RedirectUri(string value)
            {
                redirectUri = value;
                return this;
            }

            public Builder RefreshToken(string value)
            {
                refreshToken = value;
                return this;
            }

            public Builder MigrationToken(string value)
            {
                migrationToken = value;
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
                    migrationToken);
            }
        }
    }
}