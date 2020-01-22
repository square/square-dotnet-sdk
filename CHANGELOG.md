# Changelog

## Version 4.1.0 (2020-01-22)
* New field:  The **Employee** object now has an `is_owner` field.
* New enumeration:  The **CardBrand** enumeration has a new `SQUARE_CAPITAL_CARD` enum value to support a Square one-time Installments payment.

* New request body field constraint: The __Refund__ Payment request now requires a payment_id. 

## Version 4.0.0 (2019-12-17)
* Square is excited to announce the public release of customized SDK for .NET

* __GA release:__ SDKs updated to support new `receipt_url` and `receipt_number` fields added to the  [Payment](${SQUARE_TECH_REF}/objects/Payment) type.  

* __Beta release:__ SDKs updated to support the new [CashDrawerShifts](cashdrawershift-api/reporting) API.

* Square now follows the semantic versioning scheme for all SDKs except PHP and Node.js. This versioning scheme uses three numbers to delineate MAJOR, MINOR, and PATCH versions of our SDK. In addition, the SDK version also includes the API version so you know what Square API version the SDK is related to. For more information, see [Versioning and SDKs](build-basics/versioning-overview#versioning-and-sdks).
* Java, .Net, Python, and Ruby SDKs are now version 4.0.0. Java and .Net SDKs have breaking changes in version 4.0.0. Ruby and Python do not have breaking changes.
