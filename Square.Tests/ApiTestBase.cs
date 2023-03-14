namespace Square
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using APIMatic.Core.Types;
    using NUnit.Framework;
    using Square;
    using Square.Http.Client;
    using Square.Models;

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
        internal HttpCallBack HttpCallBack { get; private set; } = new HttpCallBack();

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
            this.Client = config.ToBuilder()
                .HttpCallBack(HttpCallBack)
                .Build();
        }
    }
}