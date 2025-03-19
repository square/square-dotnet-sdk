using System.Text.Json;
using Square.Core;

namespace Square;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
public class SquareApiException : SquareException
{
    private static readonly Error FallbackError = new()
    {
        Category = ErrorCategory.FromCustom("V1_ERROR"),
        Code = ErrorCode.FromCustom("Unknown"),
    };

    private static readonly IReadOnlyList<Error> FallbackErrors = new List<Error> { FallbackError };

    /// <summary>
    /// The error code of the response that triggered the exception.
    /// </summary>
    public int StatusCode { get; }

    /// <summary>
    /// The body of the response that triggered the exception.
    /// </summary>
    public object Body { get; }

    /// <summary>
    /// The parsed error objects from the response.
    /// </summary>
    public IReadOnlyList<Error> Errors { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SquareApiException"/> class.
    /// </summary>
    /// <param name="message">The error message.</param>
    /// <param name="statusCode">The HTTP status code.</param>
    /// <param name="body">The response body.</param>
    public SquareApiException(string message, int statusCode, object body)
        : base(BuildMessage(message, statusCode, body, out var json))
    {
        StatusCode = statusCode;
        Body = body;
        Errors = ParseErrors(json);
    }

    public static string BuildMessage(
        string message,
        int statusCode,
        object body,
        out JsonElement jsonElement
    )
    {
        string bodyString;
        if (body is string s)
        {
            bodyString = s;
            jsonElement = JsonUtils.Deserialize<JsonElement>(bodyString);
        }
        else
        {
            bodyString = JsonUtils.Serialize(body);
            jsonElement = JsonUtils.SerializeToElement(body);
        }

        return $"""
            {message}
            Status code: {statusCode.ToString()}
            Body: {bodyString}
            """;
    }

    private static IReadOnlyList<Error> ParseErrors(JsonElement json)
    {
        if (json.TryGetProperty("errors", out var errorsElement))
        {
            var errors = new List<Error>();
            foreach (var errorElement in errorsElement.EnumerateArray())
            {
                var error = new Error
                {
                    Category = ErrorCategory.ApiError,
                    Code = ErrorCode.FromCustom("Unknown"),
                };
                if (errorElement.TryGetProperty("category", out var category))
                {
                    var categoryString = category.GetString();
                    if (categoryString != null)
                    {
                        error.Category = new ErrorCategory(categoryString);
                    }
                }

                if (errorElement.TryGetProperty("code", out var code))
                {
                    var codeString = code.GetString();
                    if (codeString != null)
                    {
                        error.Code = ErrorCode.FromCustom(codeString);
                    }
                }

                if (errorElement.TryGetProperty("detail", out var detail))
                {
                    error.Detail = detail.GetString();
                }

                if (errorElement.TryGetProperty("field", out var field))
                {
                    error.Field = field.GetString();
                }

                errors.Add(error);
            }

            return errors.Count > 0 ? errors : FallbackErrors;
        }

        if (
            json.TryGetProperty("type", out var typeElement)
            && json.TryGetProperty("message", out var messageElement)
            && json.TryGetProperty("field", out var fieldElement)
        )
        {
            var v1Error = new Error
            {
                Category = ErrorCategory.FromCustom("V1_ERROR"),
                Code = ErrorCode.FromCustom(typeElement.GetString() ?? "Unknown"),
                Detail = messageElement.GetString(),
                Field = fieldElement.GetString(),
            };
            return new List<Error> { v1Error };
        }

        return FallbackErrors;
    }
}
