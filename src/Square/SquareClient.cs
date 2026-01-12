using Square.Core;
using Square.Default;

namespace Square;

public partial class SquareClient : ISquareClient
{
    private readonly RawClient _client;

    public SquareClient(string? token = null, ClientOptions? clientOptions = null)
    {
        token ??= GetFromEnvironmentOrThrow(
            "SQUARE_TOKEN",
            "Please pass in token or set the environment variable SQUARE_TOKEN."
        );
        var defaultHeaders = new Headers(
            new Dictionary<string, string>()
            {
                { "Authorization", $"Bearer {token}" },
                { "Square-Version", "2025-10-16" },
                { "X-Fern-Language", "C#" },
                { "X-Fern-SDK-Name", "Square" },
                { "X-Fern-SDK-Version", Version.Current },
                { "User-Agent", "Square/42.2.2" },
            }
        );
        clientOptions ??= new ClientOptions();
        if (clientOptions.Version != null)
        {
            defaultHeaders["Square-Version"] = clientOptions.Version;
        }
        foreach (var header in defaultHeaders)
        {
            if (!clientOptions.Headers.ContainsKey(header.Key))
            {
                clientOptions.Headers[header.Key] = header.Value;
            }
        }
        _client = new RawClient(clientOptions);
        Default = new DefaultClient(_client);
    }

    public DefaultClient Default { get; }

    private static string GetFromEnvironmentOrThrow(string env, string message)
    {
        return Environment.GetEnvironmentVariable(env) ?? throw new Exception(message);
    }
}
