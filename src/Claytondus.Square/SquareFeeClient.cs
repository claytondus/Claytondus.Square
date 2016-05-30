using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Claytondus.Square.Models;

namespace Claytondus.Square
{
    /// <summary>
    /// Square Connect Fee Management API
    /// </summary>
    public class SquareFeeClient : SquareClient
	{
		private readonly string _locationId;

		public SquareFeeClient(string authToken, string locationId = "me") : base(authToken)
		{
			_locationId = locationId;
		}

        public async Task<SquareFee> CreateFeeAsync(string modifierListId, SquareFee fee)
        {
            return await PostAsync<SquareFee>("/v1/" + _locationId + "/fees", fee);
		}

        public async Task<SquareResponse<List<SquareFee>>> ListFeesAsync()
        {
            return await GetAsync<List<SquareFee>>("/v1/" + _locationId + "/fees");
        }

        public async Task<SquareFee> UpdateFeeAsync(string feeId, SquareFee fee)
        {
            return await PutAsync<SquareFee>("/v1/" + _locationId + "/fees/" + feeId, fee);
        }

        public async Task DeleteFeeAsync(string feeId)
        {
            await DeleteAsync<string>("/v1/" + _locationId + "/fees/" + feeId);
        }

    }
}