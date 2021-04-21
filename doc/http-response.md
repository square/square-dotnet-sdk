
# HttpResponse Class

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
| `HttpResponse(int statusCode, Dictionary<string, string> headers, Stream rawBody)` | Initializes a new instance of the <see cref="HttpResponse"/> class. |

