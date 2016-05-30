using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Claytondus.Square.Logging;
using Claytondus.Square.Models;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;

namespace Claytondus.Square
{
    public class SquareClient
    {
	    protected readonly string SquareUrl = "https://connect.squareup.com";
	    private readonly string _authToken;
        private static readonly ILog Log = LogProvider.GetCurrentClassLogger();

        public SquareClient()
		{
		}

		public SquareClient(string authToken)
		{
			_authToken = authToken;
		}

	    protected async Task<SquareResponse<T>> GetAsync<T>(string resource, object queryParams = null) where T : class
	    {
            Log.Trace("GET " + resource);
		    try
		    {
			    var response = await new Url(SquareUrl)
				    .AppendPathSegment(resource)
				    .SetQueryParams(queryParams)
				    .WithDefaults()
				    .WithOAuthBearerToken(_authToken)
					.GetAsync();
                Log.Trace(response.RequestMessage.ToString);
			    var responseBody = await response.Content.ReadAsStringAsync();
				var settings = new JsonSerializerSettings
				{
					Error = (sender, args) =>
					{
						if (System.Diagnostics.Debugger.IsAttached)
						{
							System.Diagnostics.Debugger.Break();
						}
					}
				};
			    var responseDeserialized = JsonConvert.DeserializeObject<T>(responseBody, settings);
			    var linkHeader = response.Headers.FirstOrDefault(h => h.Key == "Link");
		        var link = linkHeader.Value?.FirstOrDefault() ?? string.Empty;
                var responseObject = new SquareResponse<T>
			    {
				    Response = responseDeserialized,
				    Link = link
			    };
			    return responseObject;
		    }
			catch (FlurlHttpTimeoutException)
			{
				throw new SquareException("timeout", "Request timed out.");
			}
			catch (FlurlHttpException ex)
			{
                var response = ex.GetResponseString();
                var squareEx = new SquareException("error", response) { Method = "GET", Resource = resource, HttpStatus = ex.Call.HttpStatus };
                throw squareEx;
            }
		}

		protected async Task<T> GetLinkAsync<T>(Url link)
		{
            Log.Trace("GET " + link);
            try
			{
				var response = await link
					.WithDefaults()
					.WithOAuthBearerToken(_authToken)
					.GetJsonAsync<T>();
			    return response;
			}
			catch (FlurlHttpTimeoutException)
			{
				throw new SquareException("timeout", "Request timed out.");
			}
			catch (FlurlHttpException ex)
			{
				var response = ex.GetResponseString();
				var squareEx = new SquareException("error", response) { Method = "GET", Resource = link, HttpStatus = ex.Call.HttpStatus };
				throw squareEx;
			}
		}

		protected async Task<T> PostAsync<T>(string resource, object body, string authenticator = "")
	    {
            Log.Trace("POST " + resource);
            try
			{
				var request =  new Url(SquareUrl)
                    .AppendPathSegment(resource)
					.WithDefaults();
			    request = authenticator == string.Empty
                    ? request.WithOAuthBearerToken(_authToken) 
                    : request.WithHeader("Authorization", authenticator);
			    return await request.PostJsonAsync(body)
					.ReceiveJson<T>();
			}
			catch (FlurlHttpTimeoutException)
			{
				throw new SquareException("timeout", "Request timed out.");
			}
			catch (FlurlHttpException ex)
			{
                var response = ex.GetResponseString();
                var squareEx = new SquareException("error", response) { Method = "POST", Resource = resource, HttpStatus = ex.Call.HttpStatus };
                throw squareEx;
            }
			
	    }

        protected async Task<T> PostAsync<T>(string resource, MultipartFormDataContent content)
        {
            Log.Trace("(Multipart) POST " + resource);
            try
            {
                return await new Url(SquareUrl)
                    .AppendPathSegment(resource)
                    .WithHeader("Content-Type", "multipart/form-data")
                    .WithOAuthBearerToken(_authToken)
                    .PostMultipartAsync(content)
                    .ReceiveJson<T>();
            }
            catch (FlurlHttpTimeoutException)
            {
                throw new SquareException("timeout", "Request timed out.");
            }
            catch (FlurlHttpException ex)
            {
                var response = ex.GetResponseString();
                var squareEx = new SquareException("error", response) { Method = "POST", Resource = resource, HttpStatus = ex.Call.HttpStatus };
                throw squareEx;
            }
        }

		protected async Task<T> PutAsync<T>(string resource, object body = null)
		{
            Log.Trace("PUT " + resource);
            try
			{
				var response = await new Url(SquareUrl)
                    .AppendPathSegment(resource)
					.WithDefaults()
					.WithOAuthBearerToken(_authToken)
					.PutJsonAsync(body)
					.ReceiveJson<T>();
			    return response;
			}
			catch (FlurlHttpTimeoutException)
			{
				throw new SquareException("timeout", "Request timed out.");
			}
			catch (FlurlHttpException ex)
			{
                var response = ex.GetResponseString();
                var squareEx = new SquareException("error", response) { Method = "PUT", Resource = resource, HttpStatus = ex.Call.HttpStatus };
                throw squareEx;
            }
		}

		protected async Task<T> DeleteAsync<T>(string resource, object queryParams = null)
		{
            Log.Trace("DELETE " + resource);
            try
            {
                var response = await new Url(SquareUrl)
                    .AppendPathSegment(resource)
                    .SetQueryParams(queryParams)
                    .WithDefaults()
                    .WithOAuthBearerToken(_authToken)
                    .DeleteAsync()
                    .ReceiveJson<T>();
                return response;
            }
			catch (FlurlHttpTimeoutException)
			{
				throw new SquareException("timeout", "Request timed out.");
			}
			catch (FlurlHttpException ex)
			{
                var response = ex.GetResponseString();
                var squareEx = new SquareException("error", response) { Method = "DELETE", Resource = resource, HttpStatus = ex.Call.HttpStatus };
                throw squareEx;
            }
		}
	}

	public static class UrlExtension
	{
		public static FlurlClient WithDefaults(this Url url)
		{
			return url
				.WithTimeout(10)
				.WithHeader("Accept", "application/json");
		}
	}
}
