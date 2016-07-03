using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Claytondus.Square.Models;

namespace Claytondus.Square
{
    /// <summary>
    /// Square Connect Category Management API
    /// </summary>
    public class SquareCategoryClient : SquareClient
    {
        private readonly string _locationId;

        public SquareCategoryClient(string authToken, string locationId = "me") : base(authToken)
        {
            _locationId = locationId;
        }

        public async Task<SquareCategory> CreateCategoryAsync(SquareCategory category)
        {
            return await PostAsync<SquareCategory>("/v1/" + _locationId + "/categories", category);
        }

        public async Task<SquareResponse<List<SquareCategory>>> ListCategoriesAsync()
        {
            return await GetAsync<List<SquareCategory>>("/v1/" + _locationId + "/categories");
        }

        public async Task<SquareCategory> UpdateCategoryAsync(string categoryId, SquareCategory category)
        {
            return await PutAsync<SquareCategory>("/v1/" + _locationId + "/categories/" + categoryId);
        }

        public async Task DeleteCategoryAsync(string categoryId)
        {
            await DeleteAsync<string>("/v1/" + _locationId + "/categories/" + categoryId);
        }
    }
}
