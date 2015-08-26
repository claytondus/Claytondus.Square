using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Claytondus.Square.Models;

namespace Claytondus.Square
{
	/// <summary>
	/// Square Connect Transaction Management API: 
	/// With these endpoints, Square merchants can:
	/// -Retrieve reports of completed payments, refunds, and settlements
	/// -Issue refunds for completed payments
	/// -Manage Square Market orders
	/// </summary>
	public class SquareTransactionClient : SquareClient
	{
		private readonly string _merchantId;
		/// <summary>
		///     Instantiate a client for accessing Square transactions.
		/// </summary>
		/// <param name="authToken">Merchant OAuth token or personal access token.</param>
		/// <param name="merchantId">
		///		Your Square-issued ID, if you've obtained it from another endpoint. 
		///		If you haven't, specify me for the Connect API to automatically determine your merchant ID based on your request's access token.
		/// </param>
		public SquareTransactionClient(string authToken, string merchantId = "me") : base(authToken)
		{
			_merchantId = merchantId;
		}

		/// <summary>
		///     Provides summary information for all payments taken by a merchant or any of the merchant's
		///     mobile staff during a date range. Date ranges cannot exceed one year in length. See Date ranges
		///     for details of inclusive and exclusive dates.
		///     Required permissions: PAYMENTS_READ
		/// </summary>
		/// <param name="begin" cref="DateTimeOffset">
		///     The beginning of the requested reporting period.
		///     If this value is before January 1, 2013 (2013-01-01T00:00:00Z), this endpoint returns an error.
		/// </param>
		/// <param name="end" cref="DateTimeOffset">
		///     The end of the requested reporting period, in ISO 8601 format.
		///     If this value is more than one year greater than begin_time, this endpoint returns an error.
		/// </param>
		/// <param name="order" cref="SquareListOrder">The order in which payments are listed in the response.  Default: "ASC"</param>
		/// <param name="limit">
		///     The maximum number of payments to return in a single response.
		///     This value cannot exceed 200.
		///     Default value: 100.
		/// </param>
		/// <returns cref="SquarePayment">List of SquarePayment objects.</returns>
		/// <exception cref="SquareException">Error returned from Square Connect.</exception>
		public async Task<SquareResponse<List<SquarePayment>>> ListPaymentsAsync(DateTimeOffset? begin = null, DateTimeOffset? end = null,
			SquareListOrder order = null, int limit = 100)
		{
			begin = begin ?? DateTimeOffset.UtcNow.AddYears(-1);
			end = end ?? DateTimeOffset.UtcNow;
			order = order ?? SquareListOrder.ASC;
			if (limit < 1 || limit > 200) throw new ArgumentOutOfRangeException("limit");

			var paymentsCriteria = new
			{
				begin_time = begin.Value.ToString("s"),
				end_time = end.Value.ToString("s"),
				order,
				limit
			};
			return await GetAsync<List<SquarePayment>>("/v1/" + _merchantId + "/payments", paymentsCriteria);
		}

		/// <summary>
		///     Provides comprehensive information for a single payment.
		///     Required permissions: PAYMENTS_READ
		/// </summary>
		/// <param name="paymentId">
		///     The payment's Square-issued ID. You obtain this value from Payment objects returned
		///     by the List Payments endpoint, or Settlement objects returned by the List Settlements endpoint.
		/// </param>
		/// <returns>A SquarePayment object that describes the requested payment.</returns>
		/// <exception cref="SquareException">Error returned from Square Connect.</exception>
		public async Task<SquareResponse<SquarePayment>> RetrievePaymentAsync(string paymentId)
		{
			return await GetAsync<SquarePayment>("/v1/" + _merchantId + "/payments/" + paymentId);
		}

		public async Task<SquareResponse<List<SquareOrder>>> ListOrdersAsync(int limit = 100, SquareListOrder order = null)
		{
			if (limit < 1 || limit > 200) throw new ArgumentOutOfRangeException("limit");
			order = order ?? SquareListOrder.ASC;

			var ordersCriteria = new
			{
				limit,
				order
			};
			return await GetAsync<List<SquareOrder>>("/v1/" + _merchantId + "/orders", ordersCriteria);
		}

		public async Task<SquareResponse<SquareOrder>> RetrieveOrderAsync(string orderId)
		{
			return await GetAsync<SquareOrder>("/v1/" + _merchantId + "/orders/" + orderId);
		}

	    public async Task<SquareOrder> UpdateOrderAsync(string orderId, SquareOrderUpdate update)
	    {
	        return await PutAsync<SquareOrder>("/v1/" + _merchantId + "/orders/" + orderId, update);
	    }

	}
}