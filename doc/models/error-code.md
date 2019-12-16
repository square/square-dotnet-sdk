## Error Code

Indicates the specific error that occurred during a request to a
Square API.

### Enumeration

`ErrorCode`

### Fields

| Name | Description |
|  --- | --- |
| `INTERNALSERVERERROR` | 500 Internal Server Error - a general server error occurred. |
| `UNAUTHORIZED` | 401 Unauthorized - a general authorization error occurred. |
| `ACCESSTOKENEXPIRED` | 401 Unauthorized - the provided access token has expired. |
| `ACCESSTOKENREVOKED` | 401 Unauthorized - the provided access token has been revoked. |
| `FORBIDDEN` | 403 Forbidden - a general access error occurred. |
| `INSUFFICIENTSCOPES` | 403 Forbidden - the provided access token does not have permission<br>to execute the requested action. |
| `APPLICATIONDISABLED` | 403 Forbidden - the calling application was disabled. |
| `V1APPLICATION` | 403 Forbidden - the calling application was created prior to<br>2016-03-30 and is not compatible with v2 Square API calls. |
| `V1ACCESSTOKEN` | 403 Forbidden - the calling application is using an access token<br>created prior to 2016-03-30 and is not compatible with v2 Square API<br>calls. |
| `CARDPROCESSINGNOTENABLED` | 403 Forbidden - the location provided in the API call is not<br>enabled for credit card processing. |
| `BADREQUEST` | 400 Bad Request - a general error occurred. |
| `MISSINGREQUIREDPARAMETER` | 400 Bad Request - the request is missing a required path, query, or<br>body parameter. |
| `INCORRECTTYPE` | 400 Bad Request - the value provided in the request is the wrong<br>type. For example, a string instead of an integer. |
| `INVALIDTIME` | 400 Bad Request - formatting for the provided time value is<br>incorrect. |
| `INVALIDTIMERANGE` | 400 Bad Request - the time range provided in the request is invalid.<br>For example, the end time is before the start time. |
| `INVALIDVALUE` | 400 Bad Request - the provided value is invalid. For example,<br>including `%` in a phone number. |
| `INVALIDCURSOR` | 400 Bad Request - the pagination cursor included in the request is<br>invalid. |
| `UNKNOWNQUERYPARAMETER` | 400 Bad Request - the query parameters provided is invalid for the<br>requested endpoint. |
| `CONFLICTINGPARAMETERS` | 400 Bad Request - 1 or more of the request parameters conflict with<br>each other. |
| `EXPECTEDJSONBODY` | 400 Bad Request - the request body is not a JSON object. |
| `INVALIDSORTORDER` | 400 Bad Request - the provided sort order is not a valid key.<br>Currently, sort order must be `ASC` or `DESC`. |
| `VALUEREGEXMISMATCH` | 400 Bad Request - the provided value does not match an expected<br>regular expression. |
| `VALUETOOSHORT` | 400 Bad Request - the provided string value is shorter than the<br>minimum length allowed. |
| `VALUETOOLONG` | 400 Bad Request - the provided string value is longer than the<br>maximum length allowed. |
| `VALUETOOLOW` | 400 Bad Request - the provided value is less than the supported<br>minimum. |
| `VALUETOOHIGH` | 400 Bad Request - the provided value is greater than the supported<br>maximum. |
| `VALUEEMPTY` | 400 Bad Request - the provided value has a default (empty) value<br>such as a blank string. |
| `ARRAYLENGTHTOOLONG` | 400 Bad Request - the provided array has too many elements. |
| `ARRAYLENGTHTOOSHORT` | 400 Bad Request - the provided array has too few elements. |
| `ARRAYEMPTY` | 400 Bad Request - the provided array is empty. |
| `EXPECTEDBOOLEAN` | 400 Bad Request - the endpoint expected the provided value to be a<br>boolean. |
| `EXPECTEDINTEGER` | 400 Bad Request - the endpoint expected the provided value to be an<br>integer. |
| `EXPECTEDFLOAT` | 400 Bad Request - the endpoint expected the provided value to be a<br>float. |
| `EXPECTEDSTRING` | 400 Bad Request - the endpoint expected the provided value to be a<br>string. |
| `EXPECTEDOBJECT` | 400 Bad Request - the endpoint expected the provided value to be a<br>JSON object. |
| `EXPECTEDARRAY` | 400 Bad Request - the endpoint expected the provided value to be an<br>array or list. |
| `EXPECTEDMAP` | 400 Bad Request - the endpoint expected the provided value to be a<br>map or associative array. |
| `EXPECTEDBASE64ENCODEDBYTEARRAY` | 400 Bad Request - the endpoint expected the provided value to be an<br>array encoded in base64. |
| `INVALIDARRAYVALUE` | 400 Bad Request - 1 or more object in the array does not match the<br>array type. |
| `INVALIDENUMVALUE` | 400 Bad Request - the provided static string is not valid for the<br>field. |
| `INVALIDCONTENTTYPE` | 400 Bad Request - invalid content type header. |
| `INVALIDFORMVALUE` | 400 Bad Request - Only relevant for applications created prior to<br>2016-03-30. Indicates there was an error while parsing form values. |
| `ONEINSTRUMENTEXPECTED` | 400 Bad Request - a general error occurred. |
| `NOFIELDSSET` | 400 Bad Request - a general error occurred. |
| `CARDEXPIRED` | The card issuer declined the request because the card is expired. |
| `INVALIDEXPIRATION` | The expiration date for the payment card is invalid. For example,<br>it indicates a date in the past. |
| `INVALIDEXPIRATIONYEAR` | The expiration year for the payment card is invalid. For example,<br>it indicates a year in the past or contains invalid characters. |
| `INVALIDEXPIRATIONDATE` | The expiration date for the payment card is invalid. For example,<br>it contains invalid characters. |
| `UNSUPPORTEDCARDBRAND` | The credit card provided is not from a supported issuer. |
| `UNSUPPORTEDENTRYMETHOD` | The entry method for the credit card (swipe, dip, tap) is not supported. |
| `INVALIDENCRYPTEDCARD` | The encrypted card information is invalid. |
| `INVALIDCARD` | The credit card cannot be validated based on the provided details. |
| `GENERICDECLINE` | The credit card was decline by the issuer for an unspecified<br>reason. |
| `CVVFAILURE` | The card issuer declined the request because the CVV value is invalid. |
| `ADDRESSVERIFICATIONFAILURE` | The card issuer declined the request because the postal code is invalid. |
| `INVALIDACCOUNT` | The card issuer was not able to locate account on record. |
| `CURRENCYMISMATCH` | The currency associated with the payment is not valid for the provided<br>funding source. For example, a gift card funded in USD cannot be used to process<br>payments in GBP. |
| `INSUFFICIENTFUNDS` | The funding source has insufficient funds to cover the payment. |
| `INSUFFICIENTPERMISSIONS` | The Square account associated with the payment does not have<br>the permissions necessary to accept the payment. For example, Square may<br>limit which merchants are allowed to process gift card payments. |
| `CARDHOLDERINSUFFICIENTPERMISSIONS` | The funding source associated with the payment has limitations on<br>how it can be used. For example, it is only valid for specific merchants<br>or transaction types. |
| `INVALIDLOCATION` | The associated Square account is not allowed to take payments in this region. |
| `TRANSACTIONLIMIT` | The payment amount violates an associated transaction limit, i.e.,<br>it is too low or too high. For example, the card used is a prepaid credit<br>card. |
| `VOICEFAILURE` | The transaction was declined because the card issuer requires voice<br>authorization from the cardholder. |
| `PANFAILURE` | The specified card number is invalid. For example, it is of<br>incorrect length or is incorrectly formatted. |
| `EXPIRATIONFAILURE` | The card expiration date is either invalid or indicates that the<br>card is expired. |
| `CARDNOTSUPPORTED` | The card is not supported in the geographic region associated with<br>the Square account. For example, the card is accepted in the US but not in<br>Japan. |
| `INVALIDPIN` | The card issuer declined the request because the PIN is invalid. |
| `INVALIDPOSTALCODE` | The postal code is improperly formatted. |
| `INVALIDFEES` | The total fee amount associated with the payment is too high. |
| `MANUALLYENTEREDPAYMENTNOTSUPPORTED` | The payment was declined because manually keying-in the card<br>information is disallowed. The card must be swiped, tapped, or dipped. |
| `PAYMENTLIMITEXCEEDED` | Square declined the request because the payment amount exceeds the<br>processing limit for the associated Square account. |
| `GIFTCARDAVAILABLEAMOUNT` | A gift card payment was declined because the card had insufficient funds. |
| `DELAYEDTRANSACTIONEXPIRED` | The application tried to update a delayed-capture payment that has expired. |
| `DELAYEDTRANSACTIONCANCELED` | The application tried to cancel a delayed-capture payment that was already cancelled. |
| `DELAYEDTRANSACTIONCAPTURED` | The application tried to capture a delayed-capture payment that was already captured. |
| `DELAYEDTRANSACTIONFAILED` | The application tried to update a delayed-capture payment that failed. |
| `CARDTOKENEXPIRED` | The provided card token (nonce) has expired. |
| `CARDTOKENUSED` | The provided card token (nonce) was already used to process payment. |
| `AMOUNTTOOHIGH` | The requested payment amount is too high for the provided payment source. |
| `UNSUPPORTEDINSTRUMENTTYPE` | The API request references an unsupported instrument type/ |
| `REFUNDAMOUNTINVALID` | The requested refund amount exceeds the amount available to refund. |
| `REFUNDALREADYPENDING` | The payment already has a pending refund. |
| `PAYMENTNOTREFUNDABLE` | The payment is not refundable. For example, a previous refund has<br>already been rejected and no new refunds can be accepted. |
| `INVALIDCARDDATA` | Generic error - the provided card data is invalid. |
| `LOCATIONMISMATCH` | Generic error - the given location does not matching what is expected. |
| `IDEMPOTENCYKEYREUSED` | The provided idempotency key has already been used. |
| `UNEXPECTEDVALUE` | General error - the value provided was unexpected. |
| `SANDBOXNOTSUPPORTED` | The API request is not supported in sandbox. |
| `INVALIDEMAILADDRESS` | The provided email address is invalid. |
| `INVALIDPHONENUMBER` | The provided phone number is invalid. |
| `CHECKOUTEXPIRED` | The provided checkout URL has expired. |
| `BADCERTIFICATE` | Bad certificate. |
| `INVALIDSQUAREVERSIONFORMAT` | The provided Square-Version is incorrectly formatted. |
| `APIVERSIONINCOMPATIBLE` | The provided Square-Version is incompatibile with the requested action. |
| `INVALIDURL` | The provided API URL is invalid. |
| `HTTPSONLY` | HTTPS only. |
| `UNREACHABLEURL` | The provided URL is unreachable. |
| `CARDDECLINED` | 402 Request failed - the card was declined. |
| `VERIFYCVVFAILURE` | 402 Request failed - the CVV could not be verified. |
| `VERIFYAVSFAILURE` | 402 Request failed - the AVS could not be verified. |
| `CARDDECLINEDCALLISSUER` | 402 Request failed - the payment card was declined with a request<br>for the card holder to call the issuer. |
| `CARDDECLINEDVERIFICATIONREQUIRED` | 402 Request failed - the payment card was declined with a request<br>for additional verification. |
| `BADEXPIRATION` | 402 Request failed - the card expiration date is either missing or<br>incorrectly formatted. |
| `CHIPINSERTIONREQUIRED` | 402 Request failed - the card issuer requires that the card be read<br>using a chip reader. |
| `ALLOWABLEPINTRIESEXCEEDED` | 402 Request failed - the card has exhausted its available pin entry<br>retries set by the card issuer. Resolving the error typically requires the<br>card holder to contact the card issuer. |
| `RESERVATIONDECLINED` | 402 Request failed - The card issuer declined the refund. |
| `NOTFOUND` | 404 Not Found - a general error occurred. |
| `APPLEPAYMENTPROCESSINGCERTIFICATEHASHNOTFOUND` | 404 Not Found - Square could not find the associated Apple Pay certificate. |
| `METHODNOTALLOWED` | 405 Method Not Allowed - a general error occurred. |
| `NOTACCEPTABLE` | 406 Not Acceptable - a general error occurred. |
| `REQUESTTIMEOUT` | 408 Request Timeout - a general error occurred. |
| `CONFLICT` | 409 Conflict - a general error occurred. |
| `GONE` | 410 Gone - the target resource is no longer available and this<br>condition is likely to be permanent.. |
| `REQUESTENTITYTOOLARGE` | 413 Request Entity Too Large - a general error occurred. |
| `UNSUPPORTEDMEDIATYPE` | 415 Unsupported Media Type - a general error occurred. |
| `UNPROCESSABLEENTITY` | 422 Unprocessable Entity - a general error occurred. |
| `RATELIMITED` | 429 Rate Limited - a general error occurred. |
| `NOTIMPLEMENTED` | 501 Not Implemented - a general error occurred. |
| `BADGATEWAY` | 502 Bad Gateway - a general error occurred. |
| `SERVICEUNAVAILABLE` | 503 Service Unavailable - a general error occurred. |
| `TEMPORARYERROR` | A temporary internal error occurred. You can safely retry your call<br>using the same idempotency key. |
| `GATEWAYTIMEOUT` | 504 Gateway Timeout - a general error occurred. |

