using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Claytondus.Square.Models;

namespace Claytondus.Square
{
    /// <summary>
    /// Square Connect Modifier Option Management API
    /// </summary>
    public class SquareModifierOptionClient : SquareClient
	{
		private readonly string _locationId;
		/// <summary>
		///     Instantiate a client for accessing Square modifier options.
		/// </summary>
		/// <param name="authToken">Merchant OAuth token or personal access token.</param>
		/// <param name="locationId">
		///		Your Square-issued location ID, if you've obtained it from another endpoint. 
		///		If you haven't, specify me for the Connect API to automatically determine your location ID based on your request's access token.
		/// </param>
		public SquareModifierOptionClient(string authToken, string locationId = "me") : base(authToken)
		{
			_locationId = locationId;
		}

        /// <summary>
        ///    Creates an item modifier option and adds it to a modifier list.
        ///    Required permissions: ITEMS_WRITE
        /// </summary>
        /// <returns cref="SquareModifierOption">Item object that represents the option.</returns>
        /// <exception cref="SquareException">Error returned from Square Connect.</exception>
        public async Task<SquareModifierOption> CreateModifierListAsync(string modifierListId, SquareModifierOption list)
        {
            return await PostAsync<SquareModifierOption>("/v1/" + _locationId + "/modifier-lists/"+ modifierListId + "/modifier-options", list);
		}

	}
}