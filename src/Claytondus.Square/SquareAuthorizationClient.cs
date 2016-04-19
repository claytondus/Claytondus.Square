using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Security.Policy;
using System.Threading.Tasks;
using Claytondus.Square.Models;
using Flurl.Http;

namespace Claytondus.Square
{
	/// <summary>
	/// Square Connect OAuth Authorization Management API: 
	/// With these endpoints, Square merchants can:
	/// -Renew or revoke authorization tokens
	/// </summary>
	public class SquareAuthorizationClient : SquareClient
	{
        private readonly string _clientId;
	    private readonly string _clientSecret;

	    ///  <summary>
	    ///      Instantiate a client for modifying Square Connect OAuth tokens.
	    ///  </summary>
	    /// <param name="clientId"></param>
	    /// <param name="clientSecret"></param>
	    public SquareAuthorizationClient(string clientId = "", string clientSecret = "") 
		{
			_clientId = clientId;
		    _clientSecret = clientSecret;
		}

	    public string GetAuthorizeUrl(string csrfToken)
	    {
	        return SquareUrl 
                + @"/oauth2/authorize"
                + @"?client_id=" + _clientId
                + @"&response_type=code"
                + @"&scope=MERCHANT_PROFILE_READ ITEMS_READ ITEMS_WRITE PAYMENTS_READ ORDERS_READ ORDERS_WRITE"
                + @"&state=" + csrfToken;
        }

	    public async Task<SquareOAuthToken> ObtainTokenAsync(string code)
	    {
	        var request = new
	        {
	            client_id = _clientId,
	            client_secret = _clientSecret,
	            code = code
	        };
	        return await PostAsync<SquareOAuthToken>("/oauth2/token", request, " ");
	    }

        public async Task<SquareOAuthToken> RenewTokenAsync(string accessToken)
		{
		    return await
		        PostAsync<SquareOAuthToken>("/oauth2/clients/" + _clientId + "/access-token/renew",
		            new {access_token = accessToken}, "Client " + _clientSecret);
        }


        public async Task RevokeTokenAsync(string accessToken, string merchantId)
        {
            var request = new Dictionary<string, string> {{ "client_id", _clientId }};
            
            if (string.IsNullOrEmpty(accessToken) && !string.IsNullOrEmpty(merchantId))
            {
                request.Add("merchant_id", merchantId);
            }
            else if (string.IsNullOrEmpty(merchantId) && !string.IsNullOrEmpty(accessToken))
            {
                request.Add("access_token", accessToken);
            }
            else
            {
                throw new ArgumentException("Provide either an accessToken or merchantId, but not both.");
            }

            await PostAsync<object>("/oauth2/revoke", request, "Client " + _clientSecret);
        }

    }
}