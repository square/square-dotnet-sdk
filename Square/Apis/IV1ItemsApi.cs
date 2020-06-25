using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Square;
using Square.Utilities;
using Square.Http.Request;
using Square.Http.Response;
using Square.Http.Client;

namespace Square.Apis
{
    public interface IV1ItemsApi
    {
        /// <summary>
        /// Lists all the item categories for a given location.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list categories for.</param>
        /// <return>Returns the List<Models.V1Category> response from the API call</return>
        [Obsolete]
        List<Models.V1Category> ListCategories(string locationId);

        /// <summary>
        /// Lists all the item categories for a given location.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list categories for.</param>
        /// <return>Returns the List<Models.V1Category> response from the API call</return>
        [Obsolete]
        Task<List<Models.V1Category>> ListCategoriesAsync(string locationId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates an item category.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to create an item for.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.V1Category response from the API call</return>
        [Obsolete]
        Models.V1Category CreateCategory(string locationId, Models.V1Category body);

        /// <summary>
        /// Creates an item category.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to create an item for.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.V1Category response from the API call</return>
        [Obsolete]
        Task<Models.V1Category> CreateCategoryAsync(string locationId, Models.V1Category body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes an existing item category.
        /// __DeleteCategory__ returns nothing on success but Connect SDKs
        /// map the empty response to an empty `V1DeleteCategoryRequest` object
        /// as documented below.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the item's associated location.</param>
        /// <param name="categoryId">Required parameter: The ID of the category to delete.</param>
        /// <return>Returns the Models.V1Category response from the API call</return>
        [Obsolete]
        Models.V1Category DeleteCategory(string locationId, string categoryId);

        /// <summary>
        /// Deletes an existing item category.
        /// __DeleteCategory__ returns nothing on success but Connect SDKs
        /// map the empty response to an empty `V1DeleteCategoryRequest` object
        /// as documented below.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the item's associated location.</param>
        /// <param name="categoryId">Required parameter: The ID of the category to delete.</param>
        /// <return>Returns the Models.V1Category response from the API call</return>
        [Obsolete]
        Task<Models.V1Category> DeleteCategoryAsync(string locationId, string categoryId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Modifies the details of an existing item category.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the category's associated location.</param>
        /// <param name="categoryId">Required parameter: The ID of the category to edit.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.V1Category response from the API call</return>
        [Obsolete]
        Models.V1Category UpdateCategory(string locationId, string categoryId, Models.V1Category body);

        /// <summary>
        /// Modifies the details of an existing item category.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the category's associated location.</param>
        /// <param name="categoryId">Required parameter: The ID of the category to edit.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.V1Category response from the API call</return>
        [Obsolete]
        Task<Models.V1Category> UpdateCategoryAsync(string locationId, string categoryId, Models.V1Category body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Lists all the discounts for a given location.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list categories for.</param>
        /// <return>Returns the List<Models.V1Discount> response from the API call</return>
        [Obsolete]
        List<Models.V1Discount> ListDiscounts(string locationId);

        /// <summary>
        /// Lists all the discounts for a given location.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list categories for.</param>
        /// <return>Returns the List<Models.V1Discount> response from the API call</return>
        [Obsolete]
        Task<List<Models.V1Discount>> ListDiscountsAsync(string locationId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a discount.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to create an item for.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.V1Discount response from the API call</return>
        [Obsolete]
        Models.V1Discount CreateDiscount(string locationId, Models.V1Discount body);

        /// <summary>
        /// Creates a discount.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to create an item for.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.V1Discount response from the API call</return>
        [Obsolete]
        Task<Models.V1Discount> CreateDiscountAsync(string locationId, Models.V1Discount body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes an existing discount.
        /// __DeleteDiscount__ returns nothing on success but Connect SDKs
        /// map the empty response to an empty `V1DeleteDiscountRequest` object
        /// as documented below.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the item's associated location.</param>
        /// <param name="discountId">Required parameter: The ID of the discount to delete.</param>
        /// <return>Returns the Models.V1Discount response from the API call</return>
        [Obsolete]
        Models.V1Discount DeleteDiscount(string locationId, string discountId);

        /// <summary>
        /// Deletes an existing discount.
        /// __DeleteDiscount__ returns nothing on success but Connect SDKs
        /// map the empty response to an empty `V1DeleteDiscountRequest` object
        /// as documented below.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the item's associated location.</param>
        /// <param name="discountId">Required parameter: The ID of the discount to delete.</param>
        /// <return>Returns the Models.V1Discount response from the API call</return>
        [Obsolete]
        Task<Models.V1Discount> DeleteDiscountAsync(string locationId, string discountId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Modifies the details of an existing discount.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the category's associated location.</param>
        /// <param name="discountId">Required parameter: The ID of the discount to edit.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.V1Discount response from the API call</return>
        [Obsolete]
        Models.V1Discount UpdateDiscount(string locationId, string discountId, Models.V1Discount body);

        /// <summary>
        /// Modifies the details of an existing discount.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the category's associated location.</param>
        /// <param name="discountId">Required parameter: The ID of the discount to edit.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.V1Discount response from the API call</return>
        [Obsolete]
        Task<Models.V1Discount> UpdateDiscountAsync(string locationId, string discountId, Models.V1Discount body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Lists all the fees (taxes) for a given location.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list fees for.</param>
        /// <return>Returns the List<Models.V1Fee> response from the API call</return>
        [Obsolete]
        List<Models.V1Fee> ListFees(string locationId);

        /// <summary>
        /// Lists all the fees (taxes) for a given location.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list fees for.</param>
        /// <return>Returns the List<Models.V1Fee> response from the API call</return>
        [Obsolete]
        Task<List<Models.V1Fee>> ListFeesAsync(string locationId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a fee (tax).
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to create a fee for.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.V1Fee response from the API call</return>
        [Obsolete]
        Models.V1Fee CreateFee(string locationId, Models.V1Fee body);

        /// <summary>
        /// Creates a fee (tax).
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to create a fee for.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.V1Fee response from the API call</return>
        [Obsolete]
        Task<Models.V1Fee> CreateFeeAsync(string locationId, Models.V1Fee body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes an existing fee (tax).
        /// __DeleteFee__ returns nothing on success but Connect SDKs
        /// map the empty response to an empty `V1DeleteFeeRequest` object
        /// as documented below.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the fee's associated location.</param>
        /// <param name="feeId">Required parameter: The ID of the fee to delete.</param>
        /// <return>Returns the Models.V1Fee response from the API call</return>
        [Obsolete]
        Models.V1Fee DeleteFee(string locationId, string feeId);

        /// <summary>
        /// Deletes an existing fee (tax).
        /// __DeleteFee__ returns nothing on success but Connect SDKs
        /// map the empty response to an empty `V1DeleteFeeRequest` object
        /// as documented below.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the fee's associated location.</param>
        /// <param name="feeId">Required parameter: The ID of the fee to delete.</param>
        /// <return>Returns the Models.V1Fee response from the API call</return>
        [Obsolete]
        Task<Models.V1Fee> DeleteFeeAsync(string locationId, string feeId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Modifies the details of an existing fee (tax).
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the fee's associated location.</param>
        /// <param name="feeId">Required parameter: The ID of the fee to edit.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.V1Fee response from the API call</return>
        [Obsolete]
        Models.V1Fee UpdateFee(string locationId, string feeId, Models.V1Fee body);

        /// <summary>
        /// Modifies the details of an existing fee (tax).
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the fee's associated location.</param>
        /// <param name="feeId">Required parameter: The ID of the fee to edit.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.V1Fee response from the API call</return>
        [Obsolete]
        Task<Models.V1Fee> UpdateFeeAsync(string locationId, string feeId, Models.V1Fee body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Provides inventory information for all inventory-enabled item
        /// variations.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the item's associated location.</param>
        /// <param name="limit">Optional parameter: The maximum number of inventory entries to return in a single response. This value cannot exceed 1000.</param>
        /// <param name="batchToken">Optional parameter: A pagination cursor to retrieve the next set of results for your original query to the endpoint.</param>
        /// <return>Returns the List<Models.V1InventoryEntry> response from the API call</return>
        [Obsolete]
        List<Models.V1InventoryEntry> ListInventory(string locationId, int? limit = null, string batchToken = null);

        /// <summary>
        /// Provides inventory information for all inventory-enabled item
        /// variations.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the item's associated location.</param>
        /// <param name="limit">Optional parameter: The maximum number of inventory entries to return in a single response. This value cannot exceed 1000.</param>
        /// <param name="batchToken">Optional parameter: A pagination cursor to retrieve the next set of results for your original query to the endpoint.</param>
        /// <return>Returns the List<Models.V1InventoryEntry> response from the API call</return>
        [Obsolete]
        Task<List<Models.V1InventoryEntry>> ListInventoryAsync(string locationId, int? limit = null, string batchToken = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Adjusts the current available inventory of an item variation.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the item's associated location.</param>
        /// <param name="variationId">Required parameter: The ID of the variation to adjust inventory information for.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.V1InventoryEntry response from the API call</return>
        [Obsolete]
        Models.V1InventoryEntry AdjustInventory(string locationId, string variationId, Models.V1AdjustInventoryRequest body);

        /// <summary>
        /// Adjusts the current available inventory of an item variation.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the item's associated location.</param>
        /// <param name="variationId">Required parameter: The ID of the variation to adjust inventory information for.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.V1InventoryEntry response from the API call</return>
        [Obsolete]
        Task<Models.V1InventoryEntry> AdjustInventoryAsync(string locationId, string variationId, Models.V1AdjustInventoryRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Provides summary information of all items for a given location.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list items for.</param>
        /// <param name="batchToken">Optional parameter: A pagination cursor to retrieve the next set of results for your original query to the endpoint.</param>
        /// <return>Returns the List<Models.V1Item> response from the API call</return>
        [Obsolete]
        List<Models.V1Item> ListItems(string locationId, string batchToken = null);

        /// <summary>
        /// Provides summary information of all items for a given location.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list items for.</param>
        /// <param name="batchToken">Optional parameter: A pagination cursor to retrieve the next set of results for your original query to the endpoint.</param>
        /// <return>Returns the List<Models.V1Item> response from the API call</return>
        [Obsolete]
        Task<List<Models.V1Item>> ListItemsAsync(string locationId, string batchToken = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates an item and at least one variation for it.
        /// Item-related entities include fields you can use to associate them with
        /// entities in a non-Square system.
        /// When you create an item-related entity, you can optionally specify `id`.
        /// This value must be unique among all IDs ever specified for the account,
        /// including those specified by other applications. You can never reuse an
        /// entity ID. If you do not specify an ID, Square generates one for the entity.
        /// Item variations have a `user_data` string that lets you associate arbitrary
        /// metadata with the variation. The string cannot exceed 255 characters.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to create an item for.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.V1Item response from the API call</return>
        [Obsolete]
        Models.V1Item CreateItem(string locationId, Models.V1Item body);

        /// <summary>
        /// Creates an item and at least one variation for it.
        /// Item-related entities include fields you can use to associate them with
        /// entities in a non-Square system.
        /// When you create an item-related entity, you can optionally specify `id`.
        /// This value must be unique among all IDs ever specified for the account,
        /// including those specified by other applications. You can never reuse an
        /// entity ID. If you do not specify an ID, Square generates one for the entity.
        /// Item variations have a `user_data` string that lets you associate arbitrary
        /// metadata with the variation. The string cannot exceed 255 characters.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to create an item for.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.V1Item response from the API call</return>
        [Obsolete]
        Task<Models.V1Item> CreateItemAsync(string locationId, Models.V1Item body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes an existing item and all item variations associated with it.
        /// __DeleteItem__ returns nothing on success but Connect SDKs
        /// map the empty response to an empty `V1DeleteItemRequest` object
        /// as documented below.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the item's associated location.</param>
        /// <param name="itemId">Required parameter: The ID of the item to modify.</param>
        /// <return>Returns the Models.V1Item response from the API call</return>
        [Obsolete]
        Models.V1Item DeleteItem(string locationId, string itemId);

        /// <summary>
        /// Deletes an existing item and all item variations associated with it.
        /// __DeleteItem__ returns nothing on success but Connect SDKs
        /// map the empty response to an empty `V1DeleteItemRequest` object
        /// as documented below.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the item's associated location.</param>
        /// <param name="itemId">Required parameter: The ID of the item to modify.</param>
        /// <return>Returns the Models.V1Item response from the API call</return>
        [Obsolete]
        Task<Models.V1Item> DeleteItemAsync(string locationId, string itemId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Provides the details for a single item, including associated modifier
        /// lists and fees.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the item's associated location.</param>
        /// <param name="itemId">Required parameter: The item's ID.</param>
        /// <return>Returns the Models.V1Item response from the API call</return>
        [Obsolete]
        Models.V1Item RetrieveItem(string locationId, string itemId);

        /// <summary>
        /// Provides the details for a single item, including associated modifier
        /// lists and fees.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the item's associated location.</param>
        /// <param name="itemId">Required parameter: The item's ID.</param>
        /// <return>Returns the Models.V1Item response from the API call</return>
        [Obsolete]
        Task<Models.V1Item> RetrieveItemAsync(string locationId, string itemId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Modifies the core details of an existing item.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the item's associated location.</param>
        /// <param name="itemId">Required parameter: The ID of the item to modify.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.V1Item response from the API call</return>
        [Obsolete]
        Models.V1Item UpdateItem(string locationId, string itemId, Models.V1Item body);

        /// <summary>
        /// Modifies the core details of an existing item.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the item's associated location.</param>
        /// <param name="itemId">Required parameter: The ID of the item to modify.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.V1Item response from the API call</return>
        [Obsolete]
        Task<Models.V1Item> UpdateItemAsync(string locationId, string itemId, Models.V1Item body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Removes a fee assocation from an item so the fee is no longer
        /// automatically applied to the item in Square Point of Sale.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the fee's associated location.</param>
        /// <param name="itemId">Required parameter: The ID of the item to add the fee to.</param>
        /// <param name="feeId">Required parameter: The ID of the fee to apply.</param>
        /// <return>Returns the Models.V1Item response from the API call</return>
        [Obsolete]
        Models.V1Item RemoveFee(string locationId, string itemId, string feeId);

        /// <summary>
        /// Removes a fee assocation from an item so the fee is no longer
        /// automatically applied to the item in Square Point of Sale.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the fee's associated location.</param>
        /// <param name="itemId">Required parameter: The ID of the item to add the fee to.</param>
        /// <param name="feeId">Required parameter: The ID of the fee to apply.</param>
        /// <return>Returns the Models.V1Item response from the API call</return>
        [Obsolete]
        Task<Models.V1Item> RemoveFeeAsync(string locationId, string itemId, string feeId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Associates a fee with an item so the fee is automatically applied to
        /// the item in Square Point of Sale.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the fee's associated location.</param>
        /// <param name="itemId">Required parameter: The ID of the item to add the fee to.</param>
        /// <param name="feeId">Required parameter: The ID of the fee to apply.</param>
        /// <return>Returns the Models.V1Item response from the API call</return>
        [Obsolete]
        Models.V1Item ApplyFee(string locationId, string itemId, string feeId);

        /// <summary>
        /// Associates a fee with an item so the fee is automatically applied to
        /// the item in Square Point of Sale.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the fee's associated location.</param>
        /// <param name="itemId">Required parameter: The ID of the item to add the fee to.</param>
        /// <param name="feeId">Required parameter: The ID of the fee to apply.</param>
        /// <return>Returns the Models.V1Item response from the API call</return>
        [Obsolete]
        Task<Models.V1Item> ApplyFeeAsync(string locationId, string itemId, string feeId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Removes a modifier list association from an item so the modifier
        /// options from the list can no longer be applied to the item.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the item's associated location.</param>
        /// <param name="modifierListId">Required parameter: The ID of the modifier list to remove.</param>
        /// <param name="itemId">Required parameter: The ID of the item to remove the modifier list from.</param>
        /// <return>Returns the Models.V1Item response from the API call</return>
        [Obsolete]
        Models.V1Item RemoveModifierList(string locationId, string modifierListId, string itemId);

        /// <summary>
        /// Removes a modifier list association from an item so the modifier
        /// options from the list can no longer be applied to the item.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the item's associated location.</param>
        /// <param name="modifierListId">Required parameter: The ID of the modifier list to remove.</param>
        /// <param name="itemId">Required parameter: The ID of the item to remove the modifier list from.</param>
        /// <return>Returns the Models.V1Item response from the API call</return>
        [Obsolete]
        Task<Models.V1Item> RemoveModifierListAsync(string locationId, string modifierListId, string itemId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Associates a modifier list with an item so the associated modifier
        /// options can be applied to the item.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the item's associated location.</param>
        /// <param name="modifierListId">Required parameter: The ID of the modifier list to apply.</param>
        /// <param name="itemId">Required parameter: The ID of the item to add the modifier list to.</param>
        /// <return>Returns the Models.V1Item response from the API call</return>
        [Obsolete]
        Models.V1Item ApplyModifierList(string locationId, string modifierListId, string itemId);

        /// <summary>
        /// Associates a modifier list with an item so the associated modifier
        /// options can be applied to the item.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the item's associated location.</param>
        /// <param name="modifierListId">Required parameter: The ID of the modifier list to apply.</param>
        /// <param name="itemId">Required parameter: The ID of the item to add the modifier list to.</param>
        /// <return>Returns the Models.V1Item response from the API call</return>
        [Obsolete]
        Task<Models.V1Item> ApplyModifierListAsync(string locationId, string modifierListId, string itemId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates an item variation for an existing item.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the item's associated location.</param>
        /// <param name="itemId">Required parameter: The item's ID.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.V1Variation response from the API call</return>
        [Obsolete]
        Models.V1Variation CreateVariation(string locationId, string itemId, Models.V1Variation body);

        /// <summary>
        /// Creates an item variation for an existing item.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the item's associated location.</param>
        /// <param name="itemId">Required parameter: The item's ID.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.V1Variation response from the API call</return>
        [Obsolete]
        Task<Models.V1Variation> CreateVariationAsync(string locationId, string itemId, Models.V1Variation body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes an existing item variation from an item.
        /// __DeleteVariation__ returns nothing on success but Connect SDKs
        /// map the empty response to an empty `V1DeleteVariationRequest` object
        /// as documented below.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the item's associated location.</param>
        /// <param name="itemId">Required parameter: The ID of the item to delete.</param>
        /// <param name="variationId">Required parameter: The ID of the variation to delete.</param>
        /// <return>Returns the Models.V1Variation response from the API call</return>
        [Obsolete]
        Models.V1Variation DeleteVariation(string locationId, string itemId, string variationId);

        /// <summary>
        /// Deletes an existing item variation from an item.
        /// __DeleteVariation__ returns nothing on success but Connect SDKs
        /// map the empty response to an empty `V1DeleteVariationRequest` object
        /// as documented below.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the item's associated location.</param>
        /// <param name="itemId">Required parameter: The ID of the item to delete.</param>
        /// <param name="variationId">Required parameter: The ID of the variation to delete.</param>
        /// <return>Returns the Models.V1Variation response from the API call</return>
        [Obsolete]
        Task<Models.V1Variation> DeleteVariationAsync(string locationId, string itemId, string variationId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Modifies the details of an existing item variation.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the item's associated location.</param>
        /// <param name="itemId">Required parameter: The ID of the item to modify.</param>
        /// <param name="variationId">Required parameter: The ID of the variation to modify.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.V1Variation response from the API call</return>
        [Obsolete]
        Models.V1Variation UpdateVariation(
                string locationId,
                string itemId,
                string variationId,
                Models.V1Variation body);

        /// <summary>
        /// Modifies the details of an existing item variation.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the item's associated location.</param>
        /// <param name="itemId">Required parameter: The ID of the item to modify.</param>
        /// <param name="variationId">Required parameter: The ID of the variation to modify.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.V1Variation response from the API call</return>
        [Obsolete]
        Task<Models.V1Variation> UpdateVariationAsync(
                string locationId,
                string itemId,
                string variationId,
                Models.V1Variation body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Lists all the modifier lists for a given location.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list modifier lists for.</param>
        /// <return>Returns the List<Models.V1ModifierList> response from the API call</return>
        [Obsolete]
        List<Models.V1ModifierList> ListModifierLists(string locationId);

        /// <summary>
        /// Lists all the modifier lists for a given location.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list modifier lists for.</param>
        /// <return>Returns the List<Models.V1ModifierList> response from the API call</return>
        [Obsolete]
        Task<List<Models.V1ModifierList>> ListModifierListsAsync(string locationId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates an item modifier list and at least 1 modifier option for it.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to create a modifier list for.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.V1ModifierList response from the API call</return>
        [Obsolete]
        Models.V1ModifierList CreateModifierList(string locationId, Models.V1ModifierList body);

        /// <summary>
        /// Creates an item modifier list and at least 1 modifier option for it.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to create a modifier list for.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.V1ModifierList response from the API call</return>
        [Obsolete]
        Task<Models.V1ModifierList> CreateModifierListAsync(string locationId, Models.V1ModifierList body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes an existing item modifier list and all modifier options
        /// associated with it.
        /// __DeleteModifierList__ returns nothing on success but Connect SDKs
        /// map the empty response to an empty `V1DeleteModifierListRequest` object
        /// as documented below.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the item's associated location.</param>
        /// <param name="modifierListId">Required parameter: The ID of the modifier list to delete.</param>
        /// <return>Returns the Models.V1ModifierList response from the API call</return>
        [Obsolete]
        Models.V1ModifierList DeleteModifierList(string locationId, string modifierListId);

        /// <summary>
        /// Deletes an existing item modifier list and all modifier options
        /// associated with it.
        /// __DeleteModifierList__ returns nothing on success but Connect SDKs
        /// map the empty response to an empty `V1DeleteModifierListRequest` object
        /// as documented below.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the item's associated location.</param>
        /// <param name="modifierListId">Required parameter: The ID of the modifier list to delete.</param>
        /// <return>Returns the Models.V1ModifierList response from the API call</return>
        [Obsolete]
        Task<Models.V1ModifierList> DeleteModifierListAsync(string locationId, string modifierListId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Provides the details for a single modifier list.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the item's associated location.</param>
        /// <param name="modifierListId">Required parameter: The modifier list's ID.</param>
        /// <return>Returns the Models.V1ModifierList response from the API call</return>
        [Obsolete]
        Models.V1ModifierList RetrieveModifierList(string locationId, string modifierListId);

        /// <summary>
        /// Provides the details for a single modifier list.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the item's associated location.</param>
        /// <param name="modifierListId">Required parameter: The modifier list's ID.</param>
        /// <return>Returns the Models.V1ModifierList response from the API call</return>
        [Obsolete]
        Task<Models.V1ModifierList> RetrieveModifierListAsync(string locationId, string modifierListId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Modifies the details of an existing item modifier list.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the item's associated location.</param>
        /// <param name="modifierListId">Required parameter: The ID of the modifier list to edit.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.V1ModifierList response from the API call</return>
        [Obsolete]
        Models.V1ModifierList UpdateModifierList(string locationId, string modifierListId, Models.V1UpdateModifierListRequest body);

        /// <summary>
        /// Modifies the details of an existing item modifier list.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the item's associated location.</param>
        /// <param name="modifierListId">Required parameter: The ID of the modifier list to edit.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.V1ModifierList response from the API call</return>
        [Obsolete]
        Task<Models.V1ModifierList> UpdateModifierListAsync(string locationId, string modifierListId, Models.V1UpdateModifierListRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates an item modifier option and adds it to a modifier list.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the item's associated location.</param>
        /// <param name="modifierListId">Required parameter: The ID of the modifier list to edit.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.V1ModifierOption response from the API call</return>
        [Obsolete]
        Models.V1ModifierOption CreateModifierOption(string locationId, string modifierListId, Models.V1ModifierOption body);

        /// <summary>
        /// Creates an item modifier option and adds it to a modifier list.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the item's associated location.</param>
        /// <param name="modifierListId">Required parameter: The ID of the modifier list to edit.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.V1ModifierOption response from the API call</return>
        [Obsolete]
        Task<Models.V1ModifierOption> CreateModifierOptionAsync(string locationId, string modifierListId, Models.V1ModifierOption body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes an existing item modifier option from a modifier list.
        /// __DeleteModifierOption__ returns nothing on success but Connect
        /// SDKs map the empty response to an empty `V1DeleteModifierOptionRequest`
        /// object.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the item's associated location.</param>
        /// <param name="modifierListId">Required parameter: The ID of the modifier list to delete.</param>
        /// <param name="modifierOptionId">Required parameter: The ID of the modifier list to edit.</param>
        /// <return>Returns the Models.V1ModifierOption response from the API call</return>
        [Obsolete]
        Models.V1ModifierOption DeleteModifierOption(string locationId, string modifierListId, string modifierOptionId);

        /// <summary>
        /// Deletes an existing item modifier option from a modifier list.
        /// __DeleteModifierOption__ returns nothing on success but Connect
        /// SDKs map the empty response to an empty `V1DeleteModifierOptionRequest`
        /// object.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the item's associated location.</param>
        /// <param name="modifierListId">Required parameter: The ID of the modifier list to delete.</param>
        /// <param name="modifierOptionId">Required parameter: The ID of the modifier list to edit.</param>
        /// <return>Returns the Models.V1ModifierOption response from the API call</return>
        [Obsolete]
        Task<Models.V1ModifierOption> DeleteModifierOptionAsync(string locationId, string modifierListId, string modifierOptionId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Modifies the details of an existing item modifier option.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the item's associated location.</param>
        /// <param name="modifierListId">Required parameter: The ID of the modifier list to edit.</param>
        /// <param name="modifierOptionId">Required parameter: The ID of the modifier list to edit.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.V1ModifierOption response from the API call</return>
        [Obsolete]
        Models.V1ModifierOption UpdateModifierOption(
                string locationId,
                string modifierListId,
                string modifierOptionId,
                Models.V1ModifierOption body);

        /// <summary>
        /// Modifies the details of an existing item modifier option.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the item's associated location.</param>
        /// <param name="modifierListId">Required parameter: The ID of the modifier list to edit.</param>
        /// <param name="modifierOptionId">Required parameter: The ID of the modifier list to edit.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.V1ModifierOption response from the API call</return>
        [Obsolete]
        Task<Models.V1ModifierOption> UpdateModifierOptionAsync(
                string locationId,
                string modifierListId,
                string modifierOptionId,
                Models.V1ModifierOption body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Lists all Favorites pages (in Square Point of Sale) for a given
        /// location.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list Favorites pages for.</param>
        /// <return>Returns the List<Models.V1Page> response from the API call</return>
        [Obsolete]
        List<Models.V1Page> ListPages(string locationId);

        /// <summary>
        /// Lists all Favorites pages (in Square Point of Sale) for a given
        /// location.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list Favorites pages for.</param>
        /// <return>Returns the List<Models.V1Page> response from the API call</return>
        [Obsolete]
        Task<List<Models.V1Page>> ListPagesAsync(string locationId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a Favorites page in Square Point of Sale.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to create an item for.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.V1Page response from the API call</return>
        [Obsolete]
        Models.V1Page CreatePage(string locationId, Models.V1Page body);

        /// <summary>
        /// Creates a Favorites page in Square Point of Sale.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to create an item for.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.V1Page response from the API call</return>
        [Obsolete]
        Task<Models.V1Page> CreatePageAsync(string locationId, Models.V1Page body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes an existing Favorites page and all of its cells.
        /// __DeletePage__ returns nothing on success but Connect SDKs
        /// map the empty response to an empty `V1DeletePageRequest` object.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the Favorites page's associated location.</param>
        /// <param name="pageId">Required parameter: The ID of the page to delete.</param>
        /// <return>Returns the Models.V1Page response from the API call</return>
        [Obsolete]
        Models.V1Page DeletePage(string locationId, string pageId);

        /// <summary>
        /// Deletes an existing Favorites page and all of its cells.
        /// __DeletePage__ returns nothing on success but Connect SDKs
        /// map the empty response to an empty `V1DeletePageRequest` object.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the Favorites page's associated location.</param>
        /// <param name="pageId">Required parameter: The ID of the page to delete.</param>
        /// <return>Returns the Models.V1Page response from the API call</return>
        [Obsolete]
        Task<Models.V1Page> DeletePageAsync(string locationId, string pageId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Modifies the details of a Favorites page in Square Point of Sale.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the Favorites page's associated location</param>
        /// <param name="pageId">Required parameter: The ID of the page to modify.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.V1Page response from the API call</return>
        [Obsolete]
        Models.V1Page UpdatePage(string locationId, string pageId, Models.V1Page body);

        /// <summary>
        /// Modifies the details of a Favorites page in Square Point of Sale.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the Favorites page's associated location</param>
        /// <param name="pageId">Required parameter: The ID of the page to modify.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.V1Page response from the API call</return>
        [Obsolete]
        Task<Models.V1Page> UpdatePageAsync(string locationId, string pageId, Models.V1Page body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a cell from a Favorites page in Square Point of Sale.
        /// __DeletePageCell__ returns nothing on success but Connect SDKs
        /// map the empty response to an empty `V1DeletePageCellRequest` object
        /// as documented below.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the Favorites page's associated location.</param>
        /// <param name="pageId">Required parameter: The ID of the page to delete.</param>
        /// <param name="row">Optional parameter: The row of the cell to clear. Always an integer between 0 and 4, inclusive. Row 0 is the top row.</param>
        /// <param name="column">Optional parameter: The column of the cell to clear. Always an integer between 0 and 4, inclusive. Column 0 is the leftmost column.</param>
        /// <return>Returns the Models.V1Page response from the API call</return>
        [Obsolete]
        Models.V1Page DeletePageCell(
                string locationId,
                string pageId,
                string row = null,
                string column = null);

        /// <summary>
        /// Deletes a cell from a Favorites page in Square Point of Sale.
        /// __DeletePageCell__ returns nothing on success but Connect SDKs
        /// map the empty response to an empty `V1DeletePageCellRequest` object
        /// as documented below.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the Favorites page's associated location.</param>
        /// <param name="pageId">Required parameter: The ID of the page to delete.</param>
        /// <param name="row">Optional parameter: The row of the cell to clear. Always an integer between 0 and 4, inclusive. Row 0 is the top row.</param>
        /// <param name="column">Optional parameter: The column of the cell to clear. Always an integer between 0 and 4, inclusive. Column 0 is the leftmost column.</param>
        /// <return>Returns the Models.V1Page response from the API call</return>
        [Obsolete]
        Task<Models.V1Page> DeletePageCellAsync(
                string locationId,
                string pageId,
                string row = null,
                string column = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Modifies a cell of a Favorites page in Square Point of Sale.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the Favorites page's associated location.</param>
        /// <param name="pageId">Required parameter: The ID of the page the cell belongs to.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.V1Page response from the API call</return>
        [Obsolete]
        Models.V1Page UpdatePageCell(string locationId, string pageId, Models.V1PageCell body);

        /// <summary>
        /// Modifies a cell of a Favorites page in Square Point of Sale.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the Favorites page's associated location.</param>
        /// <param name="pageId">Required parameter: The ID of the page the cell belongs to.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.V1Page response from the API call</return>
        [Obsolete]
        Task<Models.V1Page> UpdatePageCellAsync(string locationId, string pageId, Models.V1PageCell body, CancellationToken cancellationToken = default);

    }
}