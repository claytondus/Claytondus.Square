using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Claytondus.Square.Models;
using Flurl.Http;

namespace Claytondus.Square
{
    /// <summary>
    /// Square Connect Batch Request API
    /// </summary>
    public class SquareBatchClient : SquareClient
	{
        /// <summary>
        ///     Lets you batch multiple requests to other Connect API endpoints into a single request. 
        ///     This endpoint's response is an array that contains the response for each batched request.
        ///     You don't need to provide an access token in the header of your request to the Submit Batch endpoint. 
        ///     Instead, you provide an access_token parameter for each request included in the batch.
        ///     Note the following when using the Submit Batch endpoint:
        ///         -You cannot include more than 30 requests in a single batch.
        ///         -Recursive requests to the Submit Batch endpoint are not allowed(i.e., none of the 
        ///             requests included in a batch can itself be a request to this endpoint).
        ///         -There is no guarantee of the order in which batched requests are performed.
        /// </summary>
        /// <returns cref="SquareItem">Item object that represents the updated item.</returns>
        /// <exception cref="SquareException">Error returned from Square Connect.</exception>
        public async Task<List<SquareBatchResponse>> SubmitAsync(List<SquareBatchRequest> request)
		{
            try
            {
                return await new Flurl.Url(SquareUrl)
                    .AppendPathSegment("/v1/batch")
                    .WithDefaults()
                    .PostJsonAsync(request)
                    .ReceiveJson<List<SquareBatchResponse>>();
            }
            catch (FlurlHttpTimeoutException)
            {
                throw new SquareException("timeout", "Request timed out.");
            }
            catch (FlurlHttpException ex)
            {
                var squareEx = await ex.GetResponseJsonAsync<SquareException>();
                squareEx.HttpStatus = ex.Call.HttpStatus;
                throw squareEx;
            }
        }



	}
}