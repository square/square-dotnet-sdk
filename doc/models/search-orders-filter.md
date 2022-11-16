
# Search Orders Filter

Filtering criteria to use for a `SearchOrders` request. Multiple filters
are ANDed together.

## Structure

`SearchOrdersFilter`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `StateFilter` | [`Models.SearchOrdersStateFilter`](../../doc/models/search-orders-state-filter.md) | Optional | Filter by the current order `state`. |
| `DateTimeFilter` | [`Models.SearchOrdersDateTimeFilter`](../../doc/models/search-orders-date-time-filter.md) | Optional | Filter for `Order` objects based on whether their `CREATED_AT`,<br>`CLOSED_AT`, or `UPDATED_AT` timestamps fall within a specified time range.<br>You can specify the time range and which timestamp to filter for. You can filter<br>for only one time range at a time.<br><br>For each time range, the start time and end time are inclusive. If the end time<br>is absent, it defaults to the time of the first request for the cursor.<br><br>__Important:__ If you use the `DateTimeFilter` in a `SearchOrders` query,<br>you must set the `sort_field` in [OrdersSort](../../doc/models/search-orders-sort.md)<br>to the same field you filter for. For example, if you set the `CLOSED_AT` field<br>in `DateTimeFilter`, you must set the `sort_field` in `SearchOrdersSort` to<br>`CLOSED_AT`. Otherwise, `SearchOrders` throws an error.<br>[Learn more about filtering orders by time range.](https://developer.squareup.com/docs/orders-api/manage-orders/search-orders#important-note-about-filtering-orders-by-time-range) |
| `FulfillmentFilter` | [`Models.SearchOrdersFulfillmentFilter`](../../doc/models/search-orders-fulfillment-filter.md) | Optional | Filter based on [order fulfillment](../../doc/models/fulfillment.md) information. |
| `SourceFilter` | [`Models.SearchOrdersSourceFilter`](../../doc/models/search-orders-source-filter.md) | Optional | A filter based on order `source` information. |
| `CustomerFilter` | [`Models.SearchOrdersCustomerFilter`](../../doc/models/search-orders-customer-filter.md) | Optional | A filter based on the order `customer_id` and any tender `customer_id`<br>associated with the order. It does not filter based on the<br>[FulfillmentRecipient](../../doc/models/fulfillment-recipient.md) `customer_id`. |

## Example (as JSON)

```json
{
  "state_filter": null,
  "date_time_filter": null,
  "fulfillment_filter": null,
  "source_filter": null,
  "customer_filter": null
}
```

