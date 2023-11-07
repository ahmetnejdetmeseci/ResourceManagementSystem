using Business.Results.Basis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Results
{
	public class SuccessResult : Result
	{
		//Example1 : Result result = new SuccessResult("Operation Successful");
		//Example2 : Result result = new SuccessResult();

		//otomatik olarak true gonderdik success result oldugu icin
		public SuccessResult(string Message) : base(true, Message)
		{

		}

        public SuccessResult() : base(true, "")
        {
            
        }
    }
}
