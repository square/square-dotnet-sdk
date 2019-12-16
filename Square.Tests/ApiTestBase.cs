using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Http.Client;
using Square.Helpers;
using Square.Models;

namespace Square
{
    [TestFixture]
    public class ApiTestBase
    {
        //Test setup
        public const int REQUEST_TIMEOUT = 60;
        protected const double ASSERT_PRECISION = 0.1;
        public TimeSpan globalTimeout = TimeSpan.FromSeconds(REQUEST_TIMEOUT);

        protected SquareClient client;

        internal HttpCallBack httpCallBackHandler;

        [OneTimeSetUp]
        public void SetUp()
        {
            httpCallBackHandler = new HttpCallBack();
            client = SquareClient.CreateFromEnvironment().ToBuilder()
                .HttpCallBack(httpCallBackHandler)
                .Build();
        }
    }
}