using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claytondus.Square.Driver
{
	class Program
	{
		private static readonly string _testAuthToken = "Jh0BLak6h3qJhw6ferNj-Q";

		static void Main(string[] args)
		{
			var client = new SquareTransactionClient(_testAuthToken);
			var paymentTask = Task.Run(async () => await client.RetrievePaymentAsync("e9b62dfe-4d42-45bf-8ecb-a43a12c3"));
			paymentTask.Wait();
			var payment = paymentTask.Result;
		}
	}
}
