using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Claytondus.Square.Models
{
	public class SquareOrder
	{
		[JsonProperty(PropertyName = "id")]
		public string Id { get; set; }

		[JsonProperty(PropertyName = "state")]
		public string State { get; set; }

		[JsonProperty(PropertyName = "buyer_email")]
		public string BuyerEmail { get; set; }

		[JsonProperty(PropertyName = "recipient_name")]
		public string RecipientName { get; set; }

		[JsonProperty(PropertyName = "recipient_phone_number")]
		public string RecipientPhone { get; set; }

		[JsonProperty(PropertyName = "shipping_address")]
		public SquareGlobalAddress ShippingAddress { get; set; }

		[JsonProperty(PropertyName = "subtotal_money")]
		public SquareMoney SubtotalMoney { get; set; }

		[JsonProperty(PropertyName = "total_shipping_money")]
		public SquareMoney TotalShippingMoney { get; set; }

		[JsonProperty(PropertyName = "total_tax_money")]
		public SquareMoney TotalTaxMoney { get; set; }

		[JsonProperty(PropertyName = "total_price_money")]
		public SquareMoney TotalPriceMoney { get; set; }

		[JsonProperty(PropertyName = "total_discount_money")]
		public SquareMoney TotalDiscountMoney { get; set; }

		[JsonProperty(PropertyName = "created_at")]
		public DateTimeOffset CreatedAt { get; set; }

		[JsonProperty(PropertyName = "updated_at")]
		public DateTimeOffset UpdatedAt { get; set; }

		[JsonProperty(PropertyName = "expires_at")]
		public DateTimeOffset ExpiresAt { get; set; }

		[JsonProperty(PropertyName = "payment_id")]
		public string PaymentId { get; set; }

		[JsonProperty(PropertyName = "buyer_note")]
		public string BuyerNote { get; set; }

		[JsonProperty(PropertyName = "completed_note")]
		public string CompletedNote { get; set; }

		[JsonProperty(PropertyName = "refunded_note")]
		public string RefundedNote { get; set; }

		[JsonProperty(PropertyName = "canceled_note")]
		public string CanceledNote { get; set; }

		[JsonProperty(PropertyName = "tender")]
		public SquareTender Tender { get; set; }

		[JsonProperty(PropertyName = "order_history")]
		public List<SquareOrderHistory> History { get; set; }

		[JsonProperty(PropertyName = "promo_code")]
		public string PromoCode { get; set; }

		[JsonProperty(PropertyName = "btc_receive_address")]
		public string BtcReceiveAddress { get; set; }

		[JsonProperty(PropertyName = "btc_price_satoshi")]
		public int BtcPriceSatoshi { get; set; }
	}
}