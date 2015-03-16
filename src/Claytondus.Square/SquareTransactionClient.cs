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
		/// <summary>
		///     Instantiate a client for accessing Square transactions.
		/// </summary>
		/// <param name="authToken">Merchant OAuth token or personal access token.</param>
		public SquareTransactionClient(string authToken) : base(authToken)
		{
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
		public async Task<List<SquarePayment>> ListPaymentsAsync(DateTimeOffset? begin = null, DateTimeOffset? end = null,
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
			return await GetAsync<List<SquarePayment>>("/v1/me/payments", paymentsCriteria);
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
		public async Task<SquarePayment> RetrievePaymentAsync(string paymentId)
		{
			return await GetAsync<SquarePayment>("/v1/me/payments/" + paymentId);
		}
	}
}