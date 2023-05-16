
# Create Mobile Authorization Code Response

Defines the fields that are included in the response body of
a request to the `CreateMobileAuthorizationCode` endpoint.

## Structure

`CreateMobileAuthorizationCodeResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `AuthorizationCode` | `string` | Optional | The generated authorization code that connects a mobile application instance<br>to a Square account.<br>**Constraints**: *Maximum Length*: `191` |
| `ExpiresAt` | `string` | Optional | The timestamp when `authorization_code` expires, in<br>[RFC 3339](https://tools.ietf.org/html/rfc3339) format (for example, "2016-09-04T23:59:33.123Z").<br>**Constraints**: *Minimum Length*: `20`, *Maximum Length*: `48` |
| `Error` | [`Models.Error`](../../doc/models/error.md) | Optional | Represents an error encountered during a request to the Connect API.<br><br>See [Handling errors](https://developer.squareup.com/docs/build-basics/handling-errors) for more information. |

## Example (as JSON)

```json
{
  "authorization_code": "YOUR_MOBILE_AUTHORIZATION_CODE",
  "expires_at": "2019-01-10T19:42:08Z",
  "error": {
    "category": "API_ERROR",
    "code": "ADDRESS_VERIFICATION_FAILURE",
    "detail": "detail0",
    "field": "field8"
  }
}
```

