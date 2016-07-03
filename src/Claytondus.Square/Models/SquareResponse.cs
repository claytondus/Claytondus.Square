using Flurl;

namespace Claytondus.Square.Models
{
	public class SquareResponse<T> where T : class
	{
		public string Link { get; set; }

		public T Response { get; set; }

	}
}