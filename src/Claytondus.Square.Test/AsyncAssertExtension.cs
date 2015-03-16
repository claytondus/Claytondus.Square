using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Claytondus.Square.Test
{
	internal class AsyncAssertExtension
	{
		public static async Task<T> ThrowsAsync<T>(Func<Task> task) where T : Exception
		{
			try
			{
				await task();
			}
			catch (Exception ex)
			{
				Assert.IsInstanceOfType(ex, typeof (T));
				return (T) ex;
			}

			if (typeof (T) == new Exception().GetType())
				Assert.Fail("Expected exception but no exception was thrown.");
			else
				Assert.Fail("Expected exception of type {0} but no exception was thrown.", typeof (T));

			return null;
		}
	}
}