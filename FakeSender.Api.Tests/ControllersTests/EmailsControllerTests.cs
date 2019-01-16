using System.Collections.Generic;
using System.Linq;
using FakeSender.Api.Controllers;
using FakeSender.Api.Data;
using FakeSender.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace FakeSender.Api.Tests.ControllersTests
{
    public class EmailsControllerTests : ControllerTestsBase<EmailsController>
    {
        public EmailsControllerTests()
            : base("emails")
        {
        }
        
        [Fact]
        public void PostEmailList_ReturnsEmail_SavedInDb()
        {
            using (var db = new ApplicationContext(Options))
            {
                var controller = new EmailsController(db, Logger);

                var expectedEmail = new Email
                {
                    Attachments = "some bytes",
                    Html = "<b>My email</b>",
                    Subject = "Subj",
                    To = "test"
                };
                var expectedList = new List<Email>
                {
                    expectedEmail
                };
                var result = controller.Post(expectedList);
                
                Assert.IsType<OkObjectResult>(result);
                Assert.Equal(expectedEmail.ToJson(), ((result as OkObjectResult).Value as List<Email>).First().ToJson());
                Assert.Equal(1, db.EmailBox.Count());
                Assert.Equal(expectedEmail.ToJson(), db.EmailBox.First().ToJson());
            }
        }

        [Fact]
        public void PostNothing_ReturnsBadRequest()
        {
            using (var db = new ApplicationContext(Options))
            {
                var controller = new EmailsController(db, Logger);

                var result = controller.Post(null);
                
                Assert.IsType<BadRequestResult>(result);
            }
        }
    }

    
}