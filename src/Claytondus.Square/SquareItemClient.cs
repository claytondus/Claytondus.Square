using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Claytondus.Square.Logging;
using Claytondus.Square.Models;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json.Linq;

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
		private readonly string _locationId;
        private static readonly ILog Log = LogProvider.GetCurrentClassLogger();

        /// <summary>
        ///     Instantiate a client for accessing Square transactions.
        /// </summary>
        /// <param name="authToken">Merchant OAuth token or personal access token.</param>
        /// <param name="locationId">
        ///		Your Square-issued ID, if you've obtained it from another endpoint. 
        ///		If you haven't, specify me for the Connect API to automatically determine your location ID based on your request's access token.
        /// </param>
        public SquareItemClient(string authToken, string locationId = "me") : base(authToken)
		{
			_locationId = locationId;
		}

        public async Task<SquareItem> CreateItemAsync(SquareItemCreate item)
        {
            return await PostAsync<SquareItem>("/v1/" + _locationId + "/items", item);
        }

        public async Task<SquareResponse<List<SquareItem>>> ListItemsAsync()
        {
            return await GetAsync<List<SquareItem>>("/v1/" + _locationId + "/items");
        }

        public async Task<SquareResponse<SquareItem>> RetrieveItemAsync(string itemId)
        {
            return await GetAsync<SquareItem>("/v1/" + _locationId + "/items/" + itemId);
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
			return await PutAsync<SquareItem>("/v1/" + _locationId + "/items/" + itemId, item);
		}

        public async Task DeleteItemAsync(string itemId)
        {
            await DeleteAsync<string>("/v1/" + _locationId + "/items/" + itemId);
        }

        public async Task<SquareItemImage> UploadItemImageAsync(string itemId, byte[] imageData, string mimeType)
        {
            var requestContent = new MultipartFormDataContent();
            var imageContent = new ByteArrayContent(imageData);
            imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse(mimeType);
            requestContent.Add(imageContent, "image_data", "image.jpg");

            var resource = "/v1/" + _locationId + "/items/" + itemId + "/image";
            return await PostAsync<SquareItemImage>(resource, requestContent);
        }

        public async Task<SquareItem> CreateVariationAsync(string itemId, SquareItemVariation variation)
        {
            return await PostAsync<SquareItem>("/v1/" + _locationId + "/items/" + itemId + "/variations", variation);
        }

        public async Task<SquareItem> UpdateVariationAsync(string itemId, string variationId, SquareItemVariation variation)
        {
            return await PutAsync<SquareItem>("/v1/" + _locationId + "/items/" + itemId + "/variations/" + variationId, variation);
        }

        public async Task DeleteVariationAsync(string itemId, string variationId)
        {
            await DeleteAsync<string>("/v1/" + _locationId + "/items/" + itemId + "/variations/" + variationId);
        }

        /// <summary>
        ///     Associates a modifier list with an item, meaning modifier options from the list can be applied to the item.
        ///     Required permissions: ITEMS_WRITE
        /// </summary>
        /// <returns cref="SquareItem">Item object that represents the updated item.</returns>
        /// <exception cref="SquareException">Error returned from Square Connect.</exception>
        public async Task<object> ApplyModifierListAsync(string itemId, string modifierListId)
        {
            return await PutAsync<object>(
                "/v1/" + _locationId + "/items/" + itemId + "/modifier-lists/" + modifierListId, new JObject());
        }

        public async Task<object> RemoveModifierListAsync(string itemId, string modifierListId)
        {
            return await DeleteAsync<object>(
                "/v1/" + _locationId + "/items/" + itemId + "/modifier-lists/" + modifierListId, new JObject());
        }

        public async Task<object> ApplyFeeAsync(string itemId, string feeId)
        {
            return await PutAsync<object>(
                "/v1/" + _locationId + "/items/" + itemId + "/fees/" + feeId, new JObject());
        }

        public async Task<object> RemoveFeeAsync(string itemId, string feeId)
        {
            return await DeleteAsync<object>(
                "/v1/" + _locationId + "/items/" + itemId + "/fees/" + feeId, new JObject());
        }

    }
}