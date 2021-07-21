
# HttpClientConfiguration Class

HttpClientConfiguration represents the current state of the Http Client.

## Properties

| Name | Description | Type |
|  --- | --- | --- |
| Timeout | Http client timeout. | `TimeSpan` |
| NumberOfRetries | Number of times the request is retried. | `int` |
| BackoffFactor | Exponential backoff factor for duration between retry calls. | `int` |
| RetryInterval | The time interval between the endpoint calls. | `double` |
| MaximumRetryWaitTime | The maximum retry wait time. | `TimeSpan` |
| StatusCodesToRetry | List of Http status codes to invoke retry. | `IList<int>` |
| RequestMethodsToRetry | List of Http request methods to invoke retry. | `IList<HttpMethod>` |
| HttpClientInstance | HttpClient instance used to make the HTTP calls | `HttpClient` |
| OverrideHttpClientConfiguration | Boolean which allows the SDK to override http client instance's settings used for features like retries, timeouts etc. | `bool` |

## Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `ToBuilder()` | Creates an object of the HttpClientConfiguration using the values provided for the builder. | `Builder` |

