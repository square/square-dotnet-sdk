
# Revoke Token Response

## Structure

`RevokeTokenResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Success` | `bool?` | Optional | If the request is successful, this is `true`. |
| `Errors` | [`IList<Models.Error>`](../../doc/models/error.md) | Optional | Any errors that occurred during the request. |

## Example (as JSON)

```json
{
  "success": true
}
```

