using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claytondus.Square.Models
{
	public sealed class SquareListOrder
	{
		private readonly string _name;
		private readonly int _value;

		public static readonly SquareListOrder ASC = new SquareListOrder(1, "ASC");
		public static readonly SquareListOrder DESC = new SquareListOrder(2, "DESC");

		private SquareListOrder(int value, string name)
		{
			_name = name;
			_value = value;
		}

		public override string ToString()
		{
			return _name;
		}
	}
}
