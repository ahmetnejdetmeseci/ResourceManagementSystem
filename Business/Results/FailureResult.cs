using Business.Results.Basis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Results
{
	public class FailureResult : Result
	{

		public FailureResult(string Message) : base(false, Message)
		{

		}

        public FailureResult() : base(false, "")
        {
            
        }
    }
}
