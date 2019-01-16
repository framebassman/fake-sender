using System;
using System.Linq;
using FakeSender.Api.Controllers;
using FakeSender.Api.Controllers.Responses;
using FakeSender.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace FakeSender.Api.Tests.ControllersTests.SmsRuControllerTests
{
    public class NewAccountTests : SmsRuTestsFixture
    {
        private readonly SmsRuController _controller;

        public NewAccountTests()
        {
            this._controller = new SmsRuController(this.Db, this.Logger);
        }
        
        public override void Dispose()
        {
            this.Db.SmsBox.RemoveRange(this.Db.SmsBox);
            this.Db.Accounts.RemoveRange(this.Db.Accounts);
            this.Db.SaveChanges();
        }

        [Fact]
        public void SendMessageFromUnknownAccount_SmsWasSaved_AccountWasSaved()
        {
            // Arrange 
            var phone = new Phone(7, 999, 9999999);
            var message = "Hi";
            var expected = new Sms
            {
                To = phone.ToString(),
                Message = message
            };
            var unknown = new Account
            {
                Type = "sms",
                Service = "unknown",
                Login = "test",
                Balance = 0
            };
            
            // Act
            var result = this._controller.Send(
                Guid.Empty,
                unknown.Login, 
                1,
                Uri.EscapeUriString(message),
                phone.ToString()
            );

            // Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(expected.ToJson(), this.Db.SmsBox.First(s => s.To == phone.ToString()).ToJson());
            Assert.True(
                this.Db.Accounts.Any(a => a.Login == unknown.Login), 
                "Unknown account should be saved in Database"
            );
        }
    }
}