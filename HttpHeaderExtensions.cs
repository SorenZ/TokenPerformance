using Microsoft.AspNetCore.Http;

namespace TokenPerformance;

public static class HttpHeaderExtensions
{
    public static string GetAuthorizationTokenValue(this IHeaderDictionary headers,
        string headerName = "Authorization",
        string expectedSchema = "Bearer")
    {
        ArgumentNullException.ThrowIfNull(headers);

        if (!headers.TryGetValue(headerName, out var authHeaders))
            throw new ArgumentException($"Couldn't find '{headerName}' in the headers");

        var authSchema = authHeaders[0][..expectedSchema.Length];
        if (!authSchema.Equals(expectedSchema, StringComparison.OrdinalIgnoreCase))
            throw new FormatException($"Schema format exception; expected: '{expectedSchema}' but got '{authSchema}'");
        
        return authHeaders[0][(expectedSchema.Length + 1)..];
    }
    
    public static string SimpleHeader(IHeaderDictionary headers)
    {
        if (headers.ContainsKey("Authorization") &&
            headers["Authorization"][0].StartsWith("Bearer "))
        {
            return headers["Authorization"][0]
                .Substring("Bearer ".Length);
            //do stuff...
        }

        return null;
    }
    
    public static string GetAuthTokenValue(this IHeaderDictionary headers, 
        string headerName = "Authorization",
        string expectedSchema = "Bearer")
    {
        if (!headers.TryGetValue(headerName, out var authHeaders))
            throw new ArgumentException($"Couldn't find '{headerName}' in the headers");
        
        if(authHeaders[0].StartsWith(expectedSchema))
            return authHeaders[0][(expectedSchema.Length + 1)..];
        
        throw new FormatException($"Schema format exception; expected: '{expectedSchema}");
    }
}
