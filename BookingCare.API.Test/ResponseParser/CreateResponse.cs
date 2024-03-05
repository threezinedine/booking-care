using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingCare.API.Test.ResponseParser
{
	public class CreateResponse<T>
	{
		public string ActionName { get; set; } = string.Empty;
		public T? Value { get; set; }
	}
}
