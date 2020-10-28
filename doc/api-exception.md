
# ApiException Class

This is the base class for all exceptions that represent an error response from the server.

## Properties

| Name | Description | Type |
|  --- | --- | --- |
| ResponseCode | The HTTP response code from the API request. | `int` |
| HttpContext | HttpContext stores the request and response. | `HttpContext` |
| Errors | Stores the list of errors. | `List<Models.Error>` |

## Constructors

| Name | Description |
|  --- | --- |
| `ApiException(string reason, HttpContext context)` | Initializes a new ApiException object with the specified parameters. |

