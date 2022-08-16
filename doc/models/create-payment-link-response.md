
# Create Payment Link Response

## Structure

`CreatePaymentLinkResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Errors` | [`IList<Models.Error>`](../../doc/models/error.md) | Optional | Any errors that occurred during the request. |
| `PaymentLink` | [`Models.PaymentLink`](../../doc/models/payment-link.md) | Optional | - |
| `RelatedResources` | [`Models.PaymentLinkRelatedResources`](../../doc/models/payment-link-related-resources.md) | Optional | - |

## Example (as JSON)

```json
{
  "errors": null,
  "payment_link": null,
  "related_resources": null
}
```

