using System.Threading.Tasks;
using Claytondus.Square.Models;
using Flurl;
using Flurl.Http;

namespace Claytondus.Square
{
    public class SquareClient
    {
	    protected readonly Url _squareUrl = new Url("https://connect.squareup.com");
	    private readonly string _authToken;

		public SquareClient()
		{
		}

		public SquareClient(string authToken)
		{
			_authToken = authToken;
		}

	    protected async Task<T> GetAsync<T>(string resource, object queryParams = null)
	    {
		    try
		    {
			    return await _squareUrl
				    .AppendPathSegment(resource)
				    .SetQueryParams(queryParams)
				    .WithDefaults()
				    .WithOAuthBearerToken(_authToken)
				    .GetJsonAsync<T>();
			}
			catch (FlurlHttpTimeoutException)
			{
				throw new SquareException() { SquareType = "timeout", SquareMessage = "Request timed out." };
			}
			catch (FlurlHttpException ex)
			{
				var squareEx = ex.GetResponseJson<SquareException>();
				squareEx.HttpStatus = ex.Call.HttpStatus;
				throw squareEx;
			}
		}

	    protected async Task<T> PostAsync<T>(string resource, object body)
	    {
			try
			{
				return await _squareUrl
					.AppendPathSegment(resource)
					.WithDefaults()
					.WithOAuthBearerToken(_authToken)
					.PostJsonAsync(body)
					.ReceiveJson<T>();
			}
			catch (FlurlHttpTimeoutException)
			{
				throw new SquareException() { SquareType = "timeout", SquareMessage = "Request timed out." };
			}
			catch (FlurlHttpException ex)
			{
				var squareEx = ex.GetResponseJson<SquareException>();
				squareEx.HttpStatus = ex.Call.HttpStatus;
				throw squareEx;
			}
			
	    }

		protected async Task<T> PutAsync<T>(string resource, object body)
		{
			try
			{
				return await _squareUrl
					.AppendPathSegment(resource)
					.WithDefaults()
					.WithOAuthBearerToken(_authToken)
					.PutJsonAsync(body)
					.ReceiveJson<T>();
			}
			catch (FlurlHttpTimeoutException)
			{
				throw new SquareException() { SquareType = "timeout", SquareMessage = "Request timed out." };
			}
			catch (FlurlHttpException ex)
			{
				var squareEx = ex.GetResponseJson<SquareException>();
				squareEx.HttpStatus = ex.Call.HttpStatus;
				throw squareEx;
			}
		}

		protected async Task DeleteAsync(string resource, object queryParams)
		{
			try
			{
				await _squareUrl
					.AppendPathSegment(resource)
					.SetQueryParams(queryParams)
					.WithDefaults()
					.WithOAuthBearerToken(_authToken)
					.DeleteAsync();
			}
			catch (FlurlHttpTimeoutException)
			{
				throw new SquareException() { SquareType = "timeout", SquareMessage = "Request timed out." };
			}
			catch (FlurlHttpException ex)
			{
				var squareEx = ex.GetResponseJson<SquareException>();
				squareEx.HttpStatus = ex.Call.HttpStatus;
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
