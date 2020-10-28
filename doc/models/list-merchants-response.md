
# List Merchants Response

The response object returned by the [ListMerchant](#endpoint-listmerchant) endpoint.

## Structure

`ListMerchantsResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Errors` | [`IList<Models.Error>`](/doc/models/error.md) | Optional | Information on errors encountered during the request. |
| `Merchant` | [`IList<Models.Merchant>`](/doc/models/merchant.md) | Optional | The requested `Merchant` entities. |
| `Cursor` | `int?` | Optional | If the  response is truncated, the cursor to use in next  request to fetch next set of objects. |

## Example (as JSON)

```json
{
  "merchant": [
    {
      "business_name": "Apple A Day",
      "country": "US",
      "currency": "USD",
      "id": "DM7VKY8Q63GNP",
      "language_code": "en-US",
      "main_location_id": "9A65CGC72ZQG1",
      "status": "ACTIVE"
    }
  ]
}
```

