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
	public class OrdersTest
	{
		private readonly string _testAuthToken = ConfigurationManager.AppSettings["squareToken"];

		[TestMethod]
		public async Task ListOrdersTest()
		{
			var client = new SquareTransactionClient(_testAuthToken);
			var orders = await client.ListOrdersAsync();
			Assert.IsNotNull(orders);
			Trace.Write(JsonConvert.SerializeObject(orders));
		}

		[TestMethod]
		public async Task RetrieveOrderTest()
		{
			var client = new SquareTransactionClient(_testAuthToken);
			var order = await client.RetrieveOrderAsync("EHOTXPEO");
			Assert.IsNotNull(order);
			Trace.Write(JsonConvert.SerializeObject(order));
		}


		[TestMethod]
		public async Task RetrieveOrderThrows404NotFound()
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
