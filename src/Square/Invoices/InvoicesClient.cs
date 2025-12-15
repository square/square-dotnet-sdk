using System.Text.Json;
using Square;
using Square.Core;

namespace Square.Invoices;

public partial class InvoicesClient
{
    private RawClient _client;

    internal InvoicesClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Returns a list of invoices for a given location. The response
    /// is paginated. If truncated, the response includes a `cursor` that you
    /// use in a subsequent request to retrieve the next set of invoices.
    /// </summary>
    private async Task<ListInvoicesResponse> ListInternalAsync(
        ListInvoicesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        _query["location_id"] = request.LocationId;
        if (request.Cursor != null)
        {
            _query["cursor"] = request.Cursor;
        }
        if (request.Limit != null)
        {
            _query["limit"] = request.Limit.Value.ToString();
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = "v2/invoices",
                    Query = _query,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<ListInvoicesResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new SquareException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            throw new SquareApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <summary>
    /// Returns a list of invoices for a given location. The response
    /// is paginated. If truncated, the response includes a `cursor` that you
    /// use in a subsequent request to retrieve the next set of invoices.
    /// </summary>
    /// <example><code>
    /// await client.Invoices.ListAsync(
    ///     new ListInvoicesRequest
    ///     {
    ///         LocationId = "location_id",
    ///         Cursor = "cursor",
    ///         Limit = 1,
    ///     }
    /// );
    /// </code></example>
    public async Task<Pager<Invoice>> ListAsync(
        ListInvoicesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            ListInvoicesRequest,
            RequestOptions?,
            ListInvoicesResponse,
            string?,
            Invoice
        >
            .CreateInstanceAsync(
                request,
                options,
                ListInternalAsync,
                (request, cursor) =>
                {
                    request.Cursor = cursor;
                },
                response => response.Cursor,
                response => response.Invoices?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Creates a draft [invoice](entity:Invoice)
    /// for an order created using the Orders API.
    ///
    /// A draft invoice remains in your account and no action is taken.
    /// You must publish the invoice before Square can process it (send it to the customer's email address or charge the customer’s card on file).
    /// </summary>
    /// <example><code>
    /// await client.Invoices.CreateAsync(
    ///     new CreateInvoiceRequest
    ///     {
    ///         Invoice = new Invoice
    ///         {
    ///             LocationId = "ES0RJRZYEC39A",
    ///             OrderId = "CAISENgvlJ6jLWAzERDzjyHVybY",
    ///             PrimaryRecipient = new InvoiceRecipient { CustomerId = "JDKYHBWT1D4F8MFH63DBMEN8Y4" },
    ///             PaymentRequests = new List&lt;InvoicePaymentRequest&gt;()
    ///             {
    ///                 new InvoicePaymentRequest
    ///                 {
    ///                     RequestType = InvoiceRequestType.Balance,
    ///                     DueDate = "2030-01-24",
    ///                     TippingEnabled = true,
    ///                     AutomaticPaymentSource = InvoiceAutomaticPaymentSource.None,
    ///                     Reminders = new List&lt;InvoicePaymentReminder&gt;()
    ///                     {
    ///                         new InvoicePaymentReminder
    ///                         {
    ///                             RelativeScheduledDays = -1,
    ///                             Message = "Your invoice is due tomorrow",
    ///                         },
    ///                     },
    ///                 },
    ///             },
    ///             DeliveryMethod = InvoiceDeliveryMethod.Email,
    ///             InvoiceNumber = "inv-100",
    ///             Title = "Event Planning Services",
    ///             Description = "We appreciate your business!",
    ///             ScheduledAt = "2030-01-13T10:00:00Z",
    ///             AcceptedPaymentMethods = new InvoiceAcceptedPaymentMethods
    ///             {
    ///                 Card = true,
    ///                 SquareGiftCard = false,
    ///                 BankAccount = false,
    ///                 BuyNowPayLater = false,
    ///                 CashAppPay = false,
    ///             },
    ///             CustomFields = new List&lt;InvoiceCustomField&gt;()
    ///             {
    ///                 new InvoiceCustomField
    ///                 {
    ///                     Label = "Event Reference Number",
    ///                     Value = "Ref. #1234",
    ///                     Placement = InvoiceCustomFieldPlacement.AboveLineItems,
    ///                 },
    ///                 new InvoiceCustomField
    ///                 {
    ///                     Label = "Terms of Service",
    ///                     Value = "The terms of service are...",
    ///                     Placement = InvoiceCustomFieldPlacement.BelowLineItems,
    ///                 },
    ///             },
    ///             SaleOrServiceDate = "2030-01-24",
    ///             StorePaymentMethodEnabled = false,
    ///         },
    ///         IdempotencyKey = "ce3748f9-5fc1-4762-aa12-aae5e843f1f4",
    ///     }
    /// );
    /// </code></example>
    public async Task<CreateInvoiceResponse> CreateAsync(
        CreateInvoiceRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = "v2/invoices",
                    Body = request,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<CreateInvoiceResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new SquareException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            throw new SquareApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <summary>
    /// Searches for invoices from a location specified in
    /// the filter. You can optionally specify customers in the filter for whom to
    /// retrieve invoices. In the current implementation, you can only specify one location and
    /// optionally one customer.
    ///
    /// The response is paginated. If truncated, the response includes a `cursor`
    /// that you use in a subsequent request to retrieve the next set of invoices.
    /// </summary>
    /// <example><code>
    /// await client.Invoices.SearchAsync(
    ///     new SearchInvoicesRequest
    ///     {
    ///         Query = new InvoiceQuery
    ///         {
    ///             Filter = new InvoiceFilter
    ///             {
    ///                 LocationIds = new List&lt;string&gt;() { "ES0RJRZYEC39A" },
    ///                 CustomerIds = new List&lt;string&gt;() { "JDKYHBWT1D4F8MFH63DBMEN8Y4" },
    ///             },
    ///             Sort = new InvoiceSort { Field = "INVOICE_SORT_DATE", Order = SortOrder.Desc },
    ///         },
    ///         Limit = 100,
    ///     }
    /// );
    /// </code></example>
    public async Task<SearchInvoicesResponse> SearchAsync(
        SearchInvoicesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = "v2/invoices/search",
                    Body = request,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<SearchInvoicesResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new SquareException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            throw new SquareApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <summary>
    /// Retrieves an invoice by invoice ID.
    /// </summary>
    /// <example><code>
    /// await client.Invoices.GetAsync(new GetInvoicesRequest { InvoiceId = "invoice_id" });
    /// </code></example>
    public async Task<GetInvoiceResponse> GetAsync(
        GetInvoicesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "v2/invoices/{0}",
                        ValueConvert.ToPathParameterString(request.InvoiceId)
                    ),
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<GetInvoiceResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new SquareException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            throw new SquareApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <summary>
    /// Updates an invoice. This endpoint supports sparse updates, so you only need
    /// to specify the fields you want to change along with the required `version` field.
    /// Some restrictions apply to updating invoices. For example, you cannot change the
    /// `order_id` or `location_id` field.
    /// </summary>
    /// <example><code>
    /// await client.Invoices.UpdateAsync(
    ///     new UpdateInvoiceRequest
    ///     {
    ///         InvoiceId = "invoice_id",
    ///         Invoice = new Invoice
    ///         {
    ///             Version = 1,
    ///             PaymentRequests = new List&lt;InvoicePaymentRequest&gt;()
    ///             {
    ///                 new InvoicePaymentRequest
    ///                 {
    ///                     Uid = "2da7964f-f3d2-4f43-81e8-5aa220bf3355",
    ///                     TippingEnabled = false,
    ///                 },
    ///             },
    ///         },
    ///         IdempotencyKey = "4ee82288-0910-499e-ab4c-5d0071dad1be",
    ///     }
    /// );
    /// </code></example>
    public async Task<UpdateInvoiceResponse> UpdateAsync(
        UpdateInvoiceRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Put,
                    Path = string.Format(
                        "v2/invoices/{0}",
                        ValueConvert.ToPathParameterString(request.InvoiceId)
                    ),
                    Body = request,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<UpdateInvoiceResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new SquareException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            throw new SquareApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <summary>
    /// Deletes the specified invoice. When an invoice is deleted, the
    /// associated order status changes to CANCELED. You can only delete a draft
    /// invoice (you cannot delete a published invoice, including one that is scheduled for processing).
    /// </summary>
    /// <example><code>
    /// await client.Invoices.DeleteAsync(
    ///     new DeleteInvoicesRequest { InvoiceId = "invoice_id", Version = 1 }
    /// );
    /// </code></example>
    public async Task<DeleteInvoiceResponse> DeleteAsync(
        DeleteInvoicesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.Version != null)
        {
            _query["version"] = request.Version.Value.ToString();
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Delete,
                    Path = string.Format(
                        "v2/invoices/{0}",
                        ValueConvert.ToPathParameterString(request.InvoiceId)
                    ),
                    Query = _query,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<DeleteInvoiceResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new SquareException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            throw new SquareApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <summary>
    /// Uploads a file and attaches it to an invoice. This endpoint accepts HTTP multipart/form-data file uploads
    /// with a JSON `request` part and a `file` part. The `file` part must be a `readable stream` that contains a file
    /// in a supported format: GIF, JPEG, PNG, TIFF, BMP, or PDF.
    ///
    /// Invoices can have up to 10 attachments with a total file size of 25 MB. Attachments can be added only to invoices
    /// in the `DRAFT`, `SCHEDULED`, `UNPAID`, or `PARTIALLY_PAID` state.
    ///
    /// __NOTE:__ When testing in the Sandbox environment, the total file size is limited to 1 KB.
    /// </summary>
    /// <example><code>
    /// await client.Invoices.CreateInvoiceAttachmentAsync(
    ///     new CreateInvoiceAttachmentRequest { InvoiceId = "invoice_id" }
    /// );
    /// </code></example>
    public async Task<CreateInvoiceAttachmentResponse> CreateInvoiceAttachmentAsync(
        CreateInvoiceAttachmentRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var multipartFormRequest_ = new MultipartFormRequest
        {
            BaseUrl = _client.Options.BaseUrl,
            Method = HttpMethod.Post,
            Path = string.Format(
                "v2/invoices/{0}/attachments",
                ValueConvert.ToPathParameterString(request.InvoiceId)
            ),
            Options = options,
        };
        multipartFormRequest_.AddJsonPart(
            "request",
            request.Request,
            "application/json; charset=utf-8"
        );
        multipartFormRequest_.AddFileParameterPart("image_file", request.ImageFile, "image/jpeg");
        var response = await _client
            .SendRequestAsync(multipartFormRequest_, cancellationToken)
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<CreateInvoiceAttachmentResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new SquareException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            throw new SquareApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <summary>
    /// Removes an attachment from an invoice and permanently deletes the file. Attachments can be removed only
    /// from invoices in the `DRAFT`, `SCHEDULED`, `UNPAID`, or `PARTIALLY_PAID` state.
    /// </summary>
    /// <example><code>
    /// await client.Invoices.DeleteInvoiceAttachmentAsync(
    ///     new DeleteInvoiceAttachmentRequest { InvoiceId = "invoice_id", AttachmentId = "attachment_id" }
    /// );
    /// </code></example>
    public async Task<DeleteInvoiceAttachmentResponse> DeleteInvoiceAttachmentAsync(
        DeleteInvoiceAttachmentRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Delete,
                    Path = string.Format(
                        "v2/invoices/{0}/attachments/{1}",
                        ValueConvert.ToPathParameterString(request.InvoiceId),
                        ValueConvert.ToPathParameterString(request.AttachmentId)
                    ),
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<DeleteInvoiceAttachmentResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new SquareException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            throw new SquareApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <summary>
    /// Cancels an invoice. The seller cannot collect payments for
    /// the canceled invoice.
    ///
    /// You cannot cancel an invoice in the `DRAFT` state or in a terminal state: `PAID`, `REFUNDED`, `CANCELED`, or `FAILED`.
    /// </summary>
    /// <example><code>
    /// await client.Invoices.CancelAsync(
    ///     new CancelInvoiceRequest { InvoiceId = "invoice_id", Version = 0 }
    /// );
    /// </code></example>
    public async Task<CancelInvoiceResponse> CancelAsync(
        CancelInvoiceRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = string.Format(
                        "v2/invoices/{0}/cancel",
                        ValueConvert.ToPathParameterString(request.InvoiceId)
                    ),
                    Body = request,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<CancelInvoiceResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new SquareException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            throw new SquareApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <summary>
    /// Publishes the specified draft invoice.
    ///
    /// After an invoice is published, Square
    /// follows up based on the invoice configuration. For example, Square
    /// sends the invoice to the customer's email address, charges the customer's card on file, or does
    /// nothing. Square also makes the invoice available on a Square-hosted invoice page.
    ///
    /// The invoice `status` also changes from `DRAFT` to a status
    /// based on the invoice configuration. For example, the status changes to `UNPAID` if
    /// Square emails the invoice or `PARTIALLY_PAID` if Square charges a card on file for a portion of the
    /// invoice amount.
    ///
    /// In addition to the required `ORDERS_WRITE` and `INVOICES_WRITE` permissions, `CUSTOMERS_READ`
    /// and `PAYMENTS_WRITE` are required when publishing invoices configured for card-on-file payments.
    /// </summary>
    /// <example><code>
    /// await client.Invoices.PublishAsync(
    ///     new PublishInvoiceRequest
    ///     {
    ///         InvoiceId = "invoice_id",
    ///         Version = 1,
    ///         IdempotencyKey = "32da42d0-1997-41b0-826b-f09464fc2c2e",
    ///     }
    /// );
    /// </code></example>
    public async Task<PublishInvoiceResponse> PublishAsync(
        PublishInvoiceRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = string.Format(
                        "v2/invoices/{0}/publish",
                        ValueConvert.ToPathParameterString(request.InvoiceId)
                    ),
                    Body = request,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<PublishInvoiceResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new SquareException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            throw new SquareApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }
}
