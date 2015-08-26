using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Claytondus.Square.Models
{
    public class SquareOAuthToken
    {
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }

        [JsonProperty(PropertyName = "token_type")]
        public string TokenType { get; set; }

        [JsonProperty(PropertyName = "expires_at")]
        public DateTimeOffset ExpiresAt { get; set; }

        [JsonProperty(PropertyName = "merchant_id")]
        public string MerchantId { get; set; }
    }
}
