using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Claytondus.Square.Models;

namespace Claytondus.Square
{
    /// <summary>
    /// Square Connect Modifier List Management API
    /// </summary>
    public class SquareModifierListClient : SquareClient
	{
		private readonly string _locationId;
		/// <summary>
		///     Instantiate a client for accessing Square modifier lists.
		/// </summary>
		/// <param name="authToken">Merchant OAuth token or personal access token.</param>
		/// <param name="locationId">
		///		Your Square-issued location ID, if you've obtained it from another endpoint. 
		///		If you haven't, specify me for the Connect API to automatically determine your location ID based on your request's access token.
		/// </param>
		public SquareModifierListClient(string authToken, string locationId = "me") : base(authToken)
		{
			_locationId = locationId;
		}

        /// <summary>
        ///    Creates an item modifier list and at least one modifier option for it.
        ///    Required permissions: ITEMS_WRITE
        /// </summary>
        /// <returns cref="SquareModifierList">Item object that represents the updated item.</returns>
        /// <exception cref="SquareException">Error returned from Square Connect.</exception>
        public async Task<SquareModifierList> CreateModifierListAsync(SquareModifierList list)
        {
            return await PostAsync<SquareModifierList>("/v1/" + _locationId + "/modifier-lists", list);
		}

        public async Task<SquareResponse<List<SquareModifierList>>> ListModifierListsAsync()
        {
            return await GetAsync<List<SquareModifierList>>("/v1/" + _locationId + "/modifier-lists");
        }

        public async Task<SquareResponse<SquareModifierList>> RetrieveModifierListAsync(string modifierListId)
        {
            return await GetAsync<SquareModifierList>("/v1/" + _locationId + "/modifier-lists/" + modifierListId);
        }

        public async Task DeleteModifierListAsync(string modifierListId)
        {
            await DeleteAsync<string>("/v1/" + _locationId + "/modifier-lists/" + modifierListId);
        }
    }
}