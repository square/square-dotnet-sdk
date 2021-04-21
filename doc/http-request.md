
# HttpRequest Class

HttpResponse stores necessary information about the http response.

## Properties

| Name | Description | Type |
|  --- | --- | --- |
| StatusCode | Gets the HTTP Status code of the http response. | `int` |
| Headers | Gets the headers of the http response. | `Dictionary<string, string>` |
| RawBody | Gets the stream of the body. | `Stream` |

## Constructors

| Name | Description |
|  --- | --- |
| `HttpRequest(HttpMethod method, string queryUrl)` | Constructor to initialize the http request object. |
| `HttpRequest(HttpMethod method, string queryUrl, Dictionary<string, string> headers, string username, string password, Dictionary<string, object> queryParameters = null)` | Constructor to initialize the http request with headers and optional Basic auth params. |
| `HttpRequest(HttpMethod method, string queryUrl, Dictionary<string, string> headers, object body, string username, string password, Dictionary<string, object> queryParameters = null)` | Constructor to initialize the http request with headers, body and optional Basic auth params. |
| `HttpRequest(HttpMethod method, string queryUrl, Dictionary<string, string> headers, List<KeyValuePair<string, Object>> formParameters, string username, string password, Dictionary<string, object> queryParameters = null)` | Constructor to initialize the http request with headers, form parameters and optional Basic auth params. |

## Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `AddHeaders(Dictionary<string, string> HeadersToAdd)` | Concatenate values from a Dictionary to this object. | `Dictionary<string, string>` |
| `AddQueryParameters(Dictionary<string, object> queryParamaters)` | Concatenate values from a Dictionary to query parameters dictionary. | `void` |

