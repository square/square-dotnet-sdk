using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIMatic.Core.Authentication;
using Square.Legacy.Http.Request;

namespace Square.Legacy.Authentication
{
    /// <summary>
    /// BearerAuthManager.
    /// </summary>
    internal class BearerAuthManager : AuthManager, IBearerAuthCredentials
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BearerAuthManager"/> class.
        /// </summary>
        /// <param name="bearerAuthModel">BearerAuthModel.</param>
        public BearerAuthManager(BearerAuthModel bearerAuthModel)
        {
            this.AccessToken = bearerAuthModel?.AccessToken;
            Parameters(paramBuilder =>
                paramBuilder.Header(header =>
                    header
                        .Setup(
                            "Authorization",
                            this.AccessToken == null ? null : $"Bearer {this.AccessToken}"
                        )
                        .Required()
                )
            );
        }

        /// <summary>
        /// Gets string value for accessToken.
        /// </summary>
        public string AccessToken { get; }

        /// <summary>
        /// Check if credentials match.
        /// </summary>
        /// <param name="accessToken"> The string value for credentials.</param>
        /// <returns> True if credentials matched.</returns>
        public bool Equals(string accessToken)
        {
            return accessToken.Equals(this.AccessToken);
        }
    }

    public sealed class BearerAuthModel
    {
        internal BearerAuthModel() { }

        internal string AccessToken { get; set; }

        /// <summary>
        /// Creates an object of the BearerAuthModel using the values provided for the builder.
        /// </summary>
        /// <returns>Builder.</returns>
        public Builder ToBuilder()
        {
            return new Builder(AccessToken);
        }

        /// <summary>
        /// Builder class for BearerAuthModel.
        /// </summary>
        public class Builder
        {
            private string accessToken;

            public Builder(string accessToken)
            {
                this.accessToken =
                    accessToken ?? throw new ArgumentNullException(nameof(accessToken));
            }

            /// <summary>
            /// Sets AccessToken.
            /// </summary>
            /// <param name="accessToken">AccessToken.</param>
            /// <returns>Builder.</returns>
            public Builder AccessToken(string accessToken)
            {
                this.accessToken =
                    accessToken ?? throw new ArgumentNullException(nameof(accessToken));
                return this;
            }

            /// <summary>
            /// Creates an object of the BearerAuthModel using the values provided for the builder.
            /// </summary>
            /// <returns>BearerAuthModel.</returns>
            public BearerAuthModel Build()
            {
                return new BearerAuthModel() { AccessToken = this.accessToken };
            }
        }
    }
}
