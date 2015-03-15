using System.Collections.Generic;
using Newtonsoft.Json;

namespace Claytondus.Square.Models
{
	public class SquarePaymentItemization
	{
		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "quantity")]
		public decimal Quantity { get; set; }

		[JsonProperty(PropertyName = "item_detail")]
		public SquarePaymentItemDetail ItemDetail { get; set; }

		[JsonProperty(PropertyName = "notes")]
		public string Notes { get; set; }

		[JsonProperty(PropertyName = "item_variation_name")]
		public string VariationName { get; set; }

		[JsonProperty(PropertyName = "total_money")]
		public SquareMoney TotalMoney { get; set; }

		[JsonProperty(PropertyName = "single_quantity_money")]
		public SquareMoney SingleQuantityMoney { get; set; }

		[JsonProperty(PropertyName = "gross_sales_money")]
		public SquareMoney GrossSalesMoney { get; set; }

		[JsonProperty(PropertyName = "discount_money")]
		public SquareMoney DiscountMoney { get; set; }

		[JsonProperty(PropertyName = "net_sales_money")]
		public SquareMoney NetSalesMoney { get; set; }

		[JsonProperty(PropertyName = "taxes")]
		public IEnumerable<SquarePaymentTax> Taxes { get; set; }
		
		[JsonProperty(PropertyName = "discounts")]
		public IEnumerable<SquareDiscount> Discounts { get; set; }

		[JsonProperty(PropertyName = "modifiers")]
		public IEnumerable<SquareModifier> Modifiers { get; set; }
	}
}