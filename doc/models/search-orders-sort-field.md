## Search Orders Sort Field

Specifies which timestamp to use to sort SearchOrder results.

### Enumeration

`SearchOrdersSortField`

### Fields

| Name | Description |
|  --- | --- |
| `CREATEDAT` | Time when the order was created in RFC-3339 format. If you are also<br>filtering for a time range in this query, you must set the `CREATED_AT`<br>field in your DateTimeFilter. |
| `UPDATEDAT` | Time when the order last updated in RFC-3339 format. If you are also<br>filtering for a time range in this query, you must set the `UPDATED_AT`<br>field in your DateTimeFilter. |
| `CLOSEDAT` | Time when the order was closed in RFC-3339 format. If you use this<br>value, you must also set a StateFilter with closed states. If you are also<br>filtering for a time range in this query, you must set the `CLOSED_AT`<br>field in your DateTimeFilter. |

