
# IAuthManager Class

IAuthManager adds the authenticaion layer to the http calls.

## Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `Apply(HttpRequest httpRequest)` | Add authentication information to the HTTP Request. | [`HttpRequest`](http-request.md) |
| `ApplyAsync(HttpRequest httpRequest)` | Asynchronously add authentication information to the HTTP Request. | `Task<`[`HttpRequest`](http-request.md)`>` |

