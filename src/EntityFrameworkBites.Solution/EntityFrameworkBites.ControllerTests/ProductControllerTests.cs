using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using EntityFrameworkBites.WebApp.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TestStack.FluentMVCTesting;


namespace EntityFrameworkBites.ControllerTests
{
    [TestClass]
    public class ProductControllerTests
    {
        private readonly ProductController _sutController;

        public ProductControllerTests()
        {
            _sutController = new ProductController();
            _sutController.ControllerContext = new ControllerContext(GetMockedContext(),
                                    new RouteData(), _sutController); ;
        }
        [TestMethod]
        public void ShouldReturnDefaultViewForIndexAction()
        {
            _sutController.WithCallTo(c => c.Index()).ShouldRenderDefaultView();

        }

        private HttpContextBase GetMockedContext()
        {
            var server = new Mock<HttpServerUtilityBase>(MockBehavior.Loose);
            var response = new Mock<HttpResponseBase>(MockBehavior.Strict);

            var request = new Mock<HttpRequestBase>(MockBehavior.Strict);
            request.Setup(r => r.UserHostAddress).Returns("127.0.0.1");

            var session = new Mock<HttpSessionStateBase>();
            session.Setup(s => s.SessionID).Returns(Guid.NewGuid().ToString());

            var context = new Mock<HttpContextBase>();
            context.SetupGet(c => c.Request).Returns(request.Object);
            context.SetupGet(c => c.Response).Returns(response.Object);
            context.SetupGet(c => c.Server).Returns(server.Object);
            context.SetupGet(c => c.Session).Returns(session.Object);

            return context.Object;
        }
    }
}
