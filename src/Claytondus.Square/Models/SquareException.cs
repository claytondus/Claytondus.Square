using System;
using System.Net;
using System.Runtime.Serialization;
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

		protected SquareException(SerializationInfo info, StreamingContext context)
		{
		}

		public string SquareType { get; set; }
        public string ResponseBody { get; set; }

		public HttpStatusCode? HttpStatus { get; set; }

        public string Method { get; set; }
        public string Resource { get; set; }


	}
}
