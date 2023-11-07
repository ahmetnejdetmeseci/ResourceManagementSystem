using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace Business.Results.Basis
{
    public abstract class Result
    {
		public bool IsSuccessful { get; } //readonly : can only be assigned through constructor

        public string Message { get; set;  }

		protected Result(bool isSuccessful, string message)
		{
			IsSuccessful = isSuccessful;
			Message = message;
		}

	}
}
