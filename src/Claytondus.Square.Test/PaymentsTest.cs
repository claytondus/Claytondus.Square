using System;
using System.Configuration;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Claytondus.Square;
using Claytondus.Square.Models;
using MSTestExtensions;
using Newtonsoft.Json;

namespace Claytondus.Square.Test
{
	[TestClass]
	public class PaymentsTest
	{
		private readonly string _testAuthToken = ConfigurationManager.AppSettings["squareToken"];

		[TestMethod]
		public async Task ListPaymentsTest()
		{
			var client = new SquareTransactionClient(_testAuthToken);
			var payments = await client.ListPaymentsAsync(DateTime.UtcNow-TimeSpan.FromDays(1), DateTime.UtcNow);
			Assert.IsNotNull(payments);
			Trace.Write(JsonConvert.SerializeObject(payments));
		}

		[TestMethod]
		public async Task RetrievePaymentTest()
		{
			var client = new SquareTransactionClient(_testAuthToken);
			var payment = await client.RetrievePaymentAsync("e9b62dfe-4d42-45bf-8ecb-a43a12c3f4df");
			Assert.IsNotNull(payment);
			Trace.Write(JsonConvert.SerializeObject(payment));
		}


		[TestMethod]
		public async Task RetrievePaymentThrows404NotFound()
		{
			const string expectedType = "not_found";
			var client = new SquareTransactionClient(_testAuthToken);

			var ex = await AsyncAssertExtension.ThrowsAsync<SquareException>(async () =>
			{
				await client.RetrievePaymentAsync("e9b62dfe-4d42-45bf-8ecb-a43a12c3f4");
			});
			Assert.AreEqual(expectedType, ex.SquareType);
			Trace.Write(ex.SquareType);
		}
	}
}
