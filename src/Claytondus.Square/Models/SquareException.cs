using System;
using System.Net;
using Newtonsoft.Json;

namespace Claytondus.Square.Models
{
	public class SquareException : Exception
	{
		[JsonProperty(PropertyName = "type")]
		public string SquareType { get; set; }

		[JsonProperty(PropertyName = "message")]
		public string SquareMessage { get; set; }

		public HttpStatusCode? HttpStatus { get; set; }

	}
}
