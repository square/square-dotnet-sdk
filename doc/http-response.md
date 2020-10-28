
# HttpResponse Class

HttpResponse stores necessary information about the http response.

## Properties

| Name | Description | Type |
|  --- | --- | --- |
| StatusCode | HTTP Status code of the http response. | `int` |
| Headers | Headers of the http response. | `Dictionary<string, string>` |
| RawBody | Stream of the body. | `Stream` |

## Constructors

| Name | Description |
|  --- | --- |
| `HttpResponse(int statusCode, Dictionary<string, string> headers, Stream rawBody)` | Initializes a new HttpResponse object with the specified parameters. |

