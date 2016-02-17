using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Claytondus.Square.Models;

namespace Claytondus.Square
{
    /// <summary>
    /// Square Connect Item Management API: 
    /// Square merchants can create, modify, and delete items and related entities with these endpoints. 
    /// Changes made with these endpoints automatically sync with the merchant dashboard and all of 
    /// a merchant's instances of Square Register.
    /// </summary>
    public class SquareItemClient : SquareClient
	{
		private readonly string _merchantId;
		/// <summary>
		///     Instantiate a client for accessing Square transactions.
		/// </summary>
		/// <param name="authToken">Merchant OAuth token or personal access token.</param>
		/// <param name="merchantId">
		///		Your Square-issued ID, if you've obtained it from another endpoint. 
		///		If you haven't, specify me for the Connect API to automatically determine your merchant ID based on your request's access token.
		/// </param>
		public SquareItemClient(string authToken, string merchantId = "me") : base(authToken)
		{
			_merchantId = merchantId;
		}

        /// <summary>
        ///     Modifies the core details of an existing item.
        ///     If you want to modify an item's variations, use the Update Variation endpoint instead.
        ///     If you want to add or remove a modifier list from an item, use the Apply Modifier List and Remove Modifier List endpoints instead.
        ///     If you want to add or remove a fee from an item, use the Apply Fee and Remove Fee endpoints instead.
        ///     Required permissions: ITEMS_WRITE
        /// </summary>
        /// <returns cref="SquareItem">Item object that represents the updated item.</returns>
        /// <exception cref="SquareException">Error returned from Square Connect.</exception>
        public async Task<SquareItem> UpdateItemAsync(string itemId, SquareItemUpdate item)
		{
			return await PutAsync<SquareItem>("/v1/" + _merchantId + "/items/" + itemId, item);
		}



	}
}