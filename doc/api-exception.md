
# ApiException Class

This is the base class for all exceptions that represent an error response from the server.

## Properties

| Name | Description | Type |
|  --- | --- | --- |
| ResponseCode | Gets the HTTP response code from the API request. | `int` |
| HttpContext | Gets or sets the HttpContext for the request and response. | `HttpContext` |
| Errors | Gets or sets the list of errors. | `List<Models.Error>` |
| Data | Gets or sets the data about the steps that completed successfully before an error was raised. This field is currently only populated for the PaymentsApi.CreatePayment endpoint. | `object` |

## Constructors

| Name | Description |
|  --- | --- |
| `ApiException(string reason, HttpContext context)` | Initializes a new instance of the <see cref="ApiException"/> class. |

