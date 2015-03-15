using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Claytondus.Square.Models;

namespace Claytondus.Square
{
	public class SquareTransactionClient : SquareClient
	{
		public SquareTransactionClient(string authToken) : base(authToken)
		{
		}

		public async Task<List<SquarePayment>> ListPayments(DateTimeOffset begin, DateTimeOffset end, string order = "ASC", int limit = 100)
		{
			var paymentsCriteria = new
			{
				begin_time = begin.ToString("s"),
				end_time = end.ToString("s"),
				order,
				limit
			};
			return await GetAsync<List<SquarePayment>>("/v1/me/payments", paymentsCriteria);
		}

		public async Task<SquarePayment> RetrievePayment(string paymentId)
		{
			return await GetAsync<SquarePayment>("/v1/me/payments/"+paymentId);
		}
	}
}
