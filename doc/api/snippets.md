# Snippets

```csharp
ISnippetsApi snippetsApi = client.SnippetsApi;
```

## Class Name

`SnippetsApi`

## Methods

* [Delete Snippet](../../doc/api/snippets.md#delete-snippet)
* [Retrieve Snippet](../../doc/api/snippets.md#retrieve-snippet)
* [Upsert Snippet](../../doc/api/snippets.md#upsert-snippet)


# Delete Snippet

Removes your snippet from a Square Online site.

You can call [ListSites](../../doc/api/sites.md#list-sites) to get the IDs of the sites that belong to a seller.

__Note:__ Square Online APIs are publicly available as part of an early access program. For more information, see [Early access program for Square Online APIs](https://developer.squareup.com/docs/online-api#early-access-program-for-square-online-apis).

```csharp
DeleteSnippetAsync(
    string siteId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `siteId` | `string` | Template, Required | The ID of the site that contains the snippet. |

## Response Type

[`Task<Models.DeleteSnippetResponse>`](../../doc/models/delete-snippet-response.md)

## Example Usage

```csharp
string siteId = "site_id6";

try
{
    DeleteSnippetResponse result = await snippetsApi.DeleteSnippetAsync(siteId);
}
catch (ApiException e){};
```


# Retrieve Snippet

Retrieves your snippet from a Square Online site. A site can contain snippets from multiple snippet applications, but you can retrieve only the snippet that was added by your application.

You can call [ListSites](../../doc/api/sites.md#list-sites) to get the IDs of the sites that belong to a seller.

__Note:__ Square Online APIs are publicly available as part of an early access program. For more information, see [Early access program for Square Online APIs](https://developer.squareup.com/docs/online-api#early-access-program-for-square-online-apis).

```csharp
RetrieveSnippetAsync(
    string siteId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `siteId` | `string` | Template, Required | The ID of the site that contains the snippet. |

## Response Type

[`Task<Models.RetrieveSnippetResponse>`](../../doc/models/retrieve-snippet-response.md)

## Example Usage

```csharp
string siteId = "site_id6";

try
{
    RetrieveSnippetResponse result = await snippetsApi.RetrieveSnippetAsync(siteId);
}
catch (ApiException e){};
```


# Upsert Snippet

Adds a snippet to a Square Online site or updates the existing snippet on the site.
The snippet code is appended to the end of the `head` element on every page of the site, except checkout pages. A snippet application can add one snippet to a given site.

You can call [ListSites](../../doc/api/sites.md#list-sites) to get the IDs of the sites that belong to a seller.

__Note:__ Square Online APIs are publicly available as part of an early access program. For more information, see [Early access program for Square Online APIs](https://developer.squareup.com/docs/online-api#early-access-program-for-square-online-apis).

```csharp
UpsertSnippetAsync(
    string siteId,
    Models.UpsertSnippetRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `siteId` | `string` | Template, Required | The ID of the site where you want to add or update the snippet. |
| `body` | [`Models.UpsertSnippetRequest`](../../doc/models/upsert-snippet-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.UpsertSnippetResponse>`](../../doc/models/upsert-snippet-response.md)

## Example Usage

```csharp
string siteId = "site_id6";
var bodySnippet = new Snippet.Builder(
        "<script>var js = 1;</script>")
    .Id("id4")
    .SiteId("site_id0")
    .CreatedAt("created_at8")
    .UpdatedAt("updated_at0")
    .Build();
var body = new UpsertSnippetRequest.Builder(
        bodySnippet)
    .Build();

try
{
    UpsertSnippetResponse result = await snippetsApi.UpsertSnippetAsync(siteId, body);
}
catch (ApiException e){};
```

