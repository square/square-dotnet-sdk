# Team

```csharp
ITeamApi teamApi = client.TeamApi;
```

## Class Name

`TeamApi`

## Methods

* [Create Team Member](../../doc/api/team.md#create-team-member)
* [Bulk Create Team Members](../../doc/api/team.md#bulk-create-team-members)
* [Bulk Update Team Members](../../doc/api/team.md#bulk-update-team-members)
* [Search Team Members](../../doc/api/team.md#search-team-members)
* [Retrieve Team Member](../../doc/api/team.md#retrieve-team-member)
* [Update Team Member](../../doc/api/team.md#update-team-member)
* [Retrieve Wage Setting](../../doc/api/team.md#retrieve-wage-setting)
* [Update Wage Setting](../../doc/api/team.md#update-wage-setting)


# Create Team Member

Creates a single `TeamMember` object. The `TeamMember` object is returned on successful creates.
You must provide the following values in your request to this endpoint:

- `given_name`
- `family_name`

Learn about [Troubleshooting the Team API](../../https://developer.squareup.com/docs/team/troubleshooting#createteammember).

```csharp
CreateTeamMemberAsync(
    Models.CreateTeamMemberRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.CreateTeamMemberRequest`](../../doc/models/create-team-member-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.CreateTeamMemberResponse>`](../../doc/models/create-team-member-response.md)

## Example Usage

```csharp
var bodyTeamMemberAssignedLocationsLocationIds = new IList<string>();
bodyTeamMemberAssignedLocationsLocationIds.Add("YSGH2WBKG94QZ");
bodyTeamMemberAssignedLocationsLocationIds.Add("GA2Y9HSJ8KRYT");
var bodyTeamMemberAssignedLocations = new TeamMemberAssignedLocations.Builder()
    .AssignmentType("EXPLICIT_LOCATIONS")
    .LocationIds(bodyTeamMemberAssignedLocationsLocationIds)
    .Build();
var bodyTeamMember = new TeamMember.Builder()
    .Id("id2")
    .ReferenceId("reference_id_1")
    .IsOwner(false)
    .Status("ACTIVE")
    .GivenName("Joe")
    .FamilyName("Doe")
    .EmailAddress("joe_doe@gmail.com")
    .PhoneNumber("+14159283333")
    .AssignedLocations(bodyTeamMemberAssignedLocations)
    .Build();
var body = new CreateTeamMemberRequest.Builder()
    .IdempotencyKey("idempotency-key-0")
    .TeamMember(bodyTeamMember)
    .Build();

try
{
    CreateTeamMemberResponse result = await teamApi.CreateTeamMemberAsync(body);
}
catch (ApiException e){};
```


# Bulk Create Team Members

Creates multiple `TeamMember` objects. The created `TeamMember` objects are returned on successful creates.
This process is non-transactional and processes as much of the request as possible. If one of the creates in
the request cannot be successfully processed, the request is not marked as failed, but the body of the response
contains explicit error information for the failed create.

Learn about [Troubleshooting the Team API](../../https://developer.squareup.com/docs/team/troubleshooting#bulk-create-team-members).

```csharp
BulkCreateTeamMembersAsync(
    Models.BulkCreateTeamMembersRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.BulkCreateTeamMembersRequest`](../../doc/models/bulk-create-team-members-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.BulkCreateTeamMembersResponse>`](../../doc/models/bulk-create-team-members-response.md)

## Example Usage

```csharp
var bodyTeamMembers = new Dictionary<string, CreateTeamMemberRequest>();


var bodyTeamMembers0 = new CreateTeamMemberRequest.Builder()
    .Build();
bodyTeamMembers.Add("",bodyTeamMembers0);

var bodyTeamMembers1 = new CreateTeamMemberRequest.Builder()
    .Build();
bodyTeamMembers.Add("",bodyTeamMembers1);

var body = new BulkCreateTeamMembersRequest.Builder(
        bodyTeamMembers)
    .Build();

try
{
    BulkCreateTeamMembersResponse result = await teamApi.BulkCreateTeamMembersAsync(body);
}
catch (ApiException e){};
```


# Bulk Update Team Members

Updates multiple `TeamMember` objects. The updated `TeamMember` objects are returned on successful updates.
This process is non-transactional and processes as much of the request as possible. If one of the updates in
the request cannot be successfully processed, the request is not marked as failed, but the body of the response
contains explicit error information for the failed update.
Learn about [Troubleshooting the Team API](../../https://developer.squareup.com/docs/team/troubleshooting#bulk-update-team-members).

```csharp
BulkUpdateTeamMembersAsync(
    Models.BulkUpdateTeamMembersRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.BulkUpdateTeamMembersRequest`](../../doc/models/bulk-update-team-members-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.BulkUpdateTeamMembersResponse>`](../../doc/models/bulk-update-team-members-response.md)

## Example Usage

```csharp
var bodyTeamMembers = new Dictionary<string, UpdateTeamMemberRequest>();


var bodyTeamMembers0 = new UpdateTeamMemberRequest.Builder()
    .Build();
bodyTeamMembers.Add("",bodyTeamMembers0);

var bodyTeamMembers1 = new UpdateTeamMemberRequest.Builder()
    .Build();
bodyTeamMembers.Add("",bodyTeamMembers1);

var body = new BulkUpdateTeamMembersRequest.Builder(
        bodyTeamMembers)
    .Build();

try
{
    BulkUpdateTeamMembersResponse result = await teamApi.BulkUpdateTeamMembersAsync(body);
}
catch (ApiException e){};
```


# Search Team Members

Returns a paginated list of `TeamMember` objects for a business.
The list can be filtered by the following:

- location IDs
- `status`

```csharp
SearchTeamMembersAsync(
    Models.SearchTeamMembersRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.SearchTeamMembersRequest`](../../doc/models/search-team-members-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.SearchTeamMembersResponse>`](../../doc/models/search-team-members-response.md)

## Example Usage

```csharp
var bodyQueryFilterLocationIds = new IList<string>();
bodyQueryFilterLocationIds.Add("0G5P3VGACMMQZ");
var bodyQueryFilter = new SearchTeamMembersFilter.Builder()
    .LocationIds(bodyQueryFilterLocationIds)
    .Status("ACTIVE")
    .IsOwner(false)
    .Build();
var bodyQuery = new SearchTeamMembersQuery.Builder()
    .Filter(bodyQueryFilter)
    .Build();
var body = new SearchTeamMembersRequest.Builder()
    .Query(bodyQuery)
    .Limit(10)
    .Cursor("cursor0")
    .Build();

try
{
    SearchTeamMembersResponse result = await teamApi.SearchTeamMembersAsync(body);
}
catch (ApiException e){};
```


# Retrieve Team Member

Retrieves a `TeamMember` object for the given `TeamMember.id`.
Learn about [Troubleshooting the Team API](../../https://developer.squareup.com/docs/team/troubleshooting#retrieve-a-team-member).

```csharp
RetrieveTeamMemberAsync(
    string teamMemberId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `teamMemberId` | `string` | Template, Required | The ID of the team member to retrieve. |

## Response Type

[`Task<Models.RetrieveTeamMemberResponse>`](../../doc/models/retrieve-team-member-response.md)

## Example Usage

```csharp
string teamMemberId = "team_member_id0";

try
{
    RetrieveTeamMemberResponse result = await teamApi.RetrieveTeamMemberAsync(teamMemberId);
}
catch (ApiException e){};
```


# Update Team Member

Updates a single `TeamMember` object. The `TeamMember` object is returned on successful updates.
Learn about [Troubleshooting the Team API](../../https://developer.squareup.com/docs/team/troubleshooting#update-a-team-member).

```csharp
UpdateTeamMemberAsync(
    string teamMemberId,
    Models.UpdateTeamMemberRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `teamMemberId` | `string` | Template, Required | The ID of the team member to update. |
| `body` | [`Models.UpdateTeamMemberRequest`](../../doc/models/update-team-member-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.UpdateTeamMemberResponse>`](../../doc/models/update-team-member-response.md)

## Example Usage

```csharp
string teamMemberId = "team_member_id0";
var bodyTeamMemberAssignedLocationsLocationIds = new IList<string>();
bodyTeamMemberAssignedLocationsLocationIds.Add("YSGH2WBKG94QZ");
bodyTeamMemberAssignedLocationsLocationIds.Add("GA2Y9HSJ8KRYT");
var bodyTeamMemberAssignedLocations = new TeamMemberAssignedLocations.Builder()
    .AssignmentType("EXPLICIT_LOCATIONS")
    .LocationIds(bodyTeamMemberAssignedLocationsLocationIds)
    .Build();
var bodyTeamMember = new TeamMember.Builder()
    .Id("id2")
    .ReferenceId("reference_id_1")
    .IsOwner(false)
    .Status("ACTIVE")
    .GivenName("Joe")
    .FamilyName("Doe")
    .EmailAddress("joe_doe@gmail.com")
    .PhoneNumber("+14159283333")
    .AssignedLocations(bodyTeamMemberAssignedLocations)
    .Build();
var body = new UpdateTeamMemberRequest.Builder()
    .TeamMember(bodyTeamMember)
    .Build();

try
{
    UpdateTeamMemberResponse result = await teamApi.UpdateTeamMemberAsync(teamMemberId, body);
}
catch (ApiException e){};
```


# Retrieve Wage Setting

Retrieves a `WageSetting` object for a team member specified
by `TeamMember.id`.
Learn about [Troubleshooting the Team API](../../https://developer.squareup.com/docs/team/troubleshooting#retrievewagesetting).

```csharp
RetrieveWageSettingAsync(
    string teamMemberId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `teamMemberId` | `string` | Template, Required | The ID of the team member for which to retrieve the wage setting. |

## Response Type

[`Task<Models.RetrieveWageSettingResponse>`](../../doc/models/retrieve-wage-setting-response.md)

## Example Usage

```csharp
string teamMemberId = "team_member_id0";

try
{
    RetrieveWageSettingResponse result = await teamApi.RetrieveWageSettingAsync(teamMemberId);
}
catch (ApiException e){};
```


# Update Wage Setting

Creates or updates a `WageSetting` object. The object is created if a
`WageSetting` with the specified `team_member_id` does not exist. Otherwise,
it fully replaces the `WageSetting` object for the team member.
The `WageSetting` is returned on a successful update.
Learn about [Troubleshooting the Team API](../../https://developer.squareup.com/docs/team/troubleshooting#create-or-update-a-wage-setting).

```csharp
UpdateWageSettingAsync(
    string teamMemberId,
    Models.UpdateWageSettingRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `teamMemberId` | `string` | Template, Required | The ID of the team member for which to update the `WageSetting` object. |
| `body` | [`Models.UpdateWageSettingRequest`](../../doc/models/update-wage-setting-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.UpdateWageSettingResponse>`](../../doc/models/update-wage-setting-response.md)

## Example Usage

```csharp
string teamMemberId = "team_member_id0";
var bodyWageSettingJobAssignments = new List<JobAssignment>();

var bodyWageSettingJobAssignments0HourlyRate = new Money.Builder()
    .Amount(117L)
    .Currency("ERN")
    .Build();
var bodyWageSettingJobAssignments0AnnualRate = new Money.Builder()
    .Amount(3000000L)
    .Currency("USD")
    .Build();
var bodyWageSettingJobAssignments0 = new JobAssignment.Builder(
        "Manager",
        "SALARY")
    .HourlyRate(bodyWageSettingJobAssignments0HourlyRate)
    .AnnualRate(bodyWageSettingJobAssignments0AnnualRate)
    .WeeklyHours(40)
    .Build();
bodyWageSettingJobAssignments.Add(bodyWageSettingJobAssignments0);

var bodyWageSettingJobAssignments1HourlyRate = new Money.Builder()
    .Amount(1200L)
    .Currency("USD")
    .Build();
var bodyWageSettingJobAssignments1AnnualRate = new Money.Builder()
    .Amount(58L)
    .Currency("DZD")
    .Build();
var bodyWageSettingJobAssignments1 = new JobAssignment.Builder(
        "Cashier",
        "HOURLY")
    .HourlyRate(bodyWageSettingJobAssignments1HourlyRate)
    .AnnualRate(bodyWageSettingJobAssignments1AnnualRate)
    .WeeklyHours(226)
    .Build();
bodyWageSettingJobAssignments.Add(bodyWageSettingJobAssignments1);

var bodyWageSetting = new WageSetting.Builder()
    .TeamMemberId("team_member_id2")
    .JobAssignments(bodyWageSettingJobAssignments)
    .IsOvertimeExempt(true)
    .Version(122)
    .CreatedAt("created_at0")
    .Build();
var body = new UpdateWageSettingRequest.Builder(
        bodyWageSetting)
    .Build();

try
{
    UpdateWageSettingResponse result = await teamApi.UpdateWageSettingAsync(teamMemberId, body);
}
catch (ApiException e){};
```

