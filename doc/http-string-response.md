
# HttpStringResponse Class

HttpStringResponse inherits from HttpResponse and has additional property of string body.

## Properties

| Name | Description | Type |
|  --- | --- | --- |
| StatusCode | HTTP Status code of the http response. | `int` |
| Headers | Headers of the http response. | `Dictionary<string, string>` |
| Body | Raw string body of the http response. | `string` |

## Constructors

| Name | Description |
|  --- | --- |
| `HttpStringResponse(int statusCode, Dictionary<string, string> headers, Stream rawBody, string body) : base(statusCode, headers, rawBody)` | Initializes a new HttpStringResponse object with the specified parameters. |

