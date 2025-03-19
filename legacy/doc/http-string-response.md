
# HttpStringResponse Class

HttpStringResponse inherits from HttpResponse and has additional property of string body.

## Properties

| Name | Description | Type |
|  --- | --- | --- |
| StatusCode | Gets the HTTP Status code of the http response. | `int` |
| Headers | Gets the headers of the http response. | `Dictionary<string, string>` |
| Body | Gets the raw string body of the http response. | `string` |

## Constructors

| Name | Description |
|  --- | --- |
| `HttpStringResponse(int statusCode, Dictionary<string, string> headers, Stream rawBody, string body) : base(statusCode, headers, rawBody)` | Initializes a new instance of the <see cref="HttpStringResponse"/> class. |

