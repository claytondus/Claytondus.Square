using System;
using System.Collections.Generic;
using System.Dynamic;
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


		public async Task<SquareOAuthToken> RenewTokenAsync(string accessToken)
		{
            try
            {
                return await SquareUrl
                    .AppendPathSegment("/oauth2/clients/"+_clientId+"/access-token/renew")
                    .WithDefaults()
                    .WithHeader("Authorization","Client "+_clientSecret)
                    .PostJsonAsync(new {access_token = accessToken})
                    .ReceiveJson<SquareOAuthToken>();
            }
            catch (FlurlHttpTimeoutException)
            {
                throw new SquareException("timeout", "Request timed out.");
            }
            catch (FlurlHttpException ex)
            {
                var squareEx = ex.GetResponseJson<SquareException>();
                squareEx.HttpStatus = ex.Call.HttpStatus;
                throw squareEx;
            }
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

            try
            {
                await SquareUrl
                    .AppendPathSegment("/oauth2/revoke")
                    .WithDefaults()
                    .WithHeader("Authorization", "Client " + _clientSecret)
                    .PostJsonAsync(request)
                    .ReceiveJson();
            }
            catch (FlurlHttpTimeoutException)
            {
                throw new SquareException("timeout", "Request timed out.");
            }
            catch (FlurlHttpException ex)
            {
                var squareEx = ex.GetResponseJson<SquareException>();
                squareEx.HttpStatus = ex.Call.HttpStatus;
                throw squareEx;
            }
        }

    }
}