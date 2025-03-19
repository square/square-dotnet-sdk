using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Square.Legacy;
using Square.Legacy.Authentication;
using Square.Legacy.Http.Client;
using Square.Legacy.Models;

namespace Square.Legacy
{
    /// <summary>
    /// ControllerTestBase Class.
    /// </summary>
    [TestFixture]
    public class ApiTestBase
    {
        /// <summary>
        /// Assert precision.
        /// </summary>
        protected const double AssertPrecision = 0.1;

        /// <summary>
        /// Gets HttpCallBackHandler.
        /// </summary>
        internal HttpCallback HttpCallBack { get; private set; } = new HttpCallback();

        /// <summary>
        /// Gets SquareClient Client.
        /// </summary>
        protected SquareClient Client { get; private set; }

        /// <summary>
        /// Set up the client.
        /// </summary>
        [OneTimeSetUp]
        public void SetUp()
        {
            SquareClient config = SquareClient.CreateFromEnvironment();
            this.Client = config.ToBuilder().HttpCallback(HttpCallBack).Build();
        }
    }
}
