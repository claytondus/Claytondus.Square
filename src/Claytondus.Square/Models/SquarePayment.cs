using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claytondus.Square.Models
{
	public class SquarePayment
	{
		public string Id { get; set; }
		public string MerchantId { get; set; }
		public DateTimeOffset CreatedAt { get; set; }
		public string CreatorId { get; set; }
		public SquareDevice Device { get; set; }
		public Uri PaymentUri { get; set; }
		public Uri ReceiptUri { get; set; }
		public SquareMoney InclusiveTaxMoney { get; set; }
		public SquareMoney AdditiveTaxMoney { get; set; }
		public SquareMoney TaxMoney { get; set; }
		public SquareMoney TipMoney { get; set; }
		public SquareMoney DiscountMoney { get; set; }
		public SquareMoney TotalCollectedMoney { get; set; }
		public SquareMoney NetTotalMoney { get; set; }
		public SquareMoney RefundedMoney { get; set; }
		public IEnumerable<SquarePaymentTax> InclusiveTax { get; set; }
		public IEnumerable<SquarePaymentTax> AdditiveTax { get; set; }
		public IEnumerable<SquareTender> Tender { get; set; }
		public IEnumerable<SquareRefund> Refund { get; set; }
		public IEnumerable<SquarePaymentItemization> Itemizations { get; set; }


	}


}
