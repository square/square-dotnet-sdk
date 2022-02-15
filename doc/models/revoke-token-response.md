
# Revoke Token Response

## Structure

`RevokeTokenResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Success` | `bool?` | Optional | If the request is successful, this is `true`. |
| `Errors` | [`IList<Models.Error>`](/doc/models/error.md) | Optional | An error object that provides details about how creation of the obtain<br>token failed. |

## Example (as JSON)

```json
{
  "success": true
}
```

