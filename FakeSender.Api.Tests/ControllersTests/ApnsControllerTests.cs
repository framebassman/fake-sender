using System.Linq;
using FakeSender.Api.Controllers;
using FakeSender.Api.Data;
using FakeSender.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace FakeSender.Api.Tests.ControllersTests
{
    public class ApnsControllerTests : ControllerTestsBase<ApnsController>
    {        
        public ApnsControllerTests()
            : base("apns")
        {
        }
        
        [Fact]
        public void PostQuery_ReturnsApnsQuery_SavedInDb()
        {
            using (var db = new ApplicationContext(Options))
            {
                var controller = new ApnsController(db, Logger);

                var expected = new ApnsQuery
                {
                    ApplePassTypeId = "test",
                    PushToken = "test_token"
                };
                
                var result = controller.PostQuery(expected);
                
                Assert.IsType<OkObjectResult>(result);
                Assert.Equal(expected.ToJson(), ((result as OkObjectResult).Value as ApnsQuery).ToJson());
                Assert.Equal(1, db.ApnsQueryBox.Count());
                Assert.Equal(expected.ToJson(), db.ApnsQueryBox.First().ToJson());
            }
        }

        [Fact]
        public void PostNothing_ReturnsBadRequest()
        {
            using (var db = new ApplicationContext(Options))
            {
                var controller = new ApnsController(db, Logger);

                var result = controller.PostQuery(null);

                Assert.IsType<BadRequestResult>(result);
            }
        }
    }
}