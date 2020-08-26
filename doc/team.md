# Team

```csharp
ITeamApi teamApi = client.TeamApi;
```

## Class Name

`TeamApi`

## Methods

* [Create Team Member](/doc/team.md#create-team-member)
* [Bulk Create Team Members](/doc/team.md#bulk-create-team-members)
* [Bulk Update Team Members](/doc/team.md#bulk-update-team-members)
* [Search Team Members](/doc/team.md#search-team-members)
* [Retrieve Team Member](/doc/team.md#retrieve-team-member)
* [Update Team Member](/doc/team.md#update-team-member)
* [Retrieve Wage Setting](/doc/team.md#retrieve-wage-setting)
* [Update Wage Setting](/doc/team.md#update-wage-setting)

## Create Team Member

Creates a single `TeamMember` object. The `TeamMember` will be returned on successful creates.
You must provide the following values in your request to this endpoint:
- `first_name`
- `last_name`
Learn about [Troubleshooting the Teams API](https://developer.squareup.com/docs/docs/team/troubleshooting#createteammember).

```csharp
CreateTeamMemberAsync(Models.CreateTeamMemberRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.CreateTeamMemberRequest`](/doc/models/create-team-member-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.CreateTeamMemberResponse>`](/doc/models/create-team-member-response.md)

### Example Usage

```csharp
var bodyTeamMemberAssignedLocationsLocationIds = new List<string>();
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

## Bulk Create Team Members

Creates multiple `TeamMember` objects. The created `TeamMember` objects will be returned on successful creates.
This process is non-transactional and will process as much of the request as is possible. If one of the creates in
the request cannot be successfully processed, the request will NOT be marked as failed, but the body of the response
will contain explicit error information for this particular create.

Learn about [Troubleshooting the Teams API](https://developer.squareup.com/docs/docs/team/troubleshooting#bulkcreateteammembers).

```csharp
BulkCreateTeamMembersAsync(Models.BulkCreateTeamMembersRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.BulkCreateTeamMembersRequest`](/doc/models/bulk-create-team-members-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.BulkCreateTeamMembersResponse>`](/doc/models/bulk-create-team-members-response.md)

### Example Usage

```csharp
var bodyTeamMembers = new CreateTeamMemberRequest.Builder()
    .Build();
var body = new BulkCreateTeamMembersRequest.Builder(
        bodyTeamMembers)
    .Build();

try
{
    BulkCreateTeamMembersResponse result = await teamApi.BulkCreateTeamMembersAsync(body);
}
catch (ApiException e){};
```

## Bulk Update Team Members

Updates multiple `TeamMember` objects. The updated `TeamMember` objects will be returned on successful updates.
This process is non-transactional and will process as much of the request as is possible. If one of the updates in
the request cannot be successfully processed, the request will NOT be marked as failed, but the body of the response
will contain explicit error information for this particular update.
Learn about [Troubleshooting the Teams API](https://developer.squareup.com/docs/docs/team/troubleshooting#bulkupdateteammembers).

```csharp
BulkUpdateTeamMembersAsync(Models.BulkUpdateTeamMembersRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.BulkUpdateTeamMembersRequest`](/doc/models/bulk-update-team-members-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.BulkUpdateTeamMembersResponse>`](/doc/models/bulk-update-team-members-response.md)

### Example Usage

```csharp
var bodyTeamMembers = new UpdateTeamMemberRequest.Builder()
    .Build();
var body = new BulkUpdateTeamMembersRequest.Builder(
        bodyTeamMembers)
    .Build();

try
{
    BulkUpdateTeamMembersResponse result = await teamApi.BulkUpdateTeamMembersAsync(body);
}
catch (ApiException e){};
```

## Search Team Members

Returns a paginated list of `TeamMember` objects for a business.
The list to be returned can be filtered by:
- location IDs **and**
- `is_active`

```csharp
SearchTeamMembersAsync(Models.SearchTeamMembersRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.SearchTeamMembersRequest`](/doc/models/search-team-members-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.SearchTeamMembersResponse>`](/doc/models/search-team-members-response.md)

### Example Usage

```csharp
var bodyQueryFilterLocationIds = new List<string>();
bodyQueryFilterLocationIds.Add("0G5P3VGACMMQZ");
var bodyQueryFilter = new SearchTeamMembersFilter.Builder()
    .LocationIds(bodyQueryFilterLocationIds)
    .Status("ACTIVE")
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

## Retrieve Team Member

Retrieve a `TeamMember` object for the given `TeamMember.id`
Learn about [Troubleshooting the Teams API](https://developer.squareup.com/docs/docs/team/troubleshooting#retrieveteammember).

```csharp
RetrieveTeamMemberAsync(string teamMemberId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `teamMemberId` | `string` | Template, Required | The ID of the team member to retrieve. |

### Response Type

[`Task<Models.RetrieveTeamMemberResponse>`](/doc/models/retrieve-team-member-response.md)

### Example Usage

```csharp
string teamMemberId = "team_member_id0";

try
{
    RetrieveTeamMemberResponse result = await teamApi.RetrieveTeamMemberAsync(teamMemberId);
}
catch (ApiException e){};
```

## Update Team Member

Updates a single `TeamMember` object. The `TeamMember` will be returned on successful updates.
Learn about [Troubleshooting the Teams API](https://developer.squareup.com/docs/docs/team/troubleshooting#updateteammember).

```csharp
UpdateTeamMemberAsync(string teamMemberId, Models.UpdateTeamMemberRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `teamMemberId` | `string` | Template, Required | The ID of the team member to update. |
| `body` | [`Models.UpdateTeamMemberRequest`](/doc/models/update-team-member-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.UpdateTeamMemberResponse>`](/doc/models/update-team-member-response.md)

### Example Usage

```csharp
string teamMemberId = "team_member_id0";
var bodyTeamMemberAssignedLocationsLocationIds = new List<string>();
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

## Retrieve Wage Setting

Retrieve a `WageSetting` object for a team member specified
by `TeamMember.id`.
Learn about [Troubleshooting the Teams API](https://developer.squareup.com/docs/docs/team/troubleshooting#retrievewagesetting).

```csharp
RetrieveWageSettingAsync(string teamMemberId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `teamMemberId` | `string` | Template, Required | The ID of the team member to retrieve wage setting for |

### Response Type

[`Task<Models.RetrieveWageSettingResponse>`](/doc/models/retrieve-wage-setting-response.md)

### Example Usage

```csharp
string teamMemberId = "team_member_id0";

try
{
    RetrieveWageSettingResponse result = await teamApi.RetrieveWageSettingAsync(teamMemberId);
}
catch (ApiException e){};
```

## Update Wage Setting

Creates or updates a `WageSetting` object. The object is created if a
`WageSetting` with the specified `team_member_id` does not exist. Otherwise,
it fully replaces the `WageSetting` object for the team member.
The `WageSetting` will be returned upon successful update.
Learn about [Troubleshooting the Teams API](https://developer.squareup.com/docs/docs/team/troubleshooting#updatewagesetting).

```csharp
UpdateWageSettingAsync(string teamMemberId, Models.UpdateWageSettingRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `teamMemberId` | `string` | Template, Required | The ID of the team member to update the `WageSetting` object for. |
| `body` | [`Models.UpdateWageSettingRequest`](/doc/models/update-wage-setting-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.UpdateWageSettingResponse>`](/doc/models/update-wage-setting-response.md)

### Example Usage

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

