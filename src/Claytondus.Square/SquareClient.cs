using System.Threading.Tasks;
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
			var poco = await _squareUrl
				.AppendPathSegment(resource)
				.SetQueryParams(queryParams)
				.WithDefaults()
				.WithOAuthBearerToken(_authToken)
				.GetJsonAsync<T>();
			return poco;
	    }

	    protected async Task PostAsync<T>(string resource, object body)
	    {
		    await _squareUrl
			    .AppendPathSegment(resource)
			    .WithDefaults()
			    .WithOAuthBearerToken(_authToken)
			    .PostJsonAsync(body);
	    }

		protected async Task PutAsync<T>(string resource, object body)
		{
			await _squareUrl
				.AppendPathSegment(resource)
				.WithDefaults()
				.WithOAuthBearerToken(_authToken)
				.PutJsonAsync(body);
		}

		protected async Task DeleteAsync<T>(string resource, object queryParams)
		{
			await _squareUrl
				.AppendPathSegment(resource)
				.SetQueryParams(queryParams)
				.WithDefaults()
				.WithOAuthBearerToken(_authToken)
				.DeleteAsync();
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
