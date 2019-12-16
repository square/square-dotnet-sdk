## Error Category

Indicates which high-level category of error has occurred during a
request to the Connect API.

### Enumeration

`ErrorCategory`

### Fields

| Name | Description |
|  --- | --- |
| `APIERROR` | An error occurred with the Connect API itself. |
| `AUTHENTICATIONERROR` | An authentication error occurred. Most commonly, the request had<br>a missing, malformed, or otherwise invalid `Authorization` header. |
| `INVALIDREQUESTERROR` | The request was invalid. Most commonly, a required parameter was<br>missing, or a provided parameter had an invalid value. |
| `RATELIMITERROR` | Your application reached the Connect API rate limit. Retry your<br>request after a while. |
| `PAYMENTMETHODERROR` | An error occurred while processing a payment method. Most commonly,<br>the details of the payment method were invalid (such as a card's CVV<br>or expiration date). |
| `REFUNDERROR` | An error occurred while attempting to process a refund. |

