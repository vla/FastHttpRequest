using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HttpRequest;

namespace ConsoleTest
{
    public class Issues_1 : TestExcute
    {
        public override bool Off {
            get {
                return base.Off;
            }
        }

        public override void Execute()
        {
            string url = "https://docs.microsoft.com/aspnet";
            var res = HttpHelper.Request(new HttpHelper.HttpParam()
            {
                Method = HttpHelper.HttpVerb.Get,
                AllowAutoRedirect = true
            }).ToStringResult();

            Console.WriteLine("Result " + res);
        }

    }
}
