
# HttpClientConfiguration Builder Class

Class to build instances of HttpClientConfiguration.

## Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `Timeout(TimeSpan timeout)` | Http client timeout. | `Builder` |
| `NumberOfRetries(int numberOfRetries)` | Number of times the request is retried. | `Builder` |
| `BackoffFactor(int backoffFactor)` | Exponential backoff factor for duration between retry calls. | `Builder` |
| `RetryInterval(double retryInterval)` | The time interval between the endpoint calls. | `Builder` |
| `MaximumRetryWaitTime(TimeSpan maximumRetryWaitTime)` | The maximum retry wait time. | `Builder` |
| `StatusCodesToRetry(IList<int> statusCodesToRetry)` | List of Http status codes to invoke retry. | `Builder` |
| `RequestMethodsToRetry(IList<HttpMethod> requestMethodsToRetry)` | List of Http request methods to invoke retry. | `Builder` |
| `Build()` | Builds a new HttpClientConfiguration object using the set fields. | `HttpClientConfiguration` |

