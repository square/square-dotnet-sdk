
# Utility Classes Documentation

## ApiHelper Class

HttpRequest stores necessary information about the http request.

### Properties

| Name | Description | Type |
|  --- | --- | --- |
| HttpMethod | The HTTP verb to use for this request. | `HttpMethod` |
| QueryUrl | The query url for the http request. | `string` |
| QueryParameters | Query parameters collection for the current http request. | `Dictionary<string, object>` |
| Headers | Headers collection for the current http request. | `Dictionary<string, string>` |
| FormParameters | Form parameters for the current http request. | `List<KeyValuePair<string, object>>` |
| Body | Optional raw string to send as request body. | `object` |
| Username | Optional username for Basic Auth. | `string` |
| Password | Optional password for Basic Auth. | `string` |

### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `DeepCloneObject<T>(T obj)` | Creates a deep clone of an object by serializing it into a json string and then deserializing back into an object. | `T` |
| `JsonSerialize(object obj, JsonConverter converter = null)` | JSON Serialization of a given object. | `string` |
| `JsonDeserialize<T>(string json, JsonConverter converter = null)` | JSON Deserialization of the given json string. | `T` |

## JsonObject Class

Class to wrap JSON object.

### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `FromJsonString(string json)` | Initializes JsonObject instance with JSON string. | `JsonObject` |
| `GetStoredObject()` | Getter for the stored JSON object. | `JToken` |
| `ToString()` | String representation of the stored JSON. | `string` |

## JsonValue Class

Class to wrap any JSON value.

### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `FromString(string value)` | Initializes JsonValue instance with string value. | `JsonValue` |
| `FromBoolean(bool? value)` | Initializes JsonValue instance with boolean value. | `JsonValue` |
| `FromInteger(int? value)` | Initializes JsonValue instance with integer value. | `JsonValue` |
| `FromDouble(double? value)` | Initializes JsonValue instance with double value. | `JsonValue` |
| `FromLong(long? value)` | Initializes JsonValue instance with long value. | `JsonValue` |
| `FromObject(object value)` | Initializes JsonValue instance with any object value. | `JsonValue` |
| `FromArray<T>(List<T> values)` | Initializes JsonValue instance with an array of the given type. | `JsonValue` |
| `GetStoredObject()` | Getter for the stored object. | `object` |
| `ToString()` | String representation of the stored JSON. | `string` |

## HttpCallback Class

Class to provide callbacks for the Http request and response of an API call.

### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `OnBeforeRequest(HttpRequest request)` | Override to provide callback for the Http request. | `void` |
| `OnAfterResponse(HttpResponse response)` | Override to provide callback for the Http response. | `void` |

