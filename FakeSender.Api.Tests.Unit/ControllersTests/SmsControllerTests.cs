using System.Collections.Generic;
using System.Linq;
using FakeSender.Api.Controllers;
using FakeSender.Api.Data;
using FakeSender.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace FakeSender.Api.Tests.Unit.ControllersTests
{
    public class SmsControllerTests : ControllerTestsBase<SmsController>
    {
        [Fact]
        public void PostSmsList_ReturnsSms_SavedInDb()
        {
            using (var db = new ApplicationContext(Options))
            {
                var controller = new SmsController(db, Logger);
                var expected = new Sms
                {
                    Message = "test",
                    To = "test boy"
                };
                var expectedList = new List<Sms> { expected };
                
                var result = controller.Post(expectedList);
                
                Assert.IsType<OkObjectResult>(result);
                Assert.Equal(expected.ToJson(), ((result as OkObjectResult).Value as List<Sms>).First().ToJson());
                Assert.Equal(1, db.SmsBox.Count());
                Assert.Equal(expected.ToJson(), db.SmsBox.First().ToJson());
            }
        }

        [Fact]
        public void PostNothing_ReturnsBadRequest()
        {
            using (var db = new ApplicationContext(Options))
            {
                var controller = new SmsController(db, Logger);

                var result = controller.Post(null);

                Assert.IsType<BadRequestResult>(result);
            }
        }
    }
}