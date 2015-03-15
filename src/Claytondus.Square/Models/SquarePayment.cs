using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl;
using Newtonsoft.Json;

namespace Claytondus.Square.Models
{
	public class SquarePayment
	{
		[JsonProperty(PropertyName = "id")]
		public string Id { get; set; }

		[JsonProperty(PropertyName = "merchant_id")]
		public string MerchantId { get; set; }

		[JsonProperty(PropertyName = "created_at")]
		public DateTimeOffset CreatedAt { get; set; }

		[JsonProperty(PropertyName = "creator_id")]
		public string CreatorId { get; set; }

		[JsonProperty(PropertyName = "device")]
		public SquareDevice Device { get; set; }

		[JsonProperty(PropertyName = "payment_url")]
		public Url PaymentUrl { get; set; }

		[JsonProperty(PropertyName = "receipt_url")]
		public Url ReceiptUrl { get; set; }

		[JsonProperty(PropertyName = "inclusive_tax_money")]
		public SquareMoney InclusiveTaxMoney { get; set; }

		[JsonProperty(PropertyName = "additive_tax_money")]
		public SquareMoney AdditiveTaxMoney { get; set; }

		[JsonProperty(PropertyName = "tax_money")]
		public SquareMoney TaxMoney { get; set; }

		[JsonProperty(PropertyName = "tip_money")]
		public SquareMoney TipMoney { get; set; }

		[JsonProperty(PropertyName = "discount_money")]
		public SquareMoney DiscountMoney { get; set; }

		[JsonProperty(PropertyName = "total_collected_money")]
		public SquareMoney TotalCollectedMoney { get; set; }

		[JsonProperty(PropertyName = "net_total_money")]
		public SquareMoney NetTotalMoney { get; set; }

		[JsonProperty(PropertyName = "refunded_money")]
		public SquareMoney RefundedMoney { get; set; }

		[JsonProperty(PropertyName = "inclusive_tax")]
		public IEnumerable<SquarePaymentTax> InclusiveTax { get; set; }

		[JsonProperty(PropertyName = "additive_tax")]
		public IEnumerable<SquarePaymentTax> AdditiveTax { get; set; }

		[JsonProperty(PropertyName = "tender")]
		public IEnumerable<SquareTender> Tender { get; set; }

		[JsonProperty(PropertyName = "refund")]
		public IEnumerable<SquareRefund> Refund { get; set; }

		[JsonProperty(PropertyName = "itemizations")]
		public IEnumerable<SquarePaymentItemization> Itemizations { get; set; }


	}


}
