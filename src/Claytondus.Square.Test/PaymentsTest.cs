using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Claytondus.Square;
using Newtonsoft.Json;

namespace Claytondus.Square.Test
{
	[TestClass]
	public class PaymentsTest
	{
		private readonly string _testAuthToken = "Jh0BLak6h3qJhw6ferNj-Q";

		[TestMethod]
		public async Task ListPaymentsTest()
		{
			var client = new SquareTransactionClient(_testAuthToken);
			var payments = await client.ListPayments(DateTime.UtcNow-TimeSpan.FromDays(14), DateTime.UtcNow);
			Assert.IsNotNull(payments);
			Trace.Write(JsonConvert.SerializeObject(payments));
		}

		[TestMethod]
		public async Task RetrievePaymentTest()
		{
			var client = new SquareTransactionClient(_testAuthToken);
			var payment = await client.RetrievePayment("e9b62dfe-4d42-45bf-8ecb-a43a12c3f4df");
			Assert.IsNotNull(payment);
			Trace.Write(JsonConvert.SerializeObject(payment));
		}
	}
}
