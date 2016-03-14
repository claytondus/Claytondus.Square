using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Claytondus.Square.Models
{
    public class SquareBatchRequest
    {
        [JsonProperty(PropertyName = "method")]
        public string Method { get; set; }

        [JsonProperty(PropertyName = "relative_path")]
        public string RelativePath { get; set; }

        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }

        [JsonProperty(PropertyName = "body")]
        public object Body { get; set; }

        [JsonProperty(PropertyName = "request_id")]
        public string RequestId { get; set; }
    }

    public class SquareBatchResponse
    {
        [JsonProperty(PropertyName = "status_code")]
        public int StatusCode { get; set; }

        [JsonProperty(PropertyName = "headers")]
        public dynamic Headers { get; set; }

        [JsonProperty(PropertyName = "body")]
        public object Body { get; set; }

        [JsonProperty(PropertyName = "request_id")]
        public string RequestId { get; set; }
    }
}
