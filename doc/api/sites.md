# Sites

```csharp
ISitesApi sitesApi = client.SitesApi;
```

## Class Name

`SitesApi`


# List Sites

Lists the Square Online sites that belong to a seller.

__Note:__ Square Online APIs are publicly available as part of an early access program. For more information, see [Early access program for Square Online APIs](https://developer.squareup.com/docs/online-api#early-access-program-for-square-online-apis).

```csharp
ListSitesAsync()
```

## Response Type

[`Task<Models.ListSitesResponse>`](/doc/models/list-sites-response.md)

## Example Usage

```csharp
try
{
    ListSitesResponse result = await sitesApi.ListSitesAsync();
}
catch (ApiException e){};
```

