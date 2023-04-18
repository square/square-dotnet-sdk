
# Update Order Request

Defines the fields that are included in requests to the
[UpdateOrder](../../doc/api/orders.md#update-order) endpoint.

## Structure

`UpdateOrderRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Order` | [`Models.Order`](../../doc/models/order.md) | Optional | Contains all information related to a single order to process with Square,<br>including line items that specify the products to purchase. `Order` objects also<br>include information about any associated tenders, refunds, and returns.<br><br>All Connect V2 Transactions have all been converted to Orders including all associated<br>itemization data. |
| `FieldsToClear` | `IList<string>` | Optional | The [dot notation paths](https://developer.squareup.com/docs/orders-api/manage-orders/update-orders#identifying-fields-to-delete)<br>fields to clear. For example, `line_items[uid].note`.<br>For more information, see [Deleting fields](https://developer.squareup.com/docs/orders-api/manage-orders/update-orders#deleting-fields). |
| `IdempotencyKey` | `string` | Optional | A value you specify that uniquely identifies this update request.<br><br>If you are unsure whether a particular update was applied to an order successfully,<br>you can reattempt it with the same idempotency key without<br>worrying about creating duplicate updates to the order.<br>The latest order version is returned.<br><br>For more information, see [Idempotency](https://developer.squareup.com/docs/basics/api101/idempotency).<br>**Constraints**: *Maximum Length*: `192` |

## Example (as JSON)

```json
{
  "order": {
    "id": "id6",
    "location_id": "location_id0",
    "reference_id": "reference_id4",
    "source": {
      "name": "name2"
    },
    "customer_id": "customer_id4",
    "line_items": [
      {
        "uid": "uid1",
        "name": "name1",
        "quantity": "quantity7",
        "quantity_unit": {
          "measurement_unit": {
            "custom_unit": {
              "name": "name9",
              "abbreviation": "abbreviation1"
            },
            "area_unit": "METRIC_SQUARE_CENTIMETER",
            "length_unit": "IMPERIAL_MILE",
            "volume_unit": "GENERIC_FLUID_OUNCE",
            "weight_unit": "METRIC_KILOGRAM",
            "generic_unit": "UNIT",
            "time_unit": "GENERIC_MILLISECOND",
            "type": "TYPE_GENERIC"
          },
          "precision": 201,
          "catalog_object_id": "catalog_object_id1",
          "catalog_version": 135
        },
        "note": "note3",
        "catalog_object_id": "catalog_object_id5",
        "catalog_version": 235,
        "variation_name": "variation_name1",
        "item_type": "CUSTOM_AMOUNT",
        "metadata": {
          "key0": "metadata2",
          "key1": "metadata3"
        },
        "modifiers": [
          {
            "uid": "uid2",
            "catalog_object_id": "catalog_object_id6",
            "catalog_version": 82,
            "name": "name2",
            "quantity": "quantity8",
            "base_price_money": {
              "amount": 66,
              "currency": "ETB"
            },
            "total_price_money": {
              "amount": 64,
              "currency": "SLL"
            },
            "metadata": {
              "key0": "metadata9",
              "key1": "metadata8"
            }
          },
          {
            "uid": "uid3",
            "catalog_object_id": "catalog_object_id7",
            "catalog_version": 83,
            "name": "name3",
            "quantity": "quantity9",
            "base_price_money": {
              "amount": 67,
              "currency": "EUR"
            },
            "total_price_money": {
              "amount": 65,
              "currency": "SOS"
            },
            "metadata": {
              "key0": "metadata0"
            }
          },
          {
            "uid": "uid4",
            "catalog_object_id": "catalog_object_id8",
            "catalog_version": 84,
            "name": "name4",
            "quantity": "quantity0",
            "base_price_money": {
              "amount": 68,
              "currency": "FJD"
            },
            "total_price_money": {
              "amount": 66,
              "currency": "SRD"
            },
            "metadata": {
              "key0": "metadata1",
              "key1": "metadata0",
              "key2": "metadata9"
            }
          }
        ],
        "applied_taxes": [
          {
            "uid": "uid1",
            "tax_uid": "tax_uid7",
            "applied_money": {}
          },
          {
            "uid": "uid2",
            "tax_uid": "tax_uid8",
            "applied_money": {}
          },
          {
            "uid": "uid3",
            "tax_uid": "tax_uid9",
            "applied_money": {}
          }
        ],
        "applied_discounts": [
          {
            "uid": "uid5",
            "discount_uid": "discount_uid9",
            "applied_money": {}
          }
        ],
        "applied_service_charges": [
          {
            "uid": "uid0",
            "service_charge_uid": "service_charge_uid0",
            "applied_money": {}
          },
          {
            "uid": "uid9",
            "service_charge_uid": "service_charge_uid9",
            "applied_money": {}
          }
        ],
        "base_price_money": {},
        "variation_total_price_money": {},
        "gross_sales_money": {},
        "total_tax_money": {},
        "total_discount_money": {},
        "total_money": {},
        "pricing_blocklists": {
          "blocked_discounts": [
            {
              "uid": "uid4",
              "discount_uid": "discount_uid0",
              "discount_catalog_object_id": "discount_catalog_object_id6"
            },
            {
              "uid": "uid5",
              "discount_uid": "discount_uid1",
              "discount_catalog_object_id": "discount_catalog_object_id7"
            }
          ],
          "blocked_taxes": [
            {
              "uid": "uid2",
              "tax_uid": "tax_uid8",
              "tax_catalog_object_id": "tax_catalog_object_id6"
            },
            {
              "uid": "uid1",
              "tax_uid": "tax_uid7",
              "tax_catalog_object_id": "tax_catalog_object_id5"
            }
          ]
        },
        "total_service_charge_money": {}
      }
    ],
    "taxes": [
      {
        "uid": "uid9",
        "catalog_object_id": "catalog_object_id7",
        "catalog_version": 153,
        "name": "name9",
        "type": "ADDITIVE",
        "percentage": "percentage7",
        "metadata": {
          "key0": "metadata4",
          "key1": "metadata5"
        },
        "applied_money": {},
        "scope": "LINE_ITEM",
        "auto_applied": true
      },
      {
        "uid": "uid8",
        "catalog_object_id": "catalog_object_id8",
        "catalog_version": 154,
        "name": "name8",
        "type": "INCLUSIVE",
        "percentage": "percentage6",
        "metadata": {
          "key0": "metadata5",
          "key1": "metadata6",
          "key2": "metadata7"
        },
        "applied_money": {},
        "scope": "ORDER",
        "auto_applied": false
      }
    ],
    "discounts": [
      {
        "uid": "uid7",
        "catalog_object_id": "catalog_object_id1",
        "catalog_version": 97,
        "name": "name7",
        "type": "FIXED_AMOUNT",
        "percentage": "percentage5",
        "amount_money": {},
        "applied_money": {},
        "metadata": {
          "key0": "metadata8"
        },
        "scope": "OTHER_DISCOUNT_SCOPE",
        "reward_ids": [
          "reward_ids4",
          "reward_ids5",
          "reward_ids6"
        ],
        "pricing_rule_id": "pricing_rule_id9"
      },
      {
        "uid": "uid8",
        "catalog_object_id": "catalog_object_id2",
        "catalog_version": 98,
        "name": "name8",
        "type": "VARIABLE_PERCENTAGE",
        "percentage": "percentage6",
        "amount_money": {},
        "applied_money": {},
        "metadata": {
          "key0": "metadata9",
          "key1": "metadata0"
        },
        "scope": "LINE_ITEM",
        "reward_ids": [
          "reward_ids5"
        ],
        "pricing_rule_id": "pricing_rule_id0"
      }
    ],
    "service_charges": [
      {
        "uid": "uid9",
        "name": "name9",
        "catalog_object_id": "catalog_object_id7",
        "catalog_version": 213,
        "percentage": "percentage7",
        "amount_money": {},
        "applied_money": {},
        "total_money": {},
        "total_tax_money": {},
        "calculation_phase": "APPORTIONED_AMOUNT_PHASE",
        "taxable": true,
        "applied_taxes": [
          {}
        ],
        "metadata": {
          "key0": "metadata4"
        },
        "type": "CUSTOM",
        "treatment_type": "APPORTIONED_TREATMENT",
        "scope": "OTHER_SERVICE_CHARGE_SCOPE"
      }
    ],
    "fulfillments": [
      {
        "uid": "uid2",
        "type": "PICKUP",
        "state": "PROPOSED",
        "line_item_application": "ALL",
        "entries": [
          {
            "uid": "uid7",
            "line_item_uid": "line_item_uid7",
            "quantity": "quantity3",
            "metadata": {
              "key0": "metadata4"
            }
          },
          {
            "uid": "uid8",
            "line_item_uid": "line_item_uid8",
            "quantity": "quantity4",
            "metadata": {
              "key0": "metadata5",
              "key1": "metadata4",
              "key2": "metadata3"
            }
          },
          {
            "uid": "uid9",
            "line_item_uid": "line_item_uid9",
            "quantity": "quantity5",
            "metadata": {
              "key0": "metadata6",
              "key1": "metadata5"
            }
          }
        ],
        "metadata": {
          "key0": "metadata7"
        },
        "pickup_details": {
          "recipient": {
            "customer_id": "customer_id0",
            "display_name": "display_name2",
            "email_address": "email_address0",
            "phone_number": "phone_number0",
            "address": {
              "address_line_1": "address_line_18",
              "address_line_2": "address_line_28",
              "address_line_3": "address_line_34",
              "locality": "locality8",
              "sublocality": "sublocality8",
              "sublocality_2": "sublocality_26",
              "sublocality_3": "sublocality_38",
              "administrative_district_level_1": "administrative_district_level_12",
              "administrative_district_level_2": "administrative_district_level_24",
              "administrative_district_level_3": "administrative_district_level_36",
              "postal_code": "postal_code0",
              "country": "SY",
              "first_name": "first_name8",
              "last_name": "last_name6"
            }
          },
          "expires_at": "expires_at4",
          "auto_complete_duration": "auto_complete_duration4",
          "schedule_type": "SCHEDULED",
          "pickup_at": "pickup_at6",
          "pickup_window_duration": "pickup_window_duration0",
          "prep_time_duration": "prep_time_duration2",
          "note": "note6",
          "placed_at": "placed_at0",
          "accepted_at": "accepted_at4",
          "rejected_at": "rejected_at2",
          "ready_at": "ready_at0",
          "expired_at": "expired_at0",
          "picked_up_at": "picked_up_at0",
          "canceled_at": "canceled_at6",
          "cancel_reason": "cancel_reason6",
          "is_curbside_pickup": false,
          "curbside_pickup_details": {
            "curbside_details": "curbside_details2",
            "buyer_arrived_at": "buyer_arrived_at8"
          }
        },
        "shipment_details": {
          "recipient": {
            "customer_id": "customer_id4",
            "display_name": "display_name6",
            "email_address": "email_address4",
            "phone_number": "phone_number4",
            "address": {
              "address_line_1": "address_line_12",
              "address_line_2": "address_line_22",
              "address_line_3": "address_line_38",
              "locality": "locality2",
              "sublocality": "sublocality2",
              "sublocality_2": "sublocality_20",
              "sublocality_3": "sublocality_32",
              "administrative_district_level_1": "administrative_district_level_16",
              "administrative_district_level_2": "administrative_district_level_28",
              "administrative_district_level_3": "administrative_district_level_30",
              "postal_code": "postal_code4",
              "country": "VA",
              "first_name": "first_name2",
              "last_name": "last_name0"
            }
          },
          "carrier": "carrier6",
          "shipping_note": "shipping_note0",
          "shipping_type": "shipping_type8",
          "tracking_number": "tracking_number2",
          "tracking_url": "tracking_url4",
          "placed_at": "placed_at4",
          "in_progress_at": "in_progress_at0",
          "packaged_at": "packaged_at8",
          "expected_shipped_at": "expected_shipped_at8",
          "shipped_at": "shipped_at2",
          "canceled_at": "canceled_at0",
          "cancel_reason": "cancel_reason0",
          "failed_at": "failed_at8",
          "failure_reason": "failure_reason4"
        },
        "delivery_details": {
          "recipient": {},
          "schedule_type": "SCHEDULED",
          "placed_at": "placed_at8",
          "deliver_at": "deliver_at6",
          "prep_time_duration": "prep_time_duration0",
          "delivery_window_duration": "delivery_window_duration2",
          "note": "note4",
          "completed_at": "completed_at0",
          "in_progress_at": "in_progress_at4",
          "rejected_at": "rejected_at0",
          "ready_at": "ready_at8",
          "delivered_at": "delivered_at6",
          "canceled_at": "canceled_at4",
          "cancel_reason": "cancel_reason4",
          "courier_pickup_at": "courier_pickup_at0",
          "courier_pickup_window_duration": "courier_pickup_window_duration2",
          "is_no_contact_delivery": false,
          "dropoff_notes": "dropoff_notes2",
          "courier_provider_name": "courier_provider_name6",
          "courier_support_phone_number": "courier_support_phone_number4",
          "square_delivery_id": "square_delivery_id8",
          "external_delivery_id": "external_delivery_id2",
          "managed_delivery": false
        }
      },
      {
        "uid": "uid3",
        "type": "SHIPMENT",
        "state": "RESERVED",
        "line_item_application": "ENTRY_LIST",
        "entries": [
          {
            "uid": "uid8",
            "line_item_uid": "line_item_uid8",
            "quantity": "quantity4",
            "metadata": {
              "key0": "metadata5",
              "key1": "metadata4",
              "key2": "metadata3"
            }
          }
        ],
        "metadata": {
          "key0": "metadata6",
          "key1": "metadata5"
        },
        "pickup_details": {
          "recipient": {
            "customer_id": "customer_id1",
            "display_name": "display_name3",
            "email_address": "email_address1",
            "phone_number": "phone_number1",
            "address": {
              "address_line_1": "address_line_19",
              "address_line_2": "address_line_29",
              "address_line_3": "address_line_35",
              "locality": "locality9",
              "sublocality": "sublocality9",
              "sublocality_2": "sublocality_27",
              "sublocality_3": "sublocality_39",
              "administrative_district_level_1": "administrative_district_level_13",
              "administrative_district_level_2": "administrative_district_level_25",
              "administrative_district_level_3": "administrative_district_level_37",
              "postal_code": "postal_code1",
              "country": "SZ",
              "first_name": "first_name9",
              "last_name": "last_name7"
            }
          },
          "expires_at": "expires_at5",
          "auto_complete_duration": "auto_complete_duration5",
          "schedule_type": "ASAP",
          "pickup_at": "pickup_at7",
          "pickup_window_duration": "pickup_window_duration1",
          "prep_time_duration": "prep_time_duration3",
          "note": "note7",
          "placed_at": "placed_at1",
          "accepted_at": "accepted_at5",
          "rejected_at": "rejected_at3",
          "ready_at": "ready_at1",
          "expired_at": "expired_at1",
          "picked_up_at": "picked_up_at1",
          "canceled_at": "canceled_at7",
          "cancel_reason": "cancel_reason7",
          "is_curbside_pickup": true,
          "curbside_pickup_details": {
            "curbside_details": "curbside_details3",
            "buyer_arrived_at": "buyer_arrived_at9"
          }
        },
        "shipment_details": {
          "recipient": {
            "customer_id": "customer_id5",
            "display_name": "display_name7",
            "email_address": "email_address5",
            "phone_number": "phone_number5",
            "address": {
              "address_line_1": "address_line_13",
              "address_line_2": "address_line_23",
              "address_line_3": "address_line_39",
              "locality": "locality3",
              "sublocality": "sublocality3",
              "sublocality_2": "sublocality_21",
              "sublocality_3": "sublocality_33",
              "administrative_district_level_1": "administrative_district_level_17",
              "administrative_district_level_2": "administrative_district_level_29",
              "administrative_district_level_3": "administrative_district_level_31",
              "postal_code": "postal_code5",
              "country": "VC",
              "first_name": "first_name3",
              "last_name": "last_name1"
            }
          },
          "carrier": "carrier7",
          "shipping_note": "shipping_note1",
          "shipping_type": "shipping_type9",
          "tracking_number": "tracking_number3",
          "tracking_url": "tracking_url5",
          "placed_at": "placed_at5",
          "in_progress_at": "in_progress_at1",
          "packaged_at": "packaged_at9",
          "expected_shipped_at": "expected_shipped_at9",
          "shipped_at": "shipped_at3",
          "canceled_at": "canceled_at1",
          "cancel_reason": "cancel_reason1",
          "failed_at": "failed_at9",
          "failure_reason": "failure_reason5"
        },
        "delivery_details": {
          "recipient": {},
          "schedule_type": "ASAP",
          "placed_at": "placed_at9",
          "deliver_at": "deliver_at7",
          "prep_time_duration": "prep_time_duration1",
          "delivery_window_duration": "delivery_window_duration3",
          "note": "note5",
          "completed_at": "completed_at1",
          "in_progress_at": "in_progress_at5",
          "rejected_at": "rejected_at1",
          "ready_at": "ready_at9",
          "delivered_at": "delivered_at7",
          "canceled_at": "canceled_at5",
          "cancel_reason": "cancel_reason5",
          "courier_pickup_at": "courier_pickup_at1",
          "courier_pickup_window_duration": "courier_pickup_window_duration3",
          "is_no_contact_delivery": true,
          "dropoff_notes": "dropoff_notes3",
          "courier_provider_name": "courier_provider_name7",
          "courier_support_phone_number": "courier_support_phone_number5",
          "square_delivery_id": "square_delivery_id9",
          "external_delivery_id": "external_delivery_id3",
          "managed_delivery": true
        }
      }
    ],
    "returns": [
      {
        "uid": "uid9",
        "source_order_id": "source_order_id7",
        "return_line_items": [
          {
            "uid": "uid4",
            "source_line_item_uid": "source_line_item_uid2",
            "name": "name4",
            "quantity": "quantity0",
            "quantity_unit": {},
            "note": "note0",
            "catalog_object_id": "catalog_object_id2",
            "catalog_version": 26,
            "variation_name": "variation_name4",
            "item_type": "GIFT_CARD",
            "return_modifiers": [
              {
                "uid": "uid3",
                "source_modifier_uid": "source_modifier_uid3",
                "catalog_object_id": "catalog_object_id3",
                "catalog_version": 79,
                "name": "name3",
                "base_price_money": {},
                "total_price_money": {},
                "quantity": "quantity9"
              },
              {
                "uid": "uid2",
                "source_modifier_uid": "source_modifier_uid4",
                "catalog_object_id": "catalog_object_id4",
                "catalog_version": 80,
                "name": "name2",
                "base_price_money": {},
                "total_price_money": {},
                "quantity": "quantity8"
              }
            ],
            "applied_taxes": [
              {}
            ],
            "applied_discounts": [
              {},
              {}
            ],
            "base_price_money": {},
            "variation_total_price_money": {},
            "gross_return_money": {},
            "total_tax_money": {},
            "total_discount_money": {},
            "total_money": {},
            "applied_service_charges": [
              {}
            ],
            "total_service_charge_money": {}
          }
        ],
        "return_service_charges": [
          {
            "uid": "uid0",
            "source_service_charge_uid": "source_service_charge_uid6",
            "name": "name0",
            "catalog_object_id": "catalog_object_id4",
            "catalog_version": 12,
            "percentage": "percentage8",
            "amount_money": {},
            "applied_money": {},
            "total_money": {},
            "total_tax_money": {},
            "calculation_phase": "SUBTOTAL_PHASE",
            "taxable": false,
            "applied_taxes": [
              {}
            ],
            "treatment_type": "LINE_ITEM_TREATMENT",
            "scope": "OTHER_SERVICE_CHARGE_SCOPE"
          },
          {
            "uid": "uid1",
            "source_service_charge_uid": "source_service_charge_uid5",
            "name": "name1",
            "catalog_object_id": "catalog_object_id5",
            "catalog_version": 11,
            "percentage": "percentage9",
            "amount_money": {},
            "applied_money": {},
            "total_money": {},
            "total_tax_money": {},
            "calculation_phase": "TOTAL_PHASE",
            "taxable": true,
            "applied_taxes": [
              {},
              {}
            ],
            "treatment_type": "APPORTIONED_TREATMENT",
            "scope": "ORDER"
          }
        ],
        "return_taxes": [
          {
            "uid": "uid1",
            "source_tax_uid": "source_tax_uid9",
            "catalog_object_id": "catalog_object_id5",
            "catalog_version": 255,
            "name": "name1",
            "type": "UNKNOWN_TAX",
            "percentage": "percentage9",
            "applied_money": {},
            "scope": "OTHER_TAX_SCOPE"
          },
          {
            "uid": "uid2",
            "source_tax_uid": "source_tax_uid0",
            "catalog_object_id": "catalog_object_id4",
            "catalog_version": 254,
            "name": "name2",
            "type": "INCLUSIVE",
            "percentage": "percentage0",
            "applied_money": {},
            "scope": "ORDER"
          },
          {
            "uid": "uid3",
            "source_tax_uid": "source_tax_uid1",
            "catalog_object_id": "catalog_object_id3",
            "catalog_version": 253,
            "name": "name3",
            "type": "ADDITIVE",
            "percentage": "percentage1",
            "applied_money": {},
            "scope": "LINE_ITEM"
          }
        ],
        "return_discounts": [
          {
            "uid": "uid9",
            "source_discount_uid": "source_discount_uid9",
            "catalog_object_id": "catalog_object_id7",
            "catalog_version": 79,
            "name": "name9",
            "type": "FIXED_PERCENTAGE",
            "percentage": "percentage7",
            "amount_money": {},
            "applied_money": {},
            "scope": "LINE_ITEM"
          },
          {
            "uid": "uid8",
            "source_discount_uid": "source_discount_uid8",
            "catalog_object_id": "catalog_object_id8",
            "catalog_version": 80,
            "name": "name8",
            "type": "FIXED_AMOUNT",
            "percentage": "percentage6",
            "amount_money": {},
            "applied_money": {},
            "scope": "ORDER"
          }
        ],
        "rounding_adjustment": {
          "uid": "uid1",
          "name": "name1",
          "amount_money": {}
        },
        "return_amounts": {
          "total_money": {},
          "tax_money": {},
          "discount_money": {},
          "tip_money": {},
          "service_charge_money": {}
        }
      },
      {
        "uid": "uid0",
        "source_order_id": "source_order_id8",
        "return_line_items": [
          {
            "uid": "uid5",
            "source_line_item_uid": "source_line_item_uid3",
            "name": "name5",
            "quantity": "quantity1",
            "quantity_unit": {},
            "note": "note1",
            "catalog_object_id": "catalog_object_id1",
            "catalog_version": 25,
            "variation_name": "variation_name5",
            "item_type": "ITEM",
            "return_modifiers": [
              {
                "uid": "uid4",
                "source_modifier_uid": "source_modifier_uid2",
                "catalog_object_id": "catalog_object_id2",
                "catalog_version": 78,
                "name": "name4",
                "base_price_money": {},
                "total_price_money": {},
                "quantity": "quantity0"
              }
            ],
            "applied_taxes": [
              {},
              {}
            ],
            "applied_discounts": [
              {},
              {},
              {}
            ],
            "base_price_money": {},
            "variation_total_price_money": {},
            "gross_return_money": {},
            "total_tax_money": {},
            "total_discount_money": {},
            "total_money": {},
            "applied_service_charges": [
              {},
              {}
            ],
            "total_service_charge_money": {}
          },
          {
            "uid": "uid6",
            "source_line_item_uid": "source_line_item_uid4",
            "name": "name6",
            "quantity": "quantity2",
            "quantity_unit": {},
            "note": "note2",
            "catalog_object_id": "catalog_object_id0",
            "catalog_version": 24,
            "variation_name": "variation_name6",
            "item_type": "CUSTOM_AMOUNT",
            "return_modifiers": [
              {
                "uid": "uid5",
                "source_modifier_uid": "source_modifier_uid1",
                "catalog_object_id": "catalog_object_id1",
                "catalog_version": 77,
                "name": "name5",
                "base_price_money": {},
                "total_price_money": {},
                "quantity": "quantity1"
              },
              {
                "uid": "uid4",
                "source_modifier_uid": "source_modifier_uid2",
                "catalog_object_id": "catalog_object_id2",
                "catalog_version": 78,
                "name": "name4",
                "base_price_money": {},
                "total_price_money": {},
                "quantity": "quantity0"
              },
              {
                "uid": "uid3",
                "source_modifier_uid": "source_modifier_uid3",
                "catalog_object_id": "catalog_object_id3",
                "catalog_version": 79,
                "name": "name3",
                "base_price_money": {},
                "total_price_money": {},
                "quantity": "quantity9"
              }
            ],
            "applied_taxes": [
              {},
              {},
              {}
            ],
            "applied_discounts": [
              {}
            ],
            "base_price_money": {},
            "variation_total_price_money": {},
            "gross_return_money": {},
            "total_tax_money": {},
            "total_discount_money": {},
            "total_money": {},
            "applied_service_charges": [
              {},
              {},
              {}
            ],
            "total_service_charge_money": {}
          }
        ],
        "return_service_charges": [
          {
            "uid": "uid1",
            "source_service_charge_uid": "source_service_charge_uid5",
            "name": "name1",
            "catalog_object_id": "catalog_object_id5",
            "catalog_version": 11,
            "percentage": "percentage9",
            "amount_money": {},
            "applied_money": {},
            "total_money": {},
            "total_tax_money": {},
            "calculation_phase": "TOTAL_PHASE",
            "taxable": true,
            "applied_taxes": [
              {},
              {}
            ],
            "treatment_type": "APPORTIONED_TREATMENT",
            "scope": "ORDER"
          },
          {
            "uid": "uid2",
            "source_service_charge_uid": "source_service_charge_uid4",
            "name": "name2",
            "catalog_object_id": "catalog_object_id6",
            "catalog_version": 10,
            "percentage": "percentage0",
            "amount_money": {},
            "applied_money": {},
            "total_money": {},
            "total_tax_money": {},
            "calculation_phase": "APPORTIONED_PERCENTAGE_PHASE",
            "taxable": false,
            "applied_taxes": [
              {},
              {},
              {}
            ],
            "treatment_type": "LINE_ITEM_TREATMENT",
            "scope": "LINE_ITEM"
          },
          {
            "uid": "uid3",
            "source_service_charge_uid": "source_service_charge_uid3",
            "name": "name3",
            "catalog_object_id": "catalog_object_id7",
            "catalog_version": 9,
            "percentage": "percentage1",
            "amount_money": {},
            "applied_money": {},
            "total_money": {},
            "total_tax_money": {},
            "calculation_phase": "APPORTIONED_AMOUNT_PHASE",
            "taxable": true,
            "applied_taxes": [
              {}
            ],
            "treatment_type": "APPORTIONED_TREATMENT",
            "scope": "OTHER_SERVICE_CHARGE_SCOPE"
          }
        ],
        "return_taxes": [
          {
            "uid": "uid2",
            "source_tax_uid": "source_tax_uid0",
            "catalog_object_id": "catalog_object_id4",
            "catalog_version": 254,
            "name": "name2",
            "type": "INCLUSIVE",
            "percentage": "percentage0",
            "applied_money": {},
            "scope": "ORDER"
          }
        ],
        "return_discounts": [
          {
            "uid": "uid8",
            "source_discount_uid": "source_discount_uid8",
            "catalog_object_id": "catalog_object_id8",
            "catalog_version": 80,
            "name": "name8",
            "type": "FIXED_AMOUNT",
            "percentage": "percentage6",
            "amount_money": {},
            "applied_money": {},
            "scope": "ORDER"
          },
          {
            "uid": "uid7",
            "source_discount_uid": "source_discount_uid7",
            "catalog_object_id": "catalog_object_id9",
            "catalog_version": 81,
            "name": "name7",
            "type": "VARIABLE_PERCENTAGE",
            "percentage": "percentage5",
            "amount_money": {},
            "applied_money": {},
            "scope": "OTHER_DISCOUNT_SCOPE"
          },
          {
            "uid": "uid6",
            "source_discount_uid": "source_discount_uid6",
            "catalog_object_id": "catalog_object_id0",
            "catalog_version": 82,
            "name": "name6",
            "type": "VARIABLE_AMOUNT",
            "percentage": "percentage4",
            "amount_money": {},
            "applied_money": {},
            "scope": "LINE_ITEM"
          }
        ],
        "rounding_adjustment": {
          "uid": "uid2",
          "name": "name2",
          "amount_money": {}
        },
        "return_amounts": {
          "total_money": {},
          "tax_money": {},
          "discount_money": {},
          "tip_money": {},
          "service_charge_money": {}
        }
      },
      {
        "uid": "uid1",
        "source_order_id": "source_order_id9",
        "return_line_items": [
          {
            "uid": "uid6",
            "source_line_item_uid": "source_line_item_uid4",
            "name": "name6",
            "quantity": "quantity2",
            "quantity_unit": {},
            "note": "note2",
            "catalog_object_id": "catalog_object_id0",
            "catalog_version": 24,
            "variation_name": "variation_name6",
            "item_type": "CUSTOM_AMOUNT",
            "return_modifiers": [
              {
                "uid": "uid5",
                "source_modifier_uid": "source_modifier_uid1",
                "catalog_object_id": "catalog_object_id1",
                "catalog_version": 77,
                "name": "name5",
                "base_price_money": {},
                "total_price_money": {},
                "quantity": "quantity1"
              },
              {
                "uid": "uid4",
                "source_modifier_uid": "source_modifier_uid2",
                "catalog_object_id": "catalog_object_id2",
                "catalog_version": 78,
                "name": "name4",
                "base_price_money": {},
                "total_price_money": {},
                "quantity": "quantity0"
              },
              {
                "uid": "uid3",
                "source_modifier_uid": "source_modifier_uid3",
                "catalog_object_id": "catalog_object_id3",
                "catalog_version": 79,
                "name": "name3",
                "base_price_money": {},
                "total_price_money": {},
                "quantity": "quantity9"
              }
            ],
            "applied_taxes": [
              {},
              {},
              {}
            ],
            "applied_discounts": [
              {}
            ],
            "base_price_money": {},
            "variation_total_price_money": {},
            "gross_return_money": {},
            "total_tax_money": {},
            "total_discount_money": {},
            "total_money": {},
            "applied_service_charges": [
              {},
              {},
              {}
            ],
            "total_service_charge_money": {}
          },
          {
            "uid": "uid7",
            "source_line_item_uid": "source_line_item_uid5",
            "name": "name7",
            "quantity": "quantity3",
            "quantity_unit": {},
            "note": "note3",
            "catalog_object_id": "catalog_object_id9",
            "catalog_version": 23,
            "variation_name": "variation_name7",
            "item_type": "GIFT_CARD",
            "return_modifiers": [
              {
                "uid": "uid6",
                "source_modifier_uid": "source_modifier_uid0",
                "catalog_object_id": "catalog_object_id0",
                "catalog_version": 76,
                "name": "name6",
                "base_price_money": {},
                "total_price_money": {},
                "quantity": "quantity2"
              },
              {
                "uid": "uid5",
                "source_modifier_uid": "source_modifier_uid1",
                "catalog_object_id": "catalog_object_id1",
                "catalog_version": 77,
                "name": "name5",
                "base_price_money": {},
                "total_price_money": {},
                "quantity": "quantity1"
              }
            ],
            "applied_taxes": [
              {}
            ],
            "applied_discounts": [
              {},
              {}
            ],
            "base_price_money": {},
            "variation_total_price_money": {},
            "gross_return_money": {},
            "total_tax_money": {},
            "total_discount_money": {},
            "total_money": {},
            "applied_service_charges": [
              {}
            ],
            "total_service_charge_money": {}
          },
          {
            "uid": "uid8",
            "source_line_item_uid": "source_line_item_uid6",
            "name": "name8",
            "quantity": "quantity4",
            "quantity_unit": {},
            "note": "note4",
            "catalog_object_id": "catalog_object_id8",
            "catalog_version": 22,
            "variation_name": "variation_name8",
            "item_type": "ITEM",
            "return_modifiers": [
              {
                "uid": "uid7",
                "source_modifier_uid": "source_modifier_uid9",
                "catalog_object_id": "catalog_object_id9",
                "catalog_version": 75,
                "name": "name7",
                "base_price_money": {},
                "total_price_money": {},
                "quantity": "quantity3"
              }
            ],
            "applied_taxes": [
              {},
              {}
            ],
            "applied_discounts": [
              {},
              {},
              {}
            ],
            "base_price_money": {},
            "variation_total_price_money": {},
            "gross_return_money": {},
            "total_tax_money": {},
            "total_discount_money": {},
            "total_money": {},
            "applied_service_charges": [
              {},
              {}
            ],
            "total_service_charge_money": {}
          }
        ],
        "return_service_charges": [
          {
            "uid": "uid2",
            "source_service_charge_uid": "source_service_charge_uid4",
            "name": "name2",
            "catalog_object_id": "catalog_object_id6",
            "catalog_version": 10,
            "percentage": "percentage0",
            "amount_money": {},
            "applied_money": {},
            "total_money": {},
            "total_tax_money": {},
            "calculation_phase": "APPORTIONED_PERCENTAGE_PHASE",
            "taxable": false,
            "applied_taxes": [
              {},
              {},
              {}
            ],
            "treatment_type": "LINE_ITEM_TREATMENT",
            "scope": "LINE_ITEM"
          }
        ],
        "return_taxes": [
          {
            "uid": "uid3",
            "source_tax_uid": "source_tax_uid1",
            "catalog_object_id": "catalog_object_id3",
            "catalog_version": 253,
            "name": "name3",
            "type": "ADDITIVE",
            "percentage": "percentage1",
            "applied_money": {},
            "scope": "LINE_ITEM"
          },
          {
            "uid": "uid4",
            "source_tax_uid": "source_tax_uid2",
            "catalog_object_id": "catalog_object_id2",
            "catalog_version": 252,
            "name": "name4",
            "type": "UNKNOWN_TAX",
            "percentage": "percentage2",
            "applied_money": {},
            "scope": "OTHER_TAX_SCOPE"
          }
        ],
        "return_discounts": [
          {
            "uid": "uid7",
            "source_discount_uid": "source_discount_uid7",
            "catalog_object_id": "catalog_object_id9",
            "catalog_version": 81,
            "name": "name7",
            "type": "VARIABLE_PERCENTAGE",
            "percentage": "percentage5",
            "amount_money": {},
            "applied_money": {},
            "scope": "OTHER_DISCOUNT_SCOPE"
          }
        ],
        "rounding_adjustment": {
          "uid": "uid3",
          "name": "name3",
          "amount_money": {}
        },
        "return_amounts": {
          "total_money": {},
          "tax_money": {},
          "discount_money": {},
          "tip_money": {},
          "service_charge_money": {}
        }
      }
    ],
    "return_amounts": {},
    "net_amounts": {},
    "rounding_adjustment": {},
    "tenders": [
      {
        "id": "id8",
        "location_id": "location_id2",
        "transaction_id": "transaction_id6",
        "created_at": "created_at6",
        "note": "note4",
        "amount_money": {},
        "tip_money": {},
        "processing_fee_money": {},
        "customer_id": "customer_id6",
        "type": "SQUARE_GIFT_CARD",
        "card_details": {
          "status": "AUTHORIZED",
          "card": {
            "id": "id0",
            "card_brand": "OTHER_BRAND",
            "last_4": "last_42",
            "exp_month": 160,
            "exp_year": 136,
            "cardholder_name": "cardholder_name4",
            "billing_address": {},
            "fingerprint": "fingerprint6",
            "customer_id": "customer_id8",
            "merchant_id": "merchant_id0",
            "reference_id": "reference_id8",
            "enabled": false,
            "card_type": "UNKNOWN_CARD_TYPE",
            "prepaid_type": "PREPAID",
            "bin": "bin0",
            "version": 222,
            "card_co_brand": "AFTERPAY"
          },
          "entry_method": "EMV"
        },
        "cash_details": {
          "buyer_tendered_money": {},
          "change_back_money": {}
        },
        "additional_recipients": [
          {
            "location_id": "location_id1",
            "description": "description7",
            "amount_money": {},
            "receivable_id": "receivable_id7"
          },
          {
            "location_id": "location_id2",
            "description": "description8",
            "amount_money": {},
            "receivable_id": "receivable_id8"
          }
        ],
        "payment_id": "payment_id8"
      },
      {
        "id": "id9",
        "location_id": "location_id3",
        "transaction_id": "transaction_id7",
        "created_at": "created_at7",
        "note": "note5",
        "amount_money": {},
        "tip_money": {},
        "processing_fee_money": {},
        "customer_id": "customer_id7",
        "type": "NO_SALE",
        "card_details": {
          "status": "CAPTURED",
          "card": {
            "id": "id1",
            "card_brand": "EBT",
            "last_4": "last_43",
            "exp_month": 159,
            "exp_year": 137,
            "cardholder_name": "cardholder_name3",
            "billing_address": {},
            "fingerprint": "fingerprint7",
            "customer_id": "customer_id9",
            "merchant_id": "merchant_id1",
            "reference_id": "reference_id9",
            "enabled": true,
            "card_type": "DEBIT",
            "prepaid_type": "UNKNOWN_PREPAID_TYPE",
            "bin": "bin1",
            "version": 223,
            "card_co_brand": "UNKNOWN"
          },
          "entry_method": "ON_FILE"
        },
        "cash_details": {
          "buyer_tendered_money": {},
          "change_back_money": {}
        },
        "additional_recipients": [
          {
            "location_id": "location_id2",
            "description": "description8",
            "amount_money": {},
            "receivable_id": "receivable_id8"
          },
          {
            "location_id": "location_id3",
            "description": "description9",
            "amount_money": {},
            "receivable_id": "receivable_id9"
          },
          {
            "location_id": "location_id4",
            "description": "description0",
            "amount_money": {},
            "receivable_id": "receivable_id0"
          }
        ],
        "payment_id": "payment_id9"
      }
    ],
    "refunds": [
      {
        "id": "id2",
        "location_id": "location_id6",
        "transaction_id": "transaction_id0",
        "tender_id": "tender_id0",
        "created_at": "created_at0",
        "reason": "reason2",
        "amount_money": {},
        "status": "PENDING",
        "processing_fee_money": {},
        "additional_recipients": [
          {}
        ]
      }
    ],
    "metadata": {
      "key0": "metadata3"
    },
    "created_at": "created_at4",
    "updated_at": "updated_at2",
    "closed_at": "closed_at8",
    "state": "OPEN",
    "version": 116,
    "total_money": {},
    "total_tax_money": {},
    "total_discount_money": {},
    "total_tip_money": {},
    "total_service_charge_money": {},
    "ticket_name": "ticket_name0",
    "pricing_options": {
      "auto_apply_discounts": false,
      "auto_apply_taxes": false
    },
    "rewards": [
      {
        "id": "id1",
        "reward_tier_id": "reward_tier_id7"
      },
      {
        "id": "id2",
        "reward_tier_id": "reward_tier_id8"
      },
      {
        "id": "id3",
        "reward_tier_id": "reward_tier_id9"
      }
    ],
    "net_amount_due_money": {}
  },
  "fields_to_clear": [
    "fields_to_clear1"
  ],
  "idempotency_key": "idempotency_key6"
}
```

