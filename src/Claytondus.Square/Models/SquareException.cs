using System;
using System.Net;
using Newtonsoft.Json;

namespace Claytondus.Square.Models
{
	public class SquareException : Exception
	{
		[JsonConstructor]
		public SquareException(string type, string message) : base(message)
		{
			SquareType = type;
		    ResponseBody = message;
		}

		public string SquareType { get; set; }
        public string RequestBody { get; set; }
        public string ResponseBody { get; set; }

		public HttpStatusCode? HttpStatus { get; set; }

        public string Method { get; set; }
        public string Resource { get; set; }
        public string HttpMessage { get; set; }


	}
}
