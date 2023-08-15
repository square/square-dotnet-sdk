
# Update Order Response

Defines the fields that are included in the response body of
a request to the [UpdateOrder](../../doc/api/orders.md#update-order) endpoint.

## Structure

`UpdateOrderResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Order` | [`Order`](../../doc/models/order.md) | Optional | Contains all information related to a single order to process with Square,<br>including line items that specify the products to purchase. `Order` objects also<br>include information about any associated tenders, refunds, and returns.<br><br>All Connect V2 Transactions have all been converted to Orders including all associated<br>itemization data. |
| `Errors` | [`IList<Error>`](../../doc/models/error.md) | Optional | Any errors that occurred during the request. |

## Example (as JSON)

```json
{
  "order": {
    "created_at": "2019-08-23T18:26:18.243Z",
    "id": "DREk7wJcyXNHqULq8JJ2iPAsluJZY",
    "line_items": [
      {
        "base_price_money": {
          "amount": 500,
          "currency": "USD"
        },
        "gross_sales_money": {
          "amount": 500,
          "currency": "USD"
        },
        "name": "Small Coffee",
        "quantity": "1",
        "total_discount_money": {
          "amount": 0,
          "currency": "USD"
        },
        "total_money": {
          "amount": 500,
          "currency": "USD"
        },
        "total_service_charge_money": {
          "amount": 0,
          "currency": "USD"
        },
        "total_tax_money": {
          "amount": 0,
          "currency": "USD"
        },
        "uid": "EuYkakhmu3ksHIds5Hiot",
        "variation_total_price_money": {
          "amount": 500,
          "currency": "USD"
        },
        "quantity_unit": {
          "measurement_unit": {
            "custom_unit": {
              "name": "name9",
              "abbreviation": "abbreviation1"
            },
            "area_unit": "METRIC_SQUARE_CENTIMETER",
            "length_unit": "IMPERIAL_MILE",
            "volume_unit": "GENERIC_FLUID_OUNCE",
            "weight_unit": "METRIC_KILOGRAM"
          },
          "precision": 201,
          "catalog_object_id": "catalog_object_id1",
          "catalog_version": 135
        },
        "note": "note3",
        "catalog_object_id": "catalog_object_id5"
      },
      {
        "base_price_money": {
          "amount": 200,
          "currency": "USD"
        },
        "gross_sales_money": {
          "amount": 400,
          "currency": "USD"
        },
        "name": "COOKIE",
        "quantity": "2",
        "total_discount_money": {
          "amount": 0,
          "currency": "USD"
        },
        "total_money": {
          "amount": 400,
          "currency": "USD"
        },
        "total_service_charge_money": {
          "amount": 0,
          "currency": "USD"
        },
        "total_tax_money": {
          "amount": 0,
          "currency": "USD"
        },
        "uid": "cookie_uid",
        "variation_total_price_money": {
          "amount": 400,
          "currency": "USD"
        },
        "quantity_unit": {
          "measurement_unit": {
            "custom_unit": {
              "name": "name8",
              "abbreviation": "abbreviation0"
            },
            "area_unit": "IMPERIAL_SQUARE_MILE",
            "length_unit": "METRIC_MILLIMETER",
            "volume_unit": "METRIC_LITER",
            "weight_unit": "IMPERIAL_WEIGHT_OUNCE"
          },
          "precision": 200,
          "catalog_object_id": "catalog_object_id0",
          "catalog_version": 134
        },
        "note": "note4",
        "catalog_object_id": "catalog_object_id6"
      }
    ],
    "location_id": "MXVQSVNDGN3C8",
    "net_amounts": {
      "discount_money": {
        "amount": 0,
        "currency": "USD"
      },
      "service_charge_money": {
        "amount": 0,
        "currency": "USD"
      },
      "tax_money": {
        "amount": 0,
        "currency": "USD"
      },
      "total_money": {
        "amount": 900,
        "currency": "USD"
      }
    },
    "source": {
      "name": "Cookies"
    },
    "state": "OPEN",
    "total_discount_money": {
      "amount": 0,
      "currency": "USD"
    },
    "total_money": {
      "amount": 900,
      "currency": "USD"
    },
    "total_service_charge_money": {
      "amount": 0,
      "currency": "USD"
    },
    "total_tax_money": {
      "amount": 0,
      "currency": "USD"
    },
    "updated_at": "2019-08-23T18:33:47.523Z",
    "version": 2,
    "reference_id": "reference_id4",
    "customer_id": "customer_id4"
  },
  "errors": [
    {
      "category": "REFUND_ERROR",
      "code": "MERCHANT_SUBSCRIPTION_NOT_FOUND",
      "detail": "detail1",
      "field": "field9"
    },
    {
      "category": "MERCHANT_SUBSCRIPTION_ERROR",
      "code": "BAD_REQUEST",
      "detail": "detail2",
      "field": "field0"
    },
    {
      "category": "EXTERNAL_VENDOR_ERROR",
      "code": "MISSING_REQUIRED_PARAMETER",
      "detail": "detail3",
      "field": "field1"
    }
  ]
}
```

