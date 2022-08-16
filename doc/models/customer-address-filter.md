
# Customer Address Filter

The customer address filter. This filter is used in a [CustomerCustomAttributeFilterValue](../../doc/models/customer-custom-attribute-filter-value.md) filter when
searching by an `Address`-type custom attribute.

## Structure

`CustomerAddressFilter`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `PostalCode` | [`Models.CustomerTextFilter`](../../doc/models/customer-text-filter.md) | Optional | A filter to select customers based on exact or fuzzy matching of<br>customer attributes against a specified query. Depending on the customer attributes,<br>the filter can be case-sensitive. This filter can be exact or fuzzy, but it cannot be both. |
| `Country` | [`string`](../../doc/models/country.md) | Optional | Indicates the country associated with another entity, such as a business.<br>Values are in [ISO 3166-1-alpha-2 format](http://www.iso.org/iso/home/standards/country_codes.htm). |

## Example (as JSON)

```json
{
  "postal_code": null,
  "country": null
}
```

