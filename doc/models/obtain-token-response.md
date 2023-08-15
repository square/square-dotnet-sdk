
# Obtain Token Response

## Structure

`ObtainTokenResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `AccessToken` | `string` | Optional | A valid OAuth access token. OAuth access tokens are 64 bytes long.<br>Provide the access token in a header with every request to Connect API<br>endpoints. For more information, see [OAuth API: Walkthrough](https://developer.squareup.com/docs/oauth-api/walkthrough).<br>**Constraints**: *Minimum Length*: `2`, *Maximum Length*: `1024` |
| `TokenType` | `string` | Optional | This value is always _bearer_.<br>**Constraints**: *Minimum Length*: `2`, *Maximum Length*: `10` |
| `ExpiresAt` | `string` | Optional | The date when the `access_token` expires, in [ISO 8601](http://www.iso.org/iso/home/standards/iso8601.htm) format.<br>**Constraints**: *Minimum Length*: `20`, *Maximum Length*: `48` |
| `MerchantId` | `string` | Optional | The ID of the authorizing merchant's business.<br>**Constraints**: *Minimum Length*: `8`, *Maximum Length*: `191` |
| `SubscriptionId` | `string` | Optional | __LEGACY FIELD__. The ID of a subscription plan the merchant signed up<br>for. The ID is only present if the merchant signed up for a subscription plan during authorization. |
| `PlanId` | `string` | Optional | __LEGACY FIELD__. The ID of the subscription plan the merchant signed<br>up for. The ID is only present if the merchant signed up for a subscription plan during<br>authorization. |
| `IdToken` | `string` | Optional | The OpenID token belonging to this person. This token is only present if the<br>OPENID scope is included in the authorization request. |
| `RefreshToken` | `string` | Optional | A refresh token. OAuth refresh tokens are 64 bytes long.<br>For more information, see [Refresh, Revoke, and Limit the Scope of OAuth Tokens](https://developer.squareup.com/docs/oauth-api/refresh-revoke-limit-scope).<br>**Constraints**: *Minimum Length*: `2`, *Maximum Length*: `1024` |
| `ShortLived` | `bool?` | Optional | A Boolean indicating that the access token is a short-lived access token.<br>The short-lived access token returned in the response expires in 24 hours. |
| `Errors` | [`IList<Error>`](../../doc/models/error.md) | Optional | Any errors that occurred during the request. |
| `RefreshTokenExpiresAt` | `string` | Optional | The date when the `refresh_token` expires, in [ISO 8601](http://www.iso.org/iso/home/standards/iso8601.htm) format.<br>**Constraints**: *Minimum Length*: `20`, *Maximum Length*: `48` |

## Example (as JSON)

```json
{
  "access_token": "ACCESS_TOKEN",
  "expires_at": "2006-01-02T15:04:05Z",
  "merchant_id": "MERCHANT_ID",
  "refresh_token": "REFRESH_TOKEN",
  "token_type": "bearer",
  "subscription_id": "subscription_id0"
}
```

